' <snippet100>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes

Class MainWindow
    Inherits Window

    ' <snippet104>
    Public Sub New()
        InitializeComponent()

        Me.InitializeFlowLayoutPanel()

    End Sub
    ' </snippet104>

    ' <snippet101>
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As System.Windows.Forms.Button = sender

        b.Top = 20
        b.Left = 20

    End Sub
    ' </snippet101>

    ' <snippet102>
    Private Sub button2_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.host1.Visibility = Windows.Visibility.Hidden
    End Sub


    Private Sub button3_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.host1.Visibility = Windows.Visibility.Collapsed
    End Sub
    ' </snippet102>

    ' <snippet103>
    Private Sub InitializeFlowLayoutPanel()
        Dim flp As System.Windows.Forms.FlowLayoutPanel = Me.flowLayoutHost.Child

        flp.WrapContents = True

        Const numButtons As Integer = 6

        Dim i As Integer
        For i = 0 To numButtons
            Dim b As New System.Windows.Forms.Button()
            b.Text = "Button"
            b.BackColor = System.Drawing.Color.AliceBlue
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat

            flp.Controls.Add(b)
        Next i

    End Sub
    ' </snippet103>

End Class

' </snippet100>