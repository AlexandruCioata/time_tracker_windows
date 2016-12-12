using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_tracker
{
    public partial class Screenshot : MetroForm
    {
        public Screenshot()
        {
            InitializeComponent();
        }

        private void Screenshot_Load(object sender, EventArgs e)
        {
            pbFullScreenshot.Image = Image.FromFile(ConfigurationManager.AppSettings["localCacheFolder"] + "/screen.png");
            pbFullScreenshot.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFullScreenshot.Dock = DockStyle.Fill;
        }
    }
}
