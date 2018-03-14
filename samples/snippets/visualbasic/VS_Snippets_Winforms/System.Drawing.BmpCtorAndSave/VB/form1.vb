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

    '<snippet1>
    Private Sub ConstructFromResourceSaveAsGif(ByVal e As PaintEventArgs)

        ' Construct a bitmap from the button image resource.
        Dim bmp1 As New Bitmap(GetType(Button), "Button.bmp")

        ' Save the image as a GIF.
        bmp1.Save("c:\button.gif", System.Drawing.Imaging.ImageFormat.Gif)

        ' Construct a new image from the GIF file.
        Dim bmp2 As New Bitmap("c:\button.gif")

        ' Draw the two images.
        e.Graphics.DrawImage(bmp1, New Point(10, 10))
        e.Graphics.DrawImage(bmp2, New Point(10, 40))

        ' Dispose of the image files.
        bmp1.Dispose()
        bmp2.Dispose()
    End Sub
    '</snippet1>

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        ConstructFromResourceSaveAsGif(e)
    End Sub
End Class
