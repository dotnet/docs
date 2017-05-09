
Imports System
Imports System.Windows
Imports System.Windows.Ink
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel
Imports System.Windows.Input

'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits Window

    Dim WithEvents inkCanvas1 As InkCanvas
    Dim canvas1 As Canvas

    Public Sub New() 
        'InitializeComponent()
        inkCanvas1 = New InkCanvas()
        inkCanvas1.Background = Brushes.Green
        Me.Content = inkCanvas1

        canvas1 = New Canvas()

        '<Snippet2>
        Stylus.SetIsFlicksEnabled(canvas1, False)
        '</Snippet2>

        '<Snippet4>
        Stylus.SetIsTapFeedbackEnabled(canvas1, False)
        '</Snippet4>

        '<Snippet5>
        Dim tapFeedbackEnabled As Boolean = Stylus.GetIsTapFeedbackEnabled(canvas1)
        '</Snippet5>

        '<Snippet6>
        Dim flicksEnabled As Boolean = Stylus.GetIsFlicksEnabled(canvas1)
        '</Snippet6>

    End Sub 'New
    
    Private Sub TouchFeedbackSnippets()

        '<Snippet8>
        Stylus.SetIsTouchFeedbackEnabled(inkCanvas1, True)
        '</Snippet8>

        '<Snippet7>
        Dim touchFeedbackEnabled As Boolean = _
            Stylus.GetIsTouchFeedbackEnabled(inkCanvas1)
        '</Snippet7>
    End Sub

    ' To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
    Private Sub OnLoad(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles Me.Loaded

        inkCanvas1.EditingMode = InkCanvasEditingMode.InkAndGesture
        'AddHandler inkCanvas1.Gesture, AddressOf inkCanvas1_Gesture

        '<Snippet3>
        ' Add this code to the contstructor or OnLoaded method.
        If (inkCanvas1.IsGestureRecognizerAvailable) Then

            inkCanvas1.EditingMode = InkCanvasEditingMode.InkAndGesture

            Dim gestures() As ApplicationGesture = _
                                {ApplicationGesture.Down, _
                                 ApplicationGesture.ArrowDown, _
                                 ApplicationGesture.Circle}

            inkCanvas1.SetEnabledGestures(gestures)
        End If
        '</Snippet3>
    End Sub 'OnLoad


    ' Sample event handler:  
    Private Sub button1_click(ByVal sender As Object, ByVal e As RoutedEventArgs)

    End Sub 'button1_click



    '<Snippet1>
    Sub inkCanvas1_Gesture(ByVal sender As Object, _
        ByVal e As InkCanvasGestureEventArgs) Handles inkCanvas1.Gesture

        Dim gestureResults As ReadOnlyCollection(Of GestureRecognitionResult)
        gestureResults = e.GetGestureRecognitionResults()

        ' Check the first recognition result for a gesture.
        If gestureResults(0).RecognitionConfidence = _
           RecognitionConfidence.Strong Then

            Select Case gestureResults(0).ApplicationGesture
                Case ApplicationGesture.Down
                    ' Do something.
                Case ApplicationGesture.ArrowDown
                    ' Do something.
                Case ApplicationGesture.Circle
                    ' Do something.
            End Select

        End If

    End Sub 'inkCanvas1_Gesture
    '</Snippet1>
End Class 'Window1 

'
'ToDo: Error processing original source shown below
'    }
'}
'-^--- expression expected