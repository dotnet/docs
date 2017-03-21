using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAGridPattern_snip
{
    class UIAGridPattern_snippets : System.Windows.Application
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIAGridPattern_snippets()
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

            PropertyCondition conditionSupportsGridPattern =
                new PropertyCondition(
                AutomationElement.IsGridPatternAvailableProperty, true);

            PropertyCondition conditionOneColumn =
                new PropertyCondition(
                GridPattern.ColumnCountProperty, 1);

            PropertyCondition conditionOneRow =
                new PropertyCondition(
                GridPattern.RowCountProperty, 1);

            AndCondition conditionSingleItemGrid =
                new AndCondition(
                conditionSupportsGridPattern, 
                conditionOneColumn, conditionOneRow);

            return targetApp.FindAll(
                TreeScope.Descendants, conditionSingleItemGrid);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a GridPattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A GridPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private GridPattern GetGridPattern(
            AutomationElement targetControl)
        {
            GridPattern gridPattern = null;

            try
            {
                gridPattern =
                    targetControl.GetCurrentPattern(
                    GridPattern.Pattern)
                    as GridPattern;
            }
            // Object doesn't support the 
            // GridPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return gridPattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Set up grid event listeners.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private void SetGridEventListeners(AutomationElement targetControl)
        {
            StructureChangedEventHandler gridStructureChangedListener = 
                new StructureChangedEventHandler(OnGridStructureChange);
            Automation.AddStructureChangedEventHandler(
                targetControl, 
                TreeScope.Element, 
                gridStructureChangedListener);
        }
        // </Snippet102>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Event handler for grid structure change.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void OnGridStructureChange(
            object src, StructureChangedEventArgs e)
        {
            // Make sure the element still exists. Elements such as tooltips
            // can disappear before the event is processed.
            AutomationElement sourceElement;
            try
            {
                sourceElement = src as AutomationElement;
            }
            catch (ElementNotAvailableException)
            {
                return;
            }

            GridPattern gridPattern = GetGridPattern(sourceElement);

            if (gridPattern == null)
            {
                return;
            }

            if (gridPattern.Current.ColumnCount != columnCount)
            {
                // Column item added.
            }
            else if (gridPattern.Current.RowCount != rowCount)
            {
                // Row item added.
            }
        }
        // Member variables to track current row and column counts.
        private int columnCount = 0;
        private int rowCount = 0;

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles our application shutdown.
        /// </summary>
        /// <param name="args">Event arguments.</param>
        ///--------------------------------------------------------------------
        protected override void OnExit(System.Windows.ExitEventArgs args)
        {
            Automation.RemoveAllEventHandlers();
            base.OnExit(args);
        }

        // </Snippet103>

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
                UIAGridPattern_snippets app = new UIAGridPattern_snippets();
            }

            
        }
    }
}
