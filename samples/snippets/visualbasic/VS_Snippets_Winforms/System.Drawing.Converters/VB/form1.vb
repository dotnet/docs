Option Explicit On 
Option Strict On

Imports System.Drawing
Imports System
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
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    ' The following code example demonstrates how to use the 
    ' PointConverter.ConvertFromString and the Point.op_Subtraction
    ' methods. This example is designed to be used with Windows
    ' Forms. Paste this code into a form and call the 
    ' ShowPointConverter method when handling the form's Paint 
    ' event, passing e as PaintEventArgs.
    '<snippet1>
    Private Sub ShowPointConverter(ByVal e As PaintEventArgs)

        ' Create the PointConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
            System.ComponentModel.TypeDescriptor.GetConverter(GetType(Point))

        Dim point1 As Point = _
            CType(converter.ConvertFromString("200, 200"), Point)

        ' Use the subtraction operator to get a second point.
        Dim point2 As Point = Point.op_Subtraction(point1, _
            New Size(190, 190))

        ' Draw a line between the two points.
        e.Graphics.DrawLine(Pens.Black, point1, point2)
    End Sub
    '</snippet1>

    ' The following code example demonstrates how to use the 
    ' ColorConverter.ConvertToString method. This example
    ' is designed to be used with Windows Forms. Paste this code
    ' into a form and call the ShowColorConverter method when
    ' handling the form's Paint event, passing e as PaintEventArgs.
    '<snippet2>
    
    Private Sub ShowColorConverter(ByVal e As PaintEventArgs)

        Dim myColor As Color = Color.PaleVioletRed

        ' Create the ColorConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
           System.ComponentModel.TypeDescriptor.GetConverter(myColor)

        Dim colorAsString As String = _
            converter.ConvertToString(Color.PaleVioletRed)
        e.Graphics.DrawString(colorAsString, Me.Font, _
            Brushes.PaleVioletRed, 50.0F, 50.0F)
    End Sub
    '</snippet2>

    ' The following code example demonstrates how to use the 
    ' ConvertToInvariantString and ConvertToString methods.  
    ' This example is designed to be used with Windows Forms. 
    ' Paste this code into a form and call the ShowFontStringConversion
    ' method when handling the form's Paint event, passing e
    ' as PaintEventArgs.
    '<snippet3>
    Private Sub ShowFontStringConversion(ByVal e As PaintEventArgs)

        ' Create the FontConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
            System.ComponentModel.TypeDescriptor.GetConverter(GetType(Font))

        Dim font1 As Font = _
            CType(converter.ConvertFromString("Arial, 12pt"), Font)

        Dim fontName1 As String = _
            converter.ConvertToInvariantString(font1)
        Dim fontName2 As String = converter.ConvertToString(font1)

        e.Graphics.DrawString(fontName1, font1, Brushes.Red, 10, 10)
        e.Graphics.DrawString(fontName2, font1, Brushes.Blue, 10, 30)
    End Sub
    '</snippet3>

    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        ShowFontStringConversion(e)
        ShowPointConverter(e)
        ShowColorConverter(e)
    End Sub

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
