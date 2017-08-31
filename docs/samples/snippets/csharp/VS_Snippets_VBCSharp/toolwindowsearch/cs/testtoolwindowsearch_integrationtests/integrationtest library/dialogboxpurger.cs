
namespace Microsoft.VsSDK.IntegrationTestLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Threading;
    using Microsoft.VisualStudio.Shell.Interop;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// This class is responsible to close dialog boxes that pop up during different VS Calls
    /// </summary>
    internal class DialogBoxPurger : IDisposable
    {
        /// <summary>
        /// The default number of milliseconds to wait for the threads to signal to terminate.
        /// </summary>
        private const int DefaultMillisecondsToWait = 3500;

        /// <summary>
        /// Object used for synchronization between thread calls.
        /// </summary>
        internal static volatile object Mutex = new object();

        /// <summary>
        /// The IVsUIShell. This cannot be queried on the working thread from the service provider. Must be done in the main thread.!!
        /// </summary>
        private IVsUIShell uiShell;

        /// <summary>
        /// The button to "press" on the dialog.
        /// </summary>
        private int buttonAction;

        /// <summary>
        /// Thread signales to the calling thread that it is done.
        /// </summary>
        private bool exitThread = false;

        /// <summary>
        /// Calling thread signales to this thread to die.
        /// </summary>
        private AutoResetEvent threadDone = new AutoResetEvent(false);

        /// <summary>
        /// The queued thread started.
        /// </summary>
        private AutoResetEvent threadStarted = new AutoResetEvent(false);

        /// <summary>
        /// The result of the dialogbox closing for all the dialog boxes. That is if there are two of them and one fails this will be false.
        /// </summary>
        private bool dialogBoxCloseResult = false;

        /// <summary>
        /// The expected text to see on the dialog box. If set the thread will continue finding the dialog box with this text.
        /// </summary>
        private string expectedDialogBoxText = String.Empty;

        /// <summary>
        /// The number of the same  dialog boxes to wait for.
        /// This is for scenarios when two dialog boxes with the same text are popping up.
        /// </summary>
        private int numberOfDialogsToWaitFor = 1;

        /// <summary>
        /// Has the object been disposed.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Overloaded ctor.
        /// </summary>
        /// <param name="buttonAction">The botton to "press" on the dialog box.</param>
        /// <param name="numberOfDialogsToWaitFor">The number of dialog boxes with the same message to wait for. This is the situation when the same action pops up two of the same dialog boxes</param>
        /// <param name="expectedDialogMesssage">The expected dialog box message to check for.</param>
        internal DialogBoxPurger(int buttonAction, int numberOfDialogsToWaitFor, string expectedDialogMesssage)
        {
            this.buttonAction = buttonAction;
            this.numberOfDialogsToWaitFor = numberOfDialogsToWaitFor;
            this.expectedDialogBoxText = expectedDialogMesssage;
        }

        /// <summary>
        /// Overloaded ctor.
        /// </summary>
        /// <param name="buttonAction">The botton to "press" on the dialog box.</param>
        /// <param name="numberOfDialogsToWaitFor">The number of dialog boxes with the same message to wait for. This is the situation when the same action pops up two of the same dialog boxes</param>
        internal DialogBoxPurger(int buttonAction, int numberOfDialogsToWaitFor)
        {
            this.buttonAction = buttonAction;
            this.numberOfDialogsToWaitFor = numberOfDialogsToWaitFor;
        }

        /// <summary>
        /// Overloaded ctor.
        /// </summary>
        /// <param name="buttonAction">The botton to "press" on the dialog box.</param>
        /// <param name="expectedDialogMesssage">The expected dialog box message to check for.</param>
        internal DialogBoxPurger(int buttonAction, string expectedDialogMesssage)
        {
            this.buttonAction = buttonAction;
            this.expectedDialogBoxText = expectedDialogMesssage;
        }

        /// <summary>
        /// Overloaded ctor.
        /// </summary>
        /// <param name="buttonAction">The botton to "press" on the dialog box.</param>
        internal DialogBoxPurger(int buttonAction)
        {
            this.buttonAction = buttonAction;
        }

        /// <summary>
        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (this.isDisposed)
            {
                return;
            }

            this.WaitForDialogThreadToTerminate();

            this.isDisposed = true;
        }

        /// <summary>
        /// Spawns a thread that will start listening to dialog boxes.
        /// </summary>
        internal void Start()
        {
            // We ask for the uishell here since we cannot do that on the therad that we will spawn.
            IVsUIShell uiShell = Package.GetGlobalService(typeof(SVsUIShell)) as IVsUIShell;

            if (uiShell == null)
            {
                throw new InvalidOperationException("Could not get the uiShell from the serviceProvider");
            }

            this.uiShell = uiShell;

            System.Threading.Thread thread = new System.Threading.Thread(new ThreadStart(this.HandleDialogBoxes));
            thread.Start();

            // We should never deadlock here, hence do not use the lock. Wait to be sure that the thread started.
            this.threadStarted.WaitOne(3500, false);
        }

        /// <summary>
        /// Waits for the dialog box close thread to terminate. If the thread does not signal back within millisecondsToWait that it is shutting down,
        /// then it will tell to the thread to do it.
        /// </summary>
        internal bool WaitForDialogThreadToTerminate()
        {
            return this.WaitForDialogThreadToTerminate(DefaultMillisecondsToWait);
        }

        /// <summary>
        /// Waits for the dialog box close thread to terminate. If the thread does not signal back within millisecondsToWait that it is shutting down,
        /// then it will tell to the thread to do it.
        /// </summary>
        /// <param name="millisecondsToWait">The number milliseconds to wait for until the dialog purger thread is signaled to terminate. This is just for safe precaution that we do not hang. </param>
        /// <returns>The result of the dialog boxes closing</returns>
        internal bool WaitForDialogThreadToTerminate(int numberOfMillisecondsToWait)
        {
            bool signaled = false;

            // We give millisecondsToWait sec to bring up and close the dialog box.
            signaled = this.threadDone.WaitOne(numberOfMillisecondsToWait, false);

            // Kill the thread since a timeout occured.
            if (!signaled)
            {
                lock (Mutex)
                {
                    // Set the exit thread to true. Next time the thread will kill itselfes if it sees 
                    this.exitThread = true;
                }

                // Wait for the thread to finish. We should never deadlock here.
                this.threadDone.WaitOne();
            }

            return this.dialogBoxCloseResult;
        }

        /// <summary>
        /// This is the thread method. 
        /// </summary>
        private void HandleDialogBoxes()
        {
            // No synchronization numberOfDialogsToWaitFor since it is readonly
            IntPtr[] hwnds = new IntPtr[this.numberOfDialogsToWaitFor];
            bool[] dialogBoxCloseResults = new bool[this.numberOfDialogsToWaitFor];

            try
            {
                // Signal that we started
                lock (Mutex)
                {
                    this.threadStarted.Set();
                }

                // The loop will be exited either if a message is send by the caller thread or if we found the dialog. If a message box text is specified the loop will not exit until the dialog is found.
                bool stayInLoop = true;
                int dialogBoxesToWaitFor = 1;

                while (stayInLoop)
                {
                    int hwndIndex = dialogBoxesToWaitFor - 1;

                    // We need to lock since the caller might set context to null.
                    lock (Mutex)
                    {
                        if (this.exitThread)
                        {
                            break;
                        }

                        // We protect the shell too from reentrency.
                        this.uiShell.GetDialogOwnerHwnd(out hwnds[hwndIndex]);

                    }

                    if (hwnds[hwndIndex] != IntPtr.Zero)
                    {
                        StringBuilder windowClassName = new StringBuilder(256);
                        NativeMethods.GetClassName(hwnds[hwndIndex], windowClassName, windowClassName.Capacity);

                        // The #32770 is the class name of a messagebox dialog.
                        if (windowClassName.ToString().Contains("#32770"))
                        {
                            IntPtr unmanagedMemoryLocation = IntPtr.Zero;
                            string dialogBoxText = String.Empty;
                            try
                            {
                                unmanagedMemoryLocation = Marshal.AllocHGlobal(10 * 1024);
                                NativeMethods.EnumChildWindows(hwnds[hwndIndex], new NativeMethods.CallBack(FindMessageBoxString), unmanagedMemoryLocation);
                                dialogBoxText = Marshal.PtrToStringUni(unmanagedMemoryLocation);
                            }
                            finally
                            {
                                if (unmanagedMemoryLocation != IntPtr.Zero)
                                {
                                    Marshal.FreeHGlobal(unmanagedMemoryLocation);
                                }
                            }

                            lock (Mutex)
                            {

                                // Since this is running on the main thread be sure that we close the dialog.
                                bool dialogCloseResult = false;
                                if (this.buttonAction != 0)
                                {
                                    dialogCloseResult = NativeMethods.EndDialog(hwnds[hwndIndex], this.buttonAction);
                                }

                                // Check if we have found the right dialog box.
                                if (String.IsNullOrEmpty(this.expectedDialogBoxText) || (!String.IsNullOrEmpty(dialogBoxText) && String.Compare(this.expectedDialogBoxText, dialogBoxText.Trim(), StringComparison.OrdinalIgnoreCase) == 0))
                                {
                                    dialogBoxCloseResults[hwndIndex] = dialogCloseResult;
                                    if (dialogBoxesToWaitFor++ >= this.numberOfDialogsToWaitFor)
                                    {
                                        stayInLoop = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                //Let the main thread run a possible close command.
                System.Threading.Thread.Sleep(2000);

                foreach (IntPtr hwnd in hwnds)
                {
                    // At this point the dialog should be closed, if not attempt to close it.
                    if (hwnd != IntPtr.Zero)
                    {
                        NativeMethods.SendMessage(hwnd, NativeMethods.WM_CLOSE, 0, new IntPtr(0));
                    }
                }

                lock (Mutex)
                {
                    // Be optimistic.
                    this.dialogBoxCloseResult = true;

                    for (int i = 0; i < dialogBoxCloseResults.Length; i++)
                    {
                        if (!dialogBoxCloseResults[i])
                        {
                            this.dialogBoxCloseResult = false;
                            break;
                        }
                    }

                    this.threadDone.Set();
                }
            }
        }

        /// <summary>
        /// Finds a messagebox string on a messagebox.
        /// </summary>
        /// <param name="hwnd">The windows handle of the dialog</param>
        /// <param name="unmanagedMemoryLocation">A pointer to the memorylocation the string will be written to</param>
        /// <returns>True if found.</returns>
        private static bool FindMessageBoxString(IntPtr hwnd, IntPtr unmanagedMemoryLocation)
        {
            StringBuilder sb = new StringBuilder(512);
            NativeMethods.GetClassName(hwnd, sb, sb.Capacity);

            if (sb.ToString().ToLower().Contains("static"))
            {
                StringBuilder windowText = new StringBuilder(2048);
                NativeMethods.GetWindowText(hwnd, windowText, windowText.Capacity);

                if (windowText.Length > 0)
                {
                    IntPtr stringAsPtr = IntPtr.Zero;
                    try
                    {
                        stringAsPtr = Marshal.StringToHGlobalAnsi(windowText.ToString());
                        char[] stringAsArray = windowText.ToString().ToCharArray();

                        // Since unicode characters are copied check if we are out of the allocated length.
                        // If not add the end terminating zero.
                        if ((2 * stringAsArray.Length) + 1 < 2048)
                        {
                            Marshal.Copy(stringAsArray, 0, unmanagedMemoryLocation, stringAsArray.Length);
                            Marshal.WriteInt32(unmanagedMemoryLocation, 2 * stringAsArray.Length, 0);
                        }
                    }
                    finally
                    {
                        if (stringAsPtr != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(stringAsPtr);
                        }
                    }
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
