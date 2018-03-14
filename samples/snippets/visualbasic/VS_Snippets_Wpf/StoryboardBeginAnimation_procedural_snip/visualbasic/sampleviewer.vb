Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.Animation.AnimatingWithStoryboards


	Public Class SampleViewer
		Inherits Page

		Public Sub New()

			Me.Title = "Storyboard Examples"
			Dim mainPanel As New DockPanel()
			mainPanel.Background = Brushes.White

			Dim sampleDisplayControl As New TabControl()


			Dim basicExampleItem As New TabItem()
			Dim myContainerFrame As New Frame()
			myContainerFrame.Content = New StoryboardExample()
			basicExampleItem.Header = "Basic Storyboard Example"
			basicExampleItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(basicExampleItem)

			Dim myTabItem As New TabItem()
			myTabItem.Header = "Scope Example"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New ScopeExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "Multiple NameScopes Example"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New MultipleNameScopesExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "ControllableStoryboardExample"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New ControlStoryboardExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "FrameworkContentElementControllableStoryboardExample"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New FrameworkContentElementControlStoryboardExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "FrameworkContentElementStoryboardExample"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New FrameworkContentElementStoryboardExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "Control Template"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New ControlTemplateStoryboardExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "FrameworkContentElementStoryboardWithHandoffBehaviorExample"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New FrameworkContentElementStoryboardWithHandoffBehaviorExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "Seek Example"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New SeekExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "FrameworkContentElement Seek Example"
			myContainerFrame = New Frame()
			myContainerFrame.Content = New FrameworkContentElementSeekExample()
			myTabItem.Content = myContainerFrame
			sampleDisplayControl.Items.Add(myTabItem)


			mainPanel.Children.Add(sampleDisplayControl)

			Me.Content = mainPanel


		End Sub


	End Class


End Namespace