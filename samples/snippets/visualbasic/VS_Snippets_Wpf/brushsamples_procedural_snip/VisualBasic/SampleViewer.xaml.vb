Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation


Namespace Microsoft.Samples.BrushExamples
	Partial Public Class SampleViewer
		Inherits Page
		Public Sub New()
			InitializeComponent()
			MyOpacityExampleFrame.Content = New OpacityExample()
			MySolidColorBrushExampleFrame.Content = New SolidColorBrushExample()
		End Sub
	End Class

End Namespace
