﻿using System;
using System.Configuration;

namespace SmsSender.Turkcell
{
    /// <summary>
    /// todo:exception,SmsSenderException'a taşınacak.
    /// </summary>
    public class TurkcellSmsProvider : BaseSmsProvider
    {
        public override string ProviderName
        {
            get
            {
                return "Turkcell Sms Provider";
            }
        }

        public TurkcellSmsProvider()
        {
            ProviderInit();
        }

        protected sealed override void ProviderInit()
        {
            var configurationSection = ConfigurationManager.GetSection("TurkcellSmsConfigSection") as TurkcellSmsProviderConfigSection;
            if (configurationSection == null) throw new Exception("Configuration Section boş..!");
            Header = configurationSection.Header;
            Password = configurationSection.Password;
            UserName = configurationSection.UserName;
        }


        protected override SmsResponse SendSms(SmsRequest smsRequest)
        {
            try
            {
                Console.WriteLine("{0} numarasına - {1} içerik ile {2} Sms gönderildi.", smsRequest.Number, smsRequest.Content, ProviderName);
                return new SmsResponse { ProviderMessage = "Success", SmsStatus = SmsStatus.Success };
            }
            catch (Exception e)
            {
                return new SmsResponse
                {
                    ProviderMessage = string.Format("Fail..! - {0}", e),
                    SmsStatus = SmsStatus.Fail
                };
            }
        }

    }
}
