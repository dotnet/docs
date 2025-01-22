---
title: "Delegates with Named vs. Anonymous Methods"
description: Learn about delegates with named vs. anonymous methods. See code examples and view other available resources.
ms.date: 12/20/2024
helpviewer_keywords: 
  - "delegates [C#], with named vs. anonymous methods"
  - "methods [C#], in delegates"
---
# Delegates with Named vs. Anonymous Methods (C# Programming Guide)

A [delegate](../../language-reference/builtin-types/reference-types.md) can be associated with a named method. When you instantiate a delegate by using a named method, the method is passed as a parameter, for example:

:::code language="csharp" source="./snippets/NamedAnonymousDelegates.cs" id="NamedDelegate":::

The preceding example uses a named method. Delegates constructed with a named method can encapsulate either a [static](../../language-reference/keywords/static.md) method or an instance method. Named methods are the only way to instantiate a delegate in earlier versions of C#. C# enables you to instantiate a delegate and immediately specify a code block that the delegate processes when called. The block can contain either a [lambda expression](../../language-reference/operators/lambda-expressions.md) or an [anonymous method](../../language-reference/operators/delegate-operator.md), as shown in the following example:

:::code language="csharp" source="./snippets/NamedAnonymousDelegates.cs" id="SnippetAnonymousMethod":::

The method that you pass as a delegate parameter must have the same signature as the delegate declaration. A delegate instance can encapsulate either static or instance method.

> [!NOTE]
> Although the delegate can use an [out](../../language-reference/keywords/method-parameters.md#out-parameter-modifier) parameter, we do not recommend its use with multicast event delegates because you cannot know which delegate will be called.

Method groups with a single overload have a *natural type*. The compiler can infer the return type and parameter types for the delegate type:

```csharp
var read = Console.Read; // Just one overload; Func<int> inferred
var write = Console.Write; // ERROR: Multiple overloads, can't choose
```

## Examples

The following example is a simple example of declaring and using a delegate. Notice that both the delegate, `MultiplyCallback`, and the associated method, `MultiplyNumbers`, have the same signature

:::code language="csharp" source="./snippets/NamedAnonymousDelegates.cs" id="DeclareAndUse":::

In the following example, one delegate is mapped to both static and instance methods and returns specific information from each.

:::code language="csharp" source="./snippets/NamedAnonymousDelegates.cs" id="AnotherSample":::

## See also

- [Delegates](./index.md)
- [How to combine delegates (Multicast Delegates)](./how-to-combine-delegates-multicast-delegates.md)
- [Events](../events/index.md)
