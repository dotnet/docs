---
title: "MSTEST0087: Avoid duplicated 'DataRow' display names"
description: "Learn about code analysis rule MSTEST0087: Avoid duplicated 'DataRow' display names"
ms.date: 10/01/2026
f1_keywords:
- MSTEST0087
- DuplicateDataRowDisplayNameAnalyzer
helpviewer_keywords:
- DuplicateDataRowDisplayNameAnalyzer
- MSTEST0087
author: evangelink
ms.author: amauryleve
ai-usage: ai-generated
dev_langs:
- CSharp
- VB
---
# MSTEST0087: Avoid duplicated `DataRow` display names

| Property | Value |
|---|---|
| **Rule ID** | MSTEST0087 |
| **Title** | Avoid duplicated `DataRow` display names |
| **Category** | Usage |
| **Fix is breaking or non-breaking** | Non-breaking |
| **Enabled by default** | Yes |
| **Default severity** | Warning |
| **Introduced in version** | 4.5.0 (preview) |
| **Is there a code fix** | No |

## Cause

Two or more <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute> instances on the same test method set the same nonempty `DisplayName`.

## Rule description

Duplicate explicit display names make data rows indistinguishable in Test Explorer, reports, and failure output. The rule compares names with ordinal, case-sensitive equality and reports each duplicate after the first occurrence.

```csharp
[TestMethod]
[DataRow(1, DisplayName = "valid")]
[DataRow(2, DisplayName = "valid")] // Violation
public void Validate(int value) { }
```

## How to fix violations

Give each row a unique display name, or remove `DisplayName` and let MSTest generate names from the method and arguments.

```csharp
[DataRow(1, DisplayName = "valid-one")]
[DataRow(2, DisplayName = "valid-two")]
```

## When to suppress warnings

Don't suppress this rule when the rows must remain distinguishable in test results. Suppression is reasonable only when a downstream runner replaces the display names with another unique identity.

## Suppress a warning

```csharp
#pragma warning disable MSTEST0087
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0087
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0087.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Data-driven testing in MSTest](../unit-testing-mstest-writing-tests-data-driven.md)
- [MSTEST0042: Duplicate DataRow](mstest0042.md)
