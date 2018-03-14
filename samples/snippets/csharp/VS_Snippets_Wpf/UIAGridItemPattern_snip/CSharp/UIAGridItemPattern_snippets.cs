using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAGridItemPattern_snip
{
    class UIAGridItemPattern_snippets : System.Windows.Application
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIAGridItemPattern_snippets()
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
        /// <param name="targetControl">
        /// The specific grid container of interest.
        /// </param>
        /// <returns>
        /// A collection of automation elements satisfying 
        /// the specified condition(s).
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElementCollection FindAutomationElement(
            AutomationElement targetApp, AutomationElement targetControl)
        {
            if (targetApp == null)
            {
                throw new ArgumentException("Root element cannot be null.");
            }

            PropertyCondition conditionSupportsGridItemPattern =
                new PropertyCondition(
                AutomationElement.IsGridItemPatternAvailableProperty, true);

            PropertyCondition conditionContainerGrid =
                new PropertyCondition(
                GridItemPattern.ContainingGridProperty, targetControl);

            AndCondition conditionGridItems =
                new AndCondition(
                conditionSupportsGridItemPattern,
                conditionContainerGrid);

            return targetApp.FindAll(
                TreeScope.Descendants, conditionGridItems);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a GridItemPattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A GridItemPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private GridItemPattern GetGridItemPattern(
            AutomationElement targetControl)
        {
            GridItemPattern gridItemPattern = null;

            try
            {
                gridItemPattern =
                    targetControl.GetCurrentPattern(
                    GridItemPattern.Pattern)
                    as GridItemPattern;
            }
            // Object doesn't support the 
            // GridPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return gridItemPattern;
        }
        // </Snippet101>

        // <Snippet1015>
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
        // </Snippet1015>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Set up grid item event listeners.
        /// </summary>
        /// <param name="targetControl">
        /// The grid item container of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private void SetGridItemEventListeners(AutomationElement targetControl)
        {
            AutomationFocusChangedEventHandler gridItemFocusChangedListener =
                new AutomationFocusChangedEventHandler(OnGridItemFocusChange);
            Automation.AddAutomationFocusChangedEventHandler(
                gridItemFocusChangedListener);
        }
        // </Snippet102>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Event handler for grid item focus change.
        /// Can be used to track traversal of individual grid items 
        /// within a grid.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void OnGridItemFocusChange(
            object src, AutomationFocusChangedEventArgs e)
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

            // Gets a GridItemPattern from the source of the event.
            GridItemPattern gridItemPattern = 
                GetGridItemPattern(sourceElement);

            if (gridItemPattern == null)
            {
                return;
            }

            // Gets a GridPattern from the grid container.
            GridPattern gridPattern = 
                GetGridPattern(gridItemPattern.Current.ContainingGrid);

            if (gridPattern == null)
            {
                return;
            }

            AutomationElement gridItem = null;
            try
            {
                gridItem = gridPattern.GetItem(
                gridItemPattern.Current.Row, 
                gridItemPattern.Current.Column);
            }
            catch (ArgumentOutOfRangeException)
            {
                // If the requested row coordinate is larger than the RowCount 
                // or the column coordinate is larger than the ColumnCount.
                // -- OR --
                // If either of the requested row or column coordinates 
                // are less than zero.
                // TO DO: error handling.
            }

            // Further event processing can be done at this point.
            // For the purposes of this sample we just report item properties.
            StringBuilder gridItemReport = new StringBuilder();
            gridItemReport.AppendLine(
                gridItemPattern.Current.Row.ToString()).AppendLine(
                gridItemPattern.Current.Column.ToString()).AppendLine(
                gridItemPattern.Current.RowSpan.ToString()).AppendLine(
                gridItemPattern.Current.ColumnSpan.ToString()).AppendLine(
                gridItem.Current.AutomationId.ToString());
            Console.WriteLine(gridItemReport.ToString());
        }

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

        // <Snippet104>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current property values from target.
        /// </summary>
        /// <param name="gridItemPattern">
        /// A GridItemPattern control pattern obtained from 
        /// an automation element representing a target control.
        /// </param>
        /// <param name="automationProperty">
        /// The automation property of interest.
        /// </param>
        /// <returns>
        /// An integer object representing the requested property value.
        /// </returns>
        ///--------------------------------------------------------------------
        private object GetGridItemProperties(
            GridItemPattern gridItemPattern,
            AutomationProperty automationProperty)
        {
            if (automationProperty.Id ==
                GridItemPattern.ColumnProperty.Id)
            {
                return gridItemPattern.Current.Column;
            }
            if (automationProperty.Id ==
                GridItemPattern.RowProperty.Id)
            {
                return gridItemPattern.Current.Row;
            }
            if (automationProperty.Id ==
                GridItemPattern.ColumnSpanProperty.Id)
            {
                return gridItemPattern.Current.ColumnSpan;
            }
            if (automationProperty.Id ==
                GridItemPattern.RowSpanProperty.Id)
            {
                return gridItemPattern.Current.RowSpan;
            }

            return null;
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
                UIAGridItemPattern_snippets app = new UIAGridItemPattern_snippets();

                app.Run();
            }
        }
    }
}
