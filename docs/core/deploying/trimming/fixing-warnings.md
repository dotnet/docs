---
title: Introduction to trim warnings
description: Learn about why warnings might be produced when publishing a trimmed application, how to address them, and how to make the application "trim compatible."
author: agocke
ms.author: angocke
ms.date: 10/30/2023
---
# Introduction to trim warnings

Conceptually, [trimming](trim-self-contained.md) is simple: when you publish an application, the .NET SDK analyzes the entire application and removes all unused code. However, it can be difficult to determine what is unused, or more precisely, what is used.

To prevent changes in behavior when trimming applications, the .NET SDK provides static analysis of trim compatibility through **trim warnings**. The trimmer produces trim warnings when it finds code that might not be compatible with trimming. Code that's not trim-compatible can produce behavioral changes, or even crashes, in an application after it has been trimmed.  Ideally, all applications that use trimming shouldn't produce any trim warnings. If there are any trim warnings, the app should be thoroughly tested after trimming to ensure that there are no behavior changes.

This article helps you understand why some patterns produce trim warnings, and how these warnings can be addressed.

## Examples of trim warnings

For most C# code, it's straightforward to determine what code is used and what code is unused&mdash;the trimmer can walk method calls, field and property references, and so on, and determine what code is accessed. Unfortunately, some features, like reflection, present a significant problem. Consider the following code:

```csharp
string s = Console.ReadLine();
Type type = Type.GetType(s);
foreach (var m in type.GetMethods())
{
    Console.WriteLine(m.Name);
}
```

In this example, <xref:System.Type.GetType> dynamically requests a type with an unknown name, and then prints the names of all of its methods. Because there's no way to know at publish-time what type name is going to be used, there's no way for the trimmer to know which type to preserve in the output. It's likely that this code could have worked before trimming (as long as the input is something known to exist in the target framework), but would probably produce a null reference exception after trimming, as `Type.GetType` returns null when the type isn't found.

In this case, the trimmer issues a warning on the call to `Type.GetType`, indicating that it can't determine which type is going to be used by the application.

## Reacting to trim warnings

Trim warnings are meant to bring predictability to trimming. There are two large categories of warnings that you'll likely see:

1. Functionality isn't compatible with trimming
2. Functionality has certain requirements on the input to be trim compatible

### Functionality incompatible with trimming

These are typically methods that either don't work at all, or might be broken in some cases if they're used in a trimmed application. A good example is the `Type.GetType` method from the previous example. In a trimmed app it might work, but there's no guarantee. Such APIs are marked with <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute>.

<xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute> is simple and broad: it's an attribute that means the member has been annotated incompatible with trimming. This attribute is used when code is fundamentally not trim compatible, or the trim dependency is too complex to explain to the trimmer. This would often be true for methods that dynamically load code for example via <xref:System.Reflection.Assembly.LoadFrom(System.String)>, enumerate or search through all types in an application or assembly for example via <xref:System.Type.GetType>, use the C# [`dynamic`](../../../csharp/language-reference/builtin-types/reference-types.md#the-dynamic-type) keyword, or use other runtime code generation technologies. An example would be:

```csharp
[RequiresUnreferencedCode("This functionality is not compatible with trimming. Use 'MethodFriendlyToTrimming' instead")]
void MethodWithAssemblyLoad()
{
    ...
    Assembly.LoadFrom(...);
    ...
}

void TestMethod()
{
    // IL2026: Using method 'MethodWithAssemblyLoad' which has 'RequiresUnreferencedCodeAttribute'
    // can break functionality when trimming application code. This functionality is not compatible with trimming. Use 'MethodFriendlyToTrimming' instead.
    MethodWithAssemblyLoad();
}
```

There aren't many workarounds for `RequiresUnreferencedCode`. The best fix is to avoid calling the method at all when trimming and use something else that's trim-compatible.

#### Mark functionality as incompatible with trimming

If you're writing a library and it's not in your control whether or not to use incompatible functionality, you can mark it with `RequiresUnreferencedCode`. This annotates your method as incompatible with trimming. Using `RequiresUnreferencedCode` silences all trim warnings in the given method, but produces a warning whenever someone else calls it.

The <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute> requires you to specify a `Message`. The message is shown as part of a warning reported to the developer who calls the marked method. For example:

```console
IL2026: Using member <incompatible method> which has 'RequiresUnreferencedCodeAttribute' can break functionality when trimming application code. <The message value>
```

With the example above, a warning for a specific method might look like this:

```console
IL2026: Using member 'MethodWithAssemblyLoad()' which has 'RequiresUnreferencedCodeAttribute' can break functionality when trimming application code. This functionality is not compatible with trimming. Use 'MethodFriendlyToTrimming' instead.
```

Developers calling such APIs are generally not going to be interested in the particulars of the affected API or specifics as it relates to trimming.

A good message should state what functionality isn't compatible with trimming and then guide the developer what are their potential next steps. It might suggest to use a different functionality or change how the functionality is used. It might also simply state that the functionality isn't yet compatible with trimming without a clear replacement.

If the guidance to the developer becomes too long to be included in a warning message, you can add an optional `Url` to the <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute> to point the developer to a web page describing the problem and possible solutions in greater detail.

For example:

```csharp
[RequiresUnreferencedCode("This functionality is not compatible with trimming. Use 'MethodFriendlyToTrimming' instead", Url = "https://site/trimming-and-method)]
void MethodWithAssemblyLoad() { ... }
```

This produces a warning:

```console
IL2026: Using member 'MethodWithAssemblyLoad()' which has 'RequiresUnreferencedCodeAttribute' can break functionality when trimming application code. This functionality is not compatible with trimming. Use 'MethodFriendlyToTrimming' instead. https://site/trimming-and-method
```

Using `RequiresUnreferencedCode` often leads to marking more methods with it, due to the same reason. This is common when a high-level method becomes incompatible with trimming because it calls a low-level method that isn't trim-compatible. You "bubble up" the warning to a public API. Each usage of `RequiresUnreferencedCode` needs a message, and in these cases the messages are likely the same. To avoid duplicating strings and making it easier to maintain, use a constant string field to store the message:

```csharp
class Functionality
{
    const string IncompatibleWithTrimmingMessage = "This functionality is not compatible with trimming. Use 'FunctionalityFriendlyToTrimming' instead";

    [RequiresUnreferencedCode(IncompatibleWithTrimmingMessage)]
    private void ImplementationOfAssemblyLoading()
    {
        ...
    }

    [RequiresUnreferencedCode(IncompatibleWithTrimmingMessage)]
    public void MethodWithAssemblyLoad()
    {
        ImplementationOfAssemblyLoading();
    }
}
```

### Functionality with requirements on its input

Trimming provides APIs to specify more requirements on input to methods and other members that lead to trim-compatible code. These requirements are usually about reflection and the ability to access certain members or operations on a type. Such requirements are specified using the <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute>.

Unlike `RequiresUnreferencedCode`, reflection can sometimes be understood by the trimmer as long as it's annotated correctly. Let's take another look at the original example:

```csharp
string s = Console.ReadLine();
Type type = Type.GetType(s);
foreach (var m in type.GetMethods())
{
    Console.WriteLine(m.Name);
}
```

In the previous example, the real problem is `Console.ReadLine()`. Because *any* type could be read, the trimmer has no way to know if you need methods on `System.DateTime` or `System.Guid` or any other type. On the other hand, the following code would be fine:

```csharp
Type type = typeof(System.DateTime);
foreach (var m in type.GetMethods())
{
    Console.WriteLine(m.Name);
}
```

Here the trimmer can see the exact type being referenced: `System.DateTime`. Now it can use flow analysis to determine that it needs to keep all public methods on `System.DateTime`. So where does `DynamicallyAccessMembers` come in? When reflection is split across multiple methods. In the following code, we can see that the type `System.DateTime` flows to `Method3` where reflection is used to access `System.DateTime`'s methods,

```csharp
void Method1()
{
    Method2<System.DateTime>();
}
void Method2<T>()
{
    Type t = typeof(T);
    Method3(t);
}
void Method3(Type type)
{
    var methods = type.GetMethods();
    ...
}
```

If you compile the previous code, the following warning is produced:

> IL2070: Program.Method3(Type): 'this' argument does not satisfy
> 'DynamicallyAccessedMemberTypes.PublicMethods' in call to 'System.Type.GetMethods()'. The
> parameter 'type' of method 'Program.Method3(Type)' does not have matching annotations. The
> source value must declare at least the same requirements as those declared on the target
> location it is assigned to.

For performance and stability, flow analysis isn't performed between methods, so an annotation is needed to pass information between methods, from the reflection call (`GetMethods`) to the source of the `Type`. In the previous example, the trimmer warning is saying that `GetMethods` requires the `Type` object instance it's called on to have the `PublicMethods` annotation, but the `type` variable doesn't have the same requirement. In other words, we need to pass the requirements from `GetMethods` up to the caller:

```csharp
void Method1()
{
    Method2<System.DateTime>();
}
void Method2<T>()
{
    Type t = typeof(T);
    Method3(t);
}
void Method3(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type)
{
    var methods = type.GetMethods();
  ...
}
```

After annotating the parameter `type`, the original warning disappears, but another appears:

> IL2087: 'type' argument does not satisfy 'DynamicallyAccessedMemberTypes.PublicMethods'
> in call to 'Program.Method3(Type)'. The generic parameter 'T' of 'Program.Method2\<T\>()' does not
> have matching annotations.

We propagated annotations up to the parameter `type` of `Method3`, in `Method2` we have a similar issue. The trimmer is able to track the value `T` as it flows through the call to `typeof`, is assigned to the local variable `t`, and passed to `Method3`. At that point it sees that the parameter `type` requires `PublicMethods` but there are no requirements on `T`, and produces a new warning. To fix this, we must "annotate and propagate" by applying annotations all the way up the call chain until we reach a statically known type (like `System.DateTime` or `System.Tuple`), or another annotated value. In this case, we need to annotate the type parameter `T` of `Method2`.

```csharp
void Method1()
{
    Method2<System.DateTime>();
}
void Method2<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>()
{
    Type t = typeof(T);
    Method3(t);
}
void Method3(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type)
{
    var methods = type.GetMethods();
  ...
}
```

Now there are no warnings because the trimmer knows which members might be accessed via runtime reflection (public methods) and on which types (`System.DateTime`), and it preserves them. It's best practice to add annotations so the trimmer knows what to preserve.

Warnings produced by these extra requirements are automatically suppressed if the affected code is in a method with `RequiresUnreferencedCode`.

Unlike `RequiresUnreferencedCode`, which simply reports the incompatibility, adding `DynamicallyAccessedMembers` makes the code compatible with trimming.

### Suppressing trimmer warnings

If you can somehow determine that the call is safe, and all the code that's needed won't be trimmed away, you can also suppress the warning using <xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute>. For example:

```csharp
[RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
void MethodWithAssemblyLoad() { ... }

[UnconditionalSuppressMessage("AssemblyLoadTrimming", "IL2026:RequiresUnreferencedCode",
    Justification = "Everything referenced in the loaded assembly is manually preserved, so it's safe")]
void TestMethod()
{
    InitializeEverything();

    MethodWithAssemblyLoad(); // Warning suppressed

    ReportResults();
}
```

> [!WARNING]
> Be very careful when suppressing trim warnings. It's possible that the call may be trim-compatible now, but as you change your code that may change, and you may forget to review all the suppressions.

`UnconditionalSuppressMessage` is like `SuppressMessage` but it can be seen by `publish` and other post-build tools.

> [!IMPORTANT]
> Do not use `SuppressMessage` or `#pragma warning disable` to suppress trimmer warnings. These only work for the compiler, but are not preserved in the compiled assembly. Trimmer operates on compiled assemblies and would not see the suppression.

The suppression applies to the entire method body. So in our sample above it suppresses all `IL2026` warnings from the method. This makes it harder to understand, as it's not clear which method is the problematic one, unless you add a comment. More importantly, if the code changes in the future, such as if `ReportResults` becomes trim-incompatible as well, no warning is reported for this method call.

You can resolve this by refactoring the problematic method call into a separate method or local function and then applying the suppression to just that method:

```csharp
void TestMethod()
{
    InitializeEverything();

    CallMethodWithAssemblyLoad();

    ReportResults();

    [UnconditionalSuppressMessage("AssemblyLoadTrimming", "IL2026:RequiresUnreferencedCode",
        Justification = "Everything referenced in the loaded assembly is manually preserved, so it's safe")]
    void CallMethodWithAssemblyLoad()
    {
        MethodWIthAssemblyLoad(); // Warning suppressed
    }
}
```
