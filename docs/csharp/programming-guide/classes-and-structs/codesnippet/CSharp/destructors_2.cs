    class First
    {
        ~First()
        {
            System.Diagnostics.Trace.WriteLine("First's finalizer is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Trace.WriteLine("Second's finalizer is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Trace.WriteLine("Third's finalizer is called.");
        }
    }

    class TestFinalizers
    {
        static void Main()
        {
            Third t = new Third();
        }

    }
    /* Output (to VS Output Window):
        Third's finalizer is called.
        Second's finalizer is called.
        First's finalizer is called.
    */
