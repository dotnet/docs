using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAExpandCollapsePattern_snip
{
    class UIAExpandCollapsePattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIAExpandCollapsePattern_snippets()
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

            PropertyCondition conditionLeafNode =
                new PropertyCondition(
                ExpandCollapsePattern.ExpandCollapseStateProperty, 
                ExpandCollapseState.LeafNode);

            return targetApp.FindAll(
                TreeScope.Descendants, conditionLeafNode);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains an ExpandCollapsePattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A ExpandCollapsePattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private ExpandCollapsePattern GetExpandCollapsePattern(
            AutomationElement targetControl)
        {
            ExpandCollapsePattern expandCollapsePattern = null;

            try
            {
                expandCollapsePattern =
                    targetControl.GetCurrentPattern(
                    ExpandCollapsePattern.Pattern)
                    as ExpandCollapsePattern;
            }
            // Object doesn't support the ExpandCollapsePattern control pattern.
            catch (InvalidOperationException)
            {
                return null;
            }

            return expandCollapsePattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Programmatically expand or collapse a menu item.
        /// </summary>
        /// <param name="menuItem">
        /// The target menu item.
        /// </param>
        ///--------------------------------------------------------------------
        private void ExpandCollapseMenuItem(
            AutomationElement menuItem)
        {
            if (menuItem == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement argument cannot be null.");
            }

            ExpandCollapsePattern expandCollapsePattern =
                GetExpandCollapsePattern(menuItem);

            if (expandCollapsePattern == null)
            {
                return;
            }

            if (expandCollapsePattern.Current.ExpandCollapseState ==
                ExpandCollapseState.LeafNode)
            {
                return;
            }

            try
            {
                if (expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded)
                {
                    // Collapse the menu item.
                    expandCollapsePattern.Collapse();
                }
                else if (expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.Collapsed ||
                    expandCollapsePattern.Current.ExpandCollapseState == ExpandCollapseState.PartiallyExpanded)
                {
                    // Expand the menu item.
                    expandCollapsePattern.Expand();
                }
            }
            // Control is not enabled
            catch (ElementNotEnabledException)
            {
                // TO DO: error handling.
            }
            // Control is unable to perform operation.
            catch (InvalidOperationException)
            {
                // TO DO: error handling.
            }
        }
        // </Snippet102>

        private void RegisterForAutomationPropertyChanges(AutomationElement targetControl)
        {
            AutomationPropertyChangedEventHandler expandcollapseStateChange = new AutomationPropertyChangedEventHandler(OnExpandCollapse);

            Automation.AddAutomationPropertyChangedEventHandler(targetControl, TreeScope.Element, expandcollapseStateChange, ExpandCollapsePattern.ExpandCollapseStateProperty);

        }

        private void OnExpandCollapse(object src, AutomationPropertyChangedEventArgs e)
        {

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
                UIAExpandCollapsePattern_snippets app = new UIAExpandCollapsePattern_snippets();
            }
        }
    }
}
