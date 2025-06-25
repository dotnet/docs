---
title: Creating a Service Object Sample
description: Creating a Service Object Sample (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Creating a Service Object Sample (POS for .NET v1.14 SDK Documentation)

Previous topics explained how to create a basic Service Object template with Plug and Play support. This section adds how to create a limited sample with the following new features:

- Necessary abstract methods are implemented so that the sample will compile successfully.
- The Service Object will be recognized by applications using <xref:Microsoft.PointOfService.PosExplorer>, for example, the **POS for .NET Test Application** included with the SDK.
- Applications may now invoke methods on the Service Object or access properties, although no useful results will be returned.

## Requirements

To compile this sample, your project has to have the correct references and global attributes.

## Example

```csharp
using System;
using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

namespace Samples.ServiceObjects.MSR
{
    [HardwareId(@"HID\Vid_05e0&Pid_038a", @"HID\Vid_05e0&Pid_038a")]

    [ServiceObject(DeviceType.Msr,
        "SampleMsr",
        "Sample Msr Service Object",
        1,
        9)]
    public class SampleMsr : MsrBase
    {
        //  String returned from CheckHealth
        private string MyHealthText;

        public SampleMsr()
        {
            // Initialize device capability properties.
            Properties.CapIso = true;
            Properties.CapTransmitSentinels = true;
            Properties.DeviceDescription = "Sample MSR";

            // Initialize other class variables.
            MyHealthText = "";
        }

        ~SampleMsr()
        {
            Dispose(false);
        }

        // Release any resources managed by this object.
        protected override void Dispose(bool disposing)
        {
            try
            {
                // Your code here.
            }
            finally
            {
                // Must call base class Dispose.
                base.Dispose(disposing);
            }
        }

        #region PosCommon overrides
        // Returns the result of the last call to CheckHealth().
        public override string CheckHealthText
        {
            get
            {
                // MsrBasic.VerifyState(mustBeClaimed,
                // mustBeEnabled). This may throw an exception.
                VerifyState(false, false);

                return MyHealthText;
            }
        }

        public override string CheckHealth(
                    HealthCheckLevel level)
        {
            // Verify that device is open, claimed, and enabled.
            VerifyState(true, true);

            // Your code here:
            // check the health of the device and return a
            // descriptive string.

            // Cache result in the CheckHealthText property.
            MyHealthText = "Ok";
            return MyHealthText;
        }

        public override DirectIOData DirectIO(
                        int command,
                        int data,
                        object obj)
        {
            // Verify that device is open.
            VerifyState(false, false);

            return new DirectIOData(data, obj);
        }
        #endregion // PosCommon overrides

        #region MsrBasic Overrides
        protected override MsrFieldData ParseMsrFieldData(
                        byte[] track1Data,
                        byte[] track2Data,
                        byte[] track3Data,
                        byte[] track4Data,
                        CardType cardType)
        {
            // Your code here:
            // Implement this method to parse track data
            // into fields which will be returned as
            // properties to the application
            // (for example, FirstName,
            // AccountNumber, etc.)
            return new MsrFieldData();
        }

        protected override MsrTrackData ParseMsrTrackData(
                        byte[] track1Data,
                        byte[] track2Data,
                        byte[] track3Data,
                        byte[] track4Data,
                        CardType cardType)
        {

            // Your code here:
            // Implement this method to convert raw track data.
            return new MsrTrackData();
        }
        #endregion
    }
}
```

In order to simplify this sample, the code does not implement any globalization features. For example, the value for **Properties.DeviceDescription** would typically be read from a localized strings resource file.

## See Also

#### Tasks

- [Adding Plug and Play Support](adding-plug-and-play-support.md)
- [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md)

#### Concepts

- [POS for .NET Class Tree](pos-for-net-class-tree.md)

#### Other Resources

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
