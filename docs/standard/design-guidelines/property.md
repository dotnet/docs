---
title: "Property Design"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "member design guidelines, properties"
  - "properties [.NET Framework], design guidelines"
ms.assetid: 127cbc0c-cbed-48fd-9c89-7c5d4f98f163
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Property Design
Although properties are technically very similar to methods, they are quite different in terms of their usage scenarios. They should be seen as smart fields. They have the calling syntax of fields, and the flexibility of methods.  
  
 **✓ DO** create get-only properties if the caller should not be able to change the value of the property.  
  
 Keep in mind that if the type of the property is a mutable reference type, the property value can be changed even if the property is get-only.  
  
 **X DO NOT** provide set-only properties or properties with the setter having broader accessibility than the getter.  
  
 For example, do not use properties with a public setter and a protected getter.  
  
 If the property getter cannot be provided, implement the functionality as a method instead. Consider starting the method name with `Set` and follow with what you would have named the property. For example, <xref:System.AppDomain> has a method called `SetCachePath` instead of having a set-only property called `CachePath`.  
  
 **✓ DO** provide sensible default values for all properties, ensuring that the defaults do not result in a security hole or terribly inefficient code.  
  
 **✓ DO** allow properties to be set in any order even if this results in a temporary invalid state of the object.  
  
 It is common for two or more properties to be interrelated to a point where some values of one property might be invalid given the values of other properties on the same object. In such cases, exceptions resulting from the invalid state should be postponed until the interrelated properties are actually used together by the object.  
  
 **✓ DO** preserve the previous value if a property setter throws an exception.  
  
 **X AVOID** throwing exceptions from property getters.  
  
 Property getters should be simple operations and should not have any preconditions. If a getter can throw an exception, it should probably be redesigned to be a method. Notice that this rule does not apply to indexers, where we do expect exceptions as a result of validating the arguments.  
  
### Indexed Property Design  
 An indexed property is a special property that can have parameters and can be called with special syntax similar to array indexing.  
  
 Indexed properties are commonly referred to as indexers. Indexers should be used only in APIs that provide access to items in a logical collection. For example, a string is a collection of characters, and the indexer on <xref:System.String?displayProperty=nameWithType> was added to access its characters.  
  
 **✓ CONSIDER** using indexers to provide access to data stored in an internal array.  
  
 **✓ CONSIDER** providing indexers on types representing collections of items.  
  
 **X AVOID** using indexed properties with more than one parameter.  
  
 If the design requires multiple parameters, reconsider whether the property really represents an accessor to a logical collection. If it does not, use methods instead. Consider starting the method name with `Get` or `Set`.  
  
 **X AVOID** indexers with parameter types other than <xref:System.Int32?displayProperty=nameWithType>, <xref:System.Int64?displayProperty=nameWithType>, <xref:System.String?displayProperty=nameWithType>, <xref:System.Object?displayProperty=nameWithType>, or an enum.  
  
 If the design requires other types of parameters, strongly reevaluate whether the API really represents an accessor to a logical collection. If it does not, use a method. Consider starting the method name with `Get` or `Set`.  
  
 **✓ DO** use the name `Item` for indexed properties unless there is an obviously better name (e.g., see the <xref:System.String.Chars%2A> property on `System.String`).  
  
 In C#, indexers are by default named Item. The <xref:System.Runtime.CompilerServices.IndexerNameAttribute> can be used to customize this name.  
  
 **X DO NOT** provide both an indexer and methods that are semantically equivalent.  
  
 **X DO NOT** provide more than one family of overloaded indexers in one type.  
  
 This is enforced by the C# compiler.  
  
 **X DO NOT** use nondefault indexed properties.  
  
 This is enforced by the C# compiler.  
  
### Property Change Notification Events  
 Sometimes it is useful to provide an event notifying the user of changes in a property value. For example, `System.Windows.Forms.Control` raises a `TextChanged` event after the value of its `Text` property has changed.  
  
 **✓ CONSIDER** raising change notification events when property values in high-level APIs (usually designer components) are modified.  
  
 If there is a good scenario for a user to know when a property of an object is changing, the object should raise a change notification event for the property.  
  
 However, it is unlikely to be worth the overhead to raise such events for low-level APIs such as base types or collections. For example, <xref:System.Collections.Generic.List%601> would not raise such events when a new item is added to the list and the `Count` property changes.  
  
 **✓ CONSIDER** raising change notification events when the value of a property changes via external forces.  
  
 If a property value changes via some external force (in a way other than by calling methods on the object), raise events indicate to the developer that the value is changing and has changed. A good example is the `Text` property of a text box control. When the user types text in a `TextBox`, the property value automatically changes.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Member Design Guidelines](../../../docs/standard/design-guidelines/member.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
