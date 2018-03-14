 '************************************************************************************************
' *
' * File: ListItemFragment.cs
' *
' * Description: Implements a list item as a fragment within a custom control that supports UI Automation.
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
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Collections




Class MyListItem
    Implements IRawElementProviderSimple
    Implements IRawElementProviderFragment

    Private parentControl As ParentList
    Private parentItems As ArrayList
    Private myText As String = ""
    Private myBounds As Rectangle
    Private amSelected As Boolean
    Private myID As Integer
    Private myIndex As Integer


    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="mainForm">Host form.</param>
    ''' <param name="rect">Position and size of control.</param>
    ''' <param name="ownerControl">Control that parents this one in the UI automation tree.</param>
    Public Sub New(ByVal parent As ParentList, ByVal items As ArrayList, ByVal [text] As String, ByVal myRect As Rectangle)
        myText = [text]
        parentControl = parent
        parentItems = items
        myID = parentItems.Count + 1
        myIndex = parentItems.Count
        myBounds = myRect
    End Sub 'New

    ''' <summary>
    ''' Gets and sets the text of the item.
    ''' </summary>

    Public Property Text() As String
        Get
            Return myText
        End Get
        Set(ByVal value As String)
            myText = value
        End Set
    End Property

    ''' <summary>
    ''' Gets and sets the selected state of this item.
    ''' </summary>
    Public Property Selected() As Boolean
        Get
            Return amSelected
        End Get
        Set(ByVal value As Boolean)
            amSelected = value
        End Set
    End Property

    ''' <summary>
    '''  Gets the index of this item within the list.
    ''' </summary>
    Public ReadOnly Property Index() As Integer
        Get
            Return myIndex
        End Get
    End Property

#Region "IRawElementProviderSimple Members"


    ''' <summary>
    ''' Returns the object that supports the specified pattern.
    ''' </summary>
    ''' <param name="patternId">ID of the pattern.</param>
    ''' <returns>Object that implements IInvokeProvider.</returns>
    Function GetPatternProvider(ByVal patternId As Integer) _
        As Object Implements IRawElementProviderSimple.GetPatternProvider
        Dim ap As AutomationPattern = AutomationPattern.LookupById(patternId)
        If patternId = SelectionItemPatternIdentifiers.Pattern.Id Then
            Return New ListItemPattern(Me, parentControl)
        Else
            Return Nothing
        End If

    End Function 'IRawElementProviderSimple.GetPatternProvider


    ''' <summary>
    ''' Returns UI automation property values.
    ''' </summary>
    ''' <param name="propId">Identifier of the property.</param>
    ''' <returns>The value of the property.</returns>
    Function GetPropertyValue(ByVal propId As Integer) As Object Implements IRawElementProviderSimple.GetPropertyValue
        If propId = AutomationElementIdentifiers.NameProperty.Id Then
            Return Me.Text
        ElseIf propId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
            Return ControlType.ListItem.Id
        ElseIf propId = AutomationElementIdentifiers.IsControlElementProperty.Id Then
            Return True
        ElseIf propId = AutomationElementIdentifiers.IsContentElementProperty.Id Then
            Return True
        ElseIf propId = AutomationElementIdentifiers.RuntimeIdProperty.Id Then
            Return GetRuntimeId()
        ElseIf propId = AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id Then
            Return True
        Else
            Return Nothing
        End If

    End Function 'IRawElementProviderSimple.GetPropertyValue

    ''' <summary>
    ''' Returns a host provider. 
    ''' </summary>
    ''' <remarks>
    ''' In this case, because the element is not directly hosted in a
    ''' window, null is returned.
    ''' </remarks>

    ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple Implements IRawElementProviderSimple.HostRawElementProvider
        Get
            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' Gets provider options.
    ''' </summary>

    ReadOnly Property ProviderOptions() As ProviderOptions Implements IRawElementProviderSimple.ProviderOptions
        Get
            Return ProviderOptions.ServerSideProvider Or ProviderOptions.ProviderOwnsSetFocus
        End Get
    End Property
#End Region

#Region "IRawElementProviderFragment"

    ' <Snippet104>
    ''' <summary>
    ''' Gets the bounding rectangle.
    ''' </summary>

    Public ReadOnly Property BoundingRectangle() As System.Windows.Rect _
        Implements IRawElementProviderFragment.BoundingRectangle
        Get
            Return New System.Windows.Rect(myBounds.X, myBounds.Y, myBounds.Width, myBounds.Height)
        End Get
    End Property
    ' </Snippet104>
    ' <Snippet105>
    ''' <summary>
    ''' Gets the root of this fragment.
    ''' </summary>
    ''' <remarks>
    ''' parentControl is the automation provider for the root fragment. In other cases,
    ''' the parent element might not be the root.
    ''' </remarks>

    Public ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot _
        Implements IRawElementProviderFragment.FragmentRoot

        Get
            Return DirectCast(parentControl, IRawElementProviderFragmentRoot)
        End Get
    End Property

    ' </Snippet105>
    ''' <summary>
    ''' Gets any fragment roots that are embedded in this fragment.
    ''' </summary>
    ''' <returns>Null in this case.</returns>
    Public Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() _
        Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots
        Return Nothing

    End Function 'GetEmbeddedFragmentRoots


    ' <Snippet101>
    ''' <summary>
    ''' Gets the runtime identifier of the UI Automation element.
    ''' </summary>
    ''' <remarks>
    ''' myID is a unique identifier for the item within this instance of the list.
    ''' </remarks>
    Public Function GetRuntimeId() As Integer() _
        Implements IRawElementProviderFragment.GetRuntimeId

        Return New Integer() {AutomationInteropProvider.AppendRuntimeId, myID}

    End Function 'GetRuntimeId

    ' </Snippet101>
    ' <Snippet103>
    ''' <summary>
    ''' Navigate to adjacent elements in the automation tree.
    ''' </summary>
    ''' <param name="direction">Direction to navigate.</param>
    ''' <returns>The element in that direction, or null.</returns>
    ''' <remarks>
    ''' parentControl is the provider for the list box.
    ''' parentItems is the collection of list item providers.
    ''' </remarks>
    Public Function Navigate(ByVal direction As NavigateDirection) As IRawElementProviderFragment _
        Implements IRawElementProviderFragment.Navigate

        Dim myIndex As Integer = parentItems.IndexOf(Me)
        If direction = NavigateDirection.Parent Then
            Return DirectCast(parentControl, IRawElementProviderFragment)
        ElseIf direction = NavigateDirection.NextSibling Then
            If myIndex < parentItems.Count - 1 Then
                Return DirectCast(parentItems((myIndex + 1)), IRawElementProviderFragment)
            Else
                Return Nothing
            End If
        ElseIf direction = NavigateDirection.PreviousSibling Then
            If myIndex > 0 Then
                Return DirectCast(parentItems((myIndex - 1)), IRawElementProviderFragment)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function 'Navigate
    ' </Snippet103>
    ''' <summary>
    ''' Responds to a client request to set the focus to this control. 
    ''' </summary>
    Public Sub SetFocus() _
        Implements IRawElementProviderFragment.SetFocus
        ' Force refresh. This must be done through delegation because it's illegal to 
        ' operate directly on the UI from a different thread.
        Dim args As New PaintEventArgs(parentControl.CreateGraphics(), parentControl.DisplayRectangle)
        Dim handler As PaintEventHandler = AddressOf parentControl.PaintMe
        parentControl.BeginInvoke(handler, New Object() {Me, args})

    End Sub 'SetFocus

#End Region
End Class
