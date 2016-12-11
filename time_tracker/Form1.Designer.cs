namespace time_tracker
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backLink = new MetroFramework.Controls.MetroLink();
            this.mainPanel = new MetroFramework.Controls.MetroPanel();
            this.userName = new MetroFramework.Controls.MetroLabel();
            this.timerLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // backLink
            // 
            this.backLink.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backLink.BackgroundImage")));
            this.backLink.Location = new System.Drawing.Point(23, 23);
            this.backLink.Name = "backLink";
            this.backLink.Size = new System.Drawing.Size(32, 32);
            this.backLink.TabIndex = 3;
            this.backLink.UseSelectable = true;
            this.backLink.Visible = false;
            this.backLink.Click += new System.EventHandler(this.backLink_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.HorizontalScrollbarBarColor = true;
            this.mainPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.mainPanel.HorizontalScrollbarSize = 10;
            this.mainPanel.Location = new System.Drawing.Point(17, 102);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(260, 340);
            this.mainPanel.TabIndex = 5;
            this.mainPanel.VerticalScrollbarBarColor = true;
            this.mainPanel.VerticalScrollbarHighlightOnWheel = false;
            this.mainPanel.VerticalScrollbarSize = 10;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.userName.Location = new System.Drawing.Point(23, 460);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(97, 25);
            this.userName.TabIndex = 6;
            this.userName.Text = "User Name";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.timerLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.timerLabel.Location = new System.Drawing.Point(108, 60);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(74, 25);
            this.timerLabel.TabIndex = 7;
            this.timerLabel.Text = "0h:00m";
            this.timerLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 500);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.backLink);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "      Time Tracker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseEvent);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLink backLink;
        private MetroFramework.Controls.MetroPanel mainPanel;
        private MetroFramework.Controls.MetroLabel userName;
        private MetroFramework.Controls.MetroLabel timerLabel;
    }
}

