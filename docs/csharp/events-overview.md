---
title: Introduction to events
description: Learn about events in .NET and our language design goals for events in this overview.
ms.date: 03/11/2025
---
# Introduction to events

[Previous](delegates-patterns.md)

Events are, like delegates, a *late binding* mechanism. In fact, events are built on the language support for delegates.

Events are a way for an object to broadcast (to all interested components in the system) that something happened. Any other component can subscribe to the event, and be notified when an event is raised.

You probably used events in some of your programming. Many graphical systems have an event model to report user interaction. These events would report mouse movement, button presses, and similar interactions. That's one of the most common, but not the only scenario where events are used.

You can define events that should be raised for your classes. One important consideration when working with events is that there might not be any object registered for a particular event. You must write your code so that it doesn't raise events when no listeners are configured.

Subscribing to an event also creates a coupling between two objects (the event source, and the event sink). You need to ensure that the event sink unsubscribes from the event source when no longer interested in events.

## Design goals for event support

The language design for events targets these goals:

- Enable minimal coupling between an event source and an event sink. These two components might be written by different organizations, and might even be updated on different schedules.
- It should be simple to subscribe to an event, and to unsubscribe from that same event.
- Event sources should support multiple event subscribers. It should also support having no event subscribers attached.

You can see that the goals for events are similar to the goals for delegates. That's why the event language support is built on the delegate language support.

## Language support for events

The syntax for defining events, and subscribing or unsubscribing from events is an extension of the syntax for delegates.

You use the `event` keyword to define an event:

```csharp
public event EventHandler<FileListArgs> Progress;
```

The type of the event (`EventHandler<FileListArgs>` in this example) must be a delegate type. There are conventions that you should follow when declaring an event. Typically, the event delegate type has a void return. Event declarations should be a verb, or a verb phrase. Use past tense when the event reports something that happened. Use a present tense verb (for example, `Closing`) to report something that is about to happen. Often, using present tense indicates that your class supports some kind of customization behavior. One of the most common scenarios is to support cancellation. For example, a `Closing` event can include an argument that would indicate if the close operation should continue, or not. Other scenarios enable callers to modify behavior by updating properties of the event arguments. You can raise an event to indicate a proposed next action an algorithm will take. The event handler might mandate a different action by modifying  properties of the event argument.

When you want to raise the event, you call the event handlers using the delegate invocation syntax:

```csharp
Progress?.Invoke(this, new FileListArgs(file));
```

As discussed in the section on [delegates](delegates-patterns.md), the `?.` operator makes it easy to ensure that you don't attempt to raise the event when there are no subscribers to that event.

You subscribe to an event by using the `+=` operator:

```csharp
EventHandler<FileListArgs> onProgress = (sender, eventArgs) =>
    Console.WriteLine(eventArgs.FoundFile);

fileLister.Progress += onProgress;
```

The handler method typically has the prefix 'On' followed by the event name, as shown in the preceding code.

You unsubscribe using the `-=` operator:

```csharp
fileLister.Progress -= onProgress;
```

It's important that you declare a local variable for the expression that represents the event handler. That ensures the unsubscribe removes the handler. If, instead, you used the body of the lambda expression, you're attempting to remove a handler that was never attached, which does nothing.

In the next article, you'll learn more about typical event patterns, and different variations on this example.

[Next](event-pattern.md)
