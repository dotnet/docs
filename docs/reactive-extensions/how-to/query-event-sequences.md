---
title: Query event-based observable sequences in .NET
description: Learn how to query event-based observable sequences using Reactive Extensions in .NET.
author: IEvangelist
ms.date: 11/06/2020
ms.author: dapine
ms.topic: how-to
---

# Query event-based observable sequences in .NET

Rx provides factory methods for you to bridge with existing asynchronous sources in .NET so that you can employ the rich composing, filtering and resource management features provided by Rx on any kind of data streams. This topic examines the FromEventPattern operator that allows "importing" a .NET event into Rx as an observable sequence. Every time an event is raised, an OnNext message will be delivered to the observable sequence. You can then manipulate event data just like any other observable sequences.

Rx does not aim at replacing existing asynchronous programming models such as .NET events, the asynchronous pattern or the Task Parallel Library. However, when you attempt to compose events, Rx's factory methods will provide you the convenience that cannot be found in the current programming model. This is especially true for resource maintenance (e.g., when to unsubscribe) and filtering (e.g., choosing what kind of data to receive). In this topic and the ones that follow, you can examine how these Rx features can assist you in asynchronous programming.

## Converting a .NET event to a Rx Observable Sequence

The following sample creates a simple .NET event handler for the mouse move event, and prints out the mouse's location in a label on a Windows form.

```csharp
using System.Linq;
using System.Windows.Forms;
using System.Reactive;
using System.Reactive.Linq;
using System;
using WinForm;
using System.Reactive.Disposables;

class Program
{
    static void Main()
    {
        var lbl = new Label();
        var frm = new Form { Controls = { lbl } };
        frm.MouseMove += (sender, args) =>
        {
            lbl.Text = args.Location.ToString();
        };
        Application.Run(frm);
    }
}
```

To import an event into Rx, you can use the FromEventPattern operator, and provide the EventArgs objects that will be raised by the event being bridged. The FromEventPattern operator works with events that take an object sender and some EventArgs, and uses reflection to find those add/remove methods for you. It then converts the given event into an observable sequence with an EventPattern type that captures both the sender and the event arguments.

For delegates that have one parameter (non-standard events), you can use the FromEvent operator which takes a pair of functions used to attach and detach a handler.

In the following example, we convert the mouse-move event stream of a Windows form into an observable sequence. Every time a mouse-move event is fired, the subscriber will receive an OnNext notification. We can then examine the EventArgs value of such notification and get the location of the mouse-move.

```csharp
using System.Linq;
using System.Windows.Forms;
using System.Reactive;
using System.Reactive.Linq;
using System;
using WinForm;
using System.Reactive.Disposables;

class Program
{
    static void Main()
    {
        var lbl = new Label();
        var frm = new Form { Controls = { lbl } };
        IObservable<EventPattern<MouseEventArgs>> move =
            Observable.FromEventPattern<MouseEventArgs>(frm, "MouseMove");

        move.Subscribe(
            evt => lbl.Text = evt.EventArgs.Location.ToString());

        Application.Run(frm);
    }
}
```

Notice that in this sample, `move` becomes an observable sequence in which we can manipulate further. The [Querying Observable Sequences using LINQ Operators](hh242983\(v=vs.103\).md) topic will show you how you can project this sequence into a collection of Points type and filter its content, so that your application will only receive values that satisfy a certain criteria.

Cleaning up of the event handler is taken care of by the IDisposable object returned by the Subscribe method. Calling Dispose (done by reaching the end of the using-block in this example) will release all resources being used by the sequence including the underlying event handler. This essentially takes care of unsubscribing to an event on your behalf.

## See also

- [Query observable sequences using LINQ operators](query-sequences-linq.md)
- [Query asynchronous observable sequences](query-async-sources.md)
- [Use schedulers with observables](use-schedulers.md)
