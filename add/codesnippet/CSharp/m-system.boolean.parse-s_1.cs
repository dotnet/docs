        bool val;
        string input;

        input = bool.TrueString;
        val = bool.Parse(input);
        Console.WriteLine("'{0}' parsed as {1}", input, val);
        // The example displays the following output:
        //       'True' parsed as True        