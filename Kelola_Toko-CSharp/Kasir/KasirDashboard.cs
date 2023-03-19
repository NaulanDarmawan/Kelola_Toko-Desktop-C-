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

namespace D_NAULANDARMAWAN_D.Kasir
{
    public partial class KasirDashboard : Form
    {
        string databaseKu = "Data Source=LAPTOP-3HFA1734\\SQLEXPRESS;Initial Catalog=D_NAULANDARMAWAN_D;Integrated Security=True";
        void tampilTotalDataPelanggan()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            string query = "SELECT COUNT(*) FROM tabel_pengguna where role = @role";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@role", "pembeli");
            int count = (int)cmd.ExecuteScalar();
            btn_pelanggan.Text = count + " Pembeli Terdaftar";
            con.Close();
        }
        void tampilTotalDataTransaksi()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            string query = "SELECT COUNT(*) FROM tabel_transaksi where status = @status";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@status", "belum diproses");
            int count = (int)cmd.ExecuteScalar();
            btn_transaksi.Text = count + " Belum Diproses";
            con.Close();
        }
        public KasirDashboard()
        {
            InitializeComponent();
        }

        private void KasirDashboard_Load(object sender, EventArgs e)
        {
            tampilTotalDataPelanggan();
            tampilTotalDataTransaksi();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            KasirAddPelanggan kasirAddPelanggan = new KasirAddPelanggan();
            kasirAddPelanggan.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            KasirAddTransaksi kasirAddTransaksi = new KasirAddTransaksi();
            kasirAddTransaksi.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            KasirLaporanTransaksi kasirLaporanTransaksi = new KasirLaporanTransaksi();
            kasirLaporanTransaksi.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Close();
            MessageBox.Show("Anda Berhasil Log Out :)");
        }
    }
}
