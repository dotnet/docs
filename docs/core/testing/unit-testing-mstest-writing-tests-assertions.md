---
title: MSTest assertions
description: Learn about MSTest assertions.
author: Evangelink
ms.author: amauryleve
ms.date: 07/24/2024
---

# Assertions

Use the Assert classes of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace to verify specific functionality. A test method exercises the code of a method in your application's code, but it reports the correctness of the code's behavior only if you include Assert statements.

## Assertions exceptions

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.UnitTestAssertException> is the base of all assertion exceptions thrown by MSTest. If you write a new assert exception class, inherit from this base class to make it easier to identify the exception as an assertion failure instead of an unexpected exception thrown from your test or production code.

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException> exception is thrown whenever a test fails. A test fails if it times out, throws an unexpected exception, or contains an assert statement that produces a **Failed** result.

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssertInconclusiveException> is thrown whenever a test produces an **Inconclusive** result. Typically, you add an <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive%2A?displayProperty=nameWithType> statement to a test that you are still working on, to indicate it's not yet ready to be run. This is also useful when you want to skip a test based on certain runtime conditions.

## The `Assert` class

In your test method, you can call any methods of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert?displayProperty=fullName> class, such as <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual%2A?displayProperty=nameWithType>. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> class has many methods to choose from, and many of the methods have several overloads.

## The `StringAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> class to compare and examine strings. This class contains a variety of useful methods, such as <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Contains%2A?displayProperty=nameWithType>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Matches%2A?displayProperty=nameWithType>, and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.StartsWith%2A?displayProperty=nameWithType>.

## The `CollectionAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> class to compare collections of objects, or to verify the state of a collection.
