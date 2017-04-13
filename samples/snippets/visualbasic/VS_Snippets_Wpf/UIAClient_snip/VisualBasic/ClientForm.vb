 '************************************************************************************************
' *
' * File: ClientForm.cs
' *
' * Description: Miscellaneous snippets illustrating client UIA functionality
' * 
' * 
' ************************************************************************************************

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Automation
Imports System.Windows




Class Form1
    Inherits Form '
    Private RootElement As AutomationElement = Nothing
    Private MainWindowElement As AutomationElement = Nothing
    Private ListElement As AutomationElement = Nothing
    Private SelectEventHandler As AutomationEventHandler = Nothing
    ' <Snippet185> 
    Structure CursorPoint
        Public X As Integer
        Public Y As Integer
    End Structure

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Friend Shared Function GetPhysicalCursorPos(ByRef lpPoint As CursorPoint) As Boolean
    End Function

    Private Function ShowUsage() As Boolean

        Dim cursorPos As New CursorPoint()
        Try
            Return GetPhysicalCursorPos(cursorPos)
        Catch e As EntryPointNotFoundException ' Not Windows Vista
            Return False
        End Try

    End Function
    ' </Snippet185>



    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New()
        InitializeComponent()

    End Sub 'New


    ' <Snippet181>
    Private Function ElementFromCursor() As AutomationElement
        ' Convert mouse position from System.Drawing.Point to System.Windows.Point.
        Dim cursorPoint As System.Windows.Point = New System.Windows.Point( _
            System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y)
        Return AutomationElement.FromPoint(cursorPoint)
    End Function
    ' </Snippet181>



    ' <Snippet171>
    ''' <summary>
    ''' Walks the UI Automation tree and adds the control type of each element it finds 
    ''' in the control view to a TreeView.
    ''' </summary>
    ''' <param name="rootElement">The root of the search on this iteration.</param>
    ''' <param name="treeNode">The node in the TreeView for this iteration.</param>
    ''' <remarks>
    ''' This is a recursive function that maps out the structure of the subtree beginning at the
    ''' UI Automation element passed in as rootElement on the first call. This could be, for example,
    ''' an application window.
    ''' CAUTION: Do not pass in AutomationElement.RootElement. Attempting to map out the entire subtree of
    ''' the desktop could take a very long time and even lead to a stack overflow.
    ''' </remarks>
    Private Sub WalkControlElements(ByVal rootElement As AutomationElement, ByVal treeNode As TreeNode)
        ' Conditions for the basic views of the subtree (content, control, and raw) 
        ' are available as fields of TreeWalker, and one of these is used in the 
        ' following code.
        Dim elementNode As AutomationElement = TreeWalker.ControlViewWalker.GetFirstChild(rootElement)

        While (elementNode IsNot Nothing)
            Dim childTreeNode As TreeNode = treeNode.Nodes.Add(elementNode.Current.ControlType.LocalizedControlType)
            WalkControlElements(elementNode, childTreeNode)
            elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode)
        End While

    End Sub 'WalkControlElements

    ' </Snippet171>

    ' <Snippet174>
    ''' <summary>
    ''' Walks the UI Automation tree and adds the control type of each enabled control 
    ''' element it finds to a TreeView.
    ''' </summary>
    ''' <param name="rootElement">The root of the search on this iteration.</param>
    ''' <param name="treeNode">The node in the TreeView for this iteration.</param>
    ''' <remarks>
    ''' This is a recursive function that maps out the structure of the subtree beginning at the
    ''' UI Automation element passed in as rootElement on the first call. This could be, for example,
    ''' an application window.
    ''' CAUTION: Do not pass in AutomationElement.RootElement. Attempting to map out the entire subtree of
    ''' the desktop could take a very long time and even lead to a stack overflow.
    ''' </remarks>
    Private Sub WalkEnabledElements(ByVal rootElement As AutomationElement, ByVal treeNode As TreeNode)
        Dim condition1 As New PropertyCondition(AutomationElement.IsControlElementProperty, True)
        Dim condition2 As New PropertyCondition(AutomationElement.IsEnabledProperty, True)
        Dim walker As New TreeWalker(New AndCondition(condition1, condition2))
        Dim elementNode As AutomationElement = walker.GetFirstChild(rootElement)
        While (elementNode IsNot Nothing)
            Dim childTreeNode As TreeNode = treeNode.Nodes.Add(elementNode.Current.ControlType.LocalizedControlType)
            WalkEnabledElements(elementNode, childTreeNode)
            elementNode = walker.GetNextSibling(elementNode)
        End While

    End Sub 'WalkEnabledElements

    ' </Snippet174>

    ' <Snippet110>
    ''' <summary>
    ''' Find a UI Automation child element by ID.
    ''' </summary>
    ''' <param name="controlName">Name of the control, such as "button1"</param>
    ''' <param name="rootElement">Parent element, such as an application window, or the 
    ''' AutomationElement.RootElement when searching for the application window.</param>
    ''' <returns>The UI Automation element.</returns>
    Private Function FindChildElement(ByVal controlName As String, ByVal rootElement As AutomationElement) _
        As AutomationElement
        If controlName = "" OrElse rootElement Is Nothing Then
            Throw New ArgumentException("Argument cannot be null or empty.")
        End If
        ' Set a property condition that will be used to find the main form of the
        ' target application. In the case of a WinForms control, the name of the control
        ' is also the AutomationId of the element representing the control.
        Dim propCondition As New PropertyCondition(AutomationElement.AutomationIdProperty, _
            controlName, PropertyConditionFlags.IgnoreCase)

        ' Find the element.
        Return rootElement.FindFirst(TreeScope.Element Or TreeScope.Children, propCondition)

    End Function 'FindChildElement

    ' </Snippet110>
    ''' <summary>
    ''' Initializes the UIAutomation system by finding the root element and the element
    ''' for the window of the provider application.
    ''' </summary>
    ''' <returns>true if successful; otherwise false.</returns>
    Private Function InitializeUIAutomation() As Boolean

        MainWindowElement = FindChildElement("UIAFragmentProviderForm", AutomationElement.RootElement)

        If MainWindowElement Is Nothing Then
            MessageBox.Show("Could not find the main form of the provider application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Dim cond2 As New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List)
            ListElement = MainWindowElement.FindFirst(TreeScope.Children, cond2)

            If ListElement Is Nothing Then
                MessageBox.Show("Could not find list in the provider application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If

        ' Subscribe to ElementSelected events, which are raised each time a list item is selected.
        ' The events are raised by the list items, not the list, so the scope is set to Descendants.
        SelectEventHandler = New AutomationEventHandler(AddressOf OnSelect)
        Automation.AddAutomationEventHandler(SelectionItemPattern.ElementAddedToSelectionEvent, ListElement, _
            TreeScope.Descendants, SelectEventHandler)

        Return True

    End Function 'InitializeUIAutomation



    ' <Snippet106>
    ''' <summary>
    ''' Handles ElementSelected events by showing a message.
    ''' </summary>
    ''' <param name="src">Object that raised the event; in this case, a list item.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub OnSelect(ByVal src As Object, ByVal e As AutomationEventArgs)
        ' Get the name of the item, which is equivalent to its text.
        Dim element As AutomationElement = DirectCast(src, AutomationElement)
        If (element IsNot Nothing) Then
            Console.WriteLine(element.Current.Name + " was selected.")
        End If

    End Sub 'OnSelect
    ' </Snippet106>

    '''' <summary>
    '''' Shuts down UI Automation.
    '''' </summary>
    '''' <param name="sender">Object that raised the event.</param>
    '''' <param name="e">Event arguments.</param>
    ' private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    '{
    '    try
    '    {
    '        Automation.RemoveAutomationEventHandler(SelectionItemPattern.ElementSelectedEvent, 
    '            elementList, OnEvent);
    '    }
    '    catch
    '    {
    '        return;
    '    }
    '}


    ''' <summary>
    ''' Handles a button click by selecting an item in the list box.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e">Information about the event.</param>
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            SelectListItem(ListElement, "Daffodil")
        Catch
            label1.Text = "No UIAutomation target found."
            Return
        End Try

    End Sub 'button1_Click

    ' <Snippet184>
    ''' <summary>
    ''' Retrieves an element in a list, using TreeWalker.
    ''' </summary>
    ''' <param name="parent">The list element.</param>
    ''' <param name="index">The index of the element to find.</param>
    ''' <returns>The list item.</returns>
    Function FindChildAt(ByVal parent As AutomationElement, ByVal index As Integer) As AutomationElement

        If (index < 0) Then
            Throw New ArgumentOutOfRangeException()
        End If
        Dim walker As TreeWalker = TreeWalker.ControlViewWalker
        Dim child As AutomationElement = walker.GetFirstChild(parent)
        For x As Integer = 1 To (index - 1)
            child = walker.GetNextSibling(child)
            If child = Nothing Then

                Throw New ArgumentOutOfRangeException()
            End If
        Next x
        Return child
    End Function

    ''' <summary>
    ''' Retrieves an element in a list, using FindAll.
    ''' </summary>
    ''' <param name="parent">The list element.</param>
    ''' <param name="index">The index of the element to find.</param>
    ''' <returns>The list item.</returns>
    Function FindChildAtB(ByVal parent As AutomationElement, ByVal index As Integer) As AutomationElement
        Dim findCondition As Condition = _
            New PropertyCondition(AutomationElement.IsControlElementProperty, True)
        Dim found As AutomationElementCollection = parent.FindAll(TreeScope.Children, findCondition)
        If (index < 0) Or (index >= found.Count) Then
            Throw New ArgumentOutOfRangeException()
        End If
        Return found(index)
    End Function
    ' </Snippet184>

#Region "Event handling"

    ' <Snippet101>
    ' Member variables.
    Private ElementSubscribeButton As AutomationElement
    Private UIAeventHandler As AutomationEventHandler


    ''' <summary>
    ''' Register an event handler for InvokedEvent on the specified element.
    ''' </summary>
    ''' <param name="elementButton">The automation element.</param>
    Public Sub SubscribeToInvoke(ByVal elementButton As AutomationElement)
        If (elementButton IsNot Nothing) Then
            UIAeventHandler = New AutomationEventHandler(AddressOf OnUIAutomationEvent)
            Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, elementButton, _
            TreeScope.Element, UIAeventHandler)
            ElementSubscribeButton = elementButton
        End If

    End Sub 'SubscribeToInvoke


    ' <Snippet173>
    ''' <summary>
    ''' AutomationEventHandler delegate.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub OnUIAutomationEvent(ByVal src As Object, ByVal e As AutomationEventArgs)
        ' Make sure the element still exists. Elements such as tooltips can disappear
        ' before the event is processed.
        Dim sourceElement As AutomationElement
        Try
            sourceElement = DirectCast(src, AutomationElement)
        Catch ex As ElementNotAvailableException
            Exit Sub
        End Try
        If e.EventId Is InvokePattern.InvokedEvent Then
            ' TODO Add handling code.
        Else
        End If
        ' TODO Handle any other events that have been subscribed to.
        Console.WriteLine("Event: " & e.EventId.ProgrammaticName)
    End Sub 'OnUIAutomationEvent
    ' </Snippet173>

    Private Sub ShutdownUIA()
        If (UIAeventHandler IsNot Nothing) Then
            Automation.RemoveAutomationEventHandler(InvokePattern.InvokedEvent, ElementSubscribeButton, UIAeventHandler)
        End If

    End Sub 'ShutdownUIA
    ' </Snippet101>

    ' NOTE: ABOVE SHOULD NOT BE CALLED ON THE UI THREAD
    ''' <summary>
    ''' Shutdown code.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        ' NOTE This should not be done on the UI thread
        ShutdownUIA()

    End Sub 'Form1_FormClosing


    ' <Snippet102>
    Private focusHandler As AutomationFocusChangedEventHandler = Nothing


    ''' <summary>
    ''' Create an event handler and register it.
    ''' </summary>
    Public Sub SubscribeToFocusChange()
        focusHandler = New AutomationFocusChangedEventHandler(AddressOf OnFocusChange)
        Automation.AddAutomationFocusChangedEventHandler(focusHandler)

    End Sub 'SubscribeToFocusChange


    ''' <summary>
    ''' Handle the event.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub OnFocusChange(ByVal src As Object, ByVal e As AutomationFocusChangedEventArgs)

    End Sub 'OnFocusChange

    ' TODO Add event handling code.
    ' The arguments tell you which elements have lost and received focus.

    ''' <summary>
    ''' Cancel subscription to the event.
    ''' </summary>
    Public Sub UnsubscribeFocusChange()
        If (focusHandler IsNot Nothing) Then
            Automation.RemoveAutomationFocusChangedEventHandler(focusHandler)
        End If

    End Sub 'UnsubscribeFocusChange
    ' </Snippet102>

#End Region

#Region "Selection and SelectionItem pattern"

    ' <Snippet103> 
    ''' <summary>
    ''' Sets the focus to a list and selects a string item in that list.
    ''' </summary>
    ''' <param name="listElement">The list element.</param>
    ''' <param name="itemText">The text to select.</param>
    ''' <remarks>
    ''' This deselects any currently selected items. To add the item to the current selection 
    ''' in a multiselect list, use AddToSelection instead of Select.
    ''' </remarks>
    Public Sub SelectListItem(ByVal listElement As AutomationElement, ByVal itemText As String)
        If listElement Is Nothing OrElse itemText = "" Then
            Throw New ArgumentException("Argument cannot be null or empty.")
        End If
        listElement.SetFocus()
        Dim cond As New PropertyCondition(AutomationElement.NameProperty, itemText, PropertyConditionFlags.IgnoreCase)
        Dim elementItem As AutomationElement = listElement.FindFirst(TreeScope.Children, cond)
        If Not (elementItem Is Nothing) Then
            Dim pattern As SelectionItemPattern
            Try
                pattern = DirectCast(elementItem.GetCurrentPattern(SelectionItemPattern.Pattern), _
                    SelectionItemPattern)
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.Message) ' Most likely "Pattern not supported."
                Return
            End Try
            pattern.Select()
        End If

    End Sub 'SelectListItem
    ' </Snippet103>

    ' <Snippet104>
    ''' <summary>
    ''' Retrieves the selection container for a selection item.
    ''' </summary>
    ''' <param name="listItem">
    ''' An element that supports SelectionItemPattern.
    ''' </param>
    Function GetListItemParent(ByVal listItem As AutomationElement) As AutomationElement
        If listItem Is Nothing Then
            Throw New ArgumentException()
        End If
        Dim pattern As SelectionItemPattern = _
            DirectCast(listItem.GetCurrentPattern(SelectionItemPattern.Pattern), SelectionItemPattern)
        If pattern Is Nothing Then
            Return Nothing
        Else
            Dim properties As SelectionItemPattern.SelectionItemPatternInformation = pattern.Current
            Return properties.SelectionContainer
        End If

    End Function 'GetListItemParent

    ' </Snippet104>
    ' <Snippet105> 
    Sub AddListItemToSelection(ByVal listItem As AutomationElement)
        If listItem Is Nothing Then
            Throw New ArgumentException()
        End If
        Dim pattern As SelectionItemPattern = _
            DirectCast(listItem.GetCurrentPattern(SelectionItemPattern.Pattern), SelectionItemPattern)
        If (pattern IsNot Nothing) Then
            pattern.AddToSelection()
        End If

    End Sub 'AddListItemToSelection
    ' </Snippet105>
#End Region


#Region "Property retrieval and caching"
    '
    ' Following snippet shows various aspects of caching and should be used in general discussion of the topic. 
    ' TODO Show use of TreeScope, GetUpdatedCache

    ' <Snippet107>
    ''' <summary>
    ''' Caches and retrieves properties for a list item by using CacheRequest.Activate.
    ''' </summary>
    ''' <param name="elementList">Element from which to retrieve a child element.</param>
    ''' <remarks>
    ''' This code demonstrates various aspects of caching. It is not intended to be 
    ''' an example of a useful method.
    ''' </remarks>
    Private Sub CachePropertiesByActivate(ByVal elementList As AutomationElement)

        ' Set up the request.
        ' <Snippet202>
        Dim myCacheRequest As New CacheRequest()
        myCacheRequest.Add(AutomationElement.NameProperty)
        myCacheRequest.Add(AutomationElement.IsEnabledProperty)
        myCacheRequest.Add(SelectionItemPattern.Pattern)
        myCacheRequest.Add(SelectionItemPattern.SelectionContainerProperty)
        ' </Snippet202>

        Dim elementListItem As AutomationElement

        ' Obtain an element and cache the requested items.
        Using myCacheRequest.Activate()
            Dim myCondition As New PropertyCondition( _
                AutomationElement.IsSelectionItemPatternAvailableProperty, True)
            elementListItem = elementList.FindFirst(TreeScope.Children, myCondition)
        End Using


        ' The CacheRequest is now inactive.
        ' Retrieve the cached property and pattern.
        Dim pattern As SelectionItemPattern
        Dim itemName As String
        Try
            itemName = elementListItem.Cached.Name
            pattern = DirectCast(elementListItem.GetCachedPattern(SelectionItemPattern.Pattern), _
                SelectionItemPattern)
        Catch ex As InvalidOperationException
            Console.WriteLine("Object was not in cache.")
            Return
        End Try
        ' Alternatively, you can use TryGetCachedPattern to retrieve the cached pattern.
        Dim cachedPattern As Object = Nothing
        If True = elementListItem.TryGetCachedPattern(SelectionItemPattern.Pattern, cachedPattern) Then
            pattern = DirectCast(cachedPattern, SelectionItemPattern)
        End If

        ' Specified pattern properties are also in the cache.
        Dim parentList As AutomationElement = pattern.Cached.SelectionContainer

        ' The following line will raise an exception, because the HelpText property was not cached.
        '** String itemHelp = elementListItem.Cached.HelpText; **

        ' Similarly, pattern properties that were not specified in the CacheRequest cannot be 
        ' retrieved from the cache. This would raise an exception.
        '** bool selected = pattern.Cached.IsSelected; **

        ' This is still a valid call, even though the property is in the cache.
        ' Of course, the cached value and the current value are not guaranteed to be the same.
        itemName = elementListItem.Current.Name
    End Sub 'CachePropertiesByActivate

    ' </Snippet107>

    ' <Snippet108>
    ''' <summary>
    ''' Caches and retrieves properties for a list item by using CacheRequest.Push.
    ''' </summary>
    ''' <param name="elementList">Element from which to retrieve a child element.</param>
    ''' <remarks>
    ''' This code demonstrates various aspects of caching. It is not intended to be 
    ''' an example of a useful method.
    ''' </remarks>
    Private Sub CachePropertiesByPush(ByVal elementList As AutomationElement)
        ' <Snippet183>
        ' Set up the request.
        Dim cacheRequest As New CacheRequest()

        ' Do not get a full reference to the cached objects, only to their cached properties and patterns.
        cacheRequest.AutomationElementMode = AutomationElementMode.None
        ' </Snippet183>

        ' Cache all elements, regardless of whether they are control or content elements.
        cacheRequest.TreeFilter = Automation.RawViewCondition

        ' Property and pattern to cache.
        cacheRequest.Add(AutomationElement.NameProperty)
        cacheRequest.Add(SelectionItemPattern.Pattern)

        ' Activate the request.
        cacheRequest.Push()

        ' Obtain an element and cache the requested items.
        Dim myCondition As New PropertyCondition(AutomationElement.IsSelectionItemPatternAvailableProperty, _
            True)
        Dim elementListItem As AutomationElement = elementList.FindFirst(TreeScope.Children, myCondition)

        ' At this point, you could call another method that creates a CacheRequest and calls Push/Pop.
        ' While that method was retrieving automation elements, the CacheRequest set in this method 
        ' would not be active. 
        ' Deactivate the request.
        cacheRequest.Pop()

        ' Retrieve the cached property and pattern.
        Dim itemName As String = elementListItem.Cached.Name
        Dim pattern As SelectionItemPattern = _
            DirectCast(elementListItem.GetCachedPattern(SelectionItemPattern.Pattern), SelectionItemPattern)

        ' The following is an alternative way of retrieving the Name property.
        itemName = CStr(elementListItem.GetCachedPropertyValue(AutomationElement.NameProperty))

        ' This is yet another way, which returns AutomationElement.NotSupported if the element does
        ' not supply a value. If the second parameter is false, a default name is returned.
        Dim objName As Object = elementListItem.GetCachedPropertyValue(AutomationElement.NameProperty, True)
        If objName Is AutomationElement.NotSupported Then
            itemName = "Unknown"
        Else
            itemName = CStr(objName)
        End If
        ' The following call raises an exception, because only the cached properties are available, 
        '  as specified by cacheRequest.AutomationElementMode. If AutomationElementMode had its
        '  default value (Full), this call would be valid.
        '** bool enabled = elementListItem.Current.IsEnabled; **

    End Sub 'CachePropertiesByPush
    ' </Snippet108>


    ' *** Simple property retrieval ***


    Sub MiscPropertyCalls(ByVal elementList As AutomationElement)
        ' <Snippet121> 
        ' elementList is an AutomationElement.
        ' The following two calls are equivalent.
        Dim name As String = elementList.Current.Name
        name = CStr(elementList.GetCurrentPropertyValue(AutomationElement.NameProperty))
        ' </Snippet121>

        ' <Snippet122> 
        ' elementList is an AutomationElement representing a list box.
        ' Error-checking is omitted. Assume that elementList is known to support SelectionPattern.
        Dim selectPattern As SelectionPattern = _
            DirectCast(elementList.GetCurrentPattern(SelectionPattern.Pattern), SelectionPattern)
        Dim isMultipleSelect As Boolean = selectPattern.Current.CanSelectMultiple

        ' The following call is equivalent to the one above.
        isMultipleSelect = CBool(elementList.GetCurrentPropertyValue(SelectionPattern.CanSelectMultipleProperty))
        ' </Snippet122>
        ' <Snippet123> 
        ' elementList is an AutomationElement.
        Dim help As Object = elementList.GetCurrentPropertyValue(AutomationElement.HelpTextProperty, True)
        If help Is AutomationElement.NotSupported Then
            help = "No help available"
        End If
        Dim helpText As String = CStr(help)
        ' </Snippet123>

        ' <Snippet126>
        ' elementList is an AutomationElement.
        Dim helpString As String = _
            CStr(elementList.GetCurrentPropertyValue(AutomationElement.HelpTextProperty))
        ' </Snippet126>
    End Sub 'MiscPropertyCalls


    ' Following is similar to above, but without the redundant comments -- better for a how-to
    ' <Snippet170> 
    Sub PropertyCallsExample(ByVal elementList As AutomationElement)
        ' The following two calls are equivalent.
        Dim name As String = elementList.Current.Name
        name = CStr(elementList.GetCurrentPropertyValue(AutomationElement.NameProperty))

        ' The following shows how to ignore the default property, which 
        '  would probably be an empty string if the property is not supported.
        '  Passing "false" as the second parameter is equivalent to using the overload
        '  that does not have this parameter.
        Dim help As Object = elementList.GetCurrentPropertyValue(AutomationElement.HelpTextProperty, True)
        If help Is AutomationElement.NotSupported Then
            help = "No help available"
        End If
        Dim helpText As String = CStr(help)

    End Sub 'PropertyCallsExample
    ' </Snippet170>

    '** *** Updating the cache *** **

    ' <Snippet109>
    Private comboCacheRequest As CacheRequest
    Private selectHandler As AutomationEventHandler
    Private elementCombo As AutomationElement
    Private selectedItem As AutomationElement


    ''' <summary>
    ''' Retrieves a combo box automation element, caches a pattern and a property,
    ''' and registers the event handler.
    ''' </summary>
    ''' <param name="elementAppWindow">The element for the parent window.</param>
    Private Sub SetupComboElement(ByVal elementAppWindow As AutomationElement)
        ' Set up the CacheRequest.
        comboCacheRequest = New CacheRequest()
        comboCacheRequest.Add(SelectionPattern.Pattern)
        comboCacheRequest.Add(SelectionPattern.SelectionProperty)
        comboCacheRequest.Add(AutomationElement.NameProperty)
        comboCacheRequest.TreeScope = TreeScope.Element Or TreeScope.Descendants

        ' Activate the CacheRequest and get the element.
        Using comboCacheRequest.Activate()
            ' Load the combo box element and cache the specified properties and patterns.
            Dim propCondition As New PropertyCondition(AutomationElement.AutomationIdProperty, "comboBox1", PropertyConditionFlags.IgnoreCase)
            elementCombo = elementAppWindow.FindFirst(TreeScope.Descendants, propCondition)

            ' Get the list from the combo box.
            ' <Snippet180> 
            Dim propCondition1 As New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List)
            Dim listElement As AutomationElement = elementCombo.FindFirst(TreeScope.Children, propCondition1)
            ' </Snippet180>

            ' Register for ElementSelectedEvent on list items.
            selectHandler = New AutomationEventHandler(AddressOf OnListItemSelect)
            If (listElement IsNot Nothing) Then
                Automation.AddAutomationEventHandler(SelectionItemPattern.ElementSelectedEvent, listElement, _
                TreeScope.Children, selectHandler)
            End If
        End Using

    End Sub 'SetupComboElement


    ''' <summary>
    ''' Handle ElementSelectedEvent on items in the combo box.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub OnListItemSelect(ByVal src As Object, ByVal e As AutomationEventArgs)
        ' Update the cache.
        Dim updatedElement As AutomationElement = elementCombo.GetUpdatedCache(comboCacheRequest)

        ' Retrieve the pattern and the selected item from the cache. This code is here only to 
        ' demonstrate that the current selection can now be retrieved from the cache. In an application,
        ' this would be done only when the information was needed.
        Dim pattern As SelectionPattern = _
            DirectCast(updatedElement.GetCachedPattern(SelectionPattern.Pattern), SelectionPattern)
        Dim selectedItems As AutomationElement() = pattern.Cached.GetSelection()
        selectedItem = selectedItems(0)

    End Sub 'OnListItemSelect

    ' </Snippet109>

    ' <Snippet119>
    ''' <summary>
    ''' Gets a list box element and caches the Name property of its children (the list items).
    ''' </summary>
    ''' <param name="elementMain">The UI Automation element for the parent window.</param>
    Sub CachePropertiesWithScope(ByVal elementMain As AutomationElement)
        Dim elementList As AutomationElement

        ' Set up the CacheRequest.
        Dim cacheRequest As New CacheRequest()
        cacheRequest.Add(AutomationElement.NameProperty)
        cacheRequest.TreeScope = TreeScope.Element Or TreeScope.Children

        ' Activate the CacheRequest and get the element. Note that the scope of the CacheRequest
        ' is in relation to the object being retrieved: the list box and its children are 
        ' cached, not the main window and its children.
        Using cacheRequest.Activate()
            ' Load the list element and cache the specified properties for its descendants.
            Dim myCondition As New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List)
            elementList = elementMain.FindFirst(TreeScope.Children, myCondition)

            If elementList Is Nothing Then
                Return
            End If

            ' The following illustrates that the children of the list are in the cache.
            Dim listItem As AutomationElement
            For Each listItem In elementList.CachedChildren
                Console.WriteLine(listItem.Cached.Name)
            Next listItem

            ' The following call raises an exception, because the IsEnabled property was not cached.
            '** Console.WriteLine(listItem.Cached.IsEnabled) **

            ' The following illustrates that because the list box itself was cached, it is now
            ' available as the CachedParent of each list item.
            Dim child As AutomationElement = elementList.CachedChildren(0)
            Console.WriteLine(child.CachedParent.Cached.Name)
        End Using
    End Sub 'CachePropertiesWithScope
    ' </Snippet119>
#End Region


#Region "Miscellaneous calls"

    ' <Snippet116>
    ''' <summary>
    ''' Finds all enabled buttons in the specified window element.
    ''' </summary>
    ''' <param name="elementWindowElement">An application or dialog window.</param>
    ''' <returns>A collection of elements that meet the conditions.</returns>
    Function FindByMultipleConditions(ByVal elementWindowElement As AutomationElement) As AutomationElementCollection
        If elementWindowElement Is Nothing Then
            Throw New ArgumentException()
        End If
        Dim conditions As New AndCondition(New PropertyCondition(AutomationElement.IsEnabledProperty, True), New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button))

        ' Find all children that match the specified conditions.
        Dim elementCollection As AutomationElementCollection = elementWindowElement.FindAll(TreeScope.Children, conditions)
        Return elementCollection

    End Function 'FindByMultipleConditions

    ' </Snippet116>
    Sub MiscellaneousCalls(ByVal element As AutomationElement)
        Dim s As String = element.Current.Name

        ' <Snippet111>
        ' element is an AutomationElement.
        Dim id As Integer() = element.GetRuntimeId()
        ' </Snippet111>

        ' <Snippet112>
        ' element is an AutomationElement.
        Dim pt As System.Windows.Point
        Dim clickable As Boolean = element.TryGetClickablePoint(pt)
        ' </Snippet112>

        ' <Snippet179>
        ' element is an AutomationElement.
        Dim clickablePoint As System.Windows.Point = element.GetClickablePoint()
        System.Windows.Forms.Cursor.Position = New System.Drawing.Point(CInt(clickablePoint.X), CInt(clickablePoint.Y))
        ' </Snippet179>


        ' <Snippet114> 
        ' element is an AutomationElement.
        Dim patterns As AutomationPattern() = element.GetSupportedPatterns()
        Dim pattern As AutomationPattern
        For Each pattern In patterns
            Console.WriteLine("ProgrammaticName: " + pattern.ProgrammaticName)
            Console.WriteLine("PatternName: " + Automation.PatternName(pattern))
        Next pattern
        ' </Snippet114>
        ' <Snippet115> 
        Dim properties As AutomationProperty() = element.GetSupportedProperties()
        Dim prop As AutomationProperty
        For Each prop In properties
            Console.WriteLine(prop.ProgrammaticName)
            Console.WriteLine(Automation.PropertyName(prop))
        Next prop
        ' </Snippet115>
        ' <Snippet113> 
        ' element is an AutomationElement.
        Dim objPattern As Object = Nothing
        Dim selPattern As SelectionPattern
        If True = element.TryGetCurrentPattern(SelectionPattern.Pattern, objPattern) Then
            selPattern = DirectCast(objPattern, SelectionPattern)
        End If
        ' </Snippet113>

        Dim elementCollection As AutomationElementCollection = FindByMultipleConditions(MainWindowElement)

        ' <Snippet117>
        ' elementCollection is an AutomationElementCollection.
        Dim elementArray(elementCollection.Count) As AutomationElement
        elementCollection.CopyTo(elementArray, 0)
        ' </Snippet117>

        ' <Snippet118>
        ' elementCollection is an AutomationElementCollection.
        Dim elementUntypedArray(elementCollection.Count) As Object
        elementCollection.CopyTo(elementUntypedArray, 0)
        ' </Snippet118>

        ' <Snippet201> 
        Dim desktopChildren As AutomationElementCollection
        desktopChildren = AutomationElement.RootElement.FindAll( _
            TreeScope.Children, Condition.TrueCondition)
        ' </Snippet201>

        ' <Snippet182>
        ' desktopChildren is a collection of AutomationElement objects.
        Dim firstWindow As AutomationElement
        Try
            firstWindow = desktopChildren(0)
        Catch ex As IndexOutOfRangeException
            Console.WriteLine("No AutomationElement at that index.")
        End Try
        ' </Snippet182>

    End Sub 'MiscellaneousCalls 

#End Region



    Private Sub button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Try
            SelectListItem(ListElement, "Daffodil")
        Catch
            label1.Text = "No UIAutomation target found."
            Return
        End Try

    End Sub

    Private Sub Form1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If False = InitializeUIAutomation() Then
            Application.Exit()
        End If
    End Sub

    Private Sub btnMisc_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMisc.Click
        ' this should all be done on a non-UI thread

        Dim cond As New PropertyCondition(AutomationElement.NameProperty, "Tulip")
        Dim elementListItem As AutomationElement = ListElement.FindFirst(TreeScope.Children, cond)

        cond = New PropertyCondition(AutomationElement.AutomationIdProperty, "btnDisable")
        Dim elementButton As AutomationElement = MainWindowElement.FindFirst(TreeScope.Subtree, cond)
        'SubscribeToInvoke(elementButton)

        'Dim invoker As InvokePattern = DirectCast(elementButton.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
        ' invoker.Invoke()
        Dim elementList As AutomationElement = GetListItemParent(elementListItem)
        Dim s As String = ListElement.Current.Name

        '        SetupComboElement(MainWindowElement)
        MiscellaneousCalls(ListElement)

        'AddListItemToSelection(elementListItem)
        'CachePropertiesByActivate(elementList)
        'CachePropertiesWithScope(MainWindowElement)
        'CachePropertiesByPush(elementList)
        'Dim cs As New ConditionSnips()
        'cs.ConditionExamples(MainWindowElement)
        'cs.AndConditionExample(MainWindowElement)
        'cs.NotConditionExample(MainWindowElement)
        'cs.StaticConditionExamples(MainWindowElement)
        'MiscPropertyCalls(elementList)
        'Dim ps As New PropertySnips()
        'ps.GetAllProperties(elementListItem)
        'Dim treeNode As TreeNode = treeView1.Nodes.Add("Root node")
        'WalkControlElements(MainWindowElement, treeNode)
        'WalkEnabledElements(MainWindowElement, TreeNode)

        '' Property changes
        'cond = New PropertyCondition(AutomationElement.AutomationIdProperty, "btnDisable")
        'elementButton = MainWindowElement.FindFirst(TreeScope.Subtree, cond)

        'ps.SubscribePropertyChange(elementButton)

    End Sub 'btnMisc_Click 

End Class 'Form1

