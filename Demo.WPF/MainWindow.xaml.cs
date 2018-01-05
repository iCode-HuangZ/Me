using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Commands;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
           
            DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class MainViewModel : ViewModel
    {
        private string name;
        private DateTime? time;

        public string Name
        {
            get { return name; }
            set { OnPropertyChanged(ref name, value); }
        }

        public DateTime? Time
        {
            get { return time; }
            set { OnPropertyChanged(ref time, value); }
        }

        public Command ShowTime { get; }

        public Command ShowPassword { get; }

        public MainViewModel()
        {
            ShowTime = new Command(ShowTimeExecuteDelegate);
            ShowPassword = new Command(ShowPasswordExecuteDelegate,ShowPasswordCanExecuteDelegate);
        }

        private async Task<bool> ShowPasswordCanExecuteDelegate(object o)
        {
            await Task.Run(() => { });
            return o is PasswordBox;
        }

        private async Task ShowPasswordExecuteDelegate(object o, CancellationToken cancellationToken)
        {
            await Task.Run(() => { });
            var passwordBox = (PasswordBox) o;
            var intPtr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(passwordBox.SecurePassword);
            var password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(intPtr);
            MessageBox.Show(password);
        }

        private async Task ShowTimeExecuteDelegate(object o, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(500);
                Time = DateTime.Now;
            }
            Time = null;
        }
    }
}
