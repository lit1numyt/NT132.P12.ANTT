using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Drawing.Text;
using System.IO;

namespace Lab1_23520734
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            // poping console for debugging
            //AllocConsole();

            var sql = "Data Source=HomNayAnGi.db";
            SQLiteConnection.CreateFile(sql);

            SQLiteConnection conn = new SQLiteConnection(sql);
            try
            {
                conn.Open();
                CreateTable(conn);

                //init data
                /*
                InsertData_NguoiCungCap(conn, "0001", "Nguyen Khoa", 1);
                InsertData_NguoiCungCap(conn, "0002", "Tran Tran", 1);
                InsertData_NguoiCungCap(conn, "0003", "Nguoi Phan Xet", 1);
                InsertData_NguoiCungCap(conn, "0004", "Nguoi Phan Xu", 1);
                InsertData_NguoiCungCap(conn, "0005", "Nguoi Phan Doan", 1);

                InsertData_MonAn(conn, "0001", "Pho", LoadImage("pho.jpg"), "0001");
                InsertData_MonAn(conn, "0002", "Bun Bo Hue", LoadImage("bunbohue.jpg"), "0002");
                InsertData_MonAn(conn, "0003", "Bun dau mam tom", LoadImage("bundaumamtom.jpg"), "0001");
                InsertData_MonAn(conn, "0004", "Ga ran", LoadImage("friedchicken.jpg"), "0003");
                InsertData_MonAn(conn, "0005", "Spaghetti", LoadImage("spaghetti.jpg"), "0004");
                InsertData_MonAn(conn, "0006", "Pasta", LoadImage("pasta.jpg"), "0005");
                InsertData_MonAn(conn, "0007", "Pizza", LoadImage("pizza.jpg"), "0001");
                InsertData_MonAn(conn, "0008", "Com chien", LoadImage("Com chien duong chau.jpg"), "0001");
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }


            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPage());

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

        public static void InsertData_NguoiCungCap(SQLiteConnection conn, string IDNCC, string HoVaTen, int QuyenHan)
        {
            string sql = "INSERT INTO NguoiCungCap (IDNCC, HoVaTen, QuyenHan) VALUES (@IDNCC, @HoVaTen, @QuyenHan)";

            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@IDNCC", IDNCC);
                cmd.Parameters.AddWithValue("@HoVaTen", HoVaTen);
                cmd.Parameters.AddWithValue("@QuyenHan", QuyenHan);

                cmd.ExecuteNonQuery();
            }
        }
        public static void CreateTable(SQLiteConnection conn)
        {
            string sql = "CREATE TABLE IF NOT EXISTS MonAn(" +
                         "IDMA VARCHAR(10) UNIQUE PRIMARY KEY," +
                         "TenMonAn VARCHAR(50) NOT NULL," +
                         "HinhAnh BLOB," +
                         "IDNCC VARCHAR(20)," +
                         "FOREIGN KEY(IDNCC) REFERENCES NguoiCungCap(IDNCC)" + 
                         "); " +  

                         "CREATE TABLE IF NOT EXISTS NguoiCungCap(" +
                         "IDNCC VARCHAR(10) UNIQUE PRIMARY KEY," +
                         "HoVaTen VARCHAR(50) NOT NULL," +
                         "QuyenHan INT NOT NULL DEFAULT 1" +
                         ");"; 


            var cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public static byte[] LoadImage(string FilePath)
        {
            return File.ReadAllBytes(FilePath);
        }
    }
}