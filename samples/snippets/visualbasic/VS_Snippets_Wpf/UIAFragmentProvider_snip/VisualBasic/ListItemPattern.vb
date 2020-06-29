'************************************************************************************************
' *
' * File: ListItemPattern.cs
' *
' * Description: Implements ISelectionItemProvider for items in the custom list box,
' * to support SelectionItemPattern in client applications.
' * 
' * See ProviderForm.cs in the ElementProvider project for a full description of this sample.
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
Imports System.Windows.Automation
Imports System.Windows.Automation.Provider
Imports System.Collections



Class ListItemPattern
    Implements ISelectionItemProvider
    Private myListItem As MyListItem
    Private parentList As ParentList
    Private selectedItems As ArrayList


    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="listItem">Item for which this pattern is implemented.</param>
    ''' <param name="parent">List that contains the item.</param>
    Public Sub New(ByVal listItem As MyListItem, ByVal parent As ParentList)
        myListItem = listItem
        parentList = parent
        selectedItems = New ArrayList()

    End Sub

#Region "ISelectionItemProvider"


    ''' <summary>
    ''' Adds an item to the selection in list boxes that support multiple selection.
    ''' </summary>
    ' <Snippet111>
    Public Sub AddToSelection() _
        Implements ISelectionItemProvider.AddToSelection

        selectedItems.Add(Me)

    End Sub
    ' </Snippet111>
    ''' <summary>
    ''' Specifies whether the item is selected.
    ''' </summary>
    ''' <remarks>selectedItems is a collection.</remarks>
    ' <Snippet113>

    Public ReadOnly Property IsSelected() As Boolean _
        Implements ISelectionItemProvider.IsSelected
        Get
            Return selectedItems.Contains(Me)
        End Get
    End Property

    ' </Snippet113>
    ''' <summary>
    ''' Removes an item from the selection is list boxes that support multiple selection
    ''' or no selection at all.
    ''' </summary>
    ''' <remarks>selectedItems is a collection.</remarks>
    ' <Snippet112>
    Public Sub RemoveFromSelection() _
        Implements ISelectionItemProvider.RemoveFromSelection
        selectedItems.Remove(Me)

    End Sub
    ' TODO: Update UI.
    ' </Snippet112>

    ''' <summary>
    ''' Selects the item.
    ''' </summary>
    ' <Snippet115>
    Public Sub SelectItem() _
        Implements ISelectionItemProvider.Select
        selectedItems.Clear()
        selectedItems.Add(Me)

    End Sub
    ' </Snippet115>

    ''' <summary>
    ''' Gets the list box that contains the item.
    ''' </summary>
    ' <Snippet114>
    Public ReadOnly Property SelectionContainer() As IRawElementProviderSimple _
        Implements ISelectionItemProvider.SelectionContainer
        Get
            Return DirectCast(parentList, IRawElementProviderSimple)
        End Get
    End Property
    ' </Snippet114>
#End Region
End Class
