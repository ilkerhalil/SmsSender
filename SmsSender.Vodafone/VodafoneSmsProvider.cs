using System;

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
