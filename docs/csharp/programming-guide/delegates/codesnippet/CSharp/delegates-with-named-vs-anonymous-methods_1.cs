        // Declare a delegate:
        delegate void Del(int x);

        // Define a named method:
        void DoWork(int k) { /* ... */ }

        // Instantiate the delegate using the method as a parameter:
        Del d = obj.DoWork;