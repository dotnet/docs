---
title: Introducing Service Object Reader Threads
description: Introducing Service Object Reader Threads (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Introducing Service Object Reader Threads (POS for .NET v1.14 SDK Documentation)

Most Service Objects need to be able to respond to hardware events asynchronously by starting a separate hardware reader thread. Service Objects are the link between the Point of Service application and the hardware. Therefore, Service Objects must read data from the associated hardware while still being available to the application.

This section demonstrates one way to implement the code necessary for multithreaded Service Objects.

## Requirements

To compile this code, the application must include a reference to the **System.Threading** namespace.

The sample below implements a threading helper class which may be used by Service Object implementations, but does not compile or run on its own.

## Demonstrates

This sample demonstrates how Service Objects may use threading to support monitoring hardware events asynchronously. The sample code implements a thread helper class which can be used to add basic threading support to a Service Object.

To use the thread helper class provided in this section, you will need to create a class derived from **ServiceObjectThreadHelper**, which is included in the code below, and implement the following methods:

- **ServiceObjectThreadOpen**
    This method is called from the **OpenThread** method of the thread helper class after initialization has been completed. Implement any hardware-specific initialization code here. This method is virtual. The default implementation simply returns.

- **ServiceObjectThreadClose**
    This method is called when the thread helper object is terminating its thread or when calling the **Dispose** method and should be used to release any unmanaged handles or other resources related to the device. This method is virtual. The default implementation simply returns.

- **ServiceObjectProcedure**
    This method will be invoked once all initialization has taken place and the thread has been started successfully. This method is abstract and must be implemented in the class derived from the thread helper class.
    The **ServiceObjectProcedure** method takes a single argument, a **ManualEvent** handle. Your thread procedure must exit when this handle is set. This is done by calling **ManualEvent.WaitOne** within a **while** loop. For example:

    ```

        while (true)
        {
            // Wait for a hardware event or the thread stop event.

            // Test to see if the thread terminated event is set and
            // exit the thread if so.
            if (ThreadStopEvent.WaitOne(0, false))
            {
               break;
            }

            // The thread is not terminating, so it must be a
            // a hardware event.
        }
    ```

## Example

```csharp
using System;
using System.Threading;
using Microsoft.PointOfService;

namespace Samples.ServiceObjects.Advanced
{
    // The following code implements a thread helper class.
    // This class may be used by other Point Of Service
    // samples which may require a separate thread for monitoring
    // hardware.
    public abstract class ServiceObjectThreadHelper : IDisposable
    {
        // The thread object which will wait for data from the POS
        // device.
        private Thread ReadThread;

        // These events signal that the thread is starting or stopping.
        private AutoResetEvent ThreadTerminating;
        private AutoResetEvent ThreadStarted;

        // Keeps track of whether or not a thread should
        // be running.
        bool ThreadWasStarted;

        public ServiceObjectThreadHelper()
        {
            // Create events to signal the reader thread.
            ThreadTerminating = new AutoResetEvent(false);
            ThreadStarted = new AutoResetEvent(false);

            ThreadWasStarted = false;

            // You need to handle the ApplicationExit event so
            // that you can properly clean up the thread.
            System.Windows.Forms.Application.ApplicationExit +=
                        new EventHandler(Application_ApplicationExit);
        }

        ~ServiceObjectThreadHelper()
        {
            Dispose(true);
        }

        public virtual void ServiceObjectThreadOpen()
        {
            return;
        }

        public virtual void ServiceObjectThreadClose()
        {
            return;
        }

        // This is called when the thread starts successfully and
        // will be run on the new thread.
        public abstract void ServiceObjectThreadProcedure(
                AutoResetEvent ThreadStopEvent);

        private bool IsDisposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                try
                {
                    if (disposing == true)
                    {
                        CloseThread();
                    }
                }
                finally
                {
                    IsDisposed = true;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);

            // This object has been disposed of, so no need for
            // the GC to call the finalization code again.
            GC.SuppressFinalize(this);
        }

        public void OpenThread()
        {
            try
            {
                // Check to see if this object is still valid.
                if (IsDisposed)
                {
                    // Throw system exception to indicate that
                        // the object has already been disposed.
                    throw new ObjectDisposedException(
                            "ServiceObjectSampleThread");
                }

                // In case the application has called OpenThread
                // before calling CloseThread, stop any previously
                // started thread.
                SignalThreadClose();

                ServiceObjectThreadOpen();

                // Reset event used to signal the thread to quit.
                ThreadTerminating.Reset();

                // Reset the event that used by the thread to signal
                // that it has started.
                ThreadStarted.Reset();

                // Create the thread object and give it a name. The
                // method used here, ThreadMethod, is a wrapper around
                // the actual thread procedure, which will be run in
                // the threading object provided by the Service
                // Object.
                ReadThread = new Thread(
                        new ThreadStart(ThreadMethod));

                // Set the thread background mode.
                ReadThread.IsBackground = false;

                // Finally, attempt to start the thread.
                ReadThread.Start();

                // Wait for the thread to start, or until the time-out
                // is reached.
                if (!ThreadStarted.WaitOne(3000, false))
                {
                    // If the time-out was reached before the event
                    // was set, then throw an exception.
                    throw new PosControlException(
                            "Unable to open the device for reading",
                            ErrorCode.Failure);
                }

                // The thread has started successfully.
                ThreadWasStarted = true;
            }
            catch (Exception e)
            {
                // If an error occurred, be sure the new thread is
                // stopped.
                CloseThread();

                // Re-throw to let the application handle the
                // failure.
                throw;
            }
        }

        private void SignalThreadClose()
        {
            if(ThreadTerminating != null && ThreadWasStarted)
            {
                // Tell the thread to terminate.
                ThreadTerminating.Set();

                // Give the thread a few seconds to end.
                ThreadStarted.WaitOne(10000, false);

                // Mark the thread as being terminated.
                ThreadWasStarted = false;
            }
        }

        public void CloseThread()
        {
            // Signal the thread that it should stop.
            SignalThreadClose();

            // Call back into the SO for any cleanup.
            ServiceObjectThreadClose();
        }

        private void Application_ApplicationExit(
                            object sender,
                            EventArgs e)
        {
            SignalThreadClose();
        }

        // This is the method run on the new thread. First it signals
        // the caller indicating that the thread has started
        // correctly. Next, it calls the service object's thread
        // method which will loop waiting for data or a signal
        // to close.
        private void ThreadMethod()
        {
            try
            {
                // Set the event to indicate that the thread has
                // started successfully.
                ThreadStarted.Set();

                // Call into the thread procedure defined by the
                // Service Object.
                ServiceObjectThreadProcedure(ThreadTerminating);

                // Signal that the thread procedure is exiting.
                ThreadStarted.Set();
            }
            catch (Exception e)
            {
                Logger.Info("ServiceObjectThreadHelper",
                        "ThreadMethod Exception = " + e.ToString());
                throw;
            }
        }
    }
}
```

## See Also

#### Tasks

- [Creating a Working, Multithreaded Service Object](creating-a-working-multithreaded-service-object.md)
- [Adding Plug and Play Support](adding-plug-and-play-support.md)

#### Other Resources

- [Service Object Samples: Getting Started](service-object-samples-getting-started.md)
- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
