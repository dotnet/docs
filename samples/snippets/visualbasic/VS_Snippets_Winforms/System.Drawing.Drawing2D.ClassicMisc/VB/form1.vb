Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D


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


    ' Snippet for: M:System.Drawing.Drawing2D.AdjustableArrowCap.#ctor(System.Single,System.Single)
    ' <snippet1>
    Public Sub ConstructAdjArrowCap1(ByVal e As PaintEventArgs)
        Dim myArrow As New AdjustableArrowCap(6, 6)
        Dim customArrow As CustomLineCap = myArrow
        Dim capPen As New Pen(Color.Black)
        capPen.CustomStartCap = myArrow
        capPen.CustomEndCap = myArrow
        e.Graphics.DrawLine(capPen, 50, 50, 200, 50)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Drawing2D.AdjustableArrowCap.#ctor(System.Single,System.Single,System.Boolean)
    ' <snippet2>
    Public Sub ConstructAdjArrowCap2(ByVal e As PaintEventArgs)
        Dim myArrow As New AdjustableArrowCap(6, 6, False)
        Dim customArrow As CustomLineCap = myArrow
        Dim capPen As New Pen(Color.Black)
        capPen.CustomStartCap = myArrow
        capPen.CustomEndCap = myArrow
        e.Graphics.DrawLine(capPen, 50, 50, 200, 50)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Drawing2D.Blend.#ctor
    ' <snippet3>
    Public Sub BlendConstExample(ByVal e As PaintEventArgs)

        ' Draw ellipse using Blend.
        Dim startPoint2 As New Point(20, 110)
        Dim endPoint2 As New Point(140, 110)
        Dim myFactors As Single() = {0.2F, 0.4F, 0.8F, 0.8F, 0.4F, 0.2F}
        Dim myPositions As Single() = {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F}
        Dim myBlend As New Blend
        myBlend.Factors = myFactors
        myBlend.Positions = myPositions
        Dim lgBrush2 As New LinearGradientBrush(startPoint2, endPoint2, _
        Color.Blue, Color.Red)
        lgBrush2.Blend = myBlend
        Dim ellipseRect2 As New Rectangle(20, 110, 120, 80)
        e.Graphics.FillEllipse(lgBrush2, ellipseRect2)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Drawing2D.ColorBlend.#ctor
    ' <snippet4>
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' Draw ellipse using ColorBlend.
        Dim startPoint2 As New Point(20, 110)
        Dim endPoint2 As New Point(140, 110)
        Dim myColors As Color() = {Color.Green, Color.Yellow, _
        Color.Yellow, Color.Blue, Color.Red, Color.Red}
        Dim myPositions As Single() = {0.0F, 0.2F, 0.4F, 0.6F, 0.8F, 1.0F}
        Dim myBlend As New ColorBlend
        myBlend.Colors = myColors
        myBlend.Positions = myPositions
        Dim lgBrush2 As New LinearGradientBrush(startPoint2, endPoint2, _
        Color.Green, Color.Red)
        lgBrush2.InterpolationColors = myBlend
        Dim ellipseRect2 As New Rectangle(20, 110, 120, 80)
        e.Graphics.FillEllipse(lgBrush2, ellipseRect2)
    End Sub
    ' </snippet4>
    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class

