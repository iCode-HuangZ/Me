using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace System.Windows.Converters
{
    public class ResizeOrientationToCursor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ResizeOrientation)
            {
                switch ((ResizeOrientation)value)
                {
                    case ResizeOrientation.Left:
                        return Cursors.SizeWE;
                    case ResizeOrientation.LeftTop:
                        return Cursors.SizeNWSE;
                    case ResizeOrientation.Top:
                        return Cursors.SizeNS;
                    case ResizeOrientation.RightTop:
                        return Cursors.SizeNESW;
                    case ResizeOrientation.Right:
                        return Cursors.SizeWE;
                    case ResizeOrientation.RightBottom:
                        return Cursors.SizeNWSE;
                    case ResizeOrientation.Bottom:
                        return Cursors.SizeNS;
                    case ResizeOrientation.LeftBottom:
                        return Cursors.SizeNESW;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
