using System.Configuration;
using System.Runtime.InteropServices;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SmsSender.Avea;
using SmsSender.Turkcell;
using SmsSender.Vodafone;

namespace SmsSender.IOC
{
    public static class BootStrap
    {
        public static IUnityContainer Init()
        {
            var unityContainer = new UnityContainer();
            //unityContainer.RegisterType<ISmsProvider, AveaSmsProvider>("aveaSmsProvider");
            //unityContainer.RegisterType<ISmsProvider, VodafoneSmsProvider>("vodafoneSmsProvider");
            //unityContainer.RegisterType<ISmsProvider, TurkcellSmsProvider>("turkcellSmsProvider");

            var unityConfSec = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            if (unityConfSec != null) unityConfSec.Configure(unityContainer);
            return unityContainer;
        }
    }
}
