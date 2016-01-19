using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SmsSender
{
    public abstract class BaseSmsProvider : ISmsProvider
    {
        public abstract string ProviderName { get; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Header { get; set; }
        protected abstract void ProviderInit();

        public virtual IEnumerable<SmsResponse> SendSms(params SmsRequest[] smsRequests)
        {
            foreach (var smsRequest in smsRequests)
            {
                string validationMessage;
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
                validationMessage = string.Format("Sms Request Boş Olamaz | Provider Name {0} \n", ProviderName);
                return false;
            }
            if (string.IsNullOrWhiteSpace(smsRequest.Content))
            {
                validationMessage = string.Format("Content Boş Olamaz | Provider Name : {0} ", ProviderName);
                return false;
            }
            if (string.IsNullOrWhiteSpace(smsRequest.Number))
            {

                validationMessage = string.Format("Number Boş Olamaz | Provider Name : {0} ", ProviderName);
                return false;
            }
            if (smsRequest.Content.Length < 3)
            {
                validationMessage = string.Format("Content 3 karakterden az olamaz | Provider Name : {0} ", ProviderName);
                return false;
            }
            if (smsRequest.Content.Length > 160)
            {

                validationMessage = string.Format("Content 160 karakterden fazla olamaz | Provider Name : {0} ", ProviderName);
                return false;
            }
            if (!Regex.IsMatch(smsRequest.Number, "905[0-9][1-9]{7}"))
            {
                validationMessage = string.Format("Telefon numarası geçerli değil..! | Provider Name : {0} ", ProviderName);
                return false;
            }

            return true;
        }

        protected abstract SmsResponse SendSms(SmsRequest smsRequest);

    }

}
