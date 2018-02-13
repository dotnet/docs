---
title: "Using objects that implement IDisposable"
ms.custom: ""
ms.date: "04/07/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Dispose method"
  - "try/finally block"
  - "garbage collection, encapsulating resources"
ms.assetid: 81b2cdb5-c91a-4a31-9c83-eadc52da5cf0
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Using objects that implement IDisposable

The common language runtime's garbage collector reclaims the memory used by managed objects, but types that use unmanaged resources implement the <xref:System.IDisposable> interface to allow the memory allocated to these unmanaged resources to be reclaimed. When you finish using an object that implements <xref:System.IDisposable>, you should call the object's <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation. You can do this in one of two ways:  
  
* With the C# `using` statement or the Visual Basic `Using` statement.  
  
* By implementing a `try/finally` block.  

## The using statement

The `using` statement in C# and the `Using` statement in Visual Basic simplify the code that you must write to create and clean up an object. The `using` statement obtains one or more resources, executes the statements that you specify, and automatically disposes of the object. However, the `using` statement is useful only for objects that are used within the scope of the method in which they are constructed.  
  
The following example uses the `using` statement to create and release a <xref:System.IO.StreamReader?displayProperty=nameWithType> object.  
  
[!code-csharp[Conceptual.Disposable#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/using1.cs#1)]
[!code-vb[Conceptual.Disposable#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/using1.vb#1)]  
  
Note that although the <xref:System.IO.StreamReader> class implements the <xref:System.IDisposable> interface, which indicates that it uses an unmanaged resource, the example doesn't explicitly call the <xref:System.IO.StreamReader.Dispose%2A?displayProperty=nameWithType> method. When the C# or Visual Basic compiler encounters the `using` statement, it emits intermediate language (IL) that is equivalent to the following code that explicitly contains a `try/finally` block.  
  
[!code-csharp[Conceptual.Disposable#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/using3.cs#3)]
[!code-vb[Conceptual.Disposable#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/using3.vb#3)]  
  
The C# `using` statement also allows you to acquire multiple resources in a single statement, which is internally equivalent to nested `using` statements. The following example instantiates two <xref:System.IO.StreamReader> objects to read the contents of two different files.  
  
[!code-csharp[Conceptual.Disposable#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/using4.cs#4)]

## Try/finally block

Instead of wrapping a `try/finally` block in a `using` statement, you may choose to implement the `try/finally` block directly. This may be your personal coding style, or you might want to do this for one of the following reasons:  
  
* To include a `catch` block to handle any exceptions thrown in the `try` block. Otherwise, any exceptions thrown by the `using` statement are unhandled, as are any exceptions thrown within the `using` block if a `try/catch` block isn't present.  
  
* To instantiate an object that implements <xref:System.IDisposable> whose scope is not local to the block within which it is declared.  
  
The following example is similar to the previous example, except that it uses a `try/catch/finally` block to instantiate, use, and dispose of a <xref:System.IO.StreamReader> object, and to handle any exceptions thrown by the <xref:System.IO.StreamReader> constructor and its <xref:System.IO.StreamReader.ReadToEnd%2A> method. Note that the code in the `finally` block checks that the object that implements <xref:System.IDisposable> isn't `null` before it calls the <xref:System.IDisposable.Dispose%2A> method. Failure to do this can result in a <xref:System.NullReferenceException> exception at run time.  
  
[!code-csharp[Conceptual.Disposable#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.disposable/cs/using5.cs#6)]
[!code-vb[Conceptual.Disposable#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.disposable/vb/using5.vb#6)]  
  
You can follow this basic pattern if you choose to implement or must implement a `try/finally` block, because your programming language doesn't support a `using` statement but does allow direct calls to the <xref:System.IDisposable.Dispose%2A> method. 
  
## See also

[Cleaning Up Unmanaged Resources](../../../docs/standard/garbage-collection/unmanaged.md)   
[using Statement (C# Reference)](~/docs/csharp/language-reference/keywords/using-statement.md)   
[Using Statement (Visual Basic)](~/docs/visual-basic/language-reference/statements/using-statement.md)
