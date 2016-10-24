---
title: "Variance in Generic Interfaces (C#)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: 4828a8f9-48c0-4128-9749-7fcd6bf19a06
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Variance in Generic Interfaces (C#)
.NET Framework 4 introduced variance support for several existing generic interfaces. Variance support enables implicit conversion of classes that implement these interfaces. The following interfaces are now variant:  
  
-   <xref:System.Collections.Generic.IEnumerable`1> (T is covariant)  
  
-   <xref:System.Collections.Generic.IEnumerator`1> (T is covariant)  
  
-   <xref:System.Linq.IQueryable`1> (T is covariant)  
  
-   <xref:System.Linq.IGrouping`2> (`TKey` and `TElement` are covariant)  
  
-   <xref:System.Collections.Generic.IComparer`1> (T is contravariant)  
  
-   <xref:System.Collections.Generic.IEqualityComparer`1> (T is contravariant)  
  
-   <xref:System.IComparable`1> (T is contravariant)  
  
 Covariance permits a method to have a more derived return type than that defined by the generic type parameter of the interface. To illustrate the covariance feature, consider these generic interfaces: `IEnumerable<Object>` and `IEnumerable<String>`. The `IEnumerable<String>` interface does not inherit the `IEnumerable<Object>` interface. However, the `String` type does inherit the `Object` type, and in some cases you may want to assign objects of these interfaces to each other. This is shown in the following code example.  
  
<CodeContentPlaceHolder>0</CodeContentPlaceHolder>  
 In earlier versions of the .NET Framework, this code causes a compilation error in C# with `Option Strict On`. But now you can use `strings` instead of `objects`, as shown in the previous example, because the <xref:System.Collections.Generic.IEnumerable`1> interface is covariant.  
  
 Contravariance permits a method to have argument types that are less derived than that specified by the generic parameter of the interface. To illustrate contravariance, assume that you have created a `BaseComparer` class to compare instances of the `BaseClass` class. The `BaseComparer` class implements the `IEqualityComparer<BaseClass>` interface. Because the <xref:System.Collections.Generic.IEqualityComparer`1> interface is now contravariant, you can use `BaseComparer` to compare instances of classes that inherit the `BaseClass` class. This is shown in the following code example.  
  
<CodeContentPlaceHolder>1</CodeContentPlaceHolder>  
 For more examples, see [Using Variance in Interfaces for Generic Collections (C#)](../covariance-contravariance/using-variance-in-interfaces-for-generic-collections--csharp-.md).  
  
 Variance in generic interfaces is supported for reference types only. Value types do not support variance. For example, `IEnumerable<int>` cannot be implicitly converted to `IEnumerable<object>`, because integers are represented by a value type.  
  
<CodeContentPlaceHolder>2</CodeContentPlaceHolder>  
 It is also important to remember that classes that implement variant interfaces are still invariant. For example, although <xref:System.Collections.Generic.List`1> implements the covariant interface <xref:System.Collections.Generic.IEnumerable`1>, you cannot implicitly convert `List<Object>` to `List<String>`. This is illustrated in the following code example.  
  
```c#  
// The following line generates a compiler error  
// because classes are invariant.  
// List<Object> list = new List<String>();  
  
// You can use the interface object instead.  
IEnumerable<Object> listObjects = new List<String>();  
```  
  
## See Also  
 [Using Variance in Interfaces for Generic Collections (C#)](../covariance-contravariance/using-variance-in-interfaces-for-generic-collections--csharp-.md)   
 [Creating Variant Generic Interfaces (C#)](../covariance-contravariance/creating-variant-generic-interfaces--csharp-.md)   
 [Generic Interfaces](../Topic/Generic%20Interfaces.md)   
 [Variance in Delegates (C#)](../covariance-contravariance/variance-in-delegates--csharp-.md)