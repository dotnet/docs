---
title: Delegates vs. events
description: Learn the difference between delegates and events and when to use each of these features of .NET Core.
ms.date: 06/20/2016
ms.technology: csharp-fundamentals
ms.assetid: 0fdc8629-2fdb-4a7c-a433-5b9d04eaf911
---

# Distinguishing Delegates and Events

[Previous](modern-events.md)

Developers that are new to the .NET Core platform often struggle
when deciding between a design based on `delegates` and a design
based on `events`. The choice of delegates or events is often difficult, because the two
language features are similar. Events are even built using
the language support for delegates.

They both offer a late binding scenario: they enable scenarios
where a component communicates by calling a method that is only
known at runtime. They both support single and multiple subscriber
methods. You may find this referred to as singlecast and multicast
support. They both support similar syntax for adding and removing
handlers. Finally, raising an event and calling a delegate use exactly the same method call syntax. They even both support the same `Invoke()`
method syntax for use with the `?.` operator.

With all those similarities, it is easy to have trouble determining when
to use which.

## Listening to Events is Optional

The most important consideration in determining which language feature
to use is whether or not there must be an attached subscriber. If your
code must call the code supplied by the subscriber, you should
use a design based on delegates when you need to implement callback. If your code can complete all its
work without calling any subscribers, you should use a
design based on events.

Consider the examples built during this section. The code you built
using `List.Sort()` must be given a comparer function in order to
properly sort the elements. LINQ queries must be supplied with delegates
in order to determine what elements to return. Both used a design built
with delegates.

Consider the `Progress` event. It reports progress on a task.
The task continues to proceed whether or not there are any listeners.
The `FileSearcher` is another example. It would still search and find
all the files that were sought, even with no event subscribers attached.
UX controls still work correctly, even when there are no subscribers
listening to the events. They both use designs based on events.

## Return Values Require Delegates

Another consideration is the method prototype you would want for your
delegate method. As you've seen, the delegates used for events all
have a void return type. You've also seen that there are idioms to
create event handlers that do pass information back to event sources
through modifying properties of the event argument object. While these
idioms do work, they are not as natural as returning a value from a
method.

Notice that these two heuristics may often both be present: If your
delegate method returns a value, it will likely impact the algorithm
in some way.

## Events Have Private Invocation

Classes other than the one in which an event is contained can only add
and remove event listeners; only the class containing the event can
invoke the event. Events are typically public class members.
By comparison, delegates are often passed as parameters and stored as
private class members, if they are stored at all.

## Event Listeners Often Have Longer Lifetimes

That event listeners have longer lifetimes is a slightly weaker justification. However, you may find that event-based designs are more natural when the event source will be
raising events over a long period of time. You can see examples of
event-based design for UX controls on many systems. Once you subscribe to an event,
the event source may raise events throughout the lifetime of the program.
(You can unsubscribe from events when you no longer need them.)

Contrast that with many delegate-based designs, where a delegate is
used as an argument to a method, and the delegate is not used after that
method returns.

## Evaluate Carefully

The above considerations are not hard and fast rules. Instead, they
represent guidance that can help you decide which choice is best for
your particular usage. Because they are similar, you can even
prototype both, and consider which would be more natural to work
with. They both handle late binding scenarios well. Use the one
that communicates your design the best.
