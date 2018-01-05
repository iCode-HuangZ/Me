using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows
{
    /// <summary>
    /// 主窗口模式
    /// </summary>
    public enum MainWindowMode
    {
        /// <summary>
        /// 隐藏到系统托盘
        /// </summary>
        [Display(Name = "隐藏到系统托盘")]
        TrayToHide,

        /// <summary>
        /// 退出程序
        /// </summary>
        [Display(Name = "退出程序")]
        Exit
    }
}
