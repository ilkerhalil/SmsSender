using System;
using SmsSender.Common;
using System.IO;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity;
using SmsSender.Avea;
using SmsSender.IOC;
using SmsSender.Turkcell;
using SmsSender.Vodafone;

namespace SmsSender.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = BootStrap.Init();

            //var parameters = new string[] { "", "", "" };


            

            var providers = unityContainer.ResolveAll<ISmsProvider>().ToList();
            Console.WriteLine("Provider Seçiniz");

            foreach (var provider in providers)
            {
                Console.WriteLine("{0} - {1}", providers.IndexOf(provider) + 1, provider.ProviderName);
            }

            string selection = Console.ReadLine();
            int index = 0;

            if (!int.TryParse(selection, out index))
            {
                Console.WriteLine("Geçersiz seçim");
                return;
            }

            if (index <= 0 || index > providers.Count)
            {
                Console.WriteLine("Geçersiz seçim");
                return;
            }

            Console.WriteLine("SMS provider kullanıcı adı giriniz");
            string username = Console.ReadLine();

            Console.WriteLine("SMS provider şifre giriniz");
            string password = Console.ReadLine();

            Console.WriteLine("Mesaj başlığını giriniz");
            string header = Console.ReadLine();

            Console.WriteLine("Telefon numarası giriniz");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Göndermek istediğiniz mesajı giriniz");
            string messageContent = Console.ReadLine();

            index--;
            BaseSmsProvider selectedProvider = SmsSenderProviderHelper.CreateInstance(providers[index].ProviderName, username, password, header);
            var smsResponses = selectedProvider.SendSms(new SmsRequest() { Content = messageContent, Number = phoneNumber });


            foreach (var smsResponse in smsResponses) Console.WriteLine(smsResponse.ProviderMessage);

            Console.ReadKey();
        }

        //public ISmsProvider SmsProviderFactory(byte a)
        //{
        //    if(a== 1)return new AveaSmsProvider();
        //    if(a==2)return new TurkcellSmsProvider();
        //    if (a == 3) return new VodafoneSmsProvider();
        //    throw new System.Exception();
        //}


    }

}
