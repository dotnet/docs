using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Windows;

namespace UIAInvokePattern_snip
{
    class UIAInvokePattern_snippets : Application
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIAInvokePattern_snippets()
        {
            ;
        }
        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains an InvokePattern control pattern from a control
        /// and calls the InvokePattern.Invoke() method on the control.
        /// </summary>
        /// <param name="targetControl">
        /// The control of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private void InvokeControl(AutomationElement targetControl)
        {
            InvokePattern invokePattern = null;

            try
            {
                invokePattern =
                    targetControl.GetCurrentPattern(InvokePattern.Pattern)
                    as InvokePattern;
            }
            catch (ElementNotEnabledException)
            {
                // Object is not enabled
                return;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the InvokePattern control pattern
                return;
            }

            invokePattern.Invoke();
        }
        // </Snippet101>

        ///--------------------------------------------------------------------
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///--------------------------------------------------------------------
        internal sealed class TestMain
        {
            [STAThread()]
            static void Main()
            {
                // Create an instance of the sample class 
                // and call its Run() method to start it.
                UIAInvokePattern_snippets app = new UIAInvokePattern_snippets();

                app.Run();
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles our application shutdown.
        /// </summary>
        /// <param name="args">Event arguments.</param>
        ///--------------------------------------------------------------------
        protected override void OnExit(ExitEventArgs args)
        {
            Automation.RemoveAllEventHandlers();
            base.OnExit(args);
        }
    }
}
