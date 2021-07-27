---
description: "Learn more about design guidelines for arrays"
title: "Arrays (.NET Framework design guidelines)"
titleSuffix: ""
ms.date: "10/22/2008"
helpviewer_keywords:
  - "class library design guidelines [.NET Framework], arrays"
  - "arrays [.NET Framework], usage guidelines"
  - "empty arrays"
---
# Arrays (.NET Framework design guidelines)

✔️ DO prefer using collections over arrays in public APIs. The [Collections](guidelines-for-collections.md) section provides details about how to choose between collections and arrays.

 ❌ DO NOT use read-only array fields. The field itself is read-only and can't be changed, but elements in the array can be changed.

 ✔️ CONSIDER using jagged arrays instead of multidimensional arrays.

 A jagged array is an array with elements that are also arrays. The arrays that make up the elements can be of different sizes, leading to less wasted space for some sets of data (e.g., sparse matrix) compared to multidimensional arrays. Furthermore, the CLR optimizes index operations on jagged arrays, so they might exhibit better runtime performance in some scenarios.

 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*

 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*

## See also

- <xref:System.Array>
- [Framework Design Guidelines](index.md)
- [Usage Guidelines](usage-guidelines.md)
