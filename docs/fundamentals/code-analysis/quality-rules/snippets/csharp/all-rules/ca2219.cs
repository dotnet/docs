using System;

namespace ca2219
{
    //<snippet1>
    public class ExampleClass
    {
        public void Process()
        {
            try
            {
                // ...
            }
            finally
            {
                // This code violates the rule.
                throw new Exception();
            }
        }
    }
    //</snippet1>
}
