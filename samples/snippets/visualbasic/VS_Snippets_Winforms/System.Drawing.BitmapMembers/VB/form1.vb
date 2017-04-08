
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
        InitializeBitmap()
        InitializeStreamBitmap()

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
        Me.Button1.Location = New System.Drawing.Point(24, 192)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Rotate and Flip"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(48, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(168, 72)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(152, 192)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Button2"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region


    ' <snippet3Intro>
    ' The following code example demonstrates constructing how to construct a new Bitmap
    ' from a file.

    ' This example is designed to be used with a Windows Forms that contains
    ' a PictureBox named PictureBox1. 
    ' 
    ' Paste the code into a form and call InitializeBitmap from the form's
    ' constructor or Load method.

    ' </snippet3Intro>

    ' <snippet4Intro>
    ' The following code example demonstrates how to set the RotateFlip 
    ' property of a Bitmap.  

    ' This example is designed to be used with a Windows form that contains
    ' a PictureBox named PictureBox1 and a button named Button1. 
    ' Paste the code to a form, call InitializeBitmap from the form's
    ' constructor or Load method and associate Button1_Click with the button's
    ' click event. Ensure the filepath to the bitmap is valid on 
    ' your system.
    ' </snippet4Intro>

    '<snippet3>
    '<snippet4>
    Dim bitmap1 As Bitmap

    Private Sub InitializeBitmap()
        Try
            bitmap1 = CType(Bitmap.FromFile("C:\Documents and Settings\All Users\" _
                & "Documents\My Music\music.bmp"), Bitmap)
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
            PictureBox1.Image = bitmap1
        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("There was an error. Check the path to the bitmap.")
        End Try


    End Sub
    '</snippet4>

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        If bitmap1 IsNot Nothing Then
            bitmap1.RotateFlip(RotateFlipType.Rotate180FlipY)
            PictureBox1.Image = bitmap1
        End If

    End Sub
    '</snippet3>

    ' The following code example demonstrates how to load a bitmap 
    ' from an Icon handle, using the GraphicsUnit enumeration, and the  
    ' the use of the RectangleF.Round method to draw the rectangle 
    ' bounds of an icon.

    ' This example is designed to be used with Windows Forms. Create
    ' a form that contains a button named Button2. Paste the code into the
    ' form and associate this method with the button's Click event.
    '<snippet1>
    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        Dim bitmap1 As Bitmap = Bitmap.FromHicon(SystemIcons.Hand.Handle)
        Dim formGraphics As Graphics = Me.CreateGraphics()
        Dim units As GraphicsUnit = GraphicsUnit.Point
        Dim bmpRectangleF As RectangleF = bitmap1.GetBounds(units)
        Dim bmpRectangle As Rectangle = Rectangle.Round(bmpRectangleF)
        formGraphics.DrawRectangle(Pens.Blue, bmpRectangle)
        formGraphics.Dispose()
    End Sub
    '</snippet1>

    ' The following code example demonstrates how to load a bitmap 
    ' from a stream.

    ' This example is designed to be used with Windows Forms. Create
    ' a form that contains a PictureBox named PictureBox1. Paste the code 
    ' into the form and call InitializeStreamBitmap from the form's
    ' constructor or Load method.
    '<snippet2>
    Private Sub InitializeStreamBitmap()
        Try
            Dim request As System.Net.WebRequest = _
                System.Net.WebRequest.Create( _
                "http://www.microsoft.com//h/en-us/r/ms_masthead_ltr.gif")
            Dim response As System.Net.WebResponse = request.GetResponse()
            Dim responseStream As System.IO.Stream = response.GetResponseStream()
            Dim bitmap2 As New Bitmap(responseStream)
            PictureBox1.Image = bitmap2

        Catch ex As System.Net.WebException
            MessageBox.Show("There was an error opening the image file. Check the URL")
        End Try
    End Sub
    '</snippet2>

' The following code example demonstrates how to use the Image.PixelFormat,
    ' Image.Height, Image.Width, and BitmapData.Scan0 properties; the Bitmap.LockBits 
    ' and Bitmap.UnlockBits methods; and the ImageLockMode enumeration. 
    ' This example is designed to be used with Windows
    ' Forms. To run this example, paste it into a form and handle the form's Paint event by
    ' calling the LockUnlockBitsExample method, passing e as PaintEventArgs. This example assumes the existence of an 24bpp image file named
' fakePhoto.jpg at c:\.
    '<snippet5>
    Private Sub LockUnlockBitsExample(ByVal e As PaintEventArgs)

        ' Create a new bitmap.
        Dim bmp As New Bitmap("c:\fakePhoto.jpg")

        ' Lock the bitmap's bits.  
        Dim rect As New Rectangle(0, 0, bmp.Width, bmp.Height)
        Dim bmpData As System.Drawing.Imaging.BitmapData = bmp.LockBits(rect, _
            Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat)

        ' Get the address of the first line.
        Dim ptr As IntPtr = bmpData.Scan0

        ' Declare an array to hold the bytes of the bitmap.
        ' This code is specific to a bitmap with 24 bits per pixels.
        Dim bytes As Integer = Math.Abs(bmpData.Stride) * bmp.Height
        Dim rgbValues(bytes - 1) As Byte

        ' Copy the RGB values into the array.
        System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)

        ' Set every third value to 255. A 24bpp image will look red.
        For counter As Integer = 2 To rgbValues.Length - 1 Step 3
            rgbValues(counter) = 255
        Next

        ' Copy the RGB values back to the bitmap
        System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)

        ' Unlock the bits.
        bmp.UnlockBits(bmpData)

        ' Draw the modified image.
        e.Graphics.DrawImage(bmp, 0, 150)

    End Sub
    '</snippet5>

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class


