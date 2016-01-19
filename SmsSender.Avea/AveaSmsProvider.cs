using System;
using System.Configuration;
using SmsSender.Exception;

namespace SmsSender.Avea
{
    public class AveaSmsProvider : BaseSmsProvider
    {
        public override string ProviderName
        {
            get
            {
                return "Avea Sms Provider";
            }
        }

        public AveaSmsProvider()
        {
            ProviderInit();
        }

        protected sealed override void ProviderInit()
        {
            var configurationSection = ConfigurationManager.GetSection("AveaSmsConfigSection") as AveaSmsProviderConfigSection;
            if (configurationSection == null) throw new SmsSenderException("Configuration Section boş..!",ProviderName);
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
