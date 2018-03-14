'This is a list of commonly used namespaces for a pane.

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media

Namespace ToolBarSimple
	''' <summary>
	''' Interaction logic for Pane1.xaml
	''' </summary>

	Partial Public Class Pane1
		Inherits Canvas
		Public Sub New()
			InitializeComponent()
			CreateToolBar()
		End Sub

		Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetToolBarOrientation>
			If tb1.Orientation = Orientation.Vertical Then
				btnText.Content = "This is a vertical toolbar."
			End If
			'</SnippetToolBarOrientation>
			If tb2.Orientation = Orientation.Vertical Then
				btnText.Content = "This is a vertical toolbar."
			End If
		End Sub

		Private Sub CreateToolBar()
			Dim tbartray As New ToolBarTray()

			Dim tbar As New ToolBar()

			Dim btn As New Button()
			btn.Content = "File"
			tbar.Items.Add(btn)

			Dim btn1 As New Button()
			btn1.Content = "Edit"
			tbar.Items.Add(btn1)

			Dim tbar1 As New ToolBar()

			Dim btn2 As New Button()
			btn2.Content = "Format"
			tbar1.Items.Add(btn2)

			Dim btn3 As New Button()
			btn3.Content = "View"
			tbar1.Items.Add(btn3)

			Dim btn4 As New Button()
			btn4.Content = "Help"
			tbar1.Items.Add(btn4)
			'<SnippetToolBarTrayToolBars>
			tbartray.ToolBars.Add(tbar)
			tbartray.ToolBars.Add(tbar1)
			'</SnippetToolBarTrayToolBars>

			bd1.Child = tbartray
		End Sub

	End Class
End Namespace