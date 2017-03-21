        // Create a SoapDate object with a positive sign.
        SoapDate date = new SoapDate(DateTime.Now, -1);
        Console.WriteLine("The date is {0}.", date.ToString());