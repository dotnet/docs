using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAValuePattern_snip
{
    class UIAValuePattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIAValuePattern_snippets()
        {
            ;
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
                ValuePattern.IsReadOnlyProperty, false);

            return targetApp.FindAll(
                TreeScope.Descendants, conditionIsReadOnly);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a ValuePattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A ValuePattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private ValuePattern GetValuePattern(
            AutomationElement targetControl)
        {
            ValuePattern valuePattern = null;

            try
            {
                valuePattern =
                    targetControl.GetCurrentPattern(
                    ValuePattern.Pattern)
                    as ValuePattern;
            }
            // Object doesn't support the ValuePattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return valuePattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current property values from target.
        /// </summary>
        /// <param name="valuePattern">
        /// A ValuePattern control pattern obtained from 
        /// an automation element representing a target control.
        /// </param>
        /// <param name="automationProperty">
        /// The automation property of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private object GetValueProperty(
            ValuePattern valuePattern,
            AutomationProperty automationProperty)
        {
            if (valuePattern == null || automationProperty == null)
            {
                throw new ArgumentNullException("Argument cannot be null.");
            }

            if (automationProperty.Id ==
                ValuePattern.ValueProperty.Id)
            {
                return valuePattern.Current.Value;
            }
            return null;
        }
        // </Snippet102>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Inserts a string into a text control that supports ValuePattern.
        /// </summary>
        /// <param name="targetControl">A text control.</param>
        /// <param name="value">The string to be inserted.</param>
        ///--------------------------------------------------------------------
        private void InsertText(AutomationElement targetControl,
                                            string value)
        {
            // Validate arguments / initial setup
            if (value == null)
                throw new ArgumentNullException(
                    "String parameter must not be null.");

            if (targetControl == null)
                throw new ArgumentNullException(
                    "AutomationElement parameter must not be null");

            // A series of basic checks prior to attempting an insertion.
            //
            // Check #1: Is control enabled?
            // An alternative to testing for static or read-only controls 
            // is to filter using 
            // PropertyCondition(AutomationElement.IsEnabledProperty, true) 
            // and exclude all read-only text controls from the collection.
            if (!targetControl.Current.IsEnabled)
            {
                throw new InvalidOperationException(
                    "The control is not enabled.\n\n");
            }

            // Check #2: Are there styles that prohibit us 
            //           from sending text to this control?
            if (!targetControl.Current.IsKeyboardFocusable)
            {
                throw new InvalidOperationException(
                    "The control is not focusable.\n\n");
            }

            // Once you have an instance of an AutomationElement,  
            // check if it supports the ValuePattern pattern.
            object valuePattern = null;

            if (!targetControl.TryGetCurrentPattern(
                ValuePattern.Pattern, out valuePattern))
            {
                // Elements that support TextPattern 
                // do not support ValuePattern and TextPattern
                // does not support setting the text of 
                // multi-line edit or document controls.
                // For this reason, text input must be simulated.
            }
            // Control supports the ValuePattern pattern so we can 
            // use the SetValue method to insert content.
            else
            {
                if (((ValuePattern)valuePattern).Current.IsReadOnly)
                {
                    throw new InvalidOperationException(
                        "The control is read-only.");
                }
                else
                {
                    ((ValuePattern)valuePattern).SetValue(value);
                }
            }
        }
        //</Snippet103>

        
        
        
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
                UIAValuePattern_snippets app = new UIAValuePattern_snippets();
            }
        }
    }
}
