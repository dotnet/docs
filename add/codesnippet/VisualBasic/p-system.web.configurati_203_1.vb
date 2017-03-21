        ' Display elements of the TrustLevels collection property.
        For i As Integer = 0 To (configSection.TrustLevels.Count - 1)
          Console.WriteLine()
          Console.WriteLine("TrustLevel {0}:", i)
          Console.WriteLine("Name: {0}", _
           configSection.TrustLevels.Get(i).Name)
          Console.WriteLine("Type: {0}", _
           configSection.TrustLevels.Get(i).PolicyFile)
        Next i

        ' Add a TrustLevel element to the configuration file.
        configSection.TrustLevels.Add(New TrustLevel("myTrust", "mytrust.config"))