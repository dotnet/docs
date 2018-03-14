 '<snippet1>
Imports System.Windows.Controls
Imports System.Windows.Ink
Imports System.Windows.Input

' This control initializes with ink already on it and allows the
' user to erase the ink with the stylus.

Namespace MyInkEraser
    Public Class InkEraser
        Inherits Border
        Private eraseTester As IncrementalStrokeHitTester

        '<Snippet5>
        Private presenter As InkPresenter

        '<Snippet8>
        ' The base-64 encoded string that contains ink data 
        ' in ink serialized format (ISF).
        Private strokesString As String = _
            "AOoFAxBIEEVqGwIAWf9GahsCAFn/GRQyCACAEAIAAABCMwgAgA" _
            & "wCAAAAQhWrqtNBq6rTQaVh0MSr+ivFHyEVVFVVVVV1OkBUVVVVVXU6QJ7" _
            & "0SZ80DJrAVFVVVVV/pcAKU3yC/gEb+AX/k5Z8PwWBO5KktgJSUAAKjzyC" _
            & "wBZYLEoCJLd+Cbti873JlTUvn158doCC/gKb+ApwAJslSywE2ALAAWPPI" _
            & "FhKWBKWAKAmwJVglAKACiMjgv3d+8Xi+fHWM2WC0zcm89+NSoL+A5P4Dl" _
            & "uNlhFIqpLKAAoaF4L+AhP4CFAWAWCggv4Dc/gNty2yy5SrlKAKIhyC/gI" _
            & "b+Ai+JZc2XZOyb46vLQCC/gOL+A5YDNlWFjN3CwAKQFeC/gOr+A7VhUFZ" _
            & "KCsS2WTc2SyhKuWVLR3ly2LAXx574ssUgv4Dm/gOcCwEEpUTYSixUsuWy" _
            & "gVZ79AQsWGyWUAKLCiC/gQT+BA9SWbllDfGqy3Lcu+OmfH8EIL+BDv4EP" _
            & "XLKSpY3lVFhZuVZvKACkFggv4F2/gXlKLFuCVKTcsqUlkoRKBmk8zfFll" _
            & "S2ySlACwAgv4Ds/gO+WWWWLBLFllllSksAoSkWG1kSbFu5AoAAAo/YoL+" _
            & "Biv4GJJU+P4qSalUBKWdkBYCbm+Nliyk1CVKgCxYNYqC/gQb+BBwO8ABY" _
            & "olDz4gAEzaw2AVCUKAsWCooCiAegv4Hw/gfEJe8zUoSgLCC/gNT+A0xM7" _
            & "Gdmdliay2VaAo0PoL+B7v4Hx5Yq3lc2xZsseeC3N8aDXjUpWW4UIL+A5P" _
            & "4DnhYqAIWFkqpcrLZuJuWqSyxVAovNoL+CJP4IjnlkDvHeSbSVd9FqFlI" _
            & "oWAAgv4Dk/gOVc7gbmdyZ1LajFFJmlRKsoAKVXmC/go7+CjdRvredypaK" _
            & "myLC7ytZQqFiyWbikAEvfg2pSVKS7liSwWJNsrbi4CC/gQD+A/9M2ACxU" _
            & "qKjcVuXKiosCWWKQSyhvKRUUWULCwEmyyu4gA="
        '</Snippet8>

        Public Sub New()

            presenter = New InkPresenter()
            Me.Child = presenter

            '// Create a StrokeCollection the string and add it to
            Dim converter As _
                New StrokeCollectionConverter()

            If converter.CanConvertFrom(GetType(String)) Then

                Dim newStrokes As StrokeCollection
                newStrokes = converter.ConvertFrom(strokesString)
                presenter.Strokes.Clear()
                presenter.Strokes.Add(newStrokes)

            End If


        End Sub 'New

        '</Snippet5>

        '<Snippet6>

        '<Snippet4>
        ' Prepare to collect stylus packets. Get the 
        ' IncrementalHitTester from the InkPresenter's 
        ' StrokeCollection and subscribe to its StrokeHitChanged event.
        Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs)

            MyBase.OnStylusDown(e)

            Dim eraserTip As New EllipseStylusShape(3, 3, 0)
            eraseTester = presenter.Strokes.GetIncrementalStrokeHitTester(eraserTip)
            AddHandler eraseTester.StrokeHit, _
                AddressOf eraseTester_StrokeHit
            eraseTester.AddPoints(e.GetStylusPoints(Me))

        End Sub 'OnStylusDown
        '</Snippet4>

        '<Snippet9>
        ' Collect the StylusPackets as the stylus moves.
        Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs)

            If eraseTester.IsValid Then
                eraseTester.AddPoints(e.GetStylusPoints(Me))
            End If

        End Sub 'OnStylusMove
        '</Snippet9>

        '<Snippet10>
        ' Unsubscribe from the StrokeHitChanged event when the
        ' user lifts the stylus.
        Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs)

            eraseTester.AddPoints(e.GetStylusPoints(Me))

            RemoveHandler eraseTester.StrokeHit, _
                AddressOf eraseTester_StrokeHit
            eraseTester.EndHitTesting()
   
        End Sub 'OnStylusUp
        '</Snippet10>


        '<Snippet2>
        ' When the stylus intersects a stroke, erase that part of
        ' the stroke.  When the stylus dissects a stoke, the 
        ' Stroke.Erase method returns a StrokeCollection that contains
        ' the two new strokes.
        Private Sub eraseTester_StrokeHit(ByVal sender As Object, _
                ByVal args As StrokeHitEventArgs)

            Dim eraseResult As StrokeCollection = _
                args.GetPointEraseResults()
            Dim strokesToReplace As New StrokeCollection()
            strokesToReplace.Add(args.HitStroke)

            ' Replace the old stroke with the new one.
            If eraseResult.Count > 0 Then
                presenter.Strokes.Replace(strokesToReplace, eraseResult)
            Else
                presenter.Strokes.Remove(strokesToReplace)
            End If

        End Sub 'eraseTester_StrokeHit 
        '</Snippet2>

        '</Snippet6>

        '</snippet1>

        '<snippet11>
        Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)

            MyBase.OnMouseLeftButtonDown(e)

            If Not e.StylusDevice Is Nothing Then
                Return
            End If

            Dim eraserTip As EllipseStylusShape = New EllipseStylusShape(3, 3, 0)
            eraseTester = _
                presenter.Strokes.GetIncrementalStrokeHitTester(eraserTip)
            AddHandler eraseTester.StrokeHit, _
                AddressOf eraseTester_StrokeHit
            eraseTester.AddPoint(e.GetPosition(Me))

        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            If Not e.StylusDevice Is Nothing Or eraseTester Is Nothing Then
                Return
            End If

            If (eraseTester.IsValid) Then
                eraseTester.AddPoint(e.GetPosition(Me))
            End If
        End Sub

        Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs)
            MyBase.OnMouseLeftButtonUp(e)

            If Not e.StylusDevice Is Nothing Then
                Return
            End If

            eraseTester.AddPoint(e.GetPosition(Me))
            RemoveHandler eraseTester.StrokeHit, _
                AddressOf eraseTester_StrokeHit
            eraseTester.EndHitTesting()
        End Sub
        '</snippet11>

        Public Sub ResetInk()
            LoadStrokes()

        End Sub

        '<Snippet3>
        ' Accepts a string that contains ink data in ink 
        ' serialized format (ISF) and converts it into a StrokeCollection.
        Public Sub LoadStrokes()

            Dim converter As New StrokeCollectionConverter()

            If converter.CanConvertFrom(GetType(String)) Then
                Dim newStrokes As StrokeCollection

                newStrokes = converter.ConvertFrom(Nothing, Nothing, strokesString)
                presenter.Strokes.Clear()
                presenter.Strokes.Add(newStrokes)

            End If

        End Sub
        '</Snippet3>

        '<Snippet7>
    End Class 'InkEraser 
End Namespace
'</Snippet7>