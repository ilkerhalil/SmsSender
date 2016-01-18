using System;
using SmsSender.Common;
using System.IO;
using System.Diagnostics;

namespace SmsSender.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new string[] { "", "", "" };
            var providers = SmsSenderProviderHelper.CreateInstance<BaseSmsProvider>("", "", "");
            foreach (var provider in providers)
            {
                Console.WriteLine(provider.ProviderName);
                var results = provider.SendSms(new[] { new SmsRequest()
                {
                    Number = "905422476935",
                    Content = "Merhaba"
                },new SmsRequest()
                {
                    Number = "90542247693",
                    Content = "Me"
                } });
                foreach (var result in results)
                {
                    //Console.WriteLine(result);
                    File.AppendAllText("result.txt", "\n" + result.ToString());
                }
            }
            Process.Start("result.txt");
            Console.ReadLine();
        }

    }

}
