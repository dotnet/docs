class Program
{
    static async Task Main() =>
        Console.WriteLine($"learn.microsoft.com/dotnet content length = {await AccessWeb.Example.GetUrlContentLengthAsync()}");
}

class AccessWeb
{
    public static AccessWeb Example = new AccessWeb();

    // <ControlFlow>
    public async Task<int> GetUrlContentLengthAsync()
    {
        using var client = new HttpClient();

        Task<string> getStringTask =
            client.GetStringAsync("https://learn.microsoft.com/dotnet");

        DoIndependentWork();

        string contents = await getStringTask;

        return contents.Length;
    }

    void DoIndependentWork()
    {
        Console.WriteLine("Working...");
    }
    // </ControlFlow>
}
