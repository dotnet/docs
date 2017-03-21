        ' Display the current Providers property value.
        For Each providerItem As ProviderSettings In sessionStateSection.Providers()
          Console.WriteLine()
          Console.WriteLine("Provider Details:")
          Console.WriteLine("Name: {0}", providerItem.Name)
          Console.WriteLine("Type: {0}", providerItem.Type)
        Next