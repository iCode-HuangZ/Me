using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public sealed class Computer
    {
      
        /// <summary>
        /// 获取一个值，该值指示本地计算机
        /// </summary>
        public static Computer Current { get; }
        
        /// <summary>
        /// 获取一个值，该值指示用于保存生成的计算机信息得根目录
        /// </summary>
        public string RootDirectory { get; }

        /// <summary>
        /// 获取一个值，该值指示计算机唯一标识
        /// </summary>
        public Guid UID { get; }

        static Computer()
        {

        }

        private Computer()
        {
            try
            {
                var myDocumentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var directory = new StringBuilder().AppendFormat(@"Computer\").ToString();
                // 初始化根目录
                RootDirectory = Path.Combine(myDocumentsDirectory, directory);
                if (!Directory.Exists(RootDirectory))
                {
                    Directory.CreateDirectory(RootDirectory);
                }
                // 生成 UID
                var uidPath = Path.Combine(RootDirectory, "Unique Identification.txt");
                if (!File.Exists(uidPath))
                {
                    UID = Guid.NewGuid();
                    using (var file = new FileStream(uidPath,FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.Read))
                    {
                        var buffer = UID.ToByteArray();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                var builder = new StringBuilder();
                builder.AppendFormat("初始化 {0} 时，出现未处理异常", GetType().FullName);
                throw new Exception(builder.ToString(), ex);
            }
        }

    }
}
