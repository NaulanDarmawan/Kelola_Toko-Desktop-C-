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

namespace D_NAULANDARMAWAN_D.Kasir
{
    public partial class KasirLaporanTransaksi : Form
    {
        string databaseKu = "Data Source=LAPTOP-3HFA1734\\SQLEXPRESS;Initial Catalog=D_NAULANDARMAWAN_D;Integrated Security=True";
        void tampilData()
        {
            SqlConnection con = new SqlConnection(databaseKu);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tabel_transaksi where status = @status", con);
            cmd.Parameters.AddWithValue("@status", "sudah diproses");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void totalUntung()
        {
            try
            {
                SqlConnection con = new SqlConnection(databaseKu);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(total_bayar) FROM tabel_transaksi", con);

                int sum = (int)cmd.ExecuteScalar();
                textBox1.Text = sum.ToString();
                con.Close();
            }
            catch (Exception peringatan)
            {

            }
        }
        public KasirLaporanTransaksi()
        {
            InitializeComponent();
        }

        private void KasirLaporanTransaksi_Load(object sender, EventArgs e)
        {
            tampilData();
            totalUntung();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Laporan Data Keuntungan Caffe Kendedes";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalUntung();
        }

    
        }
    }

