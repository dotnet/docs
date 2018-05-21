    void StartThread()
    {
        System.Threading.Thread t1 = new System.Threading.Thread
          (delegate()
                {
                    System.Console.Write("Hello, ");
                    System.Console.WriteLine("World!");
                });
        t1.Start();
    }