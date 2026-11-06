---
title: "MSTEST0018: DynamicData should be valid"
description: "Learn about code analysis rule MSTEST0018: DynamicData should be valid"
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0018
- DynamicDataShouldBeValidAnalyzer
helpviewer_keywords:
- DynamicDataShouldBeValidAnalyzer
- MSTEST0018
author: Evangelink
ms.author: amauryleve
---
# MSTEST0018: DynamicData should be valid

| Property                            | Value                                 |
|-------------------------------------|---------------------------------------|
| **Rule ID**                         | MSTEST0018                            |
| **Title**                           | DynamicData should be valid           |
| **Category**                        | Usage                                 |
| **Fix is breaking or non-breaking** | Non-breaking                          |
| **Enabled by default**              | Yes                                   |
| **Default severity**                | Warning                               |
| **Introduced in version**           | 3.6.0                                 |

## Cause

A method marked with `[DynamicData]` should have valid layout.

## Rule description

`[DynamicData]` names a member that supplies test cases. MSTest resolves that member, enumerates its rows, and passes each row to a test method. The analyzer catches member-lookup and signature problems before the runner encounters them.

MSTest can enumerate data during discovery, before it creates a per-test instance or runs per-test initialization. A data source therefore must not depend on those steps to supply its rows.

| Data-source requirement | Reason |
|-------------------------|--------|
| Apply `[DynamicData]` to a method marked with `[TestMethod]` or a derived attribute. | A data attribute supplies arguments; it doesn't declare a test entry point. |
| Reference an existing, unambiguous member on the specified type, or the current class if no type is specified. | MSTest resolves the member by name. A missing or ambiguous member prevents the runner from obtaining the intended test data. |
| Match the member kind to the specified `DynamicDataSourceType`, or use `AutoDetect` on versions that support it. | MSTest must know whether to invoke a method, read a property, or read a field to obtain the rows. |
| Use a static member and a non-generic data-source method. | The source must be callable without a per-test instance or method type arguments. |
| Use a parameterless method, or in MSTest 3.10 and later, supply matching data-source arguments through `[DynamicData]`. | The runner only supplies the data-source arguments specified by the attribute, not arbitrary values or the test's `TestContext`. |
| Return an enumerable of supported test-data rows. | MSTest enumerates the source and binds each row to the test method's parameters. The row shape must supply compatible arguments. Common return types include `IEnumerable<object[]>`, `IEnumerable<Tuple<...>>`, and `IEnumerable<ValueTuple<...>>`. |

For supported row types and parameterized sources, see [DynamicDataAttribute](../unit-testing-mstest-writing-tests-data-driven.md#dynamicdataattribute). For automatic member-kind detection, see [MSTEST0052](mstest0052.md).

If you specify a custom display-name member, it must meet a separate callback contract:

| Display-name requirement | Reason |
|--------------------------|--------|
| Reference an existing, unambiguous method on the specified type. | MSTest must resolve one callback that formats the name, rather than a property or an ambiguous overload. |
| Use a public, static, non-generic method. | MSTest invokes the formatter directly without a test-class instance or method type arguments. |
| Return `string`. | The callback supplies the human-readable name used to identify the test case. |
| Take exactly two parameters: `MethodInfo` followed by `object[]`. | MSTest supplies the test method and the current row's values so the formatter can distinguish individual test cases. |

Example:

```csharp
public static string GetDisplayName(MethodInfo methodInfo, object[] data)
{
    return string.Format("{0} ({1})", methodInfo.Name, string.Join(",", data));
}
```

## How to fix violations

Ensure that the attribute matches the conditions described above.

## When to suppress warnings

Do not suppress a warning from this rule. If you ignore this rule, flagged instances will be either skipped or result in runtime error.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0018
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0018
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0018.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
