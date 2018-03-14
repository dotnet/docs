using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIASelectionPattern_snip
{
    class UIASelectionPattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIASelectionPattern_snippets()
        {
            ;
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
                UIASelectionPattern_snippets app = new UIASelectionPattern_snippets();
            }
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

            PropertyCondition conditionCanSelectMultiple =
                new PropertyCondition(
                SelectionPattern.CanSelectMultipleProperty, true);

            PropertyCondition conditionIsSelectionRequired =
                new PropertyCondition(
                SelectionPattern.IsSelectionRequiredProperty, false);

            // Use any combination of the preceding condtions to 
            // find the control(s) of interest
            Condition condition = new AndCondition(
                conditionCanSelectMultiple,
                conditionIsSelectionRequired);

            return rootElement.FindAll(TreeScope.Descendants, condition);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a SelectionPattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A SelectionPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private SelectionPattern GetSelectionPattern(
            AutomationElement targetControl)
        {
            SelectionPattern selectionPattern = null;

            try
            {
                selectionPattern =
                    targetControl.GetCurrentPattern(SelectionPattern.Pattern)
                    as SelectionPattern;
            }
            // Object doesn't support the SelectionPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return selectionPattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the currently selected SelectionItem objects from target.
        /// </summary>
        /// <param name="selectionContainer">
        /// The current Selection container object.
        /// </param>
        ///--------------------------------------------------------------------
        private AutomationElement[] GetCurrentSelectionProperty(
            AutomationElement selectionContainer)
        {
            try
            {
                return selectionContainer.GetCurrentPropertyValue(
                    SelectionPattern.SelectionProperty) as AutomationElement[];
            }
            // Container is not enabled
            catch (InvalidOperationException)
            {
                return null;
            }
        }
        // </Snippet102>

        // <Snippet1025>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the currently selected SelectionItem objects from target.
        /// </summary>
        /// <param name="ae">The current Selection container object.</param>
        ///--------------------------------------------------------------------
        private AutomationElement[] GetCurrentSelection(
            AutomationElement selectionContainer)
        {
            try
            {
                SelectionPattern selectionPattern =
                    selectionContainer.GetCurrentPattern(
                    SelectionPattern.Pattern) as SelectionPattern;
                return selectionPattern.Current.GetSelection();
            }
            // Container is not enabled
            catch (InvalidOperationException)
            {
                return null;
            }
        }
        // </Snippet1025>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Subscribe to the selection events of interest.
        /// </summary>
        /// <param name="selectionContainer">
        /// Automation element that supports SelectionPattern
        /// </param>
        ///--------------------------------------------------------------------
        private void SetSelectionEventHandlers
            (AutomationElement selectionContainer)
        {            
            AutomationEventHandler selectionInvalidatedHandler =
                new AutomationEventHandler(SelectionInvalidatedHandler);

            Automation.AddAutomationEventHandler(
                SelectionPattern.InvalidatedEvent, 
                selectionContainer, 
                TreeScope.Element, 
                SelectionInvalidatedHandler);
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Selection invalidated event handler.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void SelectionInvalidatedHandler(object src, AutomationEventArgs e)
        {
            // TODO: event handling
        }
        // </Snippet103>

        // <Snippet104>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current property values from target.
        /// </summary>
        /// <param name="selectionPattern">
        /// A SelectionPattern control pattern obtained from 
        /// an automation element representing the selection control.
        /// </param>
        /// <param name="automationProperty">
        /// The automation property of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private bool GetSelectionObjectProperty(
            SelectionPattern selectionPattern,
            AutomationProperty automationProperty)
        {
            if (automationProperty.Id == 
                SelectionPattern.CanSelectMultipleProperty.Id)
            {
                return selectionPattern.Current.CanSelectMultiple;
            }
            if (automationProperty.Id == 
                SelectionPattern.IsSelectionRequiredProperty.Id)
            {
                return selectionPattern.Current.IsSelectionRequired;
            }
            return false;
        }
        // </Snippet104>
    }
}
