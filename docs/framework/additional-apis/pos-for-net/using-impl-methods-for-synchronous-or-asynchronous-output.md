---
title: Using Impl Methods for Synchronous or Asynchronous Output
description: Using Impl Methods for Synchronous or Asynchronous Output (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Using Impl Methods for Synchronous or Asynchronous Output (POS for .NET v1.14 SDK Documentation)

Some POS device types support printed or displayed output, for example, the **PosPrinter** or **LineDisplay**. Service Objects written for output-enabled devices should provide support for both asynchronous and synchronous output.

An application that performs an operation asynchronously will set the **AsyncMode** property of the Service Object to **true** before calling the desired output method. The Service Object may throw an exception if it is unable to process the request asynchronously, but this is not ideal since it limits the scope of applications that may use that particular Service Object.

Supporting asynchronous output may, however, require additional and potentially complicated code. This code would manage a queue of incoming requests, maintain a thread to monitor the queue and dispatch requests in the proper order, and raise events back to the application.

The Microsoft Point of Service for .NET (POS for .NET) **Base** classes can manage all of these tasks for the developer. For each output method, the **Base** class has a helper method associated with each output method. These methods, which end with the **Impl** suffix, are written as if they were simply the synchronous implementation of their parent method. The **Base** class transparently manages a queue, dispatches requests to the **Impl** functions at the right time in the right order, and raises the appropriate events back to the application. This same method is called for both synchronous and asynchronous operations.

By deriving from a POS for .NET **Base** class, the Service Object gets asynchronous functionality without implementing additional code.

## Base Class Implementation

POS for .NET provides **Base** classes for a subset of POS device types. For each output method in these classes, there is a corresponding method with an **Impl** suffix. The Service Object derived from a **Base** class should override only the **Impl** method and not the corresponding parent method. For example, in a class derived from the POS for .NET **Base** class <xref:Microsoft.PointOfService.BaseServiceObjects.PosPrinterBase>, the Service Object would provide an implementation for **PrintNormalImpl** and would not override **PrintNormal**.

The POS for .NET **Base** classes implement all output methods and perform the following tasks in order to support the **Impl** method implemented by the Service Object:

- Validate arguments.
- If the **AsyncMode** property is **false**, the corresponding **Impl** method is called immediately.
- If the **AsyncMode** property is set to **true**:
    1. The request is placed in a queue. This queue is owned by POS for .NET and is managed by its own thread.
    2. Requests on the queue are examined by the queue's thread and the corresponding **Impl** method is called. This call could be delayed if the device is already processing an output request or if a request of higher priority on the queue exists.
- When the **Impl** method returns, the POS for .NET **Base** class code handles all results. For a synchronous call, the method may either return a value or throw an exception. For an asynchronous call, the method may raise **OutputCompleteEvent** or **ErrorEvent** events back to the application.
- **Impl** methods may also return an object which contains not only error information, but also statistics values.

### Service Object Impl Methods

Since most processing is handled by the **Base** class code, the Service Object's **Impl** method can be relatively simple.

In many cases, the state of the device at the time of the original call is required by the **Impl** method. In these situations, the **Base** class code saves the current device state along with the output request. The device state is later sent as an argument to the **Impl** method. For example, the definition for **PrintNormalImpl** is:

```csharp
protected override PrintResults PrintNormalImpl(
    PrinterStation station,
    PrinterState printerState,
    string data);
```

The argument *printerState* above is specific to the **Impl** method and does not exist in the <xref:Microsoft.PointOfService.PosPrinter.PrintNormal(Microsoft.PointOfService.PrinterStation,System.String)> definition.

The return value of **Impl** functions also differs from their calling methods. For example, note that the **PrintNormalImpl** method returns a class of type <xref:Microsoft.PointOfService.BaseServiceObjects.PrintResults>. In addition to **ErrorCode**, **ErrorCodeExtended**, **ErrorLevel**, and **ErrorString**, there are a number of additional properties which will be used by the calling method to update statistic counts.

### Example

The following example demonstrates how these methods are implemented in Service Object code.

```csharp
protected override PrintResults PrintNormalImpl(
        PrinterStation station,
        PrinterState printerState,
        string data)
{
    // First, create a PrintResults object to hold return values.
    PrintResults pr = new PrintResults();

    // Now print, depending on the station.
    if (station == PrinterStation.Receipt)
    {
        // Your code goes here.

        // Update statistics to be returned to the caller.
        pr.ReceiptLinePrintedCount = 1;
        pr.ReceiptCharacterPrintedCount = data.Length;
    }
    else if (station == PrinterStation.Slip)
    {
        // Your code goes here.

        // Update statistics to be returned to the caller.
        pr.SlipLinePrintedCount = 1;
        pr.SlipCharacterPrintedCount = data.Length;
    }

    return pr;
}
```

## See Also

#### Tasks

- [Asynchronous Output Sample](asynchronous-output-sample.md)

#### Reference

- <xref:Microsoft.PointOfService.BaseServiceObjects.PosPrinterBase>

#### Concepts

- [Device Output Models](device-output-models.md)

#### Other Resources

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
