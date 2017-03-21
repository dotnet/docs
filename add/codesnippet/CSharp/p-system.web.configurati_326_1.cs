
// Display all current Providers.
Console.WriteLine("Current Providers:");
int providerCtr = 0;
foreach (ProviderSettings provider in profileSection.Providers)
{
    Console.WriteLine("  {0}: Provider '{1}' of type '{2}'", ++providerCtr, 
        provider.Name, provider.Type);
}

// Add a new provider.
profileSection.Providers.Add(new ProviderSettings("AspNetSqlProvider", "...SqlProfileProvider"));
