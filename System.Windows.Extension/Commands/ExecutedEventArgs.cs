using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace System.Windows.Commands
{
    /// <summary>
    /// 命令执行完毕后
    /// </summary>
    public class ExecutedEventArgs: EventArgs
    {
        public ICommandState CommandState { get; }
        
        public Exception Exception { get; }
        
        public ExecutedEventArgs(ICommandState commandState, Exception exception)
        {
            CommandState = commandState;
            Exception = exception;
        }

    }
}
