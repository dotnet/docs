namespace ConsoleDI.IEnumerableExample;

public sealed class ConsoleMessageWriter : IMessageWriter
{
    public void Write(string message) =>
        Console.WriteLine(
            $"ConsoleMessageWriter.Write(message: \"{message}\")");
}
