---
title: Validate Compatible Frameworks Inside a Package
description: Learn how to detect issues with API surface, identity, and compatibility across different target frameworks in a package.
ms.date: 09/29/2021
---

# Validate compatible frameworks

Packages containing compatible frameworks need to ensure that code compiled against one can run against another. Examples of compatible framework pairs are:

* .NET Standard 2.0 and .NET 6.0
* .NET 5.0 and .NET 6.0

In both of these cases, consumers can build against .NET Standard 2.0 or NET 5.0 and run on .NET 6.0. In case your binaries are not compatible between these frameworks, consumers could end up with compile or run-time errors.

Package validation catches these errors at pack time. Here is an example scenario:

Suppose you're writing a game that manipulates strings. You need to support both .NET Framework and .NET (.NET Core) consumers. Originally, your project targeted .NET Standard 2.0, but now you realize you want to take advantage of `Span<T>` in .NET 6.0 to avoid unnecessary string allocations. In order to do that, you now want to multi-target for .NET Standard 2.0 and .NET 6.0.

You've written the following code:

```csharp
#if NET6_0_OR_GREATER
    public void DoStringManipulation(ReadOnlySpan<char> input)
    {
        // use spans to do string operations.
    }
#else
    public void DoStringManipulation(string input)
    {
        // Do some string operations.
    }
#endif
```

You then try to pack the project (using either `dotnet pack` or Visual Studio), and it fails with the following error:

![CompatibleFrameworks](compatible-frameworks.png)

You realize that instead of excluding `DoStringManipulation(string)`, you should provide an additional `DoStringManipulation(ReadOnlySpan<char>)` method for .NET 6.0:

```csharp
#if NET6_0_OR_GREATER
    public void DoStringManipulation(ReadOnlySpan<char> input)
    {
        // use spans to do string operations.
    }
#endif
    public void DoStringManipulation(string input)
    {
        // Do some string operations.
    }
```

You try to pack the project again, and it succeeds.

![CompatibleFrameworksSuccessful](compatible-frameworks-successful.png)

You can enable *strict mode* for this validator by setting the `EnableStrictModeForCompatibleFrameworksInPackage` property in your project file. Enabling strict mode changes some rules and executes some other rules when getting the differences. This is useful when you want both sides you're comparing to be strictly the same on their surface area and identity.
