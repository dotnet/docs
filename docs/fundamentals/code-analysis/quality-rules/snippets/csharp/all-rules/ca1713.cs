using System;

namespace ca1713
{
    //<snippet1>
    public class Session
    {
        // This code violates the rule.
        public event EventHandler? BeforeClose;
        public event EventHandler? AfterClose;

        // This code satisfies the rule.
        public event EventHandler? Closing;
        public event EventHandler? Closed;
    }
    //</snippet1>
}
