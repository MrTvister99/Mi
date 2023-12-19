using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public bool found = false;
        public string login;
        public string password;
        string server = "10.112.48.11";
        string database = "lesuser9";
        string username = "lesuser9";
        string passwordDB = "lesuser9";
        public Page1()
        {
            InitializeComponent();
        }

        private void Enter_Click1(object sender, RoutedEventArgs e)
        {
            podkl();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            podkl1();


        }
        private void podkl()
        {
           

            using (SqlConnection connection = new SqlConnection($"Server={server};Database={database};User ID={username};Password={passwordDB}"))
            {
                login = email.Text;
                password = Password.Text;
                connection.Open();



                string sql = $"INSERT INTO Users (email,password)  VALUES (@email, @password)";
                if (Password.Text != "" && email.Text != "")
                {
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", $"{login}");
                        command.Parameters.AddWithValue("@password", $"{password}");
                        //command.Parameters.AddWithValue("@working_day_length", $"{startDay}-{endDay}");

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    //frame.Navigate(new Menu());
                }
                else
                {
                    MessageBox.Show($"Поля не могут быть пустыми");
                   
                }
            }

        }
        private void podkl1()
        {
            
            using (SqlConnection connection = new SqlConnection($"Server={server};Database={database};User ID={username};Password={passwordDB}"))
            {
                connection.Open();

                string sql = "SELECT * FROM Users";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        bool found = false;
                        while (reader.Read())
                        {
                           string email1 = reader["email"].ToString();
                           string password1 = reader["password"].ToString();
                            password1 = password1.Trim();
                            email1 = email1.Trim();

                            if (password1 == Password.Text && email.Text == email1)
                            {
                                found = true;
                            }
                        }

                        if (Password.Text != "" && email.Text != "")
                        {
                            if (found)
                            {
                                frame.Navigate(new Menu());
                            }
                            else
                            {
                                MessageBox.Show($"Неправильный логин или пароль");
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Поля не могут быть пустыми");
                        }
                    }
                }
            }
        }
    }
        }
    

