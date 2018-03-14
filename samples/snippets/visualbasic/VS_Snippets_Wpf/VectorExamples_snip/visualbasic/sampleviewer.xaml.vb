Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.VectorExamples
	''' <summary>
	''' Interaction logic for SampleViewer.xaml
	''' </summary>

	Partial Public Class SampleViewer
		Inherits Page
	   Public Sub New()
			InitializeComponent()

			VectorExampleFrame.Content = New VectorExample()

	   End Sub

	End Class
End Namespace