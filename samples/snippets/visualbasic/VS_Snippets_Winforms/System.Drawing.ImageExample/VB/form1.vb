Option Strict On
Option Explicit On 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Imaging



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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(24, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 88)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(192, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(192, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(192, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Button3"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(192, 104)
        Me.Button4.Name = "Button4"
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Button4"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(200, 136)
        Me.Button5.Name = "Button5"
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Button5"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' The following code example demonstrates how to construct a new Bitmap
    ' from a file, using the GetPixel and SetPixel methods to
    ' recolor the image. It also uses the PixelFormat property. 

    ' This example is designed to be used with a Windows Forms that contains
    ' a Label, PictureBox and Button named Label1, PictureBox1 and Button1, 
    ' respectively. Paste the code into the form and associate  the 
    ' Button1_Click method with the button's Click event.
    '<snippet1>
    Dim image1 As Bitmap

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        Try
            ' Retrieve the image.
            image1 = New Bitmap( _
                "C:\Documents and Settings\All Users\Documents\My Music\music.bmp", _
                True)

            Dim x, y As Integer

            ' Loop through the images pixels to reset color.
            For x = 0 To image1.Width - 1
                For y = 0 To image1.Height - 1
                    Dim pixelColor As Color = image1.GetPixel(x, y)
                    Dim newColor As Color = _
                        Color.FromArgb(pixelColor.R, 0, 0)
                    image1.SetPixel(x, y, newColor)
                Next
            Next

            ' Set the PictureBox to display the image.
            PictureBox1.Image = image1

            ' Display the pixel format in Label1.
            Label1.Text = "Pixel format: " + image1.PixelFormat.ToString()

        Catch ex As ArgumentException
            MessageBox.Show("There was an error." _
                & "Check the path to the image file.")
        End Try
    End Sub
    '</snippet1>

    ' The following code example demonstrates how to obtain a new bitmap
    ' using the FromFile method. It also demonstrates a TextureBrush.

    ' This example is designed to be used with Windows Forms. Create 
    ' a form containing a button named Button2. Paste the code into the form
    ' and associate the Button2_Click method with the button's Click event.
    '<snippet2>
    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim image1 As Bitmap = _
                CType(Image.FromFile("C:\Documents and Settings\" _
                & "All Users\Documents\My Music\music.bmp", True), Bitmap)

            Dim texture As New TextureBrush(image1)
            texture.WrapMode = Drawing2D.WrapMode.Tile
            Dim formGraphics As Graphics = Me.CreateGraphics()
            formGraphics.FillEllipse(texture, _
                New RectangleF(90.0F, 110.0F, 100, 100))
            formGraphics.Dispose()

        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("There was an error opening the bitmap." _
                & "Please check the path.")
        End Try

    End Sub
    '</snippet2>

    ' The following code example demonstrates how to create a pen 
    ' and set its DashStyle property. 

    ' This example is designed to be used with Windows Forms. Create
    ' a form that contains a Button named Button3. Paste the code into the 
    ' form and associate the Button3_Click method with the button's 
    ' Click event.
    '<snippet3>
    Private Sub Button3_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button3.Click

        Dim buttonGraphics As Graphics = Button3.CreateGraphics()
        Dim myPen As Pen = New Pen(Color.ForestGreen, 4.0F)
        myPen.DashStyle = Drawing2D.DashStyle.DashDotDot

        Dim theRectangle As Rectangle = Button3.ClientRectangle
        theRectangle.Inflate(-2, -2)
        buttonGraphics.DrawRectangle(myPen, theRectangle)
        buttonGraphics.Dispose()
        myPen.Dispose()
    End Sub
    '</snippet3>

    ' The following code example demonstrates the Clear method.

    ' This example is designed to be used with Windows Forms.
    ' Create a form that contains a Button named Button4.
    ' Paste the code into the form and associate 
    ' the Button4_Click method with the button's Click event.
    '<snippet4>
    Private Sub Button4_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button4.Click

        Dim buttonGraphics As Graphics = Button4.CreateGraphics()
        buttonGraphics.Clear(Button4.BackColor)
        buttonGraphics.Dispose()
    End Sub
    '</snippet4>

    ' The following code example demonstrates calling the Save method.

    ' This example is designed to be used with Windows Forms. 
    ' Create a form that contains a button named Button5.
    ' Paste the code to the form and associate 
    ' the Button5_Click method with button's Click event.
    '<snippet5>
    Private Sub Button5_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If (image1 IsNot Nothing) Then
                image1.Save("c:\myBitmap.bmp")
                Button5.Text = "Saved file."
            End If
        Catch ex As Exception
            MessageBox.Show("There was a problem saving the file." _
            & "Check the file permissions.")
        End Try

    End Sub
    '</snippet5>

' This example was extracted from the "Reading Metadata"
    ' conceptual topic.
    '
    ' The following method demonstrates how to read and display 
    ' the metadata in an image file using the PropertyItem class and
    ' PropertyItems property. 
    '
    ' This example is designed to be used a Windows Form that imports the
    ' System.Drawing.Imaging namespace.
    ' Paste the code into the form and change the path to fakePhoto.jpg 
    ' to point to an image file on your system. Call the ExtractMetaData 
    ' method when handling the form's Paint event, passing e as PaintEventArgs.

    '<snippet6>
    Private Sub ExtractMetaData(ByVal e As PaintEventArgs)

        Try
            'Create an Image object. 
            Dim theImage As Image = New Bitmap("c:\fakePhoto.jpg")

            'Get the PropertyItems property from image.
            Dim propItems As PropertyItem() = theImage.PropertyItems

            'Set up the display.
            Dim font As New font("Arial", 10)
            Dim blackBrush As New SolidBrush(Color.Black)
            Dim X As Integer = 0
            Dim Y As Integer = 0

            'For each PropertyItem in the array, display the id, type, and length.
            Dim count As Integer = 0
            Dim propItem As PropertyItem
            For Each propItem In propItems

                e.Graphics.DrawString("Property Item " + count.ToString(), _
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   iD: 0x" & propItem.Id.ToString("x"), _
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   type: " & propItem.Type.ToString(), _
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   length: " & propItem.Len.ToString() & _
                    " bytes", font, blackBrush, X, Y)
                Y += font.Height

                count += 1
            Next propItem

            font.Dispose()
        Catch ex As ArgumentException
            MessageBox.Show("There was an error. Make sure the path to the image file is valid.")
        End Try

    End Sub
    '</snippet6>

' The following code example demonstrates how to use the GetPropertyItem
    ' and SetPropertyItem methods. This example is designed to be used with Windows
    ' Forms. To run this example paste it into a form, and handle the form's Paint event
    ' by calling the DemonstratePropertyItem method, passing e as PaintEventArgs.
'<snippet7>
    Private Sub DemonstratePropertyItem(ByVal e As PaintEventArgs)

        ' Create two images.
        Dim image1 As Image = Image.FromFile("c:\FakePhoto1.jpg")
        Dim image2 As Image = Image.FromFile("c:\FakePhoto2.jpg")

        ' Get a PropertyItem from image1.
        Dim propItem As PropertyItem = image1.GetPropertyItem(20624)

        ' Change the ID of the PropertyItem.
        propItem.Id = 20625

        ' Set the PropertyItem for image2.
        image2.SetPropertyItem(propItem)

        ' Draw the image.
        e.Graphics.DrawImage(image2, 20.0F, 20.0F)
    End Sub
    '</snippet7>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
