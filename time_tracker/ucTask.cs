using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace time_tracker
{
    public partial class ucTask : MetroUserControl
    {
        Timer myTimer = new Timer();
        Stopwatch stopwatch = new Stopwatch();
        static bool isRunning = false;

        public ucTask()
        {
            InitializeComponent();
        }

        private void ucTask_Load(object sender, EventArgs e)
        {
            Form1.Instance.TimerLabel.Visible = true;
            if(!isRunning)
            {
                btnStop.Visible = false;
            }
            else
            {
                btnStart.Visible = false;
                btnStop.Visible = true;
            }
            pbScreenshot.Image = Image.FromFile(ConfigurationManager.AppSettings["localCacheFolder"] + "/screen.png");
            pbScreenshot.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void LoadNewPict()
        {
            // You should replace the bold image 
            // in the sample below with an icon of your own choosing.
            // Note the escape character used (@) when specifying the path.
            //pictureBox1.Image = Image.FromFile
            //(System.Environment.GetFolderPath
            //(System.Environment.SpecialFolder.Personal)
            //+ @"\Image.gif");
        }

        private void taskLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isRunning = true;
            Form1.Instance.MainApp.startServices();
            btnStart.Visible = false;
            btnStop.Visible = true;
            myTimer.Tick += new EventHandler(timer_Tick);
            myTimer.Interval = 1000;
            myTimer.Enabled = true;
            myTimer.Start();
            stopwatch.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isRunning = false;
            if (Form1.Instance.MainApp != null)
            {
                
            }
            Form1.Instance.MainApp.stopServices();
            btnStop.Visible = false;
            btnStart.Visible = true;
            stopwatch.Stop();
            myTimer.Stop();  
        }

        void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            Form1.Instance.TimerLabel.Text = elapsedTime;
            //if (ts.Seconds == 10)
            //{
            //    var form = new PopupForm();
            //    form.StartPosition = FormStartPosition.Manual;
            //    form.Location = new Point(this.ClientSize.Width, 0);
            //    form.Show(this);
            //}
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.Container.Controls.ContainsKey("ucDescription"))
            {
                ucDescription description = new ucDescription();
                description.Dock = DockStyle.Fill;
                Form1.Instance.Container.Controls.Clear();
                Form1.Instance.Container.Controls.Add(description);
            }
            Form1.Instance.Container.Controls["ucDescription"].BringToFront();
            Form1.Instance.Back.Visible = true;
        }
    }
}
