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

			MyMultipleTransformsExampleFrame.Content = New MultipleTransformsExample()
		End Sub

	End Class


End Namespace
