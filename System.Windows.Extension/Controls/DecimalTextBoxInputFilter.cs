using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace System.Windows.Controls
{
    public class DecimalTextBoxInputFilter:TextBoxInputFilter
    {
        public static readonly DependencyProperty DecimalsLengthProperty = DependencyProperty.Register(
              "DecimalsLength", typeof(int), typeof(DecimalTextBoxInputFilter), new PropertyMetadata(default(int)));

        /// <summary>
        /// 获取或设置一个值，该值指示小数点后的位数的长度
        /// </summary>
        public int DecimalsLength
        {
            get { return (int)GetValue(DecimalsLengthProperty); }
            set { SetValue(DecimalsLengthProperty, value); }
        }

        public DecimalTextBoxInputFilter()
        {
            DecimalsLength = 2;
        }

        public override bool CanInput(TextBox element, Key key)
        {
            var currentText = element.Text;
            // 小数点后的位数的长度
            if (!string.IsNullOrEmpty(currentText))
            {
                var index = currentText.IndexOf(".");
                // 判断输入光标的位置
                if (index != -1 && element.SelectionStart > index)
                {
                    var decimals = currentText.Substring(index + 1);
                    if (DecimalsLength == decimals.Length)
                    {
                        return false;
                    }
                }
            }
            // 小数点 
            if (key == Key.OemPeriod)
            {
                // 首位不能是小数点
                if (string.IsNullOrEmpty(currentText))
                {
                    return false;
                }
                // 禁止小数点重复
                return !currentText.Contains(".");
            }
            return key.IsNumberic() || key == Key.OemPeriod;
        }
    }
}
