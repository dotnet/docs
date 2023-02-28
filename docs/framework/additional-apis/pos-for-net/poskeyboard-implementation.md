---
title: PosKeyboard Implementation
description: PosKeyboard Implementation (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# PosKeyboard Implementation (POS for .NET v1.14 SDK Documentation)

A **PosKeyboard** Service Object reads keys from a POS keyboard. A POS keyboard may be an auxiliary keyboard, or it may be a virtual keyboard consisting of some or all of the keys on the system keyboard. In Microsoft Point of Service for .NET (POS for .NET), the POS keyboard **Base** class is <xref:Microsoft.PointOfService.BaseServiceObjects.PosKeyboardBase>.

A **PosKeyboard** Service Object follows the general input device model:

- When input is received from the POS keyboard, a **DataEvent** is queued.
- If the **AutoDisable** property is **true**, then the device automatically disables itself when a **DataEvent** event is queued. This is done automatically by the **PosKeyboardBase** class.
- A queued **DataEvent** event will be delivered to the application when the **DataEventEnabled** property is **true** and other event delivery requirements are met. The **PosKeyboardBase** class will manage event delivery automatically.
- An **ErrorEvent** event is queued if an error while gathering or processing input, and is delivered to the application when **DataEventEnabled** is **true** and other event delivery requirements are met.
- The **DataCount** property, which is maintained by the **PosKeyboardBase** class, may be read to obtain the number of queued events.
- All queued input may be deleted by calling <xref:Microsoft.PointOfService.CashChanger.ClearInput>.

The POS keyboard is an exclusive-use device:

- The application must claim the device before enabling it.
- The application must claim and enable the device before the device begins reading input.

This section contains a sample **PosKeyboard** Service Object that generates simulated keystrokes which are sent to the application by using **DataEvents**. This sample depends on the thread-helper object presented in [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md). To compile this sample, you need to include the code from that topic.

## To write a Service Object

1. Add **using** directives for **Microsoft.PointofService**, **Microsoft.PointOfService.BaseServiceObjects**, and **System.Threading**.

2. Add the global attribute **PosAssembly**.

3. Choose an appropriate namespace name for your project.

4. Create a Service Object class derived from **PosKeyboardBase**.

5. Add the **ServiceObject** attribute to your Service Object class, using the **DeviceType.PosKeyboard** value as your device type.

## To add features to the sample keyboard Service Object

1. Create a thread helper class, **KeyboardThreadingObject**, derived from **ServiceObjectThreadHelper** from the **Service Object Read Threads** section.

2. Implement the **ServiceObjectThreadProcedure** method in the **KeyboardThreadingObject** class. This is the procedure that will be run on a separate thread. In the sample code below, this method simulates keyboard input.

3. This sample class implements a method called **SendKey** and another called **ChangePowerState**. These methods are wrappers around protected members. Because they are protected, they cannot be invoked directly from the threading object.

4. Override the **PosCommon.Open** method to specify capabilities supported by this Service Object and create a new thread-helper object.

5. Override the **PosCommon.DeviceEnable** specifically to **Open** and **Close** the thread-helper.

6. Implement the abstract virtual methods from **PosCommon**, providing minimum functionality.

## Running the Application

This sample Service Object can be run in conjunction with the test application provided with the POS for .NET Software Development Kit (SDK).

## To test the Service Object

1. Start the test application and select **SamplePosKeyboard** from the **Keyboard** drop-down list.

2. **Open** and **Claim** the device, and then select the device with the **DeviceEnabled** check box to enable it.

3. Checking the **DataEventEnabled** box will allow the Service Object to send a single simulated key to the application. The **DataEvent** is queued automatically by the **PosKeyboardBase** class when **KeyDown** is called.

4. Selecting the **Automatically enable data events** box allows the Service Object to continue delivering characters, two seconds apart.

5. The Service Object will send simulated key strokes for characters 'a' through 'z'. After that, a **StatusUpdateEvent** event will be sent indicating the device is now offline. This event is sent automatically by the **PosKeyboardBase** class when **Properties.PowerState** is changed.

## Example

This sample demonstrates how to develop a simple **PosKeyboard** Service Object. It supports a separate reader thread to send **DataEvents** asynchronously to the application. Once compiled, you can execute the Service Object in conjunction with the test application included with the POS for .NET SDK.

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;

[assembly: PosAssembly("Service Object Contractors, Inc.")]

namespace SOSamples.Keyboard
{
    [ServiceObject(
            DeviceType.PosKeyboard,
            "SamplePosKeyboard",
            "Sample PosKeyboard Service Object",
            1,
            9)]

    public class SampleKeyboard : PosKeyboardBase
    {
        KeyboardThreadingObject ReadThread = null;

        public SampleKeyboard()
        {
            // DevicePath must be set before Open() is called.
            // In the case of Play and Plug hardware, the
            // POS for .NET Base class will set this value.
            DevicePath = "Sample Keyboard";

            // NOTE: You can test the power notification events
            // sent from this Service Object by selecting the
            // "Power Notify" check box.

            // Let the application know advanced power
            // reporting is supported.
            Properties.CapPowerReporting = PowerReporting.Advanced;
            Properties.CapKeyUp = false;
        }

        ~SampleKeyboard()
        {
            // Code added from previous sections to terminate
            // the read thread started by the thread-helper
            // object.
            if (ReadThread != null)
            {
                ReadThread.CloseThread();
            }

            Dispose(false);
        }

        // Expose the protected KeyDown() method so that it can be
        // called from our threading helper.
        public void SendKey(int key)
        {
            KeyDown(key);
        }

        // Expose the protected PowerState property so it can be
        // changed from the threading helper.
        public void ChangePowerState(PowerState state)
        {
            Properties.PowerState = state;
        }

        #region Override Virtual PosCommon Members
        public override void Open()
        {
            base.Open();

            // Create the reader-thread object.
            ReadThread = new KeyboardThreadingObject(this);
        }

        public override bool DeviceEnabled
        {
            get
            {
                return base.DeviceEnabled;
            }
            set
            {
                if (value != base.DeviceEnabled)
                {
                    base.DeviceEnabled = value;

                    if (value == false)
                    {
                        // Stop the reader thread when the device
                        // is disabled.
                        ReadThread.CloseThread();
                    }
                    else
                    {
                        try
                        {
                            // By enabling the device, start the
                            // reader thread.
                            ReadThread.OpenThread();
                        }
                        catch (Exception e)
                        {
                            base.DeviceEnabled = false;

                            if (e is PosControlException)
                                throw;

                            throw new PosControlException(
                                    "Unable to Enable Device",
                                    ErrorCode.Failure, e);
                        }
                    }
                }
            }
        }
        #endregion Override Virtual PosCommon Members

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
            // Verify that device is open, claimed and enabled.
            VerifyState(true, true);

            // Your code here:
            // Check the health of the device and return a
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

    #region Thread Helper Class
    public class KeyboardThreadingObject :
        ServiceObjectThreadHelper, IDisposable
    {
        // This is a helper class which will depend on
        // being able to call back into the actual Service
        // Object to pass along data. However, you cannot
        // keep a strong reference to the Service Object,
        // since that may prevent clean disposal, leaving
        // hardware resources unavailable to other processes.
        // Therefore, you create a weak reference. From this
        // reference, you can get a temporary strong reference,
        // which you can act on and then release.
        WeakReference ServiceObjectReference;

        // The name of the Service Object.
        string ObjectName;

        public KeyboardThreadingObject(SampleKeyboard so)
        {
            ObjectName = GetType().Name;
            ServiceObjectReference = new WeakReference(so);
        }

        // This method will be called during initialization.
        public override void ServiceObjectThreadOpen()
        {
            Logger.Info(ObjectName, "Keyboard Thread Open");
        }

        // This method will be called curing shutdown.
        public override void ServiceObjectThreadClose()
        {
            Logger.Info(ObjectName, "Keyboard Thread Open");
        }

        // Your code used to monitor your device for input should
        // go here. The implementation below generates simulated
        // input as an example.
        public override void ServiceObjectThreadProcedure(
                            AutoResetEvent ThreadStopEvent)
        {
            Logger.Info(ObjectName,
                            "Keyboard Thread Procedure Entered");
            int KeyValue = (int)'a';

            while (true)
            {
                // When this method is called by the
                // ServiceObjectThreadHelper, it is obligated to
                // exit when the event ThreadStopEvent has been
                // set.
                if (ThreadStopEvent.WaitOne(2000, false))
                {
                    break;
                }

                if (KeyValue <= (int) 'z')
                {
                    Logger.Info(ObjectName, "Reader Thread cycling");

                    // Try to get a strong reference to the Service
                    // Object using the weak reference saved when
                    // this helper object was created.
                    SampleKeyboard Keyboard =
                        ServiceObjectReference.Target
                        as SampleKeyboard;

                    // If this fails, that means the Service Object
                    // has already been disposed of - exit the thread.
                    if (Keyboard == null)
                    {
                        break;
                    }

                    if (Keyboard.DataEventEnabled == true)
                    {
                        // Call a method implemented in our Keyboard
                        // class to queue the key stroke.
                        Keyboard.SendKey(KeyValue);

                        // Simulate input by moving through the
                        // alphabet, sending one character at a time.
                        KeyValue++;
                        if (KeyValue >= (int)'z')
                        {
                            // Once you run out of input, simulate a
                            // power state change. Setting the SO's
                            // PowerState property to
                            // PowerState.Offline will cause a
                            // StatusUpdateEvent to be sent to the
                            // application.
                            Keyboard.ChangePowerState(
                                            PowerState.Offline);

                            // Release the strong reference.
                            Keyboard = null;

                            // There is no more work, so exit the
                            // loop.
                            break;
                        }
                    }

                    // Release the strong reference.
                    Keyboard = null;
                }
            }
        }
    }
    #endregion Thread Helper Class
}
```

## Compiling the Code

- This sample requires that the code from the [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md) section be included.
- The assemblies **Microsoft.PointOfService** and **Microsoft.PointOfService.BaseServiceObjects** must be referenced.

## See Also

#### Tasks

- [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md)

#### Other Resources

- [Developing Service Objects Using Base Classes](developing-service-objects-using-base-classes.md)
- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
