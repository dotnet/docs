'************************************************************************************************
' *
' * File: ProviderForm.vb
' *
' * Description: 
' * 
' * The sample is shows how to implement UI Automation providers for the elements 
' * of a fragment that is hosted in an HWND. The control itself has been kept 
' * simple. It does not support scrolling and therefore an arbitrary limit has 
' * been set on the number of items it can contain.
' * 
' * The fragment consists of the root element (a list box) and its children (the 
' * list items.) The UI Automation provider for the list box supports only one 
' * control pattern, the Selection pattern. The provider for the list items 
' * implements the SelectionItem pattern.
' *
' * To see the UI Automation provider at work, run the application and then open 
' * UI Spy. You can see the application and its controls in the Control View. 
' * Clicking on the control or on the list items in the UI Spy tree causes the 
' * provider's methods to be called, and the values returned are displayed in the 
' * Properties pane. (Note that some values are retrieved from the default HWND
' * provider, not this custom implementation.) You can also select an item in the 
' * list by using the SelectionItem control pattern in UI Spy.
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
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Namespace CustomControls
	Partial Public Class SampleApplicationForm
		Inherits Form
		Private customList As CustomListControl

		''' <summary>
		''' Constructor for the application window.
		''' </summary>
		Public Sub New()
			InitializeComponent()

			' Create a label.  
			Dim listLabel As New Label()
			listLabel.Location = New Point(20, 10)
			listLabel.AutoSize = True
			listLabel.TabIndex = 0
			listLabel.Text = "&Contacts:"
			Me.Controls.Add(listLabel)

			' Create an instance of the custom control.
			customList = New CustomListControl()
			customList.Name = "customList"

			' Add it to the form's controls. Among other things, this makes it possible for
			' UIAutomation to discover it, as it will become a child of the application window.
			Me.Controls.Add(customList)

			' Set some properties.
			customList.Location = New Point(20, 30)
			' Text becomes the Name property for the custom control.
			customList.Text = listLabel.Text
			customList.TabIndex = 0

			' Add list items.
			customList.Add("Prakash",CustomControls.Availability.Online)
			customList.Add("James", CustomControls.Availability.Online)
			customList.Add("Lisa", CustomControls.Availability.Offline)
			customList.Add("Kim", CustomControls.Availability.Online)
			customList.Add("Bailey", CustomControls.Availability.Offline)
		End Sub

		''' <summary>
		''' Handles Add button clicks.
		''' </summary>
		''' <param name="sender">Object that raised the event.</param>
		''' <param name="e">Event arguments.</param>
		Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
			If Me.txtItem.Text.Length <> 0 Then
				If Me.radioOn.Checked Then
					Me.customList.Add(Me.txtItem.Text, Availability.Online)
				Else
					Me.customList.Add(Me.txtItem.Text, Availability.Offline)
				End If
				Me.txtItem.Clear()
			End If
		End Sub

	   ''' <summary>
	   ''' Handles Remove button clicks.
	   ''' </summary>
	   ''' <param name="sender">Object that raised the event.</param>
	   ''' <param name="e">Event arguments.</param>
		Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemove.Click
			Dim success As Boolean = customList.Remove(Me.customList.SelectedIndex)
		End Sub

		''' <summary>
		''' Handles Exit button clicks.
		''' </summary>
		''' <param name="sender">Object that raised the event.</param>
		''' <param name="e">Event arguments.</param>
		Private Sub btnExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
			Application.Exit()
		End Sub
	End Class
End Namespace
