using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Permissions;

// Creates a class to throw the error.
namespace Samples.Microsoft.WindowsThreadException
{

    // Our Form class. Contains the program's entry point.
    public class ErrorHandlerForm : System.Windows.Forms.Form
    {

        // Inserts the code to create a form.
        public ErrorHandlerForm()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.AutoSize = true;
            flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Controls.Add(flowPanel);

            Button button1 = new Button();
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Text = "Throw UI exception";
            button1.Click += new EventHandler(button1_Click);
            flowPanel.Controls.Add(button1);

            // Add a second button for firing off a second thread that will fire an exception.
            Button button2 = new Button();
            button2.AutoSize = true;
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.Text = "Throw non-UI exception";
            button2.Click += new EventHandler(button2_Click);
            flowPanel.Controls.Add(button2);
        }

        //<SNIPPET1>
        Thread newThread = null;

        // Starts the application. 
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static void Main(string[] args)
        {
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(ErrorHandlerForm.Form1_UIThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Runs the application.
            Application.Run(new ErrorHandlerForm());
        }

        // Programs the button to throw an exception when clicked.
        private void button1_Click(object sender, System.EventArgs e)
        {
            throw new ArgumentException("The parameter was invalid");
        }

        // Start a new thread, separate from Windows Forms, that will throw an exception.
        private void button2_Click(object sender, System.EventArgs e)
        {
            ThreadStart newThreadStart = new ThreadStart(newThread_Execute);
            newThread = new Thread(newThreadStart);
            newThread.Start();
        }

        // The thread we start up to demonstrate non-UI exception handling. 
        void newThread_Execute()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        // NOTE: This exception cannot be kept from terminating the application - it can only 
        // log the event, and inform the user about it. 
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
                    "with the following information:\n\n";

                // Since we can't prevent the app from terminating, log this to the event log.
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                EventLog myLog = new EventLog();
                myLog.Source = "ThreadException";
                myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                "with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }
        // </SNIPPET1>
    }
}