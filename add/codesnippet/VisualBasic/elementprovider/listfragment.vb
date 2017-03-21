'************************************************************************************************
' *
' * File: ListFragment.vb
' *
' * Description: Implements a UI Automation provider for a custom list control.
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
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Collections
Imports System.Threading


Namespace CustomControls
	Public Class ListProvider
		Implements IRawElementProviderFragmentRoot, ISelectionProvider
		' Control that contains the list.
		Private OwnerListControl As CustomListControl
		' Window handle of the control.
		Private WindowHandle As IntPtr

		''' <summary>
		''' Constructor
		''' </summary>
		''' <param name="control">
		''' The control for which this object is providing UI Automation functionality.
		''' </param>
		Public Sub New(ByVal control As CustomListControl)
			OwnerListControl = control
			WindowHandle = control.Handle
		End Sub

		#Region "IRawElementProviderSimple Members"

		''' <summary>
		''' Retrieves the object that supports the specified control pattern.
		''' </summary>
		''' <param name="patternId">The pattern identifier</param>
		''' <returns>
		''' The supporting object, or null if the pattern is not supported.
		''' </returns>
		Private Function GetPatternProvider(ByVal patternId As Integer) As Object Implements IRawElementProviderSimple.GetPatternProvider
			If patternId = SelectionPatternIdentifiers.Pattern.Id Then
				Return Me
			End If
			Return Nothing
		End Function


		''' <summary>
		''' Gets provider property values.
		''' </summary>
		''' <param name="propertyId">The property identifier.</param>
		''' <returns>The value of the property.</returns>
		Private Function GetPropertyValue(ByVal propertyId As Integer) As Object Implements IRawElementProviderSimple.GetPropertyValue
			If propertyId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
				Return ControlType.List.Id
			' It is necessary to supply a value for IsKeyboardFocusable in a Windows Forms control,        
			'  because this value cannot be discovered by the HWND host provider. This is not 
			'  necessary for a Win32 provider.
			ElseIf propertyId = AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id Then
				Return True
			ElseIf propertyId = AutomationElementIdentifiers.FrameworkIdProperty.Id Then
				Return "Custom"
			End If
			Return Nothing
		End Function

		''' <summary>
		''' Gets the host provider.
		''' </summary>
		''' <remarks>
		''' Fragment roots return their window providers; most others return null.
		''' </remarks>
		Private ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple Implements IRawElementProviderSimple.HostRawElementProvider
			Get
				Return AutomationInteropProvider.HostProviderFromHandle(WindowHandle)
			End Get
		End Property

		''' <summary>
		''' Gets provider options.
		''' </summary>
		Private ReadOnly Property IRawElementProviderSimple_ProviderOptions() As ProviderOptions Implements IRawElementProviderSimple.ProviderOptions
			Get
				Return ProviderOptions.ServerSideProvider
			End Get
		End Property

		#End Region ' IRawElementProviderSimple Members


		#Region "IRawElementProviderFragment Members"

		''' <summary>
		''' Gets the bounding rectangle.
		''' </summary>
		''' <remarks>
		''' Fragment roots should return an empty rectangle. UI Automation will get the rectangle
		''' from the host control (the HWND in this case).
		''' </remarks>
		Private ReadOnly Property BoundingRectangle() As System.Windows.Rect Implements IRawElementProviderFragment.BoundingRectangle
			Get
				Return System.Windows.Rect.Empty
			End Get
		End Property

		''' <summary>
		''' Gets the root of this fragment.
		Private ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot Implements IRawElementProviderFragment.FragmentRoot
			Get
				Return Me
			End Get
		End Property

		''' <summary>
		''' Gets any fragment roots that are embedded in this fragment.
		''' </summary>
		''' <returns>Null in this case.</returns>
		Private Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots
			Return Nothing
		End Function

		''' <summary>
		''' Gets the runtime identifier of the UI Automation element.
		''' </summary>
		''' <returns>Fragment roots return null.</returns>
		Private Function GetRuntimeId() As Integer() Implements IRawElementProviderFragment.GetRuntimeId
			Return Nothing
		End Function

		''' <summary>
		''' Navigates to adjacent elements in the UI Automation tree.
		''' </summary>
		''' <param name="direction">Direction of navigation.</param>
		''' <returns>The element in that direction, or null.</returns>
		''' <remarks>The provider only returns directions that it is responsible for.  
		''' UI Automation knows how to navigate between HWNDs, so only the custom item 
		''' navigation needs to be provided.
		'''</remarks>
		Private Function Navigate(ByVal direction As NavigateDirection) As IRawElementProviderFragment Implements IRawElementProviderFragment.Navigate
			If direction = NavigateDirection.FirstChild Then
				Return GetProviderForIndex(0)
			ElseIf direction = NavigateDirection.LastChild Then
				Return GetProviderForIndex(OwnerListControl.ItemCount-1)
			End If
			Return Nothing
		End Function

		''' <summary>
		''' Responds to a client request to set the focus to this control.
		''' </summary>
		''' <remarks>Setting focus to the control is handled by the parent window.</remarks>
		Private Sub SetFocus() Implements IRawElementProviderFragment.SetFocus
			Throw New Exception("The method is not implemented.")
		End Sub

		#End Region ' IRawElementProviderFragment Members


		#Region "IRawElementProviderFragmentRoot Members"

		''' <summary>
		''' Gets the child element at the specified point.
		''' </summary>
		''' <param name="x">Distance from the left of the application window.</param>
		''' <param name="y">Distance from the top of the application window.</param>
		''' <returns>The provider for the element at that point.</returns>
		Private Function ElementProviderFromPoint(ByVal x As Double, ByVal y As Double) As IRawElementProviderFragment Implements IRawElementProviderFragmentRoot.ElementProviderFromPoint
			Dim index As Integer = -1
            Dim clientPoint As New System.Drawing.Point(CInt(x), CInt(y))

			' Invoke control method on separate thread to avoid clashing with UI.
            ' Use anonymous method for simplicity.
			Me.OwnerListControl.Invoke(New MethodInvoker(Sub() clientPoint = Me.OwnerListControl.PointToClient(clientPoint)))

			index = OwnerListControl.ItemIndexFromPoint(clientPoint)

			If index = -1 Then
				Return Nothing
			End If
			Return GetProviderForIndex(index)
		End Function


		''' <summary>
		''' Returns the child element that is selected when the list gets focus.
		''' </summary>
		''' <returns>The selected item.</returns>
		Private Function GetFocus() As IRawElementProviderFragment Implements IRawElementProviderFragmentRoot.GetFocus
			Dim index As Integer = OwnerListControl.SelectedIndex
			Return GetProviderForIndex(index)
		End Function

		#End Region ' IRawElementProviderFragmentRoot


		#Region "ISelectionProvider Members"

		' <SnippetCanSelectMultiple>
		''' <summary>
		''' Specifies whether selection of more than one item at a time is supported.
		''' </summary>
		Private ReadOnly Property CanSelectMultiple() As Boolean Implements ISelectionProvider.CanSelectMultiple
			Get
				Return False
			End Get
		End Property
		' </SnippetCanSelectMultiple>

		' <SnippetGetSelection>
		''' <summary>
		''' Returns the UI Automation provider for the selected list items.
		''' </summary>
		''' <returns>The selected items.</returns>
		''' <remarks>
		''' Because this is a single-selection list box, only one item is 
		''' returned.
		''' </remarks>
		Private Function GetSelection() As IRawElementProviderSimple() Implements ISelectionProvider.GetSelection
			Dim index As Integer = OwnerListControl.SelectedIndex
			Return New IRawElementProviderSimple() { GetProviderForIndex(index) }
		End Function
		' </SnippetGetSelection>

		' <SnippetIsSelectionRequired>
		''' <summary>
		''' Specifies whether the list must have an item selected at all times.
		''' </summary>
		Private ReadOnly Property IsSelectionRequired() As Boolean Implements ISelectionProvider.IsSelectionRequired
			Get
				Return True
			End Get
		End Property
		' </SnippetIsSelectionRequired>

		#End Region ' ISelectionProvider Members

		#Region "Helper methods"

		''' <summary>
		''' Gets the UI Automation provider for the item at the specified index.
		''' </summary>
		''' <param name="index">Index of the item.</param>
		''' <returns>The provider object, or null if the index is out of range.</returns>
		Public Function GetProviderForIndex(ByVal index As Integer) As IRawElementProviderFragment
			Dim OwnerCustomListItemCount As Integer = OwnerListControl.ItemCount - 1
			If (index < 0) OrElse (index > OwnerCustomListItemCount) Then
				Return Nothing
			End If
			Return CType(Me.OwnerListControl.GetItem(index).Provider, IRawElementProviderFragment)
		End Function


		''' <summary>
		''' Responds to a focus change by raising an event.
		''' </summary>
		''' <param name="listItem">The item that has received focus.</param>
		Public Shared Sub OnFocusChange(ByVal listItem As CustomListItem)
			If AutomationInteropProvider.ClientsAreListening Then
				Dim args As New AutomationEventArgs(AutomationElementIdentifiers.AutomationFocusChangedEvent)
				AutomationInteropProvider.RaiseAutomationEvent(AutomationElementIdentifiers.AutomationFocusChangedEvent, listItem.Provider, args)
			End If
		End Sub


		''' <summary>
		''' Responds to a selection change by raising an event.
		''' </summary>
		''' <param name="listItem">The item that has been selected.</param>
		Public Shared Sub OnSelectionChange(ByVal listItem As CustomListItem)
			If AutomationInteropProvider.ClientsAreListening Then
				Dim args As New AutomationEventArgs(SelectionItemPatternIdentifiers.ElementSelectedEvent)
				AutomationInteropProvider.RaiseAutomationEvent(SelectionItemPatternIdentifiers.ElementSelectedEvent, listItem.Provider, args)
			End If
		End Sub

' <Snippet101>
		''' <summary>
		''' Responds to an addition to the UI Automation tree structure by raising an event.
		''' </summary>
		''' <param name="list">
		''' The list to which the item was added.
		''' </param>
		''' <remarks>
		''' For the runtime Id of the item, pass 0 because the provider cannot know
		''' what its actual runtime Id is.
		''' </remarks>
		Public Shared Sub OnStructureChangeAdd(ByVal list As CustomListControl)
			If AutomationInteropProvider.ClientsAreListening Then
				Dim fakeRuntimeId() As Integer = { 0 }
				Dim args As New StructureChangedEventArgs(StructureChangeType.ChildrenBulkAdded, fakeRuntimeId)
				AutomationInteropProvider.RaiseStructureChangedEvent(CType(list.Provider, IRawElementProviderSimple), args)
			End If
		End Sub

		''' <summary>
		''' Responds to a removal from the UI Automation tree structure 
		''' by raising an event.
		''' </summary>
		''' <param name="list">
		''' The list from which the item was removed.
		''' </param>
		''' <remarks>
		''' For the runtime Id of the list, pass 0 because the provider cannot know
		''' what its actual runtime ID is.
		''' </remarks>
		Public Shared Sub OnStructureChangeRemove(ByVal list As CustomListControl)
			If AutomationInteropProvider.ClientsAreListening Then
				Dim fakeRuntimeId() As Integer = { 0 }
				Dim args As New StructureChangedEventArgs(StructureChangeType.ChildrenBulkRemoved, fakeRuntimeId)
				AutomationInteropProvider.RaiseStructureChangedEvent(CType(list.Provider, IRawElementProviderSimple), args)
			End If
		End Sub
' </Snippet101>        

		#End Region ' Helper methods

	End Class ' ListProvider class
End Namespace
