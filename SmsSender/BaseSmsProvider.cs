using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SmsSender
{
    public abstract class BaseSmsProvider : ISmsProvider
    {
        public abstract string ProviderName { get; }

        public virtual string UserName { get; private set; }
        public virtual string Password { get; private set; }
        public virtual string Header { get; private set; }

        public BaseSmsProvider(string userName, string password, string header)
        {
            UserName = userName;
            Password = password;
            Header = header;
        }

        public virtual IEnumerable<SmsResponse> SendSms(params SmsRequest[] smsRequests)
        {
            string validationMessage = string.Empty;
            foreach (var smsRequest in smsRequests)
            {
                if (!ValidateSmsRequest(smsRequest, out validationMessage))
                {
                    yield return new SmsResponse { SmsStatus = SmsStatus.Fail, ProviderMessage = validationMessage };
                    continue;
                }
                yield return SendSms(smsRequest);
            }
        }

        protected virtual bool ValidateSmsRequest(SmsRequest smsRequest, out string validationMessage)
        {
            validationMessage = string.Empty;

            if (smsRequest == null)
            {
                validationMessage = string.Format("Sms Request Boş Olamaz |Provider Name {0} \n",ProviderName);
                return false;
            }
            if (string.IsNullOrWhiteSpace(smsRequest.Content))
            {
                validationMessage = string.Format("Content Boş Olamaz | Provider Name : {0} ",ProviderName);
                return false;
            }
            if (string.IsNullOrWhiteSpace(smsRequest.Number))
            {

                validationMessage = "Number Boş Olamaz";
                return false;
            }
            if (smsRequest.Content.Length < 3)
            {
                validationMessage = "Content 3 karakterden az olamaz";
                return false;
            }
            if (smsRequest.Content.Length > 160)
            {

                validationMessage = "Content 160 karakterden fazla olamaz";
                return false;
            }
            if (!Regex.IsMatch(smsRequest.Number, "905[0-9][1-9]{7}"))
            {
                validationMessage = "Telefon numarası geçerli değil..!";
                return false;
            }

            return true;
        }

        protected abstract SmsResponse SendSms(SmsRequest smsRequest);
       
    }

}
