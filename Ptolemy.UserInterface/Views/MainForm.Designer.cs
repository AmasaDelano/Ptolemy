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
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this._startButton = new System.Windows.Forms.Button();
            this._rightPanel = new System.Windows.Forms.Panel();
            this._planetDisplayTabs = new System.Windows.Forms.TabControl();
            this._heavenPanel = new Ptolemy.UserInterface.Views.HeavenPanel();
            this._speedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this._rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _speedBox
            // 
            this._speedBox.Controls.Add(this.numericUpDown2);
            this._speedBox.Controls.Add(this.numericUpDown1);
            this._speedBox.Controls.Add(this._startButton);
            this._speedBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._speedBox.Location = new System.Drawing.Point(0, 481);
            this._speedBox.Margin = new System.Windows.Forms.Padding(2);
            this._speedBox.Name = "_speedBox";
            this._speedBox.Padding = new System.Windows.Forms.Padding(2);
            this._speedBox.Size = new System.Drawing.Size(634, 81);
            this._speedBox.TabIndex = 2;
            this._speedBox.TabStop = false;
            this._speedBox.Text = "Prime Mover";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Location = new System.Drawing.Point(80, 26);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(55, 23);
            this.numericUpDown2.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(12, 26);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(62, 23);
            this.numericUpDown1.TabIndex = 1;
            // 
            // _startButton
            // 
            this._startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._startButton.Location = new System.Drawing.Point(155, 26);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(63, 23);
            this._startButton.TabIndex = 0;
            this._startButton.Text = "Start";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // _rightPanel
            // 
            this._rightPanel.Controls.Add(this._planetDisplayTabs);
            this._rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._rightPanel.Location = new System.Drawing.Point(634, 0);
            this._rightPanel.Margin = new System.Windows.Forms.Padding(2);
            this._rightPanel.Name = "_rightPanel";
            this._rightPanel.Size = new System.Drawing.Size(150, 562);
            this._rightPanel.TabIndex = 3;
            // 
            // _planetDisplayTabs
            // 
            this._planetDisplayTabs.Location = new System.Drawing.Point(3, 3);
            this._planetDisplayTabs.Margin = new System.Windows.Forms.Padding(2);
            this._planetDisplayTabs.Name = "_planetDisplayTabs";
            this._planetDisplayTabs.SelectedIndex = 0;
            this._planetDisplayTabs.Size = new System.Drawing.Size(147, 216);
            this._planetDisplayTabs.TabIndex = 0;
            // 
            // _heavenPanel
            // 
            this._heavenPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._heavenPanel.Location = new System.Drawing.Point(0, 0);
            this._heavenPanel.Margin = new System.Windows.Forms.Padding(2);
            this._heavenPanel.Name = "_heavenPanel";
            this._heavenPanel.Size = new System.Drawing.Size(634, 562);
            this._heavenPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this._speedBox);
            this.Controls.Add(this._heavenPanel);
            this.Controls.Add(this._rightPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(379, 413);
            this.Name = "MainForm";
            this.Text = "Ptolemy\'s Heavens";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._speedBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this._rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HeavenPanel _heavenPanel;
        private GroupBox _speedBox;
        private Panel _rightPanel;
        private TabControl _planetDisplayTabs;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Button _startButton;

    }
}

