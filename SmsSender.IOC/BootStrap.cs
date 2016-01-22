using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

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
            unityConfSec?.Configure(unityContainer);
            return unityContainer;
        }
    }
}
