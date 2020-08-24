using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var stream = new StreamReader("lorem-ipsum.txt");
        using var cts = new CancellationTokenSource();

        var reader = PipeReader.Create(stream.BaseStream, new StreamPipeReaderOptions());
        var writer = PipeWriter.Create(Console.OpenStandardOutput(), new StreamPipeWriterOptions());

        var processMessagesTask = ProcessMessagesAsync(reader, writer, cts.Token);

        WriteUserCancellationPrompt();

        var cancelProcessingTask = Task.Run(() =>
        {
            while (char.ToUpperInvariant(Console.ReadKey().KeyChar) != 'C')
            {
                WriteUserCancellationPrompt();
            }

            cts.Cancel();

            reader.CancelPendingRead();
            writer.CancelPendingFlush();
        });

        await Task.WhenAny(new[] { cancelProcessingTask, processMessagesTask });

        Console.WriteLine(
            $"Processing {(cts.IsCancellationRequested? "cancelled" : "completed")}.");
    }

    static void WriteUserCancellationPrompt() =>
        Console.WriteLine("Press 'C' to cancel processing...\n");

    static async Task ProcessMessagesAsync(
        PipeReader reader,
        PipeWriter writer,
        CancellationToken cancellationToken)
    {
        try
        {
            while (true)
            {
                ReadResult readResult = await reader.ReadAsync(cancellationToken);
                ReadOnlySequence<byte> buffer = readResult.Buffer;

                try
                {
                    if (readResult.IsCanceled)
                    {
                        break;
                    }

                    while (TryParseMessage(ref buffer, out string message))
                    {
                        FlushResult flushResult = await WriteMessagesAsync(writer, message, cancellationToken);
                        if (flushResult.IsCanceled || flushResult.IsCompleted)
                        {
                            break;
                        }
                    }

                    if (readResult.IsCompleted)
                    {
                        if (buffer.Length > 0)
                        {
                            throw new InvalidDataException("Incomplete message.");
                        }
                        break;
                    }
                }
                finally
                {
                    reader.AdvanceTo(buffer.Start, buffer.End);
                }
            }
        }
        finally
        {
            await reader.CompleteAsync();
        }
    }

    static bool TryParseMessage(
        ref ReadOnlySequence<byte> buffer,
        out string message) => 
        (message = Encoding.ASCII.GetString(buffer)) != null;

    static ValueTask<FlushResult> WriteMessagesAsync(
        PipeWriter writer,
        string message,
        CancellationToken cancellationToken) =>
        writer.WriteAsync(Encoding.ASCII.GetBytes(message), cancellationToken);
}
