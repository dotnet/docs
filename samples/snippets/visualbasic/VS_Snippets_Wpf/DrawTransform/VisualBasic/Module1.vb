Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Ink
Imports System.Windows.Media

Namespace DrawTransformSample

    Public Class DrawTransformApp
        Inherits Application

        Dim myWindow As Window
        Dim myCanvas As Canvas
        Dim myIC As InkCanvas
        Dim myLabel As Label
        Dim myMatrix As Matrix
        Dim myVisuals As VisualCollection

        Protected Overrides Sub OnStartup(ByVal args As System.Windows.StartupEventArgs)
            'MyBase.OnStartingUp(args)

            myWindow = New Window()

            ' Create new Canvas
            ' and connect it to the top-level Window
            myCanvas = New Canvas()
            myWindow.Content = myCanvas

            myIC = New InkCanvas()

            ' You must set a background to get stroke events
            myIC.Background = Brushes.LightGray

            ' Get each stroke as it is added to the InkCanvas
            AddHandler myIC.StrokeCollected, AddressOf myIC_StrokeCollected

            myIC.SetValue(Canvas.TopProperty, 30.0R)
            myIC.SetValue(Canvas.LeftProperty, 30.0R)
            myIC.SetValue(Canvas.WidthProperty, 450.0R)
            myIC.SetValue(Canvas.HeightProperty, 400.0R)

            ' Add the InkCanvas to the Canvas
            myCanvas.Children.Add(myIC)

            myLabel = New Label()

            myLabel.Background = Brushes.Salmon
            myLabel.SetValue(Canvas.TopProperty, 30.0R)
            myLabel.SetValue(Canvas.LeftProperty, 500.0R)
            myLabel.SetValue(Canvas.WidthProperty, 450.0R)
            myLabel.SetValue(Canvas.HeightProperty, 400.0R)

            ' Add the Label to the Canvas
            myCanvas.Children.Add(myLabel)

            myMatrix = New Matrix()

            ' Shrink the new Stroke by 50% in both dimensions
            ' The new Stroke added to the label should appear
            ' in the upper-left quadrant
            myMatrix.Scale(0.5, 0.5)

            ' Display the Window
            myWindow.Show()

        End Sub

        Public Enum dMode
            dCOnly
            dCandDA
            all
        End Enum

        Dim _state As dMode = dMode.dCOnly

        Private Sub myIC_StrokeCollected(ByVal sender As Object, ByVal e As InkCanvasStrokeCollectedEventArgs)
            ' Create a copy of the new Stroke object
            Dim myStroke As Stroke = e.Stroke.Clone()

            ' Draw stroke based on state
            If _state = dMode.dCOnly Then
                drawDCOnly(myStroke)
            ElseIf _state = dMode.dCandDA Then
                drawDCandDA(myStroke)
            Else
                drawAll(myStroke)
            End If
        End Sub

        ' <Snippet1>
        Function DrawDCOnly(ByVal myStroke As Stroke) As DrawingVisual

            ' Create new Visual context to draw on
            Dim myVisual As DrawingVisual = New DrawingVisual()
            Dim myContext As DrawingContext = myVisual.RenderOpen()

            ' myMatrix is scaled by:
            ' myMatrix.Scale(0.5, 0.5)
            myStroke.Transform(myMatrix, False)

            ' Draw the stroke on the Visual context using DrawingContext
            myStroke.Draw(myContext)

            ' Close the context
            myContext.Close()

            Return myVisual

        End Function
        ' </Snippet1>

        ' <Snippet2>
        Function DrawDCandDA(ByVal myStroke As Stroke) As DrawingVisual

            ' Create new Visual context to draw on
            Dim myVisual As DrawingVisual = New DrawingVisual()
            Dim myContext As DrawingContext = myVisual.RenderOpen()

            ' Draw stroke using DrawingContext and DrawingAttributes
            ' (to make the stroke magenta)
            Dim myDAs As DrawingAttributes = New DrawingAttributes()
            myDAs.Color = Colors.Magenta

            myStroke.Draw(myContext, myDAs)

            ' Close the context
            myContext.Close()

            Return myVisual

        End Function
        ' </Snippet2>

        Sub drawAll(ByVal myStroke As Stroke)
            ' <Snippet3>
            Dim myPIDs As Guid() = myStroke.GetPropertyDataIds()
            ' </Snippet3>
        End Sub

        Public Shared Sub Main()
            Dim myDTA = New DrawTransformApp()
            myDTA.run()
        End Sub

    End Class

End Namespace
