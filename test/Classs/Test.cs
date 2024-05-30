using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.Classs
{
    public class Test
    {
        public static string login;
        public static string password;
        static string connectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;";
        public static bool IsUserValid(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // SQL запрос для проверки данных пользователя
                    string query = "SELECT * FROM Сотрудники WHERE Логин = @login AND Пароль = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", Test.login);
                    command.Parameters.AddWithValue("@password", Test.password);

                    // Выполнение запроса и получение результата
                    //int count = (int)command.ExecuteScalar();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                    return false;
                }
            }
        }
        public static bool Connection(string con) { //метод для проверки подклбчения БД
            try
            {
                SqlConnection connection = new SqlConnection(con);
                connection.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public static bool IsUserValid2_0(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // SQL запрос для проверки данных пользователя
                    string query = "SELECT * FROM Сотрудники WHERE Логин = @login AND Пароль = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", Test.login);
                    command.Parameters.AddWithValue("@password", Test.password);

                    // Выполнение запроса и получение результата
                    //int count = (int)command.ExecuteScalar();
                    //if (count > 0) return true;
                    //else return false;
                    SqlDataReader reader = command.ExecuteReader();
                    bool i = false;
                    if (reader.HasRows)
                    {
                        i = true;
                    }
                    return i;
                }
                catch (Exception ex)
                {
                    
                    return false;
                }
            }
        }
    }
}