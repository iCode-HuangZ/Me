using System.Threading;
using System.Threading.Tasks;

namespace System.Windows.Input.Commands
{
    /// <summary>
    /// 仅允许执行一次的命令
    /// </summary>
    public class OnceCommand : Command
    {
        private bool isExecuted;

        /// <summary>
        /// 获取一个值，该值指示命令是否执行过
        /// </summary>
        public bool IsExecuted
        {
            get { return isExecuted; }
            private set
            {
                isExecuted = value;
                OnPropertyChanged();
            }
        }

        public OnceCommand(Func<object, CancellationToken, Task> executeDelegate,Func<object,bool> canExecuteDelegate) : base(executeDelegate, canExecuteDelegate)
        {
            Executed += OnceCommand_Executed;
        }

        private void OnceCommand_Executed(object sender, ExecutedEventArgs e)
        {
            IsExecuted = true;
        }

        protected override bool Can()
        {
            return base.Can() && !IsExecuted;
        }
    }
}
