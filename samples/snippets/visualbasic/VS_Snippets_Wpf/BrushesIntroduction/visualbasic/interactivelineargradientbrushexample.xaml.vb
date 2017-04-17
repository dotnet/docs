Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace BrushesIntroduction

	''' <summary>
	''' Enables the user to configure a LinearGradientBrush interactively. 
	''' </summary>
	Partial Public Class InteractiveLinearGradientBrushExample
		Inherits Page

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub onPageLoaded(ByVal sender As Object, ByVal s As RoutedEventArgs)

			AddHandler MappingModeComboBox.SelectionChanged, AddressOf mappingModeChanged
			onStartPointTextBoxKeyUp(StartPointTextBox, Nothing)
			onEndPointTextBoxKeyUp(EndPointTextBox, Nothing)
		End Sub


		' Update the StartPoint and EndPoint markers when the gradient display
		' element's size changes.
		Private Sub gradientDisplaySizeChanged(ByVal sender As Object, ByVal e As SizeChangedEventArgs)
			' The marker positions only need recalcutated if the brush's MappingMode
			' is RelativeToBoundingBox.
			If InteractiveLinearGradientBrush.MappingMode = BrushMappingMode.RelativeToBoundingBox Then
				StartPointMarkerTranslateTransform.X = InteractiveLinearGradientBrush.StartPoint.X * e.NewSize.Width
				StartPointMarkerTranslateTransform.Y = InteractiveLinearGradientBrush.StartPoint.Y * e.NewSize.Height

				EndPointMarkerTranslateTransform.X = InteractiveLinearGradientBrush.EndPoint.X * e.NewSize.Width
				EndPointMarkerTranslateTransform.Y = InteractiveLinearGradientBrush.EndPoint.Y * e.NewSize.Height
			End If
		End Sub

		Private Sub onStartPointTextBoxKeyUp(ByVal sender As Object, ByVal args As KeyEventArgs)
			Dim t As TextBox = CType(sender, TextBox)
			Try
				Dim p As Point = Point.Parse(t.Text)
				If InteractiveLinearGradientBrush.MappingMode = BrushMappingMode.RelativeToBoundingBox Then
					StartPointMarkerTranslateTransform.X = p.X * GradientDisplayElement.ActualWidth
					StartPointMarkerTranslateTransform.Y = p.Y * GradientDisplayElement.ActualHeight
				Else
					StartPointMarkerTranslateTransform.X = p.X
					StartPointMarkerTranslateTransform.Y = p.Y

				End If
			Catch ex As InvalidOperationException
				' Ignore errors.
			Catch formatEx As FormatException
				' Ignore errors.
			End Try

		End Sub

		Private Sub onEndPointTextBoxKeyUp(ByVal sender As Object, ByVal args As KeyEventArgs)
			Dim t As TextBox = CType(sender, TextBox)
			Try
				Dim p As Point = Point.Parse(t.Text)
				If InteractiveLinearGradientBrush.MappingMode = BrushMappingMode.RelativeToBoundingBox Then
					EndPointMarkerTranslateTransform.X = p.X * GradientDisplayElement.ActualWidth
					EndPointMarkerTranslateTransform.Y = p.Y * GradientDisplayElement.ActualHeight
				Else
					EndPointMarkerTranslateTransform.X = p.X
					EndPointMarkerTranslateTransform.Y = p.Y

				End If

			Catch ex As InvalidOperationException
				' Ignore errors.
			Catch formatEx As FormatException
				' Ignore errors.
			End Try

		End Sub

		' Determine whether the user clicked a marker.
		Private Sub gradientDisplayMouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			If TypeOf e.OriginalSource Is Shape Then
				SetValue(SelectedMarkerProperty, CType(e.OriginalSource, Shape))
			Else
				SetValue(SelectedMarkerProperty, Nothing)
			End If
		End Sub

		' Determines whether the user just finished dragging a marker. If so,
		' this method updates the brush's StartPoint or EndPoint property,
		' depending on which marker was dragged. 
		Private Sub gradientDisplayMouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim clickPoint As Point = e.GetPosition(GradientDisplayElement)
			Dim s As Shape = CType(GetValue(SelectedMarkerProperty), Shape)
			If s Is EndPointMarker OrElse s Is StartPointMarker Then
				Dim translation As TranslateTransform = CType(s.RenderTransform, TranslateTransform)
				translation.X = clickPoint.X
				translation.Y = clickPoint.Y
				SetValue(SelectedMarkerProperty, Nothing)
				Mouse.Synchronize()

				Dim p As Point
				If InteractiveLinearGradientBrush.MappingMode = BrushMappingMode.RelativeToBoundingBox Then
					p = New Point(clickPoint.X / GradientDisplayElement.ActualWidth, clickPoint.Y / GradientDisplayElement.ActualHeight)
				Else

					p = clickPoint

				End If

				If s Is StartPointMarker Then

					InteractiveLinearGradientBrush.StartPoint = p
					StartPointTextBox.Text = p.X.ToString("F4") & "," & p.Y.ToString("F4")
				Else
					InteractiveLinearGradientBrush.EndPoint = p
					EndPointTextBox.Text = p.X.ToString("F4") & "," & p.Y.ToString("F4")
				End If
			End If
		End Sub

		' Update the StartPoint or EndPoint when the user drags one of the
		' points with the mouse. 
		Private Sub gradientDisplayMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim currentPoint As Point = e.GetPosition(GradientDisplayElement)
			Dim s As Shape = CType(GetValue(SelectedMarkerProperty), Shape)

			' Determine whether the user dragged a StartPoint or
			' EndPoint marker.
			If s Is EndPointMarker OrElse s Is StartPointMarker Then

				' Move the selected marker to the current mouse position.
				Dim translation As TranslateTransform = CType(s.RenderTransform, TranslateTransform)
				translation.X = currentPoint.X
				translation.Y = currentPoint.Y
				Mouse.Synchronize()

				Dim p As Point

				' Calculate the StartPoint or EndPoint.
				If InteractiveLinearGradientBrush.MappingMode = BrushMappingMode.RelativeToBoundingBox Then
					' If the MappingMode is relative, compute the relative
					' value of the new point.
					p = New Point(currentPoint.X / GradientDisplayElement.ActualWidth, currentPoint.Y / GradientDisplayElement.ActualHeight)
				Else
					' If the MappingMode is absolute, there's no more
					' work to do.
					p = currentPoint

				End If

				If s Is StartPointMarker Then
					' If the selected marker is the StartPoint marker,
					' update the brush's StartPoint.
					InteractiveLinearGradientBrush.StartPoint = p
					StartPointTextBox.Text = p.X.ToString("F4") & "," & p.Y.ToString("F4")
				Else
					' Otherwise, update the brush's EndPoint.
					InteractiveLinearGradientBrush.EndPoint = p
					EndPointTextBox.Text = p.X.ToString("F4") & "," & p.Y.ToString("F4")
				End If
			End If
		End Sub




		' Updates the StartPoint and EndPoint and their markers when
		' the user changes the brush's MappingMode.
		Private Sub mappingModeChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

			Dim oldStartPoint As Point = InteractiveLinearGradientBrush.StartPoint
			Dim newStartPoint As New Point()
			Dim oldEndPoint As Point = InteractiveLinearGradientBrush.EndPoint
			Dim newEndPoint As New Point()


			If InteractiveLinearGradientBrush.MappingMode = BrushMappingMode.RelativeToBoundingBox Then

				' The MappingMode changed from absolute to relative.
				' To find the new relative point, divide the old absolute points
				' by the painted area's width and height. 
				newStartPoint.X = oldStartPoint.X / GradientDisplayElement.ActualWidth
				newStartPoint.Y = oldStartPoint.Y / GradientDisplayElement.ActualHeight
				InteractiveLinearGradientBrush.StartPoint = newStartPoint

				newEndPoint.X = oldEndPoint.X / GradientDisplayElement.ActualWidth
				newEndPoint.Y = oldEndPoint.Y / GradientDisplayElement.ActualHeight
				InteractiveLinearGradientBrush.EndPoint = newEndPoint

			Else
				' The MappingMode changed from relative to absolute.
				' To find the new absolute point, multiply the old relative points
				' by the painted area's width and height. 
				newStartPoint.X = oldStartPoint.X * GradientDisplayElement.ActualWidth
				newStartPoint.Y = oldStartPoint.Y * GradientDisplayElement.ActualHeight
				InteractiveLinearGradientBrush.StartPoint = newStartPoint

				newEndPoint.X = oldEndPoint.X * GradientDisplayElement.ActualWidth
				newEndPoint.Y = oldEndPoint.Y * GradientDisplayElement.ActualHeight

				InteractiveLinearGradientBrush.EndPoint = newEndPoint

			End If

			' Update the StartPoint and EndPoint display text.
			StartPointTextBox.Text = newStartPoint.X.ToString("F4") & "," & newStartPoint.Y.ToString("F4")
			EndPointTextBox.Text = newEndPoint.X.ToString("F4") & "," & newEndPoint.Y.ToString("F4")
		End Sub

		' Update the markup display whenever the brush changes.
		Private Sub onInteractiveLinearGradientBrushChanged(ByVal sender As Object, ByVal e As EventArgs)
			If GradientDisplayElement IsNot Nothing Then
				markupOutputTextBlock.Text = generateLinearGradientBrushMarkup(InteractiveLinearGradientBrush)
			End If
		End Sub

		' Helper method that displays the markup of interest for
		' creating the specified brush.
		Private Shared Function generateLinearGradientBrushMarkup(ByVal theBrush As LinearGradientBrush) As String
			Dim sBuilder As New System.Text.StringBuilder()
			sBuilder.Append("<" & theBrush.GetType().Name & vbLf & "  StartPoint=""" & theBrush.StartPoint.ToString() & """" & "  EndPoint=""" & theBrush.EndPoint.ToString() & """ " & vbLf & "  MappingMode=""" & theBrush.MappingMode.ToString() & """" & "  SpreadMethod=""" & theBrush.SpreadMethod.ToString() & """" & vbLf & "  ColorInterpolationMode=""" & theBrush.ColorInterpolationMode.ToString() & """" & "  Opacity=""" & theBrush.Opacity.ToString() & """" & ">" & vbLf)

			For Each [stop] As GradientStop In theBrush.GradientStops
				sBuilder.Append ("  <GradientStop Offset=""" & [stop].Offset.ToString("F4") & """ Color=""" & [stop].Color.ToString() & """ />" & vbLf)

			Next [stop]
			sBuilder.Append("</LinearGradientBrush>")
			Return sBuilder.ToString()
		End Function

		Public Shared ReadOnly SelectedMarkerProperty As DependencyProperty = DependencyProperty.Register ("SelectedMarker", GetType(Shape), GetType(InteractiveLinearGradientBrushExample), New PropertyMetadata(Nothing))

	End Class


	<ValueConversion(GetType(Object), GetType(String()))>
	Public Class EnumPossibleValuesToStringArrayConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert


			Return New System.Collections.ArrayList(System.Enum.GetNames(value.GetType()))

		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class

	<ValueConversion(GetType(Point), GetType(String))>
	Public Class PointToStringConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert

			Dim p As Point = CType(value, Point)
			Return p.X.ToString("F4") & "," & p.Y.ToString("F4")

		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Try
				Return Point.Parse(CStr(value))
			Catch ex As System.InvalidOperationException
				Return Nothing
			End Try
		End Function
	End Class

	<ValueConversion(GetType(Double), GetType(String))>
	Public Class DoubleToStringConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert

			Dim d As Double = CDbl(value)
			Return d.ToString("F4")

		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Try
				Return Double.Parse(CStr(value))
			Catch ex As System.InvalidOperationException
				Return Nothing
			End Try
		End Function
	End Class


End Namespace