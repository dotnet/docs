---
title: "Names of Classes, Structs, and Interfaces"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "type names, guidelines"
  - "classes [.NET Framework], names"
  - "enumerations [.NET Framework], names"
  - "names [.NET Framework], interfaces"
  - "common type names"
  - "names [.NET Framework], type names"
  - "names [.NET Framework], classes"
  - "interfaces [.NET Framework], names"
  - "generic type parameters"
ms.assetid: 87a4b0da-ed64-43b1-ac43-968576c444ce
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Names of Classes, Structs, and Interfaces
The naming guidelines that follow apply to general type naming.  
  
 **✓ DO** name classes and structs with nouns or noun phrases, using PascalCasing.  
  
 This distinguishes type names from methods, which are named with verb phrases.  
  
 **✓ DO** name interfaces with adjective phrases, or occasionally with nouns or noun phrases.  
  
 Nouns and noun phrases should be used rarely and they might indicate that the type should be an abstract class, and not an interface.  
  
 **X DO NOT** give class names a prefix (e.g., "C").  
  
 **✓ CONSIDER** ending the name of derived classes with the name of the base class.  
  
 This is very readable and explains the relationship clearly. Some examples of this in code are: `ArgumentOutOfRangeException`, which is a kind of `Exception`, and `SerializableAttribute`, which is a kind of `Attribute`. However, it is important to use reasonable judgment in applying this guideline; for example, the `Button` class is a kind of `Control` event, although `Control` doesn’t appear in its name.  
  
 **✓ DO** prefix interface names with the letter I, to indicate that the type is an interface.  
  
 For example, `IComponent` (descriptive noun), `ICustomAttributeProvider` (noun phrase), and `IPersistable` (adjective) are appropriate interface names. As with other type names, avoid abbreviations.  
  
 **✓ DO** ensure that the names differ only by the "I" prefix on the interface name when you are defining a class–interface pair where the class is a standard implementation of the interface.  
  
## Names of Generic Type Parameters  
 Generics were added to .NET Framework 2.0. The feature introduced a new kind of identifier called *type parameter*.  
  
 **✓ DO** name generic type parameters with descriptive names unless a single-letter name is completely self-explanatory and a descriptive name would not add value.  
  
 **✓ CONSIDER** using `T` as the type parameter name for types with one single-letter type parameter.  
  
```  
public int IComparer<T> { ... }  
public delegate bool Predicate<T>(T item);  
public struct Nullable<T> where T:struct { ... }  
```  
  
 **✓ DO** prefix descriptive type parameter names with `T`.  
  
```  
public interface ISessionChannel<TSession> where TSession : ISession{  
    TSession Session { get; }  
}  
```  
  
 **✓ CONSIDER** indicating constraints placed on a type parameter in the name of the parameter.  
  
 For example, a parameter constrained to `ISession` might be called `TSession`.  
  
## Names of Common Types  
 **✓ DO** follow the guidelines described in the following table when naming types derived from or implementing certain .NET Framework types.  
  
|Base Type|Derived/Implementing Type Guideline|  
|---------------|------------------------------------------|  
|`System.Attribute`|**✓ DO** add the suffix "Attribute" to names of custom attribute classes.|  
|`System.Delegate`|**✓ DO** add the suffix "EventHandler" to names of delegates that are used in events.<br /><br /> **✓ DO** add the suffix "Callback" to names of delegates other than those used as event handlers.<br /><br /> **X DO NOT** add the suffix "Delegate" to a delegate.|  
|`System.EventArgs`|**✓ DO** add the suffix "EventArgs."|  
|`System.Enum`|**X DO NOT** derive from this class; use the keyword supported by your language instead; for example, in C#, use the `enum` keyword.<br /><br /> **X DO NOT** add the suffix "Enum" or "Flag."|  
|`System.Exception`|**✓ DO** add the suffix "Exception."|  
|`IDictionary` <br /> `IDictionary<TKey,TValue>`|**✓ DO** add the suffix "Dictionary." Note that `IDictionary` is a specific type of collection, but this guideline takes precedence over the more general collections guideline that follows.|  
|`IEnumerable` <br /> `ICollection` <br /> `IList` <br /> `IEnumerable<T>` <br /> `ICollection<T>` <br /> `IList<T>`|**✓ DO** add the suffix "Collection."|  
|`System.IO.Stream`|**✓ DO** add the suffix "Stream."|  
|`CodeAccessPermission IPermission`|**✓ DO** add the suffix "Permission."|  
  
## Naming Enumerations  
 Names of enumeration types (also called enums) in general should follow the standard type-naming rules (PascalCasing, etc.). However, there are additional guidelines that apply specifically to enums.  
  
 **✓ DO** use a singular type name for an enumeration unless its values are bit fields.  
  
 **✓ DO** use a plural type name for an enumeration with bit fields as values, also called flags enum.  
  
 **X DO NOT** use an "Enum" suffix in enum type names.  
  
 **X DO NOT** use "Flag" or "Flags" suffixes in enum type names.  
  
 **X DO NOT** use a prefix on enumeration value names (e.g., "ad" for ADO enums, "rtf" for rich text enums, etc.).  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Naming Guidelines](../../../docs/standard/design-guidelines/naming-guidelines.md)
