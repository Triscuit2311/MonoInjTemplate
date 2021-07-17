using System;
using System.IO;

namespace MonoInjectionTemplate
{
    class DebugLog
    {
#if DEBUG
        private StreamWriter logFile;
        private bool usingTimeStamps = true;
#endif
        public DebugLog(bool useTimeStamps)
        {
#if DEBUG
            usingTimeStamps = useTimeStamps;
            logFile = File.AppendText($"log.txt");
#endif
        }
        public void Log(string msg)
        {
#if DEBUG
            logFile.WriteLine($"{(usingTimeStamps ? $"[{DateTime.Now.ToLongTimeString()}]" : "") }\t[LOG]:{msg}");
            logFile.Flush();
#endif
        }
        public void Error(string msg)
        {
#if DEBUG
            logFile.WriteLine($"{(usingTimeStamps ? $"[{DateTime.Now.ToLongTimeString()}]" : "") }\t[ERR]:{msg}");
            logFile.Flush();
#endif
        }
        public void Info(string msg)
        {
#if DEBUG
            logFile.WriteLine($"{(usingTimeStamps ? $"[{DateTime.Now.ToLongTimeString()}]" : "") }\t[INF]:{msg}");
            logFile.Flush();
#endif
        }
        public void RawLog(string msg)
        {
#if DEBUG
            logFile.WriteLine(msg);
            logFile.Flush();
#endif
        }
    }
}
