 '<Snippet2>
Imports System.IO
Imports System.Windows
Imports System.Windows.Ink
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Windows.Media

Class Window1
    Inherits Window

    Public Sub New() 
        InitializeComponent()
    
    End Sub

    '<Snippet3>
    Private Sub InkCanvas_PreviewMouseDown(ByVal sender As Object, _
                                   ByVal e As MouseButtonEventArgs)

        Dim ic As InkCanvas = CType(sender, InkCanvas)

        Dim pt As Point = e.GetPosition(ic)

        ' If the user is moving selected strokes, prepare the strokes to be
        ' moved to another InkCanvas.
        If ic.HitTestSelection(pt) = InkCanvasSelectionHitResult.Selection Then

            Dim selectedStrokes As StrokeCollection = _
                                   ic.GetSelectedStrokes()

            Dim strokesToMove As StrokeCollection = _
                                 selectedStrokes.Clone()

            ' Remove the offset of the selected strokes so they
            ' are positioned when the strokes are dropped.
            Dim inkBounds As Rect = strokesToMove.GetBounds()
            TranslateStrokes(strokesToMove, -inkBounds.X, -inkBounds.Y)

            ' Perform drag and drop.
            Dim ms As New MemoryStream()
            strokesToMove.Save(ms)

            Dim dataObject As New DataObject _
                (StrokeCollection.InkSerializedFormat, ms)

            Dim effects As DragDropEffects = _
                DragDrop.DoDragDrop(ic, dataObject, DragDropEffects.Move)

            If (effects And DragDropEffects.Move) = DragDropEffects.Move Then

                ' Remove the selected strokes from the current InkCanvas.
                ic.Strokes.Remove(selectedStrokes)
            End If
        End If

    End Sub
    '</Snippet3>

    Private Sub InkCanvas_Drop(ByVal sender As Object, _
                       ByVal e As DragEventArgs)

        ' Get the strokes that were moved.
        Dim ic As InkCanvas = CType(sender, InkCanvas)
        Dim ms As MemoryStream = CType(e.Data.GetData( _
                  StrokeCollection.InkSerializedFormat),  _
                  MemoryStream)

        ms.Position = 0
        Dim strokes As New StrokeCollection(ms)

        ' Translate the strokes to the position at which
        ' they were dropped.
        Dim pt As Point = e.GetPosition(ic)
        TranslateStrokes(strokes, pt.X, pt.Y)

        ' Add the strokes to the InkCanvas and keep them selected.
        ic.Strokes.Add(strokes)
        ic.Select(strokes)

    End Sub

    ' Helper method that transletes the specified strokes.
    Sub TranslateStrokes(ByVal strokes As StrokeCollection, _
                         ByVal x As Double, ByVal y As Double)

        Dim mat As New Matrix()
        mat.Translate(x, y)
        strokes.Transform(mat, False)

    End Sub
    
    
    Private Sub switchToSelect(ByVal sender As Object, _
                       ByVal e As RoutedEventArgs)

        ic1.EditingMode = InkCanvasEditingMode.Select
        ic2.EditingMode = InkCanvasEditingMode.Select

    End Sub
    
    
    Private Sub switchToInk(ByVal sender As Object, _
                    ByVal e As RoutedEventArgs)

        ic1.EditingMode = InkCanvasEditingMode.Ink
        ic2.EditingMode = InkCanvasEditingMode.Ink

    End Sub

End Class
'</Snippet2>