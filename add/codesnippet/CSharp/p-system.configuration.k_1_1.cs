        // Display each KeyValueConfigurationElement.
        foreach (KeyValueConfigurationElement keyValueElement in settings)
        {
          Console.WriteLine("Key: {0}", keyValueElement.Key);
          Console.WriteLine("Value: {0}", keyValueElement.Value);
          Console.WriteLine();
        }