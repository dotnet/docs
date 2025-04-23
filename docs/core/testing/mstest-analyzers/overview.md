---
title: MSTest code analysis
description: Learn about the MSTest code analysis.
author: evangelink
ms.author: amauryleve
ms.date: 12/20/2023
---

# MSTest code analysis

*MSTest analysis* ("MSTESTxxxx") rules inspect your C# or Visual Basic code for security, performance, design and other issues.

> [!TIP]
> If you're using Visual Studio, many analyzer rules have associated *code fixes* that you can apply to correct the problem. Code fixes are shown in the light bulb icon menu.

The rules are organized into categories such as performance usage...

Starting with MSTest.TestFramework 3.7, the MSTest.Analyzers NuGet package is a dependency of the framework. For earlier versions, you need to use `MSTest` metapackage or add a package reference for `MSTest.Analyzers` explicitly.

## MSTestAnalysisMode

Starting with MSTest 3.8, an MSBuild property named `MSTestAnalysisMode` is available to determine which analyzers are enabled at which severity.

> [!TIP]
> To see which rules are enabled at which severity for each mode, you can navigate to the package of the version of interest in NuGet cache, locate the `globalconfigs` directory, and open the `.globalconfig` file corresponding to the analysis mode.
> For more information on finding the NuGet cache directory, see [Managing the global packages, cache, and temp folders](/nuget/consume-packages/managing-the-global-packages-and-cache-folders). From that directory, locate `mstest.analyzers` directory, then the version (3.8 and higher), then `globalconfigs`.
> Alternatively, you can download the NuGet package of the version of interest from `nuget.org` and view it in NuGet Package Explorer (Windows app), or view directly in the [web app version of NuGet Package Explorer](https://nuget.info/packages/MSTest.Analyzers/).

The available values for this property:

- [`None`](#none)
- [`Default`](#default)
- [`Recommended`](#recommended)
- [`All`](#all)

### `None`

This value sets all analyzers to `none` severity, disabling all of them. You can then enable individual analyzers using `.editorconfig` or `.globalconfig` files.

### `Default`

This setting follows the default documented behavior for each rule.

- Rules that are enabled by default will use their default severity.
- Rules that are disabled by default will use `none` severity.

> [!NOTE]
> Rules that are enabled by default as warnings are violations that are expected to cause issues at run time.

### `Recommended`

This is the mode most developers are expected to use. Rules that are enabled by default with Info (`suggestion`) severity are escalated to warnings. The following rules are escalated to errors in both `Recommended` and `All` modes:

- [MSTEST0003: Test methods should have valid layout](mstest0003.md).
- [MSTEST0043: Use retry attribute on test method](mstest0043.md).

### `All`

This mode is more aggressive than `Recommended`. All rules are enabled as warnings. In addition, the following rules are escalated to errors:

- [MSTEST0003: Test methods should have valid layout](mstest0003.md).
- [MSTEST0043: Use retry attribute on test method](mstest0043.md).

> [!NOTE]
> The following rules are completely opt-in and are not enabled in `Default`, `Recommended`, or `All` modes:
>
> - [MSTEST0015: Test method should not be ignored](mstest0015.md)
> - [MSTEST0019: Prefer TestInitialize methods over constructors](mstest0019.md)
> - [MSTEST0020: Prefer constructors over TestInitialize methods](mstest0020.md)
> - [MSTEST0021: Prefer Dispose over TestCleanup methods](mstest0021.md)
> - [MSTEST0022: Prefer TestCleanup over Dispose methods](mstest0022.md)

## Categories

### Design rules

[Design rules](design-rules.md) help you create and maintain test suites that adhere to proper design and good practices.

### Performance rules

[Performance rules](performance-rules.md) support high-performance testing.

### Suppression rules

[Suppression rules](suppression-rules.md) support suppressing diagnostics from other rules.

### Usage rules

[Usage rules](usage-rules.md) support proper usage of MSTest.

### MSTESTEXP

Several APIs of MSTest are decorated with the <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute>. This attribute indicates that the API is experimental and may be removed or changed in future versions of MSTest. The attribute is used to identify APIs that aren't yet stable and may not be suitable for production use.

The MSTESTEXP diagnostic alerts you to use of an experimental API in your code. To suppress this diagnostic with the `SuppressMessageAttribute`, add the following code to your project:

```csharp
using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("MSTESTEXP", "Justification")]
```

Alternatively, you can suppress this diagnostic with preprocessor directive by adding the following code to your project:

```csharp
#pragma warning disable MSTESTEXP
        // API that is causing the warning.
#pragma warning restore MSTESTEXP
```
