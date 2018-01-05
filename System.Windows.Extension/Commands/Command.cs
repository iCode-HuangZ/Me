using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace System.Windows.Commands
{
    public class Command :ICommand,ICommandState, IExecutionState, INotifyPropertyChanged
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
        protected Func<object, Task<bool>> CanExecuteDelegate { get; }
        
        /// <summary>
        /// 获取或设置一个值，该值指示是否首次获取键盘焦点
        /// </summary>
        protected bool IFirstKeyboardFocus { get; private set; }

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
        public Command(Func<object, CancellationToken, Task> executeDelegate, Func<object, Task<bool>> canExecuteDelegate = null)
        {
            ExecuteDelegate = executeDelegate;
            CanExecuteDelegate = canExecuteDelegate;
            IsCompleted = true;
            IFirstKeyboardFocus = true;
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
        public bool CanExecute(object parameter)
        {
            // 仅在第一次获取键盘焦点时，执行 CanExecuteDelegate
            if (IFirstKeyboardFocus)
            {
                // 备注：使用关键字 async 返回的 Task 会自动执行
                CanExecuteTask(parameter);
                IFirstKeyboardFocus = false;
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
        /// 确定此命令是否可在其当前状态下执行的任务
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private async Task CanExecuteTask(object parameter)
        {
            try
            {
                if (null == CanExecuteDelegate)
                {
                    IsCan = true;
                    return;
                }
                IsCan = await CanExecuteDelegate.Invoke(parameter);
                CommandManager.InvalidateRequerySuggested();
            }
            catch
            {
                IsCan = false;
            }
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
                await CanExecuteTask(parameter);
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
        protected virtual void OnExecuted()
        {
            Executed?.Invoke(this, new ExecutedEventArgs(this,Exception));
        }
    }
}
