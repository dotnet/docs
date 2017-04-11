Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation


Namespace Microsoft.Samples.Animation


	Partial Public Class SampleViewer
		Inherits Page

		Public Sub New()
			InitializeComponent()
			StoryboardsExampleFrame.Content = New StoryboardsExample()
			IndirectTargetingExampleFrame.Content = New IndirectTargetingExample()
		End Sub


	End Class
End Namespace
