---
title: Introduction to AOT warnings
description: Learn about why warnings may be produced when publishing application as native AOT, how to address them, and how to make the application "AOT compatible."
author: MichalStrehovsky
ms.author: michals
ms.date: 09/06/2022
---
# Introduction to AOT warnings

When publishing your application as native AOT, the build process produces all the native code and data structures required to support the application at run time. This is different from non-native deployments that execute the application from formats describing the application in abstract terms (a program for a virtual machine) and create native representations on demand at run time.

The abstract representations of program parts don't have a one-to-one mapping to native representation. E.g. the abstract description of the generic `List<T>.Add` method maps to potentially infinite number of native method bodies that need to be specialized for the given T (`List<int>.Add`, `List<double>.Add`, etc.).

Because the relationship of abstract code to native code is not one-to-one, the build process needs to create a complete list of native code bodies and data structures at build time. With some of the .NET APIs it can be difficult to create this list at build time. If the API is used in a way that wasn't anticipated at build time, an exception will be thrown.

To prevent changes in behavior when deploying as native AOT, the .NET SDK provides static analysis of AOT compatibility through "AOT warnings." AOT warnings are produced when the build finds code that may not be compatible with AOT. Code that's not AOT-compatible may produce behavioral changes, or even crashes, in an application after it has been built as native AOT. Ideally, all applications that use native AOT should have no AOT warnings. If there are any AOT warnings, the app should be thoroughly tested after building as native AOT to ensure that there are no behavior changes.

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

While the above program is not very useful, it represents an extreme case that requires an infinite number of generic types to be created when building the application as native AOT. Without native AOT, the program would run until it runs out of memory. With native AOT, we would not be able to even build it if we were to generate all the necessary types (the infinite number of them).

In this case, native AOT build will issue following warning on the `MakeGenericType` line:

```
AOT analysis warning IL3050: Program.<Main>$(String[]): Using member 'System.Type.MakeGenericType(Type[])' which has 'RequiresDynamicCodeAttribute' can break functionality when AOT compiling. The native code for this instantiation might not be available at runtime.
```

At run time, the application will indeed throw an exception from the `MakeGenericType` call.

## Reacting to AOT warnings

The AOT warnings are meant to bring predictability to native AOT builds. Majority of AOT warning are about possible run time exception in situations when native code wasn't generated to support the scenario. The broadest category is `RequiresDynamicCodeAttribute`.

### RequiresDynamicCode

<xref:System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute> is simple and broad: it's an attribute that means the member has been annotated incompatible with AOT, meaning that it might use reflection or some other mechanism to create new native code at runtime. This attribute is used when code is fundamentally not AOT compatible, or the native dependency is too complex to statically predict at build time. This would often be true for methods that use the Type.MakeGenericType API, reflection emit, or other runtime code generation technologies. An example would be:
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

There aren't many workarounds for `RequiresDynamicCode`. The best fix is to avoid calling the method at all when building as native AOT and use something else that's AOT-compatible. If you're writing a library and it's not in your control whether or not to call the method, you can also add `RequiresDynamicCode` to your own method. This will annotate your method as not AOT compatible. Adding `RequiresDynamicCode` will silence all AOT warnings in the given method, but will produce a warning whenever someone else calls it. For this reason, it is mostly useful to library authors to "bubble up" the warning to a public API.

If you can somehow determine that the call is safe, and all native code will be available at runtime, you can also suppress the warning using <xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute>. For example:

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

`UnconditionalSuppressMessage` is like `SuppressMessage` but it can be seen by `publish` and other post-build tools. `SuppressMessage` and `#pragma` directives are only present in source so they can't be used to silence warnings from the build. Be very careful when suppressing AOT warnings: it's possible that the call may be AOT-compatible now, but as you change your code that may change, and you may forget to review all the suppressions.
