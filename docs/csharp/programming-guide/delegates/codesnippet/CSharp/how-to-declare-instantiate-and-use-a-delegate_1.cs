    // Declare a delegate.
    delegate void Del(string str);

    // Declare a method with the same signature as the delegate.
    static void Notify(string name)
    {
        Console.WriteLine("Notification received for: {0}", name);
    }