---
title: Asynchronous Output Sample
description: Asynchronous Output Sample (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Asynchronous Output Sample (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) supports asynchronous output in compliance with the Unified Point Of Service (UnifiedPOS) specification. In the asynchronous output model, the Service Object must queue output requests so that it can return control to the application as quickly as possible. A second thread must then dispatch output to the device and notify applications when the request has been fulfilled, either with an **OutputCompleteEvent** or an **ErrorEvent** event.

The POS for .NET class library handles most of these functions for the Service Object developer so that there is little, if any, difference between an asynchronous output device and a synchronous output only device.

## To create the project

1. Create a Visual Studio class library project.

2. Add the sample code below to your project.

3. Add references to the **Microsoft.PointOfService** assemblies.

4. Compile and copy the Service Object to one of the directories in your Service Object assembly load path.

## To use the application sample with the Service Object

- This Service Object can be used with the application sample presented in [Event Handler Sample](event-handler-sample.md).

## Example

To output to a **PosPrinter** device, an application will most commonly use the <xref:Microsoft.PointOfService.BaseServiceObjects.PosPrinterBase.PrintNormal(Microsoft.PointOfService.PrinterStation,System.String)> method. Notice that the **PosPrinter** Service Object code below does not provide an implementation for this method. Instead, <xref:Microsoft.PointOfService.BaseServiceObjects.PosPrinterBase.PrintNormalImpl(Microsoft.PointOfService.PrinterStation,Microsoft.PointOfService.BaseServiceObjects.PrinterState,System.String)> is implemented. This method is called by the POS for .NET library for both synchronous and asynchronous output requests.

When an application calls an output method, such as **PrintNormal**, the POS for .NET implementation checks the value of the <xref:Microsoft.PointOfService.PosPrinter.AsyncMode> property. If this value is **false**, then the POS for .NET library sends the request to **PrintNormalImpl** immediately and waits for it to return. If the value is **true**, however, then the POS for .NET implementation of **PrintNormal** adds the request to an internally managed queue. While there are items in the queue, a POS for .NET managed thread will send each request, in first-in-first-out (FIFO) order, to the device by calling **PrintNormalImpl**. When **PrintNormalImpl** returns, the library implementation will raise an <xref:Microsoft.PointOfService.PosPrinter.OutputCompleteEvent> in the application. In short, the same Service Object code can support both synchronous and asynchronous output without ever needing to know which output mode is being used.

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

[assembly: PosAssembly("Service Object Contractors, Inc.")]

namespace SOSamples.AsyncOutput
{
    [ServiceObject(
            DeviceType.PosPrinter,
            "AsyncOutputPrinter",
            "Sample Async Printer",
            1,
            9)]

    public class AsyncOutputSimulator : PosPrinterBase
    {
        public AsyncOutputSimulator()
        {
            DevicePath = "Sample Async Printer";

            // Indicate that the Service Object supports
            // the receipt printer.
            Properties.CapRecPresent = true;
        }

        // Note that this method will be called by the POS for .NET
        // library code, regardless of whether the print request
        // is synchronous or asynchronous. The print request
        // queue is managed completely by POS for .NET so the
        // Service Object should simply write data to the device
        // here.
        protected override PrintResults PrintNormalImpl(
                        PrinterStation station,
                        PrinterState printerState,
                        string data)
        {
            // Your code to print to the actual hardware would go
            // here.

            // For demonstration, however, the code simulates
            // that fulfilling this print request took 4 seconds.
            Thread.Sleep(4000);

            PrintResults results = new PrintResults();
            return results;
        }

        // This method must be implemented by the Service
        // Object, and should validate the data to be printed,
        // including any escape sequences. This method should throw
        // a PosControlException to indicate failure.
        protected override void ValidateDataImpl(
                        PrinterStation station,
                        string data)
        {
            // Insert your validation code here.
            return;
        }

        #region Implement Abstract PosCommon Members
        private string MyHealthText = "";

        // PosCommon.CheckHealthText.
        public override string CheckHealthText
        {
            get
            {
                // VerifyState(mustBeClaimed,
                // mustBeEnabled).
                VerifyState(false, false);
                return MyHealthText;
            }
        }

        //  PosCommon.CheckHealth.
        public override string CheckHealth(
                        HealthCheckLevel level)
        {
            // Verify that device is open, claimed, and enabled.
            VerifyState(true, true);

            // Insert your code here:
            // check the health of the device and return a
            // descriptive string.

            // Cache result in the CheckHealthText property.
            MyHealthText = "Ok";
            return MyHealthText;
        }

        // PosCommon.DirectIOData.
        public override DirectIOData DirectIO(
                                int command,
                                int data,
                                object obj)
        {
            // Verify that the device is open.
            VerifyState(false, false);

            return new DirectIOData(data, obj);
        }
        #endregion Implement Abstract PosCommon Members
    }
}
```

The application code in the [Event Handler Sample](event-handler-sample.md) can be compiled and run with this Service Object.

## See Also

#### Tasks

- [Event Handler Sample](event-handler-sample.md)

#### Concepts

- [Event Management](event-management.md)
- [Device Output Models](device-output-models.md)

#### Other Resources

- [Developing a Custom Service Object](developing-a-custom-service-object.md)
