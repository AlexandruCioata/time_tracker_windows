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
        public static Form1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Form1();
                }
                return _instance;
            }
        }

        public MetroPanel Container { get { return mainPanel; } set { mainPanel = value; } }
        public MetroLink Back { get { return backLink; } set { backLink = value; } }
        public MetroLabel TimerLabel { get { return timerLabel; } set { timerLabel = value; } }

        static MainApplication mainApplication;
        public MainApplication MainApp
        {
            get
            {
                if(mainApplication == null)
                {
                    mainApplication = new MainApplication();
                }
                return mainApplication;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("form 1");
            _instance = this;
            mainApplication = new MainApplication();
            ucDashboard uc = new ucDashboard();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }

        private void CloseEvent(object sender, FormClosedEventArgs e)
        {
            if (MainApp != null)
            {
                MainApp.stopServices();
            }
        }

        private void backLink_Click(object sender, EventArgs e)
        {
            if (Form1.Instance.Container.Controls.ContainsKey("ucTask"))
            {
                clearFormContainer();
                addPanelControl("ucDashboard");
                backLink.Visible = false;
                timerLabel.Visible = false;
            }
            else if(Form1.Instance.Container.Controls.ContainsKey("ucDescription"))
            {
                clearFormContainer();
                addPanelControl("ucTask");
            }
        }

        private void addPanelControl(string type)
        {
            switch (type)
            {
                case "ucDashboard":
                    ucDashboard dashboard = new ucDashboard();
                    dashboard.Dock = DockStyle.Fill;
                    Form1.Instance.Container.Controls.Add(dashboard);
                    mainPanel.Controls["ucDashboard"].BringToFront();
                    break;
                case "ucTask":
                    ucTask task = new ucTask();
                    task.Dock = DockStyle.Fill;
                    Form1.Instance.Container.Controls.Add(task);
                    mainPanel.Controls["ucTask"].BringToFront();
                    break;
                default:
                    break;
            }
        }

        private void clearFormContainer()
        {
            Form1.Instance.Container.Controls.Clear();
        }
    }
}