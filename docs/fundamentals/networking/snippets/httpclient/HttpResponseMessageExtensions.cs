static class HttpResponseMessageExtensions
{
    internal static void WriteRequestToConsole(this HttpResponseMessage response)
    {
        if (response is null)
        {
            return;
        }

        var request = response.RequestMessage;
        Write($"{request?.Method} ");
        Write($"{request?.RequestUri} ");
        WriteLine($"HTTP/{request?.Version}");        
    }
}
