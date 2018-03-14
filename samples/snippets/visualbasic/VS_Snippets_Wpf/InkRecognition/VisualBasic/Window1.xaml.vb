'<Snippet2>
Imports System.Windows
Imports Microsoft.Ink
Imports System.IO

'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Namespace InkRecognition

    Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub 'New


        ' Recognizes handwriting by using RecognizerContext
        Private Sub buttonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Using ms As New MemoryStream()
                theInkCanvas.Strokes.Save(ms)
                Dim myInkCollector As InkCollector = New InkCollector()
                Dim ink As Ink = New Ink()
                ink.Load(ms.ToArray())

                Using context As New RecognizerContext()
                    If ink.Strokes.Count > 0 Then
                        context.Strokes = ink.Strokes
                        Dim status As RecognitionStatus

                        Dim result As RecognitionResult = context.Recognize(status)

                        If status = RecognitionStatus.NoError Then
                            textBox1.Text = result.TopString
                        Else
                            MessageBox.Show("Recognition failed")
                        End If
                    Else
                        MessageBox.Show("No stroke detected")
                    End If
                End Using
            End Using
        End Sub 'buttonClick

        Private Sub btnClear_Click(sender As Object, e As RoutedEventArgs)
            theInkCanvas.Strokes.Clear()
        End Sub
    End Class 'Window1 
End Namespace

'</Snippet2>