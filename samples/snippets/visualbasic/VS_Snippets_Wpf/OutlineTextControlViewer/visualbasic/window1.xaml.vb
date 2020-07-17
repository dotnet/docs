Imports System.Windows.Media.Animation

' Namespace that defines the OutlineText custom control class in the referenced assembly.
Imports OutlineText

Namespace SDKSample
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			cbFont.SelectedValue = New FontFamily("Arial")
		End Sub

		' Reset the OutlineText control when a different font has been selected.
		Private Sub OnFontChanged(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)
			If args.AddedItems.Count <> 1 Then
				Return
			End If

			Dim selectedFont As FontFamily = TryCast(args.AddedItems(0), FontFamily)

			If selectedFont IsNot outlineText.Font Then
				outlineText.Font = selectedFont
			End If
		End Sub

		' Reset the OutlineText control to custom Fill and Stroke styles.
		Private Sub OnCustomStylesChanged(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)
			If outlineText Is Nothing Then
				Return
			End If

			Select Case cbCustomStyles.SelectedIndex
				Case 0
					outlineText.Fill = Brushes.LightSteelBlue
					outlineText.Stroke = Brushes.Teal

				Case 1
					outlineText.Fill = CreateLinearGradientSpectrumBrush()
					outlineText.Stroke = Brushes.Black

				Case 2
					outlineText.Fill = Brushes.Black
					outlineText.Stroke = CreateLinearGradientSpectrumBrush()

				Case 3
					outlineText.Fill = CType(Me.FindResource("FlamesBrush"), ImageBrush)
					outlineText.Stroke = Brushes.Black

				Case 4
					outlineText.Fill = Brushes.Black
					outlineText.Stroke = CType(Me.FindResource("FlamesBrush"), ImageBrush)

				Case 5
					outlineText.Fill = CType(Me.FindResource("ButterflyBrush"), ImageBrush)
					outlineText.Stroke = Brushes.Black

				Case 6
					outlineText.Fill = Brushes.Black
					outlineText.Stroke = CType(Me.FindResource("ButterflyBrush"), ImageBrush)

				Case 7
					outlineText.Fill = CType(Me.FindResource("CherriesBrush"), ImageBrush)
					outlineText.Stroke = Brushes.Maroon

				Case 8
					outlineText.Fill = Brushes.Maroon
					outlineText.Stroke = CType(Me.FindResource("CherriesBrush"), ImageBrush)
			End Select
		End Sub

		' Create a linear gradient brush for the spectrum custom Fill and Stroke.
		Private Function CreateLinearGradientSpectrumBrush() As LinearGradientBrush
			Dim gsc As New GradientStopCollection()
			gsc.Add(New GradientStop(Colors.Red, 0))
			gsc.Add(New GradientStop(Colors.Orange, 0.2))
			gsc.Add(New GradientStop(Colors.Yellow, 0.4))
			gsc.Add(New GradientStop(Colors.Green, 0.6))
			gsc.Add(New GradientStop(Colors.Blue, 0.8))
			gsc.Add(New GradientStop(Colors.Indigo, 1))

			Return New LinearGradientBrush(gsc)
		End Function
	End Class
End Namespace