---
title: Introduction to AOT warnings
description: Learn why warnings might be produced when publishing an application as Native AOT, how to address them, and how to make the application "AOT compatible."
author: MichalStrehovsky
ms.author: michals
ms.date: 09/06/2022
ms.topic: concept-article
---
# Introduction to AOT warnings

When publishing your application as Native AOT, the build process produces all the native code and data structures required to support the application at run time. This is different from non-native deployments, which execute the application from formats that describe the application in abstract terms (a program for a virtual machine) and create native representations on demand at run time.

The abstract representations of program parts don't have a one-to-one mapping to native representation. For example, the abstract description of the generic `List<T>.Add` method maps to potentially infinite native method bodies that need to be specialized for the given `T` (for example, `List<int>.Add` and `List<double>.Add`).

Because the relationship of abstract code to native code is not one-to-one, the build process needs to create a complete list of native code bodies and data structures at build time. It can be difficult to create this list at build time for some of the .NET APIs. If the API is used in a way that wasn't anticipated at build time, an exception will be thrown at run time.

To prevent changes in behavior when deploying as Native AOT, the .NET SDK provides static analysis of AOT compatibility through "AOT warnings." AOT warnings are produced when the build finds code that may not be compatible with AOT. Code that's not AOT-compatible may produce behavioral changes or even crashes in an application after it's been built as Native AOT. Ideally, all applications that use Native AOT should have no AOT warnings. If there are any AOT warnings, ensure there are no behavior changes by thoroughly testing your app after building as Native AOT.

## Examples of AOT warnings

For most C# code, it's straightforward to determine what native code needs to be generated. The native compiler can walk the method bodies and find what native code and data structures are accessed. Unfortunately, some features, like reflection, present a significant problem. Consider the following code:

```csharp
Type t = typeof(int);
while (true)
{
    t = typeof(GenericType<>).MakeGenericType(t);
    Console.WriteLine(Activator.CreateInstance(t));
}

struct GenericType<T> { }
```

While the above program is not very useful, it represents an extreme case that requires an infinite number of generic types to be created when building the application as Native AOT. Without Native AOT, the program would run until it runs out of memory. With Native AOT, we would not be able to even build it if we were to generate all the necessary types (the infinite number of them).

In this case, Native AOT build issues the following warning on the `MakeGenericType` line:

```
AOT analysis warning IL3050: Program.<Main>$(String[]): Using member 'System.Type.MakeGenericType(Type[])' which has 'RequiresDynamicCodeAttribute' can break functionality when AOT compiling. The native code for this instantiation might not be available at runtime.
```

At run time, the application will indeed throw an exception from the `MakeGenericType` call.

## React to AOT warnings

The AOT warnings are meant to bring predictability to Native AOT builds. A majority of AOT warnings are about possible run-time exception in situations when native code wasn't generated to support the scenario. The broadest category is `RequiresDynamicCodeAttribute`.

### RequiresDynamicCode

<xref:System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute> is simple and broad: it's an attribute that means the member has been annotated as being incompatible with AOT. This annotation means that the member might use reflection or another mechanism to create new native code at run time. This attribute is used when code is fundamentally not AOT compatible, or the native dependency is too complex to statically predict at build time. This would often be true for methods that use the `Type.MakeGenericType` API, reflection emit, or other run-time code generation technologies. The following code shows an example.

```csharp
[RequiresDynamicCode("Use 'MethodFriendlyToAot' instead")]
void MethodWithReflectionEmit() { ... }

void TestMethod()
{
    // IL3050: Using method 'MethodWithReflectionEmit' which has 'RequiresDynamicCodeAttribute'
    // can break functionality when AOT compiling. Use 'MethodFriendlyToAot' instead.
    MethodWithReflectionEmit();
}
```

There aren't many workarounds for `RequiresDynamicCode`. The best fix is to avoid calling the method at all when building as Native AOT and use something else that's AOT compatible. If you're writing a library and it's not in your control whether or not to call the method, you can also add `RequiresDynamicCode` to your own method. This will annotate your method as not AOT compatible. Adding `RequiresDynamicCode` silences all AOT warnings in the annotated method but will produce a warning whenever someone else calls it. For this reason, it's mostly useful to library authors to "bubble up" the warning to a public API.

If you can somehow determine that the call is safe, and all native code will be available at run time, you can also suppress the warning using <xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute>. For example:

```csharp
[RequiresDynamicCode("Use 'MethodFriendlyToAot' instead")]
void MethodWithReflectionEmit() { ... }

[UnconditionalSuppressMessage("Aot", "IL3050:RequiresDynamicCode",
    Justification = "The unfriendly method is not reachable with AOT")]
void TestMethod()
{
    If (RuntimeFeature.IsDynamicCodeSupported)
        MethodWithReflectionEmit(); // warning suppressed
}
```

`UnconditionalSuppressMessage` is like `SuppressMessage` but it can be seen by `publish` and other post-build tools. `SuppressMessage` and `#pragma` directives are only present in source, so they can't be used to silence warnings from the build.

> [!CAUTION]
> Be careful when suppressing AOT warnings. The call might be AOT-compatible now, but as you update your code, that might change, and you might forget to review all the suppressions.
