---
title: LineDisplay Sample
description: LineDisplay Sample (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# LineDisplay Sample (POS for .NET v1.14 SDK Documentation)

The <xref:Microsoft.PointOfService.BaseServiceObjects.LineDisplayBase> class is a relatively thin abstraction layer when compared to other Service Object **Base** classes—there is little code needed between the application and the physical device. The <xref:Microsoft.PointOfService.LineDisplay> Service Object simply needs to advertise which features the physical device supports and modify its output according to the display properties the application has set.

A **LineDisplay** Service Object may also monitor the device and report power or other status changes back to the application using a **StatusUpdateEvent**. This can be done by using the **Queue** methods or, for example, by using the power reporting features in **PosCommon**. Monitoring the device this way will generally require starting a new thread to wait for hardware events and queue the appropriate **StatusUpdateEvent**. A **LineDisplay** Service Object may also send **DirectIOEvents** to the application.

## To implement the LineDisplay class and attributes

1. Add **using** directives for the **Microsoft.PointOfService** and **Microsoft.PointOfService.BaseServiceObject** namespaces.

2. Add the global attribute <xref:Microsoft.PointOfService.PosAssemblyAttribute> so that **PosExplorer** recognizes this as a Microsoft Point of Service for .NET (POS for .NET) assembly.

3. Create a new class which is derived from **LineDisplayBase**.

4. Add the class-level attribute <xref:Microsoft.PointOfService.ServiceObjectAttribute> to your new class so that **PosExplorer** recognizes it as a Service Object.

## To implement abstract LineDisplayBase members

1. All **LineDisplay** Service Objects must support at least one screen mode. To provide the application with specifics about the supported screen modes, implement the abstract property <xref:Microsoft.PointOfService.BaseServiceObjects.LineDisplayBase.LineDisplayScreenModes>.

2. At a minimum, all **LineDisplay** Service Objects must implement <xref:Microsoft.PointOfService.BaseServiceObjects.LineDisplayBase.DisplayData(Microsoft.PointOfService.BaseServiceObjects.Cell[])> to display characters on the output device.

## Additional Capabilities

Set capability properties in your Service Object to advertise support for the features of your device. This sample demonstrates how to implement the **LineDisplay** blink feature.

## To implement the blink feature

1. In the constructor, set the <xref:Microsoft.PointOfService.BaseServiceObjects.LineDisplayProperties.CapBlink> property to either **DisplayBlink.All** or **DisplayBlink.Each** to indicate which blinking mode this Service Object supports.

2. Set the **CapBlink** property to **true**indicating that the blink rate may be set by the application by calling <xref:Microsoft.PointOfService.LineDisplay.BlinkRate>.

3. Take these and other settings into account when implementing **DisplayData**.

## Example

```csharp
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

[assembly: PosAssembly("Service Object Contractors, Inc.")]

namespace SOSample.LineDisplay
{
    [ServiceObject(
            DeviceType.LineDisplay,
            "SampleLineDisplay",
            "Sample LineDisplay Service Object",
            1,
            9)]

    public class SampleLineDisplay : LineDisplayBase
    {
        SampleLineDisplay()
        {
            // The CapBlink property is initially set to
            // DisplayBlink.None in LineDisplayBase. This property
            // will be set here to indicate what mode of blinking
            // text our Service Object can support.
            Properties.CapBlink = DisplayBlink.All;

            // Set the CapBlinkRate property to true to indicate
            // that this device has the ability to change the
            // rate at which it blinks by setting the property
            // BlinkRate.
            Properties.CapBlinkRate = true;
        }

        #region Implement Abstract LineDisplayBase Members
        // LineDisplayScreenMode must be implemented to
        // allow the application to find out which screen modes
        // are supported by this device.
        protected override LineDisplayScreenMode[]
                                    LineDisplayScreenModes
        {
            get
            {
                LineDisplayScreenMode[] SupportedModes;

                // Create a LineDisplayScreenMode object; this SO
                // has a screen mode 10 columns wide and 2 rows deep.
                LineDisplayScreenMode mode =
                        new LineDisplayScreenMode(10, 2, 0, 0);

                // Allocate space for our screen mode array and
                // initialize it to hold our supported screen
                // mode(s).
                SupportedModes =
                        new LineDisplayScreenMode[] { mode };

                return SupportedModes;
            }
        }

        // DisplayData is the method called from the application
        // specifying what data should be displayed on the
        // device.
        protected override void DisplayData(Cell[] cells)
        {
            // Your code here:
            // Send the data to your device. Take settings such
            // as blink and blink rate into account here.
            return;
        }
        #endregion Implement Abstract LineDisplayBase Members

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
            // Verify that the device is open, claimed and enabled.
            VerifyState(true, true);

            // Your code here:
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
        #endregion Abstract PosCommon Members
    }
}
```

## See Also

#### Other Resources

- [LineDisplay Implementation](linedisplay-implementation.md)
- [Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
