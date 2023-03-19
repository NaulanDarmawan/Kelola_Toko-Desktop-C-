using D_NAULANDARMAWAN_D.Admin;
using D_NAULANDARMAWAN_D.Kasir;
using D_NAULANDARMAWAN_D.Pembeli;
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

namespace D_NAULANDARMAWAN_D
{
    public partial class LoginPage : Form
    {
        string databaseKu = "Data Source=LAPTOP-3HFA1734\\SQLEXPRESS;Initial Catalog=D_NAULANDARMAWAN_D;Integrated Security=True";
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String role = null;
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = new SqlCommand("select role from tabel_pengguna where username = @username and password = @password", con);
            cmd.Parameters.AddWithValue("@username", txt_userName.Text);
            cmd.Parameters.AddWithValue("@password", txt_password.Text);

            //konvert role di tabel kamu menjadi string agar bisa dibaca sistem
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                role = reader["role"].ToString();
            }
            reader.Close();
            //Batas Akhir

            if (role == "admin")
            {
                AdminDashboard halamanAdmin = new AdminDashboard();
                halamanAdmin.Show();
                this.Close();
                MessageBox.Show("Anda Masuk Sebagai Admin :)");

            }
            else if (role == "kasir")
            {
                KasirDashboard halamanKasir = new KasirDashboard();
                halamanKasir.Show();
                this.Close();
                MessageBox.Show("Anda Masuk Sebagai Kasir :)");

            }
            else if (role == "pembeli")
            {
                PembeliDashboard halamanPembeli = new PembeliDashboard();
                halamanPembeli.Show();
                this.Close();
                MessageBox.Show("Anda Masuk Sebagai Pembeli :)");

            }
            else
            {
                MessageBox.Show("Anda Masih Belum Terdaftar");
            }
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }
    }
}
