using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class AddFood : Form
    {
        private SQLiteConnection conn;
        private string currentUserID;

        public AddFood(string userID)
        {
            InitializeComponent();
            var sql = "Data Source=HomNayAnGi.db";
            conn = new SQLiteConnection(sql);
            conn.Open();


            currentUserID = userID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.Trim();
            byte[] imageBytes = ImageToByteArray(pictureBox1.Image);
            string userID = currentUserID;
            string newID = IDgen();
            
            InsertData_MonAn(conn, newID, name, imageBytes, userID);
            var mainForm = (FoodMenu)this.Owner; 
            mainForm.LoadFoodItem();

            this.Close();
        }


        public static void InsertData_MonAn(SQLiteConnection conn, string IDMA, string TenMonAn, byte[] HinhAnh, string IDNCC)
        {
            string sql = "INSERT INTO MonAn (IDMA, TenMonAn, HinhAnh, IDNCC) VALUES (@IDMA, @TenMonAn, @HinhAnh, @IDNCC)";

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@IDMA", IDMA);
                cmd.Parameters.AddWithValue("@TenMonAn", TenMonAn);
                cmd.Parameters.AddWithValue("@HinhAnh", HinhAnh);
                cmd.Parameters.AddWithValue("@IDNCC", IDNCC);

                cmd.ExecuteNonQuery();
            }
        }

        private byte[] ImageToByteArray(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // You can change the image format if needed.
                return ms.ToArray();
            }
        }

        private string IDgen()
        {
            string sql = "SELECT COUNT(*) FROM MonAn";
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return (count + 2).ToString("D4");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }

        }
    }
}
