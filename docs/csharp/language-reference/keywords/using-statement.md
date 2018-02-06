---
title: "using Statement (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "using statement [C#]"
ms.assetid: afc355e6-f0b9-4240-94dd-0d93f17d9fc3
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
---
# using Statement (C# Reference)
Provides a convenient syntax that ensures the correct use of <xref:System.IDisposable> objects.  
  
## Example  
 The following example shows how to use the using statement.  
  
 [!code-csharp[csrefKeywordsNamespace#4](../../../csharp/language-reference/keywords/codesnippet/CSharp/using-statement_1.cs)]  
  
## Remarks  
 <xref:System.IO.File> and <xref:System.Drawing.Font> are examples of managed types that access unmanaged resources (in this case file handles and device contexts). There are many other kinds of unmanaged resources and class library types that encapsulate them. All such types must implement the <xref:System.IDisposable> interface.  
  
When the lifetime of an `IDisposable` object is limited to a single method, you should declare and instantiate it in a `using` statement. The `using` statement calls the <xref:System.IDisposable.Dispose%2A> method on the object in the correct way, and (when you use it as shown earlier) it also causes the object itself to go out of scope as soon as <xref:System.IDisposable.Dispose%2A> is called. Within the `using` block, the object is read-only and cannot be modified or reassigned.  
  
 The `using` statement ensures that <xref:System.IDisposable.Dispose%2A> is called even if an exception occurs while you are calling methods on the object. You can achieve the same result by putting the object inside a try block and then calling <xref:System.IDisposable.Dispose%2A> in a finally block; in fact, this is how the `using` statement is translated by the compiler. The code example earlier expands to the following code at compile time (note the extra curly braces to create the limited scope for the object):  
  
 [!code-csharp[csrefKeywordsNamespace#5](../../../csharp/language-reference/keywords/codesnippet/CSharp/using-statement_2.cs)]  
  
 Multiple instances of a type can be declared in a `using` statement, as shown in the following example.  
  
 [!code-csharp[csrefKeywordsNamespace#6](../../../csharp/language-reference/keywords/codesnippet/CSharp/using-statement_3.cs)]  
  
 You can instantiate the resource object and then pass the variable to the `using` statement, but this is not a best practice. In this case, the object remains in scope after control leaves the `using` block even though it will probably no longer have access to its unmanaged resources. In other words, it will no longer be fully initialized. If you try to use the object outside the `using` block, you risk causing an exception to be thrown. For this reason, it is generally better to instantiate the object in the `using` statement and limit its scope to the `using` block.  
  
 [!code-csharp[csrefKeywordsNamespace#7](../../../csharp/language-reference/keywords/codesnippet/CSharp/using-statement_4.cs)]  
  
For more information on disposing of `IDisposable` objects, see [Using objects that implement IDisposable](../../../standard/garbage-collection/using-objects.md).

## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [using Directive](../../../csharp/language-reference/keywords/using-directive.md)  
 [Garbage Collection](../../../standard/garbage-collection/index.md)  
 [Using objects that implement IDisposable](../../../standard/garbage-collection/using-objects.md)  
 [IDisposable interface](xref:System.IDisposable)
