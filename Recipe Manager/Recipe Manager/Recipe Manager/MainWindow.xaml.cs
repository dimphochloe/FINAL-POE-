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

namespace Recipe_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtOption_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Option = int.Parse(txtOption.Text);

            switch (Option)
            {
                case 1:
                    // add recipe form
                    Add_Recipe Add_Recipt= new Add_Recipe();
                    Add_Recipt.Show();
                    break;
                case 2:
                    // Code block
                    break;
                case 3:
                    // Displays all Recipes
                    Display_Recipe Display = new Display_Recipe();
                    Display.Show();
                    break;
                case 4:
                    // code block
                    break;
                case 5:
                    // code block
                    break;
                case 6:
                    //Opens a form that clears all data
                    Clear_All clear_All = new Clear_All();
                    clear_All.Show();
                    break;
                case 7:
                    //Closing the Application
                    Environment.Exit(0);
                    break;
                default:
                    MessageBox.Show("Invalid Option");
                    txtOption.Text = " ";
                    break;
            }

            txtOption.Text = "";
        }
    }
}
