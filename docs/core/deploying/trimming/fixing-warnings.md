---
title: Introduction to trim warnings
description: Learn about why warnings may be produced when publishing a trimmed application, how to address them, and how to make the application "trim compatible."
author: agocke
ms.author: angocke
ms.date: 09/08/2021
---
# Introduction to trim warnings

Conceptually, [trimming](trim-self-contained.md) is simple: when publishing the application, the .NET SDK analyzes the entire application and removes all unused code. However, it can be difficult to determine what is unused, or more precisely, what is used.

To prevent changes in behavior when trimming applications, the .NET SDK provides static analysis of trim compatibility through "trim warnings." Trim warnings are produced by the trimmer when it finds code that may not be compatible with trimming. Code that's not trim-compatible may produce behavioral changes, or even crashes, in an application after it has been trimmed. Ideally, all applications that use trimming should have no trim warnings. If there are any trim warnings, the app should be thoroughly tested after trimming to ensure that there are no behavior changes.

This article will help developers understand why some patterns produce trim warnings, and how these warnings can be addressed.

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

In this example, <xref:System.Type.GetType> dynamically requests a type with an unknown name, and then prints the names of all of its methods. Because there's no way to know at publish time what type name is going to be used, there's no way for the trimmer to know which type to preserve in the output. It's likely that this code could have worked before trimming (as long as the input is something known to exist in the target framework), but would probably produce a null reference exception after trimming (due to `Type.GetType` returning null).

In this case, the trimmer issues a warning on the call to `Type.GetType`, indicating that it cannot determine which type is going to be used by the application.

## Reacting to trim warnings

Trim warnings are meant to bring predictability to trimming. There are two large categories of warnings that you will likely see:

1. `RequiresUnreferencedCode`
2. `DynamicallyAccessedMembers`

### RequiresUnreferencedCode

<xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute> is simple and broad: it's an attribute that means the member has been annotated incompatible with trimming, meaning that it might use reflection or some other mechanism to access code that may be trimmed away. This attribute is used when code is fundamentally not trim compatible, or the trim dependency is too complex to explain to the trimmer. This would often be true for methods that use the C# [`dynamic`](../../../csharp/language-reference/builtin-types/reference-types.md#the-dynamic-type) keyword, accessing types from <xref:System.Reflection.Assembly.LoadFrom(System.String)>, or other runtime code generation technologies. An example would be:

```csharp
[RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
void MethodWithAssemblyLoad() { ... }

void TestMethod()
{
    // IL2026: Using method 'MethodWithAssemblyLoad' which has 'RequiresUnreferencedCodeAttribute'
    // can break functionality when trimming application code. Use 'MethodFriendlyToTrimming' instead.
    MethodWithAssemblyLoad();
}
```

There aren't many workarounds for `RequiresUnreferencedCode`. The best fix is to avoid calling the method at all when trimming and use something else that's trim-compatible. If you're writing a library and it's not in your control whether or not to call the method, you can also add `RequiresUnreferencedCode` to your own method. This will annotate your method as not trim compatible. Adding `RequiresUnreferencedCode` will silence all trimming warnings in the given method, but will produce a warning whenever someone else calls it. For this reason, it is mostly useful to library authors to "bubble up" the warning to a public API.

If you can somehow determine that the call is safe, and all the code that's needed won't be trimmed away, you can also suppress the warning using <xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute>. For example:

```csharp
[RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
void MethodWithAssemblyLoad() { ... }

[UnconditionalSuppressMessage("AssemblyLoadTrimming", "IL2026:RequiresUnreferencedCode",
    Justification = "Everything referenced in the loaded assembly is manually preserved, so it's safe")]
void TestMethod()
{
    MethodWithAssemblyLoad(); // Warning suppressed
}
```

`UnconditionalSuppressMessage` is like `SuppressMessage` but it can be seen by `publish` and other post-build tools. `SuppressMessage` and `#pragma` directives are only present in source so they can't be used to silence warnings from the trimmer. Be very careful when suppressing trim warnings: it's possible that the call may be trim-compatible now, but as you change your code that may change, and you may forget to review all the suppressions.

### DynamicallyAccessedMembers

<xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> is usually about reflection. Unlike `RequiresUnreferencedCode`, reflection can sometimes be understood by the trimmer as long as it's annotated correctly. Let's take another look at the original example:

```csharp
string s = Console.ReadLine();
Type type = Type.GetType(s);
foreach (var m in type.GetMethods())
{
    Console.WriteLine(m.Name);
}
```

In the example above, the real problem is `Console.ReadLine()`. Because *any* type could be read, the trimmer has no way to know if you need methods on `System.DateTime` or `System.Guid` or any other type. On the other hand, the following code would be fine:

```csharp
Type type = typeof(System.DateTime);
foreach (var m in type.GetMethods())
{
    Console.WriteLine(m.Name);
}
```

Here the trimmer can see the exact type being referenced: `System.DateTime`. Now it can use flow analysis to determine that it needs to keep all public methods on `System.DateTime`. So where does `DynamicallyAccessMembers` come in? When reflection is split across multiple methods. In the below code, we can see that the type `System.DateTime` flows to `Method3` where reflection is used to access `System.DateTime`'s methods,

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

If you compile the previous code, now you see a warning:

> Trim analysis warning IL2070: net6.Program.Method3(Type): 'this' argument does not satisfy
> 'DynamicallyAccessedMemberTypes.PublicMethods' in call to 'System.Type.GetMethods()'. The
> parameter 'type' of method 'net6.Program.Method3(Type)' does not have matching annotations. The
> source value must declare at least the same requirements as those declared on the target
> location it is assigned to.

For performance and stability, flow analysis isn't performed between methods, so an annotation is needed to pass information between methods, from the reflection call (`GetMethods`) to the source of the `Type`. In the previous example, the trimmer warning is saying that `GetMethods` requires the `Type` object instance it is called on to have the `PublicMethods` annotation, but the `type` variable doesn't have the same requirement. In other words, we need to pass the requirements from `GetMethods` up to the caller:

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
> in call to 'C.Method3(Type)'. The generic parameter 'T' of 'C.Method2\<T\>()' does not
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

Now there are no warnings because the trimmer knows exactly which members may be accessed via runtime reflection (public methods) and on which types (`System.DateTime`), and it will preserve them. In general, this is the best way to deal with `DynamicallyAccessedMembers` warnings: add annotations so the trimmer knows what to preserve.

As with `RequiresUnreferencedCode` warnings, adding `RequiresUnreferencedCode` or `UnconditionalSuppressMessage` attributes also suppresses warnings but doesn't make the code compatible with trimming, while adding `DynamicallyAccessedMembers` does make it compatible.
