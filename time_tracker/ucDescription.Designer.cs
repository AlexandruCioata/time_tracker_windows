namespace time_tracker
{
    partial class ucDescription
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
            this.tbCurrentTask = new MetroFramework.Controls.MetroTextBox();
            this.btnStartNewTask = new MetroFramework.Controls.MetroButton();
            this.btnCancelTask = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // tbCurrentTask
            // 
            // 
            // 
            // 
            this.tbCurrentTask.CustomButton.Image = null;
            this.tbCurrentTask.CustomButton.Location = new System.Drawing.Point(166, 1);
            this.tbCurrentTask.CustomButton.Name = "";
            this.tbCurrentTask.CustomButton.Size = new System.Drawing.Size(87, 87);
            this.tbCurrentTask.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbCurrentTask.CustomButton.TabIndex = 1;
            this.tbCurrentTask.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbCurrentTask.CustomButton.UseSelectable = true;
            this.tbCurrentTask.CustomButton.Visible = false;
            this.tbCurrentTask.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.tbCurrentTask.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.tbCurrentTask.Lines = new string[0];
            this.tbCurrentTask.Location = new System.Drawing.Point(3, 3);
            this.tbCurrentTask.MaxLength = 32767;
            this.tbCurrentTask.Multiline = true;
            this.tbCurrentTask.Name = "tbCurrentTask";
            this.tbCurrentTask.PasswordChar = '\0';
            this.tbCurrentTask.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbCurrentTask.SelectedText = "";
            this.tbCurrentTask.SelectionLength = 0;
            this.tbCurrentTask.SelectionStart = 0;
            this.tbCurrentTask.ShortcutsEnabled = true;
            this.tbCurrentTask.Size = new System.Drawing.Size(254, 89);
            this.tbCurrentTask.TabIndex = 0;
            this.tbCurrentTask.UseSelectable = true;
            this.tbCurrentTask.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbCurrentTask.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbCurrentTask.TextChanged += new System.EventHandler(this.tbCurrentTask_TextChanged);
            // 
            // btnStartNewTask
            // 
            this.btnStartNewTask.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnStartNewTask.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnStartNewTask.Location = new System.Drawing.Point(3, 143);
            this.btnStartNewTask.Name = "btnStartNewTask";
            this.btnStartNewTask.Size = new System.Drawing.Size(112, 40);
            this.btnStartNewTask.Style = MetroFramework.MetroColorStyle.Black;
            this.btnStartNewTask.TabIndex = 1;
            this.btnStartNewTask.Text = "Start Tracking";
            this.btnStartNewTask.UseCustomBackColor = true;
            this.btnStartNewTask.UseSelectable = true;
            this.btnStartNewTask.Visible = false;
            this.btnStartNewTask.Click += new System.EventHandler(this.btnStartNewTask_Click);
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCancelTask.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnCancelTask.Location = new System.Drawing.Point(145, 143);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Size = new System.Drawing.Size(112, 40);
            this.btnCancelTask.TabIndex = 2;
            this.btnCancelTask.Text = "Cancel";
            this.btnCancelTask.UseSelectable = true;
            this.btnCancelTask.Click += new System.EventHandler(this.btnCancelTask_Click);
            // 
            // ucDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelTask);
            this.Controls.Add(this.btnStartNewTask);
            this.Controls.Add(this.tbCurrentTask);
            this.Name = "ucDescription";
            this.Size = new System.Drawing.Size(260, 216);
            this.Load += new System.EventHandler(this.ucDescription_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tbCurrentTask;
        private MetroFramework.Controls.MetroButton btnStartNewTask;
        private MetroFramework.Controls.MetroButton btnCancelTask;
    }
}
