#define RequiresUnreferencedCode // FIRST RequiresUnreferencedCode
#if NEVER
#elif FIRST
// <snippet_1>
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    public static void Method()
    {
        // warning IL2026 : MyLibrary.Method: Using method 'MyLibrary.DynamicBehavior'
        //  which has 'RequiresUnreferencedCodeAttribute' can break functionality
        // when trimming application code.
        DynamicBehavior();
    }

    [RequiresUnreferencedCode(
        "DynamicBehavior is incompatible with trimming.")]
    static void DynamicBehavior()
    {
    }
}
// </snippet_1>
#elif RequiresUnreferencedCode
// <snippet_RequiresUnreferencedCode>
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    [RequiresUnreferencedCode("Calls DynamicBehavior.")]
    public static void Method()
    {
        DynamicBehavior();
    }

    [RequiresUnreferencedCode(
        "DynamicBehavior is incompatible with trimming.")]
    static void DynamicBehavior()
    {
    }
}
// </snippet_RequiresUnreferencedCode>
#endif
