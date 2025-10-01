---
title: "MSTEST0052: Prefer DynamicDataSourceType.AutoDetect"
description: "Learn about code analysis rule MSTEST0052: Prefer DynamicDataSourceType.AutoDetect"
ms.date: 01/29/2025
f1_keywords:
- MSTEST0052
- PreferDynamicDataSourceTypeAutoDetectAnalyzer
helpviewer_keywords:
- PreferDynamicDataSourceTypeAutoDetectAnalyzer
- MSTEST0052
author: Evangelink
ms.author: amauryleve
ai-usage: ai-generated
---
# MSTEST0052: Prefer DynamicDataSourceType.AutoDetect

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0052                                                                               |
| **Title**                           | Prefer DynamicDataSourceType.AutoDetect                                                  |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Warning                                                                                  |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | Yes                                                                                      |

## Cause

A <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataAttribute> explicitly specifies <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataSourceType.Property> or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataSourceType.Method> instead of using the default <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DynamicDataSourceType.AutoDetect>.

## Rule description

Starting with MSTest 3.8, `DynamicDataSourceType.AutoDetect` is the default value for the `DynamicDataSourceType` parameter in the `DynamicDataAttribute` constructor. This enhancement automatically detects whether the data source is a property or method, eliminating the need to explicitly specify the source type. Using `AutoDetect` makes the code more maintainable and reduces verbosity.

## How to fix violations

Remove the explicit `DynamicDataSourceType` parameter from the `DynamicData` attribute and let the framework auto-detect the source type.

For example, change this:

```csharp
public static IEnumerable<object[]> TestData { get; } = new[]
{
    new object[] { 1, 2, 3 },
    new object[] { 4, 5, 9 }
};

[TestMethod]
[DynamicData(nameof(TestData), DynamicDataSourceType.Property)]
public void TestMethod(int a, int b, int expected)
{
    Assert.AreEqual(expected, a + b);
}
```

To this:

```csharp
public static IEnumerable<object[]> TestData { get; } = new[]
{
    new object[] { 1, 2, 3 },
    new object[] { 4, 5, 9 }
};

[TestMethod]
[DynamicData(nameof(TestData))]
public void TestMethod(int a, int b, int expected)
{
    Assert.AreEqual(expected, a + b);
}
```

## When to suppress warnings

You can suppress warnings from this rule if you're using a version of MSTest earlier than 3.8, where `AutoDetect` isn't available. However, consider upgrading to MSTest 3.8 or later to take advantage of this feature.
