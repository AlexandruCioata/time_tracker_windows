using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_tracker
{
    public partial class ucDescription : MetroFramework.Controls.MetroUserControl
    {
        string taskName = ucTask.task;

        public ucDescription()
        {
            InitializeComponent();
        }

        private void ucDescription_Load(object sender, EventArgs e)
        {
            tbCurrentTask.Text = taskName;
        }

        private void btnStartNewTask_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpan = Form1.stopwatch.Elapsed;
            ucTask.newTask = tbCurrentTask.Text;

            bool isRunning = Form1.Instance.isRunning;
            if(!isRunning)
            {
                Form1.Instance.isRunning = true;
                Form1.Instance.mainApplication.startServices();
                Form1.myTimer.Start();
                Form1.stopwatch.Start();
                Form1.myTimer.Tick += new EventHandler(Form1.Instance.timer_Tick);
            }

            string elapsedDay = String.Format("{0:0h}:{1:00m}:{2:00s}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            string elapsedWeek = String.Format("{0:0h}:{1:00m}:{2:00s}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

            Form1.Instance.todayTime = timeSpan;
            Form1.Instance.thisWeekTime = timeSpan;

            Form1.Instance.Container.Controls.Clear();
            Form1.Instance.createTaskContainer();
        }

        private void btnCancelTask_Click(object sender, EventArgs e)
        {
            Form1.Instance.Container.Controls.Clear();
            Form1.Instance.createTaskContainer();
        }

        private void tbCurrentTask_TextChanged(object sender, EventArgs e)
        {
            string newTaskName = tbCurrentTask.Text;
            btnStartNewTask.Visible = (newTaskName != taskName && newTaskName != "") ? true : false;
        }
    }
}
