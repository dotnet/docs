Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Media3D

Namespace ContainerModelSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		'<SnippetContainerMouseDown>
		' When the ContainerUIElement3D that has the two cubes as its children gets the
		' routed click event, spin the cubes in a 360 degree circle
		Private Sub ContainerMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			e.Handled = True

			' spin the cubes around
			Dim doubleAnimation As New DoubleAnimation(0, 360, New Duration(TimeSpan.FromSeconds(0.5)))
			containerRotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, doubleAnimation)
		End Sub
		'</SnippetContainerMouseDown>

		'<SnippetCube1MouseDown>
		' Change the color of the first cube from Blue to Red, or vice versa, when it is clicked
		Private Sub Cube1MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            cube1Material.Brush = (If(cube1Material.Brush Is Brushes.Blue, Brushes.Red, Brushes.Blue))
		End Sub
		'</SnippetCube1MouseDown>

		'<SnippetCube2MouseDown>
		' Change the color of the second cube from Green to Yellow, or vice versa, when it is clicked
		Private Sub Cube2MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            cube2Material.Brush = (If(cube2Material.Brush Is Brushes.Green, Brushes.Yellow, Brushes.Green))
		End Sub
		'</SnippetCube2MouseDown>
	End Class
End Namespace
