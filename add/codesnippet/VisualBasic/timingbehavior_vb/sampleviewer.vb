' <Snippet101>
' EllipseGeometryExample.vb
'
' This sample demonstrates how to animate the center
' position of an EllipseGeometry using a PointAnimation.

Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls
Imports HexConverter


Namespace Microsoft.Samples.Animation.TimingBehavior

	Public Class SampleViewer
		Inherits Page

		Public Sub New()
			Me.WindowTitle = "Timing Behaviors"

			Dim myDockPanel As New DockPanel()
			myDockPanel.Background = Brushes.White

			Dim myTabControl As New TabControl()
			myTabControl.Name = "sampleSelector"
			myDockPanel.Children.Add(myTabControl)

			Dim myTabItem As New TabItem()
			myTabItem.Header = "RepeatBehavior Example"
			Dim myFrame As New Frame()
            'myFrame.Source = New Uri("RepeatBehaviorExample.vb")
			myFrame.Background = Brushes.White
			myTabControl.Items.Add(myTabItem)


			myTabItem = New TabItem()
			myTabItem.Header = "AutoReverse Example"
			myFrame = New Frame()
            'myFrame.Source = New Uri("AutoReverseExample.vb")
			myFrame.Background = Brushes.White
			myTabControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "BeginTime Example"
			myFrame = New Frame()
            ' myFrame.Source = New Uri("BeginTimeExample.vb")
			'myFrame.Content = New BeginTimeExample()
			myFrame.Background = Brushes.White
			myTabControl.Items.Add(myTabItem)


			myTabItem = New TabItem()
			myTabItem.Header = "FillBehavior Example"
			myFrame.Content = New FillBehaviorExample()
			myFrame.Background = Brushes.White
			myTabControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "Speed Example"
			myFrame = New Frame()
            'myFrame.Source = New Uri("SpeedExample.vb")
			myFrame.Background = Brushes.White
			myTabControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "Acceleration and Deceleration Example"
			myFrame = New Frame()
			myFrame.Content = New AccelDecelExample()
            'myFrame.Source = New Uri("AccelDecelExample.vb")
			myFrame.Background = Brushes.White
			myTabControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "Opacity Animation Example"
			myFrame = New Frame()
            'myFrame.Source = New Uri("OpacityAnimationExample.vb")
			myFrame.Background = Brushes.White
			myTabControl.Items.Add(myTabItem)

			myTabItem = New TabItem()
			myTabItem.Header = "Styles Example"
			myFrame = New Frame()
            ' myFrame.Source = New Uri("StyleStoryboardsExample.vb")
			myFrame.Background = Brushes.White
			myTabControl.Items.Add(myTabItem)

			Me.Content = myDockPanel
		End Sub
	End Class
End Namespace
' </Snippet101>