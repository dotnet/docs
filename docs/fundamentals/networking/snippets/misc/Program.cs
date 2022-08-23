RegisterNetworkAddressChanged();
RegisterNetworkAvailabilityChanged();

try
{
    DangerousUri();
    CanonicalUri();

    await PingAsync();
    await IPGlobalPropertiesAsync();
}
finally
{
    UnregisterNetworkAddressChanged();
    UnregisterNetworkAvailabilityChanged();
}
