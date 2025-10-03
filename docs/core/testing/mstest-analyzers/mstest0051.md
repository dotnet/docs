---
title: "MSTEST0051: Assert.Throws should contain only a single statement"
description: "Learn about code analysis rule MSTEST0051: Assert.Throws should contain only a single statement"
ms.date: 10/01/2025
f1_keywords:
- MSTEST0051
- AssertThrowsShouldContainSingleStatementAnalyzer
helpviewer_keywords:
- AssertThrowsShouldContainSingleStatementAnalyzer
- MSTEST0051
author: Youssef1313
ms.author: ygerges
ai-usage: ai-generated
---
# MSTEST0051: Assert.Throws should contain only a single statement

| Property                            | Value                                                                                    |
|-------------------------------------|------------------------------------------------------------------------------------------|
| **Rule ID**                         | MSTEST0051                                                                               |
| **Title**                           | Assert.Throws should contain only a single statement                                     |
| **Category**                        | Usage                                                                                    |
| **Fix is breaking or non-breaking** | Non-breaking                                                                             |
| **Enabled by default**              | Yes                                                                                      |
| **Default severity**                | Info                                                                                     |
| **Introduced in version**           | 3.11.0                                                                                   |
| **Is there a code fix**             | No                                                                                       |

## Cause

A call to <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Throws%2A>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsAsync%2A>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExactly%2A>, or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExactlyAsync%2A> contains multiple statements in the action delegate.

## Rule description

To ensure that only the specific method call that is expected to throw an exception is tested, the action delegate passed to `Assert.Throws`, `Assert.ThrowsAsync`, `Assert.ThrowsExactly`, or `Assert.ThrowsExactlyAsync` should contain exactly one statement. Including multiple statements can lead to passing tests when the exception is thrown by a statement that is not intended to throw. If it's not the last statement in the action that is intended to throw, then the test has dead code. If it's the last statement, the intent should be clearly stated.

## How to fix violations

Refactor the test to ensure that the action delegate contains only the single statement that is expected to throw the exception. Move any setup code outside the assertion call.

For example, change this:

```csharp
[TestMethod]
public void TestMethod()
{
    var obj = new MyClass();
    Assert.ThrowsExactly<InvalidOperationException>(() =>
    {
        obj.Initialize();
        obj.Execute(); // Only this should be inside the assertion
    });
}
```

To this:

```csharp
[TestMethod]
public void TestMethod()
{
    var obj = new MyClass();
    obj.Initialize();
    Assert.ThrowsExactly<InvalidOperationException>(() => obj.Execute());
}
```

## When to suppress warnings

Don't suppress warnings from this rule. Including multiple statements in the action delegate can make it unclear which operation is being tested and can lead to passing tests when the original intent is violated.
