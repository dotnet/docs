Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Namespace PasswordBoxSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub WindowLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
		End Sub

		' <Snippet_PwBox_PwChanged>
		Private pwChanges As Integer = 0

		Private Sub PasswordChangedHandler(ByVal sender As Object, ByVal args As RoutedEventArgs)
			' Increment a counter each time the event fires.
			pwChanges += 1
		End Sub
		' </Snippet_PwBox_PwChanged>

		Private Sub ChangeMaxLen()
			' <Snippet_PwdBox_MaxLen>
			' Set the new maximum input length for passwords to 128 characters.
			pwdBox.MaxLength = 128
			' </Snippet_PwdBox_MaxLen>
		End Sub

		Private Sub ChangePwdChar()
			' <Snippet_PwdBox_PwdChar>
			' Change the password masking character to a period.
			pwdBox.PasswordChar = "."c
			' </Snippet_PwdBox_PwdChar>

		End Sub

		Private Sub ClearPwdBox()
				' <Snippet_PwdBox_Clear>
				Dim pwdBox As New PasswordBox()
				pwdBox.Password = "Open Sesame!"

				' Clear any contents of the PasswordBox, as well as the value stored in the Password property.
				pwdBox.Clear()
				' </Snippet_PwdBox_Clear>
		End Sub

		Private Sub PwdProperty()
				' <Snippet_PwdBox_Pwd>
				Dim pwdBox As New PasswordBox()
				pwdBox.Password = "Open Sesame!"
				' </Snippet_PwdBox_Pwd>
		End Sub

		Private Sub PwdPaste()
			' <Snippet_PwdBox_Paste>
			' A TextBox will serve as a contrived means of putting our test 
			' password on the Clipboard.
			Dim txtBox As New TextBox()
			Dim pwdBox As New PasswordBox()

			' Put some content in the TextBox, and copy it to the Clipboard.
			txtBox.Text = "Open Sesame!"
			txtBox.SelectAll()
			txtBox.Copy()

			' Paste the contents of the Clipboard into the PasswordBox.  After this
			' call, the value of pwdBox.Password == "Open Sesame!".
			pwdBox.Paste()
			' </Snippet_PwdBox_Paste>

		End Sub
	End Class
End Namespace