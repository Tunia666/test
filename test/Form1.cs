using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Classs;
namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public string TextBox1Text { get { return textBox1.Text; } set { textBox1.Text = value; }  }
        public string TextBox2Text { get { return textBox2.Text; } set { textBox2.Text = value; } }
        static string connectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;";
        public void button1_Click(object sender, EventArgs e)
        {
            Test.login = textBox1.Text;
            Test.password = textBox2.Text;
            //MessageBox.Show(Test.login);
            if (IsUserValid(Test.login, Test.password)) {
                MessageBox.Show("Авторизация успешна!");
            }
            else { MessageBox.Show("Ошибка!"); }
        }
        public static bool IsUserValid(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // SQL запрос для проверки данных пользователя
                    string query = "SELECT Count(*) FROM Сотрудники WHERE Логин = @login AND Пароль = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", Test.login);
                    command.Parameters.AddWithValue("@password", Test.password);

                    // Выполнение запроса и получение результата
                    int count = (int)command.ExecuteScalar();
                    return count >0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                    return false;
                }
            }
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
