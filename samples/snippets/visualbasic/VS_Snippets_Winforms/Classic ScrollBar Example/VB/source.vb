Option Explicit On
Option Strict On

' <Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace Scrollbar
    Public Class Form1
        Inherits System.Windows.Forms.Form

        Private WithEvents openFileDialog1 As System.Windows.Forms.OpenFileDialog
        Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
        Private WithEvents vScrollBar1 As System.Windows.Forms.VScrollBar
        Private WithEvents hScrollBar1 As System.Windows.Forms.HScrollBar

        <STAThread()> Shared Sub Main()
            Application.Run(New Form1())
        End Sub

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub InitializeComponent()
            Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.pictureBox1 = New System.Windows.Forms.PictureBox()
            Me.vScrollBar1 = New System.Windows.Forms.VScrollBar()
            Me.hScrollBar1 = New System.Windows.Forms.HScrollBar()
            Me.pictureBox1.SuspendLayout()
            Me.SuspendLayout()

            Me.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pictureBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.vScrollBar1, Me.hScrollBar1})
            Me.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pictureBox1.Size = New System.Drawing.Size(440, 349)

            Me.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right
            Me.vScrollBar1.Location = New System.Drawing.Point(422, 0)
            Me.vScrollBar1.Size = New System.Drawing.Size(16, 331)
            Me.vScrollBar1.Visible = False

            Me.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.hScrollBar1.Location = New System.Drawing.Point(0, 331)
            Me.hScrollBar1.Size = New System.Drawing.Size(438, 16)
            Me.hScrollBar1.Visible = False

            Me.Text = "Form1"
            Me.ClientSize = New System.Drawing.Size(440, 349)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pictureBox1})
            Me.pictureBox1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub


        ' <Snippet3>
        Private Sub HandleScroll(ByVal sender As [Object], ByVal e As ScrollEventArgs) _
          Handles vScrollBar1.Scroll, hScrollBar1.Scroll

            'Create a graphics object and draw a portion of the image in the PictureBox.
            Dim g As Graphics = pictureBox1.CreateGraphics()

            Dim xWidth As Integer = pictureBox1.Width
            Dim yHeight As Integer = pictureBox1.Height

            Dim x As Integer
            Dim y As Integer

            If (e.ScrollOrientation = ScrollOrientation.HorizontalScroll) Then

                x = e.NewValue
                y = vScrollBar1.Value

            Else 'e.ScrollOrientation == ScrollOrientation.VerticalScroll

                y = e.NewValue
                x = hScrollBar1.Value
            End If

            'First Rectangle: Where to draw the image.
            'Second Rectangle: The portion of the image to draw.

            g.DrawImage(pictureBox1.Image, _
              New Rectangle(0, 0, xWidth, yHeight), _
              New Rectangle(x, y, xWidth, yHeight), _
              GraphicsUnit.Pixel)

            pictureBox1.Update()
        End Sub
        ' </Snippet3>


        Private Sub pictureBox1_DoubleClick(ByVal sender As [Object], ByVal e As EventArgs) _
          Handles pictureBox1.DoubleClick

            'Ask the uesr to select a new image to display.
            'If the user does not select an image...
            If (openFileDialog1.ShowDialog() = DialogResult.Cancel) Then

                Return  '...do nothing.
            End If

            'Otherwise display the image in the picture box.
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName)

            'And see if the image needs scrollbars and refresh the image. 
            Me.DisplayScrollBars()
            Me.SetScrollBarValues()
            Me.Refresh()
        End Sub


        Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) _
          Handles MyBase.Resize

            'If the picture box does not contain an image...
            If (pictureBox1.Image Is Nothing) Then

                Return  '...do nothing.
            End If

            'Otherwise see if the image needs scrollbars and refresh the image. 
            Me.DisplayScrollBars()
            Me.SetScrollBarValues()
            Me.Refresh()
        End Sub


        Public Sub DisplayScrollBars()

            'Very Important: Reset any previous scrollbar values to 0.
            hScrollBar1.Value = 0
            vScrollBar1.Value = 0

            'If the image is wider than the picture box, show a horizontal scrollbar.
            If (pictureBox1.Image.Width > pictureBox1.Width) Then

                hScrollBar1.Visible = True
            Else
                hScrollBar1.Visible = False
            End If

            'If the image is taller than the picture box, show a vertical scrollbar.
            If (pictureBox1.Image.Height > pictureBox1.Height) Then

                vScrollBar1.Visible = True
            Else
                vScrollBar1.Visible = False
            End If
        End Sub


        ' <Snippet2>
        Public Sub SetScrollBarValues()

            'Set the following scrollbar properties:

            'Minimum: Set to 0

            'SmallChange and LargeChange: Per UI guidelines, these must be set
            '    relative to the size of the view that the user sees, not to
            '    the total size including the unseen part.  In this example,
            '    these must be set relative to the picture box, not to the image.

            'Maximum: Calculate in steps:
            'Step 1: The maximum to scroll is the size of the unseen part.
            'Step 2: Add the size of visible scrollbars if necessary.
            'Step 3: Add an adjustment factor of ScrollBar.LargeChange.


            'Configure the horizontal scrollbar
            '---------------------------------------------
            If (Me.hScrollBar1.Visible) Then

                Me.hScrollBar1.Minimum = 0
                Me.hScrollBar1.SmallChange = CInt(Me.pictureBox1.Width / 20)
                Me.hScrollBar1.LargeChange = CInt(Me.pictureBox1.Width / 10)

                Me.hScrollBar1.Maximum = Me.pictureBox1.Image.Size.Width - pictureBox1.ClientSize.Width  'step 1

                If (Me.vScrollBar1.Visible) Then 'step 2

                    Me.hScrollBar1.Maximum += Me.vScrollBar1.Width
                End If

                Me.hScrollBar1.Maximum += Me.hScrollBar1.LargeChange 'step 3
            End If

            'Configure the vertical scrollbar
            '---------------------------------------------
            If (Me.vScrollBar1.Visible) Then

                Me.vScrollBar1.Minimum = 0
                Me.vScrollBar1.SmallChange = CInt(Me.pictureBox1.Height / 20)
                Me.vScrollBar1.LargeChange = CInt(Me.pictureBox1.Height / 10)

                Me.vScrollBar1.Maximum = Me.pictureBox1.Image.Size.Height - pictureBox1.ClientSize.Height 'step 1

                If (Me.hScrollBar1.Visible) Then 'step 2

                    Me.vScrollBar1.Maximum += Me.hScrollBar1.Height
                End If

                Me.vScrollBar1.Maximum += Me.vScrollBar1.LargeChange 'step 3
            End If
         End Sub
        ' </Snippet2>
    End Class
End Namespace
' </Snippet1>
