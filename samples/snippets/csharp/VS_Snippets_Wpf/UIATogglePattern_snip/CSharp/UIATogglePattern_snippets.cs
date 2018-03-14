using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIATogglePattern_snip
{
    class UIATogglePattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIATogglePattern_snippets()
        {
            ;
        }

        // <Snippet100>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Finds all automation elements that satisfy 
        /// the specified condition(s).
        /// </summary>
        /// <param name="rootElement">
        /// The automation element from which to start searching.
        /// </param>
        /// <returns>
        /// A collection of automation elements satisfying 
        /// the specified condition(s).
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElementCollection FindAutomationElement(
            AutomationElement rootElement)
        {
            if (rootElement == null)
            {
                throw new ArgumentException("Root element cannot be null.");
            }

            PropertyCondition conditionOn =
                new PropertyCondition(
                TogglePattern.ToggleStateProperty, ToggleState.On);

            PropertyCondition conditionIndeterminate =
                new PropertyCondition(
                TogglePattern.ToggleStateProperty, ToggleState.Indeterminate);

            // Use any combination of the preceding condtions to 
            // find the control(s) of interest
            OrCondition condition = new OrCondition(
                conditionOn,
                conditionIndeterminate);

            return rootElement.FindAll(TreeScope.Descendants, condition);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a TogglePattern control pattern from an automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A TogglePattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private TogglePattern GetTogglePattern(AutomationElement targetControl)
        {
            TogglePattern togglePattern = null;

            try
            {
                togglePattern =
                    targetControl.GetCurrentPattern(TogglePattern.Pattern)
                    as TogglePattern;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the TogglePattern control pattern
                return null;
            }

            return togglePattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Calls the TogglePattern.Toggle() method for an associated 
        /// automation element.
        /// </summary>
        /// <param name="togglePattern">
        /// The TogglePattern control pattern obtained from
        /// an automation element.
        /// </param>
        ///--------------------------------------------------------------------
        private void ToggleElement(TogglePattern togglePattern)
        {
            try
            {
                togglePattern.Toggle();
            }
            catch (InvalidOperationException)
            {
                // object is not able to perform the requested action
                return;
            }
        }
        // </Snippet102>


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
                UIATogglePattern_snippets app = new UIATogglePattern_snippets();
            }
        }
    }
}
