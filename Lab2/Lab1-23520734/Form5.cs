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
    public partial class FoodMenu : Form
    {
        private SQLiteConnection conn;
        private string currentUserID;
        private int currentPage = 1;
        private int itemsPerPage = 5;

        private List<FoodItem> allFoodItems;
        private List<FoodItem> userFoodItems;

        public FoodMenu(string userID)
        {
            InitializeComponent();
            var sql = "Data Source=HomNayAnGi.db";
            conn = new SQLiteConnection(sql);
            conn.Open();

       
            currentUserID = userID;
            LoadFoodItem();
            PopulateTabData();
        }

        private static byte[] LoadImage(string FilePath)
        {
            return File.ReadAllBytes(FilePath);
        }

        public void LoadFoodItem()
        {
            allFoodItems = GetFoodItem_all();
            userFoodItems = GetFoodItem(currentUserID);
            PopulateTabData();
        }

        private List<FoodItem> GetFoodItem_all()
        {
            string sql = "SELECT * FROM MonAn";

            using (var cmd = new SQLiteCommand(sql, conn))
            {

                var items = new List<FoodItem>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new FoodItem
                        {
                            IDMonAn = reader["IDMA"].ToString(),
                            tenMonAn = reader["TenMonAn"].ToString(),
                            hinhAnh = (byte[])reader["HinhAnh"]
                        });
                    }
                }
                return items;
            }

        }

        private List<FoodItem> GetFoodItem(string userID)
        {
            string sql;

            if (userID == null)
            {
                sql = "SELECT * FROM MonAn";
            }
            else
            {
                sql = "SELECT * FROM MonAn WHERE IDNCC = @IDNCC";
            }

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                if (userID != null)
                {
                    cmd.Parameters.AddWithValue("@IDNCC", userID);
                }

                var items = new List<FoodItem>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new FoodItem
                        {
                            IDMonAn = reader["IDMA"].ToString(),
                            tenMonAn = reader["TenMonAn"].ToString(),
                            hinhAnh = (byte[])reader["HinhAnh"]
                        });
                    }
                }
                return items;
            }

        }

        private void PopulateTabData()
        {
            DisplayFoodItems(allFoodItems, currentPage, itemsPerPage, allFood);
            DisplayFoodItems(userFoodItems, currentPage, itemsPerPage, userFood);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == userFood)
            {
                DisplayFoodItems(userFoodItems, currentPage, itemsPerPage, userFood);
            }
            else if (tabControl1.SelectedTab == allFood)
            {
                DisplayFoodItems(allFoodItems, currentPage, itemsPerPage, allFood);
            }
        }


        private void DisplayFoodItems(List<FoodItem> items, int page, int perPage, Panel panel)
        {
            panel.Controls.Clear();

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            int start = (page - 1) * perPage;
            var pageItems = items.Skip(start).Take(perPage).ToList();

            foreach (var item in pageItems)
            {
                var itemPanel = new Panel
                {
                    Width = 400,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10)
                };

                var pictureBox = new PictureBox
                {
                    Image = ByteArrayToImage(item.hinhAnh),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 80,
                    Height = 80,
                    Dock = DockStyle.Left,
                    Margin = new Padding(10)
                };

                var nameLabel = new Label
                {
                    Text = item.tenMonAn,
                    AutoSize = true,
                    Dock = DockStyle.Right,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10)
                };

                itemPanel.Controls.Add(pictureBox);
                itemPanel.Controls.Add(nameLabel);

                flowPanel.Controls.Add(itemPanel);
            }

            panel.Controls.Add(flowPanel);
        }


        private Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<FoodItem> activeList = tabControl1.SelectedTab == userFood ? userFoodItems : allFoodItems;

            if (activeList.Count == 0)
            {
                MessageBox.Show("No food items.");
                return;
            }

            Random rnd = new Random();
            int randomIndex = rnd.Next(activeList.Count);

            FoodItem randomFood = activeList[randomIndex];

            MessageBox.Show(randomFood.tenMonAn);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddFood addFood = new AddFood(currentUserID);
            addFood.Owner = this;
            addFood.Show();
        }

        private void PrevPageBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                PopulateTabData();
            }
        }

        private void NextPageBtn_Click(object sender, EventArgs e)
        {
            currentPage++;
            PopulateTabData();
        }

        private void userFood_Click(object sender, EventArgs e)
        {

        }

        private void allFood_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class FoodItem
    {
        public string IDMonAn { get; set; }
        public string tenMonAn { get; set; }
        public byte[] hinhAnh { get; set; }
    }

}
