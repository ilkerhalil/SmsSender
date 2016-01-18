using System.Collections.Generic;

namespace SmsSender
{
    public interface ISmsProvider
    {
        string Header { get; }
        string Password { get; }
        string UserName { get; }
        string ProviderName { get; }
        IEnumerable<SmsResponse> SendSms(params SmsRequest[] smsRequests);
    }
}