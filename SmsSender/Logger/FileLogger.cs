using System;
using System.IO;

namespace SmsSender.Logger
{
    public class FileLogger : BaseLogger
    {
        private readonly string _fileName;

        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }


        public override void Write(LogSeverity logSeverity, string message)
        {
            switch (logSeverity)
            {
                case LogSeverity.Error:
                    File.AppendAllText(_fileName, $"{logSeverity} : {message}");
                    break;
                case LogSeverity.Warn:
                    File.AppendAllText(_fileName, $"{logSeverity} : {message}");
                    break;
                case LogSeverity.Info:
                    File.AppendAllText(_fileName, $"{logSeverity} : {message}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logSeverity), logSeverity, null);
            }
        }
    }
}