using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_tracker
{
    public partial class Form1 : Form
    {
        MainApplication mainApplication;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainApplication = new MainApplication();
            mainApplication.startServices();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CloseEvent(object sender, FormClosedEventArgs e)
        {
            if(mainApplication != null)
            {
                mainApplication.stopServices();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (mainApplication != null)
            {
                mainApplication.stopServices();
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mainApplication != null)
            {
                mainApplication.getData();
            }
        }
    }
}
