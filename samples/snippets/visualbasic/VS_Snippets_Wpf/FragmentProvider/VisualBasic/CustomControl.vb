'*****************************************************************************
'
' File: CustomControl.vb
'
' Description: 
' 
' A custom list control that supports UI Automation.
'  
' See ProviderForm.cs for a full description of this sample.
' 
' 
'  This file is part of the Microsoft Windows SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
' 
'******************************************************************************
Option Strict Off  ' To prevent warnings with Int function.

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Collections
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Security.Permissions


''' <summary>
''' Values for the state of each list item.
''' </summary>
''' <remarks></remarks>
Public Enum Availability
    Online
    Offline
End Enum 'Availability 

''' <summary>
''' Class for the list control.
''' </summary>
''' <remarks></remarks>
Public Class CustomListControl
    Inherits Control
#Region "Private Members"

    ' Collection of strings that are items in the list.
    Private itemsArray As ArrayList
    ' Index of selected item, or -1 if no item is selected.
    Private currentSelection As Integer = -1
    ' Constraints on list size.
    Private maxNumberOfItems As Integer = 10
    Private minNumberOfItems As Integer = 1
    ' Dimensions of list item.
    Private Const itemHeight As Integer = 15
    Private Const listWidth As Integer = 70
    ' Dimensions of image that signifies item status.
    Private Const imageWidth As Integer = 10
    Private Const imageHeight As Integer = 10
    ' Text indentation to allow room for image.
    Private Const textIndent As Integer = 15

    ' Unique identifier for each list item; never reused 
    ' during the life of the control.
    Private uniqueIdentifier As Integer = 0

    ' The UI Automation provider for this instance of the control.
    Private myListProvider As ListProvider

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' CustomListControl constructor.
    ''' </summary>
    Public Sub New()
        Me.Size = New Size(listWidth, itemHeight * MaximumNumberOfItems)

        ' Initialize list item collection.
        itemsArray = New ArrayList()

    End Sub 'New


    ''' <summary>
    ''' Gets the maximum number of items the list can accommodate. For this example, this is constrained
    ''' by the size of the window so that we do not have to handle scrolling.
    ''' </summary>
    Public ReadOnly Property MaximumNumberOfItems() As Integer
        Get
            Return maxNumberOfItems
        End Get
    End Property

    ''' <summary>
    ''' Gets the minimum number of items the list can accommodate. 
    ''' </summary>
    Public ReadOnly Property MinimumNumberOfItems() As Integer
        Get
            Return minNumberOfItems
        End Get
    End Property

    ''' <summary>
    ''' Gets the unique identifier of a list item. This number is never reused within an instance
    ''' of the control.
    ''' </summary>
    Public ReadOnly Property UniqueId() As Integer
        Get
            uniqueIdentifier += 1
            Return uniqueIdentifier
        End Get
    End Property

    ''' <summary>
    ''' Gets and sets the index of the selected item.
    ''' </summary>
    Public Property SelectedIndex() As Integer
        Get
            Return Me.currentSelection
        End Get
        Set(ByVal value As Integer)
            InternalSelect(value)
        End Set
    End Property


    ''' <summary>
    ''' Gets the item at the specified index.
    ''' </summary>
    ''' <param name="i">The zero-based index of the item.</param>
    ''' <returns>The control for the item.</returns>
    Public Function GetItem(ByVal i As Integer) As CustomListItem
        Return CType(itemsArray(i), CustomListItem)
    End Function 'GetItem

    ''' <summary>
    ''' Gets the number of items in the list.
    ''' </summary>
    Public ReadOnly Property ItemCount() As Integer
        Get
            Return itemsArray.Count
        End Get
    End Property


    ''' <summary>
    ''' Gets the index of the specified item.
    ''' </summary>
    ''' <param name="listItem">The item.</param>
    ''' <returns>The zero-based index.</returns>
    Public Function ItemIndex(ByVal listItem As CustomListItem) As Integer
        ' Allows CustomListItem to requery its index, as it can change.
        Return itemsArray.IndexOf(listItem)
    End Function 'ItemIndex


    ''' <summary>
    ''' Removes an item from the list.
    ''' </summary>
    ''' <param name="itemIndex">Index of the item.</param>
    ''' <returns>true if successful.</returns>
    Public Function Remove(ByVal itemIndex As Integer) As Boolean
        If Me.ItemCount = minNumberOfItems OrElse itemIndex <= -1 OrElse itemIndex >= Me.ItemCount Then
            ' If the number of items in the list is already at minimum,
            ' no additional items can be removed.
            Return False
        End If
        Dim itemToBeRemoved As CustomListItem = CType(itemsArray(itemIndex), CustomListItem)
        itemToBeRemoved.IsAlive = False ' Notification to provider that item it going to be destroyed.
        ' Force refresh.
        Me.Invalidate()

        ' Raise notification.
        If Not (myListProvider Is Nothing) Then
            ListProvider.OnStructureChangeRemove(itemToBeRemoved.Container)
        End If
        itemsArray.RemoveAt(itemIndex)
        currentSelection = 0 ' Reset selection to first item.
        Return True
    End Function 'Remove


    ''' <summary>
    ''' Adds an item to the list.
    ''' </summary>
    ''' <param name="item">Index at which to add the item.</param>
    ''' <param name="a">Item to add.</param>
    ''' <returns>true if successful.</returns>
    Public Function Add(ByVal item As String, ByVal a As Availability) As Boolean
        If itemsArray.Count < maxNumberOfItems Then
            Dim listItem As CustomListItem
            listItem = New CustomListItem(Me, item, Me.UniqueId, a)
            itemsArray.Add(listItem)

            ' Initialize the selection if necessary.
            If currentSelection < 0 Then
                currentSelection = 0
                listItem.IsSelected = True
            End If
            Me.Invalidate() ' Update to draw new added item.

            ' Raise a UI Automation event.
            If Not (myListProvider Is Nothing) Then
                ListProvider.OnStructureChangeAdd(listItem.Container)
            End If
            Return True
        End If
        Return False
    End Function 'Add

#End Region


#Region "Private/Internal methods"

    ''' <summary>
    ''' Responds to GotFocus event by repainting the list.
    ''' </summary>
    ''' <param name="e">Event arguments</param>
    Protected Overrides Sub OnGotFocus(ByVal e As EventArgs)
        OnPaint(New PaintEventArgs(CreateGraphics(), Me.DisplayRectangle))
        MyBase.OnGotFocus(e)
    End Sub 'OnGotFocus


    ''' <summary>
    ''' Responds to LostFocus event by repainting the list.
    ''' </summary>
    ''' <param name="e">Event arguments.</param>
    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
        OnPaint(New PaintEventArgs(CreateGraphics(), Me.DisplayRectangle))
        MyBase.OnLostFocus(e)
    End Sub 'OnLostFocus


    ''' <summary>
    ''' Responds to Paint event.
    ''' </summary>
    ''' <param name="e">Event arguments.</param>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        ' Use SystemBrushes for colors of a control.
        Dim backgroundBrush As System.Drawing.Brush = SystemBrushes.Window
        Dim focusedBrush As System.Drawing.Brush
        If Me.Focused Then
            focusedBrush = SystemBrushes.Highlight
        Else
            focusedBrush = New SolidBrush(Color.DarkGray)
        End If
        e.Graphics.FillRectangle(backgroundBrush, DisplayRectangle)

        ' Colors for online/offline image.
        Dim itemOnBrush As System.Drawing.Brush = Brushes.Green
        Dim itemOffBrush As System.Drawing.Brush = Brushes.Red

        Dim itemTextFont As System.Drawing.Font = SystemFonts.DefaultFont

        Dim itemInk As System.Drawing.Brush = SystemBrushes.ControlText
        Dim selectedItemInk As System.Drawing.Brush = SystemBrushes.HighlightText

        ' Loop through items to draw their text onto screen
        Dim i As Integer
        For i = 0 To itemsArray.Count - 1
            Dim pt As New Point(DisplayRectangle.Left + 2, DisplayRectangle.Top + i * itemHeight)
            Dim listItem As CustomListItem = CType(itemsArray(i), CustomListItem)
            Dim rc As Rectangle = GetDrawingRectForItem(i)
            rc = New Rectangle(rc.X, rc.Y + 2, imageWidth, imageHeight)
            If listItem.Status = Availability.Online Then
                e.Graphics.FillRectangle(itemOnBrush, rc)
            Else
                e.Graphics.FillRectangle(itemOffBrush, rc)
            End If
            rc = New Rectangle(rc.X + textIndent, rc.Y - 2, listWidth - textIndent, itemHeight)
            If i = SelectedIndex Then
                e.Graphics.FillRectangle(focusedBrush, rc)
                e.Graphics.DrawString(listItem.Text, itemTextFont, selectedItemInk, rc)
            Else
                ' Item not selected.
                e.Graphics.DrawString(listItem.Text, itemTextFont, itemInk, rc)
            End If
        Next i
        e.Dispose()
    End Sub 'OnPaint


    ''' <summary>
    ''' Handles MouseDown event by selecting the item under the cursor.
    ''' </summary>
    ''' <param name="e">Event arguments.</param>
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Me.Focus()
        Dim index As Integer = ItemIndexFromPoint(New Point(e.X, e.Y))
        If index <> -1 Then
            InternalSelect(index)
        End If

    End Sub 'OnMouseDown


    ''' <summary>
    ''' Gets the index at the specified screen coordinates.
    ''' </summary>
    ''' <param name="pt">The screen coordinates.</param>
    ''' <returns>The index of the item, or -1 if pt is not within the control.</returns>
    ''' <remarks>This logic is simple because the control does not support scrolling.</remarks>
    Friend Function ItemIndexFromPoint(ByVal pt As Point) As Integer
        ' Determine whether the point is within the control. 
        If Not Me.DisplayRectangle.Contains(pt) Then
            Return -1
        End If

        Dim index As Integer = Int((Me.DisplayRectangle.Y + pt.Y) / itemHeight)
        If index >= itemsArray.Count Then
            index = -1
        End If
        Return index

    End Function 'ItemIndexFromPoint


    ''' <summary>
    ''' Gets the screen coordinates of an item.
    ''' </summary>
    ''' <param name="index">The index of the item.</param>
    ''' <returns>The screen coordinates.</returns>
    Friend Function GetDrawingRectForItem(ByVal index As Integer) As Rectangle
        Dim itemTop As Integer = DisplayRectangle.Top + itemHeight * index + 1
        Return New Rectangle(DisplayRectangle.X, itemTop, DisplayRectangle.Width, itemHeight)

    End Function 'GetRectForItem


    ''' <summary>
    ''' Processes up/down arrow keys.
    ''' </summary>
    ''' <param name="msg">The Windows message.</param>
    ''' <param name="keyData">Information about the key press.</param>
    ''' <returns>true if successful.</returns>
    <PermissionSetAttribute(SecurityAction.Demand, Unrestricted:=True)> _
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Down Then
            If currentSelection < itemsArray.Count - 1 Then
                InternalSelect((currentSelection + 1))
            End If
            Return True

        ElseIf keyData = Keys.Up Then
            If currentSelection > 0 Then
                InternalSelect((currentSelection - 1))
            End If
            Return True
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

    End Function 'ProcessCmdKey


    ''' <summary>
    ''' Selects an item in the list.
    ''' </summary>
    ''' <param name="index">Index of the item to select.</param>
    Private Sub InternalSelect(ByVal index As Integer)
        If index >= itemsArray.Count OrElse index < 0 Then
            Throw New ArgumentOutOfRangeException()
        Else
            If currentSelection <> index Then
                ' Deselect previous selection.

                Dim listItem As CustomListItem = CType(itemsArray(currentSelection), CustomListItem)
                listItem.IsSelected = False
                ' Select new selection.

                listItem = CType(itemsArray(index), CustomListItem)
                listItem.IsSelected = True
                currentSelection = index

                ' Force refresh.
                Invalidate()

                ' Raise  a selection-changed event.
                ListProvider.OnSelectionChange(CType(itemsArray(index), CustomListItem))
            End If

            ' Raise a focus-changed event.
            ListProvider.OnFocusChange(CType(itemsArray(index), CustomListItem))
        End If

    End Sub 'InternalSelect

#End Region


#Region "UI Automation related methods" '

    ''' <summary>
    ''' Gets the UI Automation provider for the control.
    ''' </summary>
    Public ReadOnly Property Provider() As ListProvider
        Get
            Return myListProvider
        End Get
    End Property

    ''' <summary>
    ''' Gets a value that specifies whether the UI Automation provider is attached.
    ''' </summary>
    Protected ReadOnly Property AutomationIsActive() As Boolean
        Get
            Return Not (myListProvider Is Nothing)
        End Get
    End Property


    ''' <summary>
    ''' Handles WM_GETOBJECT message; others are passed to base handler.
    ''' </summary>
    ''' <param name="winMessage">Windows message.</param>
    ''' <remarks>This method enables UI Automation to find the control.</remarks>
    <PermissionSetAttribute(SecurityAction.Demand, Unrestricted:=True)> _
    Protected Overrides Sub WndProc(ByRef winMessage As Message)
        Const WM_GETOBJECT As Integer = &H3D
        If winMessage.Msg = WM_GETOBJECT Then
            If Not AutomationIsActive Then
                ' If no provider has been created, then create one.
                myListProvider = New ListProvider(Me)

                ' Create providers for each existing item in the list.
                Dim listItem As CustomListItem
                For Each listItem In itemsArray
                    listItem.Provider = New ListItemProvider(myListProvider, listItem)
                Next listItem
            End If

            winMessage.Result = AutomationInteropProvider.ReturnRawElementProvider( _
                Handle, winMessage.WParam, winMessage.LParam, myListProvider)
            Return
        End If
        MyBase.WndProc(winMessage)

    End Sub 'WndProc

#End Region

End Class 'CustomListControl 

''' <summary>
''' Class for the list items controls.
''' </summary>
Public Class CustomListItem
    Private ItemIsSelected As Boolean = False
    Private ItemText As String
    Private ItemIndex As Integer
    Private ItemOwnerList As CustomListControl
    Private ItemStatus As Availability
    Private ItemId As Integer
    Private ItemProvider As ListItemProvider
    Private ItemRect As Rectangle
    Private ItemIsAlive As Boolean


    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="parent">The owning list.
    ''' </param>
    ''' <param name="text">The text of the item.
    ''' </param>
    ''' <param name="id">The unique identifier of the item within the list.
    ''' </param>
    ''' <param name="availability">The status (online or offline) of the item.
    ''' </param>
    Public Sub New(ByVal parent As CustomListControl, ByVal [text] As String, _
        ByVal id As Integer, ByVal availability As Availability)

        ItemIsAlive = True
        ItemOwnerList = parent
        ItemText = [text]
        ItemId = id
        ItemStatus = availability
    End Sub 'New

    ''' <summary>
    ''' Gets and sets the status of the item (alive if it is still displayed).
    ''' </summary>
    Public Property IsAlive() As Boolean
        Get
            Return ItemIsAlive
        End Get

        Set(ByVal value As Boolean)
            ItemIsAlive = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the CustomListControl that contains this item.
    ''' </summary>
    Public ReadOnly Property Container() As CustomListControl
        Get
            Return ItemOwnerList
        End Get
    End Property

    ''' <summary>
    ''' Gets and sets the selection status of the item.
    ''' </summary>
    Public Property IsSelected() As Boolean
        Get
            Return ItemIsSelected
        End Get
        Set(ByVal value As Boolean)
            ItemIsSelected = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the unique identifier of the item within the list.
    ''' </summary>
    Public ReadOnly Property Id() As Integer
        Get
            Return ItemId
        End Get
    End Property

    ''' <summary>
    ''' Gets the screen coordinates of the rectangle for a list item.
    ''' </summary>
    Public Sub GetItemRectangle()
        Dim temp As System.Drawing.Rectangle = _
            Me.ItemOwnerList.GetDrawingRectForItem(Me.Index)
        ItemRect = Me.ItemOwnerList.RectangleToScreen(temp)
    End Sub


    ''' <summary>
    ''' Gets the location of the item on the screen.
    ''' </summary>
    ''' <remarks>
    ''' Uses delegation to avoid interacting with the UI on a different thread.
    ''' </remarks>
    Public ReadOnly Property Location() As Rectangle
        Get
            Me.ItemOwnerList.Invoke(New MethodInvoker(AddressOf GetItemRectangle))
            Return ItemRect
        End Get
    End Property

    ''' <summary>
    ''' Gets and sets the text of the item.
    ''' </summary>
    Public Property [Text]() As String
        Get
            Return ItemText
        End Get
        Set(ByVal value As String)
            ItemText = value
        End Set
    End Property

    ''' <summary>
    ''' Gets and sets the index of the item.
    ''' </summary>
    Public Property Index() As Integer
        Get
            ItemIndex = ItemOwnerList.ItemIndex(Me)
            Return ItemIndex
        End Get
        Set(ByVal value As Integer)
            ItemIndex = value
        End Set
    End Property

    ''' <summary>
    ''' Gets and sets the status (online or offline) of the item.
    ''' </summary>
    Public Property Status() As Availability
        Get
            Return ItemStatus
        End Get
        Set(ByVal value As Availability)
            ItemStatus = value
        End Set
    End Property


    ''' <summary>
    ''' Gets and sets the UI Automation provider for the item.
    ''' </summary>
    Public Property Provider() As ListItemProvider
        Get
            If ItemProvider Is Nothing Then
                ItemProvider = New ListItemProvider(ItemOwnerList.Provider, Me)
            End If
            Return ItemProvider
        End Get
        Set(ByVal value As ListItemProvider)
            ItemProvider = value
        End Set
    End Property
End Class 'CustomListItem 
