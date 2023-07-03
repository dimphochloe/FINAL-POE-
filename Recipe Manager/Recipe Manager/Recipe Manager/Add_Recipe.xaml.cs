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

namespace Recipe_Manager
{
    /// <summary>
    /// Interaction logic for Add_Recipe.xaml
    /// </summary>
    public partial class Add_Recipe : Window
    {
        public Add_Recipe()
        {
            InitializeComponent();
        }

        private void txtRecipeName_Copy5_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //Closing the add recipe form to return back to the Menu option
            MainWindow Menu = new MainWindow();
            Close();
        }
      
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //calling two methods
;           StoreList();
            Clear();
            
        }

        public void Clear()
        {
            txtRecipeName.Clear();
            txtIngredientNumber.Clear();
            txtIngredientName.Clear();
            txtQuantity.Clear();
            txtMeasurement.Clear();
            txtCalories.Clear();
            cbFoodGroup.SelectedIndex = 0;
            txtSteps.Clear();
            txtDescription.Clear();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //when form is loaded, the combobox will display default values
        private void NewRecipe(object sender, RoutedEventArgs e)
        {
            cbFoodGroup.SelectedIndex = 0;
            cbFoodGroup.Items.Add("    --Please Select--");
            cbFoodGroup.Items.Add("Dairy");
            cbFoodGroup.Items.Add("Fruits");
            cbFoodGroup.Items.Add("Grains");
            cbFoodGroup.Items.Add("Protein Foods");
            cbFoodGroup.Items.Add("Vegetables");
                     
        }

        //returning the list
        public void StoreList()
        {
            try
            {
                //DECLEARING VARIABLES
                string Rcp_Name, Ing_Name, Food_Group, Step_Description;
                int Ing_Num, Quantities, Steps_Num;
                double Col_Num;
                var UOM="";

                Rcp_Name = txtRecipeName.Text;
                Ing_Num = int.Parse(txtIngredientNumber.Text);
                Ing_Name = txtIngredientName.Text;
                Quantities = int.Parse(txtQuantity.Text);
                UOM = txtMeasurement.Text;
                Col_Num = double.Parse(txtCalories.Text);
                Food_Group = cbFoodGroup.Text;
                Steps_Num = int.Parse(txtSteps.Text);
                Step_Description = (txtDescription.Text);

                string IngNum = Ing_Num.ToString();
                string Quantity = Quantities.ToString();
                string Colories = Col_Num.ToString();
                string StepNo = Steps_Num.ToString();
                string UnitOfMeasure = UOM.ToString();

                if (Rcp_Name == "" || Ing_Num.ToString() == "" || Ing_Name == "" || Quantities.ToString() == "" || UnitOfMeasure == "" || Col_Num.ToString() == "" || Food_Group == "" || Steps_Num.ToString() == " " || Step_Description == "")
                {
                    MessageBox.Show("Please fill in all the fields");
                }
                else
                {

                    //append to a list
                    string line = $"{Rcp_Name} \t{IngNum} \t{Ing_Name} \t{Quantity} \t{UOM} \t{Colories} \t{Food_Group} \t{StepNo} \t{Step_Description}\n";
                    Writing(line);
                    MessageBox.Show("New Recipe is added");
                }

            }
            catch (Exception error) {

                MessageBox.Show(error.Message);
            }
        }

        //method to store data in a file repository
        public void Writing(string line)
        {
            File.AppendAllText("./Recipes.txt", line);
        }
       

        private void cbFoodGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void lstResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
