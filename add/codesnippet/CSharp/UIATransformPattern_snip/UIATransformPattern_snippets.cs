using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIATransformPattern_snip
{
    class UIATransformPattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public UIATransformPattern_snippets()
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

            PropertyCondition conditionCanMove =
                new PropertyCondition(TransformPattern.CanMoveProperty, false);

            PropertyCondition conditionCanResize =
                new PropertyCondition(TransformPattern.CanResizeProperty, true);

            PropertyCondition conditionCanRotate =
                new PropertyCondition(TransformPattern.CanRotateProperty, true);

            // Use any combination of the preceding condtions to 
            // find the control(s) of interest
            Condition condition = new AndCondition(
                conditionCanRotate,
                conditionCanMove,
                conditionCanResize);

            return rootElement.FindAll(TreeScope.Descendants, condition);
        }
        // </Snippet100>

        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a TransformPattern control pattern from 
        /// an automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A TransformPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private TransformPattern GetTransformPattern(
            AutomationElement targetControl)
        {
            TransformPattern transformPattern = null;

            try
            {
                transformPattern =
                    targetControl.GetCurrentPattern(TransformPattern.Pattern)
                    as TransformPattern;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the TransformPattern control pattern
                return null;
            }

            return transformPattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Calls the TransformPattern.Rotate() method for an associated 
        /// automation element.
        /// </summary>
        /// <param name="transformPattern">
        /// The TransformPattern control pattern obtained from
        /// an automation element.
        /// </param>
        /// <param name="degrees">
        /// The amount of degrees to rotate the automation element.
        /// </param>
        ///--------------------------------------------------------------------
        private void RotateElement(
            TransformPattern transformPattern, double degrees)
        {
            try
            {
                if (transformPattern.Current.CanRotate)
                {
                    transformPattern.Rotate(degrees);
                }
            }
            catch (InvalidOperationException)
            {
                // object is not able to perform the requested action
                return;
            }
        }
        // </Snippet102>

        // <Snippet103>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Calls the TransformPattern.Move() method for an associated 
        /// automation element.
        /// </summary>
        /// <param name="transformPattern">
        /// The TransformPattern control pattern obtained from
        /// an automation element.
        /// </param>
        /// <param name="x">
        /// The number of screen pixels to move the automation element 
        /// horizontally.
        /// </param>
        /// <param name="y">
        /// The number of screen pixels to move the automation element 
        /// vertically.
        /// </param>
        ///--------------------------------------------------------------------
        private void MoveElement(
            TransformPattern transformPattern, double x, double y)
        {
            try
            {
                if (transformPattern.Current.CanMove)
                {
                    transformPattern.Move(x, y);
                }
            }
            catch (InvalidOperationException)
            {
                // object is not able to perform the requested action
                return;
            }
        }
        // </Snippet103>

        // <Snippet104>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Calls the TransformPattern.Resize() method for an associated 
        /// automation element.
        /// </summary>
        /// <param name="transformPattern">
        /// The TransformPattern control pattern obtained from
        /// an automation element.
        /// </param>
        /// <param name="width">
        /// The requested width of the automation element.
        /// </param>
        /// <param name="height">
        /// The requested height of the automation element.
        /// </param>
        ///--------------------------------------------------------------------
        private void ResizeElement(
            TransformPattern transformPattern, double width, double height)
        {
            try
            {
                if (transformPattern.Current.CanResize)
                {
                    transformPattern.Resize(width, height);
                }
            }
            catch (InvalidOperationException)
            {
                // object is not able to perform the requested action
                return;
            }
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
                UIATransformPattern_snippets app = new UIATransformPattern_snippets();
            }
        }
    }
}
