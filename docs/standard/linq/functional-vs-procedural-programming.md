---
title: Functional vs. procedural programming
description: LINQ to XML supports both functional construction and procedural techniques for creating XML applications. Functional construction is a declarative approach. The procedural techniques support in-memory modification of XML trees.
ms.date: 07/20/2015
ms.assetid: fc64e39c-a487-4882-9169-da4de97917d9
ms.topic: article
---

# Functional vs. procedural programming (LINQ to XML)

There are various types of XML applications:

- Some applications take source XML documents, and produce new XML documents that are in a different shape than the source documents.
- Some applications take source XML documents, and produce result documents in an entirely different form, such as HTML or CSV text files.
- Some applications take source XML documents, and insert records into a database.
- Some applications take data from another source, such as a database, and create XML documents from it.

These aren't all of the types of XML applications, but these are a representative set of the types of functionality that an XML programmer has to implement.

With all of these types of applications, there are two contrasting approaches that a developer can take:

- Functional construction using a declarative approach.
- In-memory XML tree modification using procedural code.

LINQ to XML supports both approaches.

When using the functional approach, you write transformations that take the source documents and generate completely new result documents with the desired shape.

When modifying an XML tree in place, you write code that traverses and navigates through nodes in an in-memory XML tree, inserting, deleting, and modifying nodes as necessary.

You can use LINQ to XML with either approach. You use the same classes, and in some cases the same methods. However, the structure and goals of the two approaches are different. For example, in different situations, one or the other approach will often have better performance, and use more or less memory. In addition, one or the other approach will be easier to write and yield more maintainable code.

To see the two approaches contrasted, see [In-memory XML tree modification vs. functional construction](in-memory-xml-tree-modification-vs-functional-construction.md).

For a tutorial on writing functional transformations, see [Introduction to pure functional transformations](introduction-pure-functional-transformations.md).
