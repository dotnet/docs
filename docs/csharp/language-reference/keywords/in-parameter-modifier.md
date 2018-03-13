---
title: "in parameter modifier (C# Reference)"
ms.date: 03/06/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "parameters [C#], in"
  - "in parameters [C#]"
author: "BillWagner"
ms.author: "wiwagn"
---

# in parameter modifier (C# Reference)

The `in` keyword causes arguments to be passed by reference. It is like the [ref](ref.md) or [out](out-parameter-modifier.md) keywords, except that `in` arguments cannot be modified by the called method, whereas `ref` arguments may be modified,  `out` arguments must be modified by the caller, and those modifications are observable in the calling context.

[!code-csharp-interactive[cs-in-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/InParameterModifier.cs#1)]  

The preceding example demonstrates that the `in` modifier is unnecessary at the call site. It is only required in the method declaration.

> [!NOTE] 
> The `in` keyword can also be used with a generic type parameter to specify that the type parameter is contravariant, as part of a `foreach` statement, or as part of a `join` clause in a LINQ query. For more information on the use of the `in` keyword in these contexts, see [in](in.md) which provides links to all those uses.
  
 Variables passed as `in` arguments must be initialized before being passed in a method call. However, the called method may not assign a value or modify the argument.  
  
 Although the `in`, `ref`, and `out` keywords cause different run-time behavior, they are not considered part of the method signature at compile time. Therefore, methods cannot be overloaded if the only difference is that one method takes a `ref` or `in` argument and the other takes an `out` argument. The following code, for example, will not compile:  
  
```csharp
class CS0663_Example
{
    // Compiler error CS0663: "Cannot define overloaded 
    // methods that differ only on in, ref and out".
    public void SampleMethod(in int i) { }
    public void SampleMethod(ref int i) { }
}
```
  
Overloading based on the presence of `in` is allowed, but generates a compiler warning:  
  
```csharp
class InOverloads
{
    // Discouraged. Calling SampleMethod(value) is ambiguous.
    public void SampleMethod(in int i) { }
    public void SampleMethod(int i) { }
}
```

Properties or constants may be passed as `in` parameters, because the calling method may not modify their values.
  
You can't use the `in`, `ref`, and `out` keywords for the following kinds of methods:  
  
- Async methods, which you define by using the [async](../../../csharp/language-reference/keywords/async.md) modifier.  
  
- Iterator methods, which include a [yield return](../../../csharp/language-reference/keywords/yield.md) or `yield break` statement.  

You typically declare `in` arguments to avoid the copy operations necessary for passing arguments by value. This is most useful when arguments are structures or arrays of structures.

## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Method Parameters](../../../csharp/language-reference/keywords/method-parameters.md)
