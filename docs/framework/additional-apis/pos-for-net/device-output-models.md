---
title: Device Output Models
description: Device Output Models (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Device Output Models (POS for .NET v1.14 SDK Documentation)

The Unified Point Of Service (UnifiedPOS) output model consists of two output types; synchronous and asynchronous. A POS device type may support one or both types, or neither type.

## Synchronous Output

When an application uses a device type-specific synchronous method to write output, the write operation takes place on the same thread that called the method. The Service Object may not return until the write operation has either been completed or failed.

Using synchronous output is simple, but can potentially impact application performance if the output cannot be completed relatively quickly. Service Object developers should take this into account.

### Asynchronous Output

Certain POS device types support asynchronous output. In the asynchronous output model, the application calls the Service Object to request that data be output to the device. Unlike the synchronous model, however, the Service Object must not wait for the write operation to complete; instead it should return control to the application as soon as possible. When a Service Object receives a request from the application, it should do the following:

- If the physical device is not able to receive data, the Service Object should buffer it in memory until the device is ready.
- Set the **OutputId** property to an identifier for this request, to be used during future events that are sent to the application.
- Return as soon as possible.

The Service Object must then wait for the device to complete the request. Typically, this is done with a separate thread, managed by the Service Object, which monitors the hardware. Once the request is completed successfully, an **OutputCompleteEvent** event, with **OutputEventArgs.OutputId** set to the previously specified identifier, is queued for delivery to the application.

### Service Object Managed Queue

The POS for .NET class library offers support for asynchronous output, which is sufficient for nearly all Service Object scenarios.

There are, however, some scenarios where Service Object developers may need to implement their own asynchronous output handling. The primary scenario is to support devices that support hardware-based print queues. In this case, the Service Object sets **UseExternalPrintQueue** to **true**, overrides the **PreQueuePrintData** method, and implements their own queue mechanism.

When **UseExternalPrintQueue** is set to **true**, the **Base** class no longer adds the print requests to its internal asynchronous queue, so it is up to the Service Object developers to queue data in any way they require. This is often done by using the device's hardware print queuing features. The **Base** class still prevalidates the same print requests but does not do any additional processing.

In these cases, the Service Object will be responsible for the following:

- Implementing its own queuing logic.
- Sending **StatusUpdateEvents** for successful operations.
- Sending **ErrorEvents** for failed asynchronous operations and handling the retry.
- Updating the state property.
- All other asynchronous operations defined in the UnifiedPOS specification.

## See Also

#### Tasks

- [Event Handler Sample](event-handler-sample.md)
- [Asynchronous Output Sample](asynchronous-output-sample.md)
- [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md)

#### Other Resources

- [Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
