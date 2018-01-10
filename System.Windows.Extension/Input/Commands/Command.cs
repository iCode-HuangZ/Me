using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace System.Windows.Input.Commands
{
    public class Command : ICommand, ICommandState, IExecutionState, INotifyPropertyChanged
    {
        private bool isCompleted;
        private bool isCancel;
        private bool isFaulted;
        private Exception exception;

        /// <summary>
        /// 获取或设置一个值，该值指示发生异常时，默认的解决方案
        /// </summary>
        public static Action<Exception> DefaultSolution { get; set; }

        /// <summary>
        /// 获取一个值，该值指示执行命令的委托
        /// </summary>
        protected Func<object, CancellationToken, Task> ExecuteDelegate { get; }

        /// <summary>
        /// 获取一个值，该值指示允许命令执行的委托
        /// </summary>
        protected Func<object, bool> CanExecuteDelegate { get; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否首次获取键盘焦点
        /// </summary>
        protected bool IsFirstKeyboardFocus { get; private set; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否允许执行命令
        /// </summary>
        protected bool IsCan { get; set; }

        /// <summary>
        /// 获取一个值，该值指示命令是否已经执行完毕
        /// </summary>
        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                isCompleted = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 获取一个值，该值指示执行命令时，是否出现异常而导致失败
        /// </summary>
        public bool IsFaulted
        {
            get { return isFaulted; }
            private set
            {
                isFaulted = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 获取一个值，该值指示执行命令时，用户是否取消执行
        /// </summary>
        public bool IsCancel
        {
            get { return isCancel; }

            private set
            {
                isCancel = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 获取一个值，该值指示执行命令时发生的异常信息
        /// </summary>
        public Exception Exception
        {
            get { return exception; }
            private set
            {
                exception = value;
                OnPropertyChanged();
            }
        }

        public CancelCommand Cancel { get; }

        /// <summary>
        /// 在命令执行后发生
        /// </summary>
        public event EventHandler<ExecutedEventArgs> Executed;

        /// <summary>
        /// 在属性值更改时发生
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 当出现影响是否应执行该命令的更改时发生
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// 用指定的委托实例化一个命令
        /// </summary>
        /// <param name="executeDelegate">执行委托</param>
        /// <param name="canExecuteDelegate">允许执行的委托</param>
        public Command(Func<object, CancellationToken, Task> executeDelegate, Func<object, bool> canExecuteDelegate = null)
        {
            ExecuteDelegate = executeDelegate;
            CanExecuteDelegate = canExecuteDelegate;
            IsCompleted = true;
            IsFirstKeyboardFocus = true;
            Cancel = new CancelCommand(this);
        }

        /// <summary>
        /// 确定此命令是否可在其当前状态下执行的方法。
        /// WPF 中触发 CanExecute 的条件：
        /// 1. 获取键盘焦点时
        /// 2. Execute 调用前
        /// 3. Execute 调用后。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual bool CanExecute(object parameter)
        {
            // 仅在第一次获取键盘焦点时，执行 CanExecuteDelegate
            if (IsFirstKeyboardFocus)
            {
                // 备注：使用关键字 async 返回的 Task 会自动执行
                IsCan = CanExecuteDelegate?.Invoke(parameter) ?? true;
                IsFirstKeyboardFocus = false;
            }
            return Can();
        }

        /// <summary>
        /// 最终确定此命令是否可在其当前状态下执行
        /// </summary>
        /// <returns></returns>
        protected virtual bool Can()
        {
            return IsCan && IsCompleted;
        }
        
        /// <summary>
        /// 在调用此命令时要调用的方法。
        /// 备注：请在此方法的最后一定加上 OnExecuted
        /// </summary>
        /// <param name="parameter"></param>
        public virtual async void Execute(object parameter)
        {
            var cancellationToken = Cancel.Initialization();
            IsCompleted = false;
            IsFaulted = false;
            Exception = null;
            // 备注：此方法会触发所有 ICommand.CanExecute
            CommandManager.InvalidateRequerySuggested();
            try
            {
                await ExecuteDelegate.Invoke(parameter, cancellationToken);
                IsCancel = cancellationToken.IsCancellationRequested;
            }
            catch (OperationCanceledException)
            {
                IsCancel = true;
            }
            catch (Exception ex)
            {
                IsFaulted = true;
                Exception = ex;
            }
            IsCompleted = true;
            CommandManager.InvalidateRequerySuggested();
            OnExecuted();
        }

        /// <summary>
        /// 引发 PropertyChanged 事件
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 引发 Executed 事件
        /// </summary>
        protected void OnExecuted()
        {
            Executed?.Invoke(this, new ExecutedEventArgs(this, Exception));
        }
    }
}
