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

namespace time_tracker
{
    public partial class ucDashboard : MetroUserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
            if(Form1.Instance.projectName != null)
            {
                string projectName = Form1.Instance.projectName;
                cbChooseProject.SelectedIndex = cbChooseProject.FindStringExact(projectName);
            }
        }

        private void cbChooseProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbChooseProject.SelectedIndex > -1)
            {
                updateProject.Visible = true;
            }
        }

        private void updateProject_Click(object sender, EventArgs e)
        {
            string projectName = Form1.Instance.projectName;
            string chosenProject = cbChooseProject.SelectedItem.ToString();

            if (chosenProject != projectName)
            {
                projectName = chosenProject;
                Form1.Instance.projectName = projectName;
                Form1.Instance.isNewProject = true;
                Form1.myTimer = new Timer();
                Form1.Instance.todayTime = new TimeSpan(0, 0, 0);
                Form1.Instance.thisWeekTime = new TimeSpan(0, 0, 0);
                Form1.stopwatch = new Stopwatch();
                TimeSpan timeSpan = Form1.stopwatch.Elapsed;
                string elapsedTime = String.Format("{0:0h}:{1:00m}:{2:00s}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                Form1.Instance.TimerLabel.Text = elapsedTime;
            }
            else
            {
                Form1.Instance.isNewProject = false;
            }
            Form1.Instance.projectName = projectName;
            Form1.Instance.clearFormContainer();
            Form1.Instance.createTaskContainer();
            Form1.Instance.Back.Visible = true;
        }
    }
}
