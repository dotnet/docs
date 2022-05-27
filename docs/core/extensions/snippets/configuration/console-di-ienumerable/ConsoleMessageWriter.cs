namespace ConsoleDI.IEnumerableExample;

public class ConsoleMessageWriter : IMessageWriter
{
    public void Write(string message) =>
        Console.WriteLine(
            $"ConsoleMessageWriter.Write(message: \"{message}\")");
}
