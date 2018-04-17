---
title: "Type Design Guidelines"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "type design guidelines"
  - "type design guidelines, about type design guidelines"
  - "class library design guidelines [.NET Framework], type design guidelines"
  - "types [.NET Framework], design guidelines"
ms.assetid: 6b49314e-8bba-43ea-97ca-4e0255812f95
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Type Design Guidelines
From the CLR perspective, there are only two categories of types—reference types and value types—but for the purpose of a discussion about framework design, we divide types into more logical groups, each with its own specific design rules.  
  
 Classes are the general case of reference types. They make up the bulk of types in the majority of frameworks. Classes owe their popularity to the rich set of object-oriented features they support and to their general applicability. Base classes and abstract classes are special logical groups related to extensibility.  
  
 Interfaces are types that can be implemented by both reference types and value types. They can thus serve as roots of polymorphic hierarchies of reference types and value types. In addition, interfaces can be used to simulate multiple inheritance, which is not natively supported by the CLR.  
  
 Structs are the general case of value types and should be reserved for small, simple types, similar to language primitives.  
  
 Enums are a special case of value types used to define short sets of values, such as days of the week, console colors, and so on.  
  
 Static classes are types intended to be containers for static members. They are commonly used to provide shortcuts to other operations.  
  
 Delegates, exceptions, attributes, arrays, and collections are all special cases of reference types intended for specific uses, and guidelines for their design and usage are discussed elsewhere in this book.  
  
 **✓ DO** ensure that each type is a well-defined set of related members, not just a random collection of unrelated functionality.  
  
## In This Section  
 [Choosing Between Class and Struct](../../../docs/standard/design-guidelines/choosing-between-class-and-struct.md)  
 [Abstract Class Design](../../../docs/standard/design-guidelines/abstract-class.md)  
 [Static Class Design](../../../docs/standard/design-guidelines/static-class.md)  
 [Interface Design](../../../docs/standard/design-guidelines/interface.md)  
 [Struct Design](../../../docs/standard/design-guidelines/struct.md)  
 [Enum Design](../../../docs/standard/design-guidelines/enum.md)  
 [Nested Types](../../../docs/standard/design-guidelines/nested-types.md)  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
