using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AttributeOverview;

public class ValidatedContractAttribute : System.Attribute
{
}

// <Snippet1>
[Serializable]
public class SampleClass
{
    // Objects of this type can be serialized.
}
// </Snippet1>

class AttributesOverview
{
    // <Snippet2>
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    extern static void SampleMethod();
    // </Snippet2>

    // <Snippet4>
    void MethodA([In][Out] ref double x) { }
    void MethodB([Out][In] ref double x) { }
    void MethodC([In, Out] ref double x) { }
    // </Snippet4>

    // <Snippet5>
    [Conditional("DEBUG"), Conditional("TEST1")]
    void TraceMethod()
    {
        // ...
    }
    // </Snippet5>

    // <Snippet6>
    // default: applies to method
    [ValidatedContract]
    int Method1() { return 0; }

    // applies to method
    [method: ValidatedContract]
    int Method2() { return 0; }

    // applies to parameter
    int Method3([ValidatedContract] string contract) { return 0; }

    // applies to return value
    [return: ValidatedContract]
    int Method4() { return 0; }
    // </Snippet6>
}
