Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Set button1 as the first element to get Mouse Capture,
			' if the user does not specifiy a different Button.
			_elementToCapture = Button1
		End Sub

		'<SnippetMouseCapturSampleCaptureElement>
		Private Sub OnCaptureMouseRequest(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Mouse.Capture(_elementToCapture)
		End Sub
		'</SnippetMouseCapturSampleCaptureElement>

		'<SnippetMouseCaptureSampleUnCaptureElement>
		Private Sub OnUnCaptureMouseRequest(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' To release mouse capture, pass null to Mouse.Capture.
			Mouse.Capture(Nothing)
		End Sub
		'</SnippetMouseCaptureSampleUnCaptureElement>

		'<SnippetMouseCaptureGotMouseCaptureHandler>
		' GotMouseCapture event handler
		' MouseEventArgs.source is the element that has mouse capture
		Private Sub ButtonGotMouseCapture(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim source As Button = TryCast(e.Source, Button)

			If source IsNot Nothing Then
				' Update the Label that displays the sample results.
				lblHasMouseCapture.Content = source.Name
			' Another way to get the element with Mouse Capture
			' is to use the static Mouse.Captured property.
			Else
				'<SnippetMouseCaptureMouseCaptured>
				' Mouse.Capture returns an IInputElement.
				Dim captureElement As IInputElement

				captureElement = Mouse.Captured

				' Update the Label that displays the element with mouse capture.
				lblHasMouseCapture.Content = CType(captureElement, Object).ToString()
				'</SnippetMouseCaptureMouseCaptured>
			End If
		End Sub
		'</SnippetMouseCaptureGotMouseCaptureHandler>

		Private Sub ButtonLostMouseCapture(ByVal sender As Object, ByVal e As MouseEventArgs)

			Dim source As Button = TryCast(e.Source, Button)

			If source IsNot Nothing Then
				lblHasMouseCapture.Content = ""
			End If
		End Sub

		'***********************************************************
		'The rest of these methods are event handlers and methods  
		'used by the sample to process sample information.
		'***********************************************************
		Private Sub OnButtonMouseEnter(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim source As Button = TryCast(e.Source, Button)

			If _enlargeOnMouseOver Then
				If source IsNot Nothing Then
					source.Height += 15
					source.Width += 15
				End If
			End If
		End Sub

		Private Sub ButtonMouseClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim source As Button = TryCast(e.Source, Button)

			If source IsNot Nothing Then
				lblMouseClick.Content = source.Name

			End If
		End Sub

		Private Sub ButtonPreviewMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim source As Button = TryCast(e.Source, Button)

			If source IsNot Nothing Then
				lblLastMouseDown.Content = source.Name

			End If
		End Sub


		Private Sub ButtonPreviewMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim source As Button = TryCast(e.Source, Button)

			If source IsNot Nothing Then
				lblLastMouseUp.Content = source.Name

			End If
		End Sub

		Private Sub OnButtonMouseLeave(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim source As Button = TryCast(e.Source, Button)

			If _enlargeOnMouseOver Then
				If source IsNot Nothing Then
					source.Height -= 15
					source.Width -= 15
				End If
			End If

		End Sub

		Private Sub OnButtonMouseWheel(ByVal sender As Object, ByVal e As MouseWheelEventArgs)
			Dim source As Button = TryCast(e.Source, Button)

			If _changeColorOnMouseWheel Then
				If source IsNot Nothing Then
					If source.Background Is Brushes.AliceBlue Then
						source.Background = Brushes.Gold
					Else
						source.Background = Brushes.AliceBlue
					End If
				End If
			End If
		End Sub


		Private Sub OnRadioButtonSelected(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim source As RadioButton = TryCast(e.Source, RadioButton)

			If source IsNot Nothing Then
				Select Case source.Content.ToString()
					Case "1"
						_elementToCapture = Button1
					Case "2"
						_elementToCapture = Button2
					Case "3"
						_elementToCapture = Button3
					Case "4"
						_elementToCapture = Button4
					Case Else
				End Select
			End If
		End Sub
		Private Sub MouseOverChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			_enlargeOnMouseOver = True
		End Sub
		Private Sub MouseOverUnChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			_enlargeOnMouseOver = False
		End Sub
		Private Sub MouseWheelChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			_changeColorOnMouseWheel = True
		End Sub
		Private Sub MouseWheelUnChecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			_changeColorOnMouseWheel = False
		End Sub



		'private fields
		Private _enlargeOnMouseOver As Boolean = False
		Private _changeColorOnMouseWheel As Boolean = False
		Private _elementToCapture As IInputElement
	End Class
End Namespace