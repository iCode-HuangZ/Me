﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace System.Windows.Commands
{
    public class CancelCommand : ICommand
    {
        protected IExecutionState State { get; }

        protected CancellationTokenSource CancellationTokenSource { get; set; }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CancelCommand(IExecutionState state)
        {
            State = state;
        }

        /// <summary>
        /// 初始化 CancellationTokenSource
        /// </summary>
        /// <returns></returns>
        public CancellationToken Initialization()
        {
            CancellationTokenSource = new CancellationTokenSource();
            return CancellationTokenSource.Token;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return !State.IsCompleted;
        }

        void ICommand.Execute(object parameter)
        {
            CancellationTokenSource.Cancel();
        }
        
    }
}
