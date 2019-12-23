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

namespace QLS
{
    public partial class dangnhap : Form
    {
        static string constr = ConfigurationManager.ConnectionStrings["QLS"].ConnectionString;
        public dangnhap()
        {
            InitializeComponent();
        }

        private void buttondangnhap_Click(object sender, EventArgs e)
        {
            //SqlConnection cnn = new SqlConnection(constr);
            //cnn.Open();
            //string select = "SELECT * FROM Username WHERE USERNAME = @user AND PASSWORD = @pass ";
            //SqlCommand cmd = new SqlCommand(select, cnn);
            //cmd.Parameters.AddWithValue("@user",textTendangnhap.Text);
            //cmd.Parameters.AddWithValue("@pass", textPasswork.Text);
            //cmd.ExecuteNonQuery();
            //SqlDataReader dta = cmd.ExecuteReader();
            //if (dta.Read()==true)
            //{
                quanlys f = new quanlys();
                this.Hide();
                f.ShowDialog();
                Show(); //}
            //else
            //{
            //    MessageBox.Show("Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng !");
            //    textPasswork.Text = "";
            //    textTendangnhap.Text = "";
            //    textTendangnhap.Focus();
            //}
        }

        private void buttonthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Có Thực Sự Muốn Thoát Chương Trình","Thông Báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
