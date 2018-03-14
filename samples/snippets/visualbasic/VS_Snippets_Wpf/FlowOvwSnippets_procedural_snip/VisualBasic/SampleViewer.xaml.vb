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
			MySimpleFlowExampleFrame.Content = New SimpleFlowExample()
			MyParagraphExampleFrame.Content = New ParagraphExample()
			MySectionExampleFrame.Content = New SectionExample()
			MyListExampleFrame.Content = New ListExample()
			MyInlineUIContainerExampleFrame.Content = New InlineUIContainerExample()
			MyFigureExampleFrame.Content = New FigureExample()
		End Sub

	End Class


End Namespace
