Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.MatrixExamples
	''' <summary>
	''' Interaction logic for SampleViewer.xaml
	''' </summary>

	Partial Public Class SampleViewer
		Inherits Page
	   Public Sub New()
			InitializeComponent()

			MatrixExampleFrame.Content = New MatrixExample()

	   End Sub

	End Class
End Namespace