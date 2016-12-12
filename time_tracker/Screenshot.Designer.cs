namespace time_tracker
{
    partial class Screenshot
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
            this.pbFullScreenshot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFullScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFullScreenshot
            // 
            this.pbFullScreenshot.Location = new System.Drawing.Point(23, 63);
            this.pbFullScreenshot.Name = "pbFullScreenshot";
            this.pbFullScreenshot.Size = new System.Drawing.Size(254, 214);
            this.pbFullScreenshot.TabIndex = 0;
            this.pbFullScreenshot.TabStop = false;
            // 
            // Screenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.pbFullScreenshot);
            this.MaximizeBox = false;
            this.Name = "Screenshot";
            this.Resizable = false;
            this.Text = "Screenshot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Screenshot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFullScreenshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFullScreenshot;
    }
}