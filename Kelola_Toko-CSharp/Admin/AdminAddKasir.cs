using DGVPrinterHelper;
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

namespace D_NAULANDARMAWAN_D.Admin
{
    public partial class AdminAddKasir : Form
    {
        string databaseKu = "Data Source=LAPTOP-3HFA1734\\SQLEXPRESS;Initial Catalog=D_NAULANDARMAWAN_D;Integrated Security=True";
        void tampilData()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tabel_pengguna where role=@role", con);
            cmd.Parameters.AddWithValue("@role", "kasir");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            txt_namaUser.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
        }

        void kodeOtomatis()
        {
            string urut;
            long hitung;
            SqlConnection con = new SqlConnection(databaseKu);
            SqlDataReader rd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select id from tabel_pengguna where id in (select max(id) from tabel_pengguna)order by id desc";
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["id"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "USR" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "USR001";
            }
            rd.Close();
            txt_id.Text = urut;
            con.Close();
        }
        public AdminAddKasir()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tabel_pengguna values (@id,@username,@password,@nama_user,@role)", con);
                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                cmd.Parameters.AddWithValue("@username", txt_username.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);
                cmd.Parameters.AddWithValue("@nama_user", txt_namaUser.Text);
                cmd.Parameters.AddWithValue("@role", "kasir");
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sukses Insert Data");
            }
            catch (Exception peringatan)
            {
                MessageBox.Show("Aduh: " + peringatan.Message);
            }
            tampilData();
            kodeOtomatis();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd = new SqlCommand("update tabel_pengguna set nama_user = @nama_user, username = @username, password = @password where id = @id", con);
                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                cmd.Parameters.AddWithValue("@nama_user", txt_namaUser.Text);
                cmd.Parameters.AddWithValue("@username", txt_username.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sukses Update Data");
            }
            catch (Exception peringatan)
            {
                MessageBox.Show("Aduh: " + peringatan.Message);
            }
            tampilData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete tabel_pengguna where id=@id", con);
                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sukses Delete Data");
            }
            catch (Exception peringatan)
            {
                MessageBox.Show("Aduh: " + peringatan.Message);
            }
            tampilData();
            kodeOtomatis();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            tampilData();
            kodeOtomatis();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Laporan Data Kasir Caffe Kendedes";
            printer.SubTitle = string.Format("{0}", DateTime.Now.Date.ToString("dddd-MMMM-yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.FooterSpacing = 15;
            printer.Footer = "Caffe Kendedes";
            printer.PrintPreviewDataGridView(dataGridView1);
        }

        private void AdminAddKasir_Load(object sender, EventArgs e)
        {
            tampilData();
            kodeOtomatis();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                txt_namaUser.Text = dataGridView1.Rows[e.RowIndex].Cells["nama_user"].FormattedValue.ToString();
                txt_username.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
                txt_password.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();
            }
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            txt_id.ReadOnly = true;
        }
    }
}
