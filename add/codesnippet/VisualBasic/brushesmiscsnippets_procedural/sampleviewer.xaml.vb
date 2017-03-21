Imports Microsoft.VisualBasic
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
			MySetBackgroundColorOfShapeExampleFrame.Content = New SetBackgroundColorOfShapeExample()
			MyCreateColorsFromExampleFrame.Content = New CreateColorsFromExample()
		End Sub

	End Class


End Namespace
