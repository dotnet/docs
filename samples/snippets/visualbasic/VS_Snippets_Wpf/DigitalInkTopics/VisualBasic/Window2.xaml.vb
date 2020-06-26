
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


'/ <summary>
'/ Interaction logic for Window2.xaml
'/ </summary>

Class Window2
    Inherits Window

    Public Sub New()
        InitializeComponent()

    End Sub
    
    
    ' <Snippet4>
    Private Sub RightMouseUpHandler(ByVal sender As Object, _
                                    ByVal e As System.Windows.Input.MouseButtonEventArgs)

        Dim m As New Matrix()
        m.Scale(1.1, 1.1)
        CType(sender, InkCanvas).Strokes.Transform(m, True)

    End Sub
    ' </Snippet4>
End Class
