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
using System.Xml.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Korzina.xaml
    /// </summary>
    public partial class Korzina : Page
    {
        private List<string> TowarList1 = new List<string>();
        public string Name2;
        string server = "DESKTOP-9MU0DUB";
        string database = "PR";
        string username = "MrTv";
        string passwordDB = "1";
        public Korzina()
        {
            InitializeComponent();
          podkl();

        }
        private void podkl()
        {
            
            using (SqlConnection connection = new SqlConnection($"Server={server};Database={database};User ID={username};Password={passwordDB}"))
            {

                //login = email.Text;
                //password = Password.Text;
                connection.Open();

                string sql = "SELECT * FROM Korzina";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            Name2 = reader["product"].ToString();
                            TowarList1.Add($" {Name2}");

                        }
                    }
                    connection.Close();
                }
            }
            TowarListView1.ItemsSource = TowarList1;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            

            using (SqlConnection connection = new SqlConnection($"Server={server};Database={database};User ID={username};Password={passwordDB}"))
            {
                // Предполагается, что TowarListView1 возвращает строку. Если нет, этот код нужно изменить.
                if (TowarListView1.SelectedItem == null)
                {
                    MessageBox.Show("No item selected");
                    return;
                }

                // Предположим, что selectedItemText получает данные напрямую из выбранного элемента в ListView
                string selectedItemText = TowarListView1.SelectedItem.ToString().Trim();
                if (string.IsNullOrEmpty(selectedItemText))
                {
                    MessageBox.Show("The selected item is invalid");
                    return;
                }
                selectedItemText = " " + selectedItemText;
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    // Параметризованный запрос без пробела внутри литерала строки SQL
                    string sql = "DELETE FROM Korzina WHERE product = @product";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Transaction = transaction;
                        // Добавляем параметр без пробелов
                        command.Parameters.AddWithValue("@product", selectedItemText);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show($"{selectedItemText} deleted");
                            
          
                        }
                        
                    
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("No rows affected. Item might not exist in the database.");
                        }
                    }
                }
            }
            
        }
            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Info());
        }

        private void Out(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
    }
}
