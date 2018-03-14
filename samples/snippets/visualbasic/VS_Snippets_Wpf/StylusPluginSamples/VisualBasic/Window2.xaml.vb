
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Media.Imaging


'/ <summary>
'/ Interaction logic for Window2.xaml
'/ </summary>

Class Window2
    Inherits Window '

    Private filteredIC As New FilteredInkCanvas()
    
    
    Public Sub New() 
        InitializeComponent()
        
        
        root.Children.Add(filteredIC)
        
        WindowState = WindowState.Maximized
    
    End Sub 'New
End Class 'Window2 

Public Class FilteredInkCanvas
    Inherits InkCanvas

    Private imageRenderer1 As New ImageRenderer()
    
    
    Public Sub New() 
        
        Me.DynamicRenderer = imageRenderer1
        Me.DefaultDrawingAttributes.Height = 20
        Me.DefaultDrawingAttributes.Width = 20
    
    End Sub 'New
    
    
    Protected Overrides Sub OnStrokeCollected(ByVal e As InkCanvasStrokeCollectedEventArgs) 
        MyBase.OnStrokeCollected(e)
        
        ' This is a hack, but I didn't want to create a whole control again.
        Me.Strokes.Remove(e.Stroke)
        Dim newStroke As New ImageStroke(e.Stroke, Me.DynamicRenderer.ElementBounds)
        Me.Strokes.Add(newStroke)
    
    End Sub 'OnStrokeCollected
End Class 'FilteredInkCanvas
