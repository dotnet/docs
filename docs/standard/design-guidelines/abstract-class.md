---
title: "Abstract Class Design"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "type design guidelines, abstract classes"
  - "abstract classes, design guidelines"
  - "class library design guidelines [.NET Framework], classes"
  - "classes [.NET Framework], abstract"
  - "classes [.NET Framework], design guidelines"
  - "type design guidelines, classes"
ms.assetid: d3646e6d-5c1f-4922-8fb0-ec5effb30d60
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Abstract Class Design
**X DO NOT** define public or protected internal constructors in abstract types.  
  
 Constructors should be public only if users will need to create instances of the type. Because you cannot create instances of an abstract type, an abstract type with a public constructor is incorrectly designed and misleading to the users.  
  
 **✓ DO** define a protected or an internal constructor in abstract classes.  
  
 A protected constructor is more common and simply allows the base class to do its own initialization when subtypes are created.  
  
 An internal constructor can be used to limit concrete implementations of the abstract class to the assembly defining the class.  
  
 **✓ DO** provide at least one concrete type that inherits from each abstract class that you ship.  
  
 Doing this helps to validate the design of the abstract class. For example,  <xref:System.IO.FileStream?displayProperty=nameWithType> is an implementation of the <xref:System.IO.Stream?displayProperty=nameWithType> abstract class.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Type Design Guidelines](../../../docs/standard/design-guidelines/type.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
