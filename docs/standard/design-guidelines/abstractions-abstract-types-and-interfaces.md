---
title: "Abstractions (Abstract Types and Interfaces)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "interfaces [.NET Framework], abstract"
  - "abstract interfaces [.NET Framework]"
  - "abstract types [.NET Framework]"
  - "types [.NET Framework], abstract"
ms.assetid: 0a632bc7-9b03-44ee-8842-c82f88672a45
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Abstractions (Abstract Types and Interfaces)
An abstraction is a type that describes a contract but does not provide a full implementation of the contract. Abstractions are usually implemented as abstract classes or interfaces, and they come with a well-defined set of reference documentation describing the required semantics of the types implementing the contract. Some of the most important abstractions in the .NET Framework include <xref:System.IO.Stream>, <xref:System.Collections.Generic.IEnumerable%601>, and <xref:System.Object>.  
  
 You can extend frameworks by implementing a concrete type that supports the contract of an abstraction and using this concrete type with framework APIs consuming (operating on) the abstraction.  
  
 A meaningful and useful abstraction that is able to withstand the test of time is very difficult to design. The main difficulty is getting the right set of members, no more and no fewer. If an abstraction has too many members, it becomes difficult or even impossible to implement. If it has too few members for the promised functionality, it becomes useless in many interesting scenarios.  
  
 Too many abstractions in a framework also negatively affect usability of the framework. It is often quite difficult to understand an abstraction without understanding how it fits into the larger picture of the concrete implementations and the APIs operating on the abstraction. Also, names of abstractions and their members are necessarily abstract, which often makes them cryptic and unapproachable without first understanding the broader context of their usage.  
  
 However, abstractions provide extremely powerful extensibility that the other extensibility mechanisms cannot often match. They are at the core of many architectural patterns, such as plug-ins, inversion of control (IoC), pipelines, and so on. They are also extremely important for testability of frameworks. Good abstractions make it possible to stub out heavy dependencies for the purpose of unit testing. In summary, abstractions are responsible for the sought-after richness of the modern object-oriented frameworks.  
  
 **X DO NOT** provide abstractions unless they are tested by developing several concrete implementations and APIs consuming the abstractions.  
  
 **✓ DO** choose carefully between an abstract class and an interface when designing an abstraction.  
  
 **✓ CONSIDER** providing reference tests for concrete implementations of abstractions. Such tests should allow users to test whether their implementations correctly implement the contract.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Designing for Extensibility](../../../docs/standard/design-guidelines/designing-for-extensibility.md)
