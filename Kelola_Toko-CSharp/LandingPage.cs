using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_NAULANDARMAWAN_D
{
    public partial class LandingPage : Form
    {
        public int imageList = 1;
        void loadNextImage()
        {
            if (imageList == 10)
            {
                imageList = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"Images\{0}.jpg", imageList);
            imageList++;
        }
        public LandingPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadingScreen loadingPage = new LoadingScreen();
            loadingPage.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadNextImage();
        }
    }
}
