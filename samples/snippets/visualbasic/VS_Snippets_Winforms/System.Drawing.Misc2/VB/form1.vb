Option Explicit On 
Option Strict On


Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'UseTransparentProperty()

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(112, 160)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 88)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(184, 88)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
' The following code example demonstrates the following members:
    '   Rectangle.#ctor(PointF, SizeF)
    '   StringFormat#ctor(StringFormatFlags)
    '   StringFormat.#ctor(StringFormat)
    '   StringFormat.Alignment
    '   StringAlignment
    '   StringFormatFlags
    ' This example is designed to be used with 
    ' Windows Forms. Paste the code into a form and call the
    ' ShowLineAndAlignment method when handling the form's Paint event,
    ' passing e as PaintEventArgs.
    '<snippet1>
    Private Sub ShowLineAndAlignment(ByVal e As PaintEventArgs)

        ' Construct a new Rectangle.
        Dim displayRectangle _
            As New Rectangle(New Point(40, 40), New Size(80, 80))

        ' Construct two new StringFormat objects
        Dim format1 As New StringFormat(StringFormatFlags.NoClip)
        Dim format2 As New StringFormat(format1)

        ' Set the LineAlignment and Alignment properties for
        ' both StringFormat objects to different values.
        format1.LineAlignment = StringAlignment.Near
        format1.Alignment = StringAlignment.Center
        format2.LineAlignment = StringAlignment.Center
        format2.Alignment = StringAlignment.Far

        ' Draw the bounding rectangle and a string for each
        ' StringFormat object.
        e.Graphics.DrawRectangle(Pens.Black, displayRectangle)
        e.Graphics.DrawString("Showing Format1", Me.Font, Brushes.Red, _
            RectangleF.op_Implicit(displayRectangle), format1)
        e.Graphics.DrawString("Showing Format2", Me.Font, Brushes.Red, _
            RectangleF.op_Implicit(displayRectangle), format2)
    End Sub
    '</snippet1>


    ' The following example shows how to set the Trimming property
    ' and how to use the StringTrimming enumeration. This example
    ' is designed to be used with a Windows Form. Paste this code
    ' into a form and call the ShowStringTrimming method when
    ' handling the form's Paint event, passing e as PaintEventArgs.
    '<snippet6>
    Private Sub ShowStringTrimming(ByVal e As PaintEventArgs)

        Dim format1 As New StringFormat
        Dim quote As String = "Not everything that can be counted counts," & _
            " and not everything that counts can be counted."
        format1.Trimming = StringTrimming.EllipsisWord
        e.Graphics.DrawString(quote, Me.Font, Brushes.Black, _
            New RectangleF(10.0F, 10.0F, 90.0F, 50.0F), format1)
    End Sub
    '</snippet6>

    Private Sub Form1_Paint(ByVal sender As Object, _
    ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        'ShowLineAndAlignment(e)
        'DemonstrateBlend(e)
        'ShowStringTrimming(e)

    End Sub

    ' The following code example demonstrates how to use the 
    ' Transparent property. 
    ' This example is designed to be used with Windows Forms.  
    ' Paste the code into a form that contains two buttons named Button1
    ' and Button2. Call the UseTransparentProperty method in the 
    ' form's constructor.
    '<snippet2>
    Private Sub UseTransparentProperty()

        ' Set up the PictureBox to display the entire image, and
        ' to cover the entire client area.
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Dock = DockStyle.Fill

        Try
            ' Set the Image property of the PictureBox to an image retrieved
            ' from the file system.
            PictureBox1.Image = _
                Image.FromFile("C:\Documents and Settings\All Users\" _
                & "Documents\My Pictures\Sample Pictures\sunset.jpg")

            ' Set the Parent property of Button1 and Button2 to the 
            ' PictureBox.
            Button1.Parent = PictureBox1
            Button2.Parent = PictureBox1

            ' Set the Color property of both buttons to transparent. 
            ' With this setting, the buttons assume the color of their
            ' parent.
            Button1.BackColor = Color.Transparent
            Button2.BackColor = Color.Transparent

        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("There was an error." _
            & "Make sure the image file path is valid.")
        End Try


    End Sub
    '</snippet2>

    ' The following code example demonstrates how to use the equality
    ' operator and construct a Point from a Size. It also 
    ' demonstrates the use of the X and Y properties.
    ' This example is designed to be used with Windows Forms.  
    ' Paste the code into a form that contains a button named Button1
    ' and associate the Button1_Click method with the button's Click event.
    '<snippet3>
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Construct a new Point with integers.
        Dim Point1 As New Point(100, 100)

        ' Create a Graphics object.
        Dim formGraphics As Graphics = Me.CreateGraphics()

        ' Construct another Point, this time using a Size.
        Dim Point2 As New Point(New Size(100, 100))

        ' Call the equality operator to see if the points are equal,  
        ' and if so print out their x and y values.
        If (Point.op_Equality(Point1, Point2)) Then
            formGraphics.DrawString(String.Format("Point1.X: " & _
                "{0},Point2.X: {1}, Point1.Y: {2}, Point2.Y {3}", _
                New Object() {Point1.X, Point2.X, Point1.Y, Point2.Y}), _
                Me.Font, Brushes.Black, New PointF(10, 70))
        End If

    End Sub
    '</snippet3>

    ' The following code example demonstrates how to use the Name
    ' property of a Color.
    ' This example is designed to be used with Windows Forms.  
    ' Paste the code into a form that contains a button named Button2
    ' and associate the Button2_Click method with the button's 
    ' Click event.
    '<snippet4>
    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Button2.Width = 100
        Button2.Text = "Color: " + Button2.BackColor.Name
    End Sub
    '</snippet4>

    ' The following code example demonstrates how to use the Blend
    ' class by setting the Factors and Positions properties.
    ' This example is designed to be used with Windows Forms.  
    ' Paste the code into a form that imports the 
    ' System.Drawing.Drawing2D namespace. Handle the form's Paint
    ' event and call the DemonstrateBlend method, passing e as 
    ' PaintEventArgs.
    '<snippet5>
    Private Sub DemonstrateBlend(ByVal e As PaintEventArgs)
        Dim blend1 As New Blend(9)

        ' Set the values in the Factors array to be all green, 
        ' go to all blue, and then go back to green.
        blend1.Factors = New Single() {0.0F, 0.2F, 0.5F, 0.7F, 1.0F, _
            0.7F, 0.5F, 0.2F, 0.0F}

        ' Set the positions.
        blend1.Positions = New Single() {0.0F, 0.1F, 0.3F, 0.4F, 0.5F, _
            0.6F, 0.7F, 0.8F, 1.0F}

        ' Declare a rectangle to draw the Blend in.
        Dim rectangle1 As New Rectangle(10, 10, 120, 100)

        ' Create a new LinearGradientBrush using the rectangle, 
        ' green and blue. and 90-degree angle.
        Dim brush1 As New LinearGradientBrush(rectangle1, _
            Color.LightGreen, Color.Blue, 90, True)

        ' Set the Blend property on the brush to the custom blend.
        brush1.Blend = blend1

        ' Fill in an ellipse with the brush.
        e.Graphics.FillEllipse(brush1, rectangle1)

        ' Dispose of the custom brush.
        brush1.Dispose()
    End Sub
    '</snippet5>



    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class



