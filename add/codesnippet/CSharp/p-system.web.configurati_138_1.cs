        // Display BatchTimeout property.
        Console.WriteLine("BatchTimeout: {0}",
          configSection.BatchTimeout);

        // Set BatchTimeout property.
        configSection.BatchTimeout = TimeSpan.FromMinutes(15);