Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace Foo
	''' <summary>
	''' Interaction logic for Page1.xaml
	''' </summary>

	Partial Public Class Page1
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub
	  Private Sub DoStuff(ByVal sender As Object, ByVal e As EventArgs)
		'<SnippetProceduralPropertySet>
		Dim myButton As New Button()
		myButton.Width = 200.0
		'</SnippetProceduralPropertySet>
		'<SnippetProceduralPropertyGet>
		Dim whatWidth As Double
		whatWidth = myButton.Width
		'</SnippetProceduralPropertyGet>
		Dim checkWidth As Double
		'<SnippetPropertyMixedDeclProcCB>
		checkWidth = myButton.Width
		If checkWidth = 200.0 Then
			anotherButton.Width = 300.0
		End If
		'</SnippetPropertyMixedDeclProcCB>
		MessageBox.Show(whatWidth.ToString())
		myButton.Content = "myButton"
		root.Children.Add(myButton)
	  End Sub

	End Class
End Namespace