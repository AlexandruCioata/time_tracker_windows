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
using System.Globalization;

namespace time_tracker
{
    public partial class ucTask : MetroUserControl
    {
        public static string task;
        public static string newTask;
        public static TimeSpan todayTimer = new TimeSpan(0, 0, 0);
        public static string thisWeekTimer;
        public static string hours;
        public static string minutes;

        public ucTask()
        {
            InitializeComponent();
        }

        private void ucTask_Load(object sender, EventArgs e)
        {
            TimeSpan todayTime = Form1.Instance.todayTime;
            TimeSpan thisWeekTime = Form1.Instance.thisWeekTime;

            bool isNewProject = Form1.Instance.isNewProject;

            Form1.Instance.Back.Visible = Form1.Instance.isRunning ? false : true;
            Form1.Instance.TimerLabel.Visible = true;
            
            currentProjectLabel.Text = Form1.Instance.projectName;
            if(newTask != null)
            {
                currentTask.Text = newTask;
            }
            task = currentTask.Text;

            string elapsedDay = String.Format("{0:0h}:{1:00m}:{2:00s}", todayTime.Hours, todayTime.Minutes, todayTime.Seconds);
            string elapsedWeek = String.Format("{0:0h}:{1:00m}:{2:00s}", todayTime.Hours, todayTime.Minutes, todayTime.Seconds);

            todayTimeLabel.Text = elapsedDay;
            weekTimeLabel.Text = elapsedWeek;

            checkButtonsStatus();
            loadScreenShotImage();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form1.Instance.isRunning = true;
            Form1.Instance.Back.Visible = false;
            btnStart.Visible = false;
            btnStop.Visible = true;
            setTimerValues();
            Form1.Instance.mainApplication.startServices();
            Form1.myTimer.Start();
            Form1.stopwatch.Start();
        }

        private void setTimerValues()
        {
            Form1.myTimer.Tick += new EventHandler(Form1.Instance.timer_Tick);
            Form1.myTimer.Interval = 1000;
            Form1.myTimer.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Form1.Instance.isRunning = false;
            Form1.Instance.Back.Visible = true;

            checkButtonsStatus();

            TimeSpan currentTime = Form1.stopwatch.Elapsed;

            string elapsed = String.Format("{0:0h}:{1:00m}:{2:00s}", currentTime.Hours, currentTime.Minutes, currentTime.Seconds);
            todayTimeLabel.Text = elapsed;
            weekTimeLabel.Text = elapsed;

            Form1.Instance.todayTime = currentTime;
            Form1.Instance.thisWeekTime = currentTime;

            Form1.Instance.mainApplication.stopServices();
            Form1.stopwatch.Stop();
            Form1.myTimer.Stop();
            Form1.myTimer.Tick -= new EventHandler(Form1.Instance.timer_Tick);
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Form1.Instance.Container.Controls.Clear();
            Form1.Instance.createDescriptionContainer();
            Form1.Instance.Back.Visible = true;
        }

        private void loadScreenShotImage()
        {
            pbScreenshot.Image = Image.FromFile(ConfigurationManager.AppSettings["localCacheFolder"] + "/screen.png");
            pbScreenshot.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void checkButtonsStatus()
        {
            btnStart.Visible = Form1.Instance.isRunning ? false : true;
            btnStop.Visible = Form1.Instance.isRunning ? true : false;
        }

        private void checkCurrentTaskChange()
        {
            if (newTask == null)
            {
                newTask = currentTask.Text;
            }
            else
            {
                currentTask.Text = newTask;
            }
        }

        private void pbScreenshot_Click(object sender, EventArgs e)
        {
            Form1.Instance.openFullScreenshot();
        }
    }
}