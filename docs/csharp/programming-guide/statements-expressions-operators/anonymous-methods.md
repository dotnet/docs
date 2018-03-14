---
title: "Anonymous Methods (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "anonymous methods [C#]"
  - "methods [C#], anonymous"
  - "delegates [C#], anonymous methods"
ms.assetid: a62441fa-f0a3-4acb-9aa6-93762a635275
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
---
# Anonymous Methods (C# Programming Guide)
In versions of C# before 2.0, the only way to declare a [delegate](../../../csharp/language-reference/keywords/delegate.md) was to use [named methods](../../../csharp/programming-guide/delegates/delegates-with-named-vs-anonymous-methods.md). C# 2.0 introduced anonymous methods and in C# 3.0 and later, lambda expressions supersede anonymous methods as the preferred way to write inline code. However, the information about anonymous methods in this topic also applies to lambda expressions. There is one case in which an anonymous method provides functionality not found in lambda expressions. Anonymous methods enable you to omit the parameter list. This means that an anonymous method can be converted to delegates with a variety of signatures. This is not possible with lambda expressions. For more information specifically about lambda expressions, see [Lambda Expressions](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md).  
  
 Creating anonymous methods is essentially a way to pass a code block as a delegate parameter. Here are two examples:  
  
 [!code-csharp[csProgGuideDelegates#6](../../../csharp/programming-guide/delegates/codesnippet/CSharp/anonymous-methods_1.cs)]  
  
 [!code-csharp[csProgGuideDelegates#5](../../../csharp/programming-guide/delegates/codesnippet/CSharp/anonymous-methods_2.cs)]  
  
 By using anonymous methods, you reduce the coding overhead in instantiating delegates because you do not have to create a separate method.  
  
 For example, specifying a code block instead of a delegate can be useful in a situation when having to create a method might seem an unnecessary overhead. A good example would be when you start a new thread. This class creates a thread and also contains the code that the thread executes without creating an additional method for the delegate.  
  
 [!code-csharp[csProgGuideDelegates#7](../../../csharp/programming-guide/delegates/codesnippet/CSharp/anonymous-methods_3.cs)]  
  
## Remarks  
 The scope of the parameters of an anonymous method is the *anonymous-method-block*.  
  
 It is an error to have a jump statement, such as [goto](../../../csharp/language-reference/keywords/goto.md), [break](../../../csharp/language-reference/keywords/break.md), or [continue](../../../csharp/language-reference/keywords/continue.md), inside the anonymous method block if the target is outside the block. It is also an error to have a jump statement, such as `goto`, `break`, or `continue`, outside the anonymous method block if the target is inside the block.  
  
 The local variables and parameters whose scope contains an anonymous method declaration are called *outer* variables of the anonymous method. For example, in the following code segment, `n` is an outer variable:  
  
 [!code-csharp[csProgGuideDelegates#8](../../../csharp/programming-guide/delegates/codesnippet/CSharp/anonymous-methods_4.cs)]  
  
 A reference to the outer variable `n` is said to be *captured* when the delegate is created. Unlike local variables, the lifetime of a captured variable extends until the delegates that reference the anonymous methods are eligible for garbage collection.  
  
 An anonymous method cannot access the [in](../../../csharp/language-reference/keywords/in.md), [ref](../../../csharp/language-reference/keywords/ref.md) or [out](../../../csharp/language-reference/keywords/out-parameter-modifier.md) parameters of an outer scope.  
  
 No unsafe code can be accessed within the *anonymous-method-block*.  
  
 Anonymous methods are not allowed on the left side of the [is](../../../csharp/language-reference/keywords/is.md) operator.  
  
## Example  
 The following example demonstrates two ways of instantiating a delegate:  
  
-   Associating the delegate with an anonymous method.  
  
-   Associating the delegate with a named method (`DoWork`).  
  
 In each case, a message is displayed when the delegate is invoked.  
  
 [!code-csharp[csProgGuideDelegates#4](../../../csharp/programming-guide/delegates/codesnippet/CSharp/anonymous-methods_5.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Delegates](../../../csharp/programming-guide/delegates/index.md)  
 [Lambda Expressions](../../../csharp/programming-guide/statements-expressions-operators/lambda-expressions.md)  
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)  
 [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)  
 [Delegates with Named vs. Anonymous Methods](../../../csharp/programming-guide/delegates/delegates-with-named-vs-anonymous-methods.md)
