---
title: ".NET Performance Tips"
description: Explore performance tips to improve the execution speed of a program in .NET. See tips for boxing and unboxing, strings, and finalizers.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "C# language, performance"
  - "performance [C#]"
  - "Visual Basic, performance"
  - "performance [Visual Basic]"
ms.assetid: ae275793-857d-4102-9095-b4c2a02d57f4
author: "BillWagner"
ms.author: "wiwagn"
---
# .NET Performance Tips

The term *performance* generally refers to the execution speed of a program. You can sometimes increase execution speed by following certain basic rules in your source code. In some programs, it is important to examine code closely and use profilers to make sure that it is running as fast as possible. In other programs, you do not have to perform such optimization because the code is running acceptably fast as it is written. This article lists some common areas where performance can suffer and tips for improving it as well as links to additional performance topics. For more information about planning and measuring for performance, see [Performance](index.md)  
  
## Boxing and Unboxing  

 It is best to avoid using value types in situations where they must be boxed a high number of times, for example in non-generic collections classes such as <xref:System.Collections.ArrayList?displayProperty=nameWithType>. You can avoid boxing of value types by using generic collections such as <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>. Boxing and unboxing are computationally expensive processes. When a value type is boxed, an entirely new object must be created. This can take up to 20 times longer than a simple reference assignment. When unboxing, the casting process can take four times as long as an assignment. For more information, see [Boxing and Unboxing](../../csharp/programming-guide/types/boxing-and-unboxing.md).  
  
## Strings  

 When you concatenate a large number of string variables, for example in a tight loop, use <xref:System.Text.StringBuilder?displayProperty=nameWithType> instead of the C# [+ operator](../../csharp/language-reference/operators/addition-operator.md) or the Visual Basic [Concatenation Operators](../../visual-basic/language-reference/operators/concatenation-operators.md). For more information, see [How to concatenate multiple strings](../../csharp/how-to/concatenate-multiple-strings.md) and [Concatenation Operators in Visual Basic](../../visual-basic/programming-guide/language-features/operators-and-expressions/concatenation-operators.md).  
  
## Finalizers  

 Empty finalizers should not be used. When a class contains a finalizer, an entry is created in the Finalize queue. When the finalizer is called, the garbage collector is invoked to process the queue. If the finalizer is empty, this simply results in a loss of performance. For more information, see [Finalizers](../../csharp/programming-guide/classes-and-structs/finalizers.md) and [Object Lifetime: How Objects Are Created and Destroyed](../../visual-basic/programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md).  
  
## Other Resources  
  
- [Writing Faster Managed Code: Know What Things Cost](/previous-versions/dotnet/articles/ms973852(v=msdn.10))  
  
- [Writing High-Performance Managed Applications: A Primer](/previous-versions/dotnet/articles/ms973858(v=msdn.10))  
  
- [Garbage Collector Basics and Performance Hints](/previous-versions/dotnet/articles/ms973837(v=msdn.10))  
  
- [Performance Tips and Tricks in .NET Applications](/previous-versions/dotnet/articles/ms973839(v=msdn.10))  

- [Rico Mariani's Performance Tidbits](/archive/blogs/ricom/)  

- [Vance Morrison's Blog](/archive/blogs/vancem/)
  
## See also

- [Performance](index.md)
- [Visual Basic Programming Guide](../../visual-basic/programming-guide/index.md)
- [C# Programming Guide](../../csharp/programming-guide/index.md)
