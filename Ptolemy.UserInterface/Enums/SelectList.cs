using System;
using System.Collections.Generic;
using System.Linq;

namespace Ptolemy.UserInterface.Enums
{
    public static class SelectList
    {
        public static List<T> Of<T>()
            where T : struct, IConvertible, IComparable, IFormattable
        {
            Type enumType = typeof (T);
            if (enumType.IsEnum)
            {
                return Enum.GetValues(enumType).Cast<T>().ToList();
            }
            return new List<T>();
        }
    }
}
