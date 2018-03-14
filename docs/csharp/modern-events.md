---
title: The Updated .NET Core Event Pattern
description: Learn how the .NET Core event pattern enables flexibility with backwards compatibility and how to implement safe event processing with async subscribers.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 9aa627c3-3222-4094-9ca8-7e88e1071e06
---

# The Updated .NET Core Event Pattern

[Previous](event-pattern.md)

The previous article discussed the most common event patterns. .NET
Core has a more relaxed pattern. In this version, the 
`EventHandler<TEventArgs>` definition no longer has the constraint that
`TEventArgs` must be a class derived from `System.EventArgs`.

This increases flexibility for you, and is backwards compatible. Let's
start with the flexibility. The class System.EventArgs introduces one
method: `MemberwiseClone()`, which creates a shallow copy of the object.
That method must use reflection in order to implement
its functionality for any class derived from `EventArgs`. That
functionality is easier to create in a specific derived class. That
effectively means that deriving from System.EventArgs is a constraint
that limits your designs, but does not provide any additional benefit.
In fact, you can changes the definitions of `FileFoundArgs` and
`SearchDirectoryArgs` so that they do not derive from `EventArgs`.
The program will work exactly the same.

You could also change the `SearchDirectoryArgs` to a struct, if you
also make one more change:

```csharp  
internal struct SearchDirectoryArgs  
{  
    internal string CurrentSearchDirectory { get; }  
    internal int TotalDirs { get; }  
    internal int CompletedDirs { get; }  
    
    internal SearchDirectoryArgs(string dir, int totalDirs, 
        int completedDirs) : this()  
    {  
        CurrentSearchDirectory = dir;  
        TotalDirs = totalDirs;  
        CompletedDirs = completedDirs;  
    }  
}  
```   

The additional change is to call the default constructor before
entering the constructor that initializes all the fields. Without
that addition, the rules of C# would report that the properties are
being accessed before they have been assigned.

You should not change the `FileFoundArgs` from a class (reference
type) to a struct (value type). That's because the protocol for
handling cancel requires that the event arguments are passed by reference. If you made the same change, the file search class could
never observe any changes made by any of the event subscribers. A new
copy of the structure would be used for each subscriber, and that
copy would be a different copy than the one seen by the file search
object.

Next, let's consider how this change can be backwards compatible.
The removal of the constraint does not affect any existing code. Any
existing event argument types do still derive from `System.EventArgs`.
Backwards compatibility is one major reason why they will continue
to derive from `System.EventArgs`. Any existing event subscribers will
be subscribers to an event that followed the classic pattern.

Following similar logic, any event argument type created now would
not have any subscribers in any existing codebases. New event types
that do not derive from `System.EventArgs` will not break those
codebases.

## Events with Async subscribers

You have one final pattern to learn: How to correctly write event
subscribers that call async code. The challenge is described in
the article on [async and await](async.md). Async methods can
have a void return type, but that is strongly discouraged. When your
event subscriber code calls an async method, you have no choice but
to create an `async void` method. The event handler signature requires
it.

You need to reconcile this opposing guidance. Somehow, you must
create a safe `async void` method. The basics of the pattern you need
to implement are below:

```csharp
worker.StartWorking += async (sender, eventArgs) =>
{
    try 
    {
        await DoWorkAsync();
    }
    catch (Exception e)
    {
        //Some form of logging.
        Console.WriteLine($"Async task failure: {e.ToString()}");
        // Consider gracefully, and quickly exiting.
    }
};
```

First, notice that the handler is marked as an async handler. Because
it is being assigned to an event handler delegate type, it will have
a void return type. That means you must follow the pattern shown in the
handler, and not allow any exceptions to be thrown out of the context
of the async handler. Because it does not return a task, there is no
task that can report the error by entering the faulted state. Because
the method is async, the method can't simply throw the exception. (The
calling method has continued execution because it is `async`.) The
actual runtime behavior will be defined differently for different
environments. It may terminate the thread, it may terminate the program,
or it may leave the program in an undetermined state. None of those
are good outcomes.

That's why you should wrap the await statement for the async Task
in your own try block. If it does cause a faulted task, you can
log the error. If it is an error from which your application cannot
recover, you can exit the program quickly and gracefully

Those are the major updates to the .NET event pattern. You will see many
examples of the earlier versions in the libraries you work with. However,
you should understand what the latest patterns are as well.

The next article in this series helps you distinguish between using
`delegates` and `events` in your designs. They are similar concepts,
and that article will help you make the best decision for your
programs.

[Next](distinguish-delegates-events.md)
