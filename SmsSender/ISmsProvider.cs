using System.Collections.Generic;

namespace SmsSender
{
    public interface ISmsProvider
    {
        string Header { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
        string ProviderName { get; }
        IEnumerable<SmsResponse> SendSms(params SmsRequest[] smsRequests);
    }
}