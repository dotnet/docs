using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Diagnostics;

namespace UIAMultipleViewPattern_snip
{
    class UIAMultipleViewPattern_snippets
    {
        AutomationElementCollection targetControl;

        /// <summary>
        /// Constructor.
        /// </summary>

        public UIAMultipleViewPattern_snippets()
        {
            AutomationElement targetWindow =
                StartTargetApp(System.Windows.Forms.Application.StartupPath +
                "\\MultipleViewPattern_snip_Target.exe");

            targetWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(
                AutomationElement.NameProperty, "C:\\Documents and Settings\\kbridge\\Desktop\\UISpy"));
            targetControl = FindAutomationElement(targetWindow);

            MultipleViewPattern multipleViewPattern =
                GetMultipleViewPattern(targetControl[0]);

            int i = GetCurrentViewProperty(targetControl[0]);

        }

        // <Snippet100>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Finds all automation elements that satisfy 
        /// the specified condition(s).
        /// </summary>
        /// <param name="targetApp">
        /// The automation element from which to start searching.
        /// </param>
        /// <returns>
        /// A collection of automation elements satisfying 
        /// the specified condition(s).
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElementCollection FindAutomationElement(
            AutomationElement targetApp)
        {
            if (targetApp == null)
            {
                throw new ArgumentException("Root element cannot be null.");
            }

            PropertyCondition conditionSupportsMultipleView =
                new PropertyCondition(
                AutomationElement.IsMultipleViewPatternAvailableProperty, true);

            return targetApp.FindAll(
                TreeScope.Descendants, conditionSupportsMultipleView);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a MultipleViewPattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A MultipleViewPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private MultipleViewPattern GetMultipleViewPattern(
            AutomationElement targetControl)
        {
            MultipleViewPattern multipleViewPattern = null;

            try
            {
                multipleViewPattern =
                    targetControl.GetCurrentPattern(
                    MultipleViewPattern.Pattern)
                    as MultipleViewPattern;
            }
            // Object doesn't support the MultipleViewPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return multipleViewPattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the collection of currently supported views from a target.
        /// </summary>
        /// <param name="multipleViewControl">
        /// The current multiple view control.
        /// </param>
        /// <returns>
        /// A collection of identifiers representing the supported views.
        /// </returns>
        ///--------------------------------------------------------------------
        private int[] GetSupportedViewsFromPattern(
            AutomationElement multipleViewControl)
        {
            if (multipleViewControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement parameter must not be null.");
            }

            return multipleViewControl.GetCurrentPropertyValue(
                MultipleViewPattern.SupportedViewsProperty) as int[];
        }
        // </Snippet102>

        // <Snippet1025>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the collection of currently supported views from a target.
        /// </summary>
        /// <param name="multipleViewPattern">
        /// The MultipleViewPattern obtained from a multiple view control.
        /// </param>
        /// <returns>
        /// A collection of identifiers representing the supported views.
        /// </returns>
        ///--------------------------------------------------------------------
        private int[] GetSupportedViewsFromControl(
            MultipleViewPattern multipleViewPattern)
        {
            if (multipleViewPattern == null)
            {
                throw new ArgumentNullException(
                    "MultipleViewPattern parameter must not be null.");
            }

            return multipleViewPattern.Current.GetSupportedViews();
        }
        // </Snippet1025>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current view identifier from a target.
        /// </summary>
        /// <param name="multipleViewControl">
        /// The current multiple view control.
        /// </param>
        /// <returns>
        /// The current view identifier.
        /// </returns>
        ///--------------------------------------------------------------------
        private int GetCurrentViewProperty(
            AutomationElement multipleViewControl)
        {
            if (multipleViewControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement parameter must not be null.");
            }

            return (int)multipleViewControl.GetCurrentPropertyValue(
                MultipleViewPattern.CurrentViewProperty);
        }
        // </Snippet103>

        // <Snippet1035>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current view identifier from a target.
        /// </summary>
        /// <param name="multipleViewPattern">
        /// The control pattern of interest.
        /// </param>
        /// <returns>
        /// The current view identifier.
        /// </returns>
        ///--------------------------------------------------------------------
        private int GetCurrentViewFromPattern(
            MultipleViewPattern multipleViewPattern)
        {
            if (multipleViewPattern == null)
            {
                throw new ArgumentNullException(
                    "MultipleViewPattern parameter must not be null.");
            }

            return multipleViewPattern.Current.CurrentView;
        }
        // </Snippet1035>

        // <Snippet104>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Sets the current view of a target.
        /// </summary>
        /// <param name="multipleViewControl">
        /// The current multiple view control.
        /// </param>
        /// <param name="viewID">
        /// The view identifier from the supported views collection.
        /// </param>
        ///--------------------------------------------------------------------
        private void SetView(AutomationElement multipleViewControl, int viewID)
        {
            if (multipleViewControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement parameter must not be null.");
            }

            // Get a MultipleViewPattern from the current control.
            MultipleViewPattern multipleViewPattern = 
                GetMultipleViewPattern(multipleViewControl);

            if (multipleViewPattern != null)
            {
                try
                {
                    multipleViewPattern.SetCurrentView(viewID);
                }
                // viewID is not a member of the supported views collection
                catch (ArgumentException)
                {
                    // TO DO: error handling
                }
            }
        }
        // </Snippet104>

        // <Snippet105>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the name of the current view of a target.
        /// </summary>
        /// <param name="multipleViewControl">
        /// The current multiple view control.
        /// </param>
        /// <returns>
        /// The current view name.
        /// </returns>
        ///--------------------------------------------------------------------
        private string ViewName(AutomationElement multipleViewControl)
        {
            if (multipleViewControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement parameter must not be null.");
            }

            // Get a MultipleViewPattern from the current control.
            MultipleViewPattern multipleViewPattern =
                GetMultipleViewPattern(multipleViewControl);

            if (multipleViewControl != null)
            {
                try
                {
                    int viewID = 
                        (int)multipleViewControl.GetCurrentPropertyValue(
                        MultipleViewPattern.CurrentViewProperty);
                    return multipleViewPattern.GetViewName(viewID);
                }
                catch (ArgumentException)
                {
                    // TO DO: error handling
                }
            }
            return null;
        }
        // </Snippet105>

        ///--------------------------------------------------------------------
        /// <summary>
        /// Starts the target app containing controls of interest.
        /// </summary>
        /// <param name="target">
        /// The filepath for the target executable.
        /// </param>
        /// <returns>
        /// An automation element representing the target window.
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElement StartTargetApp(string target)
        {
            Process p = Process.Start(target);
            if (p.WaitForInputIdle(50000) == false)
            {
                return null;
            }
            else System.Windows.MessageBox.Show(
                    "Target ready for user interaction");

            // Return the automation element
            return AutomationElement.FromHandle(p.MainWindowHandle);
        }

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
                UIAMultipleViewPattern_snippets app = new UIAMultipleViewPattern_snippets();
            }
        }
    }
}
