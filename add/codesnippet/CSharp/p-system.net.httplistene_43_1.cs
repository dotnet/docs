    public static void DisplayPrefixesAndState(HttpListener listener)
    {
        // List the prefixes to which the server listens.
        HttpListenerPrefixCollection prefixes = listener.Prefixes;
        if (prefixes.Count == 0)
        {
            Console.WriteLine("There are no prefixes.");
        }
        foreach(string prefix in prefixes)
        {
            Console.WriteLine(prefix);
        }
        // Show the listening state.
        if (listener.IsListening)
        {
            Console.WriteLine("The server is listening.");
        }
    }