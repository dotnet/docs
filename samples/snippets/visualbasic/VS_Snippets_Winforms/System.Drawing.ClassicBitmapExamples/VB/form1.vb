Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
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


    ' <snippet1>
    Private Sub Clone_Example1(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from a file.
        Dim myBitmap As New Bitmap("Grapes.jpg")

        ' Clone a portion of the Bitmap object.
        Dim cloneRect As New Rectangle(0, 0, 100, 100)
        Dim format As PixelFormat = myBitmap.PixelFormat
        Dim cloneBitmap As Bitmap = myBitmap.Clone(cloneRect, format)

        ' Draw the cloned portion of the Bitmap object.
        e.Graphics.DrawImage(cloneBitmap, 0, 0)
    End Sub
    ' </snippet1>


    ' <snippet2>
    Private Sub Clone_Example2(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from a file.
        Dim myBitmap As New Bitmap("Grapes.jpg")

        ' Clone a portion of the Bitmap object.
        Dim cloneRect As New RectangleF(0, 0, 100, 100)
        Dim format As PixelFormat = myBitmap.PixelFormat
        Dim cloneBitmap As Bitmap = myBitmap.Clone(cloneRect, format)

        ' Draw the cloned portion of the Bitmap object.
        e.Graphics.DrawImage(cloneBitmap, 0, 0)
    End Sub
    ' </snippet2>


    ' <snippet3>
    <System.Runtime.InteropServices.DllImportAttribute("user32.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function LoadImage(ByVal Hinstance As Integer, ByVal name As String, ByVal type As Integer, ByVal width As Integer, ByVal height As Integer, ByVal load As Integer) As IntPtr
    End Function

    Private Sub HICON_Example(ByVal e As PaintEventArgs)

        ' Get a handle to an icon.
        Dim Hicon As IntPtr = LoadImage(0, "smile.ico", 1, 0, 0, 16)

        ' Create a Bitmap object from the icon handle.
        Dim iconBitmap As Bitmap = Bitmap.FromHicon(Hicon)

        ' Draw the Bitmap object to the screen.
        e.Graphics.DrawImage(iconBitmap, 0, 0)
    End Sub
    ' </snippet3>

 ' <snippet4>
'<snippet11>
<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
    Private Shared Function DeleteObject (ByVal hObject As IntPtr) As Boolean
    End Function
'</snippet11>
   


    Private Sub DemonstrateGetHbitmap()
        Dim bm As New Bitmap("Picture.jpg")
        Dim hBitmap As IntPtr
        hBitmap = bm.GetHbitmap()

        ' Do something with hBitmap.
        DeleteObject(hBitmap)
    End Sub

    ' </snippet4>


    ' <snippet5>
    
    Private Sub DemonstrateGetHbitmapWithColor()
        Dim bm As New Bitmap("Picture.jpg")
        Dim hBitmap As IntPtr
        hBitmap = bm.GetHbitmap(Color.Blue)

        ' Do something with hBitmap.
        DeleteObject(hBitmap)
    End Sub

    ' </snippet5>


    ' <snippet6>
<System.Runtime.InteropServices.DllImportAttribute("user32.dll")> _
    Private Shared Function DestroyIcon(ByVal handle _ 
	As IntPtr) As Boolean 
    End Function

   Private Sub GetHicon_Example(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from an image file.
        Dim myBitmap As New Bitmap("c:\FakePhoto.jpg")

        ' Draw myBitmap to the screen.
        e.Graphics.DrawImage(myBitmap, 0, 0)

        ' Get an Hicon for myBitmap.
        Dim HIcon As IntPtr = myBitmap.GetHicon()
	
        ' Create a new icon from the handle.
        Dim newIcon As Icon = System.Drawing.Icon.FromHandle(HIcon)

        ' Set the form Icon attribute to the new icon.
        Me.Icon = newIcon

        ' You can now destroy the icon, since the form creates its 
        ' own copy of the icon accessible through the Form.Icon property.
	DestroyIcon(newIcon.Handle)
    End Sub

    ' </snippet6>


    ' <snippet7>
    Private Sub GetPixel_Example(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from an image file.
        Dim myBitmap As New Bitmap("Grapes.jpg")

        ' Get the color of a pixel within myBitmap.
        Dim pixelColor As Color = myBitmap.GetPixel(50, 50)

        ' Fill a rectangle with pixelColor.
        Dim pixelBrush As New SolidBrush(pixelColor)
        e.Graphics.FillRectangle(pixelBrush, 0, 0, 100, 100)
    End Sub
    ' </snippet7>


    ' <snippet8>
    Private Sub MakeTransparent_Example1(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from an image file.
        Dim myBitmap As New Bitmap("Grapes.gif")

        ' Draw myBitmap to the screen.
        e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, _
        myBitmap.Height)

        ' Make the default transparent color transparent for myBitmap.
        myBitmap.MakeTransparent()

        ' Draw the transparent bitmap to the screen.
        e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0, myBitmap.Width, _
        myBitmap.Height)
    End Sub
    ' </snippet8>


    ' <snippet9>
    Private Sub MakeTransparent_Example2(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from an image file.
        Dim myBitmap As New Bitmap("Grapes.gif")

        ' Draw myBitmap to the screen.
        e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, _
            myBitmap.Height)

        ' Get the color of a background pixel.
        Dim backColor As Color = myBitmap.GetPixel(1, 1)

        ' Make backColor transparent for myBitmap.
        myBitmap.MakeTransparent(backColor)

        ' Draw the transparent bitmap to the screen.
        e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0, myBitmap.Width, _
            myBitmap.Height)
    End Sub
    ' </snippet9>


    ' <snippet10>
    Private Sub SetPixel_Example(ByVal e As PaintEventArgs)

        ' Create a Bitmap object from a file.
        Dim myBitmap As New Bitmap("Grapes.jpg")

        ' Draw myBitmap to the screen.
        e.Graphics.DrawImage(myBitmap, 0, 0, myBitmap.Width, _
        myBitmap.Height)

        ' Set each pixel in myBitmap to black.
        Dim Xcount As Integer
        For Xcount = 0 To myBitmap.Width - 1
            Dim Ycount As Integer
            For Ycount = 0 To myBitmap.Height - 1
                myBitmap.SetPixel(Xcount, Ycount, Color.Black)
            Next Ycount
        Next Xcount

        ' Draw myBitmap to the screen again.
        e.Graphics.DrawImage(myBitmap, myBitmap.Width, 0, myBitmap.Width, _
            myBitmap.Height)
    End Sub
    ' </snippet10>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
