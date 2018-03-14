
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Ink
Imports System.Windows.Input.StylusPlugIns


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits Window '

    Private customInkCanvas As CustomRenderingInkCanvas
    Private ic As InkCanvas
    Private filterInkCanvas As FilterInkCanvas
    Private textbox1 As TextBox
    Private control As InkControl


    Public Sub New() 
        InitializeComponent()
        
        customInkCanvas = New CustomRenderingInkCanvas()
        'root.Children.Add(customInkCanvas)

        filterInkCanvas = New FilterInkCanvas()
        root.Children.Add(filterInkCanvas)

        customInkCanvas.EditingModeInverted = InkCanvasEditingMode.EraseByPoint
        AddHandler customInkCanvas.StrokeCollected, AddressOf customInkCanvas_StrokeCollected
        
        AddHandler ClearStrokes.Click, AddressOf ClearStrokes_Click
        WindowState = WindowState.Maximized
    
    End Sub 'New
    
    
    Private Sub ClearStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        customInkCanvas.Strokes.Clear()

    End Sub 'ClearStrokes_Click
    
    
    Private Sub customInkCanvas_StrokeCollected(ByVal sender As Object, ByVal e As InkCanvasStrokeCollectedEventArgs)
        System.Diagnostics.Debug.WriteLine("customInkCanvase_StrokeCollected")
        e.Stroke.DrawingAttributes.Color = Colors.Green
        If TypeOf e.Stroke Is CustomStroke Then
            System.Diagnostics.Debug.WriteLine("stroke is custom")
        Else
            System.Diagnostics.Debug.WriteLine("stroke is not custom")
        End If

        If customInkCanvas.Strokes.Contains(e.Stroke) Then
            System.Diagnostics.Debug.WriteLine("stroke is in ink canvas")
        Else
            System.Diagnostics.Debug.WriteLine("stroke is not in ink canvas") 'always lands here
        End If

        System.Diagnostics.Debug.WriteLine("")

    End Sub 'customInkCanvas_StrokeCollected
End Class 'Window1 

'<Snippet4>
Public Class FilterInkCanvas
    Inherits InkCanvas
    Private filter As New FilterPlugin()


    Public Sub New()
        Me.StylusPlugIns.Add(filter)

    End Sub 'New
End Class 'FilterInkCanvas
'</Snippet4>

'<Snippet5>
Public Class DynamicallyFilteredInkCanvas
    Inherits InkCanvas

    Private filter As New FilterPlugin()

    Public Sub New()
        Dim dynamicRenderIndex As Integer = Me.StylusPlugIns.IndexOf(Me.DynamicRenderer)

        Me.StylusPlugIns.Insert(dynamicRenderIndex, filter)

    End Sub 'New 

End Class 'DynamicallyFilteredInkCanvas
'</Snippet5>

'<Snippet9>
Public Class CustomRenderingInkCanvas
    Inherits InkCanvas

    Private customRenderer As New CustomDynamicRenderer()

    Public Sub New()
        ' Use the custom dynamic renderer on the
        ' custom InkCanvas.
        Me.DynamicRenderer = customRenderer

    End Sub 'New

    Protected Overrides Sub OnStrokeCollected(ByVal e As InkCanvasStrokeCollectedEventArgs)

        ' Remove the original stroke and add a custom stroke.
        Me.Strokes.Remove(e.Stroke)
        Dim customStroke As New CustomStroke(e.Stroke.StylusPoints)
        Me.Strokes.Add(customStroke)

        ' Pass the custom stroke to base class' OnStrokeCollected method.
        Dim args As New InkCanvasStrokeCollectedEventArgs(customStroke)
        MyBase.OnStrokeCollected(args)

    End Sub 'OnStrokeCollected 
End Class 'CustomRenderingInkCanvas
'</Snippet9>
