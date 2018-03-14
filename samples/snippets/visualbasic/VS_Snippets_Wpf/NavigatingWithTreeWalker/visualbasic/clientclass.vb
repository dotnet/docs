'************************************************************************************************\
'*
'* File: ClientClass.vb
'*
'* Description:
'*   This sample client locates the element representing the main window of the
'*   TreeWalkerTarget sample application. It then locates the element representing
'*   the tab control in the automation element tree. The sample subscribes to the 
'*   automation StructureChanged event on the tab control element.
'* 
'*   To run the sample within Visual Studio, first open the solution properties and
'*   set both the target and the client applications to run as multiple startup 
'*   projects.
'*
'*   When the user clicks a tab on the control, a StructureChanged event is raised and the 
'*   current stucture of the subtree is displayed in the client window.
'* 
'*   The sample also demonstrates two-way communication between the target application and the client.
'*   When the user toggles automation on or off in the client application, a message is displayed 
'*   in a text box in the target application's window.
'*
'* Programming Elements:
'*    This sample demonstrates the following UI Automation programming elements from the
'*     System.Windows.Automation namespace:
'* 
'*       AutomationElement class
'*           RootElement property
'*           AutomationId property
'*           Name property
'*           GetCurrentPatterns() method
'*           GetCurrentPropertyValue() method
'*           BoundingRectangleProperty property
'*           Condition property
'*           AndCondition() method
'*       TreeWalker class
'*           ControlViewWalker.GetFirstChild()
'*           ControlViewWalker.GetNextSibling()
'*       AutomationProperty class
'*           ToString() method
'*
'* Copyright (C) 2005 by Microsoft Corporation.  All rights reserved.
'*
'\************************************************************************************************
Imports System.Text
Imports System.Windows.Automation

Namespace NavigateWithTreeWalker
	Friend Class myAutomationClass
		' The automation element representing the tab control container.
		Private tabElement As AutomationElement

		' The automation element representing the "is listening" label.
		Private listenElement As AutomationElement

		' The indentation level.
		Private treeDepth As Integer

		' The user's selection for showing supported patterns.
		Private showPatterns As Boolean = False

		' Global variable that gives this class access to the client's controls.
		' This is assigned when the main form has been initialized.
		Public mainForm As NavigationWithTreeWalker = Nothing

		' Constructor
		Public Sub New()
		End Sub

		''' <summary>
		''' Displays the tree structure in the client.
		''' </summary>
		''' <param name="structureStr">The string to display.</param>
		Private Sub ShowStructure(ByVal structureStr As String)
			mainForm.tbStructure.Text = structureStr
		End Sub


		''' <summary>
		''' Retrieves a list of all the patterns supported by the control.
		''' </summary>
		''' <param name="ae">The automation element for the control.</param>
		''' <param name="structureStringBuilder">The StringBuilder that gets the string. </param>
		Private Sub GetSupportedPatterns(ByVal element As AutomationElement, ByVal structureStringBuilder As StringBuilder)
			Dim padding As New StringBuilder()
			padding.Insert(0, " ", treeDepth * 8)

			' GetSupportedPatterns() is typically used only in debugging situations.
			' It is more efficient to call GetCurrentPattern() for just those patterns
			' you want to retrieve.
			Dim supportedPatterns() As AutomationPattern = element.GetSupportedPatterns()
            structureStringBuilder.Append(padding.ToString() & "Supported Patterns" & vbCrLf)
			For Each pattern As AutomationPattern In supportedPatterns
                structureStringBuilder.Append(padding.ToString() & "      " & pattern.ProgrammaticName & vbCrLf)
			Next pattern
			structureStringBuilder.Append(vbCrLf)
		End Sub

		''' <summary>
		''' Retrieves a non-empty string to identify this automation element.
		''' The AutomationId is the preferred identifier.
		''' </summary>
		''' <param name="ae">The automation element for the control.</param>
		''' <param name="structureStringBuilder">The StringBuilder that gets the string. </param>
		Private Sub GetAnIdentifier(ByVal element As AutomationElement, ByRef structureStringBuilder As StringBuilder)
			Dim padding As New StringBuilder()
			padding.Insert(0, " ", treeDepth * 8)
			structureStringBuilder.Append(padding)

			' Get an identifier for the element.
			' You can use either GetCurrentPropertyValue or an accessor on the Current property
			' to get the values of properties.
			If CStr(element.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty)) <> "" Then
                structureStringBuilder.Append("Automation Identifier : " & element.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty).ToString & vbCrLf)
			ElseIf CStr(element.GetCurrentPropertyValue(AutomationElement.NameProperty)) <> "" Then
                structureStringBuilder.Append("Name : " & element.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString & vbCrLf)
			ElseIf CStr(element.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty)) <> "" Then
                structureStringBuilder.Append("Localized Control Type : " & element.GetCurrentPropertyValue(AutomationElement.LocalizedControlTypeProperty).ToString & vbCrLf)
			Else
				structureStringBuilder.Append("No Identifier found" & vbCrLf)
			End If
		End Sub

		''' <summary>
		''' Gets a string for the element identifier and, optionally, the patterns it supports.
		''' </summary>
		''' <param name="ae">The automation element for the control.</param>
		''' <param name="structureStringBuilder">The StringBuilder that gets the string. </param>
		Private Sub ProcessElement(ByVal element As AutomationElement, ByRef structureStringBuilder As StringBuilder)
			GetAnIdentifier(element, structureStringBuilder)
			' If we are showing the supported patterns, get them and
			' add them to the string.
			If showPatterns Then
				GetSupportedPatterns(element, structureStringBuilder)
			End If
		End Sub

		''' <summary>
		''' Gets the child element of the automation element passed into the
		''' method. It returns a string containing the list of children.
		''' The method is called recursively if the element in the sibling list
		''' has child elements of its own.
		''' </summary>
		''' <param name="ae">The automation element for the control.</param>
		''' <param name="structureStringBuilder">The StringBuilder that gets the string.</param>
		Private Sub ProcessTree(ByVal element As AutomationElement, ByRef structureStringBuilder As StringBuilder)
			ProcessElement(element, structureStringBuilder)
			treeDepth += 1
			Dim child As AutomationElement = TreeWalker.ControlViewWalker.GetFirstChild(element)
			Do While child IsNot Nothing
				ProcessTree(child, structureStringBuilder)
				child = TreeWalker.ControlViewWalker.GetNextSibling(child)
			Loop
			treeDepth -= 1
		End Sub


		''' <summary>
		''' Initiates the building of the string that describes the automation structure
		''' under the specified element. Calls ProcessTree, which is recursive, to build
		''' the string.
		''' </summary>
		''' <param name="ae">The root automation element.</param>
		''' <returns>Description of the structure.</returns>
		Private Function GetAutomationStructure(ByVal element As AutomationElement) As String
			Dim structureStringBuilder As New StringBuilder("")
			If element IsNot Nothing Then
				treeDepth = 0
				ProcessTree(element, structureStringBuilder)
			End If
			Return structureStringBuilder.ToString()
		End Function

		'<Snippet1200>
		''' <summary>
		''' Gets the toggle state of an element in the target application.
		''' </summary>
		''' <param name="element">The target element.</param>
		Private Function IsElementToggledOn(ByVal element As AutomationElement) As Boolean
			If element Is Nothing Then
				' TODO: Invalid parameter error handling.
				Return False
			End If

            Dim objPattern As Object = Nothing
			Dim togPattern As TogglePattern
			If True = element.TryGetCurrentPattern(TogglePattern.Pattern, objPattern) Then
				togPattern = TryCast(objPattern, TogglePattern)
				Return togPattern.Current.ToggleState = ToggleState.On
			End If
			' TODO: Object doesn't support TogglePattern error handling.
			Return False
		End Function
		'</Snippet1200>

		''' <summary>
		''' Handles the StructureChanged event. Each time the automation element
		''' tree under the tab control changes, this event is raised.
		''' StructureChangedEventArgs can provide more information as to what kind of change happened.
		''' </summary>
		''' <param name="sender">The object that raised the event.</param>
		''' <param name="e">Event arguments.</param>
		Private Sub onStructureChanged(ByVal sender As Object, ByVal e As StructureChangedEventArgs)
			If sender IsNot Nothing Then
				Dim newStructure As String = GetAutomationStructure(CType(sender, AutomationElement))
				If newStructure <> "" Then
					ShowStructure((CType(sender, AutomationElement)).Current.Name & " indicated that the tree has changed. The new structure is: " & vbCrLf & vbCrLf & newStructure)
				End If
			End If
		End Sub

		''' <summary>
		''' Handles the ToggleStateChanged event.
		''' </summary>
		''' <param name="sender">The object that raised the event.</param>
		''' <param name="e">Event arguments.</param>
		Private Sub OnToggleStateChanged(ByVal sender As Object, ByVal e As AutomationPropertyChangedEventArgs)
			IsElementToggledOn(CType(sender, AutomationElement))
			Dim StructureDescription As String = GetAutomationStructure(tabElement)
			ShowStructure(StructureDescription)
		End Sub

		''' <summary>
		''' Locates an element by its automation identifier.
		''' </summary>
		''' <param name="el">The root automation element.</param>
		''' <param name="aID">The identifier.</param>
		''' <returns>The element identified by aID.</returns>
		Private Function FindByAutomationId(ByVal el As AutomationElement, ByVal automationId As String) As AutomationElement
			Dim condition As Condition = New PropertyCondition(AutomationElement.AutomationIdProperty, automationId)
			Return el.FindFirst(TreeScope.Element Or TreeScope.Descendants, condition)
		End Function

		''' <summary>
		''' Display a message in the target application.
		''' </summary>
        ''' <param name="check">true to select the checkbox, otherwise, false.</param>
		Private Sub InformTarget(ByVal check As Boolean)
			If listenElement Is Nothing Then
				Return
			End If

			Dim listenValuePattern As ValuePattern = CType(listenElement.GetCurrentPattern(ValuePattern.Pattern), ValuePattern)
			If listenValuePattern IsNot Nothing Then
				If check = True Then
					listenValuePattern.SetValue("UIAutomation is listening.")
				Else
					listenValuePattern.SetValue("UIAutomation is not listening.")
				End If
			End If
		End Sub


		''' <summary>
		''' Removes the event handlers.
		''' </summary>
		Public Sub StopListening()
			Try
				Automation.RemoveAllEventHandlers()
				ShowStructure("Event handlers removed.")
				' Uncheck the "UIAutomation is listening" checkbox in the target application.
				InformTarget(False)
			Catch e1 As ElementNotAvailableException
				Return
			End Try
		End Sub


		''' <summary>
		''' Initializes UI automation by finding the target form, adding event handlers,
		''' and displaying the current automation element structure.
		''' </summary>
        ''' <returns>true on success, otherwise, false.</returns>
		Public Function StartListening() As Boolean
			Dim returnCode As Boolean = False
			Dim rootElement As AutomationElement = AutomationElement.RootElement

			' Set a property condition that will be used to find the main form of the
			' target application. myTestForm is the name of the Form and in the case
			' of a WinForms control, it is also the AutomationId of the element representing the control.
			Dim cond As Condition = New PropertyCondition(AutomationElement.AutomationIdProperty, "myTestForm")

			' Find the main window of the target application.
			Dim mainWindowElement As AutomationElement = rootElement.FindFirst(TreeScope.Element Or TreeScope.Children, cond)
			If mainWindowElement Is Nothing Then
				MessageBox.Show("Could not find the main form for the target application.")
				returnCode = False
			Else
				' Find the "Show supported patterns" checkbox and add an event handler for when
				' the toggle state changes.
				Dim elementCheckBox As AutomationElement = FindByAutomationId(mainWindowElement, "chkbxShowPatterns")
				Dim propsWanted() As AutomationProperty = { TogglePattern.ToggleStateProperty }

				If elementCheckBox IsNot Nothing Then
					If CBool(elementCheckBox.GetCurrentPropertyValue(AutomationElement.IsTogglePatternAvailableProperty)) = True Then
						IsElementToggledOn(elementCheckBox)
						Dim _onToggleStateChanged As New AutomationPropertyChangedEventHandler(AddressOf OnToggleStateChanged)
						Automation.AddAutomationPropertyChangedEventHandler(elementCheckBox, TreeScope.Element, _onToggleStateChanged, propsWanted)
					End If
				End If
				' Find the "UIAutomation is listening" textbox.
				 listenElement = FindByAutomationId(mainWindowElement, "tbListen")

				' Find the tab control and add an event handler for when the automation tree structure changes.
				' This event will be raised whenever the user selects a tab.
				tabElement = FindByAutomationId(mainWindowElement, "tabControl1")
				If tabElement IsNot Nothing Then
					Dim _onStructureChanged As New StructureChangedEventHandler(AddressOf onStructureChanged)
					Automation.AddStructureChangedEventHandler(tabElement, TreeScope.Descendants, _onStructureChanged)
				End If
				Dim StructureDescription As String = GetAutomationStructure(tabElement)
				ShowStructure(StructureDescription)
				' Check the "UIAutomation is listening" checkbox in the target application.
				InformTarget(True)

				returnCode = True
			End If
			Return returnCode
		End Function
	End Class
End Namespace
