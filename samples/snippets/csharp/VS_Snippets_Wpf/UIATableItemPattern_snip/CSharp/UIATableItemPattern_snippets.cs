using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Diagnostics;

namespace UIATableItemPattern_snip
{
    class UIATableItemPattern_snippets : System.Windows.Application
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIATableItemPattern_snippets()
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
                UIATableItemPattern_snippets app = new UIATableItemPattern_snippets();

                app.Run();
            }
        }

        // <SnippetStartTarget>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Starts the target application and returns the AutomationElement
        /// obtained from the targets window handle.
        /// </summary>
        /// <param name="exe">
        /// The target application.
        /// </param>
        /// <param name="filename">
        /// The text file to be opened in the target application
        /// </param>
        /// <returns>
        /// An AutomationElement representing the target application.
        /// </returns>
        /// -------------------------------------------------------------------
        private AutomationElement StartTarget(string exe, string filename)
        {
            // Start text editor and load with a text file.
            Process p = Process.Start(exe, filename);

            // targetApp --> the root AutomationElement
            AutomationElement targetApp =
                AutomationElement.FromHandle(p.MainWindowHandle);

            return targetApp;
        }
        // </SnippetStartTarget>

        // <SnippetGetTableElement>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Obtain the table control of interest from the target application.
        /// </summary>
        /// <param name="targetApp">
        /// The target application.
        /// </param>
        /// <returns>
        /// An AutomationElement representing a table control.
        /// </returns>
        /// -------------------------------------------------------------------
        private AutomationElement GetTableElement(AutomationElement targetApp)
        {
            // The control type we're looking for; in this case 'Document'
            PropertyCondition cond1 =
                new PropertyCondition(
                AutomationElement.ControlTypeProperty,
                ControlType.Table);

            // The control pattern of interest; in this case 'TextPattern'.
            PropertyCondition cond2 =
                new PropertyCondition(
                AutomationElement.IsTablePatternAvailableProperty,
                true);

            AndCondition tableCondition = new AndCondition(cond1, cond2);

            AutomationElement targetTableElement =
                targetApp.FindFirst(TreeScope.Descendants, tableCondition);

            // If targetTableElement is null then a suitable table control
            // was not found.
            return targetTableElement;
        }
        // </SnippetGetTableElement>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a TableItemPattern control pattern from an
        /// AutomationElement.
        /// </summary>
        /// <param name="targetControl">
        /// The AutomationElement of interest.
        /// </param>
        /// <returns>
        /// A TableItemPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private TableItemPattern GetTableItemPattern(
            AutomationElement targetControl)
        {
            TableItemPattern tableItemPattern = null;

            try
            {
                tableItemPattern =
                    targetControl.GetCurrentPattern(
                    TableItemPattern.Pattern)
                    as TableItemPattern;
            }
            // Object doesn't support the
            // TableItemPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return tableItemPattern;
        }
        // </Snippet101>

        // <Snippet1015>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a TablePattern control pattern from an
        /// AutomationElement.
        /// </summary>
        /// <param name="targetControl">
        /// The AutomationElement of interest.
        /// </param>
        /// <returns>
        /// A TablePattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private TablePattern GetTablePattern(
            AutomationElement targetControl)
        {
            TablePattern tablePattern = null;

            try
            {
                tablePattern =
                    targetControl.GetCurrentPattern(
                    TablePattern.Pattern)
                    as TablePattern;
            }
            // Object doesn't support the
            // TablePattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return tablePattern;
        }
        // </Snippet1015>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Set up table item event listeners.
        /// </summary>
        /// <remarks>
        /// The event listener is essentially a focus change listener.
        /// Since this is a global desktop listener, a filter would be required
        /// to ignore focus change events outside the table.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void SetTableItemEventListeners()
        {
            AutomationFocusChangedEventHandler tableItemFocusChangedListener =
                new AutomationFocusChangedEventHandler(OnTableItemFocusChange);
            Automation.AddAutomationFocusChangedEventHandler(
                tableItemFocusChangedListener);
        }
        // </Snippet102>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Event handler for table item focus change.
        /// Can be used to track traversal of individual table items
        /// within a table.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void OnTableItemFocusChange(
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

            // Get a TableItemPattern from the source of the event.
            TableItemPattern tableItemPattern =
                GetTableItemPattern(sourceElement);

            if (tableItemPattern == null)
            {
                return;
            }

            // Get a TablePattern from the container of the current element.
            TablePattern tablePattern =
                GetTablePattern(tableItemPattern.Current.ContainingGrid);

            if (tablePattern == null)
            {
                return;
            }

            AutomationElement tableItem = null;
            try
            {
                tableItem = tablePattern.GetItem(
                tableItemPattern.Current.Row,
                tableItemPattern.Current.Column);
            }
            catch (ArgumentOutOfRangeException)
            {
                // If the requested row coordinate is larger than the RowCount
                // or the column coordinate is larger than the ColumnCount.
                // -- OR --
                // If either of the requested row or column coordinates
                // is less than zero.
                // TO DO: error handling.
            }

            // Further event processing can be done at this point.
            // For the purposes of this sample we can just record item properties.
            string controlType =
                tableItem.Current.ControlType.LocalizedControlType;
            AutomationElement[] columnHeaders =
                tableItemPattern.Current.GetColumnHeaderItems();
            AutomationElement[] rowHeaders =
                tableItemPattern.Current.GetRowHeaderItems();
            int itemRow = tableItemPattern.Current.Row;
            int itemColumn = tableItemPattern.Current.Column;
            int itemRowSpan = tableItemPattern.Current.RowSpan;
            int itemColumnSpan = tableItemPattern.Current.ColumnSpan;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the application shutdown.
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
        /// <param name="tableItemPattern">
        /// A TableItemPattern control pattern obtained from
        /// an AutomationElement representing a target control.
        /// </param>
        /// <param name="automationProperty">
        /// The automation property of interest.
        /// </param>
        /// <returns>
        /// An object representing the requested integer property value.
        /// </returns>
        ///--------------------------------------------------------------------
        private object GetTableItemProperties(
            TableItemPattern tableItemPattern,
            AutomationProperty automationProperty)
        {
            if (automationProperty.Id ==
                TableItemPattern.ColumnProperty.Id)
            {
                return tableItemPattern.Current.Column;
            }
            if (automationProperty.Id ==
                TableItemPattern.RowProperty.Id)
            {
                return tableItemPattern.Current.Row;
            }
            if (automationProperty.Id ==
                TableItemPattern.ColumnSpanProperty.Id)
            {
                return tableItemPattern.Current.ColumnSpan;
            }
            if (automationProperty.Id ==
                TableItemPattern.RowSpanProperty.Id)
            {
                return tableItemPattern.Current.RowSpan;
            }

            return null;
        }
        // </Snippet104>

        // <Snippet105>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains an array of primary table headers.
        /// </summary>
        /// <param name="targetControl">
        /// The target control of interest.
        /// </param>
        /// <param name="roworcolumnMajor">
        /// The RowOrColumnMajor specifier.
        /// </param>
        /// <returns>
        /// An AutomationElement array object.
        /// </returns>
        ///--------------------------------------------------------------------
        private Object GetPrimaryHeaders(
            AutomationElement targetControl, RowOrColumnMajor roworcolumnMajor)
        {
            if (targetControl == null)
            {
                throw new ArgumentException("Target element cannot be null.");
            }

            try
            {
                if (roworcolumnMajor ==
                    RowOrColumnMajor.RowMajor)
                {
                    return targetControl.GetCurrentPropertyValue(
                        TableItemPattern.RowHeaderItemsProperty);
                }

                if (roworcolumnMajor ==
                    RowOrColumnMajor.ColumnMajor)
                {
                    return targetControl.GetCurrentPropertyValue(
                        TableItemPattern.ColumnHeaderItemsProperty);
                }
            }
            catch (InvalidOperationException)
            {
                // TableItemPattern not supported.
                // TO DO: error processing.
            }

            return null;
        }
        // </Snippet105>
    }
}
