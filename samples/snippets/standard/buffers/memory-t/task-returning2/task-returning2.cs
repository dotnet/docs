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
        return Task.Run(() => {
            StreamWriter sw = File.AppendText(@".\input-numbers.dat");
            sw.WriteLine(message);
            sw.Flush();
        });
    }
    // </Snippet1>

    // user code
    public static void Main()
    {
        using (var owner = MemoryPool<char>.Shared.Rent())
        {
            var memory = owner.Memory;
            var span = memory.Span;
            while (true)
            {
                int value = Int32.Parse(Console.ReadLine());
                if (value < 0)
                    return;

                int numCharsWritten = ToBuffer(value, span);
                Log(memory.Slice(0, numCharsWritten));
            }
        }
    }

    private static int ToBuffer(int value, Span<char> span)
    {
        string strValue = value.ToString();
        int length = strValue.Length;
        strValue.AsSpan().CopyTo(span.Slice(0, length));
        return length;
    }
}
