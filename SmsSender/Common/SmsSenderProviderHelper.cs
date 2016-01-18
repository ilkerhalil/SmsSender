using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmsSender.Common
{
    public static class SmsSenderProviderHelper
    {
        public static BaseSmsProvider CreateInstance(string providerName, params object[] parameters)
        {
            return CreateInstance<BaseSmsProvider>(parameters).Single(s => s.ProviderName == providerName);
        }

        public static IEnumerable<T> CreateInstance<T>(params object[] parameters)
        {

            var dlls = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll").Where(w => !w.EndsWith("SmsSender.dll"));
            List<T> typesTy = new List<T>();
            foreach (var dll in dlls)
            {
                var assm = Assembly.LoadFile(dll);
                var modules = assm.GetModules();
                var types = modules.SelectMany(s => s.GetTypes());
                var targetTypes = types.Where(s => s.BaseType == (typeof(T)) && !s.IsAbstract);
                typesTy.AddRange(targetTypes.Select(s => (T)Activator.CreateInstance(s, parameters)));
            }
            return typesTy;
        }
    }
}
