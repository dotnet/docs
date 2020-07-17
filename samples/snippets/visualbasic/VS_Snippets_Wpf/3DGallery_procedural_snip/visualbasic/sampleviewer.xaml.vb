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

			MyBasic3DShapeExampleFrame.Content = New Basic3DShapeExample()
			MyMisc3DOperationsExampleFrame.Content = New Misc3DOperationsExample()
			MyViewport3DVisualExampleFrame.Content = New Viewport3dVisualExample()
			MyEmissiveMaterialExampleFrame.Content = New EmissiveMaterialExample()
			MyMultipleTransformationsExampleFrame.Content = New MultipleTransformationsExample()
		End Sub

	End Class


End Namespace
