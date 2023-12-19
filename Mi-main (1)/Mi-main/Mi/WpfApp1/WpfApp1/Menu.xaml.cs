using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private List<string> TowarList = new List<string>();
        public string Name1;
        string server = "10.112.48.11";
        string database = "lesuser9";
        string username = "lesuser9";
        string passwordDB = "lesuser9";
        public Menu()
        {
            InitializeComponent();
            podkl();
            myTextBox1.TextChanged += myTextBox1_TextChanged;
        }
        private void podkl()
        {
           
            using (SqlConnection connection = new SqlConnection($"Server={server};Database={database};User ID={username};Password={passwordDB}"))
            {

                //login = email.Text;
                //password = Password.Text;
                connection.Open();

                string sql = "SELECT * FROM Product";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Name1 = reader["product"].ToString();
                            TowarList.Add($" {Name1}");

                        }
                    }
                }
            }
            TowarListView.ItemsSource = TowarList;
        }
       
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
          

            using (SqlConnection connection = new SqlConnection($"Server={server};Database={database};User ID={username};Password={passwordDB}"))
            {
                string selectedItemText = TowarListView.SelectedItem as string;
                connection.Open();

                if (!string.IsNullOrEmpty(selectedItemText))
                {
                    string sql = $"INSERT INTO Korzina (product)  VALUES (@product)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@product", $"{selectedItemText}");
                        command.ExecuteNonQuery();
                        Button button = sender as Button;
                        button.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    MessageBox.Show("Выбранный товар не может быть пустым");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Korzina());
           // frame.Navigate(new Korzina());
        }


        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Info());
        }
        private void Out(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void myTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
           

            // Поиск элементов, содержащих введенный текст
            string filterText = myTextBox1.Text;
            var filteredItems = TowarList.Where(item => item.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0);
            TowarListView.ItemsSource = filteredItems;
        }
       
    }
    }


