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

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotSame*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreSame*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotInstanceOfType*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsExceptionAsync*>

## The `StringAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert> class to compare and examine strings. Available APIs are:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Contains*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.DoesNotMatch*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.EndsWith*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.Matches*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.StringAssert.StartsWith*>

## The `CollectionAssert` class

Use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert> class to compare collections of objects, or to verify the state of a collection. Available APIs are:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreInstancesOfType*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreNotNull*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AllItemsAreUnique*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEqual*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreEquivalent*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreNotEqual*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.AreNotEquivalent*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.Contains*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.DoesNotContain*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.IsNotSubsetOf*>
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert.IsSubsetOf*>
