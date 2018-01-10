using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace System.Windows.Input
{
    public static class _Extension
    {
        /// <summary>
        /// 判断是否为数字键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsNumberic(this Key key)
        {
            return key.Range(Key.D0, Key.D9) || key.Range(Key.NumPad0, Key.NumPad9);
        }

        /// <summary>
        /// 是否为英文字母键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsAlphabet(this Key key)
        {
            return key.Range(Key.A, Key.Z);
        }
    }
}
