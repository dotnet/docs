---
title: "when (C# Reference)"
ms.date: 03/07/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "when_CSharpKeyword"
  - "when"
helpviewer_keywords: 
  - "when keyword [C#]"
ms.assetid: dd543335-ae37-48ac-9560-bd5f047b9aea
caps.latest.revision: 30
author: "BillWagner"
ms.author: "wiwagn"
---
 # when (C# Reference)

You can use the `when` contextual keyword to specify a filter condition in two contexts:

- In the `catch` statement of a [try/catch](try-catch.md) or [try/catch/finally](try-catch-finally.md) block.
- In the `case` label of a [switch](switch.md) statement.

## `when` in a `catch` statement

Starting with C# 6, `When` can be used in a `catch` statement to specify a condition that must be true for the handler for a specific exception to execute. Its syntax is:

```csharp
catch ExceptionType [e] when (expr)
```
where *expr* is an expression that evaluates to a Boolean value. If it returns `true`, the exception handler executes; if `false`, it does not. 

The following example uses the `when` keyword to conditionally execute handlers for an <xref:System.Net.Http.HttpRequestException> depending on the text of the exception message.

 [!code-csharp[when-with-catch](../../../../samples/snippets/csharp/language-reference/keywords/when/catch.cs)]  
  
## `when` in a `switch` statement

Starting with 7, `case` labels no longer need be mutually exclusive, and the order in which `case` labels appear in a `switch` statement can determine which switch block executes. The `when` keyword can be used to specify a filter condition that causes its associated case label to be true only if the filter condition is also true. Its syntax is:

```csharp
case (expr) when (when-condition):
```
where *expr* is a constant pattern or type pattern that is compared to the match expression, and *when-condition* is any Boolean expression. 

The following example uses the `when` keyword to test for `Shape` objects that have an area of zero, as well as to test for a variety of `Shape` objects that have an area greater than zero. 

 [!code-csharp[when-with-case#1](../../../../samples/snippets/csharp/language-reference/keywords/when/when.cs#1)]  

## See also 
  [switch statement](switch.md)  
  [try/catch statement](try-catch.md)  
  [try/catch/finally statement](try-catch-finally.md) 

