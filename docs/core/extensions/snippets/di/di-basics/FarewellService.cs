public class FarewellService(IConsole console)
{
    public string SayGoodbye(string name)
    {
        var farewell = $"Goodbye, {name}!";

        console.WriteLine(farewell);

        return farewell;
    }
}
