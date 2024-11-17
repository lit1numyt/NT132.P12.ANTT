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
    public partial class CreateAccountPage : Form
    {

        private SQLiteConnection conn;
        public CreateAccountPage()
        {
            InitializeComponent();
            conn = new SQLiteConnection("Data Source=Lab4.db");
            conn.Open();
        }

        private void CreateAccountPage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userID = enteredID.Text.Trim();
            string userName = enteredName.Text.Trim();

            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckUserIDExists(userID))
            {
                MessageBox.Show("This userID is already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CreateNewUser(userID, userName);
                this.Close();
            }
            conn.Close();
        }

        private bool CheckUserIDExists(string userID)
        {
            string sql = "SELECT COUNT(1) FROM NguoiCungCap WHERE IDNCC = @UserID";

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                int count = Convert.ToInt32(cmd.ExecuteScalar()); ;

                return count > 0;
            }
        }

        private void CreateNewUser(string userID, string userName)
        {
            string sql = "INSERT INTO NguoiCungCap (IDNCC, HoVaTen, QuyenHan) VALUES (@UserID, @HoVaTen, @QuyenHan)";

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@HoVaTen", userName);
                cmd.Parameters.AddWithValue("@QuyenHan", 1);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
