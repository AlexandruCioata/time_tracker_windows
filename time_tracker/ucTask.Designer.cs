namespace time_tracker
{
    partial class ucTask
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentProjectLabel = new MetroFramework.Controls.MetroLabel();
            this.currentTask = new MetroFramework.Controls.MetroTile();
            this.taskLabel = new MetroFramework.Controls.MetroLabel();
            this.btnStart = new MetroFramework.Controls.MetroButton();
            this.todayLabel = new MetroFramework.Controls.MetroLabel();
            this.todayTimeLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.weekTimeLabel = new MetroFramework.Controls.MetroLabel();
            this.btnStop = new MetroFramework.Controls.MetroButton();
            this.pbScreenshot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // currentProjectLabel
            // 
            this.currentProjectLabel.AutoSize = true;
            this.currentProjectLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.currentProjectLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.currentProjectLabel.Location = new System.Drawing.Point(3, 4);
            this.currentProjectLabel.Name = "currentProjectLabel";
            this.currentProjectLabel.Size = new System.Drawing.Size(0, 0);
            this.currentProjectLabel.TabIndex = 1;
            // 
            // currentTask
            // 
            this.currentTask.ActiveControl = null;
            this.currentTask.Location = new System.Drawing.Point(3, 100);
            this.currentTask.Name = "currentTask";
            this.currentTask.Size = new System.Drawing.Size(254, 40);
            this.currentTask.TabIndex = 4;
            this.currentTask.Text = "Current Task";
            this.currentTask.UseSelectable = true;
            this.currentTask.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // taskLabel
            // 
            this.taskLabel.AutoSize = true;
            this.taskLabel.Location = new System.Drawing.Point(4, 78);
            this.taskLabel.Name = "taskLabel";
            this.taskLabel.Size = new System.Drawing.Size(80, 19);
            this.taskLabel.TabIndex = 5;
            this.taskLabel.Text = "Working on:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(163, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 30);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // todayLabel
            // 
            this.todayLabel.AutoSize = true;
            this.todayLabel.Location = new System.Drawing.Point(169, 170);
            this.todayLabel.Name = "todayLabel";
            this.todayLabel.Size = new System.Drawing.Size(46, 19);
            this.todayLabel.TabIndex = 8;
            this.todayLabel.Text = "Today:";
            // 
            // todayTimeLabel
            // 
            this.todayTimeLabel.AutoSize = true;
            this.todayTimeLabel.Location = new System.Drawing.Point(169, 200);
            this.todayTimeLabel.Name = "todayTimeLabel";
            this.todayTimeLabel.Size = new System.Drawing.Size(36, 19);
            this.todayTimeLabel.TabIndex = 9;
            this.todayTimeLabel.Text = "--:--";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(169, 229);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(67, 19);
            this.metroLabel4.TabIndex = 10;
            this.metroLabel4.Text = "This week:";
            // 
            // weekTimeLabel
            // 
            this.weekTimeLabel.AutoSize = true;
            this.weekTimeLabel.Location = new System.Drawing.Point(169, 261);
            this.weekTimeLabel.Name = "weekTimeLabel";
            this.weekTimeLabel.Size = new System.Drawing.Size(36, 19);
            this.weekTimeLabel.TabIndex = 11;
            this.weekTimeLabel.Text = "--:--";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(163, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(95, 30);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseSelectable = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pbScreenshot
            // 
            this.pbScreenshot.Location = new System.Drawing.Point(4, 170);
            this.pbScreenshot.Name = "pbScreenshot";
            this.pbScreenshot.Size = new System.Drawing.Size(159, 122);
            this.pbScreenshot.TabIndex = 13;
            this.pbScreenshot.TabStop = false;
            this.pbScreenshot.Click += new System.EventHandler(this.pbScreenshot_Click);
            // 
            // ucTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbScreenshot);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.weekTimeLabel);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.todayTimeLabel);
            this.Controls.Add(this.todayLabel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.taskLabel);
            this.Controls.Add(this.currentTask);
            this.Controls.Add(this.currentProjectLabel);
            this.Name = "ucTask";
            this.Size = new System.Drawing.Size(260, 330);
            this.Load += new System.EventHandler(this.ucTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel currentProjectLabel;
        private MetroFramework.Controls.MetroTile currentTask;
        private MetroFramework.Controls.MetroLabel taskLabel;
        private MetroFramework.Controls.MetroButton btnStart;
        private MetroFramework.Controls.MetroLabel todayLabel;
        private MetroFramework.Controls.MetroLabel todayTimeLabel;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel weekTimeLabel;
        private MetroFramework.Controls.MetroButton btnStop;
        private System.Windows.Forms.PictureBox pbScreenshot;
    }
}
