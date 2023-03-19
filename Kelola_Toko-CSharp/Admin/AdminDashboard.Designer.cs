namespace D_NAULANDARMAWAN_D.Admin
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_pelanggan = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_transaksi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_menu = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_kasir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1378, 100);
            this.panel1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel6,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.toolStripLabel5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1378, 30);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(88, 25);
            this.toolStripLabel1.Text = "Add Kasir";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click_1);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(133, 25);
            this.toolStripLabel6.Text = "Add Pelanggan";
            this.toolStripLabel6.Click += new System.EventHandler(this.toolStripLabel6_Click_1);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(96, 25);
            this.toolStripLabel2.Text = "Add Menu";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click_1);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(134, 25);
            this.toolStripLabel3.Text = "Pesan Makanan";
            this.toolStripLabel3.Click += new System.EventHandler(this.toolStripLabel3_Click_1);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(146, 25);
            this.toolStripLabel4.Text = "Validasi Transaksi";
            this.toolStripLabel4.Click += new System.EventHandler(this.toolStripLabel4_Click_1);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(77, 25);
            this.toolStripLabel5.Text = "Log Out";
            this.toolStripLabel5.Click += new System.EventHandler(this.toolStripLabel5_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(366, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(591, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "~~ SELAMAT DATANG ADMIN ~~";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 619);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1378, 100);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(376, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "~~ UKK 13 - 14 MARET 2023 ~~";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.btn_pelanggan);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btn_transaksi);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btn_menu);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btn_kasir);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1378, 519);
            this.panel3.TabIndex = 4;
            // 
            // btn_pelanggan
            // 
            this.btn_pelanggan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_pelanggan.Font = new System.Drawing.Font("Bahnschrift Condensed", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pelanggan.Location = new System.Drawing.Point(417, 181);
            this.btn_pelanggan.Name = "btn_pelanggan";
            this.btn_pelanggan.Size = new System.Drawing.Size(227, 208);
            this.btn_pelanggan.TabIndex = 7;
            this.btn_pelanggan.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(394, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 36);
            this.label6.TabIndex = 6;
            this.label6.Text = "Total Pelanggan Terdaftar";
            // 
            // btn_transaksi
            // 
            this.btn_transaksi.BackColor = System.Drawing.Color.DarkOrange;
            this.btn_transaksi.Font = new System.Drawing.Font("Bahnschrift Condensed", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_transaksi.Location = new System.Drawing.Point(1053, 181);
            this.btn_transaksi.Name = "btn_transaksi";
            this.btn_transaksi.Size = new System.Drawing.Size(227, 208);
            this.btn_transaksi.TabIndex = 5;
            this.btn_transaksi.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1078, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 36);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Transaksi";
            // 
            // btn_menu
            // 
            this.btn_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_menu.Font = new System.Drawing.Font("Bahnschrift Condensed", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_menu.Location = new System.Drawing.Point(745, 181);
            this.btn_menu.Name = "btn_menu";
            this.btn_menu.Size = new System.Drawing.Size(227, 208);
            this.btn_menu.TabIndex = 3;
            this.btn_menu.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(773, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Menu Toko";
            // 
            // btn_kasir
            // 
            this.btn_kasir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_kasir.Font = new System.Drawing.Font("Bahnschrift Condensed", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_kasir.Location = new System.Drawing.Point(110, 181);
            this.btn_kasir.Name = "btn_kasir";
            this.btn_kasir.Size = new System.Drawing.Size(227, 208);
            this.btn_kasir.TabIndex = 1;
            this.btn_kasir.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 36);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Kasir Terdaftar";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 719);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_pelanggan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_transaksi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_menu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_kasir;
        private System.Windows.Forms.Label label3;
    }
}