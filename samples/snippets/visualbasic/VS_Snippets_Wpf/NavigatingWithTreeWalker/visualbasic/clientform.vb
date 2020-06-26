Imports System.ComponentModel
Imports System.Text

Namespace NavigateWithTreeWalker
	Partial Public Class NavigationWithTreeWalker
		Inherits Form
		Private showAutomation As New myAutomationClass()
		Private automationStarted As Boolean = False
		Public Sub New()
			InitializeComponent()
			showAutomation.mainForm = Me
		End Sub

		Private Sub btnStartAutomation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStartAutomation.Click
			If automationStarted Then
				showAutomation.StopListening()
				btnStartAutomation.Text = "Start Automation"
				automationStarted = False
			Else
				automationStarted = showAutomation.StartListening()
				If automationStarted Then
					btnStartAutomation.Text = "Stop Automation"
				End If
			End If
		End Sub

		Private Sub NavigationWithTreeWalker_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			If showAutomation IsNot Nothing Then
				showAutomation.StopListening()
			End If
		End Sub
	End Class
End Namespace