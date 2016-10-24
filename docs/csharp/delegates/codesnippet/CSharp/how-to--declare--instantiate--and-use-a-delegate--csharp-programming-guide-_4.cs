        // Instantiate Del by using an anonymous method.
        Del del3 = delegate(string name)
            { Console.WriteLine("Notification received for: {0}", name); };