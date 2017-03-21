'<SnippetInteractiveAnimationExampleWholePage>
'
'
'   This sample animates the position of an ellipse when 
'   the user clicks within the main border. If the user
'   left-clicks, the SnapshotAndReplace HandoffBehavior
'   is used when applying the animations. If the user
'   right-clicks, the Compose HandoffBehavior is used
'   instead.
'
'

Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls
Imports System.Windows.Input

Namespace Microsoft.Samples.Animation.LocalAnimations


    ' Create the demonstration.
    Public Class InteractiveAnimationExample
    	Inherits Page
        
        
        Private Dim interactiveTranslateTransform As TranslateTransform  
        Private Dim WithEvents containerBorder As Border 
        Private Dim interactiveEllipse As Ellipse
        
        Public Sub New()
        
            WindowTitle = "Interactive Animation Example"
            Dim myPanel As New DockPanel()
            myPanel.Margin = New Thickness(20.0)            
    
            containerBorder = new Border()
            containerBorder.Background = Brushes.White
            containerBorder.BorderBrush = Brushes.Black
            containerBorder.BorderThickness = new Thickness(2.0) 
            containerBorder.VerticalAlignment = VerticalAlignment.Stretch
            
            interactiveEllipse = new Ellipse()
            interactiveEllipse.Fill = Brushes.Lime
            interactiveEllipse.Stroke = Brushes.Black
            interactiveEllipse.StrokeThickness = 2.0
            interactiveEllipse.Width = 25
            interactiveEllipse.Height = 25
            interactiveEllipse.HorizontalAlignment = HorizontalAlignment.Left
            interactiveEllipse.VerticalAlignment = VerticalAlignment.Top
            
            interactiveTranslateTransform = new TranslateTransform()
            interactiveEllipse.RenderTransform = _
                interactiveTranslateTransform           
            
            containerBorder.Child = interactiveEllipse
            myPanel.Children.Add(containerBorder)
            Me.Content = myPanel
        End Sub
        

        ' When the user left-clicks, use the 
        ' SnapshotAndReplace HandoffBehavior when applying the animation.        
       	Private Sub border_mouseLeftButtonDown( _
       		ByVal sender As Object, ByVal e As MouseButtonEventArgs) _
       		Handles containerBorder.MouseLeftButtonDown
     
        
            Dim clickPoint = Mouse.GetPosition(containerBorder)
            
            ' Set the target point so the center of the ellipse
            ' ends up at the clicked point.
            Dim targetPoint As New System.Windows.Point()
            targetPoint.X = clickPoint.X - interactiveEllipse.Width / 2
            targetPoint.Y = clickPoint.Y - interactiveEllipse.Height / 2  
            
            ' Animate to the target point.
            Dim xAnimation As _ 
                New DoubleAnimation(targetPoint.X,  _
                New Duration(TimeSpan.FromSeconds(4)))
            interactiveTranslateTransform.BeginAnimation( _
                TranslateTransform.XProperty, xAnimation, HandoffBehavior.SnapshotAndReplace)
                
            Dim yAnimation As _ 
                New DoubleAnimation(targetPoint.Y, _
                New Duration(TimeSpan.FromSeconds(4)))
            interactiveTranslateTransform.BeginAnimation( _
                TranslateTransform.YProperty, yAnimation, HandoffBehavior.SnapshotAndReplace)                

            ' Change the color of the ellipse.
            interactiveEllipse.Fill = Brushes.Lime
                    
        End Sub
        
        ' When the user right-clicks, use the 
        ' Compose HandoffBehavior when applying the animation.
        Private Sub border_mouseRightButtonDown( _
        	ByVal sender As Object, ByVal e As MouseButtonEventArgs) _
        	Handles containerBorder.MouseRightButtonDown
        
        
            ' Find the point where the use clicked.
            Dim clickPoint = Mouse.GetPosition(containerBorder)
            
            ' Set the target point so the center of the ellipse
            ' ends up at the clicked point.
            Dim targetPoint As New System.Windows.Point()
            targetPoint.X = clickPoint.X - interactiveEllipse.Width / 2
            targetPoint.Y = clickPoint.Y - interactiveEllipse.Height / 2
            
            ' Animate to the target point.
            Dim xAnimation As _
                New DoubleAnimation(targetPoint.X, _
                New Duration(TimeSpan.FromSeconds(4)))
            interactiveTranslateTransform.BeginAnimation( _
                TranslateTransform.XProperty, xAnimation, HandoffBehavior.Compose)
                
            Dim yAnimation As _ 
                New DoubleAnimation(targetPoint.Y, _
                New Duration(TimeSpan.FromSeconds(4))) 
            interactiveTranslateTransform.BeginAnimation( _
                TranslateTransform.YProperty, yAnimation, HandoffBehavior.Compose)   
                
            ' Change the color of the ellipse.
            interactiveEllipse.Fill = Brushes.Orange
            
                    
        End Sub
        
    End Class
 
End Namespace
'</SnippetInteractiveAnimationExampleWholePage>