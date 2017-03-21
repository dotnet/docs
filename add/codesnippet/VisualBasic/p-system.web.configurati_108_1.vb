        ' Display BatchTimeout property.
        Console.WriteLine("BatchTimeout: {0}", _
         configSection.BatchTimeout)

        ' Set BatchTimeout property.
        configSection.BatchTimeout = TimeSpan.FromMinutes(15)