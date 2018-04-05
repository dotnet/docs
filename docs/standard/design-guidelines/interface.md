---
title: "Interface Design"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "interfaces [.NET Framework], design guidelines"
  - "type design guidelines, interfaces"
  - "class library design guidelines [.NET Framework], interfaces"
ms.assetid: a016bd18-6710-4358-9438-9f190a295392
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Interface Design
Although most APIs are best modeled using classes and structs, there are cases in which interfaces are more appropriate or are the only option.  
  
 The CLR does not support multiple inheritance (i.e., CLR classes cannot inherit from more than one base class), but it does allow types to implement one or more interfaces in addition to inheriting from a base class. Therefore, interfaces are often used to achieve the effect of multiple inheritance. For example, <xref:System.IDisposable> is an interface that allows types to support disposability independent of any other inheritance hierarchy in which they want to participate.  
  
 The other situation in which defining an interface is appropriate is in creating a common interface that can be supported by several types, including some value types. Value types cannot inherit from types other than <xref:System.ValueType>, but they can implement interfaces, so using an interface is the only option in order to provide a common base type.  
  
 **✓ DO** define an interface if you need some common API to be supported by a set of types that includes value types.  
  
 **✓ CONSIDER** defining an interface if you need to support its functionality on types that already inherit from some other type.  
  
 **X AVOID** using marker interfaces (interfaces with no members).  
  
 If you need to mark a class as having a specific characteristic (marker), in general, use a custom attribute rather than an interface.  
  
 **✓ DO** provide at least one type that is an implementation of an interface.  
  
 Doing this helps to validate the design of the interface. For example, <xref:System.Collections.Generic.List%601> is an implementation of the <xref:System.Collections.Generic.IList%601> interface.  
  
 **✓ DO** provide at least one API that consumes each interface you define (a method taking the interface as a parameter or a property typed as the interface).  
  
 Doing this helps to validate the interface design. For example, <xref:System.Collections.Generic.List%601.Sort%2A?displayProperty=nameWithType> consumes the <xref:System.Collections.Generic.IComparer%601?displayProperty=nameWithType> interface.  
  
 **X DO NOT** add members to an interface that has previously shipped.  
  
 Doing so would break implementations of the interface. You should create a new interface in order to avoid versioning problems.  
  
 Except for the situations described in these guidelines, you should, in general, choose classes rather than interfaces in designing managed code reusable libraries.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Type Design Guidelines](../../../docs/standard/design-guidelines/type.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
