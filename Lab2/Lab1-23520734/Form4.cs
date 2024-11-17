using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_23520734
{
    public partial class LoginPage : Form
    {
        private SQLiteConnection conn;
        public LoginPage()
        {
            InitializeComponent();
            conn = new SQLiteConnection("Data Source=HomNayAnGi.db");
            conn.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string userID = InputAccountID.Text.Trim();

            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Please enter a User ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CheckUserIDExists(userID))
            {
                FoodMenu mainProgram = new FoodMenu(userID);
                mainProgram.Show();
                this.Hide();
                conn.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("UserID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            CreateAccountPage createAccount = new CreateAccountPage();
            createAccount.Show();
            conn.Close();
        }

        private bool CheckUserIDExists(string userID)
        {
            string sql = "SELECT COUNT(1) FROM NguoiCungCap WHERE IDNCC = @UserID";

            using (var cmd = new  SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                int count = Convert.ToInt32(cmd.ExecuteScalar()); ;

                return count > 0;
            }
        }
    }
}
