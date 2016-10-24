    class First
    {
        ~First()
        {
            System.Diagnostics.Trace.WriteLine("First's destructor is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Trace.WriteLine("Second's destructor is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Trace.WriteLine("Third's destructor is called.");
        }
    }

    class TestDestructors
    {
        static void Main()
        {
            Third t = new Third();
        }

    }
    /* Output (to VS Output Window):
        Third's destructor is called.
        Second's destructor is called.
        First's destructor is called.
    */