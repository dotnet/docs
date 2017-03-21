
// Display contents of the Providers collection property
Console.WriteLine("Providers Collection contains {0} values:", 
    healthMonitoringSection.Providers.Count);

// Display all elements.
for (System.Int32 i = 0; i < healthMonitoringSection.Providers.Count; i++)
{
    System.Configuration.ProviderSettings provider = 
        healthMonitoringSection.Providers[i];
    Console.WriteLine("  Item {0}: Name = '{1}' Type = '{2}'", i, 
        provider.Name, provider.Type);
}
