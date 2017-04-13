' <SnippetPopExampleWholePage> 
Imports System.Windows.Media.Animation

Namespace SDKSample


	Public Class PopExample
		Inherits Page

		Public Sub New()
			Dim shapeOutlinePen As New Pen(Brushes.Black, 2)
			shapeOutlinePen.Freeze()

			' Create a DrawingGroup
			Dim dGroup As New DrawingGroup()

			' Obtain a DrawingContext from 
			' the DrawingGroup.
			Using dc As DrawingContext = dGroup.Open()
				' Draw a rectangle at full opacity.
				dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, New Rect(0, 0, 25, 25))

				' Push an opacity change of 0.5. 
				' The opacity of each subsequent drawing will
				' will be multiplied by 0.5.
				dc.PushOpacity(0.5)

				' This rectangle is drawn at 50% opacity.
				dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, New Rect(25, 25, 25, 25))

				' Push an opacity change of 0.5. 
				' The opacity of each subsequent drawing will
				' will be multiplied by 0.5. Note that
				' push operations are cumulative (until they are
				' popped). 
				dc.PushOpacity(0.5)

				' This rectangle is drawn at 25% opacity (0.5 x 0.5). 
				dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, New Rect(50, 50, 25, 25))

				' Changes the opacity back to 0.5.
				dc.Pop()

				' This rectangle is drawn at 50% opacity.
				dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, New Rect(75, 75, 25, 25))

				' Changes the opacity back to 1.0.
				dc.Pop()

				' This rectangle is drawn at 100% opacity.
				dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, New Rect(100, 100, 25, 25))
			End Using

			' Display the drawing using an image control.
			Dim theImage As New Image()
			Dim dImageSource As New DrawingImage(dGroup)
			theImage.Source = dImageSource

			Me.Content = theImage

		End Sub




	End Class

End Namespace
' </SnippetPopExampleWholePage> 

