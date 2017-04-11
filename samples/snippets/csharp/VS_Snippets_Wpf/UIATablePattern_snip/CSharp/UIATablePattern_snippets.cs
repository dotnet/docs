using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Diagnostics;

namespace UIATablePattern_snip
{
    class UIATablePattern_snippets : System.Windows.Application
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIATablePattern_snippets()
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
                UIATablePattern_snippets app = new UIATablePattern_snippets();

                app.Run();
            }
        }

        // <SnippetStartTarget>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Starts the target application and returns the automation element 
        /// obtained from the targets window handle.
        /// </summary>
        /// <param name="exe">
        /// The target application.
        /// </param>
        /// <param name="filename">
        /// The text file to be opened in the target application
        /// </param>
        /// <returns>
        /// An automation element representing the target application.
        /// </returns>
        /// -------------------------------------------------------------------
        private AutomationElement StartTarget(string exe, string filename)
        {
            // Start text editor and load with a text file.
            Process p = Process.Start(exe, filename);

            // targetApp --> the root automation element
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
        /// An automation element representing a table control.
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

            PropertyCondition conditionSupportsTablePattern =
                new PropertyCondition(
                AutomationElement.IsTablePatternAvailableProperty, true);

            PropertyCondition conditionIndeterminateTraversal =
                new PropertyCondition(
                TablePattern.RowOrColumnMajorProperty,
                RowOrColumnMajor.Indeterminate);

            PropertyCondition conditionRowColumnTraversal =
                new PropertyCondition(
                TablePattern.RowOrColumnMajorProperty,
                RowOrColumnMajor.ColumnMajor);

            AndCondition conditionTable =
                new AndCondition(
                conditionSupportsTablePattern,
                new OrCondition(
                conditionIndeterminateTraversal,
                conditionRowColumnTraversal));

            return targetApp.FindAll(
                TreeScope.Descendants, conditionTable);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a TablePattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
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
            // GridPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return tablePattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a table items primary row or column header.
        /// </summary>
        /// <param name="tableItem">
        /// The table item of interest.
        /// </param>
        /// <returns>
        /// The table item header.
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElement GetTableItemHeader(TableItemPattern tableItem)
        {
            if (tableItem == null)
            {
                throw new ArgumentException("Target element cannot be null.");
            }

            TablePattern tablePattern = GetTablePattern(tableItem.Current.ContainingGrid);

            if (tablePattern == null)
            {
                return null;
            }

            AutomationElement[] tableHeaders = 
                GetPrimaryHeaders(tablePattern);

            if (tableHeaders == null)
            {
                // Indeterminate headers.
                return null;
            }

            if (tablePattern.Current.RowOrColumnMajor == RowOrColumnMajor.ColumnMajor)
            {
                return tableHeaders[tableItem.Current.Column];
            }

            if (tablePattern.Current.RowOrColumnMajor == RowOrColumnMajor.RowMajor)
            {
                return tableHeaders[tableItem.Current.Row];
            }

            return null;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains an array of table headers.
        /// </summary>
        /// <param name="tablePattern">
        /// The TablePattern object of interest.
        /// </param>
        /// <returns>
        /// The table row or column primary headers.
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElement[] GetPrimaryHeaders(
            TablePattern tablePattern)
        {
            if (tablePattern.Current.RowOrColumnMajor == 
                RowOrColumnMajor.RowMajor)
            {
                return tablePattern.Current.GetRowHeaders();
            }

            if (tablePattern.Current.RowOrColumnMajor == 
                RowOrColumnMajor.ColumnMajor)
            {
                return tablePattern.Current.GetColumnHeaders();
            }

            return null;
        }
        // </Snippet102>

        // <Snippet1025>
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
        /// An array of automation elements.
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElement[] GetPrimaryHeaders(
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
                        TablePattern.RowHeadersProperty) as AutomationElement[];
                }

                if (roworcolumnMajor ==
                    RowOrColumnMajor.ColumnMajor)
                {
                    return targetControl.GetCurrentPropertyValue(
                        TablePattern.ColumnHeadersProperty) as AutomationElement[];
                }
            }
            catch (InvalidOperationException)
            {
                // TablePattern not supported.
                // TO DO: error processing.
            }

            return null;
        }
        // </Snippet1025>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current property values from target.
        /// </summary>
        /// <param name="tablePattern">
        /// A TablePattern control pattern obtained from 
        /// an automation element representing a target control.
        /// </param>
        ///--------------------------------------------------------------------
        private void GetRowColumnCounts(TablePattern tablePattern)
        {
            if (tablePattern == null)
            {
                throw new ArgumentException("Target element cannot be null.");
            }

            Console.WriteLine(tablePattern.Current.RowCount.ToString());
            Console.WriteLine(tablePattern.Current.ColumnCount.ToString());
        }
        // </Snippet103>

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
    }
}
