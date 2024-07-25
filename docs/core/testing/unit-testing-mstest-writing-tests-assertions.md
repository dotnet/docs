---
title: MSTest assertions
description: Learn about MSTest assertions.
author: Evangelink
ms.author: amauryleve
ms.date: 07/24/2024
---

# MSTest assertions

Use the `Assert` classes of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace to verify specific functionality. A test method exercises the code of a method in your application's code, but it reports the correctness of the code's behavior only if you include `Assert` statements.

## The `Assert` class

In your test method, you can call any methods of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert?displayProperty=fullName> class, such as <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual%2A?displayProperty=nameWithType>. The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> class has many methods to choose from, and many of the methods have several overloads.

## The `StringAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> class to compare and examine strings. This class contains a variety of useful methods, such as <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Contains%2A?displayProperty=nameWithType>, <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Matches%2A?displayProperty=nameWithType>, and <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.StartsWith%2A?displayProperty=nameWithType>.

## The `CollectionAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> class to compare collections of objects, or to verify the state of a collection.
