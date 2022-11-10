using System.Diagnostics.Tracing;

using var listener = new SystemDotNetListener();
using var client = new HttpClient();
string? json = await client.GetStringAsync("https://httpbin.org/get");

sealed file class SystemDotNetListener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource.Name.Contains("System.Net"))
        {
            EnableEvents(eventSource, EventLevel.Verbose);
        }
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        Console.WriteLine($"{DateTime.UtcNow:ss:fff} {eventData.EventSource.Name}/{eventData.EventName}: " +
            string.Join(' ', eventData.PayloadNames!.Zip(eventData.Payload!)
                .Select(pair => $"{pair.First}={(pair.Second is byte[] buffer ? Convert.ToHexString(buffer) : $"{pair.Second}")}")));
    }
}
