
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Imports System.Windows.Input
Imports System.Windows.Ink
Imports System.Windows.Input.StylusPlugIns



Public Class StylusControl
    Inherits Label
    Private inkPresenter1 As InkPresenter
    Private dynamicRenderer1 As DynamicRenderer

    ' Declare the StylusPointsCollection where we'll 
    ' gather points before creating a Stroke from them
    Private stylusPoints As StylusPointCollection = Nothing
    Private filterPlugin1 As FilterPlugin
    Private cdr As CustomDynamicRenderer2
    Private recoPlugin As RecognizerPlugin
    
    Private currentAttributes As DrawingAttributes
    Private playPoints As StylusPointCollection
    
    
    Shared Sub New() 

        ' Allow ink to be drawn only within the bounds of the control.
        Dim owner As Type = GetType(StylusControl)
        ClipToBoundsProperty.OverrideMetadata(owner, New FrameworkPropertyMetadata(True))
    
    End Sub 'New
    
    
    Public Sub New() 

        ' Add an InkPresenter for drawing
        inkPresenter1 = New InkPresenter()
        
        ' When StylusContol is a Label
        Me.Content = inkPresenter1
        
        ' Add a custom filter plugin that restricts the 
        ' input area first, before rendering occurs
        filterPlugin1 = New FilterPlugin()
        AddHandler filterPlugin1.StrokeRendered, AddressOf filterPlugin1_StrokeRendered
        Me.StylusPlugIns.Add(filterPlugin1)

        cdr = New CustomDynamicRenderer2()
        cdr.DrawingAttributes.Color = Colors.Green
        currentAttributes = cdr.DrawingAttributes
        inkPresenter1.AttachVisuals(cdr.RootVisual, cdr.DrawingAttributes)

        'Me.StylusPlugIns.Add(cdr)
        
        AttatchDynamicRenderer()

        recoPlugin = New RecognizerPlugin()
        'Me.StylusPlugIns.Add(recoPlugin)
    
    End Sub 'New

    Public Sub ChangeDAOnCustomDR() 
        If Not StylusPlugIns.Contains(cdr) Then
            Return
        End If
        
        cdr.DrawingAttributes.Color = Colors.Red

    End Sub 'ChangeDAOnCustomDR
    
    Private Sub filterPlugin1_StrokeRendered(ByVal sender As Object, ByVal e As StrokeRenderedEventArgs)

        filterPlugin1.RecordPoints(e.StrokePoints, "StrokeRendered")
        Dim newStroke As New Stroke(e.StrokePoints, currentAttributes)
        inkPresenter1.Strokes.Add(newStroke)

    End Sub 'filterPlugin1_StrokeRendered
    
    Private stylus1 As StylusDevice = Nothing
    Private stylus2 As StylusDevice = Nothing
    
    
    Protected Overrides Sub OnStylusInRange(ByVal e As StylusEventArgs) 

        If Not e.Inverted Then
            stylus1 = e.StylusDevice
        Else
            stylus2 = e.StylusDevice
        End If
    
    End Sub 'OnStylusInRange
     

    Protected Overrides Sub OnStylusOutOfRange(ByVal e As StylusEventArgs) 
    
    End Sub 'OnStylusOutOfRange
    

    Private Sub AttatchDynamicRenderer() 
        '<Snippet3>
        ' Create a DrawingAttributes to use for the 
        ' DynamicRenderer.
        Dim inkDA As New DrawingAttributes()
        inkDA.Width = 5
        inkDA.Height = 5
        inkDA.Color = Colors.Purple
        
        ' Add a dynamic renderer plugin that 
        ' draws ink as it "flows" from the stylus
        Dim dynamicRenderer1 As New DynamicRenderer()
        dynamicRenderer1.DrawingAttributes = inkDA
        
        Me.StylusPlugIns.Add(dynamicRenderer1)
        inkPresenter1.AttachVisuals(dynamicRenderer1.RootVisual, dynamicRenderer1.DrawingAttributes)
        '</Snippet3>

    End Sub 'AttatchDynamicRenderer
    

    
    Private Sub DrawRect(ByVal rect As Rect) 
    
    End Sub 'DrawRect

    Public Property FilterEnabled() As Boolean 
        Get
            Return filterPlugin1.Enabled
        End Get
        Set
            filterPlugin1.Enabled = value
        End Set
    End Property
     
    
    
    Public Function AddRemoveDynamicRenderer() As Boolean 
        Dim containsPlugin As Boolean = Me.StylusPlugIns.Contains(dynamicRenderer1)
        If containsPlugin Then
            StylusPlugIns.Remove(dynamicRenderer1)
        Else
            StylusPlugIns.Insert(0, dynamicRenderer1)
        End If

        Return Not containsPlugin
    
    End Function 'AddRemoveDynamicRenderer 
    
    
    Public ReadOnly Property IsDynamicRendererActive() As Boolean 
        Get
            Return dynamicRenderer1.IsActiveForInput
        End Get
    End Property
    
    
    Public Function AddRemoveFilterPlugin() As Boolean 
        Dim containsPlugin As Boolean = Me.StylusPlugIns.Contains(filterPlugin1)
        If containsPlugin Then
            StylusPlugIns.Remove(filterPlugin1)
        Else
            StylusPlugIns.Add(filterPlugin1)
        End If
        
        Return Not containsPlugin
    
    End Function 'AddRemoveFilterPlugin 
    
    
    Public ReadOnly Property IsFilterPluginActive() As Boolean 
        Get
            Return filterPlugin1.IsActiveForInput
        End Get
    End Property
    
    
    Public Function RemovePluginSample() As Boolean 
        '<Snippet2>
        If Me.StylusPlugIns.Contains(filterPlugin1) Then
            StylusPlugIns.Remove(filterPlugin1)
        End If
        '</Snippet2>
        Return Me.StylusPlugIns.Contains(filterPlugin1)
    
    End Function 'RemovePluginSample
     
    
    Sub PluginCollectionSnippets() 
        '<Snippet5>
        Me.StylusPlugIns.Clear()
        '</Snippet5>
        '<Snippet6>
        Dim plugIns(Me.StylusPlugIns.Count) As StylusPlugIn
        Me.StylusPlugIns.CopyTo(plugIns, 0)
        '</Snippet6>
        '<Snippet7>
        If Me.StylusPlugIns.Count > 0 Then
            Dim firstPlugin As StylusPlugIn = Me.StylusPlugIns(0)
        End If
        '</Snippet7>

    End Sub 'PluginCollectionSnippets

    '<Snippet4>
    Public Sub MoveDownPlugIn(ByVal pluginToMoveDown As StylusPlugIn) 
        Dim index As Integer = Me.StylusPlugIns.IndexOf(pluginToMoveDown)
        
        ' If the plug-in isn't already the last one in the
        ' StylusPluginCollection, move it down one position.
        If index < StylusPlugIns.Count - 1 Then
            StylusPlugIns.RemoveAt(index)
            StylusPlugIns.Insert(index + 1, pluginToMoveDown)
        End If
    
    End Sub 'MoveDownPlugIn
    
    '</Snippet4>
    
    Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)
        MyBase.OnMouseLeftButtonDown(e)

        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If

        Dim pt As Point = e.GetPosition(Me)

        Dim collectedPoints As New StylusPointCollection(New Point() {pt})

        stylusPoints = New StylusPointCollection()

        stylusPoints.Add(collectedPoints)

    End Sub 'OnMouseLeftButtonDown
    
    
    Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs) 
        
        Stylus.Capture(Me)
        
        'Get the StylusPoints that have come in so far
        Dim newStylusPoints As StylusPointCollection = e.GetStylusPoints(Me)
        
        ' Allocate memory for the StylusPointsCollection and
        ' add the StylusPoints that have come in so far
        'stylusPoints = new StylusPointCollection(newStylusPoints.Description);
        'stylusPoints.Add(newStylusPoints);
        'Create a new StylusPointCollection using the StylusPointDescription
        'from the stylus points in the StylusDownEventArgs.
        stylusPoints = New StylusPointCollection()
        Dim eventPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
        
        stylusPoints.Add(eventPoints)
    
    End Sub 'OnStylusDown
     
    
    
    Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs) 
        ' Allocate memory for the StylusPointsCollection, if necessary
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If
        
        ' Add the StylusPoints that have come in since the last call to OnStylusMove
        Dim newStylusPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
        stylusPoints.Add(newStylusPoints)
    
    End Sub 'OnStylusMove
    
    
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
        
        Dim collectedPoints As New StylusPointCollection(New Point() {pt})
        
        stylusPoints.Add(collectedPoints)
    
    End Sub 'OnMouseMove
    
    
    Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs) 
        ' Allocate memory for the StylusPointsCollection, if necessary
        If stylusPoints Is Nothing Then
            stylusPoints = New StylusPointCollection()
        End If
        
        ' Add the StylusPoints that have come in since the last call to OnStylusMove
        Dim newStylusPoints As StylusPointCollection = e.GetStylusPoints(Me, stylusPoints.Description)
        stylusPoints.Add(newStylusPoints)
        
        ' Create a new custom stroke from all the StylusPoints since OnStylusDown
        'Stroke3D stroke = new Stroke3D(stylusPoints);
        Dim stroke As New Stroke(stylusPoints, currentAttributes.Clone())
        
        ' Add the new stroke to the Strokes collection of the InkPresenter
        inkPresenter1.Strokes.Add(stroke)
        
        ' Clear out the StylusPointsCollection
        stylusPoints = Nothing
        
        ' Release stylus capture
        Stylus.Capture(Nothing)
    
    End Sub 'OnStylusUp
    
    'Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs)

    '    MyBase.OnMouseLeftButtonUp(e)

    '    If stylusPoints Is Nothing Then
    '        Return
    '    End If

    '    If playPoints Is Nothing Then
    '        playPoints = stylusPoints
    '    End If

    '    Dim stroke As Stroke = New Stroke(stylusPoints, currentAttributes.Clone())

    '    ' Add the new stroke to the Strokes collection of the InkPresenter
    '    inkPresenter1.Strokes.Add(stroke)

    '    ' Clear out the StylusPointsCollection
    '    stylusPoints = Nothing
    'End Sub

    '<Snippet13>
    Private selectionMode As Boolean = False
    
    
    Public Sub ToggleSelect() 
        Dim currentStylus As StylusDevice = Stylus.CurrentStylusDevice
        
        ' Check if the stylus is down or the mouse is pressed.
        If Mouse.LeftButton <> MouseButtonState.Pressed AndAlso _
          (currentStylus Is Nothing OrElse currentStylus.InAir) Then
            Return
        End If
        
        selectionMode = Not selectionMode
        
        ' If the control is in selection mode, change the color of 
        ' the current stroke dark gray.
        If selectionMode Then
            dynamicRenderer1.DrawingAttributes.Color = Colors.DarkGray
        
        Else
            dynamicRenderer1.DrawingAttributes.Color = Colors.Purple
        End If 
        
        dynamicRenderer1.Reset(currentStylus, stylusPoints)
    
    End Sub 'ToggleSelect
    '</Snippet13>

    Public Sub ClearInk() 

        inkPresenter1.Strokes.Clear()
    
    End Sub 'ClearInk
End Class 'StylusControl