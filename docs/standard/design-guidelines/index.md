---
title: "Framework Design Guidelines"
description: See framework design guidelines for designing libraries that extend and interact with .NET, to ensure API consistency and ease of use.
titleSuffix: ""
ms.date: "10/22/2008"
helpviewer_keywords:
  - "libraries, .NET Framework class library"
  - "class library design guidelines [.NET Framework], about"
  - "class library design guidelines [.NET]"
ms.assetid: 5fbcaf4f-ea2a-4d20-b0d6-e61dee202b4b
ms.topic: article
---
# Framework design guidelines

This section provides guidelines for designing libraries that extend and interact with .NET. The goal is to help library designers ensure API consistency and ease of use by providing a unified programming model that is independent of the programming language used for development. We recommend that you follow these design guidelines when developing classes and components that extend .NET. Inconsistent library design adversely affects developer productivity and discourages adoption.

 The guidelines are organized as simple recommendations prefixed with the terms `Do`, `Consider`, `Avoid`, and `Do not`. These guidelines are intended to help class library designers understand the trade-offs between different solutions. There might be situations where good library design requires that you violate these design guidelines. Such cases should be rare, and it is important that you have a clear and compelling reason for your decision.

 These guidelines are excerpted from the book *Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition*, by Krzysztof Cwalina and Brad Abrams, which was published in 2008. The book has since been fully revised in the [third edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780135896464). Some of the information in these guidelines may be out-of-date.

## In this section

 [Naming Guidelines](naming-guidelines.md)\
 Provides guidelines for naming assemblies, namespaces, types, and members in class libraries.

 [Type Design Guidelines](type.md)\
 Provides guidelines for using static and abstract classes, interfaces, enumerations, structures, and other types.

 [Member Design Guidelines](member.md)\
 Provides guidelines for designing and using properties, methods, constructors, fields, events, operators, and parameters.

 [Designing for Extensibility](designing-for-extensibility.md)\
 Discusses extensibility mechanisms such as subclassing, using events, virtual members, and callbacks, and explains how to choose the mechanisms that best meet your framework's requirements.

 [Design Guidelines for Exceptions](exceptions.md)\
 Describes design guidelines for designing, throwing, and catching exceptions.

 [Usage Guidelines](usage-guidelines.md)\
 Describes guidelines for using common types such as arrays, attributes, and collections, supporting serialization, and overloading equality operators.

 [Common Design Patterns](common-design-patterns.md)\
 Provides guidelines for choosing and implementing dependency properties and the dispose pattern.

 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*

 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*
