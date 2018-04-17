---
title: "Field Design"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "fields, design guidelines"
  - "read-only fields"
  - "member design guidelines, fields"
ms.assetid: 7cb4b0f3-7a10-4c93-b84d-733f7134fcf8
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Field Design
The principle of encapsulation is one of the most important notions in object-oriented design. This principle states that data stored inside an object should be accessible only to that object.  
  
 A useful way to interpret the principle is to say that a type should be designed so that changes to fields of that type (name or type changes) can be made without breaking code other than for members of the type. This interpretation immediately implies that all fields must be private.  
  
 We exclude constant and static read-only fields from this strict restriction, because such fields, almost by definition, are never required to change.  
  
 **X DO NOT** provide instance fields that are public or protected.  
  
 You should provide properties for accessing fields instead of making them public or protected.  
  
 **✓ DO** use constant fields for constants that will never change.  
  
 The compiler burns the values of const fields directly into calling code. Therefore, const values can never be changed without the risk of breaking compatibility.  
  
 **✓ DO** use public static `readonly` fields for predefined object instances.  
  
 If there are predefined instances of the type, declare them as public read-only static fields of the type itself.  
  
 **X DO NOT** assign instances of mutable types to `readonly` fields.  
  
 A mutable type is a type with instances that can be modified after they are instantiated. For example, arrays, most collections, and streams are mutable types, but <xref:System.Int32?displayProperty=nameWithType>, <xref:System.Uri?displayProperty=nameWithType>, and <xref:System.String?displayProperty=nameWithType> are all immutable. The read-only modifier on a reference type field prevents the instance stored in the field from being replaced, but it does not prevent the field’s instance data from being modified by calling members changing the instance.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Member Design Guidelines](../../../docs/standard/design-guidelines/member.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
