
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Shapes



Class HitTestSampleApp
    Inherits Application
    Private myWindow As Window
    Private myCanvas As Canvas
    Private inkCanvas1 As InkCanvas
    Private myPoints() As System.Windows.Point
    Private buttonPanel As StackPanel
    Private rbClipWithRect As RadioButton
    Private rbclipWithPoints As RadioButton
    Private rbEraseWithRect As RadioButton
    Private rbEraseWithPoints As RadioButton
    Private rbEraseWithStylusShape As RadioButton
    Private rbChangeColorAtPoint As RadioButton
    Private rbChangeColorWithPoints As RadioButton
    Private rbChangeColorWithRect As RadioButton
    Private rbChangeColorWithStylusShape As RadioButton
    
    
    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs) 
        myWindow = New Window()
        myCanvas = New Canvas()
        myWindow.Content = myCanvas
        
        inkCanvas1 = New InkCanvas()
        
        AddHandler inkCanvas1.StrokeCollected, AddressOf myIC_StrokeCollected
        
        inkCanvas1.Background = Brushes.LightGray
        
        inkCanvas1.SetValue(Canvas.TopProperty, 30.0)
        inkCanvas1.SetValue(Canvas.LeftProperty, 30.0)
        inkCanvas1.SetValue(Canvas.WidthProperty, 450.0)
        inkCanvas1.SetValue(Canvas.HeightProperty, 400.0)
        
        myCanvas.Children.Add(inkCanvas1)
        
        Dim box As New Rectangle()
        box.Height = 100
        box.Width = 100
        box.Stroke = Brushes.Black
        InkCanvas.SetLeft(box, 100)
        InkCanvas.SetTop(box, 100)
        inkCanvas1.Children.Add(box)
        
        'add the stack panel and radio buttons;
        buttonPanel = New StackPanel()
        buttonPanel.Width = 200
        buttonPanel.Height = 400
        Canvas.SetLeft(buttonPanel, 500)
        Canvas.SetTop(buttonPanel, 30)
        
        myCanvas.Children.Add(buttonPanel)
        
        rbclipWithPoints = New RadioButton()
        rbclipWithPoints.Content = "ClipWithPoints"
        AddHandler rbclipWithPoints.Click, AddressOf rbclipWithPoints_Click
        buttonPanel.Children.Add(rbclipWithPoints)
        
        rbClipWithRect = New RadioButton()
        rbClipWithRect.Content = "ClipWithRect"
        AddHandler rbClipWithRect.Click, AddressOf rbClipWithRect_Click
        buttonPanel.Children.Add(rbClipWithRect)
        
        rbChangeColorWithStylusShape = New RadioButton()
        rbChangeColorWithStylusShape.Content = "ChangeColorWithStylusShape"
        AddHandler rbChangeColorWithStylusShape.Click, AddressOf rbChangeColorWithStylusShape_Click
        buttonPanel.Children.Add(rbChangeColorWithStylusShape)
        
        rbChangeColorWithRect = New RadioButton()
        rbChangeColorWithRect.Content = "ChangeColorWithRect"
        AddHandler rbChangeColorWithRect.Click, AddressOf rbChangeColorWithRect_Click
        buttonPanel.Children.Add(rbChangeColorWithRect)
        
        rbChangeColorWithPoints = New RadioButton()
        rbChangeColorWithPoints.Content = "ChangeColorWithPoints"
        AddHandler rbChangeColorWithPoints.Click, AddressOf rbChangeColorWithPoints_Click
        buttonPanel.Children.Add(rbChangeColorWithPoints)
        
        rbChangeColorAtPoint = New RadioButton()
        rbChangeColorAtPoint.Content = "ChangeColorAtPoint"
        AddHandler rbChangeColorAtPoint.Click, AddressOf rbChangeColorAtPoint_Click
        buttonPanel.Children.Add(rbChangeColorAtPoint)
        
        rbEraseWithStylusShape = New RadioButton()
        rbEraseWithStylusShape.Content = "EraseWithStylusShape"
        AddHandler rbEraseWithStylusShape.Click, AddressOf rbEraseWithStylusShape_Click
        buttonPanel.Children.Add(rbEraseWithStylusShape)
        
        rbEraseWithPoints = New RadioButton()
        rbEraseWithPoints.Content = "EraseWithPoints"
        AddHandler rbEraseWithPoints.Click, AddressOf rbEraseWithPoints_Click
        buttonPanel.Children.Add(rbEraseWithPoints)
        
        rbEraseWithRect = New RadioButton()
        rbEraseWithRect.Content = "EraseWithRect"
        AddHandler rbEraseWithRect.Click, AddressOf rbEraseWithRect_Click
        buttonPanel.Children.Add(rbEraseWithRect)
        
        myWindow.Show()
    
    End Sub 'OnStartup
    
    
    Sub rbEraseWithRect_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.EraseWithRect
    
    End Sub 'rbEraseWithRect_Click
    
    
    Sub rbEraseWithPoints_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.EraseWithPoints
    
    End Sub 'rbEraseWithPoints_Click
    
    
    Sub rbEraseWithStylusShape_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.EraseWithStylusShape
    
    End Sub 'rbEraseWithStylusShape_Click
    
    
    Sub rbChangeColorAtPoint_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.ChangeColorAtPoint
    
    End Sub 'rbChangeColorAtPoint_Click
    
    
    Sub rbChangeColorWithPoints_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.ChangeColorWithPoints
    
    End Sub 'rbChangeColorWithPoints_Click
    
    
    Sub rbChangeColorWithRect_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.ChangeColorWithRect
    
    End Sub 'rbChangeColorWithRect_Click
    
    
    Sub rbChangeColorWithStylusShape_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.ChangeColorWithStylusShape
    
    End Sub 'rbChangeColorWithStylusShape_Click
    
    
    Sub rbclipWithPoints_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.ClipWithPoints
    
    End Sub 'rbclipWithPoints_Click
    
    
    Sub rbClipWithRect_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) 
        _hMode = hMode.ClipWithRect
    
    End Sub 'rbClipWithRect_Click
    
    
    Public Enum hMode
        ClipWithRect
        ClipWithPoints
        EraseWithRect
        EraseWithPoints
        EraseWithStylusShape
        ChangeColorAtPoint
        ChangeColorWithPoints
        ChangeColorWithRect
        ChangeColorWithStylusShape
    End Enum 'hMode
    
    Private _hMode As hMode = hMode.ClipWithRect
    
    
    Sub myIC_StrokeCollected(ByVal sender As Object, ByVal e As InkCanvasStrokeCollectedEventArgs) 
        Select Case _hMode
            Case hMode.ChangeColorAtPoint
                ChangeColorAtPoint(e.Stroke)
            
            Case hMode.ChangeColorWithPoints
                ChangeColorWithPoints(e.Stroke)
            
            Case hMode.ChangeColorWithRect
                ChangeColorWithRect(e.Stroke)
            
            Case hMode.ChangeColorWithStylusShape
                ChangeColorWithStylusShape(e.Stroke)
            
            Case hMode.ClipWithPoints
                ClipWithPoints(e.Stroke)
            
            Case hMode.ClipWithRect
                ClipWithRect(e.Stroke)
            
            Case hMode.EraseWithPoints
                EraseWithPoints(e.Stroke)
            
            Case hMode.EraseWithRect
                EraseWithRect(e.Stroke)
            
            Case hMode.EraseWithStylusShape
                EraseWithStylusShape(e.Stroke)
        End Select
    
    End Sub 'myIC_StrokeCollected
     
    Private Sub ClipWithRect(ByVal aStroke As Stroke)
        '<Snippet5>
        Dim myRect As New Rect(100, 100, 100, 100)

        Dim clipResults As StrokeCollection = aStroke.GetClipResult(myRect)

        ' inkCanvas1 is the InkCanvas on which we update the strokes
        inkCanvas1.Strokes.Remove(aStroke)
        inkCanvas1.Strokes.Add(clipResults)
        '</Snippet5>

    End Sub 'ClipWithRect

    Sub ClipWithPoints(ByVal aStroke As Stroke) 
        '<Snippet6>
        Dim myPoints() As System.Windows.Point = _
                      {New System.Windows.Point(100, 100), _
                       New System.Windows.Point(200, 100), _
                       New System.Windows.Point(200, 200), _
                       New System.Windows.Point(100, 200)}
        
        Dim clipResults As StrokeCollection = aStroke.GetClipResult(myPoints)
        
        ' inkCanvas1 is the InkCanvas on which we update the strokes
        inkCanvas1.Strokes.Remove(aStroke)
        inkCanvas1.Strokes.Add(clipResults)
        '</Snippet6>

    End Sub 'ClipWithPoints

    Sub EraseWithRect(ByVal aStroke As Stroke) 
        '<Snippet4>
        Dim myRect As New Rect(100, 100, 100, 100)
        
        Dim eraseResults As StrokeCollection = aStroke.GetEraseResult(myRect)
        
        ' inkCanvas1 is the InkCanvas on which we update the strokes
        inkCanvas1.Strokes.Remove(aStroke)
        inkCanvas1.Strokes.Add(eraseResults)
        '</Snippet4>

    End Sub 'EraseWithRect

    Sub EraseWithPoints(ByVal aStroke As Stroke) 
        ' <Snippet1>
        Dim myPoints() As System.Windows.Point = _
                      {New System.Windows.Point(100, 100), _
                       New System.Windows.Point(200, 100), _
                       New System.Windows.Point(200, 200), _
                       New System.Windows.Point(100, 200)}

        Dim eraseResults As StrokeCollection = aStroke.GetEraseResult(myPoints)
        
        ' inkCanvas1 is the InkCanvas on which we update the strokes
        inkCanvas1.Strokes.Remove(aStroke)
        inkCanvas1.Strokes.Add(eraseResults)
        '</Snippet1>

    End Sub 'EraseWithPoints

    Sub EraseWithStylusShape(ByVal aStroke As Stroke) 
        ' <Snippet2>
        Dim myPoints() As System.Windows.Point = _
                              {New System.Windows.Point(100, 100), _
                               New System.Windows.Point(200, 100), _
                               New System.Windows.Point(200, 200), _
                               New System.Windows.Point(100, 200)}

        Dim myStylus As New EllipseStylusShape(5.0, 5.0, 0.0)
        
        Dim eraseResults As StrokeCollection = aStroke.GetEraseResult(myPoints, myStylus)
        
        ' inkCanvas1 is the InkCanvas on which we update the strokes
        inkCanvas1.Strokes.Remove(aStroke)
        inkCanvas1.Strokes.Add(eraseResults)
        ' </Snippet2>

    End Sub 'EraseWithStylusShape

    Sub ChangeColorAtPoint(ByVal myStroke As Stroke) 
        ' <Snippet3>
        Dim myPoint As New System.Windows.Point(100, 100)
        
        If myStroke.HitTest(myPoint, 10) Then
            myStroke.DrawingAttributes.Color = Colors.Red
        End If
        ' </Snippet3>

    End Sub 'ChangeColorAtPoint

    Sub ChangeColorWithPoints(ByVal aStroke As Stroke)

        '<Snippet7>
        Dim myPoints() As System.Windows.Point = _
                              {New System.Windows.Point(100, 100), _
                               New System.Windows.Point(200, 100), _
                               New System.Windows.Point(200, 200), _
                               New System.Windows.Point(100, 200)}

        If aStroke.HitTest(myPoints, 80) Then
            aStroke.DrawingAttributes.Color = Colors.Purple
        End If
        '</Snippet7>
    End Sub 'ChangeColorWithPoints
    
    
    Sub ChangeColorWithRect(ByVal aStroke As Stroke)

        '<Snippet8>
        Dim rect1 As New Rect(100, 100, 100, 100)

        If aStroke.HitTest(rect1, 80) Then
            aStroke.DrawingAttributes.Color = Colors.Purple
        End If
        '</Snippet8>
    End Sub 'ChangeColorWithRect
     
    
    Sub ChangeColorWithStylusShape(ByVal aStroke As Stroke)

        '<Snippet9>
        Dim myPoints() As System.Windows.Point = _
                              {New System.Windows.Point(100, 100), _
                               New System.Windows.Point(200, 100), _
                               New System.Windows.Point(200, 200), _
                               New System.Windows.Point(100, 200)}

        Dim myStylus As New EllipseStylusShape(5.0, 5.0, 0.0)

        If aStroke.HitTest(myPoints, myStylus) Then
            aStroke.DrawingAttributes.Color = Colors.Purple
        End If
        '</Snippet9>
    End Sub 'ChangeColorWithStylusShape
     
    
    <System.STAThread()>  _
    Shared Sub Main(ByVal args() As String) 
        Dim myApp As New HitTestSampleApp()
        myApp.Run()

    End Sub 'Main
End Class 'HitTestSampleApp