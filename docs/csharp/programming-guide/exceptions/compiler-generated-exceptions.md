---
title: "Compiler-Generated Exceptions (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "exceptions [C#], compiler-generated"
ms.assetid: 53b52f97-b366-4ed7-b05b-9eb78096b7f9
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
---
# Compiler-Generated Exceptions (C# Programming Guide)
Some exceptions are thrown automatically by the .NET Framework's common language runtime (CLR) when basic operations fail. These exceptions and their error conditions are listed in the following table.  
  
|Exception|Description|  
|---------------|-----------------|  
|<xref:System.ArithmeticException>|A base class for exceptions that occur during arithmetic operations, such as <xref:System.DivideByZeroException> and <xref:System.OverflowException>.|  
|<xref:System.ArrayTypeMismatchException>|Thrown when an array cannot store a given element because the actual type of the element is incompatible with the actual type of the array.|  
|<xref:System.DivideByZeroException>|Thrown when an attempt is made to divide an integral value by zero.|  
|<xref:System.IndexOutOfRangeException>|Thrown when an attempt is made to index an array when the index is less than zero or outside the bounds of the array.|  
|<xref:System.InvalidCastException>|Thrown when an explicit conversion from a base type to an interface or to a derived type fails at runtime.|  
|<xref:System.NullReferenceException>|Thrown when you attempt to reference an object whose value is [null](../../../csharp/language-reference/keywords/null.md).|  
|<xref:System.OutOfMemoryException>|Thrown when an attempt to allocate memory using the [new](../../../csharp/language-reference/keywords/new-operator.md) operator fails. This indicates that the memory available to the common language runtime has been exhausted.|  
|<xref:System.OverflowException>|Thrown when an arithmetic operation in a `checked` context overflows.|  
|<xref:System.StackOverflowException>|Thrown when the execution stack is exhausted by having too many pending method calls; usually indicates a very deep or infinite recursion.|  
|<xref:System.TypeInitializationException>|Thrown when a static constructor throws an exception and no compatible `catch` clause exists to catch it.|  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Exceptions and Exception Handling](../../../csharp/programming-guide/exceptions/index.md)  
 [Exception Handling](../../../csharp/programming-guide/exceptions/exception-handling.md)  
 [try-catch](../../../csharp/language-reference/keywords/try-catch.md)  
 [try-finally](../../../csharp/language-reference/keywords/try-finally.md)  
 [try-catch-finally](../../../csharp/language-reference/keywords/try-catch-finally.md)
