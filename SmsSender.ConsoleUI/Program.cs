using System;
using SmsSender.Common;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace SmsSender.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new string[] { "", "", "" };
            var providers = SmsSenderProviderHelper.CreateInstance<BaseSmsProvider>("", "", "").ToList();
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

    }

}
