---
title: "Delegates with Named vs. Anonymous Methods"
description: Learn about delegates with named vs. anonymous methods. See code examples and view additional available resources.
ms.date: 11/22/2024
helpviewer_keywords: 
  - "delegates [C#], with named vs. anonymous methods"
  - "methods [C#], in delegates"
ms.assetid: 98fa8c61-66b6-4146-986c-3236c4045733
---
# Delegates with Named vs. Anonymous Methods (C# Programming Guide)

A [delegate](../../language-reference/builtin-types/reference-types.md) can be associated with a named method. When you instantiate a delegate by using a named method, the method is passed as a parameter, for example:

[!code-csharp[csProgGuideDelegates#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#1)]

This is called using a named method. Delegates constructed with a named method can encapsulate either a [static](../../language-reference/keywords/static.md) method or an instance method. Named methods are the only way to instantiate a delegate in earlier versions of C#. However, in a situation where creating a new method is unwanted overhead, C# enables you to instantiate a delegate and immediately specify a code block that the delegate will process when it is called. The block can contain either a [lambda expression](../../language-reference/operators/lambda-expressions.md) or an [anonymous method](../../language-reference/operators/delegate-operator.md).

The method that you pass as a delegate parameter must have the same signature as the delegate declaration. A delegate instance may encapsulate either static or instance method.

> [!NOTE]
> Although the delegate can use an [out](../../language-reference/keywords/method-parameters.md#out-parameter-modifier) parameter, we do not recommend its use with multicast event delegates because you cannot know which delegate will be called.

Method groups with a single overload have a *natural type*. This means the compiler can infer the return type and parameter types for the delegate type:

```csharp
var read = Console.Read; // Just one overload; Func<int> inferred
var write = Console.Write; // ERROR: Multiple overloads, can't choose
```

## Examples

The following is a simple example of declaring and using a delegate. Notice that both the delegate, `MultiplyCallback`, and the associated method, `MultiplyNumbers`, have the same signature

[!code-csharp[csProgGuideDelegates#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#2)]

In the following example, one delegate is mapped to both static and instance methods and returns specific information from each.

[!code-csharp[csProgGuideDelegates#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#3)]

## See also

- [Delegates](./index.md)
- [How to combine delegates (Multicast Delegates)](./how-to-combine-delegates-multicast-delegates.md)
- [Events](../events/index.md)
