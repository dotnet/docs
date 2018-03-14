
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes



'/ <summary>
'/ Interaction logic for Window3.xaml
'/ </summary>
Namespace CustomInkControlSample

    Class Window3
        Inherits Window

        Dim thumbnail1 As New InkThumbnail()

        Public Sub New()
            InitializeComponent()

            thumbnail1.Height = 100
            thumbnail1.Width = 100

            thumbnail1.Source = inkCanvas1
            inkCanvas1.Children.Add(thumbnail1)
            inkCanvas1.Background = Brushes.Green


        End Sub 'New

    End Class 'Window3 

    '<Snippet33>
    Public Class InkThumbnail
        Inherits FrameworkElement

        Private sourceInkCanvas As InkCanvas = Nothing

        ' Get the InkCanvas that the user draws on.
        Public Property Source() As InkCanvas
            Get
                Return sourceInkCanvas
            End Get

            Set(ByVal Value As InkCanvas)

                If Not sourceInkCanvas Is Nothing Then

                    ' Detach the event handler from the former InkCanvas.
                    RemoveHandler sourceInkCanvas.StrokeCollected, AddressOf SourceChanged
                End If

                sourceInkCanvas = Value


                If Not sourceInkCanvas Is Nothing Then

                    ' Attach the even handler to the InkCannvas
                    AddHandler sourceInkCanvas.StrokeCollected, AddressOf SourceChanged
                End If

            End Set
        End Property

        ' Handle the StrokeCollection event of the InkCanvas.
        Private Sub SourceChanged(ByVal sender As Object, ByVal e As InkCanvasStrokeCollectedEventArgs)

            ' Cause the thumbnail to be redrawn.
            Me.InvalidateVisual()
        End Sub


        Protected Overrides Sub OnRender(ByVal drawingContext As DrawingContext)

            MyBase.OnRender(drawingContext)

            ' Draw the strokes from the InkCanvas at 1/4 of their size.
            drawingContext.PushTransform(New ScaleTransform(0.25, 0.25))

            If Not sourceInkCanvas Is Nothing Then
                sourceInkCanvas.Strokes.Draw(drawingContext)
            End If

        End Sub

    End Class
    '</Snippet33>

End Namespace