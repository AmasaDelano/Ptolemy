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
            this.label1 = new System.Windows.Forms.Label();
            this._sizeLabel = new System.Windows.Forms.Label();
            this._zoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._zoomLabel = new System.Windows.Forms.Label();
            this._planetColorPictureBox = new System.Windows.Forms.PictureBox();
            this._planetSizeTrackBar = new System.Windows.Forms.TrackBar();
            this._showPlanetCheckBox = new System.Windows.Forms.CheckBox();
            this._showOrbitsCheckBox = new System.Windows.Forms.CheckBox();
            this._showAxesCheckBox = new System.Windows.Forms.CheckBox();
            this._planetColorDialog = new System.Windows.Forms.ColorDialog();
            this._displayOptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._zoomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._planetColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._planetSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // _showAllCheckbox
            // 
            this._showAllCheckbox.AutoSize = true;
            this._showAllCheckbox.Location = new System.Drawing.Point(24, 2);
            this._showAllCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._showAllCheckbox.Name = "_showAllCheckbox";
            this._showAllCheckbox.Size = new System.Drawing.Size(68, 21);
            this._showAllCheckbox.TabIndex = 0;
            this._showAllCheckbox.Text = "Show ";
            this._showAllCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._showAllCheckbox.UseVisualStyleBackColor = true;
            this._showAllCheckbox.CheckedChanged += new System.EventHandler(this._displayPlanetCheckbox_CheckedChanged);
            // 
            // _displayOptionsGroupBox
            // 
            this._displayOptionsGroupBox.Controls.Add(this.label1);
            this._displayOptionsGroupBox.Controls.Add(this._sizeLabel);
            this._displayOptionsGroupBox.Controls.Add(this._zoomNumericUpDown);
            this._displayOptionsGroupBox.Controls.Add(this._zoomLabel);
            this._displayOptionsGroupBox.Controls.Add(this._planetColorPictureBox);
            this._displayOptionsGroupBox.Controls.Add(this._planetSizeTrackBar);
            this._displayOptionsGroupBox.Controls.Add(this._showPlanetCheckBox);
            this._displayOptionsGroupBox.Controls.Add(this._showOrbitsCheckBox);
            this._displayOptionsGroupBox.Controls.Add(this._showAxesCheckBox);
            this._displayOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._displayOptionsGroupBox.Location = new System.Drawing.Point(0, 29);
            this._displayOptionsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._displayOptionsGroupBox.Name = "_displayOptionsGroupBox";
            this._displayOptionsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._displayOptionsGroupBox.Size = new System.Drawing.Size(149, 217);
            this._displayOptionsGroupBox.TabIndex = 1;
            this._displayOptionsGroupBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Color";
            // 
            // _sizeLabel
            // 
            this._sizeLabel.AutoSize = true;
            this._sizeLabel.Location = new System.Drawing.Point(17, 133);
            this._sizeLabel.Name = "_sizeLabel";
            this._sizeLabel.Size = new System.Drawing.Size(35, 17);
            this._sizeLabel.TabIndex = 8;
            this._sizeLabel.Text = "Size";
            // 
            // _zoomNumericUpDown
            // 
            this._zoomNumericUpDown.Location = new System.Drawing.Point(67, 104);
            this._zoomNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._zoomNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._zoomNumericUpDown.Name = "_zoomNumericUpDown";
            this._zoomNumericUpDown.Size = new System.Drawing.Size(56, 22);
            this._zoomNumericUpDown.TabIndex = 7;
            this._zoomNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._zoomNumericUpDown.ValueChanged += new System.EventHandler(this._zoomNumericUpDown_ValueChanged);
            // 
            // _zoomLabel
            // 
            this._zoomLabel.AutoSize = true;
            this._zoomLabel.Location = new System.Drawing.Point(17, 104);
            this._zoomLabel.Name = "_zoomLabel";
            this._zoomLabel.Size = new System.Drawing.Size(44, 17);
            this._zoomLabel.TabIndex = 6;
            this._zoomLabel.Text = "Zoom";
            // 
            // _planetColorPictureBox
            // 
            this._planetColorPictureBox.BackColor = System.Drawing.Color.Yellow;
            this._planetColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._planetColorPictureBox.Location = new System.Drawing.Point(67, 172);
            this._planetColorPictureBox.Name = "_planetColorPictureBox";
            this._planetColorPictureBox.Size = new System.Drawing.Size(25, 25);
            this._planetColorPictureBox.TabIndex = 5;
            this._planetColorPictureBox.TabStop = false;
            this._planetColorPictureBox.Click += new System.EventHandler(this._planetColorPictureBox_Click);
            // 
            // _planetSizeTrackBar
            // 
            this._planetSizeTrackBar.Location = new System.Drawing.Point(58, 133);
            this._planetSizeTrackBar.Maximum = 50;
            this._planetSizeTrackBar.Name = "_planetSizeTrackBar";
            this._planetSizeTrackBar.Size = new System.Drawing.Size(69, 56);
            this._planetSizeTrackBar.TabIndex = 4;
            this._planetSizeTrackBar.TickFrequency = 5;
            this._planetSizeTrackBar.Value = 10;
            this._planetSizeTrackBar.Scroll += new System.EventHandler(this._planetSizeTrackBar_Scroll);
            // 
            // _showPlanetCheckBox
            // 
            this._showPlanetCheckBox.AutoSize = true;
            this._showPlanetCheckBox.Location = new System.Drawing.Point(20, 78);
            this._showPlanetCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._showPlanetCheckBox.Name = "_showPlanetCheckBox";
            this._showPlanetCheckBox.Size = new System.Drawing.Size(107, 21);
            this._showPlanetCheckBox.TabIndex = 2;
            this._showPlanetCheckBox.Text = "Show planet";
            this._showPlanetCheckBox.UseVisualStyleBackColor = true;
            this._showPlanetCheckBox.CheckedChanged += new System.EventHandler(this._showPlanetCheckBox_CheckedChanged);
            // 
            // _showOrbitsCheckBox
            // 
            this._showOrbitsCheckBox.AutoSize = true;
            this._showOrbitsCheckBox.Location = new System.Drawing.Point(20, 50);
            this._showOrbitsCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._showOrbitsCheckBox.Name = "_showOrbitsCheckBox";
            this._showOrbitsCheckBox.Size = new System.Drawing.Size(103, 21);
            this._showOrbitsCheckBox.TabIndex = 1;
            this._showOrbitsCheckBox.Text = "Show orbits";
            this._showOrbitsCheckBox.UseVisualStyleBackColor = true;
            this._showOrbitsCheckBox.CheckedChanged += new System.EventHandler(this._showOrbitsCheckBox_CheckedChanged);
            // 
            // _showAxesCheckBox
            // 
            this._showAxesCheckBox.AutoSize = true;
            this._showAxesCheckBox.Location = new System.Drawing.Point(20, 22);
            this._showAxesCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._showAxesCheckBox.Name = "_showAxesCheckBox";
            this._showAxesCheckBox.Size = new System.Drawing.Size(97, 21);
            this._showAxesCheckBox.TabIndex = 0;
            this._showAxesCheckBox.Text = "Show axes";
            this._showAxesCheckBox.UseVisualStyleBackColor = true;
            this._showAxesCheckBox.CheckedChanged += new System.EventHandler(this._showAxesCheckBox_CheckedChanged);
            // 
            // PlanetDisplayTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._displayOptionsGroupBox);
            this.Controls.Add(this._showAllCheckbox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PlanetDisplayTab";
            this.Size = new System.Drawing.Size(149, 246);
            this.Load += new System.EventHandler(this.PlanetDisplayTab_Load);
            this._displayOptionsGroupBox.ResumeLayout(false);
            this._displayOptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._zoomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._planetColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._planetSizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _showAllCheckbox;
        private System.Windows.Forms.GroupBox _displayOptionsGroupBox;
        private System.Windows.Forms.CheckBox _showPlanetCheckBox;
        private System.Windows.Forms.CheckBox _showOrbitsCheckBox;
        private System.Windows.Forms.CheckBox _showAxesCheckBox;
        private System.Windows.Forms.Label _sizeLabel;
        private System.Windows.Forms.NumericUpDown _zoomNumericUpDown;
        private System.Windows.Forms.Label _zoomLabel;
        private System.Windows.Forms.PictureBox _planetColorPictureBox;
        private System.Windows.Forms.TrackBar _planetSizeTrackBar;
        private System.Windows.Forms.ColorDialog _planetColorDialog;
        private System.Windows.Forms.Label label1;
    }
}
