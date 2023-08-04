// <snippet_1>
using System.Diagnostics.CodeAnalysis;
using System;
using System.Text;
using System.Reflection;

public class MyLibrary
{
    internal static Type type;

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

// <snippet_RequiresUnreferencedCode>
public class MyLibrary2
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

// <snippet_DAA1>
public class MyLibrary3
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

public class MyLibrary4
{
    // <snippet_DAA2>
    static void UseMethods(
        // State the requirement in the UseMethods parameter.
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
    Type type)
    {
        // ...
    }
    // </snippet_DAA2>
}

public class MyLibrary5
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

public class MyLibrary6
{
    // <snippet_UMH2>
    static Type type;
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]

    static void InitializeTypeField()
    {
        MyLibrary.type = typeof(System.Tuple);
    }
    // </snippet_UMH2>
}

public class MyLibrary7
{
    // <snippet_AD1>
    class TypeCollection
    {
        Type[] types;

        // Ensure that only types with preserved constructors are stored in the array
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
        public Type this[int i]
        {
            // warning IL2063: TypeCollection.Item.get: Value returned from method
            // 'TypeCollection.Item.get' can't be statically determined and may not meet
            // 'DynamicallyAccessedMembersAttribute' requirements.
            get => types[i];
            set => types[i] = value;
        }
    }

    class TypeCreator
    {
        TypeCollection types;

        public void CreateType(int i)
        {
            types[i] = typeof(TypeWithConstructor);
            Activator.CreateInstance(types[i]); // No warning!
        }
    }

    class TypeWithConstructor
    {
    }
    // </snippet_AD1>
}

public class MyLibrary8
{
    // <snippet_AD2>
    class TypeCollection
    {
        Type[] types;

        // Ensure that only types with preserved constructors are stored in the array
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
        public Type this[int i]
        {
            [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2063",
                Justification = "The list only contains types stored through the annotated setter.")]
            get => types[i];
            set => types[i] = value;
        }
    }

    class TypeCreator
    {
        TypeCollection types;

        public void CreateType(int i)
        {
            types[i] = typeof(TypeWithConstructor);
            Activator.CreateInstance(types[i]); // No warning!
        }
    }

    class TypeWithConstructor
    {
    }
    // </snippet_AD2>
}

public class MyLibrary11
{
    // <snippet_AD3>
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2063",
        // Invalid justification and suppression: property being non-reflectively
        // used by the app doesn't guarantee that the property will be available
        // for reflection. Properties that are not visible targets of reflection
        // are already optimized away with Native AOT trimming and may be
        // optimized away for non-native deployment in the future as well.
        Justification = "*INVALID* Only need to serialize properties that are used by"
                        + "the app. *INVALID*")]
    public string Serialize(object o)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var property in o.GetType().GetProperties())
        {
            AppendProperty(sb, property, o);
        }
        return sb.ToString();
    }
    // </snippet_AD3>
    private void AppendProperty(StringBuilder sb, PropertyInfo property, object o) => throw new NotImplementedException();
}

public class MyLibrary12
{
    // <snippet_AD4>
    [DynamicDependency("Helper", "MyType", "MyAssembly")]
    static void RunHelper()
    {
        var helper = Assembly.Load("MyAssembly").GetType("MyType").GetMethod("Helper");
        helper.Invoke(null, null);
    }
}
// </snippet_AD4>
public class MyLibrary22
{
    // <snippet_AD5>
    [DynamicDependency("Method()")]
    [DynamicDependency("Method(System,Boolean,System.String)")]
    [DynamicDependency("MethodOnDifferentType()", typeof(ContainingType))]
    [DynamicDependency("MemberName")]
    [DynamicDependency("MemberOnUnreferencedAssembly", "ContainingType", "UnreferencedAssembly")]
    [DynamicDependency("MemberName", "Namespace.ContainingType.NestedType", "Assembly")]
    // generics
    [DynamicDependency("GenericMethodName``1")]
    [DynamicDependency("GenericMethod``2(``0,``1)")]
    [DynamicDependency("MethodWithGenericParameterTypes(System.Collections.Generic.List{System.String})")]
    [DynamicDependency("MethodOnGenericType(`0)", "GenericType`1", "UnreferencedAssembly")]
    [DynamicDependency("MethodOnGenericType(`0)", typeof(GenericType<>))]
    // </snippet_AD5>
    static void RunHelper()
    {
        var helper = Assembly.Load("MyAssembly").GetType("MyType").GetMethod("Helper");
        helper.Invoke(null, null);
    }
}
