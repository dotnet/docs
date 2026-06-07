using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        bool isChildProcess = args.Length > 0 && args[0] == "child";
        if (!isChildProcess)
        {
            var psi = new ProcessStartInfo
            {
                FileName = Environment.ProcessPath,
                Arguments = "child",
                CreateNewProcessGroup = true,
            };

            using Process process = Process.Start(psi)!;
            Thread.Sleep(5_000);

            GenerateConsoleCtrlEvent(CTRL_BREAK_EVENT, (uint)process.Id);
            process.WaitForExit();

            Console.WriteLine("Child process terminated gracefully, continue with the parent process logic if needed.");
        }
        else
        {
            // CREATE_NEW_PROCESS_GROUP disables CTRL+C handling in the new process group.
            // CTRL+BREAK is not affected, so you don't need to re-enable it with SetConsoleCtrlHandler.
            // If you use CTRL+C instead, re-enable handling by calling SetConsoleCtrlHandler(NULL, FALSE).
            // see https://learn.microsoft.com/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessw#remarks

            Console.WriteLine("Greetings from the child process!  I need to be gracefully terminated, send me a signal!");

            bool stop = false;

            var registration = PosixSignalRegistration.Create(PosixSignal.SIGQUIT, ctx =>
            {
                stop = true;
                ctx.Cancel = true;
                Console.WriteLine("Received CTRL+BREAK, stopping...");
            });

            StreamWriter sw = File.AppendText("log.txt");
            int i = 0;
            while (!stop)
            {
                Thread.Sleep(1000);
                sw.WriteLine($"{++i}");
                Console.WriteLine($"Logging {i}...");
            }

            // Clean up
            sw.Dispose();
            registration.Dispose();

            Console.WriteLine("Thanks for not killing me!");
        }
    }

    private const int CTRL_C_EVENT = 0;
    private const int CTRL_BREAK_EVENT = 1;

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetConsoleCtrlHandler(IntPtr handler, [MarshalAs(UnmanagedType.Bool)] bool Add);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GenerateConsoleCtrlEvent(uint dwCtrlEvent, uint dwProcessGroupId);
}