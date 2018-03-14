'************************************************************************************************
' *
' * File: ListItemFragment.vb
' *
' * Description: Implements a list item as a fragment within a custom control 
' * that supports UI Automation.
' * 
' * See ProviderForm.vb for a full description of this sample.
' *   
' * 
' *  This file is part of the Microsoft Windows SDK Code Samples.
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

Namespace CustomControls
	Public Class ListItemProvider
		Implements IRawElementProviderFragment, ISelectionItemProvider
		' Provider for the list that contains the item.
		Private containerListProvider As ListProvider
		' Control that contains the list.
		Private listItemControl As CustomListItem
		' ArrayList that represents the collection of ListItems.
		Private selectedItems As ArrayList


		''' <summary>
		''' Constructor.
		''' </summary>
		''' <param name="rootProvider">
		''' UI Automation provider for the fragment root (the containing list).
		''' </param>
		''' <param name="thisItem">The control that owns this provider.</param>
		Public Sub New(ByVal rootProvider As ListProvider, ByVal thisItem As CustomListItem)
			containerListProvider = rootProvider
			listItemControl = thisItem
			selectedItems = New ArrayList()
		End Sub


		''' <summary>
		''' Gets the index of the item within the list.
		''' </summary>
		Public ReadOnly Property Index() As Integer
			Get
				Return listItemControl.Index
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
		Public Function GetPatternProvider(ByVal patternId As Integer) As Object Implements System.Windows.Automation.Provider.IRawElementProviderSimple.GetPatternProvider
			If patternId = SelectionItemPatternIdentifiers.Pattern.Id Then
				Return Me
			End If
			Return Nothing
		End Function

		''' <summary>
		''' Returns UI Automation property values.
		''' </summary>
		''' <param name="propId">The identifier of the property.</param>
		''' <returns>The value of the property.</returns>
		Public Function GetPropertyValue(ByVal propertyId As Integer) As Object Implements System.Windows.Automation.Provider.IRawElementProviderSimple.GetPropertyValue
			If listItemControl.IsAlive = False Then
				Throw New ElementNotAvailableException()
			End If
			If propertyId = AutomationElementIdentifiers.NameProperty.Id Then
				Return listItemControl.Text
			ElseIf propertyId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
				Return ControlType.ListItem.Id
			ElseIf propertyId = AutomationElementIdentifiers.AutomationIdProperty.Id Then
				Return listItemControl.Id.ToString()
			ElseIf propertyId = AutomationElementIdentifiers.HasKeyboardFocusProperty.Id Then
				Return listItemControl.IsSelected
			ElseIf propertyId = AutomationElementIdentifiers.ItemStatusProperty.Id Then
				If listItemControl.Status = CustomControls.Availability.Online Then
					Return "Contact is online"
				Else
					Return "Contact is offline"
				End If
			ElseIf propertyId = AutomationElementIdentifiers.IsEnabledProperty.Id Then
				Return True
			ElseIf propertyId = AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id Then
				Return True
			ElseIf propertyId = AutomationElementIdentifiers.FrameworkIdProperty.Id Then
				Return "Custom"
			End If
			Return Nothing
		End Function

		''' <summary>
		''' Returns a host provider. 
		''' </summary>
		''' <remarks>
		''' In this case, because the element is not directly hosted in a
		''' window, null is returned.
		''' </remarks>
		Public ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple Implements System.Windows.Automation.Provider.IRawElementProviderSimple.HostRawElementProvider
			Get
				' Because the element is not directly hosted in a window, null is returned.
				Return Nothing
			End Get
		End Property

		''' <summary>
		''' Gets provider options.
		''' </summary>
		Public ReadOnly Property ProviderOptions() As ProviderOptions Implements System.Windows.Automation.Provider.IRawElementProviderSimple.ProviderOptions
			Get
				Return ProviderOptions.ServerSideProvider
			End Get
		End Property

		#End Region ' IRawElementProviderSimple Members

		#Region "IRawElementProviderFragment Members"

		''' <summary>
		''' Gets the bounding rectangle, in screen coordinates.
		''' </summary>
		Public ReadOnly Property BoundingRectangle() As System.Windows.Rect Implements IRawElementProviderFragment.BoundingRectangle
			Get
				Dim rc As Rectangle = Me.listItemControl.Location
				Return New System.Windows.Rect(rc.X, rc.Y, rc.Width, rc.Height)
			End Get
		End Property

		''' <summary>
		''' Gets the root of this fragment.
		''' </summary>
		Public ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot Implements IRawElementProviderFragment.FragmentRoot
			Get
				Return containerListProvider
			End Get
		End Property

		''' <summary>
		''' Gets any fragment roots that are embedded in this fragment.
		''' </summary>
		''' <returns>Null in this case.</returns>
		Public Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots
			Return Nothing
		End Function

		''' <summary>
		''' Gets the runtime identifier of the UI Automation element.
		''' </summary>
		''' <returns>An array of integers.</returns>
		Public Function GetRuntimeId() As Integer() Implements IRawElementProviderFragment.GetRuntimeId
			Return New Integer() { AutomationInteropProvider.AppendRuntimeId, listItemControl.Id}
		End Function

		''' <summary>
		''' Navigate to adjacent elements in the UI Automation tree.
		''' </summary>
		''' <param name="direction">Direction to navigate.</param>
		''' <returns>The element in that direction, or null.</returns>
		Public Function Navigate(ByVal direction As NavigateDirection) As IRawElementProviderFragment Implements IRawElementProviderFragment.Navigate
			If direction = NavigateDirection.Parent Then
				Return containerListProvider
			ElseIf direction = NavigateDirection.NextSibling Then
				Return containerListProvider.GetProviderForIndex(listItemControl.Index + 1)
			ElseIf direction = NavigateDirection.PreviousSibling Then
				Return containerListProvider.GetProviderForIndex(listItemControl.Index - 1)
			End If
			Return Nothing
		End Function


		''' <summary>
		''' Responds to a client request to set the focus to this control. 
		''' </summary>
		Public Sub SetFocus() Implements IRawElementProviderFragment.SetFocus
			If listItemControl.IsAlive = False Then
				Throw New ElementNotAvailableException()
			End If
			listItemControl.Container.SelectedIndex = Index
		End Sub

		#End Region ' IRawElementProviderFragment Members

		#Region "ISelectionItemProvider Members"

		' <SnippetAddToSelection>
		''' <summary>
		''' Adds an item to the selection for list boxes that 
		''' support multiple selection.
		''' </summary>
		''' <remarks>
		''' In a single-selection list box, AddToSelection() is 
		''' equivalent to Select().
		''' selectedItems is the collection of selected ListItems.
		''' </remarks>
		Public Sub AddToSelection() Implements ISelectionItemProvider.AddToSelection
			' Return if the item is already selected.
			If (CType(Me, ISelectionItemProvider)).IsSelected Then
				Return
			End If
			selectedItems.Add(Me)
			' TODO: Update UI.
		End Sub
		' </SnippetAddToSelection>

		' <SnippetIsSelected>
		''' <summary>
		''' Specifies whether the item is selected.
		''' </summary>
		''' <remarks>
		''' selectedItems is the collection of selected ListItems.
		''' </remarks>
		Public ReadOnly Property IsSelected() As Boolean Implements ISelectionItemProvider.IsSelected
			Get
				Return selectedItems.Contains(Me)
			End Get
		End Property
		' </SnippetIsSelected>

		' <SnippetRemoveFromSelection>
		''' <summary>
		''' Removes the item from the selection in list boxes that support 
		''' multiple selection or no selection at all.
		''' </summary>
		''' <remarks>
		''' selectedItems is the collection of selected ListItems.
		''' </remarks>
		Public Sub RemoveFromSelection() Implements ISelectionItemProvider.RemoveFromSelection
			' Return if the item is already selected.
			If (CType(Me, ISelectionItemProvider)).IsSelected Then
				Return
			End If
			If (CType(Me, ISelectionProvider)).IsSelectionRequired And selectedItems.Count <= 0 Then
				Throw New InvalidOperationException("Operation cannot be performed.")
			End If

			selectedItems.Remove(Me)
			' TODO: Update UI.
		End Sub
		' </SnippetRemoveFromSelection>

		' <SnippetSelect>
		''' <summary>
		''' Selects the item.
		''' </summary>
		''' <remarks>
		''' selectedItems is the collection of selected ListItems.
		''' </remarks>
		Public Sub [Select]() Implements ISelectionItemProvider.Select
			selectedItems.Clear()
			selectedItems.Add(Me)
			' TODO: Update UI.
		End Sub
		' </SnippetSelect>

		' <SnippetSelectionContainer>
		''' <summary>
		''' Gets the list box that contains the item.
		''' </summary>
		''' <remarks>
		''' Provider for the list that contains the item.
		''' </remarks>
		Public ReadOnly Property SelectionContainer() As IRawElementProviderSimple Implements ISelectionItemProvider.SelectionContainer
			Get
				Return containerListProvider
			End Get
		End Property
		' </SnippetSelectionContainer>

		#End Region ' ISelectionPatternProvider Members
	End Class
End Namespace
