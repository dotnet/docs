Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data

Namespace ListBox_Index
	Partial Public Class MyApp
		Inherits Application
		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As EventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Show()
		End Sub

	End Class
End Namespace