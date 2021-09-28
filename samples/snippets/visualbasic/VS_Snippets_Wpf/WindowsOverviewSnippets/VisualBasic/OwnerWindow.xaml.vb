Imports System.Windows

Partial Public Class OwnerWindow
	Inherits System.Windows.Window
	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub OpenOwnedWindow()
		' NOTE: Owner must be shown before it can own another window

		' Create new owned window and show it
		Dim ownedWindow As New OwnedWindow()
		ownedWindow.Owner = Me
		ownedWindow.Show()
	End Sub
End Class