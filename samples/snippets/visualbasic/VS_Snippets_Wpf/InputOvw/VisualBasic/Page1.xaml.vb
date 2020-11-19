Namespace Input_Ovw
	''' <summary>
	''' Interaction logic for Page1.xaml
	''' </summary>

	Partial Public Class Page1
		Inherits Page
		Private Sub OnLoaded(ByVal sender As Object, ByVal e As EventArgs)
			'<SnippetInput_OvwHandlingInputCodeBehind>
			' Create the UI elements.
			Dim inputStackPanel As New StackPanel()
			Dim inputButton As New Button()
			Dim inputTextBox As New TextBox()

			' Attach the Button and TextBox to the StackPanel.
			inputStackPanel.Children.Add(inputButton)
			inputStackPanel.Children.Add(inputTextBox)

			' Attach the event handlers.
			AddHandler inputStackPanel.KeyDown, AddressOf OnOverviewKeyDown
			AddHandler inputButton.Click, AddressOf OnOverviewButtonClick
			'</SnippetInput_OvwHandlingInputCodeBehind>



			'<SnippetInput_OvwKeyboardExampleUICodeBehind>
			' Create the UI elements.
			Dim keyboardStackPanel As New StackPanel()
			Dim keyboardButton1 As New Button()

			' Set properties on Buttons.
			keyboardButton1.Background = Brushes.AliceBlue
			keyboardButton1.Content = "Button 1"

			' Attach Buttons to StackPanel.
			keyboardStackPanel.Children.Add(keyboardButton1)

			' Attach event handler.
			AddHandler keyboardButton1.KeyDown, AddressOf OnButtonKeyDown
			'</SnippetInput_OvwKeyboardExampleUICodeBehind>




			'<SnippetInput_OvwMouseExampleUICodeBehind>
			' Create the UI elements.
			Dim mouseMoveStackPanel As New StackPanel()
			Dim mouseMoveButton As New Button()

			' Set properties on Button.
			mouseMoveButton.Background = Brushes.AliceBlue
			mouseMoveButton.Content = "Button"

			' Attach Buttons to StackPanel.
			mouseMoveStackPanel.Children.Add(mouseMoveButton)

			' Attach event handler.
			AddHandler mouseMoveButton.MouseEnter, AddressOf OnMouseExampleMouseEnter
			AddHandler mouseMoveButton.MouseLeave, AddressOf OnMosueExampleMouseLeave
			'</SnippetInput_OvwMouseExampleUICodeBehind>

			'<SnippetInput_OvwTextInputUICodeBehind>
			' Create the UI elements.
			Dim textInputStackPanel As New StackPanel()
			Dim textInputeButton As New Button()
			Dim textInputTextBox As New TextBox()
			textInputeButton.Content = "Open"

			' Attach elements to StackPanel.
			textInputStackPanel.Children.Add(textInputeButton)
			textInputStackPanel.Children.Add(textInputTextBox)

			' Attach event handlers.
			AddHandler textInputStackPanel.KeyDown, AddressOf OnTextInputKeyDown
			AddHandler textInputeButton.Click, AddressOf OnTextInputButtonClick
			'</SnippetInput_OvwTextInputUICodeBehind>

			' Attach to main Stackpanel.
			mainStackPanel.Children.Add(inputStackPanel)
			mainStackPanel.Children.Add(keyboardStackPanel)
			mainStackPanel.Children.Add(mouseMoveStackPanel)
			mainStackPanel.Children.Add(textInputStackPanel)
		End Sub

		'<SnippetInput_OvwHandlingInputKeyDownHandler>
		Private Sub OnOverviewKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
			' If the "A" key is pressed, open a MessageBox.
			If e.Key = Key.A Then
				MessageBox.Show("The A key was pressed!")
			End If
		End Sub
		'</SnippetInput_OvwHandlingInputKeyDownHandler>

		'<SnippetInput_OvwHandlingInputClickHandler>
		Private Sub OnOverviewButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' If the Button is clicked, open a MessageBox.
			MessageBox.Show("The Button was Clicked")
		End Sub
		'</SnippetInput_OvwHandlingInputClickHandler>

		'<SnippetInput_OvwKeyboardExampleHandlerCodeBehind>
		Private Sub OnButtonKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
			Dim source As Button = TryCast(e.Source, Button)
			If source IsNot Nothing Then
				If e.Key = Key.Left Then
					source.Background = Brushes.LemonChiffon
				Else
					source.Background = Brushes.AliceBlue
				End If
			End If
		End Sub
		'</SnippetInput_OvwKeyboardExampleHandlerCodeBehind>

		'<SnippetInput_OvwMouseExampleEneterHandler>
		Private Sub OnMouseExampleMouseEnter(ByVal sender As Object, ByVal e As MouseEventArgs)
			' Cast the source of the event to a Button.
			Dim source As Button = TryCast(e.Source, Button)

			' If source is a Button.
			If source IsNot Nothing Then
				source.Background = Brushes.SlateGray
			End If
		End Sub
		'</SnippetInput_OvwMouseExampleEneterHandler>

		'<SnippetInput_OvwMouseExampleLeaveHandler>
		Private Sub OnMosueExampleMouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
			' Cast the source of the event to a Button.
			Dim source As Button = TryCast(e.Source, Button)

			' If source is a Button.
			If source IsNot Nothing Then
				source.Background = Brushes.AliceBlue
			End If
		End Sub
		'</SnippetInput_OvwMouseExampleLeaveHandler>


		'<SnippetInput_OvwTextInputHandlersCodeBehind>
		Private Sub OnTextInputKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
			If e.Key = Key.O AndAlso Keyboard.Modifiers = ModifierKeys.Control Then
				handle()
				e.Handled = True
			End If
		End Sub

		Private Sub OnTextInputButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			handle()
			e.Handled = True
		End Sub

		Public Sub handle()
			MessageBox.Show("Pretend this opens a file")
		End Sub
		'</SnippetInput_OvwTextInputHandlersCodeBehind>



		Private Sub handler1(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

		End Sub
		Private Sub handler2(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

		End Sub

	End Class
End Namespace
