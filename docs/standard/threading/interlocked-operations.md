---
title: "Interlocked Operations"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "Interlocked class, about Interlocked class"
  - "threading [.NET Framework], Interlocked class"
ms.assetid: cbda7114-c752-4f3e-ada1-b1e8dd262f2b
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Interlocked Operations
The <xref:System.Threading.Interlocked> class provides methods that synchronize access to a variable that is shared by multiple threads. The threads of different processes can use this mechanism if the variable is in shared memory. Interlocked operations are atomic — that is, the entire operation is a unit that cannot be interrupted by another interlocked operation on the same variable. This is important in operating systems with preemptive multithreading, where a thread can be suspended after loading a value from a memory address, but before having the chance to alter it and store it.  
  
 The <xref:System.Threading.Interlocked> class provides the following operations:  
  
-   In the .NET Framework version 2.0, the <xref:System.Threading.Interlocked.Add%2A> method adds an integer value to a variable and returns the new value of the variable.  
  
-   In the .NET Framework version 2.0, the <xref:System.Threading.Interlocked.Read%2A> method reads a 64-bit integer value as an atomic operation. This is useful on 32-bit operating systems, where reading a 64-bit integer is not ordinarily an atomic operation.  
  
-   The <xref:System.Threading.Interlocked.Increment%2A> and <xref:System.Threading.Interlocked.Decrement%2A> methods increment or decrement a variable and return the resulting value.  
  
-   The <xref:System.Threading.Interlocked.Exchange%2A> method performs an atomic exchange of the value in a specified variable, returning that value and replacing it with a new value. In the .NET Framework version 2.0, a generic overload of this method can be used to perform this exchange on a variable of any reference type. See <xref:System.Threading.Interlocked.Exchange%60%601%28%60%600%40%2C%60%600%29>.  
  
-   The <xref:System.Threading.Interlocked.CompareExchange%2A> method also exchanges two values, but contingent on the result of a comparison. In the .NET Framework version 2.0, a generic overload of this method can be used to perform this exchange on a variable of any reference type. See <xref:System.Threading.Interlocked.CompareExchange%60%601%28%60%600%40%2C%60%600%2C%60%600%29>.  
  
 On modern processors, the methods of the <xref:System.Threading.Interlocked> class can often be implemented by a single instruction. Thus, they provide very high-performance synchronization and can be used to build higher-level synchronization mechanisms, like spin locks.  
  
 For an example that uses the <xref:System.Threading.Monitor> and <xref:System.Threading.Interlocked> classes in combination, see [Monitors](http://msdn.microsoft.com/library/33fe4aef-b44b-42fd-9e72-c908e39e75db).  
  
## CompareExchange Example  
 The <xref:System.Threading.Interlocked.CompareExchange%2A> method can be used to protect computations that are more complicated than simple increment and decrement. The following example demonstrates a thread-safe method that adds to a running total stored as a floating point number. (For integers, the <xref:System.Threading.Interlocked.Add%2A> method is a simpler solution.) For complete code examples, see the overloads of <xref:System.Threading.Interlocked.CompareExchange%2A> that take single-precision and double-precision floating-point arguments (<xref:System.Threading.Interlocked.CompareExchange%28System.Single%40%2CSystem.Single%2CSystem.Single%29> and <xref:System.Threading.Interlocked.CompareExchange%28System.Double%40%2CSystem.Double%2CSystem.Double%29>).  
  
 [!code-cpp[Conceptual.Interlocked#1](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.interlocked/cpp/source1.cpp#1)]
 [!code-csharp[Conceptual.Interlocked#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.interlocked/cs/source1.cs#1)]
 [!code-vb[Conceptual.Interlocked#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interlocked/vb/source1.vb#1)]  
  
## Untyped Overloads of Exchange and CompareExchange  
 The <xref:System.Threading.Interlocked.Exchange%2A> and <xref:System.Threading.Interlocked.CompareExchange%2A> methods have overloads that take arguments of type <xref:System.Object>. The first argument of each of these overloads is `ref Object` (`ByRef … As Object` in Visual Basic), and type safety requires the variable passed to this argument to be typed strictly as <xref:System.Object>; you cannot simply cast the first argument to type <xref:System.Object> when calling these methods.  
  
> [!NOTE]
>  In the .NET Framework version 2.0, use the generic overloads of the <xref:System.Threading.Interlocked.Exchange%2A> and <xref:System.Threading.Interlocked.CompareExchange%2A> methods to exchange strongly typed variables.  
  
 The following code example shows a property of type `ClassA` that can be set only once, as it might be implemented in the .NET Framework version 1.0 or 1.1.  
  
 [!code-cpp[Conceptual.Interlocked#2](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.interlocked/cpp/source2.cpp#2)]
 [!code-csharp[Conceptual.Interlocked#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.interlocked/cs/source2.cs#2)]
 [!code-vb[Conceptual.Interlocked#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.interlocked/vb/source2.vb#2)]  
  
## See Also  
 <xref:System.Threading.Interlocked>  
 <xref:System.Threading.Monitor>  
 [Threading](../../../docs/standard/threading/index.md)  
 [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md)
