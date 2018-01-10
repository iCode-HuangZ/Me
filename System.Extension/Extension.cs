using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace System
{
    public static class Extension
    {
        /// <summary>
        /// 当前值是否在此范围内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static bool Range<T>(this T value, T minValue, T maxValue)
            where T : IComparable
        {
            if (minValue.CompareTo(maxValue) < 0)
            {
                throw new Exception("Range：minValue 必须小于 maxValue");
            }
            return value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
        }

    }
}
