Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation


Namespace SDKSample
	Partial Public Class SampleViewer
		Inherits Page
		Public Sub New()
			InitializeComponent()
			MyCompositeShapeExampleFrame.Content = New CompositeShapeExample()
			MyStreamGeometryExampleFrame.Content = New StreamGeometryExample()
			MyStreamGeometryTriangleExampleFrame.Content = New StreamGeometryTriangleExample()
			MyStreamGeometryArcToExampleFrame.Content = New StreamGeometryArcToExample()
			MyStreamGeometryBezierToExampleFrame.Content = New StreamGeometryBezierToExample()
			MyStreamGeometryPolyBezierToExampleFrame.Content = New StreamGeometryPolyBezierToExample()
			MyStreamGeometryPolyLineToExampleFrame.Content = New StreamGeometryPolyLineToExample()
			MyStreamGeometryPolyQuadraticBezierToExampleFrame.Content = New StreamGeometryPolyQuadraticBezierToExample()
			MyStreamGeometryQuadraticBezierToExampleFrame.Content = New StreamGeometryQuadraticBezierToExample()
			MyPolyQuadraticBezierSegmentExampleFrame.Content = New PolyQuadraticBezierSegmentExample()
			MyPolyBezierSegmentExampleFrame.Content = New PolyBezierSegmentExample()
		End Sub

	End Class


End Namespace
