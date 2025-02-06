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
    public partial class Login : Form
    {
        // Connection string from App.config
        string connectionString = "Data Source=DESKTOP-3RL8GT8\\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True;Encrypt=False";
        string userName, password;

        public Login()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            // Get the username and password from the text boxes.
            userName = userNameText.Text.Trim();
            password = passwordText.Text.Trim();

            // SQL query to check credentials
            string query = "SELECT COUNT(*) FROM Table_Users WHERE UserName = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Username", userName);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        this.Hide(); // Hide the login form.
                        //MainForm mainForm = new MainForm(); // Assuming you have a MainForm class.
                        //mainForm.Show(); // Show the main form.
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void signUpButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}
