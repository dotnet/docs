using System;

namespace ca2201
{
    //<snippet1>
    public class ExampleClass
    {
        public void BadMethod()
        {
            // This code violates the rule.
            throw new Exception();
            throw new NullReferenceException();
            throw new IndexOutOfRangeException();
            // ...
        }

        public void GoodMethod()
        {
            // This code satisfies the rule.
            throw new ArgumentException();
            throw new ArgumentNullException();
            throw new InvalidOperationException();
            // ...
        }

        // A minimal implementation of inheritance from Exception
        public class CustomException : Exception { }

        public void AnotherGoodMethod()
        {
            // Or create your own type that derives from Exception
            // This code satisfies the rule too.
            throw new CustomException();
        }
    }
    //</snippet1>
}
