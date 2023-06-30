/******************************************************************************
 *
 * File: WindowMove.cs
 *
 * Description:
 *       Moves a WCP window from a random location on the desktop to the
 *       top-left corner of the desktop. This is accomplished by obtaining an
 *       automation element based on the text value of the window,
 *       and then obtaining a TransformPattern object from this element.
 *       If the element is moveable, rects for both the element and the
 *       desktop are created.
 *       The top and left coordinates needed to move the parent window are set
 *       and, if not out of range, the window is moved to the new coordinates.
 *
 * Programming Elements:
 *    This sample demonstrates the following UI Automation programming elements
 *    from the System.Windows.Automation namespace:
 *       Automation class
 *           ScopeFlags
 *       AutomationElement class
 *           RootElement property
 *           AutomationIDProperty property
 *           TryGetCurrentPattern() method
 *           Current struct
 *           BoundingRectangle property
 *           Condition property
 *       WindowPattern class
 *           WaitForInputIdle method
 *           WindowVisualState property
 *           SetWindowVisualState method
 *       TransformPattern class
 *           CanMove property
 *           Move() method
 *       AutomationProperty class
 *           ToString() method
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
using System.Windows.Documents;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Threading;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Threading;

namespace SDKSample
{
    /// <summary>
    /// WindowMove application.
    /// </summary>
    public class WindowMove : Application
    {
        private DockPanel informationPanel;
        private AutomationElement targetWindow;
        private WindowPattern windowPattern;
        private TransformPattern transformPattern;
        private Point targetLocation;
        private TextBox xCoordinate;
        private TextBox yCoordinate;
        private Button moveTarget;
        private StringBuilder feedbackText = new StringBuilder();
        private String targetApplication = "Notepad.exe";
        // Delegates for updating the client UI based on target application events.
        private delegate void FeedbackDelegate(string message);
        private delegate void ClientControlsDelegate(Object src);

        // <Snippet1301>
        /// <summary>
        /// The Startup handler.
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Start the WindowMove client.
            CreateWindow();

            try
            {
                // Obtain an AutomationElement from the target window handle.
                targetWindow = StartTargetApp(targetApplication);

                // Does the automation element exist?
                if (targetWindow == null)
                {
                    Feedback("No target.");
                    return;
                }
                Feedback("Found target.");

                // find current location of our window
                targetLocation = targetWindow.Current.BoundingRectangle.Location;

                // Obtain required control patterns from our automation element
                windowPattern = GetControlPattern(targetWindow,
                    WindowPattern.Pattern) as WindowPattern;

                if (windowPattern == null) return;

                // Make sure our window is usable.
                // WaitForInputIdle will return before the specified time
                // if the window is ready.
                if (false == windowPattern.WaitForInputIdle(10000))
                {
                    Feedback("Object not responding in a timely manner.");
                    return;
                }
                Feedback("Window ready for user interaction");

                // Register for required events
                RegisterForEvents(
                    targetWindow, WindowPattern.Pattern, TreeScope.Element);

                // Obtain required control patterns from our automation element
                transformPattern =
                    GetControlPattern(targetWindow, TransformPattern.Pattern)
                    as TransformPattern;

                if (transformPattern == null) return;

                // Is the TransformPattern object moveable?
                if (transformPattern.Current.CanMove)
                {
                    // Enable our WindowMove fields
                    xCoordinate.IsEnabled = true;
                    yCoordinate.IsEnabled = true;
                    moveTarget.IsEnabled = true;

                    // Move element
                    transformPattern.Move(0, 0);
                }
                else
                {
                    Feedback("Window is not moveable.");
                }
            }
            catch (ElementNotAvailableException)
            {
                Feedback("Client window no longer available.");
                return;
            }
            catch (InvalidOperationException)
            {
                Feedback("Client window cannot be moved.");
                return;
            }
            catch (Exception exc)
            {
                Feedback(exc.ToString());
            }
        }
        // </Snippet1301>

        /// <summary>
        /// Start the WindowMove client.
        /// </summary>
       private void CreateWindow()
        {
            Window window = new Window();
            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Horizontal;
            sp.HorizontalAlignment = HorizontalAlignment.Center;

            TextBlock txtX = new TextBlock();
            txtX.Text = "X-coordinate: ";
            txtX.VerticalAlignment = VerticalAlignment.Center;

            xCoordinate = new TextBox();
            xCoordinate.Text = "0";
            xCoordinate.IsEnabled = false;
            xCoordinate.MaxLines = 1;
            xCoordinate.MaxLength = 4;
            xCoordinate.Margin = new Thickness(10, 0, 10, 0);

            TextBlock txtY = new TextBlock();
            txtY.Text = "Y-coordinate: ";
            txtY.VerticalAlignment = VerticalAlignment.Center;

            yCoordinate = new TextBox();
            yCoordinate.Text = "0";
            yCoordinate.IsEnabled = false;
            yCoordinate.MaxLines = 1;
            yCoordinate.MaxLength = 4;
            yCoordinate.Margin = new Thickness(10, 0, 10, 0);

            moveTarget = new Button();
            moveTarget.IsEnabled = false;
            moveTarget.Width = 100;
            moveTarget.Content = "Move Window";
            moveTarget.Click += new RoutedEventHandler(btnMove_Click);

            sp.Children.Add(txtX);
            sp.Children.Add(xCoordinate);
            sp.Children.Add(txtY);
            sp.Children.Add(yCoordinate);
            sp.Children.Add(moveTarget);

            informationPanel = new DockPanel();
            informationPanel.LastChildFill = false;
            DockPanel.SetDock(sp, Dock.Top);
            informationPanel.Children.Add(sp);

            window.Content = informationPanel;
            window.Show();
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Provides feedback in the client.
        /// </summary>
        /// <param name="message">The string to display.</param>
        /// <remarks>
        /// Since the events may happen on a different thread than the
        /// client we need to use a Dispatcher delegate to handle them.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void Feedback(string message)
        {
            // Check if we need to call BeginInvoke.
            if (this.Dispatcher.CheckAccess() == false)
            {
                // Pass the same function to BeginInvoke,
                // but the call would come on the correct
                // thread and InvokeRequired will be false.
                this.Dispatcher.BeginInvoke(
                    DispatcherPriority.Send,
                    new FeedbackDelegate(Feedback),
                    message);
                return;
            }
            TextBlock textElement = new TextBlock();
            textElement.Text = message;
            DockPanel.SetDock(textElement, Dock.Top);
            informationPanel.Children.Add(textElement);
        }

        //<Snippet1300>
        /// <summary>
        /// Handles the 'Move' button invoked event.
        /// By default, the Move method does not allow an object
        /// to be moved completely off-screen.
        /// </summary>
        /// <param name="src">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnMove_Click(object src, RoutedEventArgs e)
        {
            try
            {
                // If coordinate left blank, substitute 0
                if (xCoordinate.Text == "") xCoordinate.Text = "0";
                if (yCoordinate.Text == "") yCoordinate.Text = "0";

                // Reset background colours
                xCoordinate.Background = System.Windows.Media.Brushes.White;
                yCoordinate.Background = System.Windows.Media.Brushes.White;

                if (windowPattern.Current.WindowVisualState ==
                    WindowVisualState.Minimized)
                    windowPattern.SetWindowVisualState(WindowVisualState.Normal);

                double X = double.Parse(xCoordinate.Text);
                double Y = double.Parse(yCoordinate.Text);

                // Should validate the requested screen location
                if ((X < 0) ||
                    (X >= (SystemParameters.WorkArea.Width -
                    targetWindow.Current.BoundingRectangle.Width)))
                {
                    Feedback("X-coordinate would place the window all or partially off-screen.");
                    xCoordinate.Background = System.Windows.Media.Brushes.Yellow;
                }

                if ((Y < 0) ||
                    (Y >= (SystemParameters.WorkArea.Height -
                    targetWindow.Current.BoundingRectangle.Height)))
                {
                    Feedback("Y-coordinate would place the window all or partially off-screen.");
                    yCoordinate.Background = System.Windows.Media.Brushes.Yellow;
                }

                // transformPattern was obtained from the target window.
                transformPattern.Move(X, Y);
            }
            catch (ElementNotAvailableException)
            {
                Feedback("Client window no longer available.");
                return;
            }
            catch (InvalidOperationException)
            {
                Feedback("Client window cannot be moved.");
                return;
            }
        }
        //</Snippet1300>

        /// <summary>
        /// Update client controls based on target location changes.
        /// </summary>
        /// <param name="src">The object that raised the event.</param>
        private void UpdateClientControls(Object src)
        {
            // If window is minimized, no need to report new screen coordinates
            if (windowPattern.Current.WindowVisualState == WindowVisualState.Minimized)
                return;

            Point ptCurrent =
                ((AutomationElement)src).Current.BoundingRectangle.Location;
            if (targetLocation != ptCurrent)
            {
                Feedback("Window moved from " + targetLocation.ToString() +
                    " to " + ptCurrent.ToString());
                targetLocation = ptCurrent;
            }
            if (targetLocation.X != double.Parse(xCoordinate.Text))
            {
                Feedback("Alert: Final X-coordinate not equal to requested X-coordinate.");
                xCoordinate.Text = targetLocation.X.ToString();
            }
            if (targetLocation.Y != double.Parse(yCoordinate.Text))
            {
                Feedback("Alert: Final Y-coordinate not equal to requested Y-coordinate.");
                yCoordinate.Text = targetLocation.Y.ToString();
            }
        }

        /// <summary>
        /// Window move event handler.
        /// </summary>
        /// <param name="src">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnWindowMove(Object src, AutomationPropertyChangedEventArgs e)
        {
            // Pass the same function to BeginInvoke.
            this.Dispatcher.BeginInvoke(
                DispatcherPriority.Send,
                new ClientControlsDelegate(UpdateClientControls), src);
        }

        /// <summary>
        /// Starts the target application.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <returns>The target automation element.</returns>
        private AutomationElement StartTargetApp(string app)
        {
            try
            {
                // Start application.
                Process p = Process.Start(app);
                if (p.WaitForInputIdle(20000) == true)
                    Feedback("Window ready for user interaction");
                else return null;

                // Give application a second to startup.
                Thread.Sleep(2000);

                // Return the automation element
                return AutomationElement.FromHandle(p.MainWindowHandle);
            }
            catch (ArgumentException e)
            {
                Feedback(e.ToString());
                return null;
            }
            catch (Win32Exception e)
            {
                Feedback(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets a specified control pattern.
        /// </summary>
        /// <param name="ae">
        /// The automation element we want to obtain the control pattern from.
        /// </param>
        /// <param name="ap">The control pattern of interest.</param>
        /// <returns>A ControlPattern object.</returns>
        private Object GetControlPattern(
            AutomationElement ae, AutomationPattern ap)
        {
            Object oPattern = null;

            if (false == ae.TryGetCurrentPattern(ap, out oPattern))
            {
                Feedback("Object does not support the " +
                    ap.ProgrammaticName.ToString() + " Pattern");
                return null;
            }

            Feedback("Object supports the " +
                ap.ProgrammaticName.ToString() + " Pattern.");

            return oPattern;
        }

        /// <summary>
        /// Register for events of interest.
        /// </summary>
        /// <param name="ae">The automation element of interest.</param>
        /// <param name="ap">The control pattern of interest.</param>
        /// <param name="ts">The tree scope of interest.</param>
        private void RegisterForEvents(AutomationElement ae,
            AutomationPattern ap, TreeScope ts)
        {
            if (ap.Id == WindowPattern.Pattern.Id)
            {
                // The WindowPattern Exposes an element's ability
                // to change its on-screen position or size.

                // The following code shows an example of listening for the
                // BoundingRectangle property changed event on the window.
                Feedback("Start listening for WindowMove events for the control.");

                // Define an AutomationPropertyChangedEventHandler delegate to
                // listen for window moved events.
                AutomationPropertyChangedEventHandler moveHandler =
                    new AutomationPropertyChangedEventHandler(OnWindowMove);

                Automation.AddAutomationPropertyChangedEventHandler(
                    ae, ts, moveHandler,
                    AutomationElement.BoundingRectangleProperty);
            }
        }

        /// <summary>
        /// Window shut down event handler.
        /// </summary>
        /// <param name="e">The exit event arguments.</param>
        protected override void OnExit(ExitEventArgs e)
        {
            Automation.RemoveAllEventHandlers();
            base.OnExit(e);
        }

        /// <summary>
        /// Launch the sample application.
        /// </summary>
        internal sealed class TestMain
        {
            [STAThread()]
            static void Main()
            {
                // Create an instance of the sample class
                WindowMove app = new WindowMove();
                app.Run();
            }
        }
    }
}
