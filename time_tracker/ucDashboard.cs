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
    public partial class ucDashboard : MetroFramework.Controls.MetroUserControl
    {
        public ucDashboard()
        {
            InitializeComponent();
        }

        private void Project1_Click(object sender, EventArgs e)
        {
            if (!Form1.Instance.Container.Controls.ContainsKey("ucTask"))
            {
                Form1.Instance.Container.Controls.Clear();
                ucTask task = new ucTask();
                task.Dock = DockStyle.Fill;
                Form1.Instance.Container.Controls.Add(task);
            }
            Form1.Instance.Container.Controls["ucTask"].BringToFront();
            Form1.Instance.Back.Visible = true;
        }
    }
}
