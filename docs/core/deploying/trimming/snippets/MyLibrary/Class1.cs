#define  UMH2 // FIRST RequiresUnreferencedCode DAA1 DAA2 UMH UMH2
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
#elif DAA1
// <snippet_DAA1>
using System;

public class MyLibrary
{
    static void UseMethods(Type type)
    {
        // warning IL2070: MyLibrary.UseMethods(Type): 'this' argument does not satisfy
        // 'DynamicallyAccessedMemberTypes.PublicMethods' in call to
        // 'System.Type.GetMethods()'.
        // The parameter 't' of method 'MyLibrary.UseMethods(Type)' doesn't have
        // matching annotations.
        foreach (var method in type.GetMethods())
        {
            // ...
        }
    }
}
// </snippet_DAA1>
#elif DAA2
// <snippet_DAA2>
using System;
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    static void UseMethods(
        // State the requirement in the UseMethods parameter.
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
    Type type)
    {
        // ...
    }
}
// </snippet_DAA2>
#elif UMH
using System;
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    private static void UseMethods(object type) => throw new NotImplementedException();

    // <snippet_UMH>

    static Type type;
    static void UseMethodsHelper()
    {
        // warning IL2077: MyLibrary.UseMethodsHelper(Type): 'type' argument does not satisfy
        // 'DynamicallyAccessedMemberTypes.PublicMethods' in call to
        // 'MyLibrary.UseMethods(Type)'.
        // The field 'System.Type MyLibrary::type' does not have matching annotations.
        UseMethods(type);
    }
    // </snippet_UMH>
}

#elif UMH2
using System;
using System.Diagnostics.CodeAnalysis;

public class MyLibrary
{
    // <snippet_UMH2>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
    static Type type;

    static void InitializeTypeField()
    {
        MyLibrary.type = typeof(System.Tuple);
    }
    // </snippet_UMH2>
}

#endif
