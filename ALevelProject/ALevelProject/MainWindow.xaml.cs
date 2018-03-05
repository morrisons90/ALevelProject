using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ALevelProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Get Instruction text from database
            var instructions = (string)SQLI.SingleResultQuery("SELECT data FROM GUITexts WHERE ref='MainInstructions'")[0]; //This function returns a ArrayList but the query only returns 1 item so [0]
            var instructionsP = instructions.Replace("\\n",Environment.NewLine);
            instructionsText.DataContext = instructionsP;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
