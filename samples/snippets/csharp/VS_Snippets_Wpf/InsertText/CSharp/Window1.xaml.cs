/******************************************************************************
 * File: Window1.xaml.cs
 *
 * Description:
 *    This sample opens a 'canned' Win32 application and shows how to use
 *    UI Automation to input text depending on the text control.
 *
 *    InsertTextTarget.exe should be automatically copied to the InsertText
 *    client folder when you build the sample. You may have to manually copy
 *    this file if you receive an error stating the file cannot be found.
 *
 * Programming Elements:
 *    The sample demonstrates the following UI Automation programming elements.
 *
 *       System.Windows.Automation Namespace:
 *         Automation Class
 *           AddAutomationEventHandler
 *           AddAutomationPropertyChangedEventHandler
 *         Condition Class
 *         AndCondition Class
 *         OrCondition Class
 *         AutomationElementCollection Class
 *         AutomationPattern Class
 *         AutomationElement Class
 *           IsTextPatternAvailableProperty field
 *           TryGetCurrentPattern method
 *           FromHandle method
 *           ControlTypeProperty field
 *           FindAll method
 *           SetFocus method
 *         TreeScope Enumeration
 *           Element member
 *           Descendants member
 *         ControlType Class
 *           Text field
 *           Edit field
 *           Document field
 *         TextPattern Class
 *           Pattern field
 *         ValuePattern Class
 *           Pattern field
 *           SetValue method
 *         AutomationPropertyChangedEventHandler Delegate
 *
 *
 * This file is part of the Microsoft .NET Framework SDK Code Samples.
 *
 * Copyright (C) Microsoft Corporation.  All rights reserved.
 *
 * This source code is intended only as a supplement to Microsoft
 * Development Tools and/or on-line documentation.  See these other
 * materials for detailed information regarding Microsoft code samples.
 *
 * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
 * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 * PARTICULAR PURPOSE.
 *
 *****************************************************************************/

using System;
using System.Windows;
using System.Diagnostics;
using System.Windows.Automation;
using System.Threading;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Threading;

namespace InsertTextClient
{
    ///------------------------------------------------------------------------
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    ///------------------------------------------------------------------------
    public partial class Window1 : Window
    {
        private AutomationElement targetWindow;
        private AutomationElementCollection textControls;
        // InsertTextTarget.exe should be automatically copied to the
        // InsertText client folder when you build the sample.
        // You may have to manually copy this file if you receive an error
        // stating the file cannot be found.
        private readonly string filePath =
            System.Windows.Forms.Application.StartupPath
            + "\\InsertTextTarget.exe";
        private StringBuilder feedbackText;

        // Delegates to be used in placing jobs onto the Dispatcher.
        private delegate void ControlsDelegate(bool arg1, bool arg2);
        private delegate void FeedbackDelegate(string arg1);

        ///--------------------------------------------------------------------
        /// <summary>
        /// The class constructor.
        /// </summary>
        // Initialize both client and target applications.
        ///--------------------------------------------------------------------
        public Window1()
        {
            InitializeComponent();
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the click event for the Start App button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void btnStartApp_Click(object sender, RoutedEventArgs e)
        {
            targetWindow = StartTargetApp(filePath);

            if (targetWindow == null)
            {
                return;
            }

            Feedback("Target started.");

            double clientLocationTop = Client.Top;
            double clientLocationRight = Client.Left + Client.Width + 100;
            TransformPattern transformPattern =
                targetWindow.GetCurrentPattern(TransformPattern.Pattern)
                as TransformPattern;
            if (transformPattern != null)
            {
                transformPattern.Move(clientLocationRight, clientLocationTop);
            }

            // Get required control patterns
            //
            // Once you have an instance of an AutomationElement for the target
            // obtain a WindowPattern object to handle the WindowClosed event.
            try
            {
                WindowPattern windowPattern =
                    targetWindow.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            }
            catch (InvalidOperationException)
            {
                Feedback("Object does not support the Window Pattern");
                return;
            }

            // Register for an Event
            //
            // The WindowPattern allows you to programmatically
            // manipulate a window.
            // It also exposes a window closed event.
            // The following code shows an example of listening
            // for the WindowClosed event.
            //
            // To intercept the WindowClosed event for our target application
            // you define an AutomationEventHandler delegate.
            AutomationEventHandler targetClosedHandler =
                new AutomationEventHandler(OnTargetClosed);

            // Use AddAutomationEventHandler() to add this event handler.
            // When listening for a WindowClosed event you must either scope
            // the event to the automation element as done here, or cast
            // the AutomationEventArgs in the handler to WindowClosedEventArgs
            // and compare the RuntimeId of the automation element that raised
            // the WindowClosed event to the automation element in the
            // class member data.
            Automation.AddAutomationEventHandler(
                WindowPattern.WindowClosedEvent,
                targetWindow,
                TreeScope.Element,
                targetClosedHandler);

            SetClientControlProperties(false, true);

            // Get our collection of interesting controls.
            textControls = FindTextControlsInTarget();
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the click event for the Insert Text buttons.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            feedbackText = new StringBuilder();
            if (string.IsNullOrEmpty(tbInsert.Text))
            {
                Feedback("Please enter some text to insert.");
                return;
            }
            switch (((System.Windows.Controls.Button) sender).Content.ToString())
            {
                case "UIAutomation":
                    SetValueWithUIAutomation(tbInsert.Text);
                    break;
                case "Win32":
                    SetValueWithWin32(tbInsert.Text);
                    break;
                default:
                    Feedback("Insert failed.");
                    return;
            }
        }

        //<SnippetInsertText>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Sets the values of the text controls using managed methods.
        /// </summary>
        /// <param name="s">The string to be inserted.</param>
        ///--------------------------------------------------------------------
        private void SetValueWithUIAutomation(string s)
        {
            foreach (AutomationElement control in textControls)
            {
                InsertTextUsingUIAutomation(control, s);
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Inserts a string into each text control of interest.
        /// </summary>
        /// <param name="element">A text control.</param>
        /// <param name="value">The string to be inserted.</param>
        ///--------------------------------------------------------------------
        private void InsertTextUsingUIAutomation(AutomationElement element,
                                            string value)
        {
            try
            {
                // Validate arguments / initial setup
                if (value == null)
                    throw new ArgumentNullException(
                        "String parameter must not be null.");

                if (element == null)
                    throw new ArgumentNullException(
                        "AutomationElement parameter must not be null");

                // A series of basic checks prior to attempting an insertion.
                //
                // Check #1: Is control enabled?
                // An alternative to testing for static or read-only controls
                // is to filter using
                // PropertyCondition(AutomationElement.IsEnabledProperty, true)
                // and exclude all read-only text controls from the collection.
                if (!element.Current.IsEnabled)
                {
                    throw new InvalidOperationException(
                        "The control with an AutomationID of "
                        + element.Current.AutomationId.ToString()
                        + " is not enabled.\n\n");
                }

                // Check #2: Are there styles that prohibit us
                //           from sending text to this control?
                if (!element.Current.IsKeyboardFocusable)
                {
                    throw new InvalidOperationException(
                        "The control with an AutomationID of "
                        + element.Current.AutomationId.ToString()
                        + "is read-only.\n\n");
                }

                // Once you have an instance of an AutomationElement,
                // check if it supports the ValuePattern pattern.
                object valuePattern = null;

                // Control does not support the ValuePattern pattern
                // so use keyboard input to insert content.
                //
                // NOTE: Elements that support TextPattern
                //       do not support ValuePattern and TextPattern
                //       does not support setting the text of
                //       multi-line edit or document controls.
                //       For this reason, text input must be simulated
                //       using one of the following methods.
                //
                if (!element.TryGetCurrentPattern(
                    ValuePattern.Pattern, out valuePattern))
                {
                    feedbackText.Append("The control with an AutomationID of ")
                        .Append(element.Current.AutomationId.ToString())
                        .Append(" does not support ValuePattern.")
                        .AppendLine(" Using keyboard input.\n");

                    // Set focus for input functionality and begin.
                    element.SetFocus();

                    // Pause before sending keyboard input.
                    Thread.Sleep(100);

                    // Delete existing content in the control and insert new content.
                    SendKeys.SendWait("^{HOME}");   // Move to start of control
                    SendKeys.SendWait("^+{END}");   // Select everything
                    SendKeys.SendWait("{DEL}");     // Delete selection
                    SendKeys.SendWait(value);
                }
                // Control supports the ValuePattern pattern so we can
                // use the SetValue method to insert content.
                else
                {
                    feedbackText.Append("The control with an AutomationID of ")
                        .Append(element.Current.AutomationId.ToString())
                        .Append((" supports ValuePattern."))
                        .AppendLine(" Using ValuePattern.SetValue().\n");

                    // Set focus for input functionality and begin.
                    element.SetFocus();

                    ((ValuePattern)valuePattern).SetValue(value);
                }
            }
            catch (ArgumentNullException exc)
            {
                feedbackText.Append(exc.Message);
            }
            catch (InvalidOperationException exc)
            {
                feedbackText.Append(exc.Message);
            }
            finally
            {
                Feedback(feedbackText.ToString());
            }
        }
        //</SnippetInsertText>

        ///--------------------------------------------------------------------
        /// <summary>
        /// Sets the values of the text controls using unmanaged methods.
        /// </summary>
        /// <param name="s">The string to be inserted.</param>
        ///--------------------------------------------------------------------
        private void SetValueWithWin32(string s)
        {
            foreach (AutomationElement control in textControls)
            {
                // An alternative to testing for static or read-only controls
                // is to filter using
                // PropertyCondition(AutomationElement.IsEnabledProperty, true)
                // and exclude all read-only text controls from the collection.
                InsertTextUsingWin32(control, s);
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Inserts the specified string into a text control.
        /// </summary>
        /// <param name="element">A text control.</param>
        /// <param name="value">The string to be inserted.</param>
        ///--------------------------------------------------------------------
        private void InsertTextUsingWin32(AutomationElement element, string value)
        {
            try
            {
                // Validate arguments / initial setup
                if (value == null)
                    throw new ArgumentNullException(
                        "String parameter 'value' must not be null.");

                if (element == null)
                    throw new ArgumentNullException(
                        "AutomationElement parameter 'element' must not be null");

                // Get hwnd
                IntPtr _hwnd = new IntPtr(element.Current.NativeWindowHandle);
                if (_hwnd == IntPtr.Zero)
                    throw new InvalidOperationException(
                        "Unable to get handle to object.");

                // A series of basic checks for the text control
                // prior to attempting an insertion.
                //
                // Check #1: Is control enabled?
                // An alternative to testing for static or read-only controls
                // is to filter using
                // PropertyCondition(AutomationElement.IsEnabledProperty, true)
                // and exclude all read-only text controls from the collection.
                if (!UnmanagedClass.IsWindowEnabled(_hwnd))
                {
                    throw new InvalidOperationException(
                        "The control with an AutomationID of "
                        + element.Current.AutomationId.ToString()
                        + " is not enabled.\n");
                }

                // Check #2: Are there styles that prohibit us from
                //           sending text to this control?
                UnmanagedClass.HWND hwnd = UnmanagedClass.HWND.Cast(_hwnd);
                int ControlStyle = UnmanagedClass.GetWindowLong(hwnd,
                                            UnmanagedClass.GCL_STYLE);

                if (IsBitSet(ControlStyle, UnmanagedClass.ES_READONLY))
                {
                    throw new InvalidOperationException(
                        "The control with an AutomationID of "
                        + element.Current.AutomationId.ToString() +
                        " is read-only.");
                }

                // Check #3: Is the size of the text we want to set
                //           greater than what the control accepts?
                IntPtr result;
                int resultInt;

                IntPtr resultSendMessage = UnmanagedClass.SendMessageTimeout(
                    hwnd,
                    UnmanagedClass.EM_GETLIMITTEXT,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    1,
                    10000,
                    out result);
                int lastWin32Error =
                    System.Runtime.InteropServices.Marshal.GetLastWin32Error();

                if (resultSendMessage == IntPtr.Zero)
                {
                    throw new InvalidOperationException(
                        "SendMessageTimeout() timed out.");
                }
                resultInt = unchecked((int)(long)result);

                // A result of -1 means that no limit is set.
                if (resultInt != -1 && resultInt < value.Length)
                {
                    throw new InvalidOperationException(
                        "The length of text entered ("
                        + value.Length
                        + ") is greater than the upper limit of the "
                        + "control with an AutomationID of "
                        + element.Current.AutomationId.ToString()
                        + " (" + resultInt.ToString() + ")"
                        + ".");
                }

                // Send the message...!
                result = UnmanagedClass.SendMessageTimeout(
                    hwnd,
                    UnmanagedClass.WM_SETTEXT,
                    IntPtr.Zero,
                    new StringBuilder(value),
                    1,
                    10000,
                    out result);
                resultInt = unchecked((int)(long)result);
                if (resultInt != 1)
                {
                    throw new InvalidOperationException(
                        "The text of the control with an AutomationID of "
                        + element.Current.AutomationId.ToString() +
                        " cannot be changed.");
                }
                feedbackText.Append(
                    "The text of the control with an AutomationID of ")
                    .Append(element.Current.AutomationId.ToString())
                    .AppendLine(" has been set.\n");
            }
            catch (EntryPointNotFoundException exc)
            {
                feedbackText.AppendLine(exc.Message);
            }
            catch (ArgumentNullException exc)
            {
                feedbackText.AppendLine(exc.Message);
            }
            catch (InvalidOperationException exc)
            {
                feedbackText.AppendLine(exc.Message);
            }
            finally
            {
                Feedback(feedbackText.ToString());
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets a pointer to an AutomationElement
        /// </summary>
        /// <param name="element">A text control.</param>
        /// <returns>A pointer to an AutomationElement</returns>
        ///--------------------------------------------------------------------
        private IntPtr GetWindowHandleFromAutomationElement
            (AutomationElement element)
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                object objHwnd = element.GetCurrentPropertyValue(
                    AutomationElement.NativeWindowHandleProperty);

                if (objHwnd is IntPtr)
                    ptr = (IntPtr)objHwnd;
                else
                    ptr = new IntPtr(Convert.ToInt64(objHwnd));

                if (ptr == IntPtr.Zero)
                    throw new InvalidOperationException
                        ("Unable to get a handle for the element with an AutomationID of "
                        + element.Current.AutomationId.ToString() + ".");
            }
            catch (InvalidOperationException exc)
            {
                Feedback(exc.Message.ToString());
            }
            return ptr;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Is bit set?
        /// </summary>
        /// <param name="flags">The flag(s) of interest.</param>
        /// <param name="bit">The bit value(s).</param>
        ///--------------------------------------------------------------------
        private bool IsBitSet(int flags, int bit)
        {
            return (flags & bit) == bit;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Finds the text controls of interest.
        /// </summary>
        /// <returns>A collection of Automation Elements
        /// that satisfy the specified conditions.</returns>
        ///--------------------------------------------------------------------
        // Find all 'text' controls that support TextPattern.
        private AutomationElementCollection FindTextControlsInTarget()
        {
            AndCondition condition = new AndCondition(
                    new OrCondition(
                        new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Edit),
                        new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Document),
                        new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.Text)),
                    new PropertyCondition(
                    AutomationElement.IsTextPatternAvailableProperty,
                    true)
                   );
            return targetWindow.FindAll(TreeScope.Descendants, condition);
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Starts the target app that contains the text controls of interest.
        /// </summary>
        /// <param name="sTarget">The target exe.</param>
        /// <returns>An Automation Element from our target window.</returns>
        ///--------------------------------------------------------------------
        // Start our target Win32 application
        private AutomationElement StartTargetApp(string target)
        {
            if (!File.Exists(target))
            {
                feedbackText.Append(target).Append(" not found.");
                Feedback(feedbackText.ToString());
                return null;
            }
            Process p;
            try
            {
                // Start application.
                p = Process.Start(target);
                if (p == null)
                    return null;

                // Give the target application some time to startup.
                // For Win32 applications, WaitForInputIdle can be used instead.
                // Another alternative is to listen for WindowOpened events.
                // Otherwise, an ArgumentException results when you try to
                // retrieve an automation element from the window handle.
                Thread.Sleep(2500);

                // Return the automation element
                return AutomationElement.FromHandle(p.MainWindowHandle);
            }
            catch (Win32Exception e)
            {
                Feedback(e.ToString());
                return null;
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Intercepts the target window closed event and starts the client
        /// window BackgroundWorker object.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// It is not advisable to operate on your own UI within an
        /// event handler. This is especially true in a multi-threaded
        /// environment as the event handler is unlikely to be called on the
        /// UI thread.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void OnTargetClosed(object sender, AutomationEventArgs e)
        {
            // Schedule the update function in the UI thread.
            spInsert.Dispatcher.BeginInvoke(
                DispatcherPriority.Send,
                new ControlsDelegate(SetClientControlProperties),
                true, false);
            txtFeedback.Dispatcher.BeginInvoke(
                DispatcherPriority.Send,
                new FeedbackDelegate(Feedback),
                "Target closed.");
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Sets attributes of the controls in the client app.
        /// </summary>
        /// <param name="e">Enabled property.</param>
        /// <param name="v">Visibility property.</param>
        ///--------------------------------------------------------------------
        private void SetClientControlProperties(bool e1, bool e2)
        {
            btnStartApp.IsEnabled = e1;
            tbkInsert.IsEnabled = e2;
            spInsert.IsEnabled = e2;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Outputs information to the client window.
        /// </summary>
        /// <param name="s">The string to display.</param>
        ///--------------------------------------------------------------------
        private void Feedback(string s)
        {
            txtFeedback.Text = s;
        }
    }
}