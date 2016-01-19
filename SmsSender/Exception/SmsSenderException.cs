namespace SmsSender.Exception
{
    public class SmsSenderException : System.Exception
    {
        public SmsSenderException(string message, string providerName)
            : base(message)
        {
            ProviderName = providerName;
        }
        public SmsSenderException(string message, string providerName, System.Exception innerException)
            : base(message, innerException)
        {
            ProviderName = providerName;
        }

        public string ProviderName { get; private set; }

    }
}