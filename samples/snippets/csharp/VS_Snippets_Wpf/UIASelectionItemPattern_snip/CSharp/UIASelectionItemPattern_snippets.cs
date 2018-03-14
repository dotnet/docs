using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIASelectionItemPattern_snip
{
    class UIASelectionItemPattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIASelectionItemPattern_snippets()
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

            PropertyCondition conditionIsSelected =
                new PropertyCondition(
                SelectionItemPattern.IsSelectedProperty, false);

            return rootElement.FindAll(
                TreeScope.Descendants, conditionIsSelected);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Subscribe to the selection item events of interest.
        /// </summary>
        /// <param name="selectionItem">
        /// Automation element that supports SelectionItemPattern and is 
        /// a child of a selection container that supports SelectionPattern
        /// </param>
        /// <remarks>
        /// The events are raised by the SelectionItem elements, 
        /// not the Selection container.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void SetSelectionEventHandlers
            (AutomationElement selectionItem)
        {
            AutomationEventHandler selectionHandler =
                new AutomationEventHandler(SelectionHandler);

            Automation.AddAutomationEventHandler(
                SelectionItemPattern.ElementSelectedEvent,
                selectionItem,
                TreeScope.Element,
                SelectionHandler);
            Automation.AddAutomationEventHandler(
                SelectionItemPattern.ElementAddedToSelectionEvent,
                selectionItem,
                TreeScope.Element,
                SelectionHandler);
            Automation.AddAutomationEventHandler(
                SelectionItemPattern.ElementRemovedFromSelectionEvent,
                selectionItem,
                TreeScope.Element,
                SelectionHandler);
        }

        private void SelectionHandler(object src, AutomationEventArgs e)
        {
            // TODO: event handling
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a SelectionItemPattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A SelectionItemPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private SelectionItemPattern GetSelectionItemPattern(
            AutomationElement targetControl)
        {
            SelectionItemPattern selectionItemPattern = null;

            try
            {
                selectionItemPattern =
                    targetControl.GetCurrentPattern(
                    SelectionItemPattern.Pattern)
                    as SelectionItemPattern;
            }
            // Object doesn't support the 
            // SelectionItemPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return selectionItemPattern;
        }
        // </Snippet102>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Retrieves the selection container for a selection item.
        /// </summary>
        /// <param name="selectionItem">
        /// An automation element that supports SelectionItemPattern.
        /// </param>
        ///--------------------------------------------------------------------
        private AutomationElement GetSelectionItemContainer(
            AutomationElement selectionItem)
        {
            // Selection item cannot be null
            if (selectionItem == null)
            {
                throw new ArgumentException();
            }

            SelectionItemPattern selectionItemPattern = 
                selectionItem.GetCurrentPattern(SelectionItemPattern.Pattern) 
                as SelectionItemPattern;
            if (selectionItemPattern == null)
            {
                return null;
            }
            else
            {
                return selectionItemPattern.Current.SelectionContainer; 
            }
        }
        // </Snippet103>

        // <Snippet1035>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Retrieves the selection items for a selection container.
        /// </summary>
        /// <param name="rootElement">
        /// The automation element from which to start searching.
        /// </param>
        /// <param name="selectionContainer">
        /// An automation element that supports SelectionPattern.
        /// </param>
        /// <returns>
        /// A collection of automation elements satisfying 
        /// the specified condition(s).
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElementCollection FindElementBasedOnContainer(
            AutomationElement rootElement, AutomationElement selectionContainer)
        {
            PropertyCondition containerCondition = 
                new PropertyCondition(
                SelectionItemPattern.SelectionContainerProperty, 
                selectionContainer);
            AutomationElementCollection selectionItems = 
                rootElement.FindAll(TreeScope.Descendants, containerCondition);
            return selectionItems;
        }
        // </Snippet1035>

        // <Snippet104>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Attempts to add the current item to a collection 
        /// of selected items. 
        /// </summary>
        /// <param name="selectionItem">
        /// An automation element that supports SelectionItemPattern.
        /// </param>
        ///--------------------------------------------------------------------
        private void AddItemToSelection(AutomationElement selectionItem)
        {
            if (selectionItem == null)
            {
                throw new ArgumentNullException(
                    "Argument cannot be null or empty.");
            }
            
            AutomationElement selectionContainer = 
                GetSelectionItemContainer(selectionItem);

            // Selection container cannot be null
            if (selectionContainer == null)
            {
                throw new ElementNotAvailableException();
            }

            SelectionPattern selectionPattern = 
                selectionContainer.GetCurrentPattern(SelectionPattern.Pattern)
                as SelectionPattern;
            
            if (selectionPattern == null)
            {
                return;
            }

            if (selectionPattern.Current.CanSelectMultiple)
            {
                SelectionItemPattern selectionItemPattern =
                    selectionItem.GetCurrentPattern(
                    SelectionItemPattern.Pattern)
                    as SelectionItemPattern;
                if (selectionItemPattern != null)
                {
                    try
                    {
                        selectionItemPattern.AddToSelection();
                    }
                    catch (InvalidOperationException)
                    {
                        // Unable to add to selection
                        return;
                    }
                }
            }
        }
        // </Snippet104>

        // <Snippet105>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Attempts to remove the current item from a collection 
        /// of selected items. 
        /// </summary>
        /// <param name="selectionItem">
        /// An automation element that supports SelectionItemPattern.
        /// </param>
        ///--------------------------------------------------------------------
        private void RemoveItemFromSelection(AutomationElement selectionItem)
        {
            if (selectionItem == null)
            {
                throw new ArgumentNullException(
                    "Argument cannot be null or empty.");
            }

            AutomationElement selectionContainer =
                GetSelectionItemContainer(selectionItem);

            // Selection container cannot be null
            if (selectionContainer == null)
            {
                throw new ElementNotAvailableException();
            }

            SelectionPattern selectionPattern =
                selectionContainer.GetCurrentPattern(SelectionPattern.Pattern)
                as SelectionPattern;

            if (selectionPattern == null)
            {
                return;
            }

            // Check if a selection is required
            if (selectionPattern.Current.IsSelectionRequired && 
                (selectionPattern.Current.GetSelection().GetLength(0) <= 1))
            {
                return;
            }

            SelectionItemPattern selectionItemPattern =
                selectionItem.GetCurrentPattern(
                SelectionItemPattern.Pattern)
                as SelectionItemPattern;
            if ((selectionItemPattern != null) && 
                selectionItemPattern.Current.IsSelected)
            {
                try
                {
                    selectionItemPattern.RemoveFromSelection();
                }
                catch (InvalidOperationException)
                {
                    // Unable to remove from selection
                    return;
                }
            }
        }
        // </Snippet105>

        // <Snippet106>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Selects a string item in a container.
        /// </summary>
        /// <param name="selectionContainer">The selection container.</param>
        /// <param name="itemText">The text to select.</param>
        /// <remarks>
        /// This deselects any currently selected items. 
        /// To add the item to the current selection in a multiselect list, 
        /// use AddToSelection instead of Select.
        /// </remarks>
        ///--------------------------------------------------------------------
        public void SelectListItem(
            AutomationElement selectionContainer, String itemText)
        {
            if ((selectionContainer == null) || (itemText == ""))
            {
                throw new ArgumentException(
                    "Argument cannot be null or empty.");
            }

            Condition propertyCondition = new PropertyCondition(
                AutomationElement.NameProperty, 
                itemText, 
                PropertyConditionFlags.IgnoreCase);

            AutomationElement firstMatch = 
                selectionContainer.FindFirst(TreeScope.Children, propertyCondition);

            if (firstMatch != null)
            {
                try
                {
                    SelectionItemPattern selectionItemPattern;
                    selectionItemPattern = 
                    firstMatch.GetCurrentPattern(
                    SelectionItemPattern.Pattern) as SelectionItemPattern;
                    selectionItemPattern.Select();
                }
                catch (InvalidOperationException)
                {
                    // Unable to select
                    return;
                }
            }
        }
        // </Snippet106>

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
                UIASelectionItemPattern_snippets app = new UIASelectionItemPattern_snippets();
            }
        }
    }
}
