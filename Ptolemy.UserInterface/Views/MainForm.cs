using System;
using System.Linq;
using System.Windows.Forms;
using Ptolemy.UserInterface.Controllers;
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

        private void _goToEpochButton_Click(object sender, EventArgs e)
        {
            _heavensController.SetTimeToEpoch();
        }

        private void _goToNowButton_Click(object sender, EventArgs e)
        {
            _heavensController.SetTimeToNow();
        }

        #endregion

        #region Private Helpers

        private void SetUpPlanetDisplayTabs()
        {
            TabPage[] planetTabPages = SelectList.Of<PlanetEnum>()
                .Select(e => new PlanetController(e))
                .Select(e =>
                {
                    // Create empty tab page
                    TabPage tabPage = new TabPage
                    {
                        Text = e.GetPlanetInfo().Name
                    };

                    // Add custom control to page
                    tabPage.Controls.Add(new PlanetDisplayTab(e));

                    return tabPage;
                })
                .ToArray();

            _planetDisplayTabs.TabPages.AddRange(planetTabPages);
        }

        private void SetUpAnimationControls()
        {
            // Get speed info
            AnimationSpeedViewModel speedInfo = _animationController.GetAnimationSpeedInfo();

            // Hacky solution - not happy with it, but it preserves the values of speed info
            TimeUnit realTimeUnit = speedInfo.RealTimeUnit;
            TimeUnit simulatedTimeUnit = speedInfo.SimulatedTimeUnit;

            // Bind enums to drop downs
            _simulatedUnitComboBox.DataSource = new TimeUnitList(quantity: speedInfo.RealTimeSteps);
            _realUnitsComboBox.DataSource = new TimeUnitList(quantity: speedInfo.SimulatedTimeSteps);

            // Set initial values
            _simulatedStepsNumericUpDown.Value = speedInfo.RealTimeSteps;
            _simulatedUnitComboBox.SelectedItem = simulatedTimeUnit;
            _realStepsNumericUpDown.Value = speedInfo.SimulatedTimeSteps;
            _realUnitsComboBox.SelectedItem = realTimeUnit;
        }

        #endregion
    }
}