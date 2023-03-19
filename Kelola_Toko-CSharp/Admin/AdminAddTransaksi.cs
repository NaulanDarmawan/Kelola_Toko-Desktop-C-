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
    public partial class AdminAddTransaksi : Form
    {
        string databaseKu = "Data Source=LAPTOP-3HFA1734\\SQLEXPRESS;Initial Catalog=D_NAULANDARMAWAN_D;Integrated Security=True";
        void tampilData()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tabel_transaksi where status = @status", con);
            cmd.Parameters.AddWithValue("@status", "belum diproses");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
            txt_id.Text = "";
            txt_namaUser.Text = "";
            txt_totalBayar.Text = "0";
            txt_jumlahBayar.Text = "0";
            txt_kembalian.Text = "0";
        }
        public AdminAddTransaksi()
        {
            InitializeComponent();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
            txt_id.ReadOnly = true;
        }

        private void txt_namaUser_TextChanged(object sender, EventArgs e)
        {
            txt_namaUser.ReadOnly = true;
        }

        private void txt_totalBayar_TextChanged(object sender, EventArgs e)
        {
            txt_totalBayar.ReadOnly = true;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            int totalBayar, jumlahBayar, kembalian;
            totalBayar = int.Parse(txt_totalBayar.Text);
            jumlahBayar = int.Parse(txt_jumlahBayar.Text);
            kembalian = jumlahBayar - totalBayar;
            txt_kembalian.Text = kembalian.ToString();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd = new SqlCommand("update tabel_transaksi set nama_pembeli = @nama_pembeli, jumlah_bayar = @jumlah_bayar, kembalian = @kembalian, status = @status where id = @id", con);
                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                cmd.Parameters.AddWithValue("@nama_pembeli", txt_namaUser.Text);
                cmd.Parameters.AddWithValue("@jumlah_bayar", float.Parse(txt_jumlahBayar.Text));
                cmd.Parameters.AddWithValue("@kembalian", float.Parse(txt_kembalian.Text));
                cmd.Parameters.AddWithValue("@status", "sudah diproses");
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

        private void AdminAddTransaksi_Load(object sender, EventArgs e)
        {
            tampilData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                txt_namaUser.Text = dataGridView1.Rows[e.RowIndex].Cells["nama_pembeli"].FormattedValue.ToString();
                txt_totalBayar.Text = dataGridView1.Rows[e.RowIndex].Cells["total_bayar"].FormattedValue.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
