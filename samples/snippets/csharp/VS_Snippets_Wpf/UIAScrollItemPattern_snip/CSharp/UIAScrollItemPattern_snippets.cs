using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.Windows.Controls;

namespace UIAScrollItemPattern_snip
{
    class UIAScrollItemPattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIAScrollItemPattern_snippets()
        {
            ;
        }

        // <Snippet100>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a ScrollItemPattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A ScrollItemPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private ScrollItemPattern GetScrollItemPattern(
            AutomationElement targetControl)
        {
            ScrollItemPattern scrollItemPattern = null;

            try
            {
                scrollItemPattern =
                    targetControl.GetCurrentPattern(
                    ScrollItemPattern.Pattern)
                    as ScrollItemPattern;
            }
            // Object doesn't support the ScrollItemPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return scrollItemPattern;
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// A Select, AddToSelection or RemoveFromSelection event handler that 
        /// scrolls a SelectionItem object into the viewable region of its 
        /// container control.
        /// </summary>
        ///--------------------------------------------------------------------
        private void OnSelectionItemSelect(
            object src, SelectionChangedEventArgs e)
        {
            AutomationElement selectionItem = src as AutomationElement;

            ScrollItemPattern scrollItemPattern = GetScrollItemPattern(selectionItem);

            if (scrollItemPattern == null)
            {
                return;
            }

            try
            {
                scrollItemPattern.ScrollIntoView();
            }
            catch (InvalidOperationException)
            {
                // The item cannot be scrolled into view.
                // TO DO: error handling.
            }
        }
        // </Snippet101>

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
                UIAScrollItemPattern_snippets app = new UIAScrollItemPattern_snippets();
            }
        }
    }
}
