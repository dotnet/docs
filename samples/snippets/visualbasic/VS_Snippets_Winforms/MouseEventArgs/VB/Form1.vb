Public Class Form1

    '<SNIPPET1>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.ContextMenu = New ContextMenu()
    End Sub

    Private Sub TextBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox1.MouseDown
        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            TextBox1.Select(0, TextBox1.Text.Length)
        End If
    End Sub
    '</SNIPPET1>

    '<SNIPPET2>
    Dim FirstPoint As Point
    Dim HaveFirstPoint As Boolean = False

    Private Sub Form1_MouseDownDrawing(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If HaveFirstPoint Then
            Dim g As Graphics = Me.CreateGraphics()
            g.DrawLine(Pens.Black, FirstPoint, e.Location)
            HaveFirstPoint = False
        Else
            FirstPoint = e.Location
            HaveFirstPoint = True
        End If
    End Sub
    '</SNIPPET2>

    '<SNIPPET3>
    Dim TrackTip As ToolTip

    Private Sub TrackCoordinates()
        TrackTip = New ToolTip()
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim TipText As String = String.Format("({0}, {1})", e.X, e.Y)
        TrackTip.Show(TipText, Me, e.Location)
    End Sub
    '</SNIPPET3>

End Class
