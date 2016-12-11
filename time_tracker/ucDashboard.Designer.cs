namespace time_tracker
{
    partial class ucDashboard
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbChooseProject = new MetroFramework.Controls.MetroComboBox();
            this.updateProject = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(3, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(132, 25);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Select a project";
            // 
            // cbChooseProject
            // 
            this.cbChooseProject.FormattingEnabled = true;
            this.cbChooseProject.ItemHeight = 23;
            this.cbChooseProject.Items.AddRange(new object[] {
            "Project 1",
            "Project 2",
            "Project 3"});
            this.cbChooseProject.Location = new System.Drawing.Point(3, 39);
            this.cbChooseProject.Name = "cbChooseProject";
            this.cbChooseProject.Size = new System.Drawing.Size(254, 29);
            this.cbChooseProject.TabIndex = 6;
            this.cbChooseProject.UseSelectable = true;
            this.cbChooseProject.SelectedIndexChanged += new System.EventHandler(this.cbChooseProject_SelectedIndexChanged);
            // 
            // updateProject
            // 
            this.updateProject.ActiveControl = null;
            this.updateProject.Location = new System.Drawing.Point(3, 125);
            this.updateProject.Name = "updateProject";
            this.updateProject.Size = new System.Drawing.Size(254, 53);
            this.updateProject.TabIndex = 7;
            this.updateProject.Text = "Update Project";
            this.updateProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.updateProject.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.updateProject.UseSelectable = true;
            this.updateProject.Visible = false;
            this.updateProject.Click += new System.EventHandler(this.updateProject_Click);
            // 
            // ucDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updateProject);
            this.Controls.Add(this.cbChooseProject);
            this.Controls.Add(this.metroLabel1);
            this.Name = "ucDashboard";
            this.Size = new System.Drawing.Size(260, 330);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbChooseProject;
        private MetroFramework.Controls.MetroTile updateProject;
    }
}
