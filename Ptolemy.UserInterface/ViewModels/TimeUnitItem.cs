using System;
using Ptolemy.UserInterface.Enums;

namespace Ptolemy.UserInterface.ViewModels
{
    internal class TimeUnitItem
    {
        #region Member Variables

        private readonly TimeUnits _timeUnit;
        private int _quantity;

        #endregion

        #region Constructors

        public TimeUnitItem(TimeUnits timeUnit, int quantity)
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

        public static implicit operator TimeUnits(TimeUnitItem timeUnitItem)
        {
            return timeUnitItem._timeUnit;
        }

        #endregion

        #region Overridden Methods

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((TimeUnitItem) obj);
        }

        protected bool Equals(TimeUnitItem other)
        {
            return _timeUnit == other._timeUnit;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) _timeUnit * 397);
            }
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
