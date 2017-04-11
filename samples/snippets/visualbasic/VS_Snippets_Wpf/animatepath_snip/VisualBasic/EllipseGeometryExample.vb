
' <Snippet201>
' EllipseGeometryExample.cs
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

Namespace Microsoft.Samples.Animation.AnimatePathShapeSample
    
    ' Create the demonstration.
    Public Class PathElementAnimationExample
        Inherits Page
        
        Private Dim WithEvents myPath As Path
        Private Dim myStoryboard As Storyboard
        
        Public Sub New()

	    NameScope.SetNameScope(Me, new NameScope())
	    
            Me.WindowTitle = "EllipseGeometry Animation Example"
            
            Dim myCanvas As New Canvas()
            myCanvas.Width = 400
            myCanvas.Height = 400
            myCanvas.Margin = New Thickness(20)
            
            ' Create a Path object to contain the geometry.
            myPath = New Path()
            myPath.Fill = Brushes.Blue
            myPath.Stroke = Brushes.Black
            myPath.StrokeThickness = 5
            
            ' Create an EllipseGeometry.
            Dim myEllipseGeometry As New EllipseGeometry()
            myEllipseGeometry.Center = New System.Windows.Point(200, 200)
            myEllipseGeometry.RadiusX = 25
            myEllipseGeometry.RadiusY = 50
            
            ' Register a name for the geometry so that it can
            ' be targeted by animations.  
            Me.RegisterName("MyEllipseGeometry", myEllipseGeometry)
            
            ' Add the geometry to the Path.
            myPath.Data = myEllipseGeometry
            myCanvas.Children.Add(myPath)
            Me.Content = myCanvas
            
            ' Create a PointAnimation to animate the center of the Ellipse.
            Dim myPointAnimation As New PointAnimation()
            myPointAnimation.From = New System.Windows.Point(200, 200)
            myPointAnimation.To = New System.Windows.Point(50, 50)
            myPointAnimation.Duration = _ 
                New Duration(TimeSpan.FromMilliseconds(5000))
            myPointAnimation.AutoReverse = True
            myPointAnimation.RepeatBehavior = RepeatBehavior.Forever   
            
            Storyboard.SetTargetName(myPointAnimation, "MyEllipseGeometry")
            Storyboard.SetTargetProperty(myPointAnimation, _
                new PropertyPath(EllipseGeometry.CenterProperty))
            myStoryboard = New Storyboard()
            myStoryboard.Children.Add(myPointAnimation)
            
  
        End Sub
        
        ' Start the animation when the path is loaded.
        Private Sub myPath_Loaded(ByVal sender as object, ByVal args as RoutedEventArgs) Handles myPath.Loaded
        
            myStoryboard.Begin(myPath)
        
        End Sub
        
        
    End Class
End Namespace
' </Snippet201>