using System.ComponentModel;
using Ptolemy.UserInterface.Enums;

namespace Ptolemy.UserInterface.ViewModels
{
    internal class TimeUnitList : BindingList<TimeUnitItem>
    {
        #region Constructors

        internal TimeUnitList(int quantity)
        {
            foreach (TimeUnits timeUnit in SelectList.Of<TimeUnits>())
            {
                this.Items.Add(new TimeUnitItem(timeUnit, quantity));
            }
        }

        #endregion

        #region Public Interface

        internal void UpdateQuantity(int quantity)
        {
            for (int i = 0; i < this.Items.Count; i += 1)
            {
                this.Items[i].UpdateQuantity(quantity);
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, i));
            }
        }

        #endregion
    }
}
