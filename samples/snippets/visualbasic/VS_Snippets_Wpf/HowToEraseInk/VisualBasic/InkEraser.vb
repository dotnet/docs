 '<Snippet1>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.IO

' This control initializes with ink already on it and allows the
' user to erase the ink with the tablet pen or mouse.

Public Class InkEraser
    Inherits Label
    Private eraseTester As IncrementalStrokeHitTester
    
    Private presenter As InkPresenter
    
    ' The base-64 encoded string that contains ink data 
    ' in ink serialized format (ISF).
    Private strokesString As String = _
         "ALwHAxdIEETLgIgERYQBGwIAJAFGhAEbAgAkAQUBOBkgMgkA9P8CAekiOkUzCQD4n" _
        & "wIBWiA6RTgIAP4DAAAAgH8RAACAPx8JEQAAAAAAAPA/CiUHh/A6N4HR0AivFX8Vs" _
        & "IfsiuyLSaIeDSLwabiHm0GgUDi+KZkACjsQh/A9t4IC5VJpfLhaIxyxXIh7Dncnh" _
        & "+6e7qODwoERlPAw8EpGoJAgh61IKjCYXBYDA4DAIHF67KIHAAojB4fwMteBn+RKB" _
        & "lziaIfwWTeCwePqbM8WgIeeQCDQOFRvcIAKNA+H8B8XgQHkUbjQTTnGuaZns3l4h" _
        & "/DWt4a0YKBBOA94D6HRCAiGnp5CS8LExMLB1tOgYIAKUBOH8KnXhU7lMold+tcbi" _
        & "kChkqu2EtPYxp9bmYCH8HDHg4ZhMIwRyMHH+4Jt8nleX8c0/D/AkYwxJGiHkkQgM" _
        & "Ch9CqcFhMDQCBwWAwuR2eAACmgdh/EpF4lA6XMUfhMXgMHgVDxBFpRKpZII5EINA" _
        & "OA64M+J4Lw1CIoAh/B2x4PS4bQodAopEI5IJBki4waEx2Qy+dy+ayHgleEmmHH8c" _
        & "e3MZOCGw5TWd3CwsHAwMCgRAEAgElKwOHZKBApaGIfxezeL0uN02N8IzwaGEpNIJ" _
        & "ZxHnELyOj0GfyuU6FgmhplIgIfwYgeDHeaI1vjOtZgcHgHAYb9hUCgEFgsPm1xnM" _
        & "ZkYhsnYJgZeZh4uAgCgnSBIOJv4OAgwCmkgh/GrR41X4dGoRJL9EKra5HKY7IZ3C" _
        & "4fj/M06olSoU8kkehUbh8jkMdCH8IJXhAXhMCk8JuNlmNyh0YiEumUwn2wMRxyHw" _
        & "2TzWmzeb02OzGKxMITwIhnrjzbb44zRhGEKRhCM4zrr6sQKXRWH8kuXkmPj0DiXC" _
        & "gcJbC9HZZgkKgUG4bLh3YrwJHAYw2CAh/CiN4Tq7DOZr4BB/AFtdOWW5P2h1Wkzv" _
        & "l4+YwqXf8d5fZ7ih51QKbB4LQrLAYDBIDABA4BO4nAICApvIIfy4BeXA2DRSrQlL" _
        & "oHHsYQ/KMXlsvl8rn8Xkcdg+G9NVaUWimUDYk9Ah/BoF4M0YBCqZPYqk8dwLf7hD" _
        & "YNBJFLKBNqZTqNubWshl9VoM1reFYZYQEBGUsDAwKEjYuDQKBgICBgCAgIOAg4nI" _
        & "8OACloSh/BFl4Gf/IOt6FXfF8F4ToPCZzlPwP4+B+DHmQO847rfDeCcG8eKh/EZV" _
        & "4i9eZt8A9nUF8VzxaUe5grl7YrPaHfpRKJNx4yHmUuj1vicwmMBEAjUVgKB61A="

    Public Sub New() 
        presenter = New InkPresenter()
        Me.Content = presenter
        
        ' Create a StrokeCollection the string and add it to
        Dim converter As New StrokeCollectionConverter()
        
        If converter.CanConvertFrom(GetType(String)) Then
            Dim newStrokes As StrokeCollection = converter.ConvertFrom(strokesString)

            presenter.Strokes.Clear()
            presenter.Strokes.Add(newStrokes)
        End If
    
    End Sub
     
    Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs) 

        MyBase.OnStylusDown(e)
        Dim points As StylusPointCollection = e.GetStylusPoints(Me)

        InitializeEraserHitTester(points)

    End Sub
     
    Protected Overrides Sub OnMouseLeftButtonDown(ByVal e As MouseButtonEventArgs) 

        MyBase.OnMouseLeftButtonDown(e)

        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If

        Dim pt As Point = e.GetPosition(Me)

        Dim collectedPoints As New StylusPointCollection(New Point() {pt})

        InitializeEraserHitTester(collectedPoints)

    End Sub
    
    ' Get the IncrementalHitTester from the InkPresenter's 
    ' StrokeCollection and subscribe to its StrokeHitChanged event.
    Private Sub InitializeEraserHitTester(ByVal points As StylusPointCollection) 

        Dim eraserTip As New EllipseStylusShape(3, 3, 0)
        eraseTester = presenter.Strokes.GetIncrementalStrokeHitTester(eraserTip)
        AddHandler eraseTester.StrokeHit, AddressOf eraseTester_StrokeHit
        eraseTester.AddPoints(points)
    
    End Sub
    
    
    Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs) 
        Dim points As StylusPointCollection = e.GetStylusPoints(Me)
        
        AddPointsToEraserHitTester(points)
    
    End Sub
    
    
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs) 
        MyBase.OnMouseMove(e)
        
        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If
        
        If e.LeftButton = MouseButtonState.Released Then
            Return
        End If
        
        Dim pt As Point = e.GetPosition(Me)
        
        Dim collectedPoints As New StylusPointCollection(New Point() {pt})
        
        AddPointsToEraserHitTester(collectedPoints)
    
    End Sub
    
    
    ' Collect the StylusPackets as the stylus moves.
    Private Sub AddPointsToEraserHitTester(ByVal points As StylusPointCollection) 

        If eraseTester.IsValid Then
            eraseTester.AddPoints(points)
        End If
    
    End Sub
    
    
    ' Unsubscribe from the StrokeHitChanged event when the
    ' user lifts the stylus.
    Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs) 

        Dim points As StylusPointCollection = e.GetStylusPoints(Me)
        
        StopEraseHitTesting(points)
    
    End Sub
    
    
    Protected Overrides Sub OnMouseLeftButtonUp(ByVal e As MouseButtonEventArgs) 

        MyBase.OnMouseLeftButtonUp(e)
        
        If Not (e.StylusDevice Is Nothing) Then
            Return
        End If
        
        Dim pt As Point = e.GetPosition(Me)
        
        Dim collectedPoints As New StylusPointCollection(New Point() {pt})
        
        StopEraseHitTesting(collectedPoints)
    
    End Sub
    
    
    Private Sub StopEraseHitTesting(ByVal points As StylusPointCollection) 

        eraseTester.AddPoints(points)
        RemoveHandler eraseTester.StrokeHit, AddressOf eraseTester_StrokeHit
        eraseTester.EndHitTesting()
    
    End Sub
    
    ' When the stylus intersects a stroke, erase that part of
    ' the stroke.  When the stylus dissects a stoke, the 
    ' Stroke.Erase method returns a StrokeCollection that contains
    ' the two new strokes.
    Private Sub eraseTester_StrokeHit(ByVal sender As Object, ByVal args As StrokeHitEventArgs)

        Dim eraseResult As StrokeCollection = args.GetPointEraseResults()
        Dim strokesToReplace As New StrokeCollection()
        strokesToReplace.Add(args.HitStroke)

        ' Replace the old stroke with the new one.
        If eraseResult.Count > 0 Then
            presenter.Strokes.Replace(strokesToReplace, eraseResult)
        Else
            presenter.Strokes.Remove(strokesToReplace)
        End If

    End Sub
End Class
'</Snippet1>