Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

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


    ' Snippet for: M:System.Drawing.ColorTranslator.FromHtml(System.String)
    ' <snippet1>
    Public Sub FromHtml_Example(ByVal e As PaintEventArgs)

        ' Create a string representation of an HTML color.
        Dim htmlColor As String = "Blue"

        ' Translate htmlColor to a GDI+ Color structure.
        Dim myColor As Color = ColorTranslator.FromHtml(htmlColor)

        ' Fill a rectangle with myColor.
        e.Graphics.FillRectangle(New SolidBrush(myColor), 0, 0, 100, 100)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.ColorTranslator.FromOle(System.Int32)
    ' <snippet2>
    Public Sub FromOle_Example(ByVal e As PaintEventArgs)

        ' Create an integer representation of an HTML color.
        Dim oleColor As Integer = &HFF00

        ' Translate oleColor to a GDI+ Color structure.
        Dim myColor As Color = ColorTranslator.FromOle(oleColor)

        ' Fill a rectangle with myColor.
        e.Graphics.FillRectangle(New SolidBrush(myColor), 0, 0, 100, 100)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.ColorTranslator.FromWin32(System.Int32)
    ' <snippet3>
    Public Sub FromWin32_Example(ByVal e As PaintEventArgs)

        ' Create an integer representation of a Win32 color.
        Dim winColor As Integer = &HA000

        ' Translate winColor to a GDI+ Color structure.
        Dim myColor As Color = ColorTranslator.FromWin32(winColor)

        ' Fill a rectangle with myColor.
        e.Graphics.FillRectangle(New SolidBrush(myColor), 0, 0, 100, 100)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color)
    ' <snippet4>
    Public Sub ToHtml_Example(ByVal e As PaintEventArgs)

        ' Create an instance of a Color structure.
        Dim myColor As Color = Color.Red

        ' Translate myColor to an HTML color.
        Dim htmlColor As String = ColorTranslator.ToHtml(myColor)

        ' Show a message box with the value of htmlColor.
        MessageBox.Show(htmlColor)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.ColorTranslator.ToOle(System.Drawing.Color)
    ' <snippet5>
    Public Sub ToOle_Example(ByVal e As PaintEventArgs)

        ' Create an instance of a Color structure.
        Dim myColor As Color = Color.Green

        ' Translate myColor to an OLE color.
        Dim oleColor As Integer = ColorTranslator.ToOle(myColor)

        ' Show a message box with the value of htmlColor.
        MessageBox.Show(oleColor.ToString())
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color)
    ' <snippet6>
    Public Sub ToWin32_Example(ByVal e As PaintEventArgs)

        ' Create an instance of a Color structure.
        Dim myColor As Color = Color.Red

        ' Translate myColor to an OLE color.
        Dim winColor As Integer = ColorTranslator.ToWin32(myColor)

        ' Show a message box with the value of winColor.
        MessageBox.Show(winColor)
    End Sub
    ' </snippet6>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
