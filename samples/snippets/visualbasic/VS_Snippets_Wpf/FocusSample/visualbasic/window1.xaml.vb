Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Input


Namespace FocusSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
		'<SnippetFocusSampleSetFocus>
		Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Sets keyboard focus on the first Button in the sample.
			Keyboard.Focus(firstButton)
		End Sub
		'</SnippetFocusSampleSetFocus>

 '<SnippetFEPredictFocus>
		Private Sub OnPredictFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim predictionElement As DependencyObject = Nothing

			Dim elementWithFocus As UIElement = TryCast(Keyboard.FocusedElement, UIElement)

			If elementWithFocus IsNot Nothing Then
				' Only these four directions are currently supported
				' by PredictFocus, so we need to filter on these only.
				If (_focusMoveValue = FocusNavigationDirection.Up) OrElse (_focusMoveValue = FocusNavigationDirection.Down) OrElse (_focusMoveValue = FocusNavigationDirection.Left) OrElse (_focusMoveValue = FocusNavigationDirection.Right) Then

					' Get the element which would receive focus if focus were changed.
					predictionElement = elementWithFocus.PredictFocus(_focusMoveValue)

					Dim controlElement As Control = TryCast(predictionElement, Control)

					' If a ContentElement.
					If controlElement IsNot Nothing Then
						controlElement.Foreground = Brushes.DarkBlue
						controlElement.FontSize += 10
						controlElement.FontWeight = FontWeights.ExtraBold

						' Fields used to reset the UI when the mouse 
						' button is released.
						_focusPredicted = True
						_predictedControl = controlElement
					End If
				End If
			End If
		End Sub
 '</SnippetFEPredictFocus>

		Private Sub OnMoveFocus(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetFocusSampleMoveFocus>
			' Creating a FocusNavigationDirection object and setting it to a
			' local field that contains the direction selected.
			Dim focusDirection As FocusNavigationDirection = _focusMoveValue

			' MoveFocus takes a TraveralReqest as its argument.
			Dim request As New TraversalRequest(focusDirection)

			'<SnippetGetKeyboardFocusedElement>
			' Gets the element with keyboard focus.
			Dim elementWithFocus As UIElement = TryCast(Keyboard.FocusedElement, UIElement)
			'</SnippetGetKeyboardFocusedElement>

			' Change keyboard focus.
			If elementWithFocus IsNot Nothing Then
				elementWithFocus.MoveFocus(request)
			End If
			'</SnippetFocusSampleMoveFocus>
		End Sub


		' Sets the FocusNavigationDirection.
		Private Sub OnFocusSelected(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim source As RadioButton = TryCast(e.Source, RadioButton)

			If source IsNot Nothing Then
				_focusMoveValue = CType(System.Enum.Parse(GetType(FocusNavigationDirection), CStr(source.Content)), FocusNavigationDirection)
			End If
		End Sub

		' Resets the UI after PredictFocus changes the UI.
		Private Sub OnPredictFocusMouseUp(ByVal sender As Object, ByVal e As RoutedEventArgs)

			If _focusPredicted = True Then
				_predictedControl.Foreground = Brushes.Black
				_predictedControl.FontSize -= 10
				_predictedControl.FontWeight = FontWeights.Normal

				_focusPredicted = False
			End If
		End Sub

		' The direction to move/predict focus.
		Private _focusMoveValue As FocusNavigationDirection

		' Used to keep track of when a PredictFocus has happened.
		Private _focusPredicted As Boolean = False
		Private _predictedControl As Control
	End Class
End Namespace