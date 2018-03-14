 '************************************************************************************************
' *
' * File: ListPattern.cs
' *
' * Description: Implements ISelectionProvider to support SelectionPattern in client applications.
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

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation.Provider
Imports System.Collections



Class ListPattern
    Implements ISelectionProvider
    Private MyList As ArrayList
    Private SelectedIndex As Integer
    
    
    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="list">List box that this pattern supports.</param>
    ''' <param name="index">Index of the selected item.</param>
    Public Sub New(ByVal list As ArrayList, ByVal index As Integer) 
        MyList = list
        SelectedIndex = index
    
    End Sub 'New
    
    ' <Snippet119>
    #Region "ISelectionProvider Members"
    
    ' <Snippet108>
    ''' <summary>
    ''' Specifies whether selection of more than one item at a time is supported.
    ''' </summary>

    Public ReadOnly Property CanSelectMultiple() As Boolean _
        Implements ISelectionProvider.CanSelectMultiple
        Get
            Return False
        End Get
    End Property
    ' </Snippet108>
    ''' <summary>
    ''' Specifies whether the list has to have an item selected at all times.
    ''' </summary>
    ' <Snippet109>
    
    Public ReadOnly Property IsSelectionRequired() As Boolean _
        Implements ISelectionProvider.IsSelectionRequired
        Get
            Return True
        End Get
    End Property
    
    ' </Snippet109>
    ' <Snippet110>
    ''' <summary>
    ''' Returns the automation provider for the selected list item.
    ''' </summary>
    ''' <returns>The selected item.</returns>
    ''' <remarks>
    ''' MyList is an ArrayList collection of providers for items in the list box.
    ''' SelectedIndex is the index of the selected item.
    ''' </remarks>
    Public Function GetSelection() As IRawElementProviderSimple() _
        Implements ISelectionProvider.GetSelection
        If SelectedIndex >= 0 Then
            Dim itemProvider As IRawElementProviderSimple = DirectCast(MyList(SelectedIndex), IRawElementProviderSimple)
            Dim providers(1) As IRawElementProviderSimple
            providers(0) = itemProvider
            Return providers
        Else
            Return Nothing
        End If

    End Function 'GetSelection 
    ' </Snippet110>
    #End Region
    Private Members As ISelectionProvider
    ' </Snippet119>
End Class 'ListPattern 
'
