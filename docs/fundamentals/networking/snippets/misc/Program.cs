ListenForNetworkAddressChanged();
ListenForNetworkAvailabilityChanged();

CanonicalUri();

await PingAsync();
ShowIPGlobalProperties();

foreach ((string eventSource, IReadOnlyList<string> counters) in RuntimeEventCounters.EventCounters)
{
    foreach (string counter in counters)
    {
        Console.WriteLine($"{eventSource}/{counter}");
    }
}
