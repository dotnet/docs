
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Ink
Imports Microsoft.Win32
Imports System.IO


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits Window '

    Private theInkCanvas As InkCanvas
    Private cbSelectionMode As CheckBox
    
    
    Public Sub New() 
        'InitializeComponent()
    
    End Sub
    
    
    Sub CodeExamples() 
        '<Snippet8>
        ' Set the selection mode based on a checkbox
        If CBool(cbSelectionMode.IsChecked) Then
            theInkCanvas.EditingMode = InkCanvasEditingMode.Select
        Else
            theInkCanvas.EditingMode = InkCanvasEditingMode.Ink
        End If
        '</Snippet8>

        '<Snippet9>
        ' Get the selected strokes from the InkCanvas
        Dim selection As StrokeCollection = theInkCanvas.GetSelectedStrokes()
        
        ' Check to see if any strokes are actually selected
        If selection.Count > 0 Then
            ' Change the color of each stroke in the collection to red
            Dim stroke As System.Windows.Ink.Stroke
            For Each stroke In  selection
                stroke.DrawingAttributes.Color = System.Windows.Media.Colors.Red
            Next stroke
        End If
        '</Snippet9>

    End Sub
    
    '<Snippet12>
    Private Sub buttonSaveAsClick(ByVal sender As Object, ByVal e As RoutedEventArgs) 

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "isf files (*.isf)|*.isf"

        If saveFileDialog1.ShowDialog() Then
            Dim fs As New FileStream(saveFileDialog1.FileName, FileMode.Create)
            theInkCanvas.Strokes.Save(fs)
            fs.Close()
        End If
    
    End Sub
    '</Snippet12>

    '<Snippet13>
    Private Sub buttonLoadClick(ByVal sender As Object, ByVal e As RoutedEventArgs) 

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "isf files (*.isf)|*.isf"

        If openFileDialog1.ShowDialog() Then
            Dim fs As New FileStream(openFileDialog1.FileName, FileMode.Open)
            theInkCanvas.Strokes = New StrokeCollection(fs)
            fs.Close()
        End If
    
    End Sub
    '</Snippet13>
    'Window1 
End Class