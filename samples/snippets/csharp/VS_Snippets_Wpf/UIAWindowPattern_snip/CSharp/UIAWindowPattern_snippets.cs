using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace UIAWindowPattern_snip
{
    class UIAWindowPattern_snippets
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public UIAWindowPattern_snippets()
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

            PropertyCondition conditionCanMaximize = 
                new PropertyCondition(WindowPattern.CanMaximizeProperty, true);

            PropertyCondition conditionCanMinimize =
                new PropertyCondition(WindowPattern.CanMinimizeProperty, true);

            PropertyCondition conditionIsModal =
                new PropertyCondition(WindowPattern.IsModalProperty, false);

            PropertyCondition conditionIsTopmost =
                new PropertyCondition(WindowPattern.IsTopmostProperty, true);

            PropertyCondition conditionWindowInteractionState =
                new PropertyCondition(
                WindowPattern.WindowInteractionStateProperty, 
                WindowInteractionState.ReadyForUserInteraction);

            PropertyCondition conditionWindowVisualState =
                new PropertyCondition(
                WindowPattern.WindowVisualStateProperty, 
                WindowVisualState.Normal);

            // Use any combination of the preceding condtions to 
            // find the control(s) of interest
            Condition condition = new AndCondition(
                conditionCanMaximize, 
                conditionIsModal, 
                conditionWindowInteractionState);

            return rootElement.FindAll(TreeScope.Descendants, condition); 
        }
        // </Snippet100>
        
        // <Snippet101>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Obtains a WindowPattern control pattern from an automation element.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        /// <returns>
        /// A WindowPattern object.
        /// </returns>
        ///--------------------------------------------------------------------
        private WindowPattern GetWindowPattern(AutomationElement targetControl)
        {
            WindowPattern windowPattern = null;

            try
            {
                windowPattern =
                    targetControl.GetCurrentPattern(WindowPattern.Pattern)
                    as WindowPattern;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the WindowPattern control pattern
                return null;
            }
            // Make sure the element is usable.
            if (false == windowPattern.WaitForInputIdle(10000))
            {
                // Object not responding in a timely manner
                return null;
            }
            return windowPattern;
        }
        // </Snippet101>

        // <Snippet102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Calls the WindowPattern.Close() method for an associated 
        /// automation element.
        /// </summary>
        /// <param name="windowPattern">
        /// The WindowPattern control pattern obtained from
        /// an automation element.
        /// </param>
        ///--------------------------------------------------------------------
        private void CloseWindow(WindowPattern windowPattern)
        {
            try
            {
                windowPattern.Close();
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
        /// Calls the WindowPattern.SetVisualState() method for an associated 
        /// automation element.
        /// </summary>
        /// <param name="windowPattern">
        /// The WindowPattern control pattern obtained from
        /// an automation element.
        /// </param>
        /// <param name="visualState">
        /// The specified WindowVisualState enumeration value.
        /// </param>
        ///--------------------------------------------------------------------
        private void SetVisualState(WindowPattern windowPattern, 
            WindowVisualState visualState)
        {
            try
            {
                if (windowPattern.Current.WindowInteractionState ==
                    WindowInteractionState.ReadyForUserInteraction)
                {
                    switch (visualState)
                    {
                        case WindowVisualState.Maximized:
                            // Confirm that the element can be maximized
                            if ((windowPattern.Current.CanMaximize) && 
                                !(windowPattern.Current.IsModal))
                            {
                                windowPattern.SetWindowVisualState(
                                    WindowVisualState.Maximized);
                                // TODO: additional processing
                            }
                            break;
                        case WindowVisualState.Minimized:
                            // Confirm that the element can be minimized
                            if ((windowPattern.Current.CanMinimize) &&
                                !(windowPattern.Current.IsModal))
                            {
                                windowPattern.SetWindowVisualState(
                                    WindowVisualState.Minimized);
                                // TODO: additional processing
                            }
                            break;
                        case WindowVisualState.Normal:
                            windowPattern.SetWindowVisualState(
                                WindowVisualState.Normal);
                            break;
                        default:
                            windowPattern.SetWindowVisualState(
                                WindowVisualState.Normal);
                            // TODO: additional processing
                            break;
                    }
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
        /// Register for events of interest.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private void RegisterForAutomationEvents(
            AutomationElement targetControl)
        {
            AutomationEventHandler eventHandler = 
                new AutomationEventHandler(OnWindowOpenOrClose);
            Automation.AddAutomationEventHandler(
                WindowPattern.WindowClosedEvent, 
                targetControl, TreeScope.Element, eventHandler);
            Automation.AddAutomationEventHandler(
                WindowPattern.WindowOpenedEvent, 
                targetControl, TreeScope.Element, eventHandler);
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// AutomationEventHandler delegate.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void OnWindowOpenOrClose(object src, AutomationEventArgs e)
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
            
            if (e.EventId == WindowPattern.WindowOpenedEvent)
            {
                // TODO: event handling
                return;
            }
            if (e.EventId == WindowPattern.WindowClosedEvent)
            {
                // TODO: event handling
                return;
            }
        }
        // </Snippet104>

        // <Snippet105>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Register for automation property change events of interest.
        /// </summary>
        /// <param name="targetControl">
        /// The automation element of interest.
        /// </param>
        ///--------------------------------------------------------------------
        private void RegisterForPropertyChangedEvents(
            AutomationElement targetControl)
        {
            AutomationPropertyChangedEventHandler propertyChangeListener = 
                new AutomationPropertyChangedEventHandler(
                OnTopmostPropertyChange);
            Automation.AddAutomationPropertyChangedEventHandler(
                targetControl, 
                TreeScope.Element, 
                propertyChangeListener, 
                WindowPattern.IsTopmostProperty);
        }
        // </Snippet105>

        // <Snippet106>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Register for automation property change events of interest.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void OnTopmostPropertyChange(object src, AutomationPropertyChangedEventArgs e)
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
            
            // Get a WindowPattern from the source of the event.
            WindowPattern windowPattern = GetWindowPattern(sourceElement);
            if (windowPattern.Current.IsTopmost)
            {
                //TODO: event handling
            }
        }
        // </Snippet106>


    }
}
