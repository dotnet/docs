Option Strict On
Option Explicit On 

Imports System
Imports System.Drawing
Imports System.Windows.Forms

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
        components = New System.ComponentModel.Container
        Me.Text = "Form1"
    End Sub

#End Region

    ' The following method demonstrates the effects of setting
    ' the LineJoin property on a Pen object.

    ' This example is designed to be used with Windows Forms.
    ' Paste the code into a form and call the ShowLineJoin method when
    ' handling the form's Paint event, passing e as PaintEventArgs.
    '<snippet1>
    Private Sub ShowLineJoin(ByVal e As PaintEventArgs)

        ' Create a new pen.
        Dim skyBluePen As New Pen(Brushes.DeepSkyBlue)

        ' Set the pen's width.
        skyBluePen.Width = 8.0F

        ' Set the LineJoin property.
        skyBluePen.LineJoin = Drawing2D.LineJoin.Bevel

        ' Draw a rectangle.
        e.Graphics.DrawRectangle(skyBluePen, _
            New Rectangle(40, 40, 150, 200))

        'Dispose of the pen.
        skyBluePen.Dispose()

    End Sub
    '</snippet1>

    ' The following method demonstrates the effects of setting
    ' the StartCap and EndCap properties on a Pen object.

    ' This example is designed to be used with Windows Forms.
    ' Paste the code into a form and call the ShowStartAndEndCaps
    ' method when handling the form's Paint event, passing e 
    ' as PaintEventArgs.
    '<snippet2>
    Private Sub ShowStartAndEndCaps(ByVal e As PaintEventArgs)

        ' Create a new custom pen.
        Dim redPen As New Pen(Brushes.Red, 6.0F)

        ' Set the StartCap property.
        redPen.StartCap = Drawing2D.LineCap.RoundAnchor

        ' Set the EndCap property.
        redPen.EndCap = Drawing2D.LineCap.ArrowAnchor

        ' Draw a line.
        e.Graphics.DrawLine(redPen, 40.0F, 40.0F, 145.0F, 185.0F)

        ' Dispose of the custom pen.
        redPen.Dispose()

    End Sub
    '</snippet2>

    ' The following method demonstrates the effects of setting
    ' the DashCap, DashPattern and SmoothingMode properties 
    ' of a Pen object.

    ' This example is designed to be used with Windows Forms. 
    ' Paste the code into a form and call the ShowPensAndSmoothingMode
    ' method when handling the form's Paint event, passing e as
    ' PaintEventArgs.
    '<snippet3>
    Private Sub ShowPensAndSmoothingMode(ByVal e As PaintEventArgs)

        ' Set the SmoothingMode property to smooth the line.
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Create a new Pen object.
        Dim greenPen As New Pen(Color.Green)

        ' Set the width to 6.
        greenPen.Width = 6.0F

        ' Set the DashCap to round.
        greenPen.DashCap = Drawing2D.DashCap.Round

        ' Create a custom dash pattern.
        greenPen.DashPattern = New Single() {4.0F, 2.0F, 1.0F, 3.0F}

        ' Draw a line.
        e.Graphics.DrawLine(greenPen, 20.0F, 20.0F, 100.0F, 240.0F)

        ' Change the SmoothingMode to none.
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None

        ' Draw another line.
        e.Graphics.DrawLine(greenPen, 100.0F, 240.0F, 160.0F, 20.0F)

        ' Dispose of the custom pen.
        greenPen.Dispose()
    End Sub
    '</snippet3>
    ' The following method demonstrates how to use the Pens class.

    ' This example is designed to be used with Windows Forms.
    ' Paste the code into a form and call the UsePensClass method
    ' when handling the form's Paint event, passing e as PaintEventArgs.
    '<snippet4>
    Private Sub UsePensClass(ByVal e As PaintEventArgs)
        e.Graphics.DrawEllipse(Pens.SlateBlue, _
            New Rectangle(40, 40, 140, 140))
    End Sub
    '</snippet4>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        UsePensClass(e)
        'ShowPensAndSmoothingMode(e)
        'ShowStartAndEndCaps(e)
        ShowLineJoin(e)
    End Sub
End Class

