using System.Diagnostics;

namespace ca1821
{
    //<snippet1>
    public class Class1
    {
        // Violation occurs because the finalizer is empty.
        ~Class1()
        {
        }
    }

    public class Class2
    {
        // Violation occurs because Debug.Fail is a conditional method.
        // The finalizer will contain code only if the DEBUG directive
        // symbol is present at compile time. When the DEBUG
        // directive is not present, the finalizer will still exist, but
        // it will be empty.
        ~Class2()
        {
            Debug.Fail("Finalizer called!");
        }
    }

    public class Class3
    {
#if DEBUG
        // Violation will not occur because the finalizer will exist and
        // contain code when the DEBUG directive is present. When the
        // DEBUG directive is not present, the finalizer will not exist,
        // and therefore not be empty.
        ~Class3()
        {
            Debug.Fail("Finalizer called!");
        }
#endif
    }
    //</snippet1>
}
