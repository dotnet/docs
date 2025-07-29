---
title: "MSTEST0050: Global test fixture should be valid"
description: "Learn about code analysis rule MSTEST0050: Global test fixture should be valid"
ms.date: 07/29/2025
f1_keywords:
- MSTEST0050
- GlobalTestFixtureShouldBeValidAnalyzer
helpviewer_keywords:
- GlobalTestFixtureShouldBeValidAnalyzer
- MSTEST0050
author: Evangelink
ms.author: amauryleve
---
# MSTEST0050: Global test fixture should be valid

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0050                                                                               |
| **Title**                           | Global test fixture should be valid                                                     |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Error                                                                                    |
| **Introduced in version**           | 3.10.0                                                                                   |
| **Is there a code fix**             | No                                                                                       |

## Cause

A global test fixture method (marked with `GlobalTestInitializeAttribute` or `GlobalTestCleanupAttribute`) doesn't follow the required layout or has invalid configuration.

## Rule description

Global test fixture methods must follow specific requirements to ensure proper test execution. This rule validates that methods marked with `GlobalTestInitializeAttribute` or `GlobalTestCleanupAttribute` adhere to the correct method signature and configuration rules.

The method must be `public`, `static`, non-generic, have a single parameter of type `TestContext`, and return `void` or `Task`. In addition, the containing type must be `public`, `static`, non-generic, and be marked with `TestClassAttribute`.

## How to fix violations

Ensure that global test fixture methods follow the required layout.

## When to suppress warnings

Don't suppress warnings from this rule. Global test fixture methods with invalid layouts may not execute properly or may cause runtime errors.

## Example of a violation

```csharp
[TestClass]
public class GlobalTestFixture
{
    // Violation: AssemblyInitialize method should be static and take TestContext parameter
    [AssemblyInitialize]
    public void Setup()
    {
        // Setup code
    }
}
```

## Example of how to fix

```csharp
[TestClass]
public class GlobalTestFixture
{
    // Fixed: Correct method signature for AssemblyInitialize
    [AssemblyInitialize]
    public static void Setup(TestContext testContext)
    {
        // Setup code
    }
}
```
