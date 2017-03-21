using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.IO;
using System.Diagnostics;

namespace UIARangeValuePattern_snip
{
    class UIARangeValuePattern_snippets
    {
        AutomationElementCollection targetControl;

        /// <summary>
        /// Constructor.
        /// </summary>
        public UIARangeValuePattern_snippets()
        {
            AutomationElement targetWindow = 
                StartTargetApp(System.Windows.Forms.Application.StartupPath + 
                "\\RangeValuePattern_snip_Target.exe");
            targetControl = FindAutomationElement(targetWindow);

            RangeValuePattern rangeValuePattern = 
                GetRangeValuePattern(targetControl[0]);

            object d = GetRangeValueProperty(rangeValuePattern, RangeValuePattern.LargeChangeProperty);

            // <Snippet103SmallChange>
            SetRangeValue(targetControl[0], rangeValuePattern.Current.SmallChange, 1);
            // </Snippet103SmallChange>

            // <Snippet103LargeChange>
            SetRangeValue(targetControl[0], rangeValuePattern.Current.LargeChange, -1);
            // </Snippet103LargeChange>

            // <Snippet104Minimum>
            SetRangeValue(targetControl[0], rangeValuePattern.Current.Minimum);
            // </Snippet104Minimum>

            // <Snippet104Maximum>
            SetRangeValue(targetControl[0], rangeValuePattern.Current.Maximum);
            // </Snippet104Maximum>
        }


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

            PropertyCondition conditionIsReadOnly =
                new PropertyCondition(
                RangeValuePattern.IsReadOnlyProperty, false);

            return targetApp.FindAll(
                TreeScope.Descendants, conditionIsReadOnly);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a RangeValuePattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A RangeValuePattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private RangeValuePattern GetRangeValuePattern(
            AutomationElement targetControl)
        {
            RangeValuePattern rangeValuePattern = null;

            try
            {
                rangeValuePattern =
                    targetControl.GetCurrentPattern(
                    RangeValuePattern.Pattern)
                    as RangeValuePattern;
            }
            // Object doesn't support the 
            // RangeValuePattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return rangeValuePattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current property values from target.
        /// </summary>
        /// <param name="rangeValuePattern">
        /// A RangeValuePattern control pattern obtained from 
        /// an automation element representing a target control.
        /// </param>
        /// <param name="automationProperty">
        /// The automation property of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private object GetRangeValueProperty(
            RangeValuePattern rangeValuePattern,
            AutomationProperty automationProperty)
        {
            if (rangeValuePattern == null || automationProperty == null)
            {
                throw new ArgumentException("Argument cannot be null.");
            }

            if (automationProperty.Id ==
                RangeValuePattern.MinimumProperty.Id)
            {
                return rangeValuePattern.Current.Minimum;
            }
            if (automationProperty.Id ==
                RangeValuePattern.MaximumProperty.Id)
            {
                return rangeValuePattern.Current.Maximum;
            }
            if (automationProperty.Id ==
                RangeValuePattern.SmallChangeProperty.Id)
            {
                return rangeValuePattern.Current.SmallChange;
            }
            if (automationProperty.Id ==
                RangeValuePattern.LargeChangeProperty.Id)
            {
                return rangeValuePattern.Current.LargeChange;
            }
            if (automationProperty.Id ==
                RangeValuePattern.ValueProperty.Id)
            {
                return rangeValuePattern.Current.Value;
            }
            return null;
        }
        // </Snippet102>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Sets the range value of the control of interest.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <param name="rangeValue">
        /// The value (either relative or absolute) to set the control to.
        /// </param>
        /// <param name="rangeDirection">
        /// The value used to specify the direction of adjustment.
        /// </param>
        ///--------------------------------------------------------------------
        private void SetRangeValue(
            AutomationElement targetControl,
            double rangeValue,
            double rangeDirection)
        {
            if (targetControl == null || rangeValue == 0 || rangeDirection == 0)
            {
                throw new ArgumentException("Argument cannot be null or zero.");
            }

            RangeValuePattern rangeValuePattern =
                GetRangeValuePattern(targetControl);

            if (rangeValuePattern.Current.IsReadOnly)
            {
                throw new InvalidOperationException("Control is read-only.");
            }

            rangeValue = rangeValue * Math.Sign(rangeDirection);

            try
            {
                if ((rangeValue <= rangeValuePattern.Current.Maximum) ||
                    (rangeValue >= rangeValuePattern.Current.Minimum))
                {
                    rangeValuePattern.SetValue(rangeValue);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // TO DO: Error handling.
            }
            catch (ArgumentException)
            {
                // TO DO: Error handling.
            }
        }
        // </Snippet103>

        // <Snippet104>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Sets the range value of the control of interest.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <param name="rangeValue">
        /// The value (either relative or absolute) to set the control to.
        /// </param>
        ///--------------------------------------------------------------------
        private void SetRangeValue(
            AutomationElement targetControl,
            double rangeValue)
        {
            if (targetControl == null)
            {
                throw new ArgumentException("Argument cannot be null.");
            }

            RangeValuePattern rangeValuePattern =
                GetRangeValuePattern(targetControl);

            if (rangeValuePattern.Current.IsReadOnly)
            {
                throw new InvalidOperationException("Control is read-only.");
            }

            try
            {
                rangeValuePattern.SetValue(rangeValue);
            }
            catch (ArgumentOutOfRangeException)
            {
                // TO DO: Error handling.
            }
            catch (ArgumentException)
            {
                // TO DO: Error handling.
            }
        }
        // </Snippet104>


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
                UIARangeValuePattern_snippets app = new UIARangeValuePattern_snippets();
            }
        }

    }
}
