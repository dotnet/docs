---
title: "MSTEST0018: DynamicData should be valid"
description: "Learn about code analysis rule MSTEST0018: DynamicData should be valid"
ms.date: 08/09/2024
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

Methods marked with `[DynamicData]` should also be marked with `[TestMethod]` (or a derived attribute).

The "data source" member referenced:

- should exist on the specified type (current class if no type is specified)
- should not have overloads
- should be of the same kind (method or property) as the `DataSourceType` property
- should be `public`
- should be `static`
- should not be generic
- should be parameterless
- should return `IEnumerable<object[]>`, `IEnumerable<Tuple<T,...>>` or `IEnumerable<ValueTuple<,...>>`

The "display name" member referenced:

- should exist on the specified type (current class if no type is specified)
- should not have overloads
- should be a method
- should be `public`
- should be `static`
- should not be generic
- should return `string`
- should take exactly 2 parameters, the first being `MethodInfo` and the second being `object[]`

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
