---
title: Creating a Working, Multithreaded Service Object
description: Creating a Working, Multithreaded Service Object (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Creating a Working, Multithreaded Service Object (POS for .NET v1.14 SDK Documentation)

The previous sections provided samples and guides to start your project including:

- Creating a simple template.
- Implementing a Service Object class that can be compiled and seen by the Point Of Service sample application via <xref:Microsoft.PointOfService.PosExplorer>.
- Implementing a thread helper class.

This sample combines all of these steps to create a working, multithreaded MSR Service Object class. This sample does not actually read from any hardware. It simply pushes test data through the system. It illustrates, however, how to add code that is specific to your Service Object.

## To customize this code for your Service Object

1. Modify the **PosAssembly** attribute in **AssemblyInfo.cs** so that it contains your organization's name.

2. Be sure that the name of the namespace is appropriate for your organization and Service Object.

3. Modify the **ServiceObject** attribute to contain the type, name, description, and version number of the Service Object that you are creating.

4. Add a **HardwareId** attribute to associate this Service Object with a Plug and Play device, or a range of devices.

5. Include the **ThreadHelper** class presented in [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md). You can do this by either pasting the code into your source file, or compiling it as a separate source file in your project. Be sure that the **ThreadHelper** class is in an accessible namespace.

6. Implement the members necessary depending on the **Base** class used by the Service Object and the functionality that you want to support. This sample is a functioning MSR Service Object with very little functionality.

## Requirements

To compile this sample, your project has to have the correct references and global attributes. If you have not already created a working POS for .NET Service Object, review the [Service Object Samples: Getting Started](service-object-samples-getting-started.md) sections.

In addition, you will also need to include the code from the previous section, [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md), into your project.

## Demonstrates

Most Service Objects need to use a second thread to monitor hardware and notify the application of various incoming data events. This sample shows one way to create a multithreaded Service Object. It relies on the **ServiceObjectThreadHelper** class discussed in [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md) to do this.

To use the helper class, an application needs to define a new class that implements the **ServiceObjectThreadHelper** interface. This interface includes three methods:

- **ServiceObjectThreadOpen**
    This method is called during thread initialization and should be used to initialize any hardware-specific resources.
- **ServiceObjectThreadClose**
    This method is called when the thread is terminated and should be used to release any hardware-specific resources.
- **ServiceObjectThreadProcedure**
    This method will be called once the thread has been successfully started and should loop waiting on hardware events, and should not exit until the proper **ManualEvent** is triggered.

This code builds on the sample presented in the topic [Creating a Service Object Sample](creating-a-service-object-sample.md) and adds the following features:

- Creates a class derived from **ServiceObjectThreadHelper**.
- Creates an instance of an **MsrThreadingObject** class. The constructor for this class takes a single argument, a reference to the service object.
- Calls methods on the **MsrThreadingObject** object from the Service Object to start and stop the thread helper as appropriate.

## Example

```csharp
using System;
using System.Threading;
using Microsoft.PointOfService;
using Microsoft.PointOfService.BaseServiceObjects;
using System.Text;

namespace Samples.ServiceObjects.Advanced.MSR
{
    public class MsrThreadingObject :
            ServiceObjectThreadHelper, IDisposable
    {
        // This is a helper class which will depend on
        // being able to call back into the actual Service
        // Object to pass along data. However, you cannot
        // keep a strong reference to the Service Object,
        // since that will prevent proper disposal, which
        // may create a state in which all hardware resources
        // are not properly released by the SO. Therefore,
        // create a weak reference. From this reference,
        // you can get a temporary strong reference, which
        // you act on and then release.
        WeakReference ServiceObjectReference;

        // The name of the Service Object.
        string ObjectName;

        public MsrThreadingObject(AdvancedSampleMsr so)
        {
            ObjectName = GetType().Name;
            ServiceObjectReference = new WeakReference(so);
        }

        ~MsrThreadingObject()
        {
            Dispose(true);
        }

        private bool IsDisposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                base.Dispose(disposing);
            }
        }

        public void Dispose()
        {
            Dispose(false);
        }

        #region Methods of ServiceObjectThreadHelper

        // This will be called during initialization.
        public override void ServiceObjectThreadOpen()
        {
            Logger.Info(ObjectName, "Msr Thread Open");
        }

        // This method will be called during shutdown.
        public override void ServiceObjectThreadClose()
        {
            Logger.Info(ObjectName, "Msr Thread Open");
        }

        public override void ServiceObjectThreadProcedure(
                            AutoResetEvent ThreadStopEvent)
        {
            // Convert a C# string into a sample byte array.
            UTF8Encoding encoder = new UTF8Encoding();

            // Convert sample data to a byte array.
            byte[] MsrData = encoder.GetBytes(
                        "This is MSR test data");

            Logger.Info(ObjectName, "Msr Thread Procedure Entered");

            while (true)
            {
                // When this method is called by the
                // ServiceObjectThreadHelper, it is obligated to
                // exit when the event ThreadStopEvent has been
                // set.

                // Additionally, this method will also wait for
                // hardware events or for a time-out. That should
                // be done here.

                // This example waits for the event to be set
                // or times out after several seconds.

                if (ThreadStopEvent.WaitOne(2000, false))
                {
                    break;
                }

                Logger.Info(ObjectName, "Reader Thread cycling");

                // Try to get a strong reference to the Service
                // Object using the weak reference saved when
                // this helper object was created.
                AdvancedSampleMsr msr =
                    ServiceObjectReference.Target
                    as AdvancedSampleMsr;

                // If this fails, that means the Service
                // Object has already been disposed of. Exit the
                // thread.
                if (msr == null)
                {
                    break;
                }

                // Using the strong reference, you can now make
                // calls back into the Service Object.
                msr.OnCardSwipe(MsrData);
                msr = null;
            }
            #endregion Methods of ServiceObjectThreadHelper
        }

        // Implementation of the Service Object class. This class
        // implements all the methods needed for an MSR Service
        // Object.
        //
        // A Service Object which supports a Plug and Play device
        // should also have a HardwareId attribute here.

        [HardwareId(
                @"HID\Vid_05e0&Pid_038a",
                @"HID\Vid_05e0&Pid_038a")]

        [ServiceObject(
                DeviceType.Msr,
                "AdvancedSampleMsr",
                "Advanced Sample Msr Service Object",
                1,
                9)]
        public class AdvancedSampleMsr : MsrBase
        {
            // String returned for various health checks.
            private string MyHealthText;
            private const string PollingStatistic =
                            "Polling Interval";

            // Create a class with interface methods called from the
            // threading object.
            MsrThreadingObject ReadThread;
            public AdvancedSampleMsr()
            {
                // DevicePath must be set before Open() is called.
                // In the case of Plug and Play hardware, the POS
                // for .NET Base class will set this value.
                DevicePath = "Sample Msr";

                Properties.CapIso = true;
                Properties.CapTransmitSentinels = true;

                Properties.DeviceDescription =
                            "Advanced Sample Msr";

                // Initialize the string to be returned from
                // CheckHealthText().
                MyHealthText = "";
            }

            ~AdvancedSampleMsr()
            {
                // Code added from previous sections to terminate
                // the read thread started by the thread-helper
                // object.
                ReadThread.CloseThread();

                Dispose(false);
            }

            protected override void Dispose(bool disposing)
            {
                try
                {
                    if (disposing)
                    {
                        if (ReadThread != null)
                        {
                            ReadThread.Dispose();
                            ReadThread = null;
                        }
                    }
                }
                finally
                {
                    // Must call base class Dispose.
                    base.Dispose(disposing);
                }
            }

            #region Internal Members
            // This is a private method called from the task
            // interface when a data event occurs in the reader
            // thread.
            internal void OnCardSwipe(byte[] CardData)
            {
                // Simple sample data.
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] track1Data = utf8.GetBytes(
                                "this is test track 1");
                byte[] track2Data = utf8.GetBytes(
                                "this is test track 2");

                // Call GoodRead(), UnreadableCard, or FailedRead
                // from here.
                GoodRead(
                        track1Data,
                        track2Data,
                        null,
                        null,
                        Microsoft.PointOfService.BaseServiceObjects.CardType.Iso);
            }
            #endregion Internal Members

            #region PosCommon overrides
            //  PosCommon.Open.
            public override void Open()
            {
                // Call base class Open.
                base.Open();

                // Initialize statistic values.

                // Set values for common statistics.
                SetStatisticValue(StatisticManufacturerName,
                                "Microsoft Corporation");
                SetStatisticValue(
                            StatisticManufactureDate, "2004-10-23");
                SetStatisticValue(
                            StatisticModelName, "Msr Simulator");
                SetStatisticValue(
                            StatisticMechanicalRevision, "1.0");
                SetStatisticValue(
                            StatisticInterface, "USB");

                // Create a new manufacturer statistic.
                CreateStatistic(
                            PollingStatistic,
                            false,
                            "milliseconds");

                // Set handlers for statistics stored in hardware.
                // Create a class with interface methods called
                // from the threading object.
                ReadThread = new MsrThreadingObject(this);
            }

            // PosCommon.CheckHealthText.
            public override string CheckHealthText
            {
                get
                {
                    // MsrBasic.VerifyState(mustBeClaimed,
                    // mustBeEnabled).
                    VerifyState(false, false);
                    return MyHealthText;
                }
            }

            //  PosCommon.CheckHealth.
            public override string CheckHealth(
                            HealthCheckLevel
                            level)
            {
                // Verify that device is open, claimed, and enabled.
                VerifyState(true, true);

                // Your code here checks the health of the device and
                // returns a descriptive string.

                // Cache result in the CheckHealthText property.
                MyHealthText = "Ok";
                return MyHealthText;
            }

            //  PosCommon.DirectIO.
            public override DirectIOData DirectIO(
                                int command,
                                int data,
                                object obj)
            {
                return new DirectIOData(data, obj);
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
                            // Stop the reader thread when the
                            // device is disabled.
                            ReadThread.CloseThread();
                        }
                        else
                        {
                            try
                            {
                                // Enabling the device, start the
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
            #endregion PosCommon overrides.

            #region MsrBasic Overrides

            // MsrBasic.MsrFieldData
            // Once the track data is retrieved, this method is
            // called when the application accesses various data
            // properties in the MsrBasic class. For example,
            // FirstName and AccountNumber.
            protected override MsrFieldData ParseMsrFieldData(
                                    byte[] track1Data,
                                    byte[] track2Data,
                                    byte[] track3Data,
                                    byte[] track4Data,
                                    CardType cardType)
            {
                // MsrFieldData contains the data elements that
                // MsrBasic will return as properties to the
                // application, as they are requested.
                MsrFieldData data = new MsrFieldData();

                // Parse the raw track data and store in fields to
                // be used by the app.
                data.FirstName = "FirstName";
                data.Surname = "LastName";
                data.Title = "Mr.";
                data.AccountNumber = "123412341234";

                return data;
            }

            // MsrBasic.MsrTrackData.
            protected override MsrTrackData ParseMsrTrackData(
                                    byte[] track1Data,
                                    byte[] track2Data,
                                    byte[] track3Data,
                                    byte[] track4Data,
                                    CardType cardType)
            {
                MsrTrackData data = new MsrTrackData();

                // Modify the track data as appropriate for your SO.
                // Remove the sentinel characters from the track data,
                // for example.
                data.Track1Data = (byte[])track1Data.Clone();
                data.Track2Data = (byte[])track2Data.Clone();

                return data;
            }
            #endregion MsrBasic overrides
        }
    }
}
```

## See Also

#### Tasks

- [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md)
- [Adding Plug and Play Support](adding-plug-and-play-support.md)

#### Other Resources

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
