# Introduction to Events

By [Bill Wagner](https://github.com/BillWagner)

[Previous](delegates-patterns.md)

Events are, like delegates, a *late binding* mechanism. In fact,
events are built on the language support for delegates.

Events are a way for an object to broadcast (to all interested
components in the system) that something has happened. Any other
component can subscribe to the event, and be notified when an event
is raised.

You've probably used events in some of your programming. Many graphical
systems have an event model to report user interaction. These events would
report mouse movement, button presses and similar interactions. That's one
of the most common, but certainly not the only scenario where events are
used.

You can define events that should be raised for your classes. One important
consideration when working with events is that there may not be any
object registered for a particular event. You must write your code so that
it does not raise events when no listeners are configured.

Subscribing to an event also creates a coupling between two objects (the event
source, and the event sink). You need to ensure that the event sink unsubscribes
from the event source when no longer interested in events.

# Design Goals for Event Support

The language design for events targets these goals.

First, enable very minimal
coupling between an event source and an event sink. These two components may
not be written by the same organization, and may even be updated on totally
different schedules.

Secondly, it should be very simple to subscribe to an event, and to
unsubscribe from that same event.

And finally, event sources should support multiple event subscribers. It should
also support having no event subscribers attached.

You can see that the goals for events are very similar to the goals for delegates.
That's why the event language support is built on the delegate language support.

# Language Support for Events

The syntax for defining events, and subscribing or unsubscribing from events is
an extension of the syntax for delegates.

To define an event you use the `event` keyword:

```cs
public event EventHandler<FileListArgs> OnProgress;
```

The type of the event (`EventHandler<FileListArgs`> in this example) must be a
delegate type. There are a number of conventions that you should follow
when declaring an event. Typically, the event delegate type has a void return.
Prefix event declarations with 'On'.
The remainder of the name is a verb. Use past tense (as in this example) when
the event reports something that has happened. Use a present tense verb (for
example, `OnClosing`) to report something that is about to happen. Often, using
present tense indicates that the event supports cancellation. For example,
an `OnClosing` event may include an argument that would indicate if the close
operation should continue, or not.  

When you want to raise the event, you call the event using the delegate invocation
syntax:

```cs
OnProgress?.Invoke(this, new FileListArgs(file));
```

As discussed in the section on [delegates](delegates-patterns.md), the ?.
operator makes it easy to ensure that you do not attempt to raise the event
when there are no subscribers to that event.
 
You subscribe to an event by using the `+=` operator:

```cs
EventHandler<FileListArgs> handler = (sender, eventArgs) => 
    Console.WriteLine(eventArgs.FoundFile);
lister.OnProgress += handler;
```

You unsubscribe using the `-=` operator:

```cs
lister.OnProgress -= handler;
```

It's important to note that I declared a local variable for the expression that
represents the event handler. That ensures the unsubscribe removes the handler.
If, instead, you used the body of the lambda expression, you are attempting
to remove a handler that has never been attached, which does nothing.

In the next article, you'll learn more about typical event patterns, and
different variations on this example.

[Next](event-pattern.md)