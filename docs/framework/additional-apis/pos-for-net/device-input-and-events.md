---
title: Device Input and Events
description: Device Input and Events (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Device Input and Events (POS for .NET v1.14 SDK Documentation)

All POS devices have the ability to generate events or change state independent of the application. For example, if an operator unplugs a **PinPad** device, the application has no direct way of detecting this change since it is not a state change requested by the application. A Service Object must have some way of alerting the application to these state changes.

## Multithreading

Since having the application continuously poll the Service Object for its current state would be far too expensive, another solution is needed. Typically, the solution is to create a background thread to monitor the device.

As other examples have demonstrated, creating a reader thread is always necessary for input devices such scanners or magnetic strip readers. For output devices such as line displays and printers, however, a second thread is often necessary to watch for state changes, such as losing power or going offline, and then to send a **StatusUpdateEvent** event to the application.

In this way, the Service Object can be responsive to requests from the application while asynchronously monitoring the hardware.

### Defining Events

Events are the mechanism by which the Service Object notifies the application of a state change in the device, or the arrival of new data.

In general terms, an event is a notification between one thread or process and another that something has occurred. More specifically, Microsoft Point of Service for .NET (POS for .NET) uses the .NET delegates feature to deliver to the application.

The Unified Point Of Service (UnifiedPOS) specification defines a set of five events: **DataEvent**, **DirectIOEvent**, **ErrorEvent**, **OutputCompleteEvent**, and **StatusUpdateEvent**. Each Service Object may be permitted to only support a subset of these. The exact contents of the data also depends on the Service Object type.

### Event Queues

When you create a Service Object class derived from one of the POS for .NET **Base** classes, events are not sent directly from the Service Object to the application. Instead, events are placed into a queue managed by the **Base** class. Since there are conditions that must be met before events may be delivered to an application, code in the **Base** class dispatches events only when it is appropriate to do so. The Service Object does not need be aware of the queue or of the requirements that must be met before an event can be fired. This greatly eases the burden on the Service Object developer.

The event queue operates asynchronously by using its own thread. This means that the Service Object does not wait for the actual delivery of the event.

### Adding Events to the Queue

The POS for .NET **Base** classes provide a number of ways to add an event to the queue depending on the Service Object and the event type.

Many **Base** classes have helper methods to simplify the queuing of certain events; most commonly, **DataEvent** events. For instance, the method **MsrBase.GoodRead** can be used to queue a **DataEvent** event after a successful card read. Likewise, **PosKeyboard.KeyDown** queues a **DataEvent** indicating that a key has been pressed.

Events may also be queued automatically by the **Base** class when a certain state is changed. For example, if a Service Object has set its **Properties.CapPowerReporting** property, then a **StatusUpdateEvent** indicating a power change can be sent simply by setting the **Properties.PowerState** property in the Service Object.

Finally, if needed a Service Object may specifically queue an event using any of the **QueueEvent** overrides. This may be used most often for sending a **DirectIOEvent**. Since **DirectIOEvent** events are vendor-specific and device-specific, no generic mechanism can be used to queue them.

### Synchronous Input

Although most device input is read asynchronously by the Service Object and then dispatched to the application in the form of events, there are instances, however, where the application may request data from the Service Object and not return until the data is ready or a time-out has been reached. For more information about event-driven input, see [Event Management](event-management.md).

## See Also

#### Tasks

- [Event Handler Sample](event-handler-sample.md)

#### Concepts

- [Event Management](event-management.md)

#### Other Resources

- [Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
