using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_tracker
{
    public partial class PopupForm : MetroFramework.Forms.MetroForm
    {
        int countDown = 10;
        Timer myTimer = new Timer();
        Stopwatch stopwatch = new Stopwatch();

        public PopupForm()
        {
            InitializeComponent();
        }

        private void PopupForm_Load(object sender, EventArgs e)
        {
            pbLastScreenshot.Image = Image.FromFile(ConfigurationManager.AppSettings["localCacheFolder"] + "/screen.png");
            pbLastScreenshot.SizeMode = PictureBoxSizeMode.StretchImage;

            myTimer.Tick += new EventHandler(timer_Tick);
            myTimer.Interval = 1000;
            myTimer.Enabled = true;
            myTimer.Start();
            stopwatch.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0}", ts.Seconds);
            int seconds;
            Int32.TryParse(elapsedTime, out seconds);
            metroLabel1.Text = seconds.ToString();
            if (seconds < countDown)
            {
                popupProgress.Value = seconds;
            }
            else
            {
                this.Close();
            }
        }

        private void btnCancelSending_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbLastScreenshot_Click(object sender, EventArgs e)
        {
            Form1.Instance.openFullScreenshot();
        }
    }
}
