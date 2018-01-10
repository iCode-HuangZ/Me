using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace System.Windows.Input
{
    public interface IInputFilter<TElement>
    {

        bool CanInput(TElement element, Key key);
    }
}
