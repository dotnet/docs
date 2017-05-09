
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Text
Imports System.Windows
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Input.StylusPlugIns
Imports System.Diagnostics


'<Snippet12>
Class RecognizerPlugin
    Inherits StylusPlugIn
    Private recognizer As GestureRecognizer

    '<Snippet20>
    ' StylusPointCollection that contains the stylus points of the current
    ' stroke.
    Private points As StylusPointCollection

    ' Keeps track of the stylus to check whether two styluses are used on the
    ' digitizer.
    Private currentStylus As Integer
    '</Snippet20>

    Public Sub New()
        recognizer = New GestureRecognizer()

    End Sub 'New


    ' <Snippet15>
    ' Collect the points as the user draws the stroke.
    Protected Overrides Sub OnStylusDown(ByVal rawStylusInput As RawStylusInput)

        ' If points is not null, there is already a stroke taking place
        ' on the digitizer, so don't create a new StylusPointsCollection.
        If points Is Nothing Then
            points = New StylusPointCollection(rawStylusInput.GetStylusPoints().Description)
            points.Add(rawStylusInput.GetStylusPoints())
            currentStylus = rawStylusInput.StylusDeviceId
        End If

    End Sub 'OnStylusDown

    ' Collect the points as the user draws the stroke.
    Protected Overrides Sub OnStylusMove(ByVal rawStylusInput As RawStylusInput)

        ' Check whether the stylus that started the stroke is the same, and
        ' that the element hasn't lost focus since the stroke began.
        If Not (points Is Nothing) AndAlso currentStylus = rawStylusInput.StylusDeviceId Then
            points.Add(rawStylusInput.GetStylusPoints())
        End If

    End Sub 'OnStylusMove

    ' Collect the points as the user draws the stroke.
    Protected Overrides Sub OnStylusUp(ByVal rawStylusInput As RawStylusInput)

        ' Check whether the stylus that started the stroke is the same, and
        ' that the element hasn't lost focus since the stroke began.
        If Not (points Is Nothing) AndAlso currentStylus = rawStylusInput.StylusDeviceId Then
            points.Add(rawStylusInput.GetStylusPoints())

            ' Subscribe to the OnStylusUpProcessed method.
            rawStylusInput.NotifyWhenProcessed(points)
        End If

        points = Nothing
        currentStylus = 0

    End Sub 'OnStylusUp
    ' </Snippet15>

    '<Snippet14>
    ' If the element loses focus, stop collecting the points and don't
    ' perform gesture recognition.
    Protected Overrides Sub OnStylusLeave(ByVal rawStylusInput As RawStylusInput, ByVal confirmed As Boolean)

        If confirmed Then
            ' Clear the StylusPointCollection
            points = Nothing
            currentStylus = 0
        End If

    End Sub 'OnStylusLeave
    '</Snippet14>

    ' This method is called on the application thread.
    Protected Overrides Sub OnStylusUpProcessed(ByVal callbackData As Object, ByVal targetVerified As Boolean)

        ' Check that the element actually receive the OnStylusUp input.
        If targetVerified AndAlso recognizer.IsRecognizerAvailable Then

            Dim strokePoints As StylusPointCollection = callbackData

            If strokePoints Is Nothing Then
                Return
            End If

            ' Create a StrokeCollection to pass to the GestureRecognizer.
            Dim newStroke As New Stroke(strokePoints)
            Dim strokes As New StrokeCollection()
            strokes.Add(newStroke)

            Dim results As ReadOnlyCollection(Of GestureRecognitionResult) = recognizer.Recognize(strokes)

            ' If the GestureRecognizer recognizes the stroke as a Down
            ' gesture with strong confidence, raise an event.
            If results(0).ApplicationGesture = ApplicationGesture.Down AndAlso _
               results(0).RecognitionConfidence = RecognitionConfidence.Strong Then
                'raise event
            End If
        End If

    End Sub 'OnStylusUpProcessed 
End Class 'RecognizerPlugin
'</Snippet12>
