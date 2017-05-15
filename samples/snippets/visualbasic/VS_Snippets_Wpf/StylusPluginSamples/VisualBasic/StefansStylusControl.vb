
Imports System
Imports System.Collections
Imports System.Windows
Imports System.Windows.Threading
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Input.StylusPlugIns
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Controls



Class CustomDynamicRenderer
    Inherits DynamicRenderer
    <ThreadStatic()>  _
    Private Shared brush As Brush = Nothing
    
    <ThreadStatic()>  _
    Private Shared pen As Pen = Nothing
    
    Private prevPoint As Point
    
    
    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput) 
        prevPoint = New Point(Double.NegativeInfinity, Double.NegativeInfinity)
        MyBase.OnStylusDown(rawStylusInput)
    
    End Sub 'OnStylusDown
    
    
    Protected Overrides Sub OnDraw(ByVal drawingContext As DrawingContext, ByVal stylusPoints As StylusPointCollection, ByVal geometry As Geometry, ByVal fillBrush As Brush) 
        If brush Is Nothing Then
            brush = New LinearGradientBrush(Colors.Red, Colors.Blue, 20.0)
        End If
        If pen Is Nothing Then
            pen = New Pen(brush, 2.0)
        End If
        Dim i As Integer
        For i = 0 To stylusPoints.Count
            Dim pt As Point = CType(stylusPoints(i), Point)
            Dim v As Vector = Point.Subtract(prevPoint, pt)
            If v.Length > 4 Then
                Dim radius As Double = stylusPoints(i).PressureFactor * 10.0
                drawingContext.DrawEllipse(brush, pen, pt, radius, radius)
                prevPoint = pt
            End If
        Next i
    
    End Sub 'OnDraw
End Class 'CustomDynamicRenderer


Class FilterPlugin
    Inherits StylusPlugIn
    
    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput) 
        MyBase.OnStylusDown(rawStylusInput)
        Filter(rawStylusInput)
    
    End Sub 'OnStylusDown
    
    Protected Overrides Sub OnStylusMove(ByVal rawStylusInput As RawStylusInput) 
        MyBase.OnStylusMove(rawStylusInput)
        Filter(rawStylusInput)
    
    End Sub 'OnStylusMove
    
    Protected Overrides Sub OnStylusUp(ByVal rawStylusInput As RawStylusInput) 
        MyBase.OnStylusUp(rawStylusInput)
        Filter(rawStylusInput)
    
    End Sub 'OnStylusUp
    
    Private Sub Filter(ByVal rawStylusInput As RawStylusInput) 
        Dim stylusPoints As StylusPointCollection = rawStylusInput.GetStylusPoints()
        Dim i As Integer
        For i = 0 To stylusPoints.Count
            Dim sp As StylusPoint = stylusPoints(i)
            If sp.X < 100 Then
                sp.X = 100
            End If
            If sp.X > 400 Then
                sp.X = 400
            End If
            If sp.Y < 100 Then
                sp.Y = 100
            End If
            If sp.Y > 400 Then
                sp.Y = 400
            End If
            stylusPoints(i) = sp
        Next i
        rawStylusInput.SetStylusPoints(stylusPoints)
    
    End Sub 'Filter
End Class 'FilterPlugin


Class TransformPlugin
    Inherits StylusPlugIn
    Private _matrix As Matrix
    
    Public Sub New(ByVal matrix As Matrix) 
        _matrix = matrix
    
    End Sub 'New
    
    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput) 
        MyBase.OnStylusDown(rawStylusInput)
        Transform(rawStylusInput)
    
    End Sub 'OnStylusDown
    
    Protected Overrides Sub OnStylusMove(ByVal rawStylusInput As RawStylusInput) 
        MyBase.OnStylusMove(rawStylusInput)
        Transform(rawStylusInput)
    
    End Sub 'OnStylusMove
    
    Protected Overrides Sub OnStylusUp(ByVal rawStylusInput As RawStylusInput) 
        MyBase.OnStylusUp(rawStylusInput)
        Transform(rawStylusInput)
    
    End Sub 'OnStylusUp
    
    Private Sub Transform(ByVal rawStylusInput As RawStylusInput) 
        Dim stylusPoints As StylusPointCollection = rawStylusInput.GetStylusPoints()
        Dim i As Integer
        For i = 0 To stylusPoints.Count
            Dim sp As StylusPoint = stylusPoints(i)
            Dim pt As Point = CType(sp, Point)
            pt *= _matrix
            sp.X = pt.X
            sp.Y = pt.Y
            stylusPoints(i) = sp
        Next i
        rawStylusInput.SetStylusPoints(stylusPoints)
    
    End Sub 'Transform
End Class 'TransformPlugin


Public Structure PluginDescription
    Public Plugin As StylusPlugIn
    Public Name As String
    
    Public Overrides Function ToString() As String 
        Return Name
    
    End Function 'ToString
End Structure 'PluginDescription


Class Stroke3D
    Inherits Stroke
    Private brush As Brush
    Private pen As Pen
    Private guidUsingStandardRenderer As New Guid("772c1f44-34db-45a3-97db-5325d5e53a52")
    Private guidUsingCustomRenderer As New Guid("44df9701-c3f8-48fd-86cc-e8c9c5341826")
    
    
    Public Sub New(ByVal stylusPoints As StylusPointCollection) 
        MyBase.New(stylusPoints)
        brush = New LinearGradientBrush(Colors.Red, Colors.Blue, 20.0)
        pen = New Pen(brush, 2.0)
    
    End Sub 'New
    
    
    Protected Overrides Sub DrawCore(ByVal drawingContext As DrawingContext, ByVal drawingAttributes As DrawingAttributes) 
        If Me.ContainsPropertyData(guidUsingCustomRenderer) Then
            Dim prevPoint As New Point(Double.NegativeInfinity, Double.NegativeInfinity)
            Dim i As Integer
            For i = 0 To (Me.StylusPoints.Count)
                Dim pt As Point = CType(Me.StylusPoints(i), Point)
                Dim v As Vector = Point.Subtract(prevPoint, pt)
                If v.Length > 4 Then
                    Dim radius As Double = Me.StylusPoints(i).PressureFactor * 10.0
                    drawingContext.DrawEllipse(brush, pen, pt, radius, radius)
                    prevPoint = pt
                End If
            Next i
        End If
        If Me.ContainsPropertyData(guidUsingStandardRenderer) Then
            MyBase.DrawCore(drawingContext, drawingAttributes)
        End If
    
    End Sub 'DrawCore
End Class 'Stroke3D


Public Class StefansStylusControl
    Inherits Label
    Private ip As InkPresenter
    Private dynamicRenderer As PluginDescription
    Private translatePlugin As PluginDescription
    Private customrenderer As PluginDescription
    Private filterPlugin As PluginDescription
    Private stylusPoints As StylusPointCollection = Nothing
    Private inPlugins As ArrayList
    Private outPlugins As ArrayList
    Private guidUsingStandardRenderer As New Guid("772c1f44-34db-45a3-97db-5325d5e53a52")
    Private guidUsingCustomRenderer As New Guid("44df9701-c3f8-48fd-86cc-e8c9c5341826")
    
    
    
    Shared Sub New() 
        Dim ownerType As Type = GetType(StefansStylusControl)
        ClipToBoundsProperty.OverrideMetadata(ownerType, New FrameworkPropertyMetadata(True))
        FocusVisualStyleProperty.OverrideMetadata(ownerType, New FrameworkPropertyMetadata(CType(Nothing, Object)))
    
    End Sub 'New
    
    
    Public Sub New() 
        Stylus.Enable()
        ip = New InkPresenter()
        Me.Content = ip 'for label
        'this.Child = ip;  //for border
        inPlugins = New ArrayList()
        outPlugins = New ArrayList()
        
        Dim translateMatrix As New Matrix()
        translateMatrix.Translate(20.0, 50.0)
        translatePlugin.Plugin = New TransformPlugin(translateMatrix)
        translatePlugin.Name = "Translate Plugin"
        outPlugins.Add(translatePlugin)
        
        filterPlugin.Plugin = New FilterPlugin()
        filterPlugin.Name = "Filter Plugin"
        outPlugins.Add(filterPlugin)
        
        Dim cr As New CustomDynamicRenderer()
        customrenderer.Plugin = cr
        customrenderer.Name = "Custom Renderer"
        outPlugins.Add(customrenderer)
        ip.AttachVisuals(cr.RootVisual, cr.DrawingAttributes)
        'this.StylusPlugIns.Add(cr);
        Dim dr As New DynamicRenderer()
        dynamicRenderer.Plugin = dr
        dynamicRenderer.Name = "Standard Renderer"
        inPlugins.Add(dynamicRenderer)
        ip.AttachVisuals(dr.RootVisual, dr.DrawingAttributes)
        Me.StylusPlugIns.Add(dr)
    
    End Sub 'New
    
    
    Public ReadOnly Property Strokes() As StrokeCollection 
        Get
            Return ip.Strokes
        End Get
    End Property
     
    Public Sub Add(ByVal pluginToAdd As PluginDescription) 
        StylusPlugIns.Add(pluginToAdd.Plugin)
        inPlugins.Add(pluginToAdd)
        outPlugins.Remove(pluginToAdd)
    
    End Sub 'Add
    
    
    Public Sub Remove(ByVal pluginToRemove As PluginDescription) 
        StylusPlugIns.Remove(pluginToRemove.Plugin)
        inPlugins.Remove(pluginToRemove)
        outPlugins.Add(pluginToRemove)
    
    End Sub 'Remove
    
    
    Public Sub MoveUp(ByVal pluginToMoveUp As PluginDescription) 
        Dim index As Integer = inPlugins.IndexOf(pluginToMoveUp)
        If index > 0 Then
            StylusPlugIns.Remove(pluginToMoveUp.Plugin)
            StylusPlugIns.Insert(index - 1, pluginToMoveUp.Plugin)
            inPlugins.Remove(pluginToMoveUp)
            inPlugins.Insert(index - 1, pluginToMoveUp)
        End If
    
    End Sub 'MoveUp
    
    
    Public Sub MoveDown(ByVal pluginToMoveDown As PluginDescription) 
        Dim index As Integer = inPlugins.IndexOf(pluginToMoveDown)
        If index < StylusPlugIns.Count - 1 Then
            StylusPlugIns.Remove(pluginToMoveDown.Plugin)
            StylusPlugIns.Insert(index + 1, pluginToMoveDown.Plugin)
            inPlugins.Remove(pluginToMoveDown)
            inPlugins.Insert(index + 1, pluginToMoveDown)
        End If
    
    End Sub 'MoveDown
    
    
    Public ReadOnly Property InPlugins() As ArrayList 
        Get
            Return inPlugins
        End Get
    End Property 
    
    Public ReadOnly Property OutPlugins() As ArrayList 
        Get
            Return outPlugins
        End Get
    End Property
     
    Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs) 
        Stylus.Capture(Me)
        Dim newStylusPoints As StylusPointCollection = e.GetStylusPoints(Me)
        stylusPoints = New StylusPointCollection(newStylusPoints.Description)
        stylusPoints.Add(newStylusPoints)
    
    End Sub 'OnStylusDown
    
    
    Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs) 
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If
        Dim newStylusPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
        stylusPoints.Add(newStylusPoints)
    
    End Sub 'OnStylusMove
    
    
    Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs) 
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If
        Dim newStylusPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
        stylusPoints.Add(newStylusPoints)
        
        Dim stroke As New Stroke3D(stylusPoints)
        If inPlugins.Contains(customrenderer) Then
            stroke.AddPropertyData(guidUsingCustomRenderer, 1)
        End If
        If inPlugins.Contains(dynamicRenderer) Then
            stroke.AddPropertyData(guidUsingStandardRenderer, 1)
        End If
        ip.Strokes.Add(stroke)
        
        stylusPoints = Nothing
        Stylus.Capture(Nothing)
    
    End Sub 'OnStylusUp
End Class 'StefansStylusControl