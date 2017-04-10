---
title: "Generic Collections in the .NET Framework | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "generics [.NET Framework], collections"
  - "generic collections [.NET Framework]"
ms.assetid: 5b646751-6ab7-465c-916c-b1a76aefa9f5
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# Generic Collections in the .NET Framework
This topic provides an overview of the generic collection classes and other generic types in the .NET Framework.  
  
## Generic Collections in the .NET Framework  
 The .NET Framework class library provides a number of generic collection classes in the <xref:System.Collections.Generic> and <xref:System.Collections.ObjectModel> namespaces. For more information about these classes, see [Commonly Used Collection Types](../../../docs/standard/collections/commonly-used-collection-types.md).  
  
### System.Collections.Generic  
 Many of the generic collection types are direct analogs of nongeneric types. <xref:System.Collections.Generic.Dictionary%602> is a generic version of <xref:System.Collections.Hashtable>; it uses the generic structure <xref:System.Collections.Generic.KeyValuePair%602> for enumeration instead of <xref:System.Collections.DictionaryEntry>.  
  
 <xref:System.Collections.Generic.List%601> is a generic version of <xref:System.Collections.ArrayList>. There are generic <xref:System.Collections.Generic.Queue%601> and <xref:System.Collections.Generic.Stack%601> classes that correspond to the nongeneric versions.  
  
 There are generic and nongeneric versions of <xref:System.Collections.Generic.SortedList%602>. Both versions are hybrids of a dictionary and a list. The <xref:System.Collections.Generic.SortedDictionary%602> generic class is a pure dictionary and has no nongeneric counterpart.  
  
 The <xref:System.Collections.Generic.LinkedList%601> generic class is a true linked list. It has no nongeneric counterpart.  
  
### System.Collections.ObjectModel  
 The <xref:System.Collections.ObjectModel.Collection%601> generic class provides a base class for deriving your own generic collection types. The <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> class provides an easy way to produce a read-only collection from any type that implements the <xref:System.Collections.Generic.IList%601> generic interface. The <xref:System.Collections.ObjectModel.KeyedCollection%602> generic class provides a way to store objects that contain their own keys.  
  
## Other Generic Types  
 The <xref:System.Nullable%601>generic structure allows you to use value types as if they could be assigned `null`. This can be useful when working with database queries, where fields that contain value types can be missing. The generic type parameter can be any value type.  
  
> [!NOTE]
>  In C# it is not necessary to use <xref:System.Nullable%601> explicitly because the language has syntax for nullable types.  
  
 The <xref:System.ArraySegment%601> generic structure provides a way to delimit a range of elements within a one-dimensional, zero-based array of any type. The generic type parameter is the type of the array's elements.  
  
 The <xref:System.EventHandler%601> generic delegate eliminates the need to declare a delegate type to handle events, if your event follows the event-handling pattern used by the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)]. For example, suppose you have created a `MyEventArgs` class, derived from <xref:System.EventArgs>, to hold the data for your event. You can then declare the event as follows:  
  
 [!code-cpp[Conceptual.Generics.Overview#7](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.generics.overview/cpp/source2.cpp#7)]
 [!code-csharp[Conceptual.Generics.Overview#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.generics.overview/cs/source2.cs#7)]
 [!code-vb[Conceptual.Generics.Overview#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.generics.overview/vb/source2.vb#7)]  
  
## See Also  
 <xref:System.Collections.Generic?displayProperty=fullName>   
 <xref:System.Collections.ObjectModel?displayProperty=fullName>   
 [Generics](../../../docs/standard/generics/index.md)   
 [Generic Delegates for Manipulating Arrays and Lists](../../../docs/standard/generics/delegates-for-manipulating-arrays-and-lists.md)   
 [Generic Interfaces](../../../docs/standard/generics/interfaces.md)