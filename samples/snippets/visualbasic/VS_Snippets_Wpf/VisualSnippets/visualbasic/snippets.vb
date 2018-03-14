Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Friend Class Snippets
		Public Shared Sub SnippetSetEdgeMode(ByVal myVisual As Visual)
			'<SnippetSetEdgeMode>
			' Set the edge mode to aliased for the visual and any descendant drawing primitives it has.
			RenderOptions.SetEdgeMode(CType(myVisual, DependencyObject), EdgeMode.Aliased)
			'</SnippetSetEdgeMode>
		End Sub

		Public Shared Sub SnippetGetRenderTier()
			'<SnippetRenderTierSnippet1>
			Dim currentRenderTier As Integer = RenderCapability.Tier
			'</SnippetRenderTierSnippet1>
		End Sub

		Public Shared Sub SnippetRenderOrder()
			Dim drawingVisual As New DrawingVisual()

			'<SnippetRenderOrderSnippet1>
			' Retrieve the DrawingContext in order to draw into the visual object.
			Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()

			' Draw a rectangle into the DrawingContext.
			Dim rect As New Rect(New Point(160, 100), New Size(320, 80))
			drawingContext.DrawRectangle(Brushes.LightBlue, CType(Nothing, Pen), rect)

			' Draw a formatted text string into the DrawingContext.
			drawingContext.DrawText(New FormattedText("Hello, world", CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, New Typeface("Verdana"), 36, Brushes.Black), New Point(200, 116))

			' Persist the drawing content.
			drawingContext.Close()
			'</SnippetRenderOrderSnippet1>
		End Sub
	End Class
End Namespace
