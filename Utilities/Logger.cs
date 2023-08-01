using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;

namespace SeleniumNUnitFramework.Utilities
{
	public class Logger : IDisposable
	{
        private StreamWriter logWriter;
        private readonly string logFilePath;

        public Logger(string logFolderPath, string logFileName)
        {
            string logDirectory = Path.Combine(logFolderPath, "Logs");
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            logFilePath = Path.Combine(logDirectory, logFileName + ".log");
            logWriter = new StreamWriter(logFilePath, append: true);
        }

        public void LogInfo(string message)
        {
            WriteLog("INFO", message);
        }

        public void LogError(string message)
        {
            WriteLog("ERROR", message);
        }

        public void LogBreakers()
        {
            logWriter.WriteLine("****************************************************************************");
            logWriter.Flush();
        }

        private void WriteLog(string logLevel, string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            logWriter.WriteLine($"{timestamp} [{logLevel}] - {message}");
            logWriter.Flush();
        }

        public void Dispose()
        {
            if (logWriter != null)
            {
                logWriter.Dispose();
                logWriter = null;
            }
        }
    }
}

