using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public AveaSmsProvider(string userName, string password, string header)
            : base(userName, password, header)
        {

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
