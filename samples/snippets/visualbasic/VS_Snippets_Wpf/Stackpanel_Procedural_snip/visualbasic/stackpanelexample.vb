' <SnippetStackPanelExampleWholePage>

Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample
	Partial Public Class StackpanelExample
		Inherits Page
		Public Sub New()
			' Create two buttons
			Dim myButton1 As New Button()
			myButton1.Content = "Button 1"
			Dim myButton2 As New Button()
			myButton2.Content = "Button 2"

			' Create a StackPanel
			Dim myStackPanel As New StackPanel()

			' Add the buttons to the StackPanel
			myStackPanel.Children.Add(myButton1)
			myStackPanel.Children.Add(myButton2)

			Me.Content = myStackPanel
		End Sub
	End Class
End Namespace
' </SnippetStackPanelExampleWholePage>