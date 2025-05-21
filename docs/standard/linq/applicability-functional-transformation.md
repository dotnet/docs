---
title: Applicability of functional transformation - LINQ to XML
description: Learn when you can make use of functional transformations.
ms.date: 07/20/2015
ms.assetid: c78107bd-b006-4574-a3d4-bbf808388ff3
ms.topic: article
---

# Applicability of functional transformation (LINQ to XML)

Pure functional transformations are applicable in a wide variety of situations.

The functional transformation approach is ideally suited for querying and manipulating structured data; therefore it fits well with LINQ technologies. However, functional transformation has a much wider applicability than use with LINQ. Any process where the main focus is on transforming data from one form to another should probably be considered as a candidate for functional transformation.

This approach is applicable to many problems that might not appear at first glance to be a candidate. Used in conjunction with or separately from LINQ, functional transformation should be considered for the following areas:

- XML-based documents. Well-formed data of any XML dialect can be easily manipulated through functional transformation. For more information, see [Functional transformation of XML](functional-transformation-xml.md).
- Other structured file formats. From Windows.ini files to plain text documents, most files have some structure that lends itself to analysis and transformation.
- Data streaming protocols. Encoding data into and decoding data from communication protocols can often be represented by a simple functional transform.
- RDBMS and OODBMS data. Relational and object-oriented databases, just like XML, are widely-used structured data sources.
- Mathematic, statistic, and science solutions. These fields tend to manipulate large data sets to assist the user in visualizing, estimating, or actually solving non-trivial problems.

As described in [Refactor into pure functions](refactor-pure-functions.md), using pure functions is an example of functional programming. In additional to their immediate benefits, using pure functions provides valuable experience in thinking about problems from a functional transformation perspective. This approach can also have major impact on program and class design. This is especially true when a problem lends itself to a data transformation solution as described above.

Although they're beyond the scope of this tutorial, designs that are influenced by the functional transformation perspective tend to center on processes more than on objects as actors, and the resulting solution tends to be implemented as a series of large-scale transformations, rather than individual object state changes.

 Again, remember that C# and Visual Basic support both imperative and functional approaches, so the best design for your application might incorporate elements of both.

## See also

- [Introduction to pure functional transformations](introduction-pure-functional-transformations.md)
- [Functional transformation of XML](functional-transformation-xml.md)
- [Refactor into pure functions](refactor-pure-functions.md)
