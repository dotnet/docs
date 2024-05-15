---
title: "MSTEST0026: Avoid conditional access in assertions"
description: "Learn about code analysis rule MSTEST0026: Avoid conditional access in assertions"
ms.date: 05/15/2024
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
| **Enabled by default**              | Yes                                                   |
| **Default severity**                | Info                                                  |
| **Introduced in version**           | 3.5.0                                                 |

## Cause

This rule raises a diagnostic when an argument containing a conditional access is passed to the `Assert`, `CollectionAssert` or `StringAssert`  assertion methods below:

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

## How to fix violations

Ensure that arguments do not contain conditional access when passed to the assertion methods.

```csharp
Company? company = GetCompany();
Assert.AreEqual(company?.Name, "Contoso"); // MSTEST0026
StringAssert.Contains(company?.Address, "Brazil"); // MSTEST0026

// Fixed code
Assert.IsNotNull(company);
Assert.AreEqual(company.Name, "Contoso");
StringAssert.Contains(company.Address, "Brazil");
```

## When to suppress warnings

We do not recommend suppressing warnings from this rule.
