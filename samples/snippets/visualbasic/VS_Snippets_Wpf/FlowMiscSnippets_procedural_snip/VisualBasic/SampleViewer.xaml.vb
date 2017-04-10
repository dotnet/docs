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
			MyFigureCodeOnlyExampleFrame.Content = New FigureCodeOnlyExample()
			MyInsertInlineIntoTextExampleFrame.Content = New InsertInlineIntoTextExample()
		End Sub

	End Class


End Namespace
