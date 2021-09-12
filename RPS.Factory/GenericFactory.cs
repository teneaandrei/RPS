using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS.Factory
{
    public static class GenericFactory<T>
    {
        public static List<T> GetInstancesOfType()
        {
            var getListOfRules = GetListOfTypes();
            return GetInstanes(getListOfRules);
        }

        private static List<T> GetInstanes(List<Type> types)
        {
            var rules = new List<T>();
            if (types != null)
            {
                foreach (var rule in types)
                {
                    rules.Add((T)Activator.CreateInstance(rule));
                }
            }
            return rules;
        }

        private static List<Type> GetListOfTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface).ToList();
        }
    }
}
