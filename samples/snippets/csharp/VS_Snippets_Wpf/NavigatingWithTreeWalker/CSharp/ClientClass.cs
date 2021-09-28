/*************************************************************************************************\
*
* File: ClientClass.cs
*
* Description:
*   This sample client locates the element representing the main window of the
*   TreeWalkerTarget sample application. It then locates the element representing
*   the tab control in the automation element tree. The sample subscribes to the
*   automation StructureChanged event on the tab control element.
*
*   To run the sample within Visual Studio, first open the solution properties and
*   set both the target and the client applications to run as multiple startup
*   projects.
*
*   When the user clicks a tab on the control, a StructureChanged event is raised and the
*   current stucture of the subtree is displayed in the client window.
*
*   The sample also demonstrates two-way communication between the target application and the client.
*   When the user toggles automation on or off in the client application, a message is displayed
*   in a text box in the target application's window.
*
* Programming Elements:
*    This sample demonstrates the following UI Automation programming elements from the
*     System.Windows.Automation namespace:
*
*       AutomationElement class
*           RootElement property
*           AutomationId property
*           Name property
*           GetCurrentPatterns() method
*           GetCurrentPropertyValue() method
*           BoundingRectangleProperty property
*           Condition property
*           AndCondition() method
*       TreeWalker class
*           ControlViewWalker.GetFirstChild()
*           ControlViewWalker.GetNextSibling()
*       AutomationProperty class
*           ToString() method
*
* Copyright (C) 2005 by Microsoft Corporation.  All rights reserved.
*
\*************************************************************************************************/
using System;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;

namespace NavigateWithTreeWalker
{
    class myAutomationClass
    {
        // The automation element representing the tab control container.
        private AutomationElement tabElement;

        // The automation element representing the "is listening" label.
        private AutomationElement listenElement;

        // The indentation level.
        private int treeDepth;

        // The user's selection for showing supported patterns.
        private bool showPatterns = false;

        // Global variable that gives this class access to the client's controls.
        // This is assigned when the main form has been initialized.
        public NavigationWithTreeWalker mainForm = null;

        // Constructor
        public myAutomationClass()
        {
        }

        /// <summary>
        /// Displays the tree structure in the client.
        /// </summary>
        /// <param name="structureStr">The string to display.</param>
        private void ShowStructure(string structureStr)
        {
            mainForm.tbStructure.Text = structureStr;
        }

        /// <summary>
        /// Retrieves a list of all the patterns supported by the control.
        /// </summary>
        /// <param name="ae">The automation element for the control.</param>
        /// <param name="structureStringBuilder">The StringBuilder that gets the string. </param>
        private void GetSupportedPatterns(AutomationElement element, StringBuilder structureStringBuilder)
        {
            StringBuilder padding = new StringBuilder();
            padding.Insert(0, " ", treeDepth * 8);

            // GetSupportedPatterns() is typically used only in debugging situations.
            // It is more efficient to call GetCurrentPattern() for just those patterns
            // you want to retrieve.
            AutomationPattern[] supportedPatterns =  element.GetSupportedPatterns();
            structureStringBuilder.Append(padding + "Supported Patterns\r\n");
            foreach (AutomationPattern pattern in supportedPatterns)
            {
                structureStringBuilder.Append(padding + "      " + pattern.ProgrammaticName + "\r\n");
            }
            structureStringBuilder.Append("\r\n");
        }

        /// <summary>
        /// Retrieves a non-empty string to identify this automation element.
        /// The AutomationId is the preferred identifier.
        /// </summary>
        /// <param name="ae">The automation element for the control.</param>
        /// <param name="structureStringBuilder">The StringBuilder that gets the string. </param>
        private void GetAnIdentifier(AutomationElement element,  ref StringBuilder structureStringBuilder)
        {
            StringBuilder padding = new StringBuilder();
            padding.Insert(0, " ", treeDepth * 8);
            structureStringBuilder.Append(padding);

            // Get an identifier for the element.
            // You can use either GetCurrentPropertyValue or an accessor on the Current property
            // to get the values of properties.
            if ((string)element.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty) != "")
            {
                structureStringBuilder.Append("Automation Identifier : " +
                    element.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty) + "\r\n");
            }
            else if ((string)element.GetCurrentPropertyValue(AutomationElement.NameProperty) != "")
            {
                structureStringBuilder.Append("Name : "
                    + element.GetCurrentPropertyValue(AutomationElement.NameProperty) + "\r\n");
            }
            else if ((string)element.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty) != "")
            {
                structureStringBuilder.Append("Localized Control Type : "
                    + element.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty) + "\r\n");
            }
            else
            {
                structureStringBuilder.Append("No Identifier found\r\n");
            }
        }

        /// <summary>
        /// Gets a string for the element identifier and, optionally, the patterns it supports.
        /// </summary>
        /// <param name="ae">The automation element for the control.</param>
        /// <param name="structureStringBuilder">The StringBuilder that gets the string. </param>
        private void ProcessElement(AutomationElement element, ref StringBuilder structureStringBuilder)
        {
            GetAnIdentifier(element, ref structureStringBuilder);
            // If we are showing the supported patterns, get them and
            // add them to the string.
            if (showPatterns)
            {
                GetSupportedPatterns(element, structureStringBuilder);
            }
        }

        /// <summary>
        /// Gets the child element of the automation element passed into the
        /// method. It returns a string containing the list of children.
        /// The method is called recursively if the element in the sibling list
        /// has child elements of its own.
        /// </summary>
        /// <param name="ae">The automation element for the control.</param>
        /// <param name="structureStringBuilder">The StringBuilder that gets the string.</param>
        private void ProcessTree(AutomationElement element, ref StringBuilder structureStringBuilder)
        {
            ProcessElement(element, ref structureStringBuilder);
            treeDepth++;
            AutomationElement child = TreeWalker.ControlViewWalker.GetFirstChild(element);
            while (child != null)
            {
                ProcessTree(child, ref structureStringBuilder);
                child = TreeWalker.ControlViewWalker.GetNextSibling(child);
            }
            treeDepth--;
        }

        /// <summary>
        /// Initiates the building of the string that describes the automation structure
        /// under the specified element. Calls ProcessTree, which is recursive, to build
        /// the string.
        /// </summary>
        /// <param name="ae">The root automation element.</param>
        /// <returns>Description of the structure.</returns>
        private string GetAutomationStructure(AutomationElement element)
        {
            StringBuilder structureStringBuilder = new StringBuilder("");
            if (element != null)
            {
                treeDepth = 0;
                ProcessTree(element, ref structureStringBuilder);
            }
            return structureStringBuilder.ToString();
        }

        //<Snippet1200>
        /// <summary>
        /// Gets the toggle state of an element in the target application.
        /// </summary>
        /// <param name="element">The target element.</param>
        private bool IsElementToggledOn(AutomationElement element)
        {
            if (element == null)
            {
                // TODO: Invalid parameter error handling.
                return false;
            }

            Object objPattern;
            TogglePattern togPattern;
            if (true == element.TryGetCurrentPattern(TogglePattern.Pattern, out objPattern))
            {
                togPattern = objPattern as TogglePattern;
                return togPattern.Current.ToggleState == ToggleState.On;
            }
            // TODO: Object doesn't support TogglePattern error handling.
            return false;
        }
        //</Snippet1200>

        /// <summary>
        /// Handles the StructureChanged event. Each time the automation element
        /// tree under the tab control changes, this event is raised.
        /// StructureChangedEventArgs can provide more information as to what kind of change happened.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void onStructureChanged(object sender, StructureChangedEventArgs e)
        {
            if (sender != null)
            {
                string newStructure = GetAutomationStructure((AutomationElement)sender);
                if (newStructure != "")
                {
                    ShowStructure(((AutomationElement)sender).Current.Name +
                        " indicated that the tree has changed. The new structure is: \r\n\r\n" + newStructure);
                }
            }
        }

        /// <summary>
        /// Handles the ToggleStateChanged event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnToggleStateChanged(object sender, AutomationPropertyChangedEventArgs e)
        {
            IsElementToggledOn((AutomationElement)sender);
            string StructureDescription = GetAutomationStructure(tabElement);
            ShowStructure(StructureDescription);
        }

        /// <summary>
        /// Locates an element by its automation identifier.
        /// </summary>
        /// <param name="el">The root automation element.</param>
        /// <param name="aID">The identifier.</param>
        /// <returns>The element identified by aID.</returns>
        private AutomationElement FindByAutomationId(AutomationElement el, string automationId)
        {
            Condition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            return el.FindFirst(TreeScope.Element | TreeScope.Descendants, condition);
        }

        /// <summary>
        /// Display a message in the target application.
        /// </summary>
        /// <param name="check">true to select the checkbox; otherwise, false.</param>
        private void InformTarget(bool check)
        {
            if (listenElement == null) return;

            ValuePattern listenValuePattern = (ValuePattern)listenElement.GetCurrentPattern(ValuePattern.Pattern);
            if (listenValuePattern != null)
            {
                if (check == true)
                {
                    listenValuePattern.SetValue("UIAutomation is listening.");
                }
                else
                {
                    listenValuePattern.SetValue("UIAutomation is not listening.");
                }
            }
        }

        /// <summary>
        /// Removes the event handlers.
        /// </summary>
        public void StopListening()
        {
            try
            {
                Automation.RemoveAllEventHandlers();
                ShowStructure("Event handlers removed.");
                // Uncheck the "UIAutomation is listening" checkbox in the target application.
                InformTarget(false);
            }
            catch (ElementNotAvailableException)
            {
                return;
            }
        }

        /// <summary>
        /// Initializes UI automation by finding the target form, adding event handlers,
        /// and displaying the current automation element structure.
        /// </summary>
        /// <returns>true on success; otherwise, false.</returns>
        public bool StartListening()
        {
            bool returnCode = false;
            AutomationElement rootElement = AutomationElement.RootElement;

            // Set a property condition that will be used to find the main form of the
            // target application. myTestForm is the name of the Form and in the case
            // of a WinForms control, it is also the AutomationId of the element representing the control.
            Condition cond = new PropertyCondition(AutomationElement.AutomationIdProperty, "myTestForm");

            // Find the main window of the target application.
            AutomationElement mainWindowElement = rootElement.FindFirst(TreeScope.Element | TreeScope.Children, cond);
            if (mainWindowElement == null)
            {
                MessageBox.Show("Could not find the main form for the target application.");
                returnCode = false;
            }
            else
            {
                // Find the "Show supported patterns" checkbox and add an event handler for when
                // the toggle state changes.
                AutomationElement elementCheckBox = FindByAutomationId(mainWindowElement, "chkbxShowPatterns");
                AutomationProperty[] propsWanted = { TogglePattern.ToggleStateProperty };

                if (elementCheckBox != null)
                {
                    if ((bool)elementCheckBox.GetCurrentPropertyValue(AutomationElement.IsTogglePatternAvailableProperty) == true)
                    {
                        IsElementToggledOn(elementCheckBox);
                        AutomationPropertyChangedEventHandler _onToggleStateChanged =
                            new AutomationPropertyChangedEventHandler(OnToggleStateChanged);
                        Automation.AddAutomationPropertyChangedEventHandler(elementCheckBox,
                            TreeScope.Element,
                            _onToggleStateChanged,
                            propsWanted);
                    }
                }
                // Find the "UIAutomation is listening" textbox.
                 listenElement = FindByAutomationId(mainWindowElement, "tbListen");

                // Find the tab control and add an event handler for when the automation tree structure changes.
                // This event will be raised whenever the user selects a tab.
                tabElement = FindByAutomationId(mainWindowElement, "tabControl1");
                if (tabElement != null)
                {
                    StructureChangedEventHandler _onStructureChanged = new StructureChangedEventHandler(onStructureChanged);
                    Automation.AddStructureChangedEventHandler(tabElement, TreeScope.Descendants, _onStructureChanged);
                }
                string StructureDescription = GetAutomationStructure(tabElement);
                ShowStructure(StructureDescription);
                // Check the "UIAutomation is listening" checkbox in the target application.
                InformTarget(true);

                returnCode = true;
            }
            return returnCode;
        }
    }
}
