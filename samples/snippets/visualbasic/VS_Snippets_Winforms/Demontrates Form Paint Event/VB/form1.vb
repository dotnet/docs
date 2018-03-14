Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(504, 273)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    '<snippet1>
    Dim RcDraw As Rectangle
    Dim PenWidth As Integer = 5


    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        ' Determine the initial rectangle coordinates...

        RcDraw.X = e.X
        RcDraw.Y = e.Y

    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

        ' Determine the width and height of the rectangle...

        If e.X < RcDraw.X Then
            RcDraw.Width = RcDraw.X - e.X
            RcDraw.X = e.X
        Else
            RcDraw.Width = e.X - RcDraw.X
        End If

        If e.Y < RcDraw.Y Then
            RcDraw.Height = RcDraw.Y - e.Y
            RcDraw.Y = e.Y
        Else
            RcDraw.Height = e.Y - RcDraw.Y
        End If

        ' Force a repaint of the region occupied by the rectangle...

        Me.Invalidate(RcDraw)

    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        ' Draw the rectangle...

        e.Graphics.DrawRectangle(New Pen(Color.Blue, PenWidth), RcDraw)

    End Sub


    '</snippet1>
End Class
