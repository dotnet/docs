
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Ink
Imports System.Windows.Input


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

'<Snippet1>
Class Window1
    Inherits Window '

    Private inkPresenter1 As InkPresenter
    
    
    Public Sub New() 
        InitializeComponent()
    
    End Sub 'New
     
    
    Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs) 

        inkPresenter1 = New InkPresenter()
        Me.Content = inkPresenter1
        
        Dim segment1Start As New StylusPoint(200, 110)
        Dim segment1End As New StylusPoint(185, 150)
        Dim segment2Start As New StylusPoint(185, 150)
        Dim segment2End As New StylusPoint(135, 150)
        Dim segment3Start As New StylusPoint(135, 150)
        Dim segment3End As New StylusPoint(175, 180)
        Dim segment4Start As New StylusPoint(175, 180)
        Dim segment4End As New StylusPoint(160, 220)
        Dim segment5Start As New StylusPoint(160, 220)
        Dim segment5End As New StylusPoint(200, 195)
        Dim segment6Start As New StylusPoint(200, 195)
        Dim segment6End As New StylusPoint(240, 220)
        Dim segment7Start As New StylusPoint(240, 220)
        Dim segment7End As New StylusPoint(225, 180)
        Dim segment8Start As New StylusPoint(225, 180)
        Dim segment8End As New StylusPoint(265, 150)
        Dim segment9Start As New StylusPoint(265, 150)
        Dim segment9End As New StylusPoint(215, 150)
        Dim segment10Start As New StylusPoint(215, 150)
        Dim segment10End As New StylusPoint(200, 110)
        
        Dim strokePoints As New StylusPointCollection()
        
        strokePoints.Add(segment1Start)
        strokePoints.Add(segment1End)
        strokePoints.Add(segment2Start)
        strokePoints.Add(segment2End)
        strokePoints.Add(segment3Start)
        strokePoints.Add(segment3End)
        strokePoints.Add(segment4Start)
        strokePoints.Add(segment4End)
        strokePoints.Add(segment5Start)
        strokePoints.Add(segment5End)
        strokePoints.Add(segment6Start)
        strokePoints.Add(segment6End)
        strokePoints.Add(segment7Start)
        strokePoints.Add(segment7End)
        strokePoints.Add(segment8Start)
        strokePoints.Add(segment8End)
        strokePoints.Add(segment9Start)
        strokePoints.Add(segment9End)
        strokePoints.Add(segment10Start)
        strokePoints.Add(segment10End)
        
        Dim newStroke As New Stroke(strokePoints)
        inkPresenter1.Strokes.Add(newStroke)
    
    End Sub 'WindowLoaded
End Class 'Window1 
'</Snippet1>