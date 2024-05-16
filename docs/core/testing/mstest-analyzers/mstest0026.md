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

This rule raises a diagnostic when an argument containing a conditional access `(?.)` is passed to the assertion methods below:

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

The purpose of assertions in unit tests is to verify that certain conditions are met. When a conditional access is used in an assertion, it introduces an additional condition that may or may not be met, depending on the state of the object being accessed. This can lead to inconsistent test results and make test less clear.

## How to fix violations

Ensure that arguments do not contain conditional access `(?.)` when passed to the assertion methods. Instead, perform null checks before making the assertion.

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
