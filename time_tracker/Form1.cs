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
using System.Runtime.InteropServices;


namespace time_tracker
{
    public partial class Form1 : MetroForm
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        static Form1 _instance;
        public static Form1 Instance { get { if (_instance == null) { _instance = new Form1(); } return _instance; } }

        public MetroLink Back { get { return backLink; } set { backLink = value; } }
        public MetroLabel TimerLabel { get { return timerLabel; } set { timerLabel = value; } }
        public new MetroPanel Container { get { return mainPanel; } set { mainPanel = value; } }

        public static Timer myTimer;
        public static Stopwatch stopwatch;

        public TimeSpan todayTime;
        public TimeSpan thisWeekTime;

        public string projectName;
        public bool isRunning = false;
        public bool isNewProject = false;

        public MainApplication mainApplication;

        private TimeSpan timeSpan;
        public static string elapsedTime;

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
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

        public void timer_Tick(object sender, EventArgs e)
        {
            timeSpan = Form1.stopwatch.Elapsed;
            elapsedTime = String.Format("{0:0h}:{1:00m}:{2:00s}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
            Console.WriteLine(Form1.myTimer);
            Console.WriteLine(timeSpan.Seconds);
            Form1.Instance.TimerLabel.Text = elapsedTime;
            if (timeSpan.Seconds == 10)
            {
                Form1.Instance.openPopUp();
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

        public void openFullScreenshot()
        {
            var form = new Screenshot();
            var screen = Screen.PrimaryScreen.Bounds;
            form.Show(this);
        }
    }
}