namespace time_tracker
{
    partial class PopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupForm));
            this.pbLastScreenshot = new System.Windows.Forms.PictureBox();
            this.popupProgress = new MetroFramework.Controls.MetroProgressSpinner();
            this.btnCancelSending = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLastScreenshot
            // 
            this.pbLastScreenshot.Location = new System.Drawing.Point(23, 63);
            this.pbLastScreenshot.Name = "pbLastScreenshot";
            this.pbLastScreenshot.Size = new System.Drawing.Size(280, 121);
            this.pbLastScreenshot.TabIndex = 3;
            this.pbLastScreenshot.TabStop = false;
            // 
            // popupProgress
            // 
            this.popupProgress.Location = new System.Drawing.Point(184, 192);
            this.popupProgress.Maximum = 9;
            this.popupProgress.Name = "popupProgress";
            this.popupProgress.Size = new System.Drawing.Size(63, 32);
            this.popupProgress.Spinning = false;
            this.popupProgress.TabIndex = 5;
            this.popupProgress.UseSelectable = true;
            // 
            // btnCancelSending
            // 
            this.btnCancelSending.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelSending.BackgroundImage")));
            this.btnCancelSending.Location = new System.Drawing.Point(271, 192);
            this.btnCancelSending.Name = "btnCancelSending";
            this.btnCancelSending.Size = new System.Drawing.Size(32, 32);
            this.btnCancelSending.TabIndex = 6;
            this.btnCancelSending.UseSelectable = true;
            this.btnCancelSending.Click += new System.EventHandler(this.btnCancelSending_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 192);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(81, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "metroLabel1";
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 251);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnCancelSending);
            this.Controls.Add(this.popupProgress);
            this.Controls.Add(this.pbLastScreenshot);
            this.Name = "PopupForm";
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "Send Screenshot?";
            this.Load += new System.EventHandler(this.PopupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLastScreenshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbLastScreenshot;
        private MetroFramework.Controls.MetroProgressSpinner popupProgress;
        private MetroFramework.Controls.MetroButton btnCancelSending;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}