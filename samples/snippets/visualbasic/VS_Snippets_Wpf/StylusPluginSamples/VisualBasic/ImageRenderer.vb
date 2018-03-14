
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Input.StylusPlugIns
Imports System.Windows.Media
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Media.Imaging
Imports System.Windows.Threading
Imports System.Windows.Ink



'/ <summary>
'/ Summary description for Class1
'/ </summary>

Public Class ImageRenderer
    Inherits DynamicRenderer
    
    Delegate Sub InitializeRenderer() 
    
    <ThreadStatic()>  _
    Private Shared imageBrush As ImageBrush
    
    Private Const imageFile As String = "C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Sunset.jpg"
    Private image1 As BitmapImage
    Private renderingDistpatcher As Dispatcher
    Private initializeMethods As InitializeRenderer
    
    <ThreadStatic()>  _
    Private Shared solidBrush As SolidColorBrush
    
    
    Protected Overrides Sub OnDraw(ByVal drawingContext As DrawingContext, ByVal stylusPoints As StylusPointCollection, ByVal geometry As Geometry, ByVal fillBrush As Brush) 

        ' <Snippet17>
        If imageBrush Is Nothing Then
            ' Create an ImageBrush.  imageFile is a string that's a path to an image file.
            image1 = New BitmapImage(New Uri(imageFile))
            imageBrush = New ImageBrush(image1)
            
            ' Don't tile, don't stretch; align to top/left.
            imageBrush.TileMode = TileMode.None
            imageBrush.Stretch = Stretch.None
            imageBrush.AlignmentX = AlignmentX.Left
            imageBrush.AlignmentY = AlignmentY.Top
            
            ' Map the brush to the entire bounds of the element.
            imageBrush.ViewportUnits = BrushMappingMode.Absolute
            imageBrush.Viewport = ElementBounds
            imageBrush.Freeze()
        End If 
        ' </Snippet17>
        drawingContext.DrawGeometry(imageBrush, Nothing, geometry)
    
    End Sub 'OnDraw
End Class 'ImageRenderer


Public Class ImageStroke
    Inherits Stroke
    Private Shared imageBrush As ImageBrush
    Private Shared brush As SolidColorBrush
    'const string imageFile = @"C:\Documents and Settings\Carole\My Documents\My Pictures\gracelockerbig.jpg";
    Private Const imageFile As String = "C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Sunset.jpg"
    Private viewportSet As Boolean = False
    
    Shared Sub New() 
        Dim image1 As New BitmapImage(New Uri(imageFile))
        imageBrush = New ImageBrush(image1)
        imageBrush.TileMode = TileMode.None
        imageBrush.Stretch = Stretch.None
        imageBrush.AlignmentX = AlignmentX.Left
        imageBrush.AlignmentY = AlignmentY.Top
        
        ' Map the brush to the entire bounds of the element.
        imageBrush.ViewportUnits = BrushMappingMode.Absolute
    
    End Sub 'New
     
    
    Public Sub New(ByVal oldStroke As Stroke, ByVal controlBounds As Rect) 
        MyBase.New(oldStroke.StylusPoints, oldStroke.DrawingAttributes)
        ' This seems like a hack, but I didn't know how else to set the viewport.
        If Not viewportSet Then
            imageBrush.Viewport = controlBounds
            viewportSet = True
        End If
    
    End Sub 'New
    
    
    Protected Overrides Sub DrawCore(ByVal drawingContext As DrawingContext, ByVal drawingAttributes As DrawingAttributes) 
        Dim geometry As Geometry = Me.GetGeometry(drawingAttributes)
        drawingContext.DrawGeometry(imageBrush, Nothing, geometry)
    
    End Sub 'DrawCore 
End Class 'ImageStroke