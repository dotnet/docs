
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Collections
Imports System.Windows.Input.StylusPlugIns


' This control allows the user to input ink and display it 
' with 3d visual effects.

Public Class Ink3d
    Inherits Border
    
    Private inkDA As DrawingAttributes
    Private presenter As InkPresenter
    Private stylusPoints As StylusPointCollection
    Private renderer As New DynamicRenderer()
    
    Public Sub New() 
        
        ' Use an InkPresenter to display the strokes on the control.
        presenter = New InkPresenter()
        Me.Child = presenter
        
        inkDA = New DrawingAttributes()
        inkDA.Width = 5
        inkDA.Height = 5
        'inkDA.AddPropertyData(shadow, false);
        'inkDA.PropertyDataChanged += new PropertyDataChangedEventHandler(inkDA_PropertyDataChanged);
        renderer.DrawingAttributes = inkDA
        Me.StylusPlugIns.Add(renderer)
        presenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes)
    
    End Sub 'New
    
    
    Shared Sub New() 
        ' Allow ink to be drawn only within the bounds of the control.
        Dim owner As Type = GetType(Ink3d)
        ClipToBoundsProperty.OverrideMetadata(owner, New FrameworkPropertyMetadata(True))
    
    End Sub 'New
    
    
    
    
    ' Remove all the strokes from the control.
    Public Sub ClearStrokes() 
        presenter.Strokes.Clear()
    
    End Sub 'ClearStrokes
     
    
    
    
    Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs) 
        
        MyBase.OnStylusDown(e)
        
        stylusPoints = New StylusPointCollection()
        
        stylusPoints.Add(e.GetStylusPoints(Me, stylusPoints.Description))
    
    End Sub 'OnStylusDown
     
    
    
    
    Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs) 
        
        MyBase.OnStylusMove(e)
        
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If 
        stylusPoints.Add(e.GetStylusPoints(Me, stylusPoints.Description))
    
    End Sub 'OnStylusMove
     
    
    
    
    Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs) 
        
        MyBase.OnStylusUp(e)
        
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If 
        stylusPoints.Add(e.GetStylusPoints(Me, stylusPoints.Description))
        
        AddStroke()
    
    End Sub 'OnStylusUp
     
    
    
    Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs) 
        
        MyBase.OnMouseLeftButtonUp(e)
        
        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If 
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If 
        Dim pt As Point = e.GetPosition(Me)
        
        stylusPoints.Add(New StylusPoint(pt.X, pt.Y))
        
        AddStroke()
    
    End Sub 'OnMouseLeftButtonUp
     
    
    
    Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs) 
        
        MyBase.OnMouseLeftButtonDown(e)
        
        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If 
        stylusPoints = New StylusPointCollection()
        
        Dim pt As Point = e.GetPosition(Me)
        
        stylusPoints.Add(New StylusPoint(pt.X, pt.Y))
    
    End Sub 'OnMouseLeftButtonDown
     
    
    
    
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs) 
        
        MyBase.OnMouseMove(e)
        
        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If 
        If e.LeftButton = MouseButtonState.Released Then
            Return
        End If 
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If 
        Dim pt As Point = e.GetPosition(Me)
        
        stylusPoints.Add(New StylusPoint(pt.X, pt.Y))
    
    End Sub 'OnMouseMove
     
    
    
    Private Sub AddStroke() 
        Dim newStroke As New ShadowedStroke(stylusPoints, inkDA)
        newStroke.Shadowed = strokesAreShadowed
        
        presenter.Strokes.Add(newStroke)
        
        stylusPoints = Nothing
    
    End Sub 'AddStroke
    
    Private strokesAreShadowed As Boolean
    
    
    Public Property Shadowed() As Boolean 
        Get
            Return strokesAreShadowed
        End Get
        
        ' Set the value of the custom property.
        Set
            strokesAreShadowed = value
            
            Dim s As ShadowedStroke
            For Each s In  presenter.Strokes
                s.Shadowed = strokesAreShadowed
            Next s
        End Set
    End Property
End Class 'Ink3d 
