// Ping example
public static partial class Program
{
    // <networkaddresschanged>
    static void RegisterNetworkAddressChanged() =>
        NetworkChange.NetworkAddressChanged += OnNetworkAddressChanged;

    static void OnNetworkAddressChanged(
        object? sender, EventArgs args)
    {
        foreach (var (name, status) in
            NetworkInterface.GetAllNetworkInterfaces()
                .Select(networkInterface =>
                    (networkInterface.Name, networkInterface.OperationalStatus)))
        {
            Console.WriteLine(
                $"{name} is {status}");
        }
    }

    static void UnregisterNetworkAddressChanged() =>
        NetworkChange.NetworkAddressChanged += OnNetworkAddressChanged;
    // </networkaddresschanged>

    // <networkavailabilitychanged>
    static void RegisterNetworkAvailabilityChanged() =>
        NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;

    static void OnNetworkAvailabilityChanged(
        object? sender, NetworkAvailabilityEventArgs args) =>
        Console.WriteLine($"Network is available: {args.IsAvailable}");

    static void UnregisterNetworkAvailabilityChanged() =>
        NetworkChange.NetworkAvailabilityChanged -= OnNetworkAvailabilityChanged;
    // </networkavailabilitychanged>
}
