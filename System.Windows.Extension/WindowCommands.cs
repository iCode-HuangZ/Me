using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Commands;
using System.Windows.Input;

namespace System.Windows
{
    /// <summary>
    /// 表示一组操作窗口的基本命令（最小化、最大化、还原...等）
    /// </summary>
    public static class WindowCommands
    {
        /// <summary>
        /// 获取一个命令，该命令能够使窗口最小化
        /// </summary>
        public static ICommand Minimize { get; }

        /// <summary>
        /// 获取一个命令，该命令能够使窗口最大化
        /// </summary>
        public static ICommand Maximize { get; }

        /// <summary>
        /// 获取一个命令，该命令能够使窗口还原
        /// </summary>
        public static ICommand Restore { get; }

        /// <summary>
        /// 获取一个命令，该命令能够使窗口关闭
        /// </summary>
        public static ICommand Close { get; }

        /// <summary>
        /// 获取一个命令，该命令能够显示系统菜单
        /// </summary>
        public static ICommand ShowSystemMenu { get; }

        static WindowCommands()
        {
            var canExecute = new Func<object, Task<bool>>(WindowCanExecuteDelegate);
            Minimize = new Command(MinimizeExecuteDelegate, canExecute);
            Maximize = new Command(MaximizeExecuteDelegate, canExecute);
            Restore = new Command(RestoreExecuteDelegate, canExecute);
            Close = new Command(CloseExecuteDelegate, canExecute);
            ShowSystemMenu = new Command(ShowSystemMenuExecuteDelegate, canExecute);
        }

        private static async Task ShowSystemMenuExecuteDelegate(object o, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });
            var window = (Window) o;
            SystemCommands.ShowSystemMenu(window, window.GetMousePoint());
        }

        private static async Task CloseExecuteDelegate(object o, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });
            SystemCommands.CloseWindow((Window) o);
        }

        private static async Task RestoreExecuteDelegate(object o, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });
            SystemCommands.RestoreWindow((Window) o);
        }

        private static async Task MaximizeExecuteDelegate(object o, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });
            SystemCommands.MaximizeWindow((Window) o);
        }


        private static async Task MinimizeExecuteDelegate(object o, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });
            SystemCommands.MinimizeWindow((Window) o);
        }

        private static async Task<bool> WindowCanExecuteDelegate(object o)
        {
            await Task.Run(() => { });
            return o is Window;
        }
    }
}
