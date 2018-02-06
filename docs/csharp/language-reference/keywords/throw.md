---
title: "throw (C# Reference)"
ms.date: 03/02/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "throw"
  - "throw_CSharpKeyword"
helpviewer_keywords: 
  - "throw statement [C#]"
  - "throw expression [C#]"
  - "throw keyword [C#]"
ms.assetid: 5ac4feef-4b1a-4c61-aeb4-61d549e5dd42
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
---
# throw (C# Reference)
Signals the occurrence of an exception during program execution.  
  
## Remarks

The syntax of `throw` is:

```csharp
throw [e]
```
where `e` is an instance of a class derived from <xref:System.Exception?displayProperty=nameWithType>. The following example uses the `throw` statement to throw an <xref:System.IndexOutOfRangeException> if the argument passed to a method named `GetNumber` does not correspond to a valid index of an internal array.

[!code-csharp[csrefKeyword#1](../../../../samples/snippets/csharp/language-reference/keywords/throw/throw-1.cs#1)]  

Method callers then use a `try-catch` or `try-catch-finally` block to handle the thrown exception. The following example handles the exception thrown by the `GetNumber` method.

[!code-csharp[csrefKeyword#2](../../../../samples/snippets/csharp/language-reference/keywords/throw/throw-1.cs#2)]  

## Re-throwing an exception

`throw` can also be used in a `catch` block to re-throw an exception handled in a `catch` block.  In this case, `throw` does not take an exception operand. It is most useful when a method passes on an argument from a caller to some other library method, and the library method throws an exception that must be passed on to the caller. For example, the following example re-throws an <xref:System.NullReferenceException> that is thrown when attempting to retrieve the first character of an uninitialized string. 

[!code-csharp[csrefKeyword#3](../../../../samples/snippets/csharp/language-reference/keywords/throw/throw-3.cs#3)]  

> [!IMPORTANT]
> You can also use the `throw e` syntax in a `catch` block to instantiate a new exception that you pass on to the caller. In this case, the stack trace of the original exception, which is available from the <xref:System.Exception.StackTrace> property, is not preserved.
 
## The `throw` expression

Starting with C# 7, `throw` can be used as an expression as well as a statement. This allows an exception to be thrown in contexts that were previously unsupported. These include:

- [the conditional operator](../operators/conditional-operator.md). The following example uses a `throw` expression to throw an <xref:System.ArgumentException> if a method is passed an empty string array. Before C# 7, this logic would need to appear in an `if`/`else` statement.

   [!code-csharp[csrefKeyword#4](../../../../samples/snippets/csharp/language-reference/keywords/throw/conditional.cs#1)]  
  
- [the null-coalescing operator](../operators/null-conditional-operator.md). In the following example, a `throw` expression is used with a null-coalescing operator to throw an exception if the string assigned to a `Name` property is `null`.
 
   [!code-csharp[csrefKeyword#5](../../../../samples/snippets/csharp/language-reference/keywords/throw/coalescing.cs#1)]  
 
- an expression-bodied [lambda](../../lambda-expressions.md) or method. The following example illustrates an expression-bodied method that throws an <xref:System.InvalidCastException> because a conversion to a <xref:System.DateTime> value is not supported.
 
   [!code-csharp[csrefKeyword#6](../../../../samples/snippets/csharp/language-reference/keywords/throw/exp-bodied.cs#1)]  
 
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [try-catch](../../../csharp/language-reference/keywords/try-catch.md)  
 [The try, catch, and throw Statements in C++](../../../csharp/language-reference/keywords/try-catch.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Exception Handling Statements](../../../csharp/language-reference/keywords/exception-handling-statements.md)  
 [How to: Explicitly Throw Exceptions](../../../standard/exceptions/how-to-explicitly-throw-exceptions.md)
