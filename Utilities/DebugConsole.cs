using System.IO;

namespace MonoInjectionTemplate
{
    public class DebugConsole
    {
#if DEBUG
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool AllocConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        private readonly StreamWriter _stdOutWriter;
        private readonly StreamReader _stdInReader;
#endif

        public DebugConsole()
        {
#if DEBUG
            AllocConsole();
            Stream stdout = System.Console.OpenStandardOutput();
            Stream stdin = System.Console.OpenStandardInput();
            _stdOutWriter = new StreamWriter(stdout);
            _stdInReader = new StreamReader(stdin);
            _stdOutWriter.AutoFlush = true;

            AttachConsole(-1);
            WriteLine("Console Initialized");
#endif
        }

        public void Release()
        {
#if DEBUG
            FreeConsole();
#endif
        }

        public string GetLine()
        {
#if DEBUG
            return _stdInReader.ReadLine();
#endif
        }
        public void WriteLine(string line)
        {
#if DEBUG
            _stdOutWriter.WriteLine(line);
            System.Console.WriteLine(line);
#endif
        }

    }
}
