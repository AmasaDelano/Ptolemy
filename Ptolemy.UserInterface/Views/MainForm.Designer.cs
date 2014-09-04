using System.Windows.Forms;

namespace Ptolemy.UserInterface.Views
{
    public partial class MainForm
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
            this._speedBox = new System.Windows.Forms.GroupBox();
            this._timeLabel = new System.Windows.Forms.Label();
            this._realUnitsComboBox = new System.Windows.Forms.ComboBox();
            this._simulatedUnitComboBox = new System.Windows.Forms.ComboBox();
            this._realStepsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._simulatedStepsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._startButton = new System.Windows.Forms.Button();
            this._rightPanel = new System.Windows.Forms.Panel();
            this._planetDisplayTabs = new System.Windows.Forms.TabControl();
            this._heavenPanel = new Ptolemy.UserInterface.Views.HeavenPanel();
            this._speedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._realStepsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._simulatedStepsNumericUpDown)).BeginInit();
            this._rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _speedBox
            // 
            this._speedBox.Controls.Add(this._timeLabel);
            this._speedBox.Controls.Add(this._realUnitsComboBox);
            this._speedBox.Controls.Add(this._simulatedUnitComboBox);
            this._speedBox.Controls.Add(this._realStepsNumericUpDown);
            this._speedBox.Controls.Add(this._simulatedStepsNumericUpDown);
            this._speedBox.Controls.Add(this._startButton);
            this._speedBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._speedBox.Location = new System.Drawing.Point(0, 592);
            this._speedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._speedBox.Name = "_speedBox";
            this._speedBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._speedBox.Size = new System.Drawing.Size(845, 100);
            this._speedBox.TabIndex = 2;
            this._speedBox.TabStop = false;
            this._speedBox.Text = "Prime Mover";
            // 
            // _timeLabel
            // 
            this._timeLabel.AutoSize = true;
            this._timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._timeLabel.Location = new System.Drawing.Point(239, 26);
            this._timeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._timeLabel.Name = "_timeLabel";
            this._timeLabel.Size = new System.Drawing.Size(22, 20);
            this._timeLabel.TabIndex = 5;
            this._timeLabel.Text = "in";
            // 
            // _simulatedUnitsComboBox
            // 
            this._realUnitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._realUnitsComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._realUnitsComboBox.FormattingEnabled = true;
            this._realUnitsComboBox.Location = new System.Drawing.Point(353, 22);
            this._realUnitsComboBox.Margin = new System.Windows.Forms.Padding(4);
            this._realUnitsComboBox.Name = "_realUnitsComboBox";
            this._realUnitsComboBox.Size = new System.Drawing.Size(160, 28);
            this._realUnitsComboBox.TabIndex = 4;
            this._realUnitsComboBox.SelectedIndexChanged += new System.EventHandler(this._realUnitsComboBox_SelectedIndexChanged);
            // 
            // _realUnitComboBox
            // 
            this._simulatedUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._simulatedUnitComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._simulatedUnitComboBox.FormattingEnabled = true;
            this._simulatedUnitComboBox.Location = new System.Drawing.Point(107, 22);
            this._simulatedUnitComboBox.Margin = new System.Windows.Forms.Padding(4);
            this._simulatedUnitComboBox.Name = "_simulatedUnitComboBox";
            this._simulatedUnitComboBox.Size = new System.Drawing.Size(123, 28);
            this._simulatedUnitComboBox.TabIndex = 3;
            this._simulatedUnitComboBox.SelectedIndexChanged += new System.EventHandler(this._simulatedUnitComboBox_SelectedIndexChanged);
            // 
            // _simulatedStepsNumericUpDown
            // 
            this._realStepsNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._realStepsNumericUpDown.Location = new System.Drawing.Point(272, 23);
            this._realStepsNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this._realStepsNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._realStepsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._realStepsNumericUpDown.Name = "_realStepsNumericUpDown";
            this._realStepsNumericUpDown.Size = new System.Drawing.Size(73, 26);
            this._realStepsNumericUpDown.TabIndex = 2;
            this._realStepsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._realStepsNumericUpDown.ValueChanged += new System.EventHandler(this._realStepsNumericUpDown_ValueChanged);
            // 
            // _realStepsNumericUpDown
            // 
            this._simulatedStepsNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._simulatedStepsNumericUpDown.Location = new System.Drawing.Point(16, 22);
            this._simulatedStepsNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this._simulatedStepsNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._simulatedStepsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._simulatedStepsNumericUpDown.Name = "_simulatedStepsNumericUpDown";
            this._simulatedStepsNumericUpDown.Size = new System.Drawing.Size(83, 26);
            this._simulatedStepsNumericUpDown.TabIndex = 1;
            this._simulatedStepsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._simulatedStepsNumericUpDown.ValueChanged += new System.EventHandler(this._simulatedStepsNumericUpDown_ValueChanged);
            // 
            // _startButton
            // 
            this._startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._startButton.Location = new System.Drawing.Point(535, 23);
            this._startButton.Margin = new System.Windows.Forms.Padding(4);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(84, 28);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Start";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // _rightPanel
            // 
            this._rightPanel.Controls.Add(this._planetDisplayTabs);
            this._rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._rightPanel.Location = new System.Drawing.Point(845, 0);
            this._rightPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._rightPanel.Name = "_rightPanel";
            this._rightPanel.Size = new System.Drawing.Size(200, 692);
            this._rightPanel.TabIndex = 3;
            // 
            // _planetDisplayTabs
            // 
            this._planetDisplayTabs.Location = new System.Drawing.Point(4, 4);
            this._planetDisplayTabs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._planetDisplayTabs.Name = "_planetDisplayTabs";
            this._planetDisplayTabs.SelectedIndex = 0;
            this._planetDisplayTabs.Size = new System.Drawing.Size(196, 266);
            this._planetDisplayTabs.TabIndex = 0;
            // 
            // _heavenPanel
            // 
            this._heavenPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._heavenPanel.Location = new System.Drawing.Point(0, 0);
            this._heavenPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._heavenPanel.Name = "_heavenPanel";
            this._heavenPanel.Size = new System.Drawing.Size(845, 692);
            this._heavenPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 692);
            this.Controls.Add(this._speedBox);
            this.Controls.Add(this._heavenPanel);
            this.Controls.Add(this._rightPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(499, 498);
            this.Name = "MainForm";
            this.Text = "Ptolemy\'s Heavens";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._speedBox.ResumeLayout(false);
            this._speedBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._realStepsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._simulatedStepsNumericUpDown)).EndInit();
            this._rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HeavenPanel _heavenPanel;
        private GroupBox _speedBox;
        private Panel _rightPanel;
        private TabControl _planetDisplayTabs;
        private NumericUpDown _realStepsNumericUpDown;
        private NumericUpDown _simulatedStepsNumericUpDown;
        private Button _startButton;
        private ComboBox _simulatedUnitComboBox;
        private Label _timeLabel;
        private ComboBox _realUnitsComboBox;

    }
}

