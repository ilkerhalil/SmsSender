namespace SmsSender.Logger
{
    public interface ILogger
    {
        void Write(LogSeverity logSeverity, string message);
    }
}
