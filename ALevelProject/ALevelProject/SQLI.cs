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
        private static SqlConnection NewConnection()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Josh\source\repos\ALevelProject\ALevelProject\ALevelProject\Database1.mdf;Integrated Security=True");
            conn.Open();

            return conn;
        }
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
    }
}
