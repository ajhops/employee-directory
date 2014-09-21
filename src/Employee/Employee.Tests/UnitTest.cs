using System;
using System.Reflection;

namespace Employee.Tests
{
    public class UnitTest
    {
        public static int Compare<T>(T x, T y)
        {
            var type = typeof (T);
            var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public);
            var fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public);
            var compareValue = 0;

            foreach (var property in properties)
            {
                var valx = property.GetValue(x, null) as IComparable;
                if (valx == null)
                    continue;
                var valy = property.GetValue(y, null);
                compareValue = valx.CompareTo(valy);
                if (compareValue != 0)
                    return compareValue;
            }
            foreach (var field in fields)
            {
                var valx = field.GetValue(x) as IComparable;
                if (valx == null)
                    continue;
                var valy = field.GetValue(y);
                compareValue = valx.CompareTo(valy);
                if (compareValue != 0)
                    return compareValue;
            }

            return compareValue;
        }
    }
}