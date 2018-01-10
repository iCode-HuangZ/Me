using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class DebugExtesion
    {
        public static void Write<T>(this T o)
        {
            if (null == o) return;
            var type = typeof (T);
            Console.WriteLine();
            Console.WriteLine("-----{0}",type);
            foreach (var property in type.GetProperties())
            {
                Console.WriteLine("{0}:{1}",property.Name,property.GetValue(o));
            }
        }
        
    }
}
