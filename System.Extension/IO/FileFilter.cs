using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    /// <summary>
    /// 文件筛选
    /// </summary>
    public sealed class FileFilter
    {
        /// <summary>
        /// 获取一个值，该值指示文件筛选名
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 扩展名集
        /// </summary>
        public List<string> ExtensionCollection { get; }

        public FileFilter(string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            Name = name;
            ExtensionCollection = new List<string>();
        }
        
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{0}|", Name);
            ExtensionCollection.ForEach(p =>
            {
                builder.AppendFormat("*{0};", p);
            });
            return builder.ToString();
        }
    }
}
