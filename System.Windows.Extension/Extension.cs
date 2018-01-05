using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace System.Windows
{
    public static class Extension
    {
        /// <summary>
        /// 获取系统消息参数
        /// </summary>
        /// <param name="resizeOrientation"></param>
        /// <returns></returns>
        public static int GetWParam(this ResizeOrientation resizeOrientation)
        {
            switch (resizeOrientation)
            {
                case ResizeOrientation.Left:
                    return 0xF001;
                case ResizeOrientation.LeftTop:
                    return 0xF004;
                case ResizeOrientation.Top:
                    return 0xF003;
                case ResizeOrientation.RightTop:
                    return 0xF005;
                case ResizeOrientation.Right:
                    return 0xF002;
                case ResizeOrientation.RightBottom:
                    return 0xF008;
                case ResizeOrientation.Bottom:
                    return 0xF006;
                case ResizeOrientation.LeftBottom:
                    return 0xF007;
                default:
                    throw new ArgumentOutOfRangeException("resizeOrientation");
            }
        }
        
        /// <summary>
        /// 获取鼠标位置（相对于屏幕）
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Point GetMousePoint<TElement>(this TElement element)
            where TElement : Visual, IInputElement
        {
            return element.PointToScreen(Mouse.GetPosition(element));
        }
    }
}
