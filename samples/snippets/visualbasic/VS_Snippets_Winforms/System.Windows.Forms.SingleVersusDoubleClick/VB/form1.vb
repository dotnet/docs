' <Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace SingleVersusDoubleClick

    Class Form1
        Inherits Form
        Private hitTestRectangle As New Rectangle()
        Private doubleClickRectangle As New Rectangle()
        Private textBox1 As New TextBox()
        Private WithEvents doubleClickTimer As New Timer()
        Private doubleClickBar As New ProgressBar()
        Private label1 As New Label()
        Private label2 As New Label()
        Private isFirstClick As Boolean = True
        Private isDoubleClick As Boolean = False
        Private milliseconds As Integer = 0

        <STAThread()> _
        Public Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Public Sub New()
            label1.Location = New Point(30, 5)
            label1.Size = New Size(100, 15)
            label1.Text = "Hit test rectangle:"

            label2.Location = New Point(30, 70)
            label2.Size = New Size(100, 15)
            label2.Text = "Double click timer:"

            hitTestRectangle.Location = New Point(30, 20)
            hitTestRectangle.Size = New Size(100, 40)
            doubleClickTimer.Interval = 100

            doubleClickBar.Location = New Point(30, 85)
            doubleClickBar.Minimum = 0
            doubleClickBar.Maximum = SystemInformation.DoubleClickTime

            textBox1.Location = New Point(30, 120)
            textBox1.Size = New Size(200, 100)
            textBox1.AutoSize = False
            textBox1.Multiline = True

            Me.Controls.Add(doubleClickBar)
            Me.Controls.Add(textBox1)
            Me.Controls.Add(label1)
            Me.Controls.Add(label2)
        End Sub

        ' <Snippet10>
        ' Detect a valid single click or double click.
        Sub Form1_MouseDown(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles Me.MouseDown

            ' Verify that the mouse click is in the main hit
            ' test rectangle.
            If Not hitTestRectangle.Contains(e.Location) Then
                Return
            End If

            ' This is the first mouse click.
            If isFirstClick = True Then
                isFirstClick = False

                ' Determine the location and size of the double click 
                ' rectangle to draw around the cursor point.
                doubleClickRectangle = New Rectangle( _
                    e.X - (SystemInformation.DoubleClickSize.Width / 2), _
                    e.Y - (SystemInformation.DoubleClickSize.Height / 2), _
                    SystemInformation.DoubleClickSize.Width, _
                    SystemInformation.DoubleClickSize.Height)
                Invalidate()

                ' Start the double click timer.
                doubleClickTimer.Start()

            ' This is the second mouse click.
            Else
                ' Verify that the mouse click is within the double click
                ' rectangle and is within the system-defined double 
                ' click period.
                If doubleClickRectangle.Contains(e.Location) And _
                    milliseconds < SystemInformation.DoubleClickTime Then
                    isDoubleClick = True
                End If
            End If
        End Sub
        ' </Snippet10>

        Sub doubleClickTimer_Tick(ByVal sender As Object, _
            ByVal e As EventArgs) Handles doubleClickTimer.Tick

            milliseconds += 100
            doubleClickBar.Increment(100)

            ' The timer has reached the double click time limit.
            If milliseconds >= SystemInformation.DoubleClickTime Then
                doubleClickTimer.Stop()

                If isDoubleClick Then
                    textBox1.AppendText("Perform double click action")
                    textBox1.AppendText(Environment.NewLine)
                Else
                    textBox1.AppendText("Perform single click action")
                    textBox1.AppendText(Environment.NewLine)
                End If

                ' Allow the MouseDown event handler to process clicks again.
                isFirstClick = True
                isDoubleClick = False
                milliseconds = 0
                doubleClickBar.Value = 0
            End If
        End Sub

        ' Paint the hit test and double click rectangles.
        Sub Form1_Paint(ByVal sender As Object, _
            ByVal e As PaintEventArgs) Handles Me.Paint

            ' Draw the border of the main hit test rectangle.
            e.Graphics.DrawRectangle(Pens.Black, hitTestRectangle)

            ' Fill in the double click rectangle.
            e.Graphics.FillRectangle(Brushes.Blue, doubleClickRectangle)
        End Sub
    End Class
End Namespace
' </Snippet0>