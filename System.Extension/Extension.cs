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
        /// <param name="value"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static bool Range(this double value, double minValue, double maxValue)
        {
            return (value >= minValue) && (value <= maxValue);
        }
        
    }
}
