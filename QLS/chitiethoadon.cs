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
    public partial class chitiethoadon : Form
    {
        
        static string constr = ConfigurationManager.ConnectionStrings["QLS"].ConnectionString;
        public chitiethoadon()
        {
            InitializeComponent();
        }
       
        public string mahd;
        public void hiendsct()
        {
            
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "select *from Chitiethoadon where MAHOADON = @mahd";
            SqlCommand cmd = new SqlCommand(select, cnn);
            cmd.Parameters.AddWithValue("@mahd",mahd);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridViewchitiethd.DataSource = dt;

        }

        private void chitiethoadon_Load(object sender, EventArgs e)
        {
            hiendsct();
        }
        public string chuyen;

        private void buttonthemchitiet_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "INSERT INTO dbo.Chitiethoadon VALUES (@mahd, @mas, @sl) ";
            SqlCommand cm = new SqlCommand(select, cnn);
            cm.Parameters.AddWithValue("@mahd", mahd);
            cm.Parameters.AddWithValue("@mas", textMasach.Text);
            cm.Parameters.AddWithValue("@sl", textSoluong.Text);
            cm.ExecuteNonQuery();
            hiendsct();
        }

        private void buttonsuachitiet_Click(object sender, EventArgs e)
        {
           /* SqlConnection cnn = new SqlConnection(constr);
            cnn.Open();
            string select = "UPDATE dbo.Chitiethoadon SET TONGTIEN = @tt WHERE MAHOADON = @mhd";
            SqlCommand cmd = new SqlCommand(select, cnn);
            cmd.Parameters.AddWithValue("@mhd", textBoxmahd.Text);
            cmd.Parameters.AddWithValue("@tt", texttongtien.Text);
            cmd.ExecuteNonQuery();
            hiendshd(); */
        }

        private void dataGridViewchitiethd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewchitiethd.CurrentCell.RowIndex;
            textMasach.Text = dataGridViewchitiethd.Rows[index].Cells[1].Value.ToString().Trim();
            textSoluong.Text = dataGridViewchitiethd.Rows[index].Cells[2].Value.ToString().Trim();
        }
    }
}
