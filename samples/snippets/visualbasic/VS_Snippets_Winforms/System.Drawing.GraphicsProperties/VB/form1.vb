Option Strict On
Option Explicit On 

Imports System
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
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    ' The following code example demonstrates how to construct and
    ' use a region. 

    ' This example is designed to be used with Windows Forms.  
    ' Paste the code to a form and call the FillRegionExcludingPath
    ' method when handling the form's Paint event, passing e as 
    ' PaintEventArgs.
    '<snippet1>
    Private Sub FillRegionExcludingPath(ByVal e As PaintEventArgs)

        ' Create the region using a rectangle.
        Dim myRegion As New Region(New Rectangle(20, 20, 100, 100))

        ' Create the GraphicsPath.
        Dim path As New System.Drawing.Drawing2D.GraphicsPath

        ' Add a circle to the graphics path.
        path.AddEllipse(50, 50, 25, 25)

        ' Exclude the circle from the region.
        myRegion.Exclude(path)

        ' Retrieve a Graphics object from the form.
        Dim formGraphics As Graphics = e.Graphics

        ' Fill the region in blue.
        formGraphics.FillRegion(Brushes.Blue, myRegion)

        ' Dispose of the path and region objects.
        path.Dispose()
        myRegion.Dispose()

    End Sub
    '</snippet1>

    ' The following code example demonstrates how to use the 
    ' PageScale and TranslateTransform members to change the
    ' scale and origin when you draw a rectangle.

    ' This example is designed to be used with Windows Forms.  
    ' Paste the code intto a form and call the 
    ' ChangePageScaleAndTranslateTransform method when 
    ' handling the form's Paint event, passing e as PaintEventArgs.
    '<snippet2>
    Private Sub ChangePageScaleAndTranslateTransform(ByVal e As _
        PaintEventArgs)

        ' Create a rectangle.
        Dim rectangle1 As New Rectangle(20, 20, 50, 100)

        ' Draw its outline.
        e.Graphics.DrawRectangle(Pens.SlateBlue, rectangle1)

        ' Change the page scale.  
        e.Graphics.PageScale = 2.0F

        ' Call TranslateTransform to change the origin of the
        '  Graphics object.
        e.Graphics.TranslateTransform(10.0F, 10.0F)

        ' Draw the rectangle again.
        e.Graphics.DrawRectangle(Pens.Tomato, rectangle1)

        ' Set the page scale and origin back to their original values.
        e.Graphics.PageScale = 1.0F
        e.Graphics.ResetTransform()

        Dim transparentBrush As New SolidBrush(Color.FromArgb(50, Color.Yellow))

        ' Create a new rectangle with the coordinates you expect
        ' after setting PageScale and calling TranslateTransform:
        ' x = (10 + 20) * 2
        ' y = (10 + 20) * 2
        ' Width = 50 * 2
        ' Length = 100 * 2
        Dim newRectangle As Rectangle = New Rectangle(60, 60, 100, 200)

        ' Fill in the rectangle with a semi-transparent color.
        e.Graphics.FillRectangle(transparentBrush, newRectangle)
    End Sub
    '</snippet2>

    
    ' The following code example demonstrates the effect of changing
    ' the PageUnit property.

    ' This example is designed to be used with Windows Forms.  
    ' Paste the code into a form and call the ChangePageUnit
    ' method when handling the form's Paint event, passing e 
    ' as PaintEventArgs.
    '<snippet3>
    Private Sub ChangePageUnit(ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rectangle1 As New Rectangle(20, 20, 50, 100)

        ' Draw its outline.
        e.Graphics.DrawRectangle(Pens.SlateBlue, rectangle1)

        ' Change the page scale.  
        e.Graphics.PageUnit = GraphicsUnit.Point

        ' Draw the rectangle again.
        e.Graphics.DrawRectangle(Pens.Tomato, rectangle1)

    End Sub
    '</snippet3>

    ' The following method demonstrates the use of the Clip
    ' property. 

    ' This example is designed to be used with Windows Forms.  
    ' Paste the code int a form and call the SetAndFillClip method
    ' when handling the form's Paint event, passing e as PaintEventArgs.
    '<snippet4>
    Private Sub SetAndFillClip(ByVal e As PaintEventArgs)

        ' Set the Clip property to a new region.
        e.Graphics.Clip = New Region(New Rectangle(10, 10, 100, 200))

        ' Fill the region.
        e.Graphics.FillRegion(Brushes.LightSalmon, e.Graphics.Clip)

        ' Demonstrate the clip region by drawing a string
        ' at the outer edge of the region.
        e.Graphics.DrawString("Outside of Clip", _
            New Font("Arial", 12.0F, FontStyle.Regular), _
            Brushes.Black, 0.0F, 0.0F)

    End Sub
    '</snippet4>

    ' The following code example demonstrates the use of the
    ' TextRenderingHint and TextContrast properties.

    ' This example is designed to be used with Windows Forms.  
    ' Paste the code into a form and call the 
    ' ChangeTextRenderingHintAndTextContrast method when 
    ' handling the form's Paint event, passing e as PaintEventArgs.
    '<snippet5>
    Private Sub ChangeTextRenderingHintAndTextContrast(ByVal e As _
        PaintEventArgs)

        ' Retrieve the graphics object.
        Dim formGraphics As Graphics = e.Graphics

        ' Declare a new font.
        Dim myFont As Font = New Font(FontFamily.GenericSansSerif, _
            20, FontStyle.Regular)

        ' Set the TextRenderingHint property.
        formGraphics.TextRenderingHint = _
            System.Drawing.Text.TextRenderingHint.SingleBitPerPixel

        ' Draw the string.
        formGraphics.DrawString("Hello World", myFont, _
            Brushes.Firebrick, 20.0F, 20.0F)

        ' Change the TextRenderingHint property.
        formGraphics.TextRenderingHint = _
            System.Drawing.Text.TextRenderingHint.AntiAliasGridFit

        ' Draw the string again.
        formGraphics.DrawString("Hello World", myFont, _
            Brushes.Firebrick, 20.0F, 60.0F)

        ' Set the text contrast to a high-contrast setting.
        formGraphics.TextContrast = 0

        ' Draw the string.
        formGraphics.DrawString("Hello World", myFont, _
            Brushes.DodgerBlue, 20.0F, 100.0F)

        ' Set the text contrast to a low-contrast setting.
        formGraphics.TextContrast = 12

        ' Draw the string again.
        formGraphics.DrawString("Hello World", myFont, _
            Brushes.DodgerBlue, 20.0F, 140.0F)

        ' Dispose of the font object.
        myFont.Dispose()

    End Sub
    '</snippet5>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        'ChangeTextRenderingHintAndTextContrast(e)
        'ChangePageScaleAndTranslateTransform(e)
        ChangePageUnit(e)
    End Sub
End Class

