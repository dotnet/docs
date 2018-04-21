---
title: "Constructor Design"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "member design guidelines, constructors"
  - "constructors, design guidelines"
  - "instance constructors"
  - "type constructors"
  - "virtual members"
  - "constructors, types"
  - "default constructors"
  - "static constructors"
ms.assetid: b4496afe-5fa7-4bb0-85ca-70b0ef21e6fc
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Constructor Design
There are two kinds of constructors: type constructors and instance constructors.  
  
 Type constructors are static and are run by the CLR before the type is used. Instance constructors run when an instance of a type is created.  
  
 Type constructors cannot take any parameters. Instance constructors can. Instance constructors that don’t take any parameters are often called default constructors.  
  
 Constructors are the most natural way to create instances of a type. Most developers will search and try to use a constructor before they consider alternative ways of creating instances (such as factory methods).  
  
 **✓ CONSIDER** providing simple, ideally default, constructors.  
  
 A simple constructor has a very small number of parameters, and all parameters are primitives or enums. Such simple constructors increase usability of the framework.  
  
 **✓ CONSIDER** using a static factory method instead of a constructor if the semantics of the desired operation do not map directly to the construction of a new instance, or if following the constructor design guidelines feels unnatural.  
  
 **✓ DO** use constructor parameters as shortcuts for setting main properties.  
  
 There should be no difference in semantics between using the empty constructor followed by some property sets and using a constructor with multiple arguments.  
  
 **✓ DO** use the same name for constructor parameters and a property if the constructor parameters are used to simply set the property.  
  
 The only difference between such parameters and the properties should be casing.  
  
 **✓ DO** minimal work in the constructor.  
  
 Constructors should not do much work other than capture the constructor parameters. The cost of any other processing should be delayed until required.  
  
 **✓ DO** throw exceptions from instance constructors, if appropriate.  
  
 **✓ DO** explicitly declare the public default constructor in classes, if such a constructor is required.  
  
 If you don’t explicitly declare any constructors on a type, many languages (such as C#) will automatically add a public default constructor. (Abstract classes get a protected constructor.)  
  
 Adding a parameterized constructor to a class prevents the compiler from adding the default constructor. This often causes accidental breaking changes.  
  
 **X AVOID** explicitly defining default constructors on structs.  
  
 This makes array creation faster, because if the default constructor is not defined, it does not have to be run on every slot in the array. Note that many compilers, including C#, don’t allow structs to have parameterless constructors for this reason.  
  
 **X AVOID** calling virtual members on an object inside its constructor.  
  
 Calling a virtual member will cause the most derived override to be called, even if the constructor of the most derived type has not been fully run yet.  
  
### Type Constructor Guidelines  
 **✓ DO** make static constructors private.  
  
 A static constructor, also called a class constructor, is used to initialize a type. The CLR calls the static constructor before the first instance of the type is created or any static members on that type are called. The user has no control over when the static constructor is called. If a static constructor is not private, it can be called by code other than the CLR. Depending on the operations performed in the constructor, this can cause unexpected behavior. The C# compiler forces static constructors to be private.  
  
 **X DO NOT** throw exceptions from static constructors.  
  
 If an exception is thrown from a type constructor, the type is not usable in the current application domain.  
  
 **✓ CONSIDER** initializing static fields inline rather than explicitly using static constructors, because the runtime is able to optimize the performance of types that don’t have an explicitly defined static constructor.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Member Design Guidelines](../../../docs/standard/design-guidelines/member.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
