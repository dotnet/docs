Imports System.Windows.Threading


Namespace FocusSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub ClearText(ByVal sender As Object, ByVal e As RoutedEventArgs)
			txtBoxResults.Clear()
		End Sub

		Private Sub TextBoxMouseDownHandler(ByVal sender As Object, ByVal e As MouseEventArgs)

			If Mouse.RightButton = MouseButtonState.Pressed AndAlso Mouse.LeftButton = MouseButtonState.Pressed AndAlso Mouse.MiddleButton = MouseButtonState.Pressed Then
				UpdateSampleResults("Right,Left,Middle Buttons Pressed")
			End If

			'<SnippetMouseRelatedSnippetsGetRightButtonMouse>
			If Mouse.RightButton = MouseButtonState.Pressed Then
				UpdateSampleResults("Right Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetRightButtonMouse>
			'<SnippetMouseRelatedSnippetsGetLeftButtonMouse>
			If Mouse.LeftButton = MouseButtonState.Pressed Then
				UpdateSampleResults("Left Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetLeftButtonMouse>
			'<SnippetMouseRelatedSnippetsGetMiddleButtonMouse>
			If Mouse.MiddleButton = MouseButtonState.Pressed Then
				UpdateSampleResults("Middle Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetMiddleButtonMouse>
			'<SnippetMouseRelatedSnippetsGetX1ButtonMouse>
			If Mouse.XButton1 = MouseButtonState.Pressed Then
				UpdateSampleResults("First Extended Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetX1ButtonMouse>
			'<SnippetMouseRelatedSnippetsGetX2ButtonMouse>
			If Mouse.XButton2 = MouseButtonState.Pressed Then
				UpdateSampleResults("Second Extended Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetX2ButtonMouse>

		End Sub

		Private Sub TextBoxMouseDeviceDownHandler(ByVal sender As Object, ByVal e As MouseEventArgs)
			'<SnippetMouseRelatedSnippetsGetMouseDevice>
			' Gets the mouse device associated with the current thread.
			Dim currentMouseDevice As MouseDevice = Mouse.PrimaryDevice
			'</SnippetMouseRelatedSnippetsGetMouseDevice>


			If currentMouseDevice.RightButton = MouseButtonState.Pressed AndAlso currentMouseDevice.LeftButton = MouseButtonState.Pressed AndAlso currentMouseDevice.MiddleButton = MouseButtonState.Pressed Then
				UpdateSampleResults("Right,Left,Middle Buttons Pressed")
			End If

			'<SnippetMouseRelatedSnippetsGetRightButtonMouseDevice>
			If currentMouseDevice.RightButton = MouseButtonState.Pressed Then
				UpdateSampleResults("Right Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetRightButtonMouseDevice>
			'<SnippetMouseRelatedSnippetsGetLeftButtonMouseDevice>
			If currentMouseDevice.LeftButton = MouseButtonState.Pressed Then
				UpdateSampleResults("Left Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetLeftButtonMouseDevice>
			'<SnippetMouseRelatedSnippetsGetMiddleButtonMouseDevice>
			If currentMouseDevice.MiddleButton = MouseButtonState.Pressed Then
				UpdateSampleResults("Middle Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetMiddleButtonMouseDevice>
			'<SnippetMouseRelatedSnippetsGetX1ButtonMouseDevice>
			If currentMouseDevice.XButton1 = MouseButtonState.Pressed Then
				UpdateSampleResults("First Extended Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetX1ButtonMouseDevice>
			'<SnippetMouseRelatedSnippetsGetX2ButtonMouseDevice>
			If currentMouseDevice.XButton2 = MouseButtonState.Pressed Then
				UpdateSampleResults("Second Extended Button Pressed")
			End If
			'</SnippetMouseRelatedSnippetsGetX2ButtonMouseDevice>

		End Sub

		Private Sub MouseMoveMouseHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim displayArea As StackPanel
			displayArea = TryCast(e.Source, StackPanel)

			If displayArea IsNot Nothing Then
				'<SnippetMouseRelatedSnippetsPositionMouse>
				' displayArea is a StackPanel and txtBoxMousePosition is
				' a TextBox used to display the position of the mouse pointer.
				Dim position As Point = Mouse.GetPosition(displayArea)
				txtBoxMousePosition.Text = "X: " & position.X & vbLf & "Y: " & position.Y
				'</SnippetMouseRelatedSnippetsPositionMouse>
			End If
		End Sub

		'<SnippetMouseRelatedSnippetsPositionMouseDevice>
		Private Sub MouseMoveMouseDeviceHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)

			Dim currentMouseDevice As MouseDevice = Mouse.PrimaryDevice
			Dim position As Point
			Dim source As StackPanel

			source = TryCast(e.Source, StackPanel)

			If source IsNot Nothing Then
				position = currentMouseDevice.GetPosition(source)
				txtBoxMouseDevicePosition.Text = "X: " & position.X & vbLf & "Y: " & position.Y
			End If

		End Sub
		'</SnippetMouseRelatedSnippetsPositionMouseDevice>

		Public Sub UpdateSampleResults(ByVal output As String)
			txtBoxResults.Text += output & vbLf

		End Sub


	End Class
End Namespace