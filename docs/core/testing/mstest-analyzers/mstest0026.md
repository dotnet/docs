---
title: "MSTEST0026: Avoid conditional access in assertions"
description: "Learn about code analysis rule MSTEST0026: Avoid conditional access in assertions"
ms.date: 11/05/2026
ai-usage: ai-assisted
f1_keywords:
- MSTEST0026
- AssertionArgsShouldAvoidConditionalAccessRuleId
helpviewer_keywords:
- AssertionArgsShouldAvoidConditionalAccessRuleId
- MSTEST0026
author: fhnaseer
ms.author: faisalhafeez
---
# MSTEST0026: Avoid conditional access in assertions

| Property                            | Value                                                 |
|-------------------------------------|-------------------------------------------------------|
| **Rule ID**                         | MSTEST0026                                            |
| **Title**                           | Avoid conditional access in assertions                |
| **Category**                        | Usage                                                 |
| **Fix is breaking or non-breaking** | Non-breaking                                          |
| **Enabled by default**              | Yes (from 3.5 to 3.7). No (starting with 3.8)         |
| **Default severity**                | Info                                                  |
| **Introduced in version**           | 3.5.0                                                 |
| **Is there a code fix**             | No                                                    |

## Cause

This rule raises a diagnostic when an argument containing a [null conditional operator](../../../csharp/language-reference/operators/member-access-operators.md#null-conditional-operators--and-) `(?.)` or `?[]` is passed to the assertion methods below:

- `Assert.IsTrue`
- `Assert.IsFalse`
- `Assert.AreEqual`
- `Assert.AreNotEqual`
- `Assert.AreSame`
- `Assert.AreNotSame`
- `CollectionAssert.AreEqual`
- `CollectionAssert.AreNotEqual`
- `CollectionAssert.AreEquivalent`
- `CollectionAssert.AreNotEquivalent`
- `CollectionAssert.Contains`
- `CollectionAssert.DoesNotContain`
- `CollectionAssert.AllItemsAreNotNull`
- `CollectionAssert.AllItemsAreUnique`
- `CollectionAssert.AllItemsAreInstancesOfType`
- `CollectionAssert.IsSubsetOf`
- `CollectionAssert.IsNotSubsetOf`
- `StringAssert.Contains`
- `StringAssert.StartsWith`
- `StringAssert.EndsWith`
- `StringAssert.Matches`
- `StringAssert.DoesNotMatch`

## Rule description

Conditional access returns `null` when its receiver is null, without evaluating the member access. An assertion on that result can fail because the receiver is missing rather than because the member has the wrong value. It can also pass unexpectedly if both values compare equal as null.

To make the test's preconditions and failures explicit, assert that an object is non-null before you assert its members. A separate null assertion tells you whether the object was missing or its contents were incorrect.

## How to fix violations

Ensure that arguments do not contain `(?.)` or `?[]` when passed to the assertion methods. Instead, perform null checks before making the assertion.

```csharp
Company? company = GetCompany();
Assert.AreEqual("Contoso", company?.Name); // MSTEST0026
StringAssert.Contains(company?.Address, "Brazil"); // MSTEST0026

// Fixed code
Assert.IsNotNull(company);
Assert.AreEqual("Contoso", company.Name);
StringAssert.Contains(company.Address, "Brazil");
```

## When to suppress warnings

Suppress the diagnostic if null propagation is itself the behavior you intend to verify. Otherwise, assert the expected non-null precondition explicitly.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0026
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0026
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0026.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
