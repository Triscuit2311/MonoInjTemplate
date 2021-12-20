using System.IO;

namespace MonoInjectionTemplate.Utilities
{
    public static class ConsoleBase
    {
        
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool AllocConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        private static readonly StreamWriter StdOutWriter;
        private static StreamReader _stdInReader;

        static ConsoleBase()
        {
            AllocConsole();
            StdOutWriter = new StreamWriter(System.Console.OpenStandardOutput());
            _stdInReader = new StreamReader(System.Console.OpenStandardInput());
            StdOutWriter.AutoFlush = true;

            AttachConsole(-1);
            WriteLine("Console Initialized");
        }
        

        public static void Release()
        {
            FreeConsole();
        }

        public static string GetLine()
        {
            return _stdInReader.ReadLine();
        }
        public static void WriteLine(string line)
        {
            StdOutWriter.WriteLine(line);
            System.Console.WriteLine(line);
        }

        public static void Write(string msg)
        {
            StdOutWriter.Write(msg);
            System.Console.Write(msg);
        }

    }
}