using System;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;

public class Example
{
    // <Snippet1>
    // An acceptable implementation.
    static Task Log(ReadOnlyMemory<char> message)
    {
        // Run in the background so that we don't block the main thread while performing IO.
        return Task.Run(() =>
        {
            StreamWriter sw = File.AppendText(@".\input-numbers.dat");
            sw.WriteLine(message);
            sw.Flush();
        });
    }
    // </Snippet1>
}
