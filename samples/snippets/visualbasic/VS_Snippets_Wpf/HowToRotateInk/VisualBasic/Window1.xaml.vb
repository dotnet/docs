Imports System.Windows.Ink
' Interaction logic for Window1.xaml
Partial Public Class Window1
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub

    '<Snippet2>
    ' Button.Click event handler that rotates the strokes
    ' and copies them to a Canvas.
    Private Sub button_Click(ByVal sender As Object, _
                             ByVal e As RoutedEventArgs)

        Dim copiedStrokes As StrokeCollection = inkCanvas1.Strokes.Clone()
        Dim rotatingMatrix As New Matrix()
        Dim canvasLeft As Double = Canvas.GetLeft(inkCanvas1)
        Dim canvasTop As Double = Canvas.GetTop(inkCanvas1)
        Dim rotatePoint As New Point(canvas1.Width / 2, canvas1.Height / 2)

        rotatingMatrix.RotateAt(90, rotatePoint.X, rotatePoint.Y)
        copiedStrokes.Transform(rotatingMatrix, False)
        inkPresenter1.Strokes = copiedStrokes
    End Sub
    '</Snippet2>
End Class
