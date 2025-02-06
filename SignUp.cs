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

namespace SuperMarketManagementSystem
{
    public partial class SignUp : Form
    {
        // Connection string from App.config
        string connectionString = "Data Source=DESKTOP-3RL8GT8\\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True;Encrypt=False";
        string UserName, password, email;

        public SignUp()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            UserName = textBox1.Text.Trim();
            password = textBox2.Text.Trim();
            email = textBox3.Text.Trim();

            string query = "INSERT INTO Table_Users (UserName, Password, Email) VALUES (@value1, @value2, @value3)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@value1", UserName);
                command.Parameters.AddWithValue("@value2", password);
                command.Parameters.AddWithValue("@value3", email);
                command.ExecuteNonQuery();

                connection.Close();
            }
            MessageBox.Show("Successfull.");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
