using System.Drawing;
using System.Windows.Forms;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.ViewModels;

namespace Ptolemy.UserInterface.Views
{
    internal partial class PlanetDisplayTab : UserControl
    {
        #region Member Variables

        private readonly PlanetController _planetController;

        #endregion

        #region Constructors

        public PlanetDisplayTab(PlanetController planetController)
        {
            _planetController = planetController;

            // Pin it to the bottom (?)
            this.Dock = DockStyle.Bottom;

            InitializeComponent();
        }

        #endregion

        #region Events

        private void PlanetDisplayTab_Load(object sender, System.EventArgs e)
        {
            // Get display info
            PlanetViewModel planetInfo = _planetController.GetPlanetInfo();

            // Append the planet's name where applicable
            _showAllCheckbox.Text += planetInfo.Name;

            // Set initial control values
            _showAllCheckbox.Checked = planetInfo.ShowAll;
            _showOrbitsCheckBox.Checked = planetInfo.ShowOrbits;
            _showAxesCheckBox.Checked = planetInfo.ShowAxes;
            _zoomNumericUpDown.Value = planetInfo.Zoom;
            _showPlanetCheckBox.Checked = planetInfo.ShowPlanet;
            _planetSizeTrackBar.Value = planetInfo.PlanetSize;
            _planetColorPictureBox.BackColor = planetInfo.PlanetColor;

            // Enable/disable controls
            _displayOptionsGroupBox.Enabled = planetInfo.ShowAll;
        }

        private void _displayPlanetCheckbox_CheckedChanged(object sender, System.EventArgs e)
        {
            _planetController.SetShowAll(_showAllCheckbox.Checked);

            _displayOptionsGroupBox.Enabled = _showAllCheckbox.Checked;
        }
        
        private void _showAxesCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            _planetController.SetShowAxes(_showAxesCheckBox.Checked);
        }

        private void _showOrbitsCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            _planetController.SetShowOrbits(_showOrbitsCheckBox.Checked);
        }

        private void _showPlanetCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            _planetController.SetShowPlanet(_showPlanetCheckBox.Checked);
        }

        private void _planetSizeTrackBar_Scroll(object sender, System.EventArgs e)
        {
            _planetController.SetPlanetSize(_planetSizeTrackBar.Value);
        }

        private void _zoomNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            _planetController.SetZoom((double) _zoomNumericUpDown.Value);
        }

        private void _planetColorPictureBox_Click(object sender, System.EventArgs e)
        {
            // Show the color dialog
            _planetColorDialog.ShowDialog();
            // Set the color
            this.SetPlanetColor(_planetColorDialog.Color);
        }

        #endregion

        #region Private Helpers

        private void SetPlanetColor(Color color)
        {
            // Send a message to the controller
            _planetController.SetPlanetColor(color);
            // Update the visual color representation
            _planetColorPictureBox.BackColor = color;
        }

        #endregion
    }
}
