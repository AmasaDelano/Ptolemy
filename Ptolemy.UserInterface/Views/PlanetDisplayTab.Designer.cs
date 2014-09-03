namespace Ptolemy.UserInterface.Views
{
    partial class PlanetDisplayTab
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
            this._showAllCheckbox = new System.Windows.Forms.CheckBox();
            this._displayOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this._showPlanetCheckBox = new System.Windows.Forms.CheckBox();
            this._showOrbitsCheckBox = new System.Windows.Forms.CheckBox();
            this._showAxesCheckBox = new System.Windows.Forms.CheckBox();
            this._displayOptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _showAllCheckbox
            // 
            this._showAllCheckbox.AutoSize = true;
            this._showAllCheckbox.Location = new System.Drawing.Point(18, 2);
            this._showAllCheckbox.Margin = new System.Windows.Forms.Padding(2);
            this._showAllCheckbox.Name = "_showAllCheckbox";
            this._showAllCheckbox.Size = new System.Drawing.Size(56, 17);
            this._showAllCheckbox.TabIndex = 0;
            this._showAllCheckbox.Text = "Show ";
            this._showAllCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._showAllCheckbox.UseVisualStyleBackColor = true;
            this._showAllCheckbox.CheckedChanged += new System.EventHandler(this._displayPlanetCheckbox_CheckedChanged);
            // 
            // _displayOptionsGroupBox
            // 
            this._displayOptionsGroupBox.Controls.Add(this._showPlanetCheckBox);
            this._displayOptionsGroupBox.Controls.Add(this._showOrbitsCheckBox);
            this._displayOptionsGroupBox.Controls.Add(this._showAxesCheckBox);
            this._displayOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._displayOptionsGroupBox.Location = new System.Drawing.Point(0, 28);
            this._displayOptionsGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this._displayOptionsGroupBox.Name = "_displayOptionsGroupBox";
            this._displayOptionsGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this._displayOptionsGroupBox.Size = new System.Drawing.Size(112, 155);
            this._displayOptionsGroupBox.TabIndex = 1;
            this._displayOptionsGroupBox.TabStop = false;
            // 
            // _showPlanetCheckBox
            // 
            this._showPlanetCheckBox.AutoSize = true;
            this._showPlanetCheckBox.Location = new System.Drawing.Point(15, 63);
            this._showPlanetCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this._showPlanetCheckBox.Name = "_showPlanetCheckBox";
            this._showPlanetCheckBox.Size = new System.Drawing.Size(85, 17);
            this._showPlanetCheckBox.TabIndex = 2;
            this._showPlanetCheckBox.Text = "Show planet";
            this._showPlanetCheckBox.UseVisualStyleBackColor = true;
            this._showPlanetCheckBox.CheckedChanged += new System.EventHandler(this._showPlanetCheckBox_CheckedChanged);
            // 
            // _showOrbitsCheckBox
            // 
            this._showOrbitsCheckBox.AutoSize = true;
            this._showOrbitsCheckBox.Location = new System.Drawing.Point(15, 41);
            this._showOrbitsCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this._showOrbitsCheckBox.Name = "_showOrbitsCheckBox";
            this._showOrbitsCheckBox.Size = new System.Drawing.Size(81, 17);
            this._showOrbitsCheckBox.TabIndex = 1;
            this._showOrbitsCheckBox.Text = "Show orbits";
            this._showOrbitsCheckBox.UseVisualStyleBackColor = true;
            this._showOrbitsCheckBox.CheckedChanged += new System.EventHandler(this._showOrbitsCheckBox_CheckedChanged);
            // 
            // _showAxesCheckBox
            // 
            this._showAxesCheckBox.AutoSize = true;
            this._showAxesCheckBox.Location = new System.Drawing.Point(15, 18);
            this._showAxesCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this._showAxesCheckBox.Name = "_showAxesCheckBox";
            this._showAxesCheckBox.Size = new System.Drawing.Size(78, 17);
            this._showAxesCheckBox.TabIndex = 0;
            this._showAxesCheckBox.Text = "Show axes";
            this._showAxesCheckBox.UseVisualStyleBackColor = true;
            this._showAxesCheckBox.CheckedChanged += new System.EventHandler(this._showAxesCheckBox_CheckedChanged);
            // 
            // PlanetDisplayTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._displayOptionsGroupBox);
            this.Controls.Add(this._showAllCheckbox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PlanetDisplayTab";
            this.Size = new System.Drawing.Size(112, 183);
            this.Load += new System.EventHandler(this.PlanetDisplayTab_Load);
            this._displayOptionsGroupBox.ResumeLayout(false);
            this._displayOptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _showAllCheckbox;
        private System.Windows.Forms.GroupBox _displayOptionsGroupBox;
        private System.Windows.Forms.CheckBox _showPlanetCheckBox;
        private System.Windows.Forms.CheckBox _showOrbitsCheckBox;
        private System.Windows.Forms.CheckBox _showAxesCheckBox;
    }
}
