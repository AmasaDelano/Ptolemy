using System;
using System.Windows.Forms;
using Ptolemy.UserInterface.Controllers;
using Ptolemy.UserInterface.Models;
using Ptolemy.SolarSystem;
using Ptolemy.UserInterface.ViewModels;
using Ptolemy.UserInterface.Enums;

namespace Ptolemy.UserInterface.Views
{
    public partial class MainForm : Form
    {
        #region Member Variables

        private readonly AnimationController _animationController;
        private readonly HeavensController _heavensController;

        #endregion

        #region Constructors
        public MainForm()
        {
            _animationController = new AnimationController();
            _heavensController = new HeavensController();

            InitializeComponent();
        }
        #endregion

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set up the display options tabs for the planets
            this.SetUpPlanetDisplayTabs();

            // Set up animation controls
            this.SetUpAnimationControls();
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            string buttonText = _animationController.ToggleStart();
            _startButton.Text = buttonText;
        }

        private void _simulatedUnitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeUnit simulatedUnit = (TimeUnitItem) _simulatedUnitComboBox.SelectedItem;
            _animationController.SetSimulatedTimeUnit(simulatedUnit);
        }

        private void _realUnitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeUnit realUnit = (TimeUnitItem) _realUnitsComboBox.SelectedItem;
            _animationController.SetRealTimeUnit(realUnit);
        }
        
        private void _simulatedStepsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int simulatedSteps = (int) _simulatedStepsNumericUpDown.Value;
            _animationController.SetSimulatedTimeSteps(simulatedSteps);

            // Update drop down to pluralized versions, if necessary
            ((TimeUnitList) _simulatedUnitComboBox.DataSource).UpdateQuantity(simulatedSteps);
        }
        
        private void _realStepsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int realSteps = (int) _realStepsNumericUpDown.Value;
            _animationController.SetRealTimeSteps(realSteps);

            // Update drop down to pluralized versions, if necessary
            ((TimeUnitList) _realUnitsComboBox.DataSource).UpdateQuantity(realSteps);
        }

        #endregion

        #region Private Helpers

        private void SetUpPlanetDisplayTabs()
        {
            foreach (PlanetEnum planetEnum in SelectList.Of<PlanetEnum>())
            {
                PlanetController planetController = new PlanetController(planetEnum);
                string planetName = planetController.GetPlanetInfo().Name;

                // Create empty tab page
                TabPage planetDisplayTabPage = new TabPage
                {
                    Text = planetName
                };
                // Add custom control to page
                planetDisplayTabPage.Controls.Add(new PlanetDisplayTab(planetController));
                // Add tab page to tab control
                _planetDisplayTabs.TabPages.Add(planetDisplayTabPage);
            }
        }

        private void SetUpAnimationControls()
        {
            // Get speed info
            AnimationSpeedViewModel speedInfo = _animationController.GetAnimationSpeedInfo();

            // Bind enums to drop downs
            _simulatedUnitComboBox.DataSource = new TimeUnitList(quantity: speedInfo.RealTimeSteps);
            _realUnitsComboBox.DataSource = new TimeUnitList(quantity: speedInfo.SimulatedTimeSteps); 

            // Set initial values
            _simulatedStepsNumericUpDown.Value = speedInfo.RealTimeSteps;
            _simulatedUnitComboBox.SelectedItem = speedInfo.RealTimeUnit;
            _realStepsNumericUpDown.Value = speedInfo.SimulatedTimeSteps;
            _realUnitsComboBox.SelectedItem = speedInfo.SimulatedTimeUnit;
        }

        #endregion
    }
}