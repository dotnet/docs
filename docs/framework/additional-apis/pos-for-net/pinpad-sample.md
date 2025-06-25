---
title: PinPad Sample
description: PinPad Sample (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# PinPad Sample (POS for .NET v1.14 SDK Documentation)

This sample demonstrates which methods must be implemented in a **PinPad** Service Object.

## To implement a PinPad Service Object framework

1. Add **using** directives for **Microsoft.PointofService**, **Microsoft.PointOfService.BaseServiceObjects**.

2. Add the global attribute **PosAssembly**.

3. Choose an appropriate namespace name for your project.

4. Create a Service Object class derived from <xref:Microsoft.PointOfService.BaseServiceObjects.PinPadBase>.

5. Add the **ServiceObject** attribute to your Service Object class, using the **DeviceType.PinPad** value as your device type.

## Example

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Microsoft.PointOfService.BaseServiceObjects;
using Microsoft.PointOfService;

[assembly: PosAssembly("Service Object Contractors, Inc")]

namespace SOSamples.PinPad
{
    [ServiceObject(
                DeviceType.PinPad,
                "SamplePinPad",
                "Sample PinPad Service Object",
                1,
                9)]
    public class SamplePinPad : PinPadBase
    {
        PinPadSystem pinPadSystemSupported = PinPadSystem.Dukpt;

        public SamplePinPad()
        {
        }

        #region Implement Abstract PinPadBase Members

        // These abstract protected methods are called from their
        // public, counterpart methods after error and state
        // validation checks are performed.

        protected override void BeginEftTransactionImpl(
                        PinPadSystem pinpadSystem,
                        int transactionHost)
        {
            // If pinpadSystem is not supported by this device,
            // throw a PosControlException.
            if (pinpadSystem != pinPadSystemSupported)
            {
                throw new PosControlException(
                            "PinPadSystem not supported",
                            ErrorCode.Illegal);
            }

            // Your code here. Perform any device-specific
            // initialization, such as computing session keys.
        }

        protected override string ComputeMacImpl(
                        string inMsg)
        {
            // Your code here. Depending on the selected PIN Pad
            // Management system, the PinPad Service Object may
            // insert additional fields into the message (inMsg).
            return inMsg;
        }

        protected override void EnablePinEntryImpl()
        {
            // PinPadBase sets PINEntryEnabled if this method
            // succeeds. After that, the Service Object may
            // send a DataEvent to the application.
        }

        protected override void EndEftTransactionImpl(
                        EftTransactionCompletion completionCode)
        {
            // Your code here. Perform any device or Service
            // Object cleanup such as computing the next
            // transaction keys.
        }

        protected override void UpdateKeyImpl(
                        int keyNumber,
                        string key)
        {
            // Your code here. Update the specified key
            // on your device.
        }

        protected override void VerifyMacImpl(
                        string message)
        {
            // Your code here. Verify the MAC value in a message
            // received from the EFT Transaction host.
        }
        #endregion Implement Abstract PinPadBase Members

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
            // Verify that the device is open, claimed, and enabled.
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
        #endregion  Implement Abstract PosCommon Members
    }
}
```

## See Also

#### Other Resources

- [PinPad Implementation](pinpad-implementation.md)
