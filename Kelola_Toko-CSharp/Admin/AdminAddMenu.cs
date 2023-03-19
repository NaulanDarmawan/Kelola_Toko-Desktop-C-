using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_NAULANDARMAWAN_D.Admin
{
    public partial class AdminAddMenu : Form
    {
        string databaseKu = "Data Source=LAPTOP-3HFA1734\\SQLEXPRESS;Initial Catalog=D_NAULANDARMAWAN_D;Integrated Security=True";
        byte[] imageBytes;

        void tampilData()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = new SqlCommand("select id, nama_menu, harga, tipe_menu from tabel_menu", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            txt_nama.Text = "";
            txt_harga.Text = "0";
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
            cmd.CommandText = "select id from tabel_menu where id in (select max(id) from tabel_menu)order by id desc";
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["id"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "MKN" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "MKN001";
            }
            rd.Close();
            txt_id.Text = urut;
            con.Close();
        }
        public AdminAddMenu()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tabel_menu values (@id,@nama_menu,@harga,@tipe_menu,@foto)", con);
                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                cmd.Parameters.AddWithValue("@nama_menu", txt_nama.Text);
                cmd.Parameters.AddWithValue("@harga", float.Parse(txt_harga.Text));
                cmd.Parameters.AddWithValue("@tipe_menu", cmb_tipe.Text);
                cmd.Parameters.AddWithValue("@foto", imageBytes);
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
                SqlCommand cmd = new SqlCommand("update tabel_menu set nama_menu = @nama_menu, harga = @harga, foto = @foto where id = @id", con);
                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                cmd.Parameters.AddWithValue("@nama_menu", txt_nama.Text);
                cmd.Parameters.AddWithValue("@harga", float.Parse(txt_harga.Text));
                cmd.Parameters.AddWithValue("@foto", imageBytes);
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
                SqlCommand cmd = new SqlCommand("delete tabel_menu where id=@id", con);
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
            printer.Title = "Laporan Data Menu Caffe Kendedes";
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

        private void btn_foto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imageBytes = ms.ToArray();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                txt_nama.Text = dataGridView1.Rows[e.RowIndex].Cells["nama_menu"].FormattedValue.ToString();
                txt_harga.Text = dataGridView1.Rows[e.RowIndex].Cells["harga"].FormattedValue.ToString();
            }
        }

        private void AdminAddMenu_Load(object sender, EventArgs e)
        {
            tampilData();
            kodeOtomatis();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            txt_id.ReadOnly = true;
        }
    }
}
