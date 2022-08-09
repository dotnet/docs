static class HttpResponseMessageExtensions
{
    internal static void WriteToConsole(this HttpResponseMessage response)
    {
        if (response is null)
        {
            return;
        }

        var request = response.RequestMessage;
        WriteLine($"{request?.RequestUri}");
        Write($"{request?.Method} ");
        WriteLine($"HTTP/{request?.Version}");        
    }
}
