using System;

namespace ca2214
{
    //<snippet1>
    public class BadlyConstructedType
    {
        protected string initialized = "No";

        public BadlyConstructedType()
        {
            Console.WriteLine("Calling base ctor.");
            // Violates rule: DoNotCallOverridableMethodsInConstructors.
            DoSomething();
        }
        // This will be overridden in the derived type.
        public virtual void DoSomething()
        {
            Console.WriteLine("Base DoSomething");
        }
    }

    public class DerivedType : BadlyConstructedType
    {
        public DerivedType()
        {
            Console.WriteLine("Calling derived ctor.");
            initialized = "Yes";
        }
        public override void DoSomething()
        {
            Console.WriteLine("Derived DoSomething is called - initialized ? {0}", initialized);
        }
    }

    public class TestBadlyConstructedType
    {
        public static void Main2214()
        {
            DerivedType derivedInstance = new DerivedType();
        }
    }
    //</snippet1>
}
