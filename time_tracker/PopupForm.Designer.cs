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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.pbLastScreenshot = new System.Windows.Forms.PictureBox();
            this.countDownLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(23, 205);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Yes";
            this.metroButton1.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(176, 205);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "No";
            this.metroButton2.UseSelectable = true;
            // 
            // pbLastScreenshot
            // 
            this.pbLastScreenshot.Location = new System.Drawing.Point(23, 63);
            this.pbLastScreenshot.Name = "pbLastScreenshot";
            this.pbLastScreenshot.Size = new System.Drawing.Size(228, 121);
            this.pbLastScreenshot.TabIndex = 3;
            this.pbLastScreenshot.TabStop = false;
            // 
            // countDownLabel
            // 
            this.countDownLabel.AutoSize = true;
            this.countDownLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.countDownLabel.Location = new System.Drawing.Point(224, 25);
            this.countDownLabel.Name = "countDownLabel";
            this.countDownLabel.Size = new System.Drawing.Size(0, 0);
            this.countDownLabel.TabIndex = 4;
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 251);
            this.Controls.Add(this.countDownLabel);
            this.Controls.Add(this.pbLastScreenshot);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Name = "PopupForm";
            this.Text = "Send Screenshot?";
            this.Load += new System.EventHandler(this.PopupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLastScreenshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.PictureBox pbLastScreenshot;
        private MetroFramework.Controls.MetroLabel countDownLabel;
    }
}