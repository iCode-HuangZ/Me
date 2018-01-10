using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ToExtension
    {
        /// <summary>
        /// 将指定枚举的值转换为 32 位带符号整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(this Enum value)
        {
            return Convert.ToInt32(value);
        }
    }
}
