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

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> class to verify that the code under test behaves as expected. Available APIs are:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotSame*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotInstanceOfType*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExceptionAsync*?displayProperty=nameWithType>

## The `StringAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> class to compare and examine strings. Available APIs are:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Contains*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.DoesNotMatch*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.EndsWith*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Matches*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.StartsWith*?displayProperty=nameWithType>

## The `CollectionAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> class to compare collections of objects, or to verify the state of a collection. Available APIs are:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreInstancesOfType*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreNotNull*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreUnique*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEqual*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEquivalent*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreNotEqual*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreNotEquivalent*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.Contains*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.DoesNotContain*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.IsNotSubsetOf*?displayProperty=nameWithType>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.IsSubsetOf*?displayProperty=nameWithType>
