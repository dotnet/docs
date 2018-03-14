Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Input


Namespace KeyArgsSnippetSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub KeyHandler(ByVal sender As Object, ByVal e As KeyEventArgs)
			btnKeyStates.Content = e.KeyStates.ToString()


			'<SnippetKeyEventArgsKeyStatesDown>
			' A bitwise AND operation is used in the comparison.
			' e is an instance of KeyEventArgs.
			' btnDown is a Button.
			If (e.KeyStates And KeyStates.Down) > 0 Then
				btnDown.Background = Brushes.Red
			'</SnippetKeyEventArgsKeyStatesDown>

			Else
				btnDown.Background = Brushes.AliceBlue
			End If

			If CInt(Fix(e.KeyStates)) = 3 Then
				btnIsToggledAndDown.Background = Brushes.Blue
			Else
				btnIsToggledAndDown.Background = Brushes.AliceBlue
			End If

			'<SnippetKeyEventArgsKeyStatesNone>
			' e is an instance of KeyEventArgs.
			' btnNone is a Button.
			If (e.KeyStates And KeyStates.None) > 0 Then
				btnNone.Background = Brushes.Red
			End If
			'</SnippetKeyEventArgsKeyStatesNone>   

			'<SnippetKeyEventArgsKeyBoardGetKeyStates>
			' Uses the Keyboard.GetKeyStates to determine if a key is down.
			' A bitwise AND operation is used in the comparison. 
			' e is an instance of KeyEventArgs.
			If (Keyboard.GetKeyStates(Key.Return) And KeyStates.Down) > 0 Then
				btnNone.Background = Brushes.Red
			'</SnippetKeyEventArgsKeyBoardGetKeyStates>

			Else
				btnNone.Background = Brushes.AliceBlue
			End If

			'<SnippetKeyEventArgsKeyStatesToggled>
			' Uses the Keyboard.GetKeyStates to determine if a key is toggled.
			' A bitwise AND operation is used in the comparison. 
			' e is a instance of KeyEventArgs.
			' btnToggled is a Button.
			If (e.KeyStates And KeyStates.Toggled) > 0 Then
				btnToggled.Background = Brushes.Red
			'</SnippetKeyEventArgsKeyStatesToggled>
			Else
				btnToggled.Background = Brushes.AliceBlue
			End If



			If e.IsDown Then
				If e.IsRepeat Then
					btnIsRepeat.Background = Brushes.Red
				End If
			End If


			'<SnippetKeyEventArgsIsDown>
			' e is an instance of KeyEventArgs.
			' btnIsDown is a Button.
			If e.IsDown Then
				btnIsDown.Background = Brushes.Red
			'</SnippetKeyEventArgsIsDown>
			Else
				btnIsDown.Background = Brushes.AliceBlue
			End If

			'<SnippetKeyEventArgsKeyBoardIsKeyDown>
			' Uses the Keyboard.IsKeyDown to determine if a key is down.
			' e is an instance of KeyEventArgs.
			If Keyboard.IsKeyDown(Key.Return) Then
				btnIsDown.Background = Brushes.Red
			Else
				btnIsDown.Background = Brushes.AliceBlue
			End If
			'</SnippetKeyEventArgsKeyBoardIsKeyDown>


			If e.IsUp Then
				' Turn Off Repeat Indicator
				If btnIsRepeat.Background Is Brushes.Red Then
					btnIsRepeat.Background = Brushes.AliceBlue
				End If

				'<SnippetKeyEventArgsIsRepeat>
				' e is an instance of KeyEventArgs.
				' btnIsRepeat is a Button.
				If e.IsRepeat Then
					btnIsRepeat.Background = Brushes.AliceBlue
				End If
				'</SnippetKeyEventArgsIsRepeat>
			End If

			'<SnippetKeyEventArgsIsUp>
			' e is an instance of KeyEventArgs.
			' btnIsUp is a Button.
			If e.IsUp Then
				btnIsUp.Background = Brushes.Red
			'</SnippetKeyEventArgsIsUp>
			Else
				btnIsUp.Background = Brushes.AliceBlue
			End If

			'<SnippetKeyEventArgsKeyBoardIsKeyUp>
			' Uses the Keyboard.IsKeyUp to determine if a key is up.
			If Keyboard.IsKeyUp(Key.Return) Then
				btnIsUp.Background = Brushes.Red
			Else
				btnIsUp.Background = Brushes.AliceBlue
			End If
			'</SnippetKeyEventArgsKeyBoardIsKeyUp>

			'<SnippetKeyEventArgsIsToggled>
			' e is a instance of KeyEventArgs.
			' btnIsToggled is a Button.
			If e.IsToggled Then
				btnIsToggle.Background = Brushes.Red
			'</SnippetKeyEventArgsIsToggled>
			Else
				btnIsToggle.Background = Brushes.AliceBlue
			End If
			'<SnippetKeyEventArgsKeyBoardIsToggled>
			' Uses the Keyboard.IsToggled to determine if a key is toggled.
			If Keyboard.IsKeyToggled(Key.Return) Then
				btnIsToggle.Background = Brushes.Red
			Else
				btnIsToggle.Background = Brushes.AliceBlue
			End If
			'</SnippetKeyEventArgsKeyBoardIsToggled>

			'<SnippetKeyboardModifiersBitOperation>
			If (Keyboard.Modifiers And ModifierKeys.Control) > 0 Then
				button1.Background = Brushes.Red
			Else
				button1.Background = Brushes.Blue
			End If
			'</SnippetKeyboardModifiersBitOperation>

			btnValue.Content = (CByte(e.KeyStates)).ToString()
		End Sub

	End Class
End Namespace