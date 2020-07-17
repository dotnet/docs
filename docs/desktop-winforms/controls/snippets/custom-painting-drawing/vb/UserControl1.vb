Imports System.Drawing
Imports System.Windows.Forms

Public Class UserControl1

    '<OnPaintMethod>
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Declare and instantiate a drawing pen.
        Using myPen = New System.Drawing.Pen(Color.Aqua)

            ' Create a rectangle that represents the size of the control, minus 1 pixel.
            Dim area = New Rectangle(New Point(0, 0), New Size(Me.Size.Width - 1, Me.Size.Height - 1))

            ' Draw an aqua rectangle in the rectangle represented by the control.
            e.Graphics.DrawRectangle(myPen, area)

        End Using
    End Sub
    '</OnPaintMethod>
End Class
