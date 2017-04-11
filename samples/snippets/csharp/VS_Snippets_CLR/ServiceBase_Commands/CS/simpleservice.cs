// The following example illustrates deriving a service implementation from
// the System.ServiceProcess.ServiceBase class.  This simple service starts
// a worker thread, and handles various service commands.
// The main service thread and the worker thread write their trace output
// to the eventlog.

// <Snippet1>
// Turn on logging to the event log.
#define LOGEVENTS

using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace SimpleService
{
    // Define custom commands for the SimpleService.
    public enum SimpleServiceCustomCommands { StopWorker = 128, RestartWorker, CheckWorker };
    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_STATUS
    {
        public int serviceType;
        public int currentState;
        public int controlsAccepted;
        public int win32ExitCode;
        public int serviceSpecificExitCode;
        public int checkPoint;
        public int waitHint;
    }

    public enum State
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    // Define a simple service implementation.
    public class SimpleService : System.ServiceProcess.ServiceBase
    {
        private static int userCount = 0;
        private static ManualResetEvent pause = new ManualResetEvent(false);

        [DllImport("ADVAPI32.DLL", EntryPoint = "SetServiceStatus")]
        public static extern bool SetServiceStatus(
                        IntPtr hServiceStatus,
                        ref SERVICE_STATUS lpServiceStatus
                        );
        private SERVICE_STATUS myServiceStatus;

        private Thread workerThread = null;

        // <Snippet2>
        public SimpleService()
        {
            CanPauseAndContinue = true;
            CanHandleSessionChangeEvent = true;
            CanShutdown = true;
            CanStop = true;
            ServiceName = "Simple Service";
            EventLog.WriteEntry("SimpleService", DateTime.Now.ToLongTimeString());
        }
        // </Snippet2>

        static void Main()
        {
#if LOGEVENTS
            EventLog.WriteEntry("SimpleService.Main", DateTime.Now.ToLongTimeString() +
                " - Service main method starting...");
#endif

            // Load the service into memory.
            System.ServiceProcess.ServiceBase.Run(new SimpleService());

#if LOGEVENTS
            EventLog.WriteEntry("SimpleService.Main", DateTime.Now.ToLongTimeString() +
                " - Service main method exiting...");
#endif

        }


        // <Snippet3>
        // Start the service.
        protected override void OnStart(string[] args)
        {
            IntPtr handle = this.ServiceHandle;
            myServiceStatus.currentState = (int)State.SERVICE_START_PENDING;
            SetServiceStatus(handle, ref myServiceStatus);

            // Start a separate thread that does the actual work.

            if ((workerThread == null) ||
                ((workerThread.ThreadState &
                 (System.Threading.ThreadState.Unstarted | System.Threading.ThreadState.Stopped)) != 0))
            {
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.OnStart", DateTime.Now.ToLongTimeString() +
                    " - Starting the service worker thread.");
#endif

                workerThread = new Thread(new ThreadStart(ServiceWorkerMethod));
                workerThread.Start();
            }
#if LOGEVENTS
            if (workerThread != null)
            {
                EventLog.WriteEntry("SimpleService.OnStart", DateTime.Now.ToLongTimeString() +
                    " - Worker thread state = " +
                    workerThread.ThreadState.ToString());
            }
#endif
            myServiceStatus.currentState = (int)State.SERVICE_RUNNING;
            SetServiceStatus(handle, ref myServiceStatus);
            EventLog.WriteEntry("SimpleService", "Starting SimpleService");

            // Get arguments from the ImagePath string value for the service's registry 
            // key (HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SimpleService).
            // These arguments are not used by this sample, this code is only intended to
            // demonstrate how to obtain the arguments.
            string[] imagePathArgs = Environment.GetCommandLineArgs();
            if (imagePathArgs.Length > 1)
            {
                EventLog.WriteEntry("SimpleService.ImagePath", "argument 1: " + imagePathArgs[1]);
                if (imagePathArgs.Length > 2)
                    EventLog.WriteEntry("SimpleService.ImagePath", "argument 2: " + imagePathArgs[2]);
            }
            // Get values for arguments passed in from the Services control panel or
            // by the ServiceController class Start(string[]) method.
            // Note:  The arguments are not persisted by the control panel. You must
            // open the properties for the service, set the arguments, then start the
            // service. You may find this functionality useful when debugging a service.
            // These arguments are not used by this sample, this code is only
            // intended to demonstrate how to obtain the arguments.
            if (args.Length > 1)
            {
                EventLog.WriteEntry("SimpleService.Arguments", args[0]);
                if (args.Length > 1)
                    EventLog.WriteEntry("SimpleService.Arguments", args[1]);
            }

        }
        // </Snippet3>

        // <Snippet4>
        // Stop this service.
        protected override void OnStop()
        {
            // New in .NET Framework version 2.0.
            this.RequestAdditionalTime(4000);
            // Signal the worker thread to exit.
            if ((workerThread != null) && (workerThread.IsAlive))
            {
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.OnStop", DateTime.Now.ToLongTimeString() +
                    " - Stopping the service worker thread.");
#endif
                pause.Reset();
                Thread.Sleep(5000);
                workerThread.Abort();

            }
            if (workerThread != null)
            {
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.OnStop", DateTime.Now.ToLongTimeString() +
                    " - OnStop Worker thread state = " +
                    workerThread.ThreadState.ToString());
#endif
            }
            // Indicate a successful exit.
            this.ExitCode = 0;
        }
        // </Snippet4>

        // <Snippet5>
        // Pause the service.
        protected override void OnPause()
        {
            // Pause the worker thread.
            if ((workerThread != null) &&
                (workerThread.IsAlive) &&
                ((workerThread.ThreadState &
                 (System.Threading.ThreadState.Suspended | System.Threading.ThreadState.SuspendRequested)) == 0))
            {
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.OnPause", DateTime.Now.ToLongTimeString() +
                    " - Pausing the service worker thread.");
#endif

                pause.Reset();
                Thread.Sleep(5000);
            }

            if (workerThread != null)
            {
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.OnPause", DateTime.Now.ToLongTimeString() +
                    " OnPause - Worker thread state = " +
                    workerThread.ThreadState.ToString());
#endif
            }
        }
        // </Snippet5>
        //<Snippet11>
        protected override void OnShutdown()
        {
#if LOGEVENTS
            EventLog.WriteEntry("SimpleService.OnShutdown", DateTime.Now.ToLongTimeString() +
                " - Stopping the SimpleService.");
#endif
        }
        //</Snippet11>
        // <Snippet6>
        // Continue a paused service.
        protected override void OnContinue()
        {

            // Signal the worker thread to continue.
            if ((workerThread != null) &&
                ((workerThread.ThreadState &
                 (System.Threading.ThreadState.Suspended | System.Threading.ThreadState.SuspendRequested)) != 0))
            {
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.OnContinue", DateTime.Now.ToLongTimeString() +
                    " - Resuming the service worker thread.");

#endif
                pause.Set();

            }
#if LOGEVENTS
            if (workerThread != null)
            {
                EventLog.WriteEntry("SimpleService.OnContinue", DateTime.Now.ToLongTimeString() +
                    " OnContinue - Worker thread state = " +
                    workerThread.ThreadState.ToString());
#endif
            }
        }
        // </Snippet6>

        // <Snippet7>
        // Handle a custom command.
        protected override void OnCustomCommand(int command)
        {
#if LOGEVENTS
            EventLog.WriteEntry("SimpleService.OnCustomCommand", DateTime.Now.ToLongTimeString() +
                " - Custom command received: " +
                command.ToString());
#endif

            // If the custom command is recognized,
            // signal the worker thread appropriately.

            switch (command)
            {
                case (int)SimpleServiceCustomCommands.StopWorker:
                    // Signal the worker thread to terminate.
                    // For this custom command, the main service
                    // continues to run without a worker thread.
                    pause.Reset();
                    break;

                case (int)SimpleServiceCustomCommands.RestartWorker:

                    // Restart the worker thread if necessary.
                    pause.Set();
                    break;

                case (int)SimpleServiceCustomCommands.CheckWorker:
#if LOGEVENTS
                    // Log the current worker thread state.
                    EventLog.WriteEntry("SimpleService.OnCustomCommand", DateTime.Now.ToLongTimeString() +
                        " OnCustomCommand - Worker thread state = " +
                        workerThread.ThreadState.ToString());
#endif

                    break;

                default:
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnCustomCommand",
                        DateTime.Now.ToLongTimeString());
#endif
                    break;
            }
        }
        // </Snippet7>
        //<Snippet9>
        //<Snippet10>
        // Handle a session change notice
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
#if LOGEVENTS
            EventLog.WriteEntry("SimpleService.OnSessionChange", DateTime.Now.ToLongTimeString() +
                " - Session change notice received: " +
                changeDescription.Reason.ToString() + "  Session ID: " +
                changeDescription.SessionId.ToString());
#endif

            //</Snippet10>
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    userCount += 1;
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " SessionLogon, total users: " +
                        userCount.ToString());
#endif
                    break;
                case SessionChangeReason.SessionLogoff:

                    userCount -= 1;
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " SessionLogoff, total users: " +
                        userCount.ToString());
#endif
                    break;
                case SessionChangeReason.RemoteConnect:
                    userCount += 1;
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " RemoteConnect, total users: " +
                        userCount.ToString());
#endif
                    break;
                case SessionChangeReason.RemoteDisconnect:
                    userCount -= 1;
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " RemoteDisconnect, total users: " +
                        userCount.ToString());
#endif
                    break;
                case SessionChangeReason.SessionLock:
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " SessionLock");
#endif
                    break;
                case SessionChangeReason.SessionUnlock:
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.OnSessionChange",
                        DateTime.Now.ToLongTimeString() +
                        " SessionUnlock");
#endif
                    break;
                default:
                    break;
            }
        }
        //</Snippet9>
        // Define a simple method that runs as the worker thread for 
        // the service.  
        public void ServiceWorkerMethod()
        {
#if LOGEVENTS
            EventLog.WriteEntry("SimpleService.WorkerThread", DateTime.Now.ToLongTimeString() +
                " - Starting the service worker thread.");
#endif

            try
            {
                do
                {
                    // Simulate 4 seconds of work.
                    Thread.Sleep(4000);
                    // Block if the service is paused or is shutting down.
                    pause.WaitOne();
#if LOGEVENTS
                    EventLog.WriteEntry("SimpleService.WorkerThread", DateTime.Now.ToLongTimeString() +
                        " - heartbeat cycle.");
#endif
                }
                while (true);
            }
            catch (ThreadAbortException)
            {
                // Another thread has signalled that this worker
                // thread must terminate.  Typically, this occurs when
                // the main service thread receives a service stop 
                // command.

                // Write a trace line indicating that the worker thread
                // is exiting.  Notice that this simple thread does
                // not have any local objects or data to clean up.
#if LOGEVENTS
                EventLog.WriteEntry("SimpleService.WorkerThread", DateTime.Now.ToLongTimeString() +
                    " - Thread abort signaled.");
#endif
            }
#if LOGEVENTS

            EventLog.WriteEntry("SimpleService.WorkerThread", DateTime.Now.ToLongTimeString() +
                " - Exiting the service worker thread.");
#endif

        }
    }
}
//</Snippet1>

