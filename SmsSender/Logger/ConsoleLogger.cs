using System;

namespace SmsSender.Logger
{
    public class ConsoleLogger : BaseLogger
    {

        public override void Write(LogSeverity logSeverity, string message)
        {
            switch (logSeverity)
            {
                case LogSeverity.Error:
                    Console.WriteLine($"{logSeverity} : {message}");
                    break;
                case LogSeverity.Warn:
                    Console.WriteLine($"{logSeverity} : {message}");
                    break;
                case LogSeverity.Info:
                    Console.WriteLine($"{logSeverity} : {message}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logSeverity), logSeverity, null);
            }
        }
    }
}