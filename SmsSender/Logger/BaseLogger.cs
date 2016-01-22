using System.Text;

namespace SmsSender.Logger
{
    public abstract class BaseLogger : ILogger
    {
        public abstract void Write(LogSeverity logSeverity, string message);
    }
}