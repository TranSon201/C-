using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace QLS
{
    public partial class Admin : Form
    {
        static string constr = ConfigurationManager.ConnectionStrings["QLS"].ConnectionString;
        public Admin()
        {
            InitializeComponent();
        }
        private const string ConnectionString = "Data Source=DESKTOP-PF3DC38\\SQLEXPRESS;Initial Catalog=PMnhasach;Integrated Security=True";

        SqlConnection cnn;

        private void Admin_Load(object sender, EventArgs e)
        {
            hiendsnv();
            hiendshd();
            HienthiTG();
            hienlinhvuc();
            hienkho();
            
        }
        public void hiendsnv()
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "select *from danhsachsach";
            SqlCommand cmd = new SqlCommand(select, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            datasach.DataSource = dt;

        }
        public void hiendshd()
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "select *from Hoadon";
            SqlCommand cmd = new SqlCommand(select, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            datahoadon.DataSource = dt;

        }

        private void btnthems_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "SELECT * FROM Sach WHERE MASACH = @MS ";
            SqlCommand cm = new SqlCommand(select, cnn);
            cm.Parameters.AddWithValue("@MS", textmasach.Text);
            cm.ExecuteNonQuery();
            SqlDataReader dta = cm.ExecuteReader();
            if (dta.Read() == false)
            {
                cnn.Close();
                cnn.Open();
                string insert = "EXEC dbo.inser @masach = @masach, @tensach = @tensach,@tacgia = @tacgia, @linhvuc = @linhvuc, @lantaiban = @lantaiban, @namxb = @namxb,@nhaxuatban = @nhaxuatban,@gia = @gia";
                SqlCommand cmd = new SqlCommand(insert, cnn);
                cmd.Parameters.AddWithValue("@masach", textmasach.Text);
                cmd.Parameters.AddWithValue("@tensach", texttensach.Text);
                cmd.Parameters.AddWithValue("@tacgia", texttacgias.Text);
                cmd.Parameters.AddWithValue("@linhvuc", textLinhvuc.Text);
                cmd.Parameters.AddWithValue("@lantaiban", textLantaiban.Text);
                cmd.Parameters.AddWithValue("@namxb", textNamxb.Text);
                cmd.Parameters.AddWithValue("@nhaxuatban", textNhaxb.Text); cmd.Parameters.AddWithValue("@gia", textGiaban.Text);
                cmd.ExecuteNonQuery();
                hiendsnv();
            }
            else
            {
                MessageBox.Show("Mã Sách Đã Tồn Tại Mời Nhập Lại!");
                textmasach.Focus();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string xoa = "DELETE FROM  Sach  WHERE @maS = MASACH";
            SqlCommand cmd = new SqlCommand(xoa, cnn);
            cmd.Parameters.AddWithValue("maS", textmasach.Text);
            cmd.ExecuteNonQuery();
            hiendsnv();
        }

        private void datasach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = datasach.CurrentCell.RowIndex;
            textmasach.Text = datasach.Rows[index].Cells[0].Value.ToString().Trim();
            texttensach.Text = datasach.Rows[index].Cells[1].Value.ToString().Trim();
            texttacgias.Text = datasach.Rows[index].Cells[2].Value.ToString().Trim();
            textLinhvuc.Text = datasach.Rows[index].Cells[3].Value.ToString().Trim();
            textLantaiban.Text = datasach.Rows[index].Cells[4].Value.ToString().Trim();
            textNamxb.Text = datasach.Rows[index].Cells[5].Value.ToString().Trim();
            textNhaxb.Text = datasach.Rows[index].Cells[6].Value.ToString().Trim();
            textGiaban.Text = datasach.Rows[index].Cells[7].Value.ToString().Trim();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "SELECT * FROM Sach WHERE MASACH = @MS ";
            SqlCommand cm = new SqlCommand(select, cnn);
            cm.Parameters.AddWithValue("@MS", textmasach.Text);
            cm.ExecuteNonQuery();
            SqlDataReader dta = cm.ExecuteReader();
            if (dta.Read() == true)
            {
                cnn.Close();
                cnn.Open();
                string insert = "EXEC dbo.updat @masach = @masach, @tensach = @tensach,@tacgia = @tacgia, @linhvuc = @linhvuc, @lantaiban = @lantaiban, @namxb = @namxb,@nhaxuatban = @nhaxuatban,@gia = @gia";
                SqlCommand cmd = new SqlCommand(insert, cnn);
                cmd.Parameters.AddWithValue("@masach",textmasach.Text);              
                cmd.Parameters.AddWithValue("@tensach", texttensach.Text);
                cmd.Parameters.AddWithValue("@tacgia", texttacgias.Text);
                cmd.Parameters.AddWithValue("@linhvuc", textLinhvuc.Text);
                cmd.Parameters.AddWithValue("@lantaiban", textLantaiban.Text);
                cmd.Parameters.AddWithValue("@namxb", textNamxb.Text);
                cmd.Parameters.AddWithValue("@nhaxuatban", textNhaxb.Text); cmd.Parameters.AddWithValue("@gia", textGiaban.Text);
                cmd.ExecuteNonQuery();
                hiendsnv();
            }
            else
            {
                MessageBox.Show("Mã Sách Không Tồn Tại Mời Nhập Lại!");
                textmasach.Focus();
            }
        }

        private void buttontimkiemsach_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "SELECT * FROM danhsachsach WHERE TENSACH = @tensach ";
            SqlCommand cmd = new SqlCommand(select, cnn);
            cmd.Parameters.AddWithValue("@tensach", texttimkiemsach.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            datasach.DataSource = dt;

        }
     

        private void btnxem_Click(object sender, EventArgs e)
        {
            hiendsnv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime idate;
            idate = dateTimePicker3.Value;
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "SELECT * FROM Hoadon WHERE MAHOADON = @mhd ";
            SqlCommand cm = new SqlCommand(select, cnn);
            cm.Parameters.AddWithValue("@mhd", textBoxmahd.Text);
            cm.ExecuteNonQuery();
            SqlDataReader dta = cm.ExecuteReader();
            if (dta.Read() == false)
            {
                cnn.Close();
                cnn.Open();
                string insert = "INSERT INTO dbo.Hoadon VALUES (@mhd,@tenkh,@nl,0)";
                SqlCommand cmd = new SqlCommand(insert, cnn);
                cmd.Parameters.AddWithValue("@mhd", textBoxmahd.Text);
                cmd.Parameters.AddWithValue("@tenkh", textBoxtenkhach.Text);
                cmd.Parameters.AddWithValue("@nl", idate.ToShortDateString());
                cmd.ExecuteNonQuery();
                chitiethoadon f = new chitiethoadon();
                f.mahd = textBoxmahd.Text;
                f.Show();
            }
            else
            {
                MessageBox.Show("Chức Năng Chỉ Dành Cho Thêm Mới. Mời Bấm 'Chi Tiết' Để Xem Chi Tiết Hóa Đơn ");
                textmasach.Focus();
            }

           
        }

        private void datahoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = datahoadon.CurrentCell.RowIndex;
            textBoxmahd.Text = datahoadon.Rows[index].Cells[0].Value.ToString().Trim();
            textBoxtenkhach.Text = datahoadon.Rows[index].Cells[1].Value.ToString().Trim();
            dateTimePicker3.Text = datahoadon.Rows[index].Cells[2].Value.ToString().Trim();
            texttongtien.Text = datahoadon.Rows[index].Cells[3].Value.ToString().Trim();
            
        }

        private void btnxemhd_Click(object sender, EventArgs e)
        {
            DateTime iDate1,iDate2;
            iDate1 = dateTimePicker1.Value;
            iDate2 = dateTimePicker2.Value;
        
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string thongke = "EXEC dbo.thongke @time1 = @time1,@time2 = @time2";
            SqlCommand cmd = new SqlCommand(thongke, cnn);
            cmd.Parameters.AddWithValue("time1", iDate1.ToShortDateString());
            cmd.Parameters.AddWithValue("time2", iDate2.ToShortDateString());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            datahoadon.DataSource = dt;
        }

        private void buttonchitiethd_Click(object sender, EventArgs e)
        {
            chitiethoadon f = new chitiethoadon();
            f.mahd = textBoxmahd.Text;
            f.Show();
        }

        private void buttonxoahd_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string xoa = "EXEC xoa @mahd = @mahd";
            SqlCommand cmd = new SqlCommand(xoa, cnn);
            cmd.Parameters.AddWithValue("mahd", textBoxmahd.Text);
            cmd.ExecuteNonQuery();
            hiendshd();
        }

        private void buttontongtien_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "SELECT dbo.tinhtien(@mahd)";
            SqlCommand cmd = new SqlCommand(select, cnn);
            cmd.Parameters.AddWithValue("@mahd", textBoxmahd.Text);
            int n = (int)cmd.ExecuteScalar();
            texttongtien.Text = n.ToString();
        }

        private void buttonthemhd_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "UPDATE dbo.Hoadon SET TONGTIEN = @tt WHERE MAHOADON = @mhd";
            SqlCommand cmd = new SqlCommand(select, cnn);
            cmd.Parameters.AddWithValue("@mhd", textBoxmahd.Text);
            cmd.Parameters.AddWithValue("@tt", texttongtien.Text);
            cmd.ExecuteNonQuery();
            hiendshd();
        }

        private void buttontimkiemhd_Click(object sender, EventArgs e)
        {

        }

        private void buttonsuahd_Click(object sender, EventArgs e)
        {

        }

        public void HienthiTG()
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "select *from Tacgia";
            SqlCommand cmd = new SqlCommand(select, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataTG.DataSource = dt;
        }
       
        

        private void dataTG_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataTG.CurrentCell.RowIndex;
            txtMatg.Text = dataTG.Rows[index].Cells[0].Value.ToString().Trim();
            txtTentg.Text = dataTG.Rows[index].Cells[1].Value.ToString().Trim();
            txtNamsinh.Text = dataTG.Rows[index].Cells[2].Value.ToString().Trim();
            txtNammat.Text = dataTG.Rows[index].Cells[3].Value.ToString().Trim();
            txtQuequan.Text = dataTG.Rows[index].Cells[4].Value.ToString().Trim();
        }

        private void btnThemTG_Click_1(object sender, EventArgs e)
        {
            if (txtMatg.Text == "" || txtMatg.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập đủ thông tin !");
            }
            else
            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string them = "INSERT INTO tacgia  VALUES (@matg , @tentg, @namsinh, @nammat,@quequan)";
                SqlCommand cmd = new SqlCommand(them, cnn);
                cmd.Parameters.AddWithValue("matg", txtMatg.Text);
                cmd.Parameters.AddWithValue("tentg", txtTentg.Text);
                cmd.Parameters.AddWithValue("namsinh", txtNamsinh.Text);
                cmd.Parameters.AddWithValue("nammat", txtNammat.Text);
                cmd.Parameters.AddWithValue("quequan", txtQuequan.Text);

                cmd.ExecuteNonQuery();
                HienthiTG();

            }
        }

        private void btnXoaTG_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string xoa = "DELETE FROM  tacgia  WHERE @maTG = MATACGIA";
            SqlCommand cmd = new SqlCommand(xoa, cnn);
            cmd.Parameters.AddWithValue("maTG", txtMatg.Text);
            cmd.ExecuteNonQuery();
            HienthiTG();

        }

        private void btnSuaTG_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "SELECT * FROM Tacgia WHERE MATACGIA = @MTG ";
            SqlCommand cm = new SqlCommand(select, cnn);
            cm.Parameters.AddWithValue("@MTG", txtMatg.Text);
            cm.ExecuteNonQuery();
            SqlDataReader dta = cm.ExecuteReader();
            if (dta.Read() == true)
            {
                cnn.Close();
                cnn.Open();
                string insert = "update  tacgia set TENTACGIA = @tentg, NAMSINH = @ns, NAMMAT = @nm, QUEQUAN = @qq WHERE MATACGIA=@matacgia";
                SqlCommand cmd = new SqlCommand(insert, cnn);
                cmd.Parameters.AddWithValue("@matacgia", txtMatg.Text);
                cmd.Parameters.AddWithValue("@tentg", txtTentg.Text);
                cmd.Parameters.AddWithValue("@ns", txtNamsinh.Text);
                cmd.Parameters.AddWithValue("@nm", txtNammat.Text);
                cmd.Parameters.AddWithValue("@qq", txtQuequan.Text);


                cmd.ExecuteNonQuery();
                HienthiTG();
            }
            else
            {
                MessageBox.Show("Mã Tác Giả Không Tồn Tại Mời Nhập Lại!");
                txtMatg.Focus();
            }
        }
        public void hienlinhvuc()
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "select *from Linhvuc";
            SqlCommand cmd = new SqlCommand(select, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            datalinhvuc.DataSource = dt;
        }

        private void btnThemlv_Click(object sender, EventArgs e)
        {
            if (txtMalv.Text == "" || txtMalv.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập đủ thông tin !");
            }
            else
            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string them = "INSERT INTO linhvuc  VALUES (@malv,@tenlv)";
                SqlCommand cmd = new SqlCommand(them, cnn);
                cmd.Parameters.AddWithValue("malv", txtMalv.Text);
                cmd.Parameters.AddWithValue("tenlv", txtTenlv.Text);
              

                cmd.ExecuteNonQuery();
                hienlinhvuc();

            }
        }

        private void datalinhvuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = datalinhvuc.CurrentCell.RowIndex;
            txtMalv.Text = datalinhvuc.Rows[index].Cells[0].Value.ToString().Trim();
            txtTenlv.Text = datalinhvuc.Rows[index].Cells[1].Value.ToString().Trim();
        }
        private void btnXoalv_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string xoa = "DELETE FROM  linhvuc  WHERE @malv = MALINHVUC";
            SqlCommand cmd = new SqlCommand(xoa, cnn);
            cmd.Parameters.AddWithValue("malv", txtMalv.Text);
            cmd.ExecuteNonQuery();
            hienlinhvuc();
        }
        private void btnSualv_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "SELECT * FROM linhvuc WHERE MALINHVUC = @malv ";
            SqlCommand cm = new SqlCommand(select, cnn);
            cm.Parameters.AddWithValue("@malv", txtMalv.Text);
            cm.ExecuteNonQuery();
            SqlDataReader dta = cm.ExecuteReader();
            if (dta.Read() == true)
            {
                cnn.Close();
                cnn.Open();
                string insert = "update dbo.Linhvuc set TENLINHVUC = @linhvuc where MALINHVUC = @malv ";
                SqlCommand cmd = new SqlCommand(insert, cnn);
                cmd.Parameters.AddWithValue("@malv", txtMalv.Text);
                cmd.Parameters.AddWithValue("@linhvuc", txtTenlv.Text);
                cmd.ExecuteNonQuery();
                hienlinhvuc();
            }
            else
            {
                MessageBox.Show("Mã Lĩnh Vực Không Tồn Tại Mời Nhập Lại!");
                txtMalv.Focus();
            }
        }

        public void hienkho()
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "select *from Kho";
            SqlCommand cmd = new SqlCommand(select, cnn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            datakho.DataSource = dt;
        }

        private void datakho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int index = datakho.CurrentCell.RowIndex;
            txtMasach.Text = datakho.Rows[index].Cells[0].Value.ToString().Trim();
            txtSoluong.Text = datakho.Rows[index].Cells[1].Value.ToString().Trim();
        }

        private void btnXoakho_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string xoa = "DELETE FROM  kho  WHERE @mas = MASACH";
            SqlCommand cmd = new SqlCommand(xoa, cnn);
            cmd.Parameters.AddWithValue("mas", txtMasach.Text);
            cmd.ExecuteNonQuery();
            hienkho();
        }

        private void btnThemkho_Click(object sender, EventArgs e)
        {

            if (txtMasach.Text == "" || txtMasach.Text == "")
            {
                MessageBox.Show(" Bạn chưa nhập đủ thông tin !");
            }
            else
            {
                SqlConnection cnn = new SqlConnection(constr);
                cnn.Open();
                string them = "INSERT INTO kho  VALUES (@mas,@soluong)";
                SqlCommand cmd = new SqlCommand(them, cnn);
                cmd.Parameters.AddWithValue("mas", txtMasach.Text);
                cmd.Parameters.AddWithValue("soluong", txtSoluong.Text);


                cmd.ExecuteNonQuery();
                hienkho();

            }
        }

       
    }

}
