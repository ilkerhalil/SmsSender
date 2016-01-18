namespace SmsSender
{
    public class SmsResponse
    {
        public SmsStatus SmsStatus { get; set; }

        public string ProviderMessage { get; set; }


        public override string ToString()
        {
            return string.Format("SmsStatus {0} | ProviderMessage {1}", SmsStatus, ProviderMessage);
        }
    }

    public class SmsRequest
    {

        public string Number { get; set; }

        public string Content { get; set; }

        public override string ToString()
        {
            return string.Format("Number {0} | Content {1}", Number, Content);
        }
    }

    public enum SmsStatus : byte
    {
        Success = 1,
        Fail = 0
    }
}