using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAScrollPattern_snip
{
    class UIAScrollPattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public UIAScrollPattern_snippets()
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

            PropertyCondition conditionSupportsScroll =
                new PropertyCondition(
                AutomationElement.IsScrollPatternAvailableProperty, true);
            
            PropertyCondition conditionHorizontallyScrollable =
                new PropertyCondition(
                ScrollPattern.HorizontallyScrollableProperty, true);

            PropertyCondition conditionVerticallyScrollable =
                new PropertyCondition(
                ScrollPattern.VerticallyScrollableProperty, true);

            // Use any combination of the preceding conditions to 
            // find the control(s) of interest
            Condition condition = new AndCondition(
                conditionSupportsScroll,
                conditionHorizontallyScrollable, 
                conditionVerticallyScrollable);

            return targetApp.FindAll(TreeScope.Descendants, condition); 
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a ScrollPattern control pattern from an 
        /// automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A ScrollPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private ScrollPattern GetScrollPattern(
            AutomationElement targetControl)
        {
            ScrollPattern scrollPattern = null;

            try
            {
                scrollPattern =
                    targetControl.GetCurrentPattern(
                    ScrollPattern.Pattern)
                    as ScrollPattern;
            }
            // Object doesn't support the ScrollPattern control pattern
            catch (InvalidOperationException)
            {
                return null;
            }

            return scrollPattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a ScrollPattern control pattern from an automation 
        /// element and attempts to scroll to the 'home' position.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private void ScrollHome(AutomationElement targetControl)
        {
            if (targetControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement argument cannot be null.");
            }

            ScrollPattern scrollPattern = GetScrollPattern(targetControl);

            if (scrollPattern == null)
            {
                return;
            }

            try
            {
                scrollPattern.SetScrollPercent(0, 0);
            }
            catch (InvalidOperationException)
            {
                // Control not able to scroll in the direction requested;
                // when scrollable property of that direction is False
                // TO DO: error handling.
            }
            catch (ArgumentOutOfRangeException)
            {
                // A value greater than 100 or less than 0 is passed in 
                // (except -1 which is equivalent to NoScroll).
                // TO DO: error handling.
            }
        }
        // </Snippet102>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a ScrollPattern control pattern from an automation 
        /// element and attempts to scroll to the top of the
        /// viewfinder.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private void ScrollToTop(AutomationElement targetControl)
        {
            if (targetControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement argument cannot be null.");
            }

            ScrollPattern scrollPattern = GetScrollPattern(targetControl);

            try
            {
                scrollPattern.SetScrollPercent(ScrollPattern.NoScroll, 0);
            }
            catch (InvalidOperationException)
            {
                // Control not able to scroll in the direction requested;
                // when scrollable property of that direction is False
                // TO DO: error handling.
            }
            catch (ArgumentOutOfRangeException)
            {
                // A value greater than 100 or less than 0 is passed in 
                // (except -1 which is equivalent to NoScroll).
                // TO DO: error handling.
            }
        }
        // </Snippet103>

        // <Snippet104>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains the current scroll positions of the viewable region 
        /// within the content area.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// The horizontal and vertical scroll percentages.
        /// </returns>
        ///--------------------------------------------------------------------
        private double[] GetScrollPercentages(AutomationElement targetControl)
        {
            if (targetControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement argument cannot be null.");
            }

            double[] percentage = new double[2];

            percentage[0] =
                (double)targetControl.GetCurrentPropertyValue(
                ScrollPattern.HorizontalScrollPercentProperty);

            percentage[1] =
                 (double)targetControl.GetCurrentPropertyValue(
                 ScrollPattern.VerticalScrollPercentProperty);

            return percentage;
        }
        // </Snippet104>

        // <Snippet1045>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains the current scroll positions of the viewable region 
        /// within the content area.
        /// </summary>
        /// <param name="scrollPattern">
        /// The ScrollPattern control pattern obtained from the 
        /// element of interest.
        /// </param>
        /// <returns>
        /// The horizontal and vertical scroll percentages.
        /// </returns>
        ///--------------------------------------------------------------------
        private double[] GetScrollPercentagesFromPattern(
            ScrollPattern scrollPattern)
        {
            if (scrollPattern == null)
            {
                throw new ArgumentNullException(
                    "ScrollPattern argument cannot be null.");
            }

            double[] percentage = new double[2];

            percentage[0] =
                scrollPattern.Current.HorizontalScrollPercent;

            percentage[1] =
                 scrollPattern.Current.VerticalScrollPercent;

            return percentage;
        }
        // </Snippet1045>

        // <Snippet105>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains the current vertical and horizontal sizes of the viewable  
        /// region as percentages of the total content area.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// The horizontal and vertical view sizes.
        /// </returns>
        ///--------------------------------------------------------------------
        private double[] GetViewSizes(AutomationElement targetControl)
        {
            if (targetControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement argument cannot be null.");
            }

            double[] viewSizes = new double[2];

            viewSizes[0] =
                (double)targetControl.GetCurrentPropertyValue(
                ScrollPattern.HorizontalViewSizeProperty);

            viewSizes[1] =
                 (double)targetControl.GetCurrentPropertyValue(
                 ScrollPattern.VerticalViewSizeProperty);

            return viewSizes;
        }
        // </Snippet105>

        // <Snippet1055>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains the current vertical and horizontal sizes of the viewable  
        /// region as percentages of the total content area.
        /// </summary>
        /// <param name="scrollPattern">
        /// The ScrollPattern control pattern obtained from the 
        /// element of interest.
        /// </param>
        /// <returns>
        /// The horizontal and vertical view sizes.
        /// </returns>
        ///--------------------------------------------------------------------
        private double[] GetViewSizes(ScrollPattern scrollPattern)
        {
            if (scrollPattern == null)
            {
                throw new ArgumentNullException(
                    "ScrollPattern argument cannot be null.");
            }

            double[] viewSizes = new double[2];

            viewSizes[0] =
                scrollPattern.Current.HorizontalViewSize;

            viewSizes[1] =
                 scrollPattern.Current.VerticalViewSize;

            return viewSizes;
        }
        // </Snippet1055>

        // <Snippet106>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a ScrollPattern control pattern from an automation 
        /// element and attempts to scroll the requested amounts.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <param name="hScrollAmount">
        /// The requested horizontal scroll amount.
        /// </param>
        /// <param name="vScrollAmount">
        /// The requested vertical scroll amount.
        /// </param>
        ///--------------------------------------------------------------------
        private void ScrollElement(
            AutomationElement targetControl,
            ScrollAmount hScrollAmount,
            ScrollAmount vScrollAmount)
        {
            if (targetControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement argument cannot be null.");
            }

            ScrollPattern scrollPattern = GetScrollPattern(targetControl);

            if (scrollPattern == null)
            {
                return;
            }

            try
            {
                scrollPattern.Scroll(hScrollAmount, vScrollAmount);
            }
            catch (InvalidOperationException)
            {
                // Control not able to scroll in the direction requested;
                // when scrollable property of that direction is False
                // TO DO: error handling.
            }
            catch (ArgumentException)
            {
                // If a control supports SmallIncrement values exclusively 
                // for horizontal or vertical scrolling but a LargeIncrement 
                // value (NaN if not supported) is passed in.
                // TO DO: error handling.
            }
        }
        // </Snippet106>

        // <Snippet107>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a ScrollPattern control pattern from an automation 
        /// element and attempts to horizontally scroll the requested amount.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <param name="hScrollAmount">
        /// The requested horizontal scroll amount.
        /// </param>
        ///--------------------------------------------------------------------
        private void ScrollElementHorizontally(
            AutomationElement targetControl,
            ScrollAmount hScrollAmount)
        {
            if (targetControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement argument cannot be null.");
            }

            ScrollPattern scrollPattern = GetScrollPattern(targetControl);

            if (scrollPattern == null)
            {
                return;
            }

            if (!scrollPattern.Current.HorizontallyScrollable)
            {
                return;
            }

            try
            {
                scrollPattern.ScrollHorizontal(hScrollAmount);
            }
            catch (InvalidOperationException)
            {
                // Control not able to scroll in the direction requested;
                // when scrollable property of that direction is False
                // TO DO: error handling.
            }
            catch (ArgumentException)
            {
                // If a control supports SmallIncrement values exclusively 
                // for horizontal or vertical scrolling but a LargeIncrement 
                // value (NaN if not supported) is passed in.
                // TO DO: error handling.
            }
        }
        // </Snippet107>

        // <Snippet108>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a ScrollPattern control pattern from an automation 
        /// element and attempts to horizontally scroll the requested amount.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <param name="vScrollAmount">
        /// The requested vertical scroll amount.
        /// </param>
        ///--------------------------------------------------------------------
        private void ScrollElementVertically(
            AutomationElement targetControl,
            ScrollAmount vScrollAmount)
        {
            if (targetControl == null)
            {
                throw new ArgumentNullException(
                    "AutomationElement argument cannot be null.");
            }

            ScrollPattern scrollPattern = GetScrollPattern(targetControl);

            if (scrollPattern == null)
            {
                return;
            }
            
            if (!scrollPattern.Current.VerticallyScrollable)
            {
                return;
            }

            try
            {
                scrollPattern.ScrollVertical(vScrollAmount);
            }
            catch (InvalidOperationException)
            {
                // Control not able to scroll in the direction requested;
                // when scrollable property of that direction is False
                // TO DO: error handling.
            }
            catch (ArgumentException)
            {
                // If a control supports SmallIncrement values exclusively 
                // for horizontal or vertical scrolling but a LargeIncrement 
                // value (NaN if not supported) is passed in.
                // TO DO: error handling.
            }
        }
        // </Snippet108>

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
                UIAScrollPattern_snippets app = new UIAScrollPattern_snippets();
            }
        }
    }
}
