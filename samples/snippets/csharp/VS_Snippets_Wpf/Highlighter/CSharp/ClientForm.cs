/*******************************************************************************
 * File: ClientForm.cs
 *
 * Description: 
 * 
 * The sample demonstrates how to keep track of focus changes so that focused
 * elements can be highlighted on the screen. The highlight is a simple colored
 * rectangle, but it could be a magnifier window or some other tool to make the
 * focused element more accessible.
 * 
 * For convenience and simplicity, the sample runs in its own window. A real-world
 * application might run in the background.
 * 
 * Sometimes focus-changed events occur in rapid succession: for example, when
 * the user rapidly moves the cursor down a menu. Also, when a complex element 
 * such as a list box receives the focus, generally two events are raised: one
 * for the container receiving the focus, and one for the focused item within
 * the container. To avoid flicker (rapid drawing and erasing of the highlight),
 * the sample uses a timer. The timer is started, or restarted, whenever an event
 * is received. Only when the timer reaches its interval is the highlight redrawn.
 * Thus the response to an event becomes "pending" when the event occurs and is 
 * discarded if another event occurs before the timer interval has elapsed.
 * 
 * You can experiment with different timer intervals by using the slider.
 * 
 *      
 *  This file is part of the Microsoft Windows SDK Code Samples.
 * 
 *  Copyright (C) Microsoft Corporation.  All rights reserved.
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
 ******************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Threading;
using System.Timers;


namespace Highlighter
{
    /// <summary>
    /// The form for the client application.
    /// </summary>
    public partial class ClientForm : Form
    {
        private HighlightRectangle highlight;
        private bool useTimer = true;
        System.Timers.Timer eventTimer;
        System.Windows.Rect focusedRect;
        AutomationFocusChangedEventHandler focusHandler;
        AutomationElement focusedElement;
        int timerInterval;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ClientForm()
        {
            // Make the process DPI-aware. Doing this ensures that when the
            // screen is set to a nonstandard DPI, all coordinates are 
            // correctly scaled and the highlight rectangle is displayed
            // in the correct place.
            try
            {
                NativeMethods.SetProcessDPIAware();
            }
            catch (EntryPointNotFoundException)
            { 
                // Not running under Vista.
            }
            InitializeComponent();

            // Create timer.
            timerInterval = tbInterval.Value;
            eventTimer = new System.Timers.Timer();
            eventTimer.Elapsed += new ElapsedEventHandler(OnTimerTick);
            eventTimer.Enabled = false;
            eventTimer.AutoReset = false;
            timerInterval = tbInterval.Value;
            eventTimer.Interval = timerInterval;

            // Create highlight rectangle.
            highlight = new HighlightRectangle();

            // Start a new thread to subscribe to UI Automation events.
            ThreadStart threadDelegate = new ThreadStart(StartListening);
            Thread UIAutoThread = new Thread(threadDelegate);
            UIAutoThread.Start();
        }


        /// <summary>
        /// Subscribe to UI Automation events.
        /// </summary>
        /// <remarks>
        /// Do not call from the UI thread.
        /// </remarks>
        private void StartListening()
        {
            focusHandler = new AutomationFocusChangedEventHandler(OnFocusChanged);
            Automation.AddAutomationFocusChangedEventHandler(focusHandler);
        }

        /// <summary>
        /// Unsubscribe to UI Automation events.  
        /// </summary>
        private void StopListening()
        {
            eventTimer.Stop();
            Automation.RemoveAutomationFocusChangedEventHandler(focusHandler);
        }


        /// <summary>
        /// Responds to focus changes. Starts the timer so that the highlight 
        /// will be updated, or updates the highlight immediately if the timer
        /// interval is set to 0.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// 
        private void OnFocusChanged(object src, AutomationFocusChangedEventArgs e)
        {
            focusedElement = src as AutomationElement;
            focusedRect = focusedElement.Current.BoundingRectangle;

#if DEBUG
            Console.WriteLine("Focus moved to: " + focusedElement.Current.Name);
#endif

            if (useTimer)
            {
                eventTimer.Interval = timerInterval;
                eventTimer.Start();
            }
            else
            {
                UpdateHighlight();
            }
        }

        /// <summary>
        /// Hides the old rectangle and creates a new one.
        /// </summary>
        private void UpdateHighlight()
        {
            // Hide old rectangle.
                highlight.Visible = false;

            // Show new rectangle.
            highlight.Location = new Rectangle(
                (int)focusedRect.Left, (int)focusedRect.Top, 
                (int)focusedRect.Width, (int)focusedRect.Height);
            highlight.Visible = true;
        }

        /// <summary>
        /// Updates the highlight rectangle.
        /// </summary>
        /// <param name="sender">Ojbect that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>The timer stops because AutoReset is false.</remarks>
        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateHighlight();
        }

        /// <summary>
        /// Responds to a change in the trackbar.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Setting the value to 0 is equivalent to turning off the timer.
        /// </remarks>
        private void tbInterval_ValueChanged(object sender, EventArgs e)
        {
            if (tbInterval.Value > 0)
            {
                timerInterval = tbInterval.Value;
                useTimer = true;
            }
            else
            {
                useTimer = false;
            }
        }

        /// <summary>
        /// Responds to Exit button click.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Responds to form closing. Unsubscribes to UI Automation events.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Start a new thread to unsubscribe to UI Automation events.
            ThreadStart threadDelegate = new ThreadStart(StopListening);
            Thread UIAutoThread = new Thread(threadDelegate);
            UIAutoThread.Start();
        }

        /// <summary>
        /// The entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ClientForm());
        }

    } // class
} // namespace