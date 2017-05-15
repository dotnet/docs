Option Strict On
Option Explicit On 

Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System
Imports System.Windows.Forms

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        DrawFirstRectangle()
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(208, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    ' The following code example demonstrates how to create
    ' a rectangle using the FromLTRB method. This example is 
    ' designed to be used with a Windows Form. Paste this code 
    ' into a form and call the CreateARectangleFromLTRB method 
    ' when handling the form's Paint event, passing e as 
    ' PaintEventArgs.
    '<snippet7>
    Private Sub CreateARectangleFromLTRB(ByVal e As PaintEventArgs)
        Dim myRectangle As Rectangle = Rectangle.FromLTRB(40, 40, 140, 240)
        e.Graphics.DrawRectangle(SystemPens.ControlText, myRectangle)
    End Sub
    '</snippet7>

    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        
        'ConvertRectangleToRectangleF(e)
        RoundingAndTruncatingRectangles(e)
    End Sub

    ' The following code example demonstrates the static (Shared in
    ' Visual Basic) Intersects method. This example should be used 
    ' with a Windows Form. Paste this code into a form
    ' and call this method when handling the form's Paint event,
    ' passing e as PaintEventArgs.
    '<snippet1>
    Private Sub StaticRectangleIntersection(ByVal e As PaintEventArgs)
        Dim rectangle1 As New Rectangle(50, 50, 200, 100)
        Dim rectangle2 As New Rectangle(70, 20, 100, 200)
        Dim rectangle3 As New Rectangle

        e.Graphics.DrawRectangle(Pens.Black, rectangle1)
        e.Graphics.DrawRectangle(Pens.Red, rectangle2)

        If (rectangle1.IntersectsWith(rectangle2)) Then
            rectangle3 = Rectangle.Intersect(rectangle1, rectangle2)
            If Not rectangle3.IsEmpty Then
                e.Graphics.FillRectangle(Brushes.Green, rectangle3)
            End If
        End If
    End Sub
    '</snippet1>

    ' The following code example demonstrates the instance
    ' version of the Intersects method.  This example should be used 
    ' with a Windows Form.  Paste this code into a form
    ' and call this method when handling the form's Paint event,
    ' passing e as PaintEventArgs.
    '<snippet2>
    Private Sub InstanceRectangleIntersection( _
        ByVal e As PaintEventArgs)

        Dim rectangle1 As New Rectangle(50, 50, 200, 100)
        Dim rectangle2 As New Rectangle(70, 20, 100, 200)
  
        e.Graphics.DrawRectangle(Pens.Black, rectangle1)
        e.Graphics.DrawRectangle(Pens.Red, rectangle2)

        If (rectangle1.IntersectsWith(rectangle2)) Then
            rectangle1.Intersect(rectangle2)
            If Not (rectangle1.IsEmpty) Then
                e.Graphics.FillRectangle(Brushes.Green, rectangle1)
            End If
        End If
    End Sub
    '</snippet2>

    ' The following code example demonstrates the Contains method 
    ' and the SystemPens class.
    ' This example is designed for use with a Windows Form.  Paste 
    ' this code into a form that contains a Button named Button1, 
    ' call DrawFirstRectangle from the form's constructor 
    ' or Load method, and associate the Button1_Click method with 
    ' the button's Click event.
    '<snippet3>
    Dim rectangle1 As New Rectangle(70, 70, 100, 150)

    Private Sub DrawFirstRectangle()
        ControlPaint.DrawReversibleFrame(rectangle1, _
            SystemColors.Highlight, FrameStyle.Thick)
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles Button1.Click

        ' Get the bounds of the screen.
        Dim screenRectangle As Rectangle = Screen.PrimaryScreen.Bounds

        ' Check to see if the rectangle is within the bounds of the screen.
        If (screenRectangle.Contains(rectangle1)) Then

            ' If so, erase the previous rectangle.
            ControlPaint.DrawReversibleFrame(rectangle1, _
                SystemColors.Highlight, FrameStyle.Thick)

            ' Call the Offset method to move the rectangle.
            rectangle1.Offset(20, 20)

            ' Draw the new, offset rectangle.
            ControlPaint.DrawReversibleFrame(rectangle1, _
                SystemColors.Highlight, FrameStyle.Thick)
        End If
    End Sub
    '</snippet3>

    ' The following code example demonstrates the Union method. This
    ' example is designed for use with a Windows Form.  Paste this code 
    ' into a form and call the ShowRectangleUnion method when handling 
    ' the form's Paint event, passing e as PaintEventArgs.
    '<snippet4>
    Private Sub ShowRectangleUnion(ByVal e As PaintEventArgs)

        ' Declare two rectangles and draw them.
        Dim rectangle1 As New Rectangle(30, 40, 50, 100)
        Dim rectangle2 As New Rectangle(50, 60, 100, 60)
        e.Graphics.DrawRectangle(Pens.Sienna, rectangle1)
        e.Graphics.DrawRectangle(Pens.BlueViolet, rectangle2)

        ' Declare a third rectangle as a union of the first two.
        Dim rectangle3 As Rectangle = Rectangle.Union(rectangle1, _
            rectangle2)

        ' Fill in the third rectangle in a semi-transparent color.
        Dim transparentColor As Color = Color.FromArgb(40, 135, 135, 255)
        e.Graphics.FillRectangle(New SolidBrush(transparentColor), _
            rectangle3)
    End Sub
    '</snippet4>


    ' The following code example demonstrates how to use the Round
    ' and Truncate methods.
    ' This example is designed for use with a Windows Form.  Paste this code 
    ' into a form and call the RoundingAndTruncatingRectangles method  
    ' when handling the form's Paint event, passing e as PaintEventArgs.
    '<snippet5>
    Private Sub RoundingAndTruncatingRectangles( _
        ByVal e As PaintEventArgs)

        ' Construct a new RectangleF.
        Dim myRectangleF As New RectangleF(30.6F, 30.7F, 40.8F, 100.9F)

        ' Call the Round method.
        Dim roundedRectangle As Rectangle = Rectangle.Round(myRectangleF)

        ' Draw the rounded rectangle in red.
        Dim redPen As New Pen(Color.Red, 4)
        e.Graphics.DrawRectangle(redPen, roundedRectangle)

        ' Call the Truncate method.
        Dim truncatedRectangle As Rectangle = _
            Rectangle.Truncate(myRectangleF)

        ' Draw the truncated rectangle in white.
        Dim whitePen As New Pen(Color.White, 4)
        e.Graphics.DrawRectangle(whitePen, truncatedRectangle)

        ' Dispose of the custom pens.
        redPen.Dispose()
        whitePen.Dispose()
    End Sub
    '</snippet5>

    ' The following code example demonstrates how to convert
    ' a Rectangle object to a RectangleF using the Implicit operator.

    ' This example is designed for use with a Windows Form.  Paste 
    ' this code into a form and call the ConvertRectangleToRectangleF
    ' method when handling the form's Paint event, passing e as 
    ' PaintEventArgs.
    '<snippet6>
    Private Sub ConvertRectangleToRectangleF( _
        ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rectangle1 As New Rectangle(30, 40, 50, 100)

        ' Convert it to a RectangleF.
        Dim convertedRectangle As RectangleF = _
            RectangleF.op_Implicit(rectangle1)

        ' Create a new RectangleF.
        Dim rectangle2 As New RectangleF(New PointF(30.0F, 40.0F), _
            New SizeF(50.0F, 100.0F))

        ' Create a custom, partially transparent brush.
        Dim redBrush As New SolidBrush(Color.FromArgb(40, Color.Red))

        ' Compare the converted rectangle with the new one.  If they 
        ' are equal, draw and fill the rectangles on the form.
        If (RectangleF.op_Equality(convertedRectangle, rectangle2)) Then
            e.Graphics.FillRectangle(redBrush, rectangle2)
        End If

        ' Dispose of the custom brush.
        redBrush.Dispose()
    End Sub
    '</snippet6>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class


