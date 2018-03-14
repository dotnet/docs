---
title: "Generic Delegates for Manipulating Arrays and Lists"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "delegates [.NET Framework], generic delegates"
  - "chaining delegates"
  - "arrays [.NET Framework], generic delegates"
  - "generic delegates [.NET Framework]"
  - "lists [.NET Framework], generic delegates"
  - "generics [.NET Framework], delegates"
ms.assetid: 416be383-cc61-4102-9b1b-88b51adb963e
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Generic Delegates for Manipulating Arrays and Lists
This topic provides an overview of generic delegates for conversions, search predicates, and actions to be taken on elements of an array or collection.  
  
## Generic Delegates for Manipulating Arrays and Lists  
 The <xref:System.Action%601> generic delegate represents a method that performs some action on an element of the specified type. You can create a method that performs the desired action on the element, create an instance of the <xref:System.Action%601> delegate to represent that method, and then pass the array and the delegate to the <xref:System.Array.ForEach%2A?displayProperty=nameWithType> static generic method. The method is called for every element of the array.  
  
 The <xref:System.Collections.Generic.List%601> generic class also provides a <xref:System.Collections.Generic.List%601.ForEach%2A> method that uses the <xref:System.Action%601> delegate. This method is not generic.  
  
> [!NOTE]
>  This makes an interesting point about generic types and methods. The <xref:System.Array.ForEach%2A?displayProperty=nameWithType> method must be static (`Shared` in Visual Basic) and generic because <xref:System.Array> is not a generic type; the only reason you can specify a type for <xref:System.Array.ForEach%2A?displayProperty=nameWithType> to operate on is that the method has its own type parameter list. By contrast, the nongeneric <xref:System.Collections.Generic.List%601.ForEach%2A?displayProperty=nameWithType> method belongs to the generic class <xref:System.Collections.Generic.List%601>, so it simply uses the type parameter of its class. The class is strongly typed, so the method can be an instance method.  
  
 The <xref:System.Predicate%601> generic delegate represents a method that determines whether a particular element meets criteria you define. You can use it with the following static generic methods of <xref:System.Array> to search for an element or a set of elements: <xref:System.Array.Exists%2A>, <xref:System.Array.Find%2A>, <xref:System.Array.FindAll%2A>, <xref:System.Array.FindIndex%2A>, <xref:System.Array.FindLast%2A>, <xref:System.Array.FindLastIndex%2A>, and <xref:System.Array.TrueForAll%2A>.  
  
 <xref:System.Predicate%601> also works with the corresponding nongeneric instance methods of the <xref:System.Collections.Generic.List%601> generic class.  
  
 The <xref:System.Comparison%601> generic delegate allows you to provide a sort order for array or list elements that do not have a native sort order, or to override the native sort order. Create a method that performs the comparison, create an instance of the <xref:System.Comparison%601> delegate to represent your method, and then pass the array and the delegate to the <xref:System.Array.Sort%60%601%28%60%600%5B%5D%2CSystem.Comparison%7B%60%600%7D%29?displayProperty=nameWithType> static generic method. The <xref:System.Collections.Generic.List%601> generic class provides a corresponding instance method overload, <xref:System.Collections.Generic.List%601.Sort%28System.Comparison%7B%600%7D%29?displayProperty=nameWithType>.  
  
 The <xref:System.Converter%602> generic delegate allows you to define a conversion between two types, and to convert an array of one type into an array of the other, or to convert a list of one type to a list of the other. Create a method that converts the elements of the existing list to a new type, create a delegate instance to represent the method, and use the <xref:System.Array.ConvertAll%2A?displayProperty=nameWithType> generic static method to produce an array of the new type from the original array, or the <xref:System.Collections.Generic.List%601.ConvertAll%60%601%28System.Converter%7B%600%2C%60%600%7D%29?displayProperty=nameWithType> generic instance method to produce a list of the new type from the original list.  
  
### Chaining Delegates  
 Many of the methods that use these delegates return an array or list, which can be passed to another method. For example, if you want to select certain elements of an array, convert those elements to a new type, and save them in a new array, you can pass the array returned by the <xref:System.Array.FindAll%2A> generic method to the <xref:System.Array.ConvertAll%2A> generic method. If the new element type lacks a natural sort order, you can pass the array returned by the <xref:System.Array.ConvertAll%2A> generic method to the <xref:System.Array.Sort%60%601%28%60%600%5B%5D%2CSystem.Comparison%7B%60%600%7D%29> generic method.  
  
## See Also  
 <xref:System.Collections.Generic?displayProperty=nameWithType>  
 <xref:System.Collections.ObjectModel?displayProperty=nameWithType>  
 [Generics](../../../docs/standard/generics/index.md)  
 [Generic Collections in the .NET Framework](../../../docs/standard/generics/collections.md)  
 [Generic Interfaces](../../../docs/standard/generics/interfaces.md)  
 [Covariance and Contravariance](../../../docs/standard/generics/covariance-and-contravariance.md)
