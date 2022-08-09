static class HttpResponseMessageExtensions
{
    internal static void WriteToConsole(this HttpResponseMessage response)
    {
        if (response is null)
        {
            return;
        }

        var request = response.RequestMessage;
        Console.WriteLine($"🔗 {request?.RequestUri}");
        Console.Write($"✅ {request?.Method} ");
        Console.WriteLine($"HTTP/{request?.Version}");        
    }
}
