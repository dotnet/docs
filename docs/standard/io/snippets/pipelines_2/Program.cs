using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var stream = File.OpenRead("lorem-ipsum.txt");

        var reader = PipeReader.Create(stream);
        var writer = PipeWriter.Create(
            Console.OpenStandardOutput(), 
            new StreamPipeWriterOptions(leaveOpen: true));

        WriteUserCancellationPrompt();

        var processMessagesTask = ProcessMessagesAsync(reader, writer);
        var userCanceled = false;
        var cancelProcessingTask = Task.Run(() =>
        {
            while (char.ToUpperInvariant(Console.ReadKey().KeyChar) != 'C')
            {
                WriteUserCancellationPrompt();
            }

            userCanceled = true;

            // No exceptions thrown
            reader.CancelPendingRead();
            writer.CancelPendingFlush();
        });

        await Task.WhenAny(cancelProcessingTask, processMessagesTask);

        Console.WriteLine(
            $"\n\nProcessing {(userCanceled ? "cancelled" : "completed")}.\n");
    }

    static void WriteUserCancellationPrompt() =>
        Console.WriteLine("Press 'C' to cancel processing...\n");

    static async Task ProcessMessagesAsync(
        PipeReader reader,
        PipeWriter writer)
    {
        try
        {
            while (true)
            {
                ReadResult readResult = await reader.ReadAsync();
                ReadOnlySequence<byte> buffer = readResult.Buffer;

                try
                {
                    if (readResult.IsCanceled)
                    {
                        break;
                    }

                    if (TryParseLines(ref buffer, out string message))
                    {
                        FlushResult flushResult =
                            await WriteMessagesAsync(writer, message);

                        if (flushResult.IsCanceled || flushResult.IsCompleted)
                        {
                            break;
                        }
                    }

                    if (readResult.IsCompleted)
                    {
                        if (!buffer.IsEmpty)
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
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }
        finally
        {
            await reader.CompleteAsync();
            await writer.CompleteAsync();
        }
    }

    static bool TryParseLines(
        ref ReadOnlySequence<byte> buffer,
        out string message)
    {
        SequencePosition? position;
        StringBuilder outputMessage = new();

        while(true)
        {
            position = buffer.PositionOf((byte)'\n');

            if (!position.HasValue)
                break;

            outputMessage.Append(Encoding.ASCII.GetString(buffer.Slice(buffer.Start, position.Value)))
                        .AppendLine();

            buffer = buffer.Slice(buffer.GetPosition(1, position.Value));
        };

        message = outputMessage.ToString();
        return message.Length != 0;
    }

    static ValueTask<FlushResult> WriteMessagesAsync(
        PipeWriter writer,
        string message) =>
        writer.WriteAsync(Encoding.ASCII.GetBytes(message));
}
