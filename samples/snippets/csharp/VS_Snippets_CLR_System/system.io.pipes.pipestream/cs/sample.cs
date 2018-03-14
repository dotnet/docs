//<snippet1>
using System;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

class PipeStreamExample
{
    private static byte[] matchSign = {9, 0, 9, 0};

    public static void Main()
    {
        string[] args = Environment.GetCommandLineArgs();
        if (args.Length < 2)
        {
            Process clientProcess = new Process();

            clientProcess.StartInfo.FileName = Environment.CommandLine;

            using (AnonymousPipeServerStream pipeServer =
                new AnonymousPipeServerStream(PipeDirection.In,
                HandleInheritability.Inheritable))
            {
                // Pass the client process a handle to the server.
                clientProcess.StartInfo.Arguments = pipeServer.GetClientHandleAsString();
                clientProcess.StartInfo.UseShellExecute = false;
                Console.WriteLine("[SERVER] Starting client process...");
                clientProcess.Start();

                pipeServer.DisposeLocalCopyOfClientHandle();

                try
                {
                    if (WaitForClientSign(pipeServer))
                    {
                        Console.WriteLine("[SERVER] Valid sign code received!");
                    }
                    else
                    {
                        Console.WriteLine("[SERVER] Invalid sign code received!");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("[SERVER] Error: {0}", e.Message);
                }
            }
            clientProcess.WaitForExit();
            clientProcess.Close();
            Console.WriteLine("[SERVER] Client quit. Server terminating.");
        }
        else
        {
            using (PipeStream pipeClient = new AnonymousPipeClientStream(PipeDirection.Out, args[1]))
            {
                try
                {
                    Console.WriteLine("[CLIENT] Sending sign code...");
                    SendClientSign(pipeClient);
                }
                catch (IOException e)
                {
                     Console.WriteLine("[CLIENT] Error: {0}", e.Message);
                }
            }
            Console.WriteLine("[CLIENT] Terminating.");
        }
    }

    //<snippet2>
    private static bool WaitForClientSign(PipeStream inStream)
    {
        byte[] inSign = new byte[matchSign.Length];
        int len = inStream.Read(inSign, 0, matchSign.Length);
        bool valid = len == matchSign.Length;

        while (valid && len-- > 0)
        {
            valid = valid && (matchSign[len] == inSign[len]);
        }
        return valid;
    }
    //</snippet2>

    private static void SendClientSign(PipeStream outStream)
    {
        outStream.Write(matchSign, 0, matchSign.Length);
    }
}
//</snippet1>
