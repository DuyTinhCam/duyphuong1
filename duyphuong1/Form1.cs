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

namespace duyphuong1
{
    public partial class Form1 : Form
    {


        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-38UPOVL\SQLEXPRESS;Initial Catalog=SQL_QLBH;Integrated Security=True";
        SqlDataAdapter adapter1 = new SqlDataAdapter();
        SqlDataAdapter adapter2 = new SqlDataAdapter();
        SqlDataAdapter adapter3 = new SqlDataAdapter();
        SqlDataAdapter adapter4 = new SqlDataAdapter();
        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        DataTable table3 = new DataTable();
        DataTable table4 = new DataTable();

        void loaddata()
        {
            using (connection = new SqlConnection(str))
            {
                connection.Open();

                // Lấy dữ liệu cho table1 và hiển thị trong dataGridView2
                command = new SqlCommand("SELECT * FROM CHITIETDATHANG", connection);
                adapter1.SelectCommand = command;
                table1.Clear();
                adapter1.Fill(table1);
                dataGridView1.DataSource = table1;

                // Lấy dữ liệu cho table2 và hiển thị trong dataGridView1
                command = new SqlCommand("SELECT * FROM DONDATHANG", connection);
                adapter2.SelectCommand = command;
                table2.Clear();
                adapter2.Fill(table2);
                dataGridView2.DataSource = table2;

                //Lấy dữ liệu cho table3 và hiển thị trong dataGridView3
                command = new SqlCommand("SELECT * FROM KHACH_HANG", connection);
                adapter3.SelectCommand = command;
                table3.Clear();
                adapter3.Fill(table3);
                dataGridView3.DataSource = table3;

                //// Lấy dữ liệu cho table4 và hiển thị trong dataGridView4
                command = new SqlCommand("SELECT * FROM NHACUNGCAP", connection);
                adapter4.SelectCommand = command;
                table4.Clear();
                adapter4.Fill(table4);
                dataGridView4.DataSource = table4;

                connection.Close();
            }
        }





        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                connection = new SqlConnection(str);
                connection.Open();
                loaddata();
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO DONDATHANG (SoHD, MaKH, NgayDatHang, NgayGiaoHang, NgayChuyenHang, NoiGiaoHang, MaHinhThucTT) " +
                "VALUES (@SoHD, @MaKH, @NgayDatHang, @NgayGiaoHang, @NgayChuyenHang, @NoiGiaoHang, @MaHinhThucTT);";
                    command.Parameters.AddWithValue("@SoHD", a1.Text);
                    command.Parameters.AddWithValue("@MaKH", a5.Text);
                    command.Parameters.AddWithValue("@NgayDatHang", a2.Text);
                    command.Parameters.AddWithValue("@NgayGiaoHang", a3.Text);
                    command.Parameters.AddWithValue("@NgayChuyenHang", a4.Text);
                    command.Parameters.AddWithValue("@NoiGiaoHang", a6.Text);
                    command.Parameters.AddWithValue("@MaHinhThucTT", a7.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView2.CurrentCell.RowIndex;
            a1.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            a2.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
            a3.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
            a4.Text = dataGridView2.Rows[i].Cells[3].Value.ToString();
            a5.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
            a6.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
            a7.Text = dataGridView2.Rows[i].Cells[3].Value.ToString();

            loaddata();
        }

        private void them_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO CHITIETDATHANG (SoHD, MaH, GiaBan, SoLuong) " +
                "VALUES (@SoHD, @MaH, @GiaBan, @SoLuong" +
                ");";
                    command.Parameters.AddWithValue("@SoHD", txt1.Text);
                    command.Parameters.AddWithValue("@MaH", txt2.Text);
                    command.Parameters.AddWithValue("@GiaBan", txt3.Text);
                    command.Parameters.AddWithValue("@SoLuong", txt4.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM CHITIETDATHANG WHERE SoHD=@SoHD";
                    command.Parameters.AddWithValue("@SoHD", txt1.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi:" + "không thể xóa thông tin", "lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentCell.RowIndex;
            txt1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE CHITIETDATHANG SET" +
                            " MaH=@MaH, GiaBan=@GiaBan, SoLuong=@SoLuong WHERE SoHD=@SoHD";
                        command.Parameters.AddWithValue("@SoHD", txt1.Text);
                        command.Parameters.AddWithValue("@MaH", txt2.Text);
                        command.Parameters.AddWithValue("@GiaBan", txt3.Text);
                        command.Parameters.AddWithValue("@SoLuong", txt4.Text);

                        command.ExecuteNonQuery();
                    }
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể khởi tạo thông tin sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM DONDATHANG WHERE SoHD=@SoHD";
                    command.Parameters.AddWithValue("@SoHD", a1.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi:" + "không thể xóa thông tin sinh viên", "lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE DONDATHANG SET MaKH=@MaKH," +
                            "NgayDatHang=@NgayDatHang, NgayGiaoHang=@NgayGiaoHang, NgayChuyenHang=@NgayChuyenHang, NoiGiaoHang=@NoiGiaoHang, MaHinhThucTT=@MaHinhThucTT WHERE SoHD=@SoHD";
                        command.Parameters.AddWithValue("@SoHD", a1.Text);
                        command.Parameters.AddWithValue("@MaKH", a5.Text);
                        command.Parameters.AddWithValue("@NgayDatHang", a2.Text);
                        command.Parameters.AddWithValue("@NgayGiaoHang", a3.Text);
                        command.Parameters.AddWithValue("@NgayChuyenHang", a4.Text);
                        command.Parameters.AddWithValue("@NoiGiaoHang", a6.Text);
                        command.Parameters.AddWithValue("@MaHinhThucTT", a7.Text);
                        command.ExecuteNonQuery();
                    }
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể khởi tạo thông tin sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void a4_TextChanged(object sender, EventArgs e)
        {

        }

        private void a2_TextChanged(object sender, EventArgs e)
        {

        }

        private void a3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView3.CurrentCell.RowIndex;
            b1.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
            b2.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
            b3.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
            b4.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();
            b5.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();

            loaddata();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO KHACH_HANG (MaKH, TenKH, DiaChi, STK, DienThoai) " +
                "VALUES (@MaKH, @TenKH, @DiaChi, @STK, @DienThoai);";
                    command.Parameters.AddWithValue("@MaKH", b1.Text);
                    command.Parameters.AddWithValue("@TenKH", b2.Text);
                    command.Parameters.AddWithValue("@DiaChi", b3.Text);
                    command.Parameters.AddWithValue("@STK", b4.Text);
                    command.Parameters.AddWithValue("@DienThoai", b5.Text);

                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE KHACH_HANG SET TenKH=@TenKH," +
                            "DiaChi=@DiaChi, STK=@STK, DienThoai=@DienThoai WHERE MaKH=@MaKH";
                        command.Parameters.AddWithValue("@MaKH", b1.Text);
                        command.Parameters.AddWithValue("@TenKH", b2.Text);
                        command.Parameters.AddWithValue("@DiaChi", b3.Text);
                        command.Parameters.AddWithValue("@STK", b4.Text);
                        command.Parameters.AddWithValue("@DienThoai", b5.Text);

                        command.ExecuteNonQuery();
                    }
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể khởi tạo thông tin sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM KHACH_HANG WHERE MaKH=@MaKH";
                    command.Parameters.AddWithValue("@MaKH", b1.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi:" + "không thể xóa thông tin sinh viên", "lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView4.CurrentCell.RowIndex;
            b1.Text = dataGridView4.Rows[i].Cells[0].Value.ToString();
            b2.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
            b3.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
            b4.Text = dataGridView4.Rows[i].Cells[3].Value.ToString();
            b5.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();

            loaddata();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, Email, STK, DienThoai) " +
                "VALUES (@MaNCC, @TenNCC, @DiaChi, @Email, @STK, @DienThoai);";
                    command.Parameters.AddWithValue("@MaNCC", x1.Text);
                    command.Parameters.AddWithValue("@TenNCC", x2.Text);
                    command.Parameters.AddWithValue("@DiaChi", x3.Text);
                    command.Parameters.AddWithValue("@Email", x4.Text);
                    command.Parameters.AddWithValue("@STK", x5.Text);
                    command.Parameters.AddWithValue("@DienThoai", x6.Text);

                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE NHACUNGCAP SET TenNCC=@TenNCC," +
                            "DiaChi=@DiaChi, Email=@Email, STK=@STK, DienThoai=@DienThoai WHERE MaNCC=@MaNCC";
                        command.Parameters.AddWithValue("@MaNCC", x1.Text);
                        command.Parameters.AddWithValue("@TenNCC", x2.Text);
                        command.Parameters.AddWithValue("@DiaChi", x3.Text);
                        command.Parameters.AddWithValue("@Email", x4.Text);
                        command.Parameters.AddWithValue("@STK", x5.Text);
                        command.Parameters.AddWithValue("@DienThoai", x6.Text);

                        command.ExecuteNonQuery();
                    }
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Không thể khởi tạo thông tin sinh viên\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM NHACUNGCAP WHERE MaNCC=@MaNCC";
                    command.Parameters.AddWithValue("@MaNCC", x1.Text);
                    command.ExecuteNonQuery();
                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi:" + "không thể xóa thông tin sinh viên", "lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}