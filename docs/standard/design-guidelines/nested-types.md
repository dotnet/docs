---
title: "Nested Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "types, nested"
  - "public nested types"
  - "type design guidelines, nested types"
  - "nested types"
  - "members [.NET Framework], type"
  - "class library design guidelines [.NET Framework], nested types"
ms.assetid: 12feb7f0-b793-4d96-b090-42d6473bab8c
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Nested Types
A nested type is a type defined within the scope of another type, which is called the enclosing type. A nested type has access to all members of its enclosing type. For example, it has access to private fields defined in the enclosing type and to protected fields defined in all ascendants of the enclosing type.  
  
 In general, nested types should be used sparingly. There are several reasons for this. Some developers are not fully familiar with the concept. These developers might, for example, have problems with the syntax of declaring variables of nested types. Nested types are also very tightly coupled with their enclosing types, and as such are not suited to be general-purpose types.  
  
 Nested types are best suited for modeling implementation details of their enclosing types. The end user should rarely have to declare variables of a nested type and almost never should have to explicitly instantiate nested types. For example, the enumerator of a collection can be a nested type of that collection. Enumerators are usually instantiated by their enclosing type, and because many languages support the foreach statement, enumerator variables rarely have to be declared by the end user.  
  
 **✓ DO** use nested types when the relationship between the nested type and its outer type is such that member-accessibility semantics are desirable.  
  
 **X DO NOT** use public nested types as a logical grouping construct; use namespaces for this.  
  
 **X AVOID** publicly exposed nested types. The only exception to this is if variables of the nested type need to be declared only in rare scenarios such as subclassing or other advanced customization scenarios.  
  
 **X DO NOT** use nested types if the type is likely to be referenced outside of the containing type.  
  
 For example, an enum passed to a method defined on a class should not be defined as a nested type in the class.  
  
 **X DO NOT** use nested types if they need to be instantiated by client code.  If a type has a public constructor, it should probably not be nested.  
  
 If a type can be instantiated, that seems to indicate the type has a place in the framework on its own (you can create it, work with it, and destroy it without ever using the outer type), and thus should not be nested. Inner types should not be widely reused outside of the outer type without any relationship whatsoever to the outer type.  
  
 **X DO NOT** define a nested type as a member of an interface. Many languages do not support such a construct.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Type Design Guidelines](../../../docs/standard/design-guidelines/type.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
