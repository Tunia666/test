using test;
using System.Data.SqlClient;
namespace NUnitDemo
{
    public class NUnitDemo
    {
        
        [Test]
        public void Test_true()//���� �� ���������� ����� � ������
        {
            // Arrange
            var form = new Form1(); // 

            form.TextBox1Text = "test"; // 
            form.TextBox2Text = "1234"; // 

            // Act
            form.button1_Click(null, EventArgs.Empty);

            // Assert
            bool i = Form1.IsUserValid(form.TextBox1Text, form.TextBox2Text);
            Assert.IsTrue(i);
        }

        [Test]
        public void Test_false()//���� �� ������������ ����� � ������
        {
            // Arrange
            var form = new Form1(); // 
            form.TextBox1Text = "validUser";
            form.TextBox2Text = "invalidPassword"; // 

            // Act
            form.button1_Click(null, EventArgs.Empty);

            // Assert
            bool i = Form1.IsUserValid(form.TextBox1Text, form.TextBox2Text);
            Assert.IsFalse(i);
        }
    }
}