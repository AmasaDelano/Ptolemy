using Ptolemy.UserInterface.Enums;

namespace Ptolemy.UserInterface.ViewModels
{
    internal class TimeUnitItem
    {
        #region Member Variables

        private readonly TimeUnit _timeUnit;
        private int _quantity;

        #endregion

        #region Constructors

        public TimeUnitItem(TimeUnit timeUnit, int quantity)
        {
            _timeUnit = timeUnit;
            _quantity = quantity;
        }

        #endregion

        #region Public Interface

        internal void UpdateQuantity(int quantity)
        {
            _quantity = quantity;
        }

        public static implicit operator TimeUnit(TimeUnitItem timeUnitItem)
        {
            return timeUnitItem._timeUnit;
        }

        #endregion

        #region Overridden Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region Private Helpers

        private string Name
        {
            get
            {
                string name = _timeUnit.ToString();

                if (_quantity > 1)
                {
                    name += "s";
                }

                return name;
            }
        }

        #endregion
    }
}
