---
title: "Lambda expressions, delegates, and events"
description: Learn what lambda expressions are in C#, how delegates work as the type system support for lambda expressions, how to use the built-in Func and Action types, and how events use delegates for notifications.
ms.date: 04/27/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Lambda expressions, delegates, and events

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. Build core type and method skills there before you use lambda expressions.

Sometimes you want to pass a small piece of behavior, a function, directly to another method. For example, you might want to filter a list, but the filtering condition changes depending on the situation. Rather than writing a separate named method for every possible condition, you pass the condition itself as an argument.

*Lambda expressions* are the C# feature that makes this possible. A lambda expression is a compact, inline function that you write without giving it a name. You use the arrow operator `=>` to separate the parameter list from the body:

```csharp
x => x * 2
```

Reading left to right: `x` is the input parameter, `=>` means "goes to," and `x * 2` is the body. It computes the value returned. When there are no parameters or more than one, wrap them in parentheses: `() => 42` or `(left, right) => left + right`.

## Delegates support lambda expressions

To use a lambda expression, the C# compiler needs to know two things: the types of the parameters and the return type. That description, the parameter types plus return type, is called a *delegate type*.

A delegate type is a type that represents a method signature. A variable of a delegate type can hold any matching method such as a lambda expression or a named method, as long as its parameter types and return type match.

You declare a delegate type with the `delegate` keyword:

```csharp
delegate int Transform(int value);
```

This declaration says: "`Transform` is a delegate type for methods that accept one `int` and return an `int`." You can then assign a lambda expression or a named method to a variable of that type:

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="DelegateBasics":::

Both `doubler` and `squarer` hold a value of type `Transform`. You call them exactly like regular methods. The compiler verifies that whatever you assign matches the declared signature.

## Built-in delegate types: `Func` and `Action`

Declaring a custom delegate type for every situation can be repetitive. .NET provides two families of generic delegate types, `Func` and `Action`, that cover most scenarios, so you rarely need to use the `delegate` keyword yourself.

Both families come in versions with zero to sixteen input type parameters, so they scale to any number of inputs. The key difference between the two families is:

- <xref:System.Func`2?displayProperty=nameWithType> (and `Func<T1, T2, TResult>`, and so on) represents a method that **returns a value**. The last type parameter is always the return type; all earlier ones are input types.
- <xref:System.Action`1?displayProperty=nameWithType> (and `Action<T1, T2>`, and so on) represents a method that **returns nothing** (`void`). All type parameters are input types. <xref:System.Action?displayProperty=nameWithType> with no type parameters represents a method with no inputs and no return value.

For example, `Func<int, int, int>` describes a method with two `int` inputs and one `int` result. `Action<string>` describes a method with one `string` input and no return value.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="FuncAndAction":::

Use descriptive parameter names in lambdas so readers can understand intent without scanning the full method body.

## Pass a lambda expression to a method

When a method declares a `Func` or `Action` parameter, callers pass a lambda expression that matches that delegate type. The compiler checks that the lambda's parameter types and return type match the declared delegate type. If they don't match, the code doesn't compile.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="LambdaAsArgument":::

The `Filter` method declares a `Func<int, bool>` parameter named `predicate`. The `Func<int, bool>` type tells callers the expected shape: one `int` input, one `bool` result. The caller passes `value => value % 2 == 0` as that argument. This pattern appears throughout LINQ and many .NET APIs.

## Keep lambda expressions self-contained

A lambda expression can reference variables from the surrounding code. *Capturing* means the lambda holds a reference to a variable declared outside its own body. The combination of the lambda and the variables it captures is called a *closure*.

When you don't need to capture anything, add the `static` modifier to the lambda. A static lambda can only use its own parameters and values declared inside its body. It can't capture local variables or instance state from the enclosing scope.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="StaticLambda":::

Static lambdas make intent clear and prevent accidental captures.

## Use discard parameters when inputs are irrelevant

Sometimes a delegate signature includes parameters you don't need. Use the discard `_` to signal that choice explicitly.

Common examples include event handlers where you don't use `sender` or `EventArgs`, callbacks where you only need some of several inputs, and LINQ overloads that provide an index you don't use.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="DiscardParameters":::

Discards improve readability because they show which parameters matter.

## Events provide optional notifications

An *event* is a mechanism that one object (the *publisher*) uses to notify other objects (the *subscribers*) when something happens. The publisher doesn't need to know who is listening or how many subscribers there are. Subscribers choose to opt in.

Events are built on delegates. An event is a delegate field with extra restrictions enforced by the `event` keyword: outside code can only subscribe (`+=`) or unsubscribe (`-=`) from the event; only the class that declares the event can invoke (raise) it.

The .NET convention for event delegate types is <xref:System.EventHandler`1?displayProperty=nameWithType>, where `T` is the type of data included with the notification. Its signature always has two parameters: the `sender` (the object that raised the event) and the event data of type `T`.

:::code language="csharp" source="snippets/delegates-lambdas/Program.cs" ID="MinimalEventIntro":::

Walking through the code:

- `MessagePublisher` declares `event EventHandler<string>? MessagePublished`. The `event` keyword means callers can only subscribe or unsubscribe—they can't invoke it directly.
- `publisher.MessagePublished += (_, message) => ...` subscribes with a lambda expression. The `_` discards the `sender` parameter because this handler doesn't need it.
- `publisher.Publish("Records updated")` raises the event and runs every subscribed handler.

Subscribing is optional. The `?.Invoke(...)` in the `Publish` method means the event raises only when at least one subscriber is attached. The publisher raises the event without knowing or caring whether anyone is listening.

## See also

- [Type system overview](index.md)
- [Methods](../../methods.md)
- [Pattern matching](../functional/pattern-matching.md)
- [Events (C# programming guide)](../../programming-guide/events/index.md)
