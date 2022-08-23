// Ping example
public static partial class Program
{
    static void ListenForNetworkAddressChanged()
    {
        // <networkaddresschanged>
        NetworkChange.NetworkAddressChanged += OnNetworkAddressChanged;

        static void OnNetworkAddressChanged(
            object? sender, EventArgs args)
        {
            foreach ((string name, OperationalStatus status) in
                NetworkInterface.GetAllNetworkInterfaces()
                    .Select(networkInterface =>
                        (networkInterface.Name, networkInterface.OperationalStatus)))
            {
                Console.WriteLine(
                    $"{name} is {status}");
            }
        }

        Console.WriteLine(
            "Listening for address changes. Press any key to continue.");
        Console.ReadLine();

        NetworkChange.NetworkAddressChanged -= OnNetworkAddressChanged;
        // </networkaddresschanged>
    }

    static void ListenForNetworkAvailabilityChanged()
    {
        // <networkavailabilitychanged>
        NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;

        static void OnNetworkAvailabilityChanged(
            object? sender, NetworkAvailabilityEventArgs networkAvailability) =>
            Console.WriteLine($"Network is available: {networkAvailability.IsAvailable}");

        Console.WriteLine(
            "Listening changes in network availability. Press any key to continue.");
        Console.ReadLine();

        NetworkChange.NetworkAvailabilityChanged -= OnNetworkAvailabilityChanged;
        // </networkavailabilitychanged>
    }        
}
