using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphvizWrapper
{
    public static class EnumExtensions
    {
        public static bool Has<T>(this Enum type, T value)
        {
            return ((int) (object) type & (int) (object) value) == (int) (object) value;
        }

        public static bool Is<T>(this Enum type, T value)
        {
            return (int) (object) type == (int) (object) value;
        }

        public static T Add<T>(this Enum type, T value)
        {
            return (T) (object) ((int) (object) type | (int) (object) value);
        }

        public static T Remove<T>(this Enum type, T value)
        {
            return (T) (object) ((int) (object) type & ~(int) (object) value);
        }
    }
}