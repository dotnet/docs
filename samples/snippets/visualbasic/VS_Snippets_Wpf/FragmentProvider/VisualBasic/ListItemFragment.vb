'*****************************************************************************
'
' File: ListItemFragment.vb
'
' Description: Implements a list item as a fragment within a custom control 
' that supports UI Automation.
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
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Collections



Public Class ListItemProvider
    Implements IRawElementProviderFragment, ISelectionItemProvider
    ' Provider for the list that contains the item.
    Private ContainingListProvider As ListProvider
    ' Control that contains the list.
    Private ListItemControl As CustomListItem
    
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="rootProvider">UI Automation provider for the 
    ''' fragment root (the containing list).</param>
    ''' <param name="thisItem">The control that owns this provider.</param>
    Public Sub New(ByVal rootProvider As ListProvider, ByVal thisItem As CustomListItem)
        ContainingListProvider = rootProvider
        ListItemControl = thisItem

    End Sub 'New


    ''' <summary>
    ''' Gets the index of the item within the list.
    ''' </summary>
    
    Public ReadOnly Property Index() As Integer 
        Get
            Return ListItemControl.Index
        End Get
    End Property
    
    
    #Region "IRawElementProviderSimple Members"
    
    
    ''' <summary>
    ''' Retrieves the object that supports the specified control pattern.
    ''' </summary>
    ''' <param name="patternId">The pattern identifier</param>
    ''' <returns>
    ''' The supporting object, or null if the pattern is not supported.
    ''' </returns>
    Public Function GetPatternProvider(ByVal patternId As Integer) As Object _
        Implements IRawElementProviderSimple.GetPatternProvider

        If patternId = SelectionItemPatternIdentifiers.Pattern.Id Then
            Return Me
        End If
        Return Nothing

    End Function 'GetPatternProvider


    ''' <summary>
    ''' Returns UI Automation property values.
    ''' </summary>
    ''' <param name="propId">The identifier of the property.</param>
    ''' <returns>The value of the property.</returns>
    Public Function GetPropertyValue(ByVal propId As Integer) As Object _
        Implements IRawElementProviderSimple.GetPropertyValue

        If ListItemControl.IsAlive = False Then
            Throw New ElementNotAvailableException()
        End If
        If propId = AutomationElementIdentifiers.NameProperty.Id Then
            Return ListItemControl.Text
        ElseIf propId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
            Return ControlType.ListItem.Id
        ElseIf propId = AutomationElementIdentifiers.AutomationIdProperty.Id Then
            Return ListItemControl.Id.ToString()
        ElseIf propId = AutomationElementIdentifiers.HasKeyboardFocusProperty.Id Then
            Return ListItemControl.IsSelected
        ElseIf propId = AutomationElementIdentifiers.ItemStatusProperty.Id Then
            If ListItemControl.Status = Availability.Online Then
                Return "Contact is online"
            Else
                Return "Contact is offline"
            End If
        ElseIf propId = AutomationElementIdentifiers.IsEnabledProperty.Id Then
            Return True
        ElseIf propId = AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id Then
            Return True
        ElseIf propId = AutomationElementIdentifiers.FrameworkIdProperty.Id Then
            Return "Custom"
        End If
        Return Nothing

    End Function 'GetPropertyValue
    
    ''' <summary>
    ''' Returns a host provider. 
    ''' </summary>
    ''' <remarks>
    ''' In this case, because the element is not directly hosted in a
    ''' window, null is returned.
    ''' </remarks>
    Public ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple _
        Implements IRawElementProviderSimple.HostRawElementProvider

        Get
            ' Because the element is not directly hosted in a window, null is returned.
            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' Gets provider options.
    ''' </summary>
    Public ReadOnly Property ProviderOptions() As ProviderOptions _
        Implements IRawElementProviderSimple.ProviderOptions

        Get
            Return ProviderOptions.ServerSideProvider
        End Get
    End Property
    
    #End Region

    #Region "IRawElementProviderFragment Members" '

    ''' <summary>
    ''' Gets the bounding rectangle, in screen coordinates.
    ''' </summary>
    Public ReadOnly Property BoundingRectangle() As System.Windows.Rect _
        Implements IRawElementProviderFragment.BoundingRectangle

        Get
            Dim rc As Rectangle = Me.ListItemControl.Location
            Return New System.Windows.Rect(rc.X, rc.Y, rc.Width, rc.Height)
        End Get
    End Property

    ''' <summary>
    ''' Gets the root of this fragment.
    ''' </summary>
    Public ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot _
        Implements IRawElementProviderFragment.FragmentRoot

        Get
            Return ContainingListProvider
        End Get
    End Property
    
    
    ''' <summary>
    ''' Gets any fragment roots that are embedded in this fragment.
    ''' </summary>
    ''' <returns>Null in this case.</returns>
    Public Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() _
        Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots

        Return Nothing
    End Function 'GetEmbeddedFragmentRoots
    
    
    ''' <summary>
    ''' Gets the runtime identifier of the UI Automation element.
    ''' </summary>
    ''' <returns>An array of integers.</returns>
    Public Function GetRuntimeId() As Integer() _
        Implements IRawElementProviderFragment.GetRuntimeId

        Return New Integer() {AutomationInteropProvider.AppendRuntimeId, ListItemControl.Id}
    End Function 'GetRuntimeId
    
    
    ''' <summary>
    ''' Navigate to adjacent elements in the UI Automation tree.
    ''' </summary>
    ''' <param name="direction">Direction to navigate.</param>
    ''' <returns>The element in that direction, or null.</returns>
    Public Function Navigate(ByVal direction As NavigateDirection) _
        As IRawElementProviderFragment _
        Implements IRawElementProviderFragment.Navigate

        If direction = NavigateDirection.Parent Then
            Return ContainingListProvider
        ElseIf direction = NavigateDirection.NextSibling Then
            Return ContainingListProvider.GetProviderForIndex(ListItemControl.Index + 1)
        ElseIf direction = NavigateDirection.PreviousSibling Then
            Return ContainingListProvider.GetProviderForIndex(ListItemControl.Index - 1)
        End If
        Return Nothing
    End Function 'Navigate



    ''' <summary>
    ''' Responds to a client request to set the focus to this control. 
    ''' </summary>
    Public Sub SetFocus() Implements IRawElementProviderFragment.SetFocus

        If ListItemControl.IsAlive = False Then
            Throw New ElementNotAvailableException()
        End If
        ListItemControl.Container.SelectedIndex = Index
    End Sub 'SetFocus
    
    #End Region

    #Region "ISelectionItemProvider Members"

    ''' <summary>
    ''' Adds an item to the selection in list boxes that support multiple 
    ''' selection.
    ''' </summary>
    Public Sub AddToSelection() Implements ISelectionItemProvider.AddToSelection
        Throw New InvalidOperationException("Multiple selection is not supported.")
    End Sub 'AddToSelection

    ''' <summary>
    ''' Specifies whether the item is selected.
    ''' </summary>
    Public ReadOnly Property IsSelected() As Boolean Implements ISelectionItemProvider.IsSelected
        Get
            Return Me.ListItemControl.IsSelected
        End Get
    End Property
    
    
    ''' <summary>
    ''' Removes the item from the selection in list boxes that support 
    ''' multiple selection or no selection at all.
    ''' </summary>
    Public Sub RemoveFromSelection() Implements ISelectionItemProvider.RemoveFromSelection
        Throw New InvalidOperationException("Selection is required for this control.")
    End Sub 'RemoveFromSelection
    
    
    ''' <summary>
    ''' Selects the item.
    ''' </summary>
    Public Sub Select1() Implements ISelectionItemProvider.Select
        ' For this list box, Focus and Selection are the same.
        SetFocus()
    End Sub 'Select

    ''' <summary>
    ''' Gets the list box that contains the item.
    ''' </summary>
    Public ReadOnly Property SelectionContainer() As IRawElementProviderSimple _
        Implements ISelectionItemProvider.SelectionContainer
        Get
            Return ContainingListProvider
        End Get
    End Property
    
    #End Region

End Class 'ListItemProvider 
