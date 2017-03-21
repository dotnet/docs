
' Display contents of the Providers collection property
Console.WriteLine("Providers Collection contains {0} values:", _
    healthMonitoringSection.Providers.Count)

' Display all elements.
For i As System.Int32 = 0 To healthMonitoringSection.Providers.Count - 1
    Dim providerStg As System.Configuration.ProviderSettings = _
        healthMonitoringSection.Providers(i)
    Console.WriteLine("  Item {0}: Name = '{1}' Type = '{2}'", i, _
        providerStg.Name, providerStg.Type)
Next
