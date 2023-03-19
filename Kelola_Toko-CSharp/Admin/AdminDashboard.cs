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
    public partial class AdminDashboard : Form
    {
        string databaseKu = "Data Source=LAPTOP-3HFA1734\\SQLEXPRESS;Initial Catalog=D_NAULANDARMAWAN_D;Integrated Security=True";
        void tampilTotalDataKasir()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            string query = "SELECT COUNT(*) FROM tabel_pengguna where role = @role";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@role", "kasir");
            int count = (int)cmd.ExecuteScalar();
            btn_kasir.Text = count + " Kasir Terdaftar";
            con.Close();
        }
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
        void tampilTotalDataMenu()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            string query = "SELECT COUNT(*) FROM tabel_menu";
            SqlCommand cmd = new SqlCommand(query, con);
            int count = (int)cmd.ExecuteScalar();
            btn_menu.Text = count + " Menu Kafe";
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
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            tampilTotalDataKasir();
            tampilTotalDataPelanggan();
            tampilTotalDataMenu();
            tampilTotalDataTransaksi();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            AdminAddKasir adminAddKasir = new AdminAddKasir();
            adminAddKasir.Show();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            AdminAddPelanggan adminAddPelanggan = new AdminAddPelanggan();
            adminAddPelanggan.Show();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            AdminAddMenu adminAddMenu = new AdminAddMenu();
            adminAddMenu.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            AdminPesanMakan adminPesanMakan = new AdminPesanMakan();
            adminPesanMakan.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            AdminAddTransaksi adminAddTransaksi = new AdminAddTransaksi();
            adminAddTransaksi.Show();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Close();
            MessageBox.Show("Anda Berhasil Log Out :)");
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AdminAddKasir adminAddKasir = new AdminAddKasir();
            adminAddKasir.Show();
        }

        private void AdminDashboard_Load_1(object sender, EventArgs e)
        {
            tampilTotalDataKasir();
            tampilTotalDataPelanggan();
            tampilTotalDataMenu();
            tampilTotalDataTransaksi();
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            AdminAddKasir adminAddKasir = new AdminAddKasir();
            adminAddKasir.Show();
        }

        private void toolStripLabel6_Click_1(object sender, EventArgs e)
        {
            AdminAddPelanggan adminAddPelanggan = new AdminAddPelanggan();
            adminAddPelanggan.Show();
        }

        private void toolStripLabel2_Click_1(object sender, EventArgs e)
        {
            AdminAddMenu adminAddMenu = new AdminAddMenu();
            adminAddMenu.Show();
        }

        private void toolStripLabel3_Click_1(object sender, EventArgs e)
        {
            AdminPesanMakan adminPesanMakan = new AdminPesanMakan();
            adminPesanMakan.Show();
        }

        private void toolStripLabel4_Click_1(object sender, EventArgs e)
        {
            AdminAddTransaksi adminAddTransaksi = new AdminAddTransaksi();
            adminAddTransaksi.Show();
        }

        private void toolStripLabel5_Click_1(object sender, EventArgs e)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.Show();
            this.Close();
            MessageBox.Show("Anda Berhasil Log Out :)");
        }
    }
}
