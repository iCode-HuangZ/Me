using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Microsoft.VisualBasic.Devices;

namespace NetworkApplication
{
    public class NetworkViewModel : ViewModel
    {
        private bool isAvailable;
        private Color available;

        protected Network Network { get; }

        /// <summary>
        /// 获取一个值，该值指示计算机是否已连接至网络
        /// </summary>
        public bool IsAvailable
        {
            get { return isAvailable; }
            private set
            {
                OnPropertyChanged(ref isAvailable,value);
                Available = value ? Colors.GreenYellow : Colors.Red;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示计算机网络状态色
        /// </summary>
        public Color Available
        {
            get { return available; }
            private set { OnPropertyChanged(ref available, value); }
        }

        public NetworkViewModel()
        {
            Network = new Network();
            CheckNetwork();
        }
        
        private async void CheckNetwork()
        {
            while (true)
            {
                try
                {
                    IsAvailable = await Task.Run(() =>
                    {
                        var result = Network.Ping("www.baidu.com");
                        Task.Delay(15*1000);
                        return result;
                    });
                }
                catch
                {
                    IsAvailable = false;
                }
            }
        }
        
    }
}
