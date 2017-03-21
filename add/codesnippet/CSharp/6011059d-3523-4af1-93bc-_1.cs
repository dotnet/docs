        // Serialize a TimeSpan object as an XSD duration string.
        // This object represents a time span of 399 days, 12 hours,
        // 35 minutes, 20 seconds, and 10 milliseconds.
        TimeSpan duration = new TimeSpan(399, 12, 35, 20, 10);
        Console.WriteLine("The duration in XSD format is {0}.",
            SoapDuration.ToString(duration));