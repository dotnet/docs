---
title: The Updated .NET Core Event Pattern
description: Learn how the .NET Core event pattern enables flexibility with backwards compatibility and how to implement safe event processing with async subscribers.
ms.date: 03/11/2025
ms.subservice: fundamentals
ms.topic: article
---
# The updated .NET Core event pattern

[Previous](event-pattern.md)

The previous article discussed the most common event patterns. .NET Core has a more relaxed pattern. In this version, the `EventHandler<TEventArgs>` definition no longer has the constraint that `TEventArgs` must be a class derived from `System.EventArgs`.

This increases flexibility for you, and is backwards compatible. Let's start with the flexibility. The implementation for <xref:System.EventArgs?displayProperty=nameWithType> uses a method defined in <xref:System.Object?displayProperty=nameWithType> one method: <xref:System.Object.MemberwiseClone>, which creates a shallow copy of the object. That method must use reflection in order to implement its functionality for any class derived from `EventArgs`. That functionality is easier to create in a specific derived class. That effectively means that deriving from System.EventArgs is a constraint that limits your designs, but doesn't provide any extra benefit. In fact, you can change the definitions of `FileFoundArgs` and `SearchDirectoryArgs` so that they don't derive from `EventArgs`. The program works exactly the same.

You could also change the `SearchDirectoryArgs` to a struct, if you make one more change:

:::code language="csharp" source="./snippets/events/FinalUpdates.cs" id="StructEventArgs":::

The extra change is to call the parameterless constructor before entering the constructor that initializes all the fields. Without that addition, the rules of C# would report that the properties are being accessed before being assigned.

You shouldn't change the `FileFoundArgs` from a class (reference type) to a struct (value type). The protocol for handling cancel requires that you pass event arguments by reference. If you made the same change, the file search class could never observe any changes made by any of the event subscribers. A new copy of the structure would be used for each subscriber, and that copy would be a different copy than the one seen by the file search object.

Next, let's consider how this change can be backwards compatible. The removal of the constraint doesn't affect any existing code. Any existing event argument types do still derive from `System.EventArgs`. Backwards compatibility is one major reason why they continue to derive from `System.EventArgs`. Any existing event subscribers are subscribers to an event that followed the classic pattern.

Following similar logic, any event argument type created now wouldn't have any subscribers in any existing codebases. New event types that don't derive from `System.EventArgs` doesn't break those codebases.

## Events with Async subscribers

You have one final pattern to learn: How to correctly write event subscribers that call async code. The challenge is described in the article on [async and await](asynchronous-programming/index.md). Async methods can have a void return type, but that is discouraged. When your event subscriber code calls an async method, you have no choice but to create an `async void` method. The event handler signature requires it.

You need to reconcile this opposing guidance. Somehow, you must create a safe `async void` method. The basics of the pattern you need to implement are shown in the following code:

:::code language="csharp" source="./snippets/events/FinalUpdates.cs" id="AsyncEvent":::

First, notice that the handler is marked as an async handler. Because it's being assigned to an event handler delegate type, it has a void return type. That means you must follow the pattern shown in the handler, and not allow any exceptions to be thrown out of the context of the async handler. Because it doesn't return a task, there's no task that can report the error by entering the faulted state. Because the method is async, the method can't throw the exception. (The calling method continues execution because it's `async`.) The actual runtime behavior is defined differently for different environments. It might terminate the thread or the process that owns the thread, or leave the process in an indeterminate state. All of these potential outcomes are highly undesirable.

You should wrap the `await` expression for the async Task in your own try block. If it does cause a faulted task, you can log the error. If it's an error from which your application can't recover, you can exit the program quickly and gracefully

This article explained the major updates to the .NET event pattern. You might see many examples of the earlier versions in the libraries you work with. However, you should understand what the latest patterns are as well. You can see the finished code for the sample at [Program.cs](https://github.com/dotnet/docs/blob/main/docs/csharp/snippets/events/Program.cs).

The next article in this series helps you distinguish between using `delegates` and `events` in your designs. They're similar concepts, and that article helps you make the best decision for your programs.

[Next](distinguish-delegates-events.md)
