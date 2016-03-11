using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obacher.Decade
{
    public static class GenericExtensions
    {
        public static bool In<T>(this T obj, params T[] values) where T: IComparable<T>
        {
            return values.Contains(obj);
        }
    }
}
