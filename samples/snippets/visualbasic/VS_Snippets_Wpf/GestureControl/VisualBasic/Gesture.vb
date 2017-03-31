 '<Snippet1>
Imports System
Imports System.Collections
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Input.StylusPlugIns
Imports System.Collections.ObjectModel

Class RealTimeInkControl
    Inherits Border

    Private presenter As InkPresenter
    Private recognizer As GestureRecognizer
    Private renderer As DynamicRenderer
    Private stylusPoints As StylusPointCollection
    
    Public Sub New() 

        recognizer = New GestureRecognizer()
        
        ClipToBoundsProperty.OverrideMetadata(GetType(RealTimeInkControl), _
            New FrameworkPropertyMetadata(True))
        
        ' Use an InkPresenter to display the strokes on the custom control.
        presenter = New InkPresenter()
        Me.Child = presenter

        ' Initialize the DynamicRenderer.
        renderer = New DynamicRenderer()
        Me.StylusPlugIns.Add(renderer)
        presenter.AttachVisuals(renderer.RootVisual, renderer.DrawingAttributes)

    End Sub 'New
    
    ' Begin collecting stylus packets.
    Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs)

        MyBase.OnStylusDown(e)
        Stylus.Capture(Me)

        Dim eventPoints As StylusPointCollection = e.GetStylusPoints(Me)
        stylusPoints = New StylusPointCollection(eventPoints.Description)
        stylusPoints.Add(eventPoints)

    End Sub 'OnStylusDown
    
    ' Collect the stylus packets as the stylus moves.
    Protected Overrides Sub OnStylusMove(ByVal e As StylusEventArgs) 

        MyBase.OnStylusMove(e)
        stylusPoints.Add(e.GetStylusPoints(Me))

    End Sub 'OnStylusMove
    
    
    '<Snippet3>
    ' Create a stroke from the packets and check if it is a gesture.
    Protected Overrides Sub OnStylusUp(ByVal e As StylusEventArgs) 

        MyBase.OnStylusUp(e)
        stylusPoints.Add(e.GetStylusPoints(Me))

        Dim stroke As New Stroke(stylusPoints)
        
        ' If the stroke was a gesture, put the name of the gesture
        ' in the title bar.  Otherwise, add the stroke to the control.
        If recognizer.IsRecognizerAvailable Then
            Dim gestureStrokes As New StrokeCollection()
            gestureStrokes.Add(stroke)
            Dim results As ReadOnlyCollection(Of GestureRecognitionResult)
            results = recognizer.Recognize(gestureStrokes)

            If results.Count > 0 _
               AndAlso results(0).ApplicationGesture <> _
               ApplicationGesture.NoGesture _
               AndAlso results(0).RecognitionConfidence = _
               RecognitionConfidence.Strong Then

                Application.Current.Windows(0).Title = _
                    results(0).ApplicationGesture.ToString()
            Else
                presenter.Strokes.Add(stroke)
                Application.Current.Windows(0).Title = ""
            End If
        Else
            presenter.Strokes.Add(stroke)
        End If
        Stylus.Capture(Nothing)
    
    End Sub 'OnStylusUp
    
    '</Snippet3>

    '</Snippet1>
    Private Sub ConstructorSnippet() 
        '<Snippet4>
        ' Declare and initialize an array of application gestures.
        Dim gestures As ApplicationGesture() = _
            {ApplicationGesture.Down, _
             ApplicationGesture.Right, _
             ApplicationGesture.Scratchout}
        
        Dim recognizer As New GestureRecognizer(gestures)
        '</Snippet4>

    End Sub 'ConstructorSnippet
    
    Private Sub SetApplicationGestures() 
        '<Snippet5>
        ' Declare and initialize an array of application gestures.
        Dim gestures As ApplicationGesture() = _
            {ApplicationGesture.Down, _
             ApplicationGesture.Right, _
             ApplicationGesture.Scratchout}

        Dim recognizer As New GestureRecognizer()
        
        recognizer.SetEnabledGestures(gestures)
        '</Snippet5>

        '<Snippet6>
        Dim enableGestures As ReadOnlyCollection(Of ApplicationGesture)
        enableGestures = recognizer.GetEnabledGestures()
        '</Snippet6>
    End Sub 'SetApplicationGestures 

    '<Snippet8>
    Private Function InterpretScratchoutGesture(ByVal stroke As Stroke) As Boolean
        ' Attempt to instantiate a recognizer for scratchout gestures.
        Dim gestures() As ApplicationGesture = {ApplicationGesture.ScratchOut}

        Dim recognizer As New GestureRecognizer(gestures)

        If Not recognizer.IsRecognizerAvailable Then
            Return False
        End If

        ' Determine if the stroke was a scratchout gesture.
        Dim gestureStrokes As StrokeCollection = New StrokeCollection()
        gestureStrokes.Add(stroke)

        Dim results As ReadOnlyCollection(Of GestureRecognitionResult)
        results = recognizer.Recognize(gestureStrokes)

        If results.Count = 0 Then
            Return False
        End If

        ' Results are returned sorted in order strongest-to-weakest; 
        ' we need only analyze the first (strongest) result.
        If (results(0).ApplicationGesture = ApplicationGesture.ScratchOut) Then

            ' Use the scratchout stroke to perform hit-testing and 
            ' erase existing strokes, as necessary.
            Return True
        Else
            ' Not a gesture: display the stroke normally.
            Return False
        End If
    End Function
    '</Snippet8>

'<Snippet2>
End Class 'RealTimeInkControl
'</Snippet2>

Class Program
    Inherits Application
    Private win As Window
    Private inkControl As RealTimeInkControl

    Protected Overrides Sub OnStartUp(ByVal args As StartupEventArgs)
        MyBase.OnStartup(args)
        win = New Window()
        inkControl = New RealTimeInkControl()
        inkControl.Background = Brushes.Beige
        win.Content = inkControl
        win.Show()

    End Sub 'OnStartingUp


    '<STAThread()>  _
    'Shared Sub Main(ByVal args() As String) 
    '    New Program().Run()

    'End Sub 'Main
End Class 'Program
'<Snippet7>

'</Snippet7>