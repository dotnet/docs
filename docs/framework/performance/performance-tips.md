---
title: ".NET Performance Tips"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "C# language, performance"
  - "performance [C#]"
  - "Visual Basic, performance"
  - "performance [Visual Basic]"
ms.assetid: ae275793-857d-4102-9095-b4c2a02d57f4
caps.latest.revision: 36
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
ms.workload: 
  - "wiwagn"
---
# .NET Performance Tips
The term *performance* generally refers to the execution speed of a program. You can sometimes increase execution speed by following certain basic rules in your source code. In some programs, it is important to examine code closely and use profilers to make sure that it is running as fast as possible. In other programs, you do not have to perform such optimization because the code is running acceptably fast as it is written. This article lists some common areas where performance can suffer and tips for improving it as well as links to additional performance topics. For more information about planning and measuring for performance, see [Performance](../../../docs/framework/performance/index.md)  
  
## Boxing and Unboxing  
 It is best to avoid using value types in situations where they must be boxed a high number of times, for example in non-generic collections classes such as <xref:System.Collections.ArrayList?displayProperty=nameWithType>. You can avoid boxing of value types by using generic collections such as <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>. Boxing and unboxing are computationally expensive processes. When a value type is boxed, an entirely new object must be created. This can take up to 20 times longer than a simple reference assignment. When unboxing, the casting process can take four times as long as an assignment. For more information, see [Boxing and Unboxing](~/docs/csharp/programming-guide/types/boxing-and-unboxing.md).  
  
## Strings  
 When you concatenate a large number of string variables, for example in a tight loop, use <xref:System.Text.StringBuilder?displayProperty=nameWithType> instead of the C# [+ operator](~/docs/csharp/language-reference/operators/addition-operator.md) or the Visual Basic [Concatenation Operators](~/docs/visual-basic/language-reference/operators/concatenation-operators.md). For more information, see [How to: Concatenate Multiple Strings](../../csharp/how-to/concatenate-multiple-strings.md) and [Concatenation Operators in Visual Basic](~/docs/visual-basic/programming-guide/language-features/operators-and-expressions/concatenation-operators.md).  
  
## Destructors  
 Empty destructors should not be used. When a class contains a destructor, an entry is created in the Finalize queue. When the destructor is called, the garbage collector is invoked to process the queue. If the destructor is empty, this simply results in a loss of performance. For more information, see [Destructors](~/docs/csharp/programming-guide/classes-and-structs/destructors.md) and [Object Lifetime: How Objects Are Created and Destroyed](~/docs/visual-basic/programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md).  
  
## Other Resources  
  
-   [Writing Faster Managed Code: Know What Things Cost](http://go.microsoft.com/fwlink/?LinkId=99294)  
  
-   [Writing High-Performance Managed Applications: A Primer](http://go.microsoft.com/fwlink/?LinkId=99295)  
  
-   [Garbage Collector Basics and Performance Hints](http://go.microsoft.com/fwlink/?LinkId=99296)  
  
-   [Performance Tips and Tricks in .NET Applications](http://go.microsoft.com/fwlink/?LinkId=99297)  

-   [Rico Mariani's Performance Tidbits](http://go.microsoft.com/fwlink/?LinkId=115679)  

-   [Vance Morrison's Blog](https://blogs.msdn.microsoft.com/vancem/)
  
## See Also  
 [Performance](../../../docs/framework/performance/index.md)  
 [Programming Concepts](http://msdn.microsoft.com/library/65c12cca-af4f-4017-886e-2dbc00a189d6)  
 [Visual Basic Programming Guide](../../visual-basic/programming-guide/index.md)  
 [C# Programming Guide](http://msdn.microsoft.com/library/ac0f23a2-6bf3-4077-be99-538ae5fd3bc5)
