'************************************************************************************************
' *
' * File: MyControl.vb
' *
' * Description: Implements a custom control that supports UI Automation.
' * 
' * See ProviderForm.vb for a full description of this sample.
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


Namespace ElementProvider
	Friend Class CustomGrid
		Inherits Control
		Implements IRawElementProviderFragmentRoot, IGridProvider

		Private ChildControl As New ListBox()
		Private myRectangle As Rectangle
		Private myColor As Color
		Private myHWND As IntPtr

		Private gridItems(4, 1) As CustomGridItem

		''' <summary>
		''' Constructor.
		''' </summary>
		''' <param name="mainForm">Host form.</param>
		''' <param name="rect">Position and size of control.</param>
		Public Sub New(ByVal mainForm As Form, ByVal rect As Rectangle)
            ' Create an object that implements IInvokeProvider; see Invoker.vb.

			' Initialize painting area and color.
			myRectangle = New Rectangle(rect.X, rect.Y, rect.Width, rect.Height)
			myColor = Color.Green
			myHWND = Me.Handle

			' Give the control a Control.Location and Size so that it will trap mouse clicks
			' and will be repainted as necessary.

			Size = New System.Drawing.Size(myRectangle.Width, myRectangle.Height)
			Location = New System.Drawing.Point(myRectangle.X, myRectangle.Y)

			' Add MouseDown event handler.
            gridItems(0, 0) = New CustomGridItem("Apple", 0, 0, CType(Me, IRawElementProviderSimple))
			gridItems(0, 1) = New CustomGridItem("10 cents", 0, 1, CType(Me, IRawElementProviderSimple))
			gridItems(1, 0) = New CustomGridItem("Orange", 1, 0, CType(Me, IRawElementProviderSimple))
			gridItems(1, 1) = New CustomGridItem("15 cents", 1, 1, CType(Me, IRawElementProviderSimple))
		End Sub


		''' <summary>
		''' Handles WM_GETOBJECT message; others are passed to base handler.
		''' </summary>
		''' <param name="m">Windows message.</param>

		Protected Overrides Sub WndProc(ByRef m As Message)
			Const WM_GETOBJECT As Integer = &H003D

			If (m.Msg = WM_GETOBJECT) AndAlso (m.LParam.ToInt32() = AutomationInteropProvider.RootObjectId) Then
				m.Result = AutomationInteropProvider.ReturnRawElementProvider(Me.Handle, m.WParam, m.LParam, CType(Me, IRawElementProviderSimple))
				Return
			End If
			MyBase.WndProc(m)
		End Sub

		''' <summary>
		''' Handles Paint event.
		''' </summary>
		''' <param name="e">Event arguments.</param>
		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			Dim brush As New SolidBrush(myColor)
			e.Graphics.FillRectangle(brush, DisplayRectangle)
		End Sub

		''' <summary>
		''' Handles MouseDown event.
		''' </summary>
		''' <param name="sender">Object that raised the event.</param>
		''' <param name="e">Event arguments.</param>
		Public Sub RootButtonControl_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			OnCustomButtonClicked()
			Return
		End Sub

		''' <summary>
		''' Responds to a button click, regardless of whether it was caused by a mouse or
		''' keyboard click or by InvokePattern.Invoke. 
		''' </summary>
		Private Sub OnCustomButtonClicked()
			' TODO  Perform program actions invoked by the control.

			' Raise an event.
			If AutomationInteropProvider.ClientsAreListening Then
				Dim args As New AutomationEventArgs(InvokePatternIdentifiers.InvokedEvent)
				AutomationInteropProvider.RaiseAutomationEvent(InvokePatternIdentifiers.InvokedEvent, Me, args)
			End If
		End Sub



		#Region "IRawElementProviderSimple"


		''' <summary>
		''' Returns the object that supports the specified pattern.
		''' </summary>
		''' <param name="patternId">ID of the pattern.</param>
		''' <returns>Object that implements IInvokeProvider.</returns>
		Private Function GetPatternProvider(ByVal patternId As Integer) As Object Implements IRawElementProviderSimple.GetPatternProvider
			If patternId = GridPatternIdentifiers.Pattern.Id Then

				Return CType(Me, IGridProvider)
			End If
			Return Nothing
		End Function

		Private Function GetPropertyValue(ByVal propertyId As Integer) As Object Implements IRawElementProviderSimple.GetPropertyValue
			If propertyId = AutomationElementIdentifiers.NameProperty.Id Then
				Return "CustomGridControl"
			ElseIf propertyId = AutomationElementIdentifiers.ClassNameProperty.Id Then
				Return "CustomGridControlClass"
			ElseIf propertyId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
				Return ControlType.Custom.Id
			ElseIf propertyId = AutomationElementIdentifiers.IsContentElementProperty.Id Then
				Return True
			ElseIf propertyId = AutomationElementIdentifiers.IsControlElementProperty.Id Then
				Return True
			Else
				Return Nothing
			End If
		End Function
		Private ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple Implements IRawElementProviderSimple.HostRawElementProvider
			Get
				' myHWND is the handle of the window that contains this control.
				Return AutomationInteropProvider.HostProviderFromHandle(myHWND)
			End Get
		End Property

		Private ReadOnly Property IRawElementProviderSimple_ProviderOptions() As ProviderOptions Implements IRawElementProviderSimple.ProviderOptions
			Get
				Return ProviderOptions.ServerSideProvider
			End Get
		End Property

		#End Region ' IRawElementProviderSimple

		#Region "IRawElementProviderFragment Members"

		Private ReadOnly Property BoundingRectangle() As System.Windows.Rect Implements IRawElementProviderFragment.BoundingRectangle
			Get
				Console.WriteLine("RootButton:  Got BoundingRectangle property.")
				Return System.Windows.Rect.Empty ' per Brendan's doc -- roots return empty.
			End Get
		End Property

		Private ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot Implements IRawElementProviderFragment.FragmentRoot
			Get
				Console.WriteLine("RootButton:  Got FragmentRoot property.")
				Return Me
			End Get
		End Property

		Private Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots
			Return Nothing
		End Function

		Private Function GetRuntimeId() As Integer() Implements IRawElementProviderFragment.GetRuntimeId
			Return Nothing

		End Function

		Private Function Navigate(ByVal direction As NavigateDirection) As IRawElementProviderFragment Implements IRawElementProviderFragment.Navigate
			If direction = NavigateDirection.FirstChild Then
				' Return the provider that is the sole child of this one.
				Return CType(gridItems(0,0), IRawElementProviderFragment)
			Else
				Return Nothing
			End If
		End Function

		Private Sub SetFocus() Implements IRawElementProviderFragment.SetFocus
			'  TODO  See spec for requirements

			Throw New Exception("The method or operation is not implemented.")
		End Sub

		#End Region

		#Region "IRawElementProviderFragmentRoot Members"

		Private Function ElementProviderFromPoint(ByVal x As Double, ByVal y As Double) As IRawElementProviderFragment Implements IRawElementProviderFragmentRoot.ElementProviderFromPoint
			Throw New Exception("The method or operation is not implemented.")
		End Function

		Private Function GetFocus() As IRawElementProviderFragment Implements IRawElementProviderFragmentRoot.GetFocus
			' TODO  Unsure of the idea here -- it returns the element within this tree that has 
			'  focus, but only if the focus is actually on an element in this tree? Or is it the element
			'  that gains focus when the user navigates to the root element?
			Throw New Exception("The method or operation is not implemented.")
		End Function


		#End Region




		#Region "IGridProvider Members"
' <Snippet101> 
		Private Function GetItem(ByVal row As Integer, ByVal column As Integer) As IRawElementProviderSimple Implements IGridProvider.GetItem
			Return CType(gridItems(row, column), IRawElementProviderSimple)
		End Function
' </Snippet101>

' <Snippet102> 
		''' <summary>
		''' Gets the count of columns in the grid.
		''' </summary>
		''' <remarks>
		''' gridItems is a two-dimensional array containing columns
		''' in the second dimension.
		''' </remarks>
		Private ReadOnly Property ColumnCount() As Integer Implements IGridProvider.ColumnCount
			Get
				Return gridItems.GetUpperBound(1) + 1

			End Get
		End Property
' </Snippet102>

' <Snippet103> 
		''' <summary>
		''' Gets the count of rows in the grid.
		''' </summary>
		''' <remarks>
		''' gridItems is a two-dimensional array containing rows in
		''' the first dimension.
		''' </remarks>
		Private ReadOnly Property RowCount() As Integer Implements IGridProvider.RowCount
			Get
				Return gridItems.GetUpperBound(0) + 1
			End Get
		End Property
' </Snippet103>

		#End Region
	End Class
End Namespace
