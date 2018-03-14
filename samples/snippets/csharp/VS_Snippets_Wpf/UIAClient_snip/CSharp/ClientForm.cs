/*************************************************************************************************
 *
 * File: ClientForm.cs
 *
 * Description: Miscellaneous snippets illustrating client UIA functionality
 * 
 * 
 *************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Windows;
using System.Diagnostics;



namespace CustomElementClient
{
    public partial class Form1 : Form
    {
// <Snippet185> 
        public struct CursorPoint
        {
            public int X;
            public int Y;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool GetPhysicalCursorPos(ref CursorPoint lpPoint);

        private bool ShowUsage()
        {
            CursorPoint cursorPos = new CursorPoint();
            try
            {
                return GetPhysicalCursorPos(ref cursorPos);
            }
            catch (EntryPointNotFoundException) // Not Windows Vista
            {
                return false;
            }
        }
// </Snippet185>

        AutomationElement RootElement = null;
        AutomationElement MainWindowElement = null;
        AutomationElement ListElement = null;
        AutomationEventHandler OnEvent = null;


        /// <summary>
        /// Constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
// <Snippet181>
        private AutomationElement ElementFromCursor()
        {
            // Convert mouse position from System.Drawing.Point to System.Windows.Point.
            System.Windows.Point point = new System.Windows.Point(Cursor.Position.X, Cursor.Position.Y);
            AutomationElement element = AutomationElement.FromPoint(point);
            return element;
        }
// </Snippet181>

        // <Snippet171>
        /// <summary>
        /// Walks the UI Automation tree and adds the control type of each element it finds 
        /// in the control view to a TreeView.
        /// </summary>
        /// <param name="rootElement">The root of the search on this iteration.</param>
        /// <param name="treeNode">The node in the TreeView for this iteration.</param>
        /// <remarks>
        /// This is a recursive function that maps out the structure of the subtree beginning at the
        /// UI Automation element passed in as rootElement on the first call. This could be, for example,
        /// an application window.
        /// CAUTION: Do not pass in AutomationElement.RootElement. Attempting to map out the entire subtree of
        /// the desktop could take a very long time and even lead to a stack overflow.
        /// </remarks>
        private void WalkControlElements(AutomationElement rootElement, TreeNode treeNode)
        {
            // Conditions for the basic views of the subtree (content, control, and raw) 
            // are available as fields of TreeWalker, and one of these is used in the 
            // following code.
            AutomationElement elementNode = TreeWalker.ControlViewWalker.GetFirstChild(rootElement);

            while (elementNode != null)
            {
                TreeNode childTreeNode = treeNode.Nodes.Add(elementNode.Current.ControlType.LocalizedControlType);
                WalkControlElements(elementNode, childTreeNode);
                elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
            }
        }
        // </Snippet171>


// <Snippet174>
        /// <summary>
        /// Walks the UI Automation tree and adds the control type of each enabled control 
        /// element it finds to a TreeView.
        /// </summary>
        /// <param name="rootElement">The root of the search on this iteration.</param>
        /// <param name="treeNode">The node in the TreeView for this iteration.</param>
        /// <remarks>
        /// This is a recursive function that maps out the structure of the subtree beginning at the
        /// UI Automation element passed in as rootElement on the first call. This could be, for example,
        /// an application window.
        /// CAUTION: Do not pass in AutomationElement.RootElement. Attempting to map out the entire subtree of
        /// the desktop could take a very long time and even lead to a stack overflow.
        /// </remarks>
        private void WalkEnabledElements(AutomationElement rootElement, TreeNode treeNode)
        {
            Condition condition1 = new PropertyCondition(AutomationElement.IsControlElementProperty, true);
            Condition condition2 = new PropertyCondition(AutomationElement.IsEnabledProperty, true);
            TreeWalker walker = new TreeWalker(new AndCondition(condition1, condition2));
            AutomationElement elementNode = walker.GetFirstChild(rootElement);
            while (elementNode != null)
            {
                TreeNode childTreeNode = treeNode.Nodes.Add(elementNode.Current.ControlType.LocalizedControlType);
                WalkEnabledElements(elementNode, childTreeNode);
                elementNode = walker.GetNextSibling(elementNode);
            }
        }
// </Snippet174>


        // <Snippet110>
        /// <summary>
        /// Find a UI Automation child element by ID.
        /// </summary>
        /// <param name="controlName">Name of the control, such as "button1"</param>
        /// <param name="parentElement">Parent element, such as an application window, or the 
        /// AutomationElement.RootElement when searching for the application window.</param>
        /// <returns>The UI Automation element.</returns>
        private AutomationElement FindChildElement(String controlName, AutomationElement rootElement)
        {
            if ((controlName == "") || (rootElement == null))
            {
                throw new ArgumentException("Argument cannot be null or empty.");
            }
            // Set a property condition that will be used to find the main form of the
            // target application. In the case of a WinForms control, the name of the control
            // is also the AutomationId of the element representing the control.
            Condition propCondition = new PropertyCondition(
                AutomationElement.AutomationIdProperty, controlName, PropertyConditionFlags.IgnoreCase);

            // Find the element.
            return rootElement.FindFirst(TreeScope.Element | TreeScope.Children, propCondition);
        }
        // </Snippet110>

        /// <summary>
        /// Initializes the UIAutomation system by finding the root element and the element
        /// for the window of the provider application.
        /// </summary>
        /// <returns>true if successful; otherwise false.</returns>
        private bool InitializeUIAutomation()
        {
            try
            {
                RootElement = AutomationElement.RootElement;
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not initialize UIAutomation: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            MainWindowElement = FindChildElement("UIAFragmentProviderForm", RootElement);

            if (MainWindowElement == null)
            {
                MessageBox.Show("Could not find the main form of the provider application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Condition cond2 =
                    new PropertyCondition(AutomationElement.NameProperty, "FlowerList");
                ListElement = MainWindowElement.FindFirst(TreeScope.Children, cond2);

                if (ListElement == null)
                {
                    MessageBox.Show("Could not find custom control in the provider application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            // Subscribe to ElementSelected events, which are raised each time a list item is selected.
            // The events are raised by the list items, not the list, so the scope is set to Descendants.
            OnEvent = new AutomationEventHandler(OnSelect);
            Automation.AddAutomationEventHandler(SelectionItemPattern.ElementSelectedEvent, ListElement,
                TreeScope.Descendants, OnEvent);
            return true;
        }


        // <Snippet106>
        /// <summary>
        /// Handles ElementSelected events by showing a message.
        /// </summary>
        /// <param name="src">Object that raised the event; in this case, a list item.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSelect(object src, AutomationEventArgs e)
        {
            // Get the name of the item, which is equivalent to its text.
            AutomationElement element = src as AutomationElement;
            if (element != null)
            {
                Console.WriteLine(element.Current.Name + " was selected.");
            }
        }
        // </Snippet106>

        /// <summary>
        /// Shuts down UI Automation.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    try
        //    {
        //        Automation.RemoveAutomationEventHandler(SelectionItemPattern.ElementSelectedEvent, 
        //            elementList, OnEvent);
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //}



        /// <summary>
        /// Handles a button click by selecting an item in the list box.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Information about the event.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SelectListItem(ListElement, "Daffodil");
            }
            catch
            {
                label1.Text = "No UIAutomation target found.";
                return;
            }
            AutomationElement ae = ElementFromCursor();
            if (ae != null)
            {
                Console.WriteLine(ae.Current.Name);
            }
            else Console.WriteLine("no element there");

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            if (false == InitializeUIAutomation())
            {
                Application.Exit();
            }
        }

        #region Event handling

        // <Snippet101>
        // Member variables.
        AutomationElement ElementSubscribeButton;
        AutomationEventHandler UIAeventHandler;

        /// <summary>
        /// Register an event handler for InvokedEvent on the specified element.
        /// </summary>
        /// <param name="elementButton">The automation element.</param>
        public void SubscribeToInvoke(AutomationElement elementButton)
        {
            if (elementButton != null)
            {
                Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent,
                     elementButton, TreeScope.Element,
                     UIAeventHandler = new AutomationEventHandler(OnUIAutomationEvent));
                ElementSubscribeButton = elementButton;
            }
        }

        // <Snippet173>
        /// <summary>
        /// AutomationEventHandler delegate.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnUIAutomationEvent(object src, AutomationEventArgs e)
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
            if (e.EventId == InvokePattern.InvokedEvent)
            {
                // TODO Add handling code.
            }
            else
            {
                // TODO Handle any other events that have been subscribed to.
            }
        }
        // </Snippet173>

        private void ShutdownUIA()
        {
            if (UIAeventHandler != null)
            {
                Automation.RemoveAutomationEventHandler(InvokePattern.InvokedEvent,
                    ElementSubscribeButton, UIAeventHandler);
            }
        }
        // </Snippet101>

        // NOTE: ABOVE SHOULD NOT BE CALLED ON THE UI THREAD

        /// <summary>
        /// Shutdown code.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // NOTE This should not be done on the UI thread
            ShutdownUIA();
        }


        // <Snippet102>
        AutomationFocusChangedEventHandler focusHandler = null;

        /// <summary>
        /// Create an event handler and register it.
        /// </summary>
        public void SubscribeToFocusChange()
        {
            focusHandler = new AutomationFocusChangedEventHandler(OnFocusChange);
            Automation.AddAutomationFocusChangedEventHandler(focusHandler);
        }

        /// <summary>
        /// Handle the event.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFocusChange(object src, AutomationFocusChangedEventArgs e)
        {
            // TODO Add event handling code.
            // The arguments tell you which elements have lost and received focus.
        }

        /// <summary>
        /// Cancel subscription to the event.
        /// </summary>
        public void UnsubscribeFocusChange()
        {
            if (focusHandler != null)
            {
                Automation.RemoveAutomationFocusChangedEventHandler(focusHandler);
            }
        }
        // </Snippet102>

        #endregion Event handling


        #region Selection and SelectionItem pattern

        // <Snippet103> 
        /// <summary>
        /// Sets the focus to a list and selects a string item in that list.
        /// </summary>
        /// <param name="listElement">The list element.</param>
        /// <param name="itemText">The text to select.</param>
        /// <remarks>
        /// This deselects any currently selected items. To add the item to the current selection 
        /// in a multiselect list, use AddToSelection instead of Select.
        /// </remarks>
        public void SelectListItem(AutomationElement listElement, String itemText)
        {
            if ((listElement == null) || (itemText == ""))
            {
                throw new ArgumentException("Argument cannot be null or empty.");
            }
            listElement.SetFocus();
            Condition cond = new PropertyCondition(
                AutomationElement.NameProperty, itemText, PropertyConditionFlags.IgnoreCase);
            AutomationElement elementItem = listElement.FindFirst(TreeScope.Children, cond);
            if (elementItem != null)
            {
                SelectionItemPattern pattern;
                try
                {
                    pattern = elementItem.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);  // Most likely "Pattern not supported."
                    return;
                }
                pattern.Select();
            }
        }
        // </Snippet103>

        // <Snippet104>
        /// <summary>
        /// Retrieves the selection container for a selection item.
        /// </summary>
        /// <param name="listItem">
        /// An element that supports SelectionItemPattern.
        /// </param>
        AutomationElement GetListItemParent(AutomationElement listItem)
        {
            if (listItem == null) throw new ArgumentException();
            SelectionItemPattern pattern = listItem.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            if (pattern == null)
            {
                return null;
            }
            else
            {
                SelectionItemPattern.SelectionItemPatternInformation properties = pattern.Current;
                return properties.SelectionContainer;
            }
        }
        // </Snippet104>

        // <Snippet105> 
        void AddListItemToSelection(AutomationElement listItem)
        {
            if (listItem == null) throw new ArgumentException();
            SelectionItemPattern pattern = listItem.GetCurrentPattern(SelectionItemPattern.Pattern)
                as SelectionItemPattern;
            if (pattern != null)
            {
                pattern.AddToSelection();
            }
        }
        // </Snippet105>

        #endregion Selection and SelectionItem pattern



        #region Property retrieval and caching

        /* Following snippet shows various aspects of caching and should be used in general discussion of the topic. */
        // TODO Show use of TreeScope, GetUpdatedCache

        // <Snippet107>
        /// <summary>
        /// Caches and retrieves properties for a list item by using CacheRequest.Activate.
        /// </summary>
        /// <param name="elementList">Element from which to retrieve a child element.</param>
        /// <remarks>
        /// This code demonstrates various aspects of caching. It is not intended to be 
        /// an example of a useful method.
        /// </remarks>
        private void CachePropertiesByActivate(AutomationElement elementList)
        {
            AutomationElement elementListItem;

            // Set up the request.
            // <Snippet202>
            CacheRequest cacheRequest = new CacheRequest();
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.Add(AutomationElement.IsEnabledProperty);
            cacheRequest.Add(SelectionItemPattern.Pattern);
            cacheRequest.Add(SelectionItemPattern.SelectionContainerProperty);
            // </Snippet202>

            // Obtain an element and cache the requested items.
            using (cacheRequest.Activate())
            {
                Condition cond = new PropertyCondition(AutomationElement.IsSelectionItemPatternAvailableProperty, true);
                elementListItem = elementList.FindFirst(TreeScope.Children, cond);
            }
            // The CacheRequest is now inactive.

            // Retrieve the cached property and pattern.
            SelectionItemPattern pattern;
            String itemName;
            try
            {
                itemName = elementListItem.Cached.Name;
                pattern = elementListItem.GetCachedPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Object was not in cache.");
                return;
            }
            // Alternatively, you can use TryGetCachedPattern to retrieve the cached pattern.
            object cachedPattern;
            if (true == elementListItem.TryGetCachedPattern(SelectionItemPattern.Pattern, out cachedPattern))
            {
                pattern = cachedPattern as SelectionItemPattern;
            }

            // Specified pattern properties are also in the cache.
            AutomationElement parentList = pattern.Cached.SelectionContainer;

            // The following line will raise an exception, because the HelpText property was not cached.
            /*** String itemHelp = elementListItem.Cached.HelpText; ***/

            // Similarly, pattern properties that were not specified in the CacheRequest cannot be 
            // retrieved from the cache. This would raise an exception.
            /*** bool selected = pattern.Cached.IsSelected; ***/

            // This is still a valid call, even though the property is in the cache.
            // Of course, the cached value and the current value are not guaranteed to be the same.
            itemName = elementListItem.Current.Name;
        }
        // </Snippet107>

        // <Snippet108>
        /// <summary>
        /// Caches and retrieves properties for a list item by using CacheRequest.Push.
        /// </summary>
        /// <param name="autoElement">Element from which to retrieve a child element.</param>
        /// <remarks>
        /// This code demonstrates various aspects of caching. It is not intended to be 
        /// an example of a useful method.
        /// </remarks>
        private void CachePropertiesByPush(AutomationElement elementList)
        {
            // <Snippet183> 
            // Set up the request.
            CacheRequest cacheRequest = new CacheRequest();

            // Do not get a full reference to the cached objects, only to their cached properties and patterns.
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            // </Snippet183>

            // Cache all elements, regardless of whether they are control or content elements.
            cacheRequest.TreeFilter = Automation.RawViewCondition;

            // Property and pattern to cache.
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.Add(SelectionItemPattern.Pattern);

            // Activate the request.
            cacheRequest.Push();

            // Obtain an element and cache the requested items.
            Condition cond = new PropertyCondition(AutomationElement.IsSelectionItemPatternAvailableProperty, true);
            AutomationElement elementListItem = elementList.FindFirst(TreeScope.Children, cond);

            // At this point, you could call another method that creates a CacheRequest and calls Push/Pop.
            // While that method was retrieving automation elements, the CacheRequest set in this method 
            // would not be active. 

            // Deactivate the request.
            cacheRequest.Pop();

            // Retrieve the cached property and pattern.
            String itemName = elementListItem.Cached.Name;
            SelectionItemPattern pattern = elementListItem.GetCachedPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;

            // The following is an alternative way of retrieving the Name property.
            itemName = elementListItem.GetCachedPropertyValue(AutomationElement.NameProperty) as String;

            // This is yet another way, which returns AutomationElement.NotSupported if the element does
            // not supply a value. If the second parameter is false, a default name is returned.
            object objName = elementListItem.GetCachedPropertyValue(AutomationElement.NameProperty, true);
            if (objName == AutomationElement.NotSupported)
            {
                itemName = "Unknown";
            }
            else
            {
                itemName = objName as String;
            }

            // The following call raises an exception, because only the cached properties are available, 
            //  as specified by cacheRequest.AutomationElementMode. If AutomationElementMode had its
            //  default value (Full), this call would be valid.
            /*** bool enabled = elementListItem.Current.IsEnabled; ***/
        }
        // </Snippet108>

        // *** Simple property retrieval ***



        void MiscPropertyCalls(AutomationElement elementList)
        {
            // <Snippet121> 
            // elementList is an AutomationElement.

            // The following two calls are equivalent.
            string name = elementList.Current.Name;
            name = elementList.GetCurrentPropertyValue(AutomationElement.NameProperty) as string;
            // </Snippet121>

            // <Snippet122> 
            // elementList is an AutomationElement representing a list box.
            // Error-checking is omitted. Assume that elementList is known to support SelectionPattern.

            SelectionPattern selectPattern =
                elementList.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
            bool isMultipleSelect = selectPattern.Current.CanSelectMultiple;

            // The following call is equivalent to the one above.
            isMultipleSelect = (bool)
                elementList.GetCurrentPropertyValue(SelectionPattern.CanSelectMultipleProperty);
            // </Snippet122>

            // <Snippet123> 
            // elementList is an AutomationElement.
            object help = elementList.GetCurrentPropertyValue(AutomationElement.HelpTextProperty, true);
            if (help == AutomationElement.NotSupported)
            {
                help = "No help available";
            }
            string helpText = (string)help;
            // </Snippet123>

            // <Snippet126>
            // elementList is an AutomationElement.
            string helpString =
                elementList.GetCurrentPropertyValue(AutomationElement.HelpTextProperty) as string;
            // </Snippet126>
        }


        // Following is similar to above, but without the redundant comments -- better for a how-to
        // <Snippet170> 
        void PropertyCallsExample(AutomationElement elementList)
        {
            // The following two calls are equivalent.
            string name = elementList.Current.Name;
            name = elementList.GetCurrentPropertyValue(AutomationElement.NameProperty) as string;

            // The following shows how to ignore the default property, which 
            //  would probably be an empty string if the property is not supported.
            //  Passing "false" as the second parameter is equivalent to using the overload
            //  that does not have this parameter.
            object help = elementList.GetCurrentPropertyValue(AutomationElement.HelpTextProperty, true);
            if (help == AutomationElement.NotSupported)
            {
                help = "No help available";
            }
            string helpText = (string)help;
        }
        // </Snippet170>


        /*** *** Updating the cache *** ***/

        // <Snippet109>
        CacheRequest comboCacheRequest;
        AutomationEventHandler selectHandler;
        AutomationElement elementCombo;
        AutomationElement selectedItem;

        /// <summary>
        /// Retrieves a combo box automation element, caches a pattern and a property,
        /// and registers the event handler.
        /// </summary>
        /// <param name="elementAppWindow">The element for the parent window.</param>
        private void SetupComboElement(AutomationElement elementAppWindow)
        {
            // Set up the CacheRequest.
            comboCacheRequest = new CacheRequest();
            comboCacheRequest.Add(SelectionPattern.Pattern);
            comboCacheRequest.Add(SelectionPattern.SelectionProperty);
            comboCacheRequest.Add(AutomationElement.NameProperty);
            comboCacheRequest.TreeScope = TreeScope.Element | TreeScope.Descendants;

            // Activate the CacheRequest and get the element.
            using (comboCacheRequest.Activate())
            {
                // Load the combo box element and cache the specified properties and patterns.
                Condition propCondition = new PropertyCondition(
                    AutomationElement.AutomationIdProperty, "comboBox1", PropertyConditionFlags.IgnoreCase);
                elementCombo = elementAppWindow.FindFirst(TreeScope.Descendants, propCondition);
            }

            // Get the list from the combo box.
            // <Snippet180> 
            Condition propCondition1 = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List);
            AutomationElement listElement = elementCombo.FindFirst(TreeScope.Children, propCondition1);
            // </Snippet180>

            // Register for ElementSelectedEvent on list items.
            if (listElement != null)
            {
                Automation.AddAutomationEventHandler(SelectionItemPattern.ElementSelectedEvent, listElement,
                    TreeScope.Children, selectHandler = new AutomationEventHandler(OnListItemSelect));
            }
        }

        /// <summary>
        /// Handle ElementSelectedEvent on items in the combo box.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnListItemSelect(object src, AutomationEventArgs e)
        {
            // Update the cache.
            AutomationElement updatedElement = elementCombo.GetUpdatedCache(comboCacheRequest);

            // Retrieve the pattern and the selected item from the cache. This code is here only to 
            // demonstrate that the current selection can now be retrieved from the cache. In an application,
            // this would be done only when the information was needed.
            SelectionPattern pattern = updatedElement.GetCachedPattern(SelectionPattern.Pattern) as SelectionPattern;
            AutomationElement[] selectedItems = pattern.Cached.GetSelection();
            selectedItem = selectedItems[0];
        }
        // </Snippet109>


        // <Snippet119>
        /// <summary>
        /// Gets a list box element and caches the Name property of its children (the list items).
        /// </summary>
        /// <param name="elementMain">The UI Automation element for the parent window.</param>
        void CachePropertiesWithScope(AutomationElement elementMain)
        {
            AutomationElement elementList;

            // Set up the CacheRequest.
            CacheRequest cacheRequest = new CacheRequest();
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.TreeScope = TreeScope.Element | TreeScope.Children;

            // Activate the CacheRequest and get the element. Note that the scope of the CacheRequest
            // is in relation to the object being retrieved: the list box and its children are 
            // cached, not the main window and its children.
            using (cacheRequest.Activate())
            {
                // Load the list element and cache the specified properties for its descendants.
                Condition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List);
                elementList = elementMain.FindFirst(TreeScope.Children, cond);
            }
            if (elementList == null) return;

            // The following illustrates that the children of the list are in the cache.
            foreach (AutomationElement listItem in elementList.CachedChildren)
            {
                Console.WriteLine(listItem.Cached.Name);
            }

            // The following call raises an exception, because the IsEnabled property was not cached.
            /*** Console.WriteLine(listItem.Cached.IsEnabled); ***/

            // The following illustrates that because the list box itself was cached, it is now
            // available as the CachedParent of each list item.
            AutomationElement child = elementList.CachedChildren[0];
            Console.WriteLine(child.CachedParent.Cached.Name);
        }
        // </Snippet119>

        #endregion Property retrieval and caching


        #region Miscellaneous calls

        // <Snippet184>
        /// <summary>
        /// Retrieves an element in a list, using TreeWalker.
        /// </summary>
        /// <param name="parent">The list element.</param>
        /// <param name="index">The index of the element to find.</param>
        /// <returns>The list item.</returns>
        AutomationElement FindChildAt(AutomationElement parent, int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            TreeWalker walker = TreeWalker.ControlViewWalker;
            AutomationElement child = walker.GetFirstChild(parent);
            for (int x = 1; x <= index; x++)
            {
                child = walker.GetNextSibling(child);
                if (child == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            return child;
        }

        /// <summary>
        /// Retrieves an element in a list, using FindAll.
        /// </summary>
        /// <param name="parent">The list element.</param>
        /// <param name="index">The index of the element to find.</param>
        /// <returns>The list item.</returns>
        AutomationElement FindChildAtB(AutomationElement parent, int index)
        {
            Condition findCondition = new PropertyCondition(AutomationElement.IsControlElementProperty, true);
            AutomationElementCollection found = parent.FindAll(TreeScope.Children, findCondition);
            if ((index < 0) || (index >= found.Count))
            {
                throw new ArgumentOutOfRangeException();
            }
            return found[index];
        }
        // </Snippet184>

        // <Snippet116>
        /// <summary>
        /// Finds all enabled buttons in the specified window element.
        /// </summary>
        /// <param name="elementWindowElement">An application or dialog window.</param>
        /// <returns>A collection of elements that meet the conditions.</returns>
        AutomationElementCollection FindByMultipleConditions(
            AutomationElement elementWindowElement)
        {
            if (elementWindowElement == null)
            {
                throw new ArgumentException();
            }
            Condition conditions = new AndCondition(
              new PropertyCondition(AutomationElement.IsEnabledProperty, true),
              new PropertyCondition(AutomationElement.ControlTypeProperty, 
                  ControlType.Button)
              );

            // Find all children that match the specified conditions.
            AutomationElementCollection elementCollection = 
                elementWindowElement.FindAll(TreeScope.Children, conditions);
            return elementCollection;
        }
        // </Snippet116>

        void MiscellaneousCalls(AutomationElement element)
        {
            String s = element.Current.Name;

            // <Snippet111>
            // element is an AutomationElement.
            int[] id = element.GetRuntimeId();
            // </Snippet111>

            // <Snippet112>
            // element is an AutomationElement.
            System.Windows.Point pt;
            bool clickable = element.TryGetClickablePoint(out pt);
            // </Snippet112>

            // <Snippet179>
            // element is an AutomationElement.
            System.Windows.Point clickablePoint = element.GetClickablePoint();
            System.Windows.Forms.Cursor.Position = 
                new System.Drawing.Point((int)clickablePoint.X, (int)clickablePoint.Y);
            // </Snippet179>

            // <Snippet114> 
            // element is an AutomationElement.
            AutomationPattern[] patterns = element.GetSupportedPatterns();
            foreach (AutomationPattern pattern in patterns)
            {
                Console.WriteLine("ProgrammaticName: " + pattern.ProgrammaticName);
                Console.WriteLine("PatternName: " + Automation.PatternName(pattern));
            }
            // </Snippet114>

            // <Snippet115> 
            AutomationProperty[] properties = element.GetSupportedProperties();
            foreach (AutomationProperty prop in properties)
            {
                Console.WriteLine(prop.ProgrammaticName);
                Console.WriteLine(Automation.PropertyName(prop));
            }
            // </Snippet115>

            // <Snippet113> 
            // element is an AutomationElement.
            object objPattern;
            SelectionPattern selPattern;
            if (true == element.TryGetCurrentPattern(SelectionPattern.Pattern, out objPattern))
            {
                selPattern = objPattern as SelectionPattern;
            }
            // </Snippet113>

            AutomationElementCollection elementCollection = 
                FindByMultipleConditions(MainWindowElement);

            // <Snippet117>
            // elementCollection is an AutomationElementCollection.
            AutomationElement[] elementArray = new AutomationElement[elementCollection.Count];
            elementCollection.CopyTo(elementArray, 0);
            // </Snippet117>

            // <Snippet118>
            // elementCollection is an AutomationElementCollection.
            object[] elementUntypedArray = new object[elementCollection.Count];
            elementCollection.CopyTo(elementUntypedArray, 0);
            // </Snippet118>
            AutomationElement elementElement = elementCollection[0];

            // <Snippet201> 
            AutomationElementCollection desktopChildren =
                AutomationElement.RootElement.FindAll(
                TreeScope.Children, Condition.TrueCondition);
            // </Snippet201>

            // <Snippet182>
            // desktopChildren is a collection of AutomationElement objects.
            AutomationElement firstWindow;
            try
            {
                firstWindow = desktopChildren[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No AutomationElement at that index.");
            }
            // </Snippet182>
        }

        #endregion Miscellaneous calls


        // this should all be done on a non-UI thread
        private void btnMisc_Click(object sender, EventArgs e)
        {

            Condition cond = new PropertyCondition(AutomationElement.NameProperty, "Tulip");
            AutomationElement elementListItem = ListElement.FindFirst(TreeScope.Children, cond);

            ShowUsage();
           // VISTAONLY GetPhysicalCursorPos(ref pt);
            

            /* Test for a WPF listbox in the window under the cursor.
            System.Windows.Point pt = new System.Windows.Point(Cursor.Position.X, Cursor.Position.Y);
            AutomationElement wpfListSample = AutomationElement.FromPoint(pt);
            Condition cond1 = new PropertyCondition(AutomationElement.ClassNameProperty, "ListBox");
            AutomationElement wpfList = wpfListSample.FindFirst(TreeScope.Children, cond1);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            AutomationElement childAt = FindChildAt(wpfList, 9);   // way faster
            watch.Stop();
            Debug.WriteLine(watch.Elapsed.Ticks.ToString());
            watch.Reset();
            watch.Start();
            AutomationElement childAt1 = FindChildAtB(wpfList, 9);
            watch.Stop();
            Debug.WriteLine(watch.Elapsed.Ticks.ToString());
             */

            
            
            cond = new PropertyCondition(AutomationElement.AutomationIdProperty, "button1");
            AutomationElement elementButton = MainWindowElement.FindFirst(TreeScope.Subtree, cond);
            SubscribeToInvoke(elementButton);

            //InvokePattern invoker = elementButton.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            //invoker.Invoke();
            // AutomationElement elementList = GetListItemParent(elementListItem);
            String s = ListElement.Current.Name;

            //SetupComboElement(MainWindowElement);
            //MiscellaneousCalls(ListElement);

            //AddListItemToSelection(elementListItem);
            //CachePropertiesByActivate(elementList);
            //CachePropertiesWithScope(MainWindowElement);
            //CachePropertiesByPush(elementList);

            ConditionSnips cs = new ConditionSnips();
            cs.GetTreeWalkerCondition();
            //cs.ConditionExamples(MainWindowElement);
            //cs.AndConditionExample(MainWindowElement);
            //cs.NotConditionExample(MainWindowElement);
            //cs.StaticConditionExamples(MainWindowElement);
            //MiscPropertyCalls(elementList);

            PropertySnips ps = new PropertySnips();
            ps.GetAllProperties(elementListItem);
            TreeNode treeNode = treeView1.Nodes.Add("Root node");
            //WalkControlElements(MainWindowElement, treeNode);
            //WalkEnabledElements(MainWindowElement, treeNode);

            // Property changes
            //cond = new PropertyCondition(AutomationElement.AutomationIdProperty, "btnDisable");
            //elementButton = MainWindowElement.FindFirst(TreeScope.Subtree, cond);

           // ps.SubscribePropertyChange(elementButton);


        }

    }  // end class



}  // end namespace