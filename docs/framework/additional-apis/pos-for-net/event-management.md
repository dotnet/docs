---
title: Event Management
description: Event Management (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Event Management (POS for .NET v1.14 SDK Documentation)

Events management represents one of the key aspects of programming applications for Microsoft Point of Service for .NET (POS for .NET). All input in the POS for .NET system is event-driven, and each segment of the [POS for .NET Architecture](pos-for-net-architecture.md) uses events to communicate with the other applications and Service Objects.

## Event-Driven Processing Model

Event-driven input begins when an attached POS device receives data input. If that device is enabled (the <xref:Microsoft.PointOfService.PosCommon.DeviceEnabled> property is set to **true**), then received data will be queued as a **DataEvent** event and sent to the application. Events are delivered in a first-in, first-out manner by an internal service thread. Just before this event is raised, a Service Object may use the **PreFireEvent** method to update properties before that event is sent off.

After the event data is received, the device will automatically disable itself (setting the **DeviceEnabled** property to **false**) if the **AutoDisable** property is set to **true**. While disabled, the device cannot queue new input, and the physical device will be disabled, if possible.

When the application is ready to receive input from the device, it sets the **DataEventEnabled** property to **true**. The application then starts to receive queued **DataEvent** events, even if those **DataEvent** events were queued before **DataEventEnabled** property was set to **true**.

Additional data events may be disabled by setting the **DataEventEnabled** property or the <xref:Microsoft.PointOfService.PosCommon.FreezeEvents> property to **false**. This causes later input data to be queued while the application processes the current input and associated properties. When the application is ready for more data, it may re-enable events by setting the **DataEventEnabled** property to **true**.

## Event-Driven Input and Device Sharing

If the input device is an exclusive-use device, the application must both claim and enable the device before it uses it to read input.

If the device is shareable, one or more applications must open and enable the device before it uses it to read input. An application must call the **Claim** method to request exclusive access to the device before the Service Object sends data to it by using **DataEvent**. If event-driven input is received but the device remains unclaimed, the input is buffered until an application claims the device and the **DataEventEnabled** property is set to **true**. This behavior promotes orderly sharing of the device between multiple applications, effectively passing the input focus between them.

## Event-Driven Input and Error Handling

The device enters an error state if an error is encountered while receiving event-driven input. Then it queues an **ErrorEvent** event (that contains **InputData** or **InputErrorEvent** loci). These events are not delivered until the **DataEventEnabled** property is set to **true** to guarantee orderly application sequencing. Each **ErrorEvent** indicates which one of two possible error loci is responsible:

- **InputData** –Used if the error occurred while one or more **DataEvent** events are queued. The **ErrorEvent** jumps to the head of the event queue for immediate handling so that the application can immediately respond by clearing input or notifying the user of the error. Then finish processing the buffered input.
- **Input** – Used if an error has occurred and no data is available. If input data is already queued when the error occurs, an **ErrorEvent** with the **InputData** locus is queued and delivered first, then the remaining **DataEvents** in the queue are raised and handled. Finally, an **ErrorEvent** with the **Input** value is sent to indicate that the queue is empty and no data is available. It is significant to notice that if an **ErrorEvent** with the **InputData** value was delivered and the application event handler responded with a **Clear** value, this **InputDataErrorEvent** is not delivered. Typically, this error is entered at the end of the event queue.

The device may exit the Error state when one of the following occurs:

- The application returns from the **InputErrorEvent**.
    The application returns from the **InputDataErrorEvent** with a **Clear** value for the **ErrorResponse** property.
- The application calls the **ClearInput** method.

For some devices, the application must call a method to begin event-driven input. After the input is received by the Service Object, then typically no additional input will be received until the method is called again. Examples for devices that use this variation of event-driven input, also known as asynchronous input, include the magnetic ink character recognition (MICR) and Signature Capture devices. The **DataCount** property can be read to obtain the number of **DataEvent** events in the queue.

All input in the queue can be deleted by calling the **ClearInput** method. **ClearInput** may be called after **Claim** for exclusive-use devices or **Open** for shareable devices.

The general event-driven input model does not prevent the definition of device classes that contain methods or properties that return input data directly. An example of this variation of event-driven input, also known as synchronous input, is the **Keylock** device.

## Event Types

POS for .NET implements Unified Point Of Service (UnifiedPOS) events as standard .NET events with multicast delegates. The events inform an application of various activities or changes with a device, such as when a device is added or removed. The following table lists the event types.

| Event               | Description                                                                                                                                                                                   |
|---------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| DataEvent           | An event raised by the Service Object to notify the application that input data is available.                                                                                                 |
| ErrorEvent          | An event raised by the Service Object to notify the application that a device error has occurred and that a suitable response by the application is necessary to process the error condition. |
| StatusUpdateEvent   | An event raised by the Service Object to alert the application of a device status change.                                                                                                     |
| OutputCompleteEvent | An event raised by the Service Object to notify the application that the queued output request has been completed successfully.                                                               |
| DirectIOEvent       | An event raised by the Service Object to communicate information directly to the application.                                                                                                 |

The Service Object must stack these events on an internally created and managed queue. Events are delivered in a first-in, first-out manner and are delivered by an internal service thread.

The following conditions cause event delivery to be delayed until the condition is corrected:

- The application has set the **FreezeEvents** property to **true**. The **FreezeEvents** property allows events to be queued but prevents their delivery until **FreezeEvents** is set to **false**.
- The event is a **DataEvent** or an input **ErrorEvent** but the property **DataEventEnabled** is **false**.

Rules for event queue management are as follows:

- The device may only queue new events while the device is enabled.
- The device delivers queued events until the application calls the **Close** method or, for exclusive-use devices, the **Release** method. When these methods are called, any remaining events in the queue are deleted.
- The **ClearInput** method clears **DataEvents** and input **DeviceErrorEvents** (**ErrorLocus** = **Input** or **InputData**).
- The **ClearOutput** method clears output **DeviceErrorEvents** (**ErrorLocus** = **Output**).

## See Also

#### Reference

- <xref:Microsoft.PointOfService.PosCommon.FreezeEvents>
- <xref:Microsoft.PointOfService.PosCommon.StatusUpdateEvent>
- <xref:Microsoft.PointOfService.PosCommon.DirectIOEvent>
- <xref:Microsoft.PointOfService.DeviceErrorEventArgs.ErrorLocus>

#### Concepts

- [Device Output Models](device-output-models.md)
- [POS Exception Handling](pos-exception-handling.md)
