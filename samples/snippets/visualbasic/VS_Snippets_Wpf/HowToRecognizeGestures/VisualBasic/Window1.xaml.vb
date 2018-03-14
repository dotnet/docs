 '<Snippet1>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Ink
Imports System.Collections.ObjectModel

Class Window1
    Inherits Window

    Public Sub New()
        InitializeComponent()

        If inkCanvas1.IsGestureRecognizerAvailable Then
            inkCanvas1.EditingMode = InkCanvasEditingMode.InkAndGesture
            AddHandler inkCanvas1.Gesture, AddressOf inkCanvas1_Gesture
            inkCanvas1.SetEnabledGestures(New ApplicationGesture() {ApplicationGesture.ScratchOut})
        End If

    End Sub 'New

    Private Sub inkCanvas1_Gesture(ByVal sender As Object, ByVal e As InkCanvasGestureEventArgs)

        Dim gestureResults As ReadOnlyCollection(Of GestureRecognitionResult) = _
                              e.GetGestureRecognitionResults()

        ' Check the first recognition result for a gesture.
        If gestureResults(0).RecognitionConfidence = _
           RecognitionConfidence.Strong AndAlso _
           gestureResults(0).ApplicationGesture = _
           ApplicationGesture.ScratchOut Then

            Dim hitStrokes As StrokeCollection = _
                inkCanvas1.Strokes.HitTest(e.Strokes.GetBounds(), 10)

            If hitStrokes.Count > 0 Then
                inkCanvas1.Strokes.Remove(hitStrokes)
            End If
        End If

    End Sub 'inkCanvas1_Gesture
End Class 'Window1
'</Snippet1>