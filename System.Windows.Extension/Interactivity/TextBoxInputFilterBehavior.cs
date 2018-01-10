using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace System.Windows.Interactivity
{
    /// <summary>
    /// 允许输入的键盘按键筛选器
    /// </summary>
    public class TextBoxInputFilterBehavior:Behavior<TextBox>
    {
        public static readonly DependencyProperty InputFilterProperty = DependencyProperty.Register("InputFilter", typeof (IInputFilter<TextBox>), typeof (TextBoxInputFilterBehavior), new PropertyMetadata(default(IInputFilter<TextBox>)));
        
        public IInputFilter<TextBox> InputFilter
        {
            get { return (IInputFilter<TextBox>) GetValue(InputFilterProperty); }
            set { SetValue(InputFilterProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
        }

        private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
        {
            //AssociatedObject.Write<TextBoxBase>();
            var handled = !InputFilter.CanInput(AssociatedObject, e.Key);
            e.Handled = handled;
        }
    }
}
