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
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace Recipe_Manager
{
    /// <summary>
    /// Interaction logic for Clear_All.xaml
    /// </summary>
    public partial class Clear_All : Window
    {
        public Clear_All()
        {
            InitializeComponent();
        }

        //methods that designs the header
        public void Heading() {
            string Titles = $"RECIPE_NAME\t\tINGREDIENT_NUMBER\t\tINGREDIENT_NAME\t\tQUANTITIES\t\tUNIT_OF_MEASURE\t\tNUMBER_OF_CALORIES\t\tFOOD_GROUP\t\tNUMBER_OF_STEPS\t\tSTEP_DESCRIPTION \n";
            string Border = $"=========================================================================================================================================================================================";

             string heading = Titles + Border;

            lstDsiplay.Items.Add(heading);
        }

        private void Recipe_List(object sender, RoutedEventArgs e)
        {
            //calling the header method that displays the header
            Heading();
            //Calling the retrieve method to display information on list box
            Retrieve();
        }

        //Method that collects information from the file repository 
        public void Retrieve()
        {

            string file = "./Recipes.txt";
            //Reading data from txt file and presents it to logic layer
            List<string> Information = File.ReadAllLines(file).ToList<string>();

            foreach (var data in Information)
            {
                var lines = data.Split('\t');
                lstDsiplay.Items.Add($"{lines[0]}\t\t\t{lines[1]}\t\t\t\t{lines[2]}\t\t\t{lines[3]}\t\t\t{lines[4]}\t\t\t\t{lines[5]}\t\t\t\t{lines[6]}\t\t\t{lines[7]}\t\t\t{lines[8]}");
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //closes the current form to navigate back to the menu
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //close the application
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //calling the method that clears data in the file repository
            ClearAll();
            Heading();
            Retrieve();
        }

        //Method that clears data in our file repository

        public void ClearAll() {
            string filePath = "./Recipes.txt";

            // Clear the contents of the text file
            File.WriteAllText(filePath, string.Empty);

            //clearing everything except the header
            lstDsiplay.Items.Remove(lstDsiplay.Items[0]);
            lstDsiplay.Items.Clear();
        }
    }
}
