Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.GradientBrushExamples
	''' <summary>
	''' Interaction logic for SampleViewer.xaml
	''' </summary>

	Partial Public Class SampleViewer
		Inherits Page
	   Public Sub New()
			InitializeComponent()

			LinearGradientBrushExampleFrame.Content = New LinearGradientBrushExample()
			RadialGradientBrushExampleFrame.Content = New RadialGradientBrushExample()
			GradientStopsExampleFrame.Content = New GradientStopsExample()

	   End Sub

	End Class
End Namespace