using System;
using System.Configuration;
using SmsSender.Exception;

namespace SmsSender.Vodafone
{
    public class VodafoneSmsProvider : BaseSmsProvider
    {
        public override string ProviderName
        {
            get
            {
                return "Vodafone Sms Provider";
            }
        }

        public VodafoneSmsProvider()
        {
            ProviderInit();
        }

        protected sealed override void ProviderInit()
        {
            var configurationSection = ConfigurationManager.GetSection("AveaSmsConfigSection") as VodafoneSmsProviderConfigSection;
            if (configurationSection == null) return;
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
            catch (System.Exception e)
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
