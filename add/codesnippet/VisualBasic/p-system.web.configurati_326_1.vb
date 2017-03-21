
Console.WriteLine("Current Providers:")
Dim providerCtr As Integer = 0
For Each provider As ProviderSettings In profileSection.Providers
    Console.WriteLine("  {0}: Provider '{1}' of type '{2}'", ++providerCtr, _
        provider.Name, provider.Type)
Next

' Add a new provider.
profileSection.Providers.Add(new ProviderSettings("AspNetSqlProvider", "...SqlProfileProvider"))
