using System;
using System.Collections.Generic;
using System.Linq;

namespace CIBPhonebook.Common.Helpers
{
    public static class ReflectionHelper
    {
        public static IEnumerable<Type> GetTypes<T>()
        {
            var typeToFind = typeof(T);

            var assembliesToScan = AppDomain.CurrentDomain.GetAssemblies();

            return assembliesToScan
                .SelectMany(s => s.GetTypes())
                .Where(p => typeToFind.IsAssignableFrom(p) && !p.IsInterface && p.ContainsGenericParameters == false);
        }
    }
}
