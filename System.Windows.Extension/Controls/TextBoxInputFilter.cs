using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace System.Windows.Controls
{
    public abstract class TextBoxInputFilter : DependencyObject, IInputFilter<TextBox>
    {
        public abstract bool CanInput(TextBox element, Key key);
    }
}
