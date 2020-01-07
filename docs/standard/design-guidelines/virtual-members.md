---
title: "Virtual Members"
ms.date: "10/22/2008"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "overridable members"
  - "virtual members"
  - "members [.NET Framework], virtual"
ms.assetid: 8ff4eb97-0364-43ec-8a02-934b5cd94d19
---
# Virtual Members
Virtual members can be overridden, thus changing the behavior of the subclass. They are quite similar to callbacks in terms of the extensibility they provide, but they are better in terms of execution performance and memory consumption. Also, virtual members feel more natural in scenarios that require creating a special kind of an existing type (specialization).  
  
 Virtual members perform better than callbacks and events, but do not perform better than non-virtual methods.  
  
 The main disadvantage of virtual members is that the behavior of a virtual member can only be modified at the time of compilation. The behavior of a callback can be modified at runtime.  
  
 Virtual members, like callbacks (and maybe more than callbacks), are costly to design, test, and maintain because any call to a virtual member can be overridden in unpredictable ways and can execute arbitrary code. Also, much more effort is usually required to clearly define the contract of virtual members, so the cost of designing and documenting them is higher.  
  
 **X DO NOT** make members virtual unless you have a good reason to do so and you are aware of all the costs related to designing, testing, and maintaining virtual members.  
  
 Virtual members are less forgiving in terms of changes that can be made to them without breaking compatibility. Also, they are slower than non-virtual members, mostly because calls to virtual members are not inlined.  
  
 **✓ CONSIDER** limiting extensibility to only what is absolutely necessary.  
  
 **✓ DO** prefer protected accessibility over public accessibility for virtual members. Public members should provide extensibility (if required) by calling into a protected virtual member.  
  
 The public members of a class should provide the right set of functionality for direct consumers of that class. Virtual members are designed to be overridden in subclasses, and protected accessibility is a great way to scope all virtual extensibility points to where they can be used.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See also

- [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
- [Designing for Extensibility](../../../docs/standard/design-guidelines/designing-for-extensibility.md)
