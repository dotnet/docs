Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Annotations
Imports System.Windows.Input


Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		'<SnippetKeyboardSampleGotFocus>
		Private Sub TextBoxGotKeyboardFocus(ByVal sender As Object, ByVal e As KeyboardFocusChangedEventArgs)
			Dim source As TextBox = TryCast(e.Source, TextBox)

			If source IsNot Nothing Then
				' Change the TextBox color when it obtains focus.
				source.Background = Brushes.LightBlue

				' Clear the TextBox.
				source.Clear()
			End If
		End Sub
		'</SnippetKeyboardSampleGotFocus>

		'<SnippetKeyboardSampleLostFocus>
		Private Sub TextBoxLostKeyboardFocus(ByVal sender As Object, ByVal e As KeyboardFocusChangedEventArgs)
			Dim source As TextBox = TryCast(e.Source, TextBox)

			If source IsNot Nothing Then
				' Change the TextBox color when it loses focus.
				source.Background = Brushes.White

				' Set the  hit counter back to zero and updates the display.
				Me.ResetCounter()
			End If
		End Sub
		'</SnippetKeyboardSampleLostFocus>

		Public Sub ResetCounter()
			numberOfHits = 0
			lblNumberOfTargetHits.Content = numberOfHits
		End Sub

		'<SnippetKeyboardSampleKeyConverter>
		' Compares the key which was pressed with a target key.
		' If they are the same, updates a label which keeps track
		' of the number of times the target key has been pressed.
		Private Sub SourceTextKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
			' The key converter.
			Dim converter As New KeyConverter()
			Dim target As Key = Key.None

			' Verifying there is only one character in the string.
			If txtTargetKey.Text.Length = 1 Then
				' Converting the string to a Key.
				target = CType(converter.ConvertFromString(txtTargetKey.Text), Key)
			End If

			' If the pressed key is equal to the target key. 
			If e.Key = target Then
				' Incrementing  the number of hits, and updating
				' the label which displays the number of hits.
				numberOfHits += 1
				lblNumberOfTargetHits.Content = numberOfHits
			End If

		End Sub
		'</SnippetKeyboardSampleKeyConverter>

		Private numberOfHits As Integer = 0

	End Class
End Namespace