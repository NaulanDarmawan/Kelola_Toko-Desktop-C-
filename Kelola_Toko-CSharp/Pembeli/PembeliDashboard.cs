using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_NAULANDARMAWAN_D.Pembeli
{
    public partial class PembeliDashboard : Form
    {
        string databaseKu = "Data Source=LAPTOP-3HFA1734\\SQLEXPRESS;Initial Catalog=D_NAULANDARMAWAN_D;Integrated Security=True";

        void tampilData()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tabel_cart_pesanan", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            txt_idMenu.Text = "";
            txt_hargaSatuan.Text = "0";
            txt_jumlahBeli.Text = "0";
            txt_totalHarga.Text = "0";
            txt_jumlahMakanan.Text = "0";
            txt_totalBayar.Text = "0";
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
            cmd.CommandText = "select id from tabel_transaksi where id in (select max(id) from tabel_transaksi)order by id desc";
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["id"].ToString().Length - 3, 3)) + 1;
                string joinstr = "000" + hitung;
                urut = "INV" + joinstr.Substring(joinstr.Length - 3, 3);
            }
            else
            {
                urut = "INV001";
            }
            rd.Close();
            txt_id.Text = urut;
            con.Close();
        }
        void munculNamaPembeli()
        {
            cmb_pembeli.Items.Clear();
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tabel_pengguna where role = @role";
            cmd.Parameters.AddWithValue("@role", "pembeli");
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmb_pembeli.Items.Add(dr["nama_user"].ToString());
            }
            con.Close();
        }
        void munculNamaMenu()
        {
            cmb_menu.Items.Clear();
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tabel_menu";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmb_menu.Items.Add(dr["nama_menu"].ToString());
            }
            con.Close();
        }
        void hitungTotalJumlahMakanan()
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(jumlah_beli) FROM tabel_cart_pesanan", con);
                int sum = (int)cmd.ExecuteScalar();
                txt_jumlahMakanan.Text = sum.ToString();
                con.Close();
            }
            catch (Exception peringatan)
            {

            }
        }
        void hitungTotalJumlahHarga()
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(total_harga) FROM tabel_cart_pesanan", con);
                int sum = (int)cmd.ExecuteScalar();
                txt_totalBayar.Text = sum.ToString();
                con.Close();
            }
            catch (Exception peringatan)
            {

            }
        }
        void tampilFotoMenu()
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                SqlCommand cmd = new SqlCommand("SELECT foto FROM tabel_menu WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", txt_idMenu.Text);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    byte[] imageBytes = (byte[])reader["foto"];
                    MemoryStream ms = new MemoryStream(imageBytes);
                    pictureBox1.Image = Image.FromStream(ms);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
        void printNota()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Nota Pembelian";
            printer.SubTitle = string.Format("Tanggal: {0}", DateTime.Now.Date.ToString("dd/MM/yyyy"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Terima kasih atas pembelian Anda!";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }
        public PembeliDashboard()
        {
            InitializeComponent();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            txt_id.ReadOnly = true;
        }

        private void txt_idPembeli_TextChanged(object sender, EventArgs e)
        {
            txt_idPembeli.ReadOnly = true;
        }

        private void txt_idMenu_TextChanged(object sender, EventArgs e)
        {
            txt_idMenu.ReadOnly = true;
        }

        private void txt_hargaSatuan_TextChanged(object sender, EventArgs e)
        {
            txt_hargaSatuan.ReadOnly = true;
        }

        private void txt_jumlahMakanan_TextChanged(object sender, EventArgs e)
        {
            txt_jumlahMakanan.ReadOnly = true;
        }

        private void txt_totalBayar_TextChanged(object sender, EventArgs e)
        {
            txt_totalBayar.ReadOnly = true;
        }

        private void PembeliDashboard_Load(object sender, EventArgs e)
        {
            tampilData();
            kodeOtomatis();
            munculNamaMenu();
            munculNamaPembeli();
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 550, 850);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            tampilData();
            kodeOtomatis();
        }

        private void btn_konfirmasi_Click(object sender, EventArgs e)
        {
            printNota();
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into tabel_transaksi values (@id,@nama_pembeli,@tanggal,@jumlah_makanan,@total_bayar,@jumlah_bayar,@kembalian,@status)", con);
                cmd1.Parameters.AddWithValue("@id", txt_id.Text);
                cmd1.Parameters.AddWithValue("@nama_pembeli", cmb_pembeli.Text);
                cmd1.Parameters.AddWithValue("@tanggal", DateTime.Now);
                cmd1.Parameters.AddWithValue("@jumlah_makanan", int.Parse(txt_jumlahMakanan.Text));
                cmd1.Parameters.AddWithValue("@total_bayar", float.Parse(txt_totalBayar.Text));
                cmd1.Parameters.AddWithValue("@jumlah_bayar", 0);
                cmd1.Parameters.AddWithValue("@kembalian", 0);
                cmd1.Parameters.AddWithValue("@status", "belum diproses");
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("delete from tabel_cart_pesanan", con);
                cmd2.ExecuteNonQuery();
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("insert into tabel_detail_pesanan values (@id_transaksi,@id_menu,@nama_menu,@harga_satuan,@jumlah_beli,@total_harga,@tanggal)", con);
                cmd1.Parameters.AddWithValue("@id_transaksi", txt_id.Text);
                cmd1.Parameters.AddWithValue("@id_menu", txt_idMenu.Text);
                cmd1.Parameters.AddWithValue("@nama_menu", cmb_menu.Text);
                cmd1.Parameters.AddWithValue("@harga_satuan", float.Parse(txt_hargaSatuan.Text));
                cmd1.Parameters.AddWithValue("@jumlah_beli", int.Parse(txt_jumlahBeli.Text));
                cmd1.Parameters.AddWithValue("@total_harga", int.Parse(txt_totalHarga.Text));
                cmd1.Parameters.AddWithValue("@tanggal", DateTime.Now);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("insert into tabel_cart_pesanan values (@id_transaksi,@id_menu,@nama_menu,@harga_satuan,@jumlah_beli,@total_harga)", con);
                cmd2.Parameters.AddWithValue("@id_transaksi", txt_id.Text);
                cmd2.Parameters.AddWithValue("@id_menu", txt_idMenu.Text);
                cmd2.Parameters.AddWithValue("@nama_menu", cmb_menu.Text);
                cmd2.Parameters.AddWithValue("@harga_satuan", float.Parse(txt_hargaSatuan.Text));
                cmd2.Parameters.AddWithValue("@jumlah_beli", int.Parse(txt_jumlahBeli.Text));
                cmd2.Parameters.AddWithValue("@total_harga", int.Parse(txt_totalHarga.Text));
                cmd2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sukses Insert Data");
            }
            catch (Exception peringatan)
            {
                MessageBox.Show("Aduh: " + peringatan.Message);
            }
            tampilData();
            kodeOtomatis();
            hitungTotalJumlahMakanan();
            hitungTotalJumlahHarga();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("delete from tabel_detail_pesanan where id_transaksi = @id_transaksi and id_menu = @id_menu", con);
                cmd1.Parameters.AddWithValue("@id_transaksi", txt_id.Text);
                cmd1.Parameters.AddWithValue("@id_menu", txt_idMenu.Text);
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("delete from tabel_cart_pesanan where id_menu = @id_menu", con);
                cmd2.Parameters.AddWithValue("@id_menu", txt_idMenu.Text);
                cmd2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sukses Delete Data");
            }
            catch (Exception peringatan)
            {
                MessageBox.Show("Aduh: " + peringatan.Message);
            }
            tampilData();
            kodeOtomatis();
            hitungTotalJumlahMakanan();
            hitungTotalJumlahHarga();
        }

        private void cmb_menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tabel_menu where nama_menu = '" + cmb_menu.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int v = da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txt_idMenu.Text = dr["id"].ToString();
                txt_hargaSatuan.Text = dr["harga"].ToString();
            }
            con.Close();
            tampilFotoMenu();
        }

        private void cmb_pembeli_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tabel_pengguna where nama_user = '" + cmb_pembeli.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            int v = da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txt_idPembeli.Text = dr["id"].ToString();
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txt_idMenu.Text = dataGridView1.Rows[e.RowIndex].Cells["id_menu"].FormattedValue.ToString();
            }
        }

        private void btn_totalHarga_Click(object sender, EventArgs e)
        {
            float hargaSatuan;
            int jumlahBeli;
            float totalHarga;
            hargaSatuan = float.Parse(txt_hargaSatuan.Text);
            jumlahBeli = int.Parse(txt_jumlahBeli.Text);
            totalHarga = hargaSatuan * jumlahBeli;
            txt_totalHarga.Text = totalHarga.ToString();
        }
    }
}
