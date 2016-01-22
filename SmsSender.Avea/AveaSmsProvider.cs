using System;
using System.Configuration;
using SmsSender.Exception;
using SmsSender.Logger;

namespace SmsSender.Avea
{
    public class AveaSmsProvider : BaseSmsProvider
    {
        public override string ProviderName => "Avea Sms Provider";

        public AveaSmsProvider()
        {
            ProviderInit();
        }

        protected sealed override void ProviderInit()
        {
            var configurationSection = ConfigurationManager.GetSection("AveaSmsConfigSection") as AveaSmsProviderConfigSection;
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
                    ProviderMessage = $"Fail..! - {e}",
                    SmsStatus = SmsStatus.Fail
                };
            }
        }
    }
}
