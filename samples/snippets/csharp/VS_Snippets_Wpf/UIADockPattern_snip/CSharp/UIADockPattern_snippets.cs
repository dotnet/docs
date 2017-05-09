using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIADockPattern_snip
{
    class UIADockPattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIADockPattern_snippets()
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

            PropertyCondition conditionSupportsDock =
                new PropertyCondition(
                AutomationElement.IsDockPatternAvailableProperty, true);

            return targetApp.FindAll(
                TreeScope.Descendants, conditionSupportsDock);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a DockPattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A DockPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private DockPattern GetDockPattern(
            AutomationElement targetControl)
        {
            DockPattern dockPattern = null;

            try
            {
                dockPattern =
                    targetControl.GetCurrentPattern(
                    DockPattern.Pattern)
                    as DockPattern;
            }
            // Object doesn't support the DockPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return dockPattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current DockPosition of a target.
        /// </summary>
        /// <param name="dockControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// The current dock position.
        /// </returns>
        ///--------------------------------------------------------------------
        private DockPosition GetCurrentDockPosition(
            AutomationElement dockControl)
        {
            if (dockControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement parameter must not be null.");
            }

            return (DockPosition)dockControl.GetCurrentPropertyValue(
                DockPattern.DockPositionProperty);
        }
        // </Snippet102>

        // <Snippet1025>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the current view identifier from a target.
        /// </summary>
        /// <param name="dockPattern">
        /// The control pattern of interest.
        /// </param>
        /// <returns>
        /// The current dock position.
        /// </returns>
        ///--------------------------------------------------------------------
        private DockPosition GetCurrentDockPosition(
            DockPattern dockPattern)
        {
            if (dockPattern == null)
            {
                throw new ArgumentNullException(
                    "DockPattern parameter must not be null.");
            }

            return dockPattern.Current.DockPosition;
        }
        // </Snippet1025>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Sets the dock position of a target.
        /// </summary>
        /// <param name="dockControl">
        /// The automation element of interest.
        /// </param>
        /// <param name="dockPosition">
        /// The requested DockPosition.
        /// </param>
        ///--------------------------------------------------------------------
        private void SetDockPositionOfControl(
            AutomationElement dockControl, DockPosition dockPosition)
        {
            if (dockControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement parameter must not be null.");
            }

            try
            {
                DockPattern dockPattern = GetDockPattern(dockControl);
                if (dockPattern == null)
                {
                    return;
                }
                dockPattern.SetDockPosition(dockPosition);
            }
            catch (InvalidOperationException)
            {
                // When a control is not able to dock.
                // TO DO: error handling
            }
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
                UIADockPattern_snippets app = new UIADockPattern_snippets();
            }
        }
    }
}
