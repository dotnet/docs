public static partial class Program
{
    // <ipglobalprops>
    static async Task IPGlobalPropertiesAsync()
    {
        var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
        var unicastIPs = await ipGlobalProperties.GetUnicastAddressesAsync();
        
        foreach (var unicastIP in
            unicastIPs.Where(ip => ip.Address.IsIPv6Teredo))
        {
            Console.WriteLine($"IPv6 Teredo: {unicastIP.Address}");
        }
    }
    // </ipglobalprops>
}
