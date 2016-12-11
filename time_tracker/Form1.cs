using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace time_tracker
{
    public partial class Form1 : MetroForm
    {
        static Form1 _instance;
        public static Form1 Instance { get { if (_instance == null) { _instance = new Form1(); } return _instance; } }

        public MetroLink Back { get { return backLink; } set { backLink = value; } }
        public MetroLabel TimerLabel { get { return timerLabel; } set { timerLabel = value; } }
        public new MetroPanel Container { get { return mainPanel; } set { mainPanel = value; } }

        public Timer myTimer;
        public Stopwatch stopwatch;

        public TimeSpan todayTime;
        public TimeSpan thisWeekTime;

        public string projectName;
        public bool isRunning = false;
        public bool isNewProject = false;

        public MainApplication mainApplication;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _instance = this;
            mainApplication = new MainApplication();
            createDashboardContainer();
        }

        private void CloseEvent(object sender, FormClosedEventArgs e)
        {
            if (mainApplication != null)
            {
                mainApplication.stopServices();
            }
        }

        private void backLink_Click(object sender, EventArgs e)
        {
            if (Form1.Instance.Container.Controls.ContainsKey("ucTask"))
            {
                clearFormContainer();
                createDashboardContainer();
                backLink.Visible = false;
                timerLabel.Visible = false;
            }
            else if(Form1.Instance.Container.Controls.ContainsKey("ucDescription"))
            {
                clearFormContainer();
                createTaskContainer();
            }
        }

        public void clearFormContainer()
        {
            Instance.Container.Controls.Clear();
        }

        public void createDashboardContainer()
        {
            ucDashboard dashboard = new ucDashboard();
            dashboard.Dock = DockStyle.Fill;
            Instance.Container.Controls.Add(dashboard);
            mainPanel.Controls["ucDashboard"].BringToFront();
        }

        public void createTaskContainer()
        {
            ucTask task = new ucTask();
            task.Dock = DockStyle.Fill;
            Instance.Container.Controls.Add(task);
            mainPanel.Controls["ucTask"].BringToFront();
        }

        public void createDescriptionContainer()
        {
            ucDescription description = new ucDescription();
            description.Dock = DockStyle.Fill;
            Instance.Container.Controls.Add(description);
            mainPanel.Controls["ucDescription"].BringToFront();
        }

        public void openPopUp()
        {
            var form = new PopupForm();
            var screen = Screen.PrimaryScreen.Bounds;
            form.StartPosition = FormStartPosition.Manual;
            form.DesktopLocation = new Point(screen.Width - this.ClientSize.Width, screen.Height - this.ClientSize.Height);
            form.Show(this);
        }
    }
}