Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

			'<SnippetFocusSetIsFocusScope>
			Dim focuseScope2 As New StackPanel()
			FocusManager.SetIsFocusScope(focuseScope2, True)
			'</SnippetFocusSetIsFocusScope>

			Dim button3 As New Button()
			focuseScope2.Children.Add(button3)
			Dim button4 As New Button()
			focuseScope2.Children.Add(button4)
			mainStackPanel.Children.Add(focuseScope2)

			GetFocusedElement()
		End Sub

		Public Sub GetFocusedElement()
			'<SnippetFocusGetSetFocusedElement>
			' Sets the focused element in focusScope1
			' focusScope1 is a StackPanel.
			FocusManager.SetFocusedElement(focusScope1, button2)

			' Gets the focused element for focusScope 1
			Dim focusedElement As IInputElement = FocusManager.GetFocusedElement(focusScope1)
			'</SnippetFocusGetSetFocusedElement>

			MessageBox.Show(CType(focusedElement, Object).ToString())
		End Sub



	End Class
End Namespace