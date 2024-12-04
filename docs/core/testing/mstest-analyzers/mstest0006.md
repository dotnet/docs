---
title: "MSTEST0006: Avoid '[ExpectedException]'"
description: "Learn about code analysis rule MSTEST0006: Avoid '[ExpectedException]'"
ms.date: 11/12/2024
f1_keywords:
- MSTEST0006
- AvoidExpectedExceptionAttributeAnalyzer
helpviewer_keywords:
- AvoidExpectedExceptionAttributeAnalyzer
- MSTEST0006
author: evangelink
ms.author: amauryleve
dev_langs:
- CSharp
- VB
---
# MSTEST0006: Avoid `[ExpectedException]`

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0006                                         |
| **Title**                           | Avoid `[ExpectedException]`                        |
| **Category**                        | Design                                             |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Info                                               |
| **Introduced in version**           | 3.2.0                                              |
| **Is there a code fix**             | Yes, starting with 3.7.0                           |

## Cause

A method is marked with the `[ExpectedException]` attribute.

## Rule description

Prefer `Assert.ThrowsException` or `Assert.ThrowsExceptionAsync` over the `[ExpectedException]` attribute as it ensures that only the expected line of code throws the expected exception, instead of acting on the whole body of the test. The assert APIs also provide more flexibility and allow you to assert extra properties of the exception.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))] // Violation
    public void TestMethod()
    {
        // Arrange
        var person = new Person
        {
            FirstName = "John", 
            LastName = "Doe",
        };
        person.SetAge(-1);

        // Act
        person.GrowOlder();
    }
}
```

## How to fix violations

Replace the usage of the `[ExpectedException]` attribute by a call to `Assert.ThrowsException` or `Assert.ThrowsExceptionAsync`.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    public void TestMethod()
    {
        // Arrange
        var person = new Person
        {
            FirstName = "John", 
            LastName = "Doe",
        };
        person.SetAge(-1);

        // Act
        Assert.ThrowsException(() => person.GrowOlder());
    }
}
```

## When to suppress warnings

It is safe to suppress this diagnostic when the method is a one-liner.

```csharp
[TestClass]
public class TestClass
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestMethod()
    {
        new Person(null);
    }
}
```
