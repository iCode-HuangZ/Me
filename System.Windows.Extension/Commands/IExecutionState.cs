using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Commands
{
    public interface IExecutionState
    {
        bool IsCompleted { get; }
    }
}
