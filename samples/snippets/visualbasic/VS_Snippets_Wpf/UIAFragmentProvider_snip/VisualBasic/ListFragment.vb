
'************************************************************************************************
' *
' * File: ListFragment.cs
' *
' * Description: Implements a custom control that supports UI Automation.
' * 
' * The control is a simple list box that manages its own items. Its primary purpose is to demonstrate how to 
' * implement a root fragment (the list box itself) and child fragments (the list items) for UI Automation. 
' * The functionality of the control itself is very limited: it will display a small number of text items 
' * and manage the selection by processing mouse clicks and arrow keys. The only control patterns it supports 
' * are SelectionPattern and SelectionItemPattern. A list box in a real application would support more patterns
' * such as ValuePattern and ScrollPattern.
' * 
' * See ProviderForm.cs for a full description of this sample.
' *   
' * 
' *  This file is part of the Microsoft WinfFX SDK Code Samples.
' * 
' *  Copyright (C) Microsoft Corporation.  All rights reserved.
' * 
' * This source code is intended only as a supplement to Microsoft
' * Development Tools and/or on-line documentation.  See these other
' * materials for detailed information regarding Microsoft code samples.
' * 
' * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' * PARTICULAR PURPOSE.
' * 
' ************************************************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Collections




Class ParentList
    Inherits Control
    Implements IRawElementProviderSimple
    Implements IRawElementProviderFragment
    Implements IRawElementProviderFragmentRoot
    Implements IRawElementProviderAdviseEvents
    Private myHandle As IntPtr
    Public myItems As ArrayList
    Private mySelection As Integer
    Private Const itemHeight As Integer = 15

#Region "Public methods"

    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="mainForm">Host form.</param>
    ''' <param name="rect">Position and size of control.</param>
    Public Sub New(ByVal mainForm As Form, ByVal x As Integer, ByVal y As Integer)
        Me.Location = New Point(x, y)
        Me.Size = New Size(70, itemHeight + 2)

        ' Create an instance of the child control.
        Dim controlRect1 As New Rectangle(Me.Left, Me.Bottom + 1, 100, 50)

        ' Save the handle in a member, because we're not allowed to access the UI thread
        ' to get the property when we need it.
        myHandle = Me.Handle

        TabStop = True

        ' Initialize list item collection.
        myItems = New ArrayList()
        SelectItem(-1)

    End Sub


    ' <Snippet122>
    ''' <summary>
    ''' Raises an event when a control is invoked.
    ''' </summary>
    ''' <param name="provider">The UI Automation provider for the control.</param>
    Private Sub RaiseInvokeEvent(ByVal provider As IRawElementProviderSimple)
        If AutomationInteropProvider.ClientsAreListening Then
            Dim args As New AutomationEventArgs(InvokePatternIdentifiers.InvokedEvent)
            AutomationInteropProvider.RaiseAutomationEvent(InvokePatternIdentifiers.InvokedEvent, provider, args)
        End If

    End Sub

    ' </Snippet122>

    ' <Snippet123>
    ''' <summary>
    ''' Raises an event when the IsEnabled property on a control is changed.
    ''' </summary>
    ''' <param name="provider">The UI Automation provider for the control.</param>
    ''' <param name="newValue">The current enabled state.</param>
    Private Sub RaiseEnabledEvent(ByVal provider As IRawElementProviderSimple, ByVal newValue As Boolean)
        If AutomationInteropProvider.ClientsAreListening Then
            Dim args As New AutomationPropertyChangedEventArgs(AutomationElement.IsEnabledProperty, Not newValue, newValue)
            AutomationInteropProvider.RaiseAutomationPropertyChangedEvent(provider, args)
        End If

    End Sub

    ' </Snippet123>
    ''' <summary>
    ''' Add an item to the list.
    ''' </summary>
    ''' <param name="text">Item to add.</param>
    ''' <returns>Index of the added item.</returns>
    Public Function Add(ByVal itemText As String) As Integer
        ' Dynamically resize the control. To keep things simple for this example,
        ' it is assumed that there will be no need for scrolling.
        If myItems.Count > 0 Then
            Me.Height += itemHeight
        End If

        ' Initialize the selection.
        If mySelection < 0 Then
            mySelection = 0
        End If

        ' Create the item and add it.
        Dim itemTop As Integer = DisplayRectangle.Top + 1 + (itemHeight * myItems.Count)
        Dim itemLeft As Integer = DisplayRectangle.Left + 1
        Dim itemWidth As Integer = DisplayRectangle.Width - 2

        Dim listItem As New MyListItem(Me, myItems, itemText, New Rectangle(itemTop, itemLeft, itemWidth, itemHeight))
        Return myItems.Add(listItem)

    End Function 'Add


    ' DON'T USE THIS SNIPPET -- PROBABLY NOT RAISING CORRECT EVENTS
    ' <Snippet118>  
    ''' <summary>
    ''' Selects an item in the myItems collection.
    ''' </summary>
    ''' <param name="index">Index of the selected item.</param>
    ''' <remarks>
    ''' This is a single-selection list whose current selection is stored
    ''' internally in mySelection.
    ''' MyListItem is the provider class for list items.
    ''' </remarks>
    Public Sub SelectItem(ByVal index As Integer)

        If index >= myItems.Count Then
            Throw New ArgumentOutOfRangeException()
        ElseIf index < 0 Then
            mySelection = -1
            Return
            ' If within range, clear the Selected property on the current item 
            ' and set it on the new item.
        Else
            Dim newItem As MyListItem
            Dim oldItem As MyListItem = Nothing

            ' Deselect old item, if there is one; list might not be initialized.
            If mySelection >= 0 Then
                oldItem = DirectCast(myItems(mySelection), MyListItem)
                oldItem.Selected = False
            End If
            mySelection = index
            newItem = DirectCast(myItems(mySelection), MyListItem)
            newItem.Selected = True
            ' Raise events that clients can receive.
            If AutomationInteropProvider.ClientsAreListening Then
                ' Generic event for selection made.
                Dim args As New AutomationEventArgs(SelectionItemPatternIdentifiers.ElementSelectedEvent)
                AutomationInteropProvider.RaiseAutomationEvent(SelectionItemPattern.ElementSelectedEvent, DirectCast(myItems(mySelection), IRawElementProviderSimple), args)

                ' Property-changed event for old item's Selection property.
                Dim propArgs As AutomationPropertyChangedEventArgs
                If Not (oldItem Is Nothing) Then
                    propArgs = New AutomationPropertyChangedEventArgs(SelectionItemPatternIdentifiers.IsSelectedProperty, True, False)
                    AutomationInteropProvider.RaiseAutomationPropertyChangedEvent(oldItem, propArgs)
                End If

                ' Property-changed event for new item's Selection property.
                propArgs = New AutomationPropertyChangedEventArgs(SelectionItemPatternIdentifiers.IsSelectedProperty, False, True)
                AutomationInteropProvider.RaiseAutomationPropertyChangedEvent(newItem, propArgs)
            End If
        End If

    End Sub
    ' </Snippet118>      
#End Region


#Region "Control method overrides"

    ' <Snippet116>
    ''' <summary>
    ''' Handles WM_GETOBJECT message; others are passed to base handler.
    ''' </summary>
    ''' <param name="m">Windows message.</param>
    ''' <remarks>
    ''' This method enables UI Automation to find the control.
    ''' In this example, the implementation of IRawElementProvider is in the same class
    ''' as this method.
    ''' </remarks>
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_GETOBJECT As Integer = &H3D

        If m.Msg = WM_GETOBJECT AndAlso CInt(CLng(m.LParam)) = AutomationInteropProvider.RootObjectId Then
            m.Result = AutomationInteropProvider.ReturnRawElementProvider(Me.Handle, m.WParam, m.LParam, DirectCast(Me, IRawElementProviderSimple))
            Return
        End If
        MyBase.WndProc(m)

    End Sub

    ' </Snippet116>
    ''' <summary>
    ''' Responds to GotFocus event by repainting the list.
    ''' </summary>
    ''' <param name="e">Event arguments.</param>
    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
        OnPaint(New PaintEventArgs(CreateGraphics(), Me.DisplayRectangle))
        MyBase.OnGotFocus(e)

    End Sub


    ''' <summary>
    ''' Responds to LostFocus event by repainting the list.
    ''' </summary>
    ''' <param name="e">Event arguments.</param>
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
        OnPaint(New PaintEventArgs(CreateGraphics(), Me.DisplayRectangle))
        MyBase.OnLostFocus(e)

    End Sub


    ''' <summary>
    ''' Delegate event handler that can be invoked from another thread.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="args">Event arguments.</param>
    Public Sub PaintMe(ByVal sender As [Object], ByVal args As PaintEventArgs)
        OnPaint(args)

    End Sub


    ''' <summary>
    ''' Handles Paint event.
    ''' </summary>
    ''' <param name="e">Event arguments.</param>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        ' Background.
        Dim brush As New SolidBrush(Color.White)
        e.Graphics.FillRectangle(brush, DisplayRectangle)

        ' Border.
        Dim borderWidth As Integer = 2
        Dim pen As New Pen(Color.Black, borderWidth)
        e.Graphics.DrawRectangle(pen, DisplayRectangle)

        ' Items.
        Dim textFont As New Font(FontFamily.GenericSansSerif, 10)
        Dim ink As New SolidBrush(Color.Black)
        Dim count As Integer = 0

        Dim item As MyListItem
        For Each item In myItems
            Dim upperLeft As New Point(DisplayRectangle.Left, DisplayRectangle.Top + count * itemHeight)
            If count = SelectedIndex Then
                ink.Color = Color.Red
                ' If the listbox has focus, paint the item background.
                If Me.Focused Then
                    brush.Color = Color.LightGray
                    Dim itemTop As Integer = DisplayRectangle.Top + 1 + (itemHeight * count)
                    e.Graphics.FillRectangle(brush, DisplayRectangle.X + 1, itemTop, DisplayRectangle.Width - 2, itemHeight)
                End If
            Else
                ink.Color = Color.Black
            End If
            e.Graphics.DrawString(item.Text, textFont, ink, upperLeft)
            count += 1
        Next item
        e.Dispose()

    End Sub


    ''' <summary>
    ''' Handles MouseDown event by selecting the item under the cursor.
    ''' </summary>
    ''' <param name="e">Event arguments.</param>
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Me.Focus()
        Dim targetPoint As New Point(e.X, e.Y)
        Dim index As Integer = CInt((Me.DisplayRectangle.Y + e.Y) \ itemHeight)
        If index < myItems.Count Then
            SelectItem(index)
            Me.Refresh()
        End If

    End Sub


    ''' <summary>
    ''' Process up/down arrow keys.
    ''' </summary>
    ''' <param name="msg">Windows message.</param>
    ''' <param name="keyData">Information about the pressed key.</param>
    ''' <returns></returns>
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Down Then
            If Me.SelectedIndex < myItems.Count - 1 Then
                SelectItem((SelectedIndex + 1))
                Refresh()
            End If
            Return True

        ElseIf keyData = Keys.Up Then
            If Me.SelectedIndex > 0 Then
                SelectItem((SelectedIndex - 1))
                Refresh()
            End If
            Return True
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function 'ProcessCmdKey 

#End Region

#Region "Properties"

    ''' <summary>
    ''' Gets and sets the index of the selected list item.
    ''' </summary>
    ''' <remarks>-1 means there is no selection.</remarks>
    Public ReadOnly Property SelectedIndex() As Integer
        Get
            Return mySelection
        End Get
    End Property

#End Region



#Region "IRawElementProviderSimple"

    ' <Snippet120>
    ''' <summary>
    ''' Returns the object that supports the specified pattern.
    ''' </summary>
    ''' <param name="patternId">ID of the pattern.</param>
    ''' <returns>Object that implements IInvokeProvider.</returns>
    ''' <remarks>
    ''' In this case, the ISelectionProvider interface is implemented in another provider-defined class, 
    ''' ListPattern. However, it could be implemented in the base provider class, in which case the 
    ''' method would simply return "this".
    ''' </remarks>
    Function GetPatternProvider(ByVal patternId As Integer) As Object _
        Implements IRawElementProviderSimple.GetPatternProvider

        If patternId = SelectionPatternIdentifiers.Pattern.Id Then
            Return New ListPattern(myItems, SelectedIndex)
        Else
            Return Nothing
        End If

    End Function 'IRawElementProviderSimple.GetPatternProvider
    ' </Snippet120>

    ' <Snippet117>
    ''' <summary>
    ''' Gets provider property values.
    ''' </summary>
    ''' <param name="propId">Property identifier.</param>
    ''' <returns>The value of the property.</returns>
    Function GetPropertyValue(ByVal propId As Integer) As Object _
        Implements IRawElementProviderSimple.GetPropertyValue

        If propId = AutomationElementIdentifiers.NameProperty.Id Then
            Return "Custom list control"
        ElseIf propId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
            Return ControlType.List.Id
        ElseIf propId = AutomationElementIdentifiers.IsContentElementProperty.Id Then
            Return True
        ElseIf propId = AutomationElementIdentifiers.IsControlElementProperty.Id Then
            Return True
        Else
            Return Nothing
        End If
    End Function 'IRawElementProviderSimple.GetPropertyValue
    ' </Snippet117>


    ' <Snippet121>
    ''' <summary>
    ''' Gets the host provider.
    ''' </summary>
    ''' <remarks>
    ''' Fragment roots return their window providers; most others return null.
    ''' </remarks>
    ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple _
        Implements IRawElementProviderSimple.HostRawElementProvider

        Get
            Return AutomationInteropProvider.HostProviderFromHandle(myHandle)
        End Get
    End Property
    ' </Snippet121>


    ''' <summary>
    ''' Gets provider options.
    ''' </summary>
    ReadOnly Property ProviderOptions() As ProviderOptions _
        Implements IRawElementProviderSimple.ProviderOptions

        Get
            Return ProviderOptions.ServerSideProvider
        End Get
    End Property

#End Region

#Region "IRawElementProviderFragment"

    ''' <summary>
    ''' Gets the bounding rectangle.
    ''' </summary>
    ''' <remarks>Fragment roots should return an empty rectangle.</remarks>
    ReadOnly Property BoundingRectangle() As System.Windows.Rect _
        Implements IRawElementProviderFragment.BoundingRectangle

        Get
            Return System.Windows.Rect.Empty
        End Get
    End Property

    ''' <summary>
    ''' Gets the root of this fragment.
    ''' </summary>
    ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot _
        Implements IRawElementProviderFragment.FragmentRoot

        Get
            Return Me
        End Get
    End Property


    ''' <summary>
    ''' Gets any fragment roots that are embedded in this fragment.
    ''' </summary>
    ''' <returns>Null in this case.</returns>
    Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() _
        Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots

        Return Nothing
    End Function 'IRawElementProviderFragment.GetEmbeddedFragmentRoots


    ''' <summary>
    ''' Gets the runtime identifier of the UI Automation element.
    ''' </summary>
    ''' <returns>Fragement roots return null.</returns>
    Function GetRuntimeId() As Integer() _
        Implements IRawElementProviderFragment.GetRuntimeId
        Return Nothing
    End Function 'IRawElementProviderFragment.GetRuntimeId


    ' <Snippet102>
    ''' <summary>
    ''' Navigates to adjacent elements in the automation tree.
    ''' </summary>
    ''' <param name="direction">Direction of navigation.</param>
    ''' <returns>The element in that direction, or null.</returns>
    ''' <remarks>myItems is the collection of items in the list.</remarks>
    Function Navigate(ByVal direction As NavigateDirection) As IRawElementProviderFragment _
        Implements IRawElementProviderFragment.Navigate

        If direction = NavigateDirection.FirstChild Then
            Return DirectCast(myItems(0), IRawElementProviderFragment)
        ElseIf direction = NavigateDirection.LastChild Then
            Return DirectCast(myItems((myItems.Count - 1)), IRawElementProviderFragment)
        Else
            Return Nothing
        End If
    End Function 'IRawElementProviderFragment.Navigate

    ' </Snippet102>
    ''' <summary>
    ''' Responds to a client request to set the focus to this control.
    ''' </summary>
    ''' <remarks>Setting focus to the control is handled by the parent window.</remarks>
    Sub SetFocus() _
        Implements IRawElementProviderFragment.SetFocus

        Throw New Exception("The method is not implemented.")
    End Sub

#End Region


#Region "IRawElementProviderFragmentRoot"

    ' <Snippet106>
    Delegate Function MyDelegate(ByVal clientRect As Rectangle) As Rectangle

    ''' <summary>
    ''' Gets the child element that is at the specified point.
    ''' </summary>
    ''' <param name="x">Distance from the left of the application window.</param>
    ''' <param name="y">Distance from the top of the application window.</param>
    ''' <returns>The provider for the element at that point.</returns>
    Function ElementProviderFromPoint(ByVal x As Double, ByVal y As Double) As IRawElementProviderFragment _
        Implements IRawElementProviderFragmentRoot.ElementProviderFromPoint

        Dim pointX As Integer = CInt(x)
        Dim pointY As Integer = CInt(y)

        ' The RectangleToScreen method on the control can't be called directly from 
        ' this thread, so use delegation.
        Dim converterDelegate As MyDelegate = New MyDelegate(AddressOf Me.RectangleToScreen)
        Dim screenRectangle As Rectangle = DirectCast(Me.Invoke(converterDelegate, _
            New Object() {Me.DisplayRectangle}), Rectangle)
        If screenRectangle.Contains(pointX, pointY) Then
            Dim index As Integer = CInt((pointY - screenRectangle.Y) \ itemHeight)
            If index < myItems.Count Then
                Return DirectCast(myItems(index), IRawElementProviderFragment)
            Else
                Return DirectCast(Me, IRawElementProviderFragment)
            End If
        Else
            Return Nothing
        End If
    End Function
    ' </Snippet106>

    ' <Snippet107>
    ''' <summary>
    ''' Returns the child element that is selected when the list gets focus.
    ''' </summary>
    ''' <returns>The selected item.</returns>
    ''' <remarks>
    ''' SelectedIndex is a class property that maintains the index of the currently
    ''' selected item in the myItems collection.</remarks>
    Function GetFocus() As IRawElementProviderFragment _
        Implements IRawElementProviderFragmentRoot.GetFocus

        If SelectedIndex >= 0 Then
            Return DirectCast(myItems(SelectedIndex), IRawElementProviderFragment)
        Else
            Return Nothing
        End If
    End Function 'IRawElementProviderFragmentRoot.GetFocus 
    ' </Snippet107>

#End Region

#Region "IRawElementProviderAdviseEvents"

    Dim subscribedProperties As ArrayList = New ArrayList()

    ' <Snippet124> 
    Sub AdviseEventAdded(ByVal eventId As Integer, ByVal properties() As Integer) _
        Implements IRawElementProviderAdviseEvents.AdviseEventAdded

        If eventId = AutomationElement.AutomationPropertyChangedEvent.Id Then
            For Each i As Integer In properties
                Dim autoProperty As AutomationProperty = AutomationProperty.LookupById(i)
                ' Add to an ArrayList.
                subscribedProperties.Add(autoProperty)
            Next
        End If

    End Sub
    ' </Snippet124>



    ' <Snippet125>
    Sub AdviseEventRemoved(ByVal eventId As Integer, ByVal properties() As Integer) _
        Implements IRawElementProviderAdviseEvents.AdviseEventRemoved

        If eventId = AutomationElement.AutomationPropertyChangedEvent.Id Then
            For Each i As Integer In properties
                Dim autoProperty As AutomationProperty = AutomationProperty.LookupById(i)
                ' Remove from ArrayList.
                subscribedProperties.Remove(autoProperty)
            Next
        End If

    End Sub
    ' </Snippet125>


#End Region

End Class
