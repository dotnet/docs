    class SimpleClass
    {
        // Static variable that must be initialized at run time.
        static readonly long baseline;

        // Static constructor is called at most one time, before any
        // instance constructor is invoked or member is accessed.
        static SimpleClass()
        {
            baseline = DateTime.Now.Ticks;
        }
    }