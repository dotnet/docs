---
title: Scanner Events
description: Scanner Events (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# Scanner Events (POS for .NET v1.14 SDK Documentation)

Bar code scanners operate asynchronously and therefore have to notify applications when data is available, or the device state has changed. You perform this task by using .NET delegates to raise events to the application.

As discussed in the [Device Input and Events](device-input-and-events.md) topic, events are queued before they are delivered to the application. The Microsoft Point of Service for .NET (POS for .NET) **Base** classes provide a means for Service Object code to queue events so that their delivery to the application can be deferred until the application can process them. Meanwhile, the Service Object can continue waiting for additional incoming hardware events.

The Scanner device can send four events to the application. For two of these events, **DataEvent** and **ErrorEvent**, the POS for .NET <xref:Microsoft.PointOfService.BaseServiceObjects.ScannerBase> class provides a protected helper method to simplify the code that is required to raise these events:

| Event      | Method That Queues the Event            |
|------------|-----------------------------------------|
| DataEvent  | Protected method ScannerBase.GoodRead   |
| ErrorEvent | Protected method ScannerBase.FailedRead |

The two other events, **DirectIOEvent** and **StatusUpdateEvent**, must be raised by using members of the lower-level **ScannerBasic** class. For more information, see [Device Input and Events](device-input-and-events.md).

Because a Scanner device can deliver data to the system at any time, a Scanner Service Object must wait for data asynchronously by starting a separate reader thread. Events should be queued from this thread as data arrives from the device.

## To raise events based on device input

1. Start a reader thread to wait for input from the device.

2. Wait for input on the reader thread, most frequently by using Win32 direct functions to read data from the USB bus.

3. After you receive data, verify that the data is valid, for example, that there are enough bytes in the packet for the header and the data type.

4. If the data is not valid, call the **ScannerBase.FailedScan** method to queue an **ErrorEvent** event that will be raised in the application.

5. If the data is valid, call the **ScannerBase.GoodScan** method to queue a **DataEvent** event that will eventually be raised in the application.

## Example

As soon as input is received from the device, the Service Object queues the appropriate event. You can do this by writing a method, such as the one in the sample in this topic that would be called from the reader thread of the Service Object.

```csharp
// A Service Object may implement a method such as this one to
// be called from the reader thread of the Service Object.
void OnDataScanned(byte[] data)
{
    // Ignore input if process in the Error state. There is no
    // need to send an ErrorEvent to the application, because it has
    // already been notified by this point.
    if (State == ControlState.Error)
    {
        return;
    }

    // Make sure that the incoming buffer is large enough to contain
    // at least the header and type data.
    if ((int)data[1] < 5)
    {
        // By calling FailedRead, you are queueing an
        // ErrorEvent for eventual delivery to the application.
        FailedScan();
    }
    else
    {
        // The buffer received from the device will be longer
        // than we need. Therefore, trim it down. Allocate space for
        // the number of bytes contained in data[1], plus one
        // more for the first byte in the buffer.
        byte[] b = new byte[(int)data[1] + 1];

        // Copy the data into a new buffer.
        for (int i = 0; i <= (int)data[1]; i++)
        {
            b[i] = data[i];
        }

        // By calling GoodScan, you are queueing a DataEvent
        // which will delivered to the application when it is suitable.
        GoodScan(b);
    }
}
```

This sample cannot be compiled on its own, but may be inserted into a complete scanner Service Object implementation.

## See Also

#### Tasks

- [Creating a Basic Service Object Code Template](creating-a-basic-service-object-code-template.md)

#### Concepts

- [Base Class DirectIO Method](base-class-directio-method.md)
- [Device Input and Events](device-input-and-events.md)

#### Other Resources

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
