---
title: System.Delegate and the `delegate` keyword
description: Learn about the classes in .NET that support delegates and how those map to the 'delegate' keyword.
ms.date: 06/20/2016
ms.subservice: fundamentals
ms.assetid: f3742fda-13c2-4283-8966-9e21c2674393
---

# System.Delegate and the `delegate` keyword

[Previous](delegates-overview.md)

This article covers the classes in .NET that support delegates, and how those map to the `delegate` keyword.

## What are delegates?

Think of a delegate as a way to store a reference to a method, similar to how you might store a reference to an object. Just as you can pass objects to methods, you can pass method references using delegates. This is incredibly useful when you want to write flexible code where different methods can be "plugged in" to provide different behaviors.

For example, imagine you have a calculator that can perform operations on two numbers. Instead of hard-coding addition, subtraction, multiplication, and division into separate methods, you could use delegates to represent any operation that takes two numbers and returns a result.

## Define delegate types

Now let's see how to create delegate types using the `delegate` keyword. When you define a delegate type, you're essentially creating a template that describes what kind of methods can be stored in that delegate.

You define a delegate type using syntax that looks similar to a method signature, but with the `delegate` keyword at the beginning:

```csharp
// Define a simple delegate that can point to methods taking two integers and returning an integer
public delegate int Calculator(int x, int y);
```

This `Calculator` delegate can hold references to any method that takes two `int` parameters and returns an `int`.

Let's look at a more practical example. When you want to sort a list, you need to tell the sorting algorithm how to compare items. Let's see how delegates help with the `List.Sort()` method. The first step is to create a delegate type for the comparison operation:

```csharp
// From the .NET Core library
public delegate int Comparison<in T>(T left, T right);
```

This `Comparison<T>` delegate can hold references to any method that:

- Takes two parameters of type `T`
- Returns an `int` (typically -1, 0, or 1 to indicate "less than", "equal to", or "greater than")

When you define a delegate type like this, the compiler automatically generates a class derived from `System.Delegate` that matches your signature. This class handles all the complexity of storing and invoking the method references for you.

The `Comparison` delegate type is a generic type, which means it can work with any type `T`. For more information about generics, see [Generic classes and methods](./fundamentals/types/generics.md).

Notice that even though the syntax looks similar to declaring a variable, you're actually declaring a new *type*. You can define delegate types inside classes, directly inside namespaces, or even in the global namespace.

> [!NOTE]
> Declaring delegate types (or other types) directly in
> the global namespace is not recommended.

The compiler also generates add and remove handlers for this new type so that clients of this class can add and remove methods from an instance's invocation list. The compiler enforces that the signature of the method being added or removed matches the signature used when declaring the delegate type.

## Declare instances of delegates

After defining the delegate type, you can create instances (variables) of that type. Think of this as creating a "slot" where you can store a reference to a method.

Like all variables in C#, you cannot declare delegate instances directly in a namespace or in the global namespace.

```csharp
// Inside a class definition:
public Comparison<T> comparator;
```

The type of this variable is `Comparison<T>` (the delegate type you defined earlier), and the name of the variable is `comparator`. At this point, `comparator` doesn't point to any method yet—it's like an empty slot waiting to be filled.

You can also declare delegate variables as local variables or method parameters, just like any other variable type.

## Invoke delegates

Once you have a delegate instance that points to a method, you can call (invoke) that method through the delegate. You invoke the methods that are in the invocation list of a delegate by calling that delegate as if it were a method.

Here's how the `Sort()` method uses the comparison delegate to determine the order of objects:

```csharp
int result = comparator(left, right);
```

In this line, the code *invokes* the method attached to the delegate. You treat the delegate variable as if it were a method name and call it using normal method call syntax.

However, this line of code makes an unsafe assumption: it assumes that a target method has been added to the delegate. If no methods have been attached, the line above would cause a `NullReferenceException` to be thrown. The patterns used to address this problem are more sophisticated than a simple null-check, and are covered later in this [series](delegates-patterns.md).

## Assign, add, and remove invocation targets

Now you know how to define delegate types, declare delegate instances, and invoke delegates. But how do you actually connect a method to a delegate? This is where delegate assignment comes in.

To use a delegate, you need to assign a method to it. The method you assign must have the same signature (same parameters and return type) as the delegate type defines.

Let's see a practical example. Suppose you want to sort a list of strings by their length. You need to create a comparison method that matches the `Comparison<string>` delegate signature:

```csharp
private static int CompareLength(string left, string right) =>
    left.Length.CompareTo(right.Length);
```

This method takes two strings and returns an integer indicating which string is "greater" (longer in this case). The method is declared as private, which is perfectly fine. You don't need the method to be part of your public interface to use it with a delegate.

Now you can pass this method to the `List.Sort()` method:

```csharp
phrases.Sort(CompareLength);
```

Notice that you use the method name without parentheses. This tells the compiler to convert the method reference into a delegate that can be invoked later. The `Sort()` method will call your `CompareLength` method whenever it needs to compare two strings.

You can also be more explicit by declaring a delegate variable and assigning the method to it:

```csharp
Comparison<string> comparer = CompareLength;
phrases.Sort(comparer);
```

Both approaches accomplish the same thing. The first approach is more concise, while the second makes the delegate assignment more explicit.

For simple methods, it's common to use [lambda expressions](language-reference/operators/lambda-expressions.md) instead of defining a separate method:

```csharp
Comparison<string> comparer = (left, right) => left.Length.CompareTo(right.Length);
phrases.Sort(comparer);
```

Lambda expressions provide a compact way to define simple methods inline. Using lambda expressions for delegate targets is covered in more detail in a [later section](delegates-patterns.md).

The examples so far show delegates with a single target method. However, delegate objects can support invocation lists that have multiple target methods attached to a single delegate object. This capability is particularly useful for event handling scenarios.

## Delegate and MulticastDelegate classes

Behind the scenes, the delegate features you've been using are built on two key classes in the .NET framework: <xref:System.Delegate> and <xref:System.MulticastDelegate>. You don't usually work with these classes directly, but they provide the foundation that makes delegates work.

The `System.Delegate` class and its direct subclass `System.MulticastDelegate` provide the framework support for creating delegates, registering methods as delegate targets, and invoking all methods that are registered with a delegate.

Here's an interesting design detail: `System.Delegate` and `System.MulticastDelegate` are not themselves delegate types that you can use. Instead, they serve as the base classes for all the specific delegate types you create. The C# language prevents you from directly inheriting from these classes—you must use the `delegate` keyword instead.

When you use the `delegate` keyword to declare a delegate type, the C# compiler automatically creates a class derived from `MulticastDelegate` with your specific signature.

### Why this design?

This design has its roots in the first release of C# and .NET. The design team had several goals:

1. **Type Safety**: The team wanted to ensure that the language enforced type safety when using delegates. This means ensuring that delegates are invoked with the correct type and number of arguments, and that return types are correctly verified at compile time.

2. **Performance**: By having the compiler generate concrete delegate classes that represent specific method signatures, the runtime can optimize delegate invocations.

3. **Simplicity**: Delegates were included in the 1.0 .NET release, which was before generics were introduced. The design needed to work within the constraints of the time.

The solution was to have the compiler create the concrete delegate classes that match your method signatures, ensuring type safety while hiding the complexity from you.

### Working with delegate methods

Even though you can't create derived classes directly, you'll occasionally use methods defined on the `Delegate` and `MulticastDelegate` classes. Here are the most important ones to know about:

Every delegate you work with is derived from `MulticastDelegate`. A "multicast" delegate means that more than one method target can be invoked when calling through a delegate. The original design considered making a distinction between delegates that could only invoke one method versus delegates that could invoke multiple methods. In practice, this distinction proved less useful than originally thought, so all delegates in .NET support multiple target methods.

The most commonly used methods when working with delegates are:

- `Invoke()`: Calls all the methods attached to the delegate
- `BeginInvoke()` / `EndInvoke()`: Used for asynchronous invocation patterns (though `async`/`await` is now preferred)

In most cases, you won't call these methods directly. Instead, you'll use the method call syntax on the delegate variable, as shown in the examples above. However, as you'll see [later in this series](delegates-patterns.md), there are patterns that work directly with these methods.

## Summary

Now that you've seen how the C# language syntax maps to the underlying .NET classes, you're ready to explore how strongly typed delegates are used, created, and invoked in more complex scenarios.

[Next](delegates-strongly-typed.md)
