---
title: "MSTEST0081: '[TestFilterProvider]' should reference a valid test filter type"
description: "Learn about code analysis rule MSTEST0081: '[TestFilterProvider]' should reference a valid test filter type"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0081
- TestFilterProviderShouldBeValidAnalyzer
helpviewer_keywords:
- TestFilterProviderShouldBeValidAnalyzer
- MSTEST0081
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0081: '\[TestFilterProvider]' should reference a valid test filter type

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0081                                          |
| **Title**                           | '\[TestFilterProvider]' should reference a valid test filter type |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | No                                                 |

> [!IMPORTANT]
> This analyzer is planned for MSTest 4.4 and is available only in preview builds until MSTest 4.4.0 is released.

## Cause

`[assembly: TestFilterProvider(typeof(MyFilter))]` references a type that doesn't satisfy the requirements the adapter enforces at run time, or the assembly registers more than one test filter provider.

## Rule description

`[assembly: TestFilterProvider(typeof(MyFilter))]` passes the filter type as a `Type`, so the compiler accepts any type at all. The adapter validates the type only when it materializes the filter, and then fails the whole run. This analyzer reports the same problems at build time, where they're cheap to fix. The referenced type must:

- Be non-generic.
- Be instantiable, so it can't be abstract, static, an interface, or a byref-like type.
- Implement `ITestFilter`.
- Declare a public parameterless constructor (every struct already satisfies this).

At most one test filter provider can be registered per test assembly, and passing an explicit `null` filter type also fails. When targeting .NET, the generic `[assembly: TestFilterProvider<MyFilter>]` form enforces the interface and constructor requirements through generic constraints instead, so only the generic-type and "at most one provider" checks still apply to it.

```csharp
[assembly: TestFilterProvider(typeof(MyFilter))]
public sealed class MyFilter : ITestFilter
{
    public MyFilter(string mode) { } // Violation: no public parameterless constructor
    public TestFilterResult Filter(TestFilterContext context) => TestFilterResult.Run;
}
```

## How to fix violations

Add a public parameterless constructor, or otherwise adjust the type so that it's non-generic, instantiable, implements `ITestFilter`, and has a public parameterless constructor.

```csharp
public sealed class MyFilter : ITestFilter
{
    public TestFilterResult Filter(TestFilterContext context) => TestFilterResult.Run;
}
```

## When to suppress warnings

Don't suppress warnings from this rule. A violation fails the whole test run at run time rather than only the filter itself.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0081
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0081
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0081.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Programmatic test filtering with ITestFilter](../unit-testing-mstest-sdk.md#programmatic-test-filtering-with-itestfilter)
