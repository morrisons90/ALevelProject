using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace ALevelProject
{
    static class SQLI
    {
        //Creates a new connection object
        private static SqlConnection NewConnection()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Josh\source\repos\ALevelProject\ALevelProject\ALevelProject\Database1.mdf;Integrated Security=True");
            conn.Open();

            return conn;
        }
        //Returns a single row in the form of a list
        public static ArrayList SingleResultQuery(String query)
        {
            SqlConnection conn = NewConnection();

            SqlCommand command = new SqlCommand(query, conn);                      
            try
            {
                var result = command.ExecuteReader();
                result.Read();
                ArrayList results = new ArrayList();
                for(var i=0; i<result.FieldCount; i++) //from the index 0 to the number of fields -1 (for base 0)
                {
                    results.Add(result.GetValue(i));
                }
                return results;
            }
            catch(SqlException e)
            {
                Console.WriteLine("Error With Query");
                return (new ArrayList {"Fail"});
            }

        }
        //Returns a results object
        public static List<T> searchQuery<T>(String query)
        {
            SqlConnection conn = NewConnection();

            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                var result = command.ExecuteReader();
                List<T> resultArray = new List<T>();
                while(result.Read())
                {
                    List<string> fields = new List<string>();
                    for(var i=0; i<result.FieldCount; i++)
                    {
                        if(result.GetFieldType(i) == typeof(string))
                        {
                            fields.Add(result.GetString(i));
                        } else
                        {
                            fields.Add(result.GetInt32(i).ToString());
                        }
                        
                    }
                    T resultObject = (T)Activator.CreateInstance(typeof(T), fields.ToArray());
                    resultArray.Add(resultObject);
                }
                return resultArray;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
