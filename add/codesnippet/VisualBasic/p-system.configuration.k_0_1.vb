        ' Display each KeyValueConfigurationElement.
        Dim keyValueElement As KeyValueConfigurationElement
        For Each keyValueElement In settings
          Console.WriteLine("Key: {0}", keyValueElement.Key)
          Console.WriteLine("Value: {0}", keyValueElement.Value)
          Console.WriteLine()
        Next