---
title: "Struct Design"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "class library design guidelines [.NET Framework], structures"
  - "deallocating structures"
  - "allocating structures"
  - "value types, structures"
  - "structure design"
  - "type design guidelines, structures"
  - "structures [.NET Framework], design guidelines"
ms.assetid: 1f48b2d8-608c-4be6-9ba4-d8f203ed9f9f
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Struct Design
The general-purpose value type is most often referred to as a struct, its C# keyword. This section provides guidelines for general struct design.  
  
 **X DO NOT** provide a default constructor for a struct.  
  
 Following this guideline allows arrays of structs to be created without having to run the constructor on each item of the array. Notice that C# does not allow structs to have default constructors.  
  
 **X DO NOT** define mutable value types.  
  
 Mutable value types have several problems. For example, when a property getter returns a value type, the caller receives a copy. Because the copy is created implicitly, developers might not be aware that they are mutating the copy, and not the original value. Also, some languages (dynamic languages, in particular) have problems using mutable value types because even local variables, when dereferenced, cause a copy to be made.  
  
 **✓ DO** ensure that a state where all instance data is set to zero, false, or null (as appropriate) is valid.  
  
 This prevents accidental creation of invalid instances when an array of the structs is created.  
  
 **✓ DO** implement <xref:System.IEquatable%601> on value types.  
  
 The <xref:System.Object.Equals%2A?displayProperty=nameWithType> method on value types causes boxing, and its default implementation is not very efficient, because it uses reflection. <xref:System.IEquatable%601.Equals%2A> can have much better performance and can be implemented so that it will not cause boxing.  
  
 **X DO NOT** explicitly extend <xref:System.ValueType>. In fact, most languages prevent this.  
  
 In general, structs can be very useful but should only be used for small, single, immutable values that will not be boxed frequently.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Type Design Guidelines](../../../docs/standard/design-guidelines/type.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Choosing Between Class and Struct](../../../docs/standard/design-guidelines/choosing-between-class-and-struct.md)
