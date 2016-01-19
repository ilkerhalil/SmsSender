using System.Runtime.InteropServices;
using Microsoft.Practices.Unity;
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
            unityContainer.RegisterType<ISmsProvider, AveaSmsProvider>("aveaSmsProvider");
            unityContainer.RegisterType<ISmsProvider, VodafoneSmsProvider>("vodafoneSmsProvider");
            unityContainer.RegisterType<ISmsProvider, TurkcellSmsProvider>("turkcellSmsProvider");
            return unityContainer;
        }
    }
}
