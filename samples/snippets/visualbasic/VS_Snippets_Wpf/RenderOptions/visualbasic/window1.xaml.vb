Imports System.Windows
Imports System.Windows.Media

Namespace WindowsApplication1
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
			Stub01()
			Stub02()
			Stub03()
			Stub04()
			Stub05()
		End Sub

		Public Sub Stub01()
			' <SnippetRenderOptionsSnippet1>
			' Get the bitmap scaling mode for the image.
			Dim bitmapScalingMode As BitmapScalingMode = RenderOptions.GetBitmapScalingMode(MyImage)
			' </SnippetRenderOptionsSnippet1>
		End Sub


		Public Sub Stub02()
			Dim bitmapScalingMode As BitmapScalingMode = RenderOptions.GetBitmapScalingMode(MyImage)

			' <SnippetRenderOptionsSnippet2>
			' Set the bitmap scaling mode for the image to render faster.
			RenderOptions.SetBitmapScalingMode(MyImage, BitmapScalingMode.LowQuality)
			' </SnippetRenderOptionsSnippet2>

			bitmapScalingMode = RenderOptions.GetBitmapScalingMode(MyImage)
		End Sub

		Public Sub Stub03()
            ' <SnippetRenderOptionsSnippet3>
            Dim drawingBrush As New DrawingBrush()

            ' Set the caching hint option for the brush.
            RenderOptions.SetCachingHint(drawingBrush, CachingHint.Cache)

            ' Set the minimum and maximum relative sizes for regenerating the tiled brush.
            ' The tiled brush will be regenerated and re-cached when its size is
            ' 0.5x or 2x of the current cached size.
			RenderOptions.SetCacheInvalidationThresholdMinimum(drawingBrush, 0.5)
			RenderOptions.SetCacheInvalidationThresholdMaximum(drawingBrush, 2.0)
			' </SnippetRenderOptionsSnippet3>
		End Sub

		Public Sub Stub04()
			Dim drawingBrush As New DrawingBrush()
			RenderOptions.SetCacheInvalidationThresholdMinimum(drawingBrush, 0.5)
			RenderOptions.SetCacheInvalidationThresholdMaximum(drawingBrush, 2.0)
			RenderOptions.SetCachingHint(drawingBrush, CachingHint.Cache)

			' <SnippetRenderOptionsSnippet4>
			' Get the caching hint option for the brush.
            Dim cachingHintOpt As CachingHint = RenderOptions.GetCachingHint(drawingBrush)

            If cachingHintOpt = CachingHint.Cache Then
                ' Get the minimum and maximum relative sizes for regenerating the tiled brush.
                Dim minimum As Double = RenderOptions.GetCacheInvalidationThresholdMinimum(drawingBrush)
                Dim maximum As Double = RenderOptions.GetCacheInvalidationThresholdMaximum(drawingBrush)

                ' Perform action based on cache values...
            End If
			' </SnippetRenderOptionsSnippet4>
		End Sub

		Public Sub Stub05()
			Dim renderCapabilityTier As Integer = &H00020000
			Dim renderingTierTest As Integer = (renderCapabilityTier >> 16)

			' <SnippetRenderCapability1>
			' The rendering tier corresponds to the high-order word of the Tier property.
			Dim renderingTier As Integer = (RenderCapability.Tier >> 16)
			' </SnippetRenderCapability1>
		End Sub
	End Class
End Namespace