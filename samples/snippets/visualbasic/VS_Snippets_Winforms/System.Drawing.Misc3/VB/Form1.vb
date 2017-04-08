
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.ComponentModel
Imports System.Drawing.Text


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        ExtractAssociatedIconEx()
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

        Me.ClientSize = New System.Drawing.Size(292, 266)

        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub


    <System.STAThread()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    '<snippet1>    
    Protected Sub DrawCaps(ByVal e As PaintEventArgs)
        Dim hPath As New GraphicsPath()

        ' Create the outline for our custom end cap.
        hPath.AddLine(New Point(0, 0), New Point(0, 5))
        hPath.AddLine(New Point(0, 5), New Point(5, 1))
        hPath.AddLine(New Point(5, 1), New Point(3, 1))

        ' Construct the hook-shaped end cap.
        Dim HookCap As New CustomLineCap(Nothing, hPath)

        ' Set the start cap and end cap of the HookCap to be rounded.
        HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round)

        ' Create a pen and set end custom start and end
        ' caps to the hook cap.
        Dim customCapPen As New Pen(Color.Black, 5)
        customCapPen.CustomStartCap = HookCap
        customCapPen.CustomEndCap = HookCap

        ' Create a second pen using the start and end caps from
        ' the hook cap.
        Dim capPen As New Pen(Color.Red, 10)
        Dim startCap As LineCap
        Dim endCap As LineCap
        HookCap.GetStrokeCaps(startCap, endCap)
        capPen.StartCap = startCap
        capPen.EndCap = endCap

        ' Create a line to draw.
        Dim points As Point() = {New Point(100, 100), New Point(200, 50), _
            New Point(250, 300)}

        ' Draw the lines.
        e.Graphics.DrawLines(capPen, points)
        e.Graphics.DrawLines(customCapPen, points)

    End Sub
    '</snippet1>  

    '<snippet2>  
    Private Sub ExtractAssociatedIconEx()
        Dim ico As Icon = Icon.ExtractAssociatedIcon("C:\WINDOWS\system32\notepad.exe")
        Me.Icon = ico

    End Sub
    '</snippet2> 

    '<snippet3> 
    Private Sub ConstructAnIconFromAType(ByVal e As PaintEventArgs)

        Dim icon1 As New Icon(GetType(Control), "Error.ico")
        e.Graphics.DrawIcon(icon1, New Rectangle(10, 10, 50, 50))

    End Sub
    '</snippet3>

    ' <snippet4>
    Private Sub ShowOutputChannels(ByVal e As PaintEventArgs)

        'Create a bitmap from a file.
        Dim bmp1 As New Bitmap("c:\fakePhoto.jpg")

        ' Create a new bitmap from the original, resizing it for this example.
        Dim bmp2 As New Bitmap(bmp1, New Size(80, 80))

        bmp1.Dispose()

        ' Create an ImageAttributes object.
        Dim imgAttributes As New System.Drawing.Imaging.ImageAttributes()

        ' Draw the image unaltered.
        e.Graphics.DrawImage(bmp2, 10, 10)

        ' Draw the image, showing the intensity of the cyan channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelC, ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(bmp2, New Rectangle(100, 10, bmp2.Width, bmp2.Height), _
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes)

        ' Draw the image, showing the intensity of the magenta channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelM, ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(bmp2, New Rectangle(10, 100, bmp2.Width, bmp2.Height), _
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes)

        ' Draw the image, showing the intensity of the yellow channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelY, _
            ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(bmp2, New Rectangle(100, 100, bmp2.Width, bmp2.Height), _
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes)

        ' Draw the image, showing the intensity of the black channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelK, _
            ColorAdjustType.Bitmap)

        e.Graphics.DrawImage(bmp2, New Rectangle(10, 190, bmp2.Width, bmp2.Height), _
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes)

        'Dispose of the bitmap.
        bmp2.Dispose()

    End Sub

    ' </snippet4>

'<snippet5>
    Private Sub OpAdditionExample(ByVal e As PaintEventArgs) 
        Dim size1 As New SizeF(120.5F, 30.5F)
        Dim point1 As New PointF(20.5F, 20F)
        Dim rect1 As New RectangleF(point1, size1)
        If New PointF(rect1.Right, rect1.Bottom) = point1 + size1 Then
            e.Graphics.DrawString("They are equal", Me.Font, Brushes.Black, rect1)
        Else
            e.Graphics.DrawString("They are not equal", Me.Font, Brushes.Red, rect1)
        End If
     
    End Sub
    '</snippet5>

    '<snippet6>
    Private Sub AddExample(ByVal e As PaintEventArgs) 
        Dim size1 As New SizeF(120.5F, 30.5F)
        Dim point1 As New PointF(20.5F, 20F)
        Dim rect1 As New RectangleF(point1, size1)
        Dim point2 As New PointF(rect1.Right, rect1.Bottom)
        If point2 <> PointF.Add(point1, size1) Then
            e.Graphics.DrawString("They are not equal", Me.Font, Brushes.Red, rect1)
        Else
            e.Graphics.DrawString("They are equal", Me.Font, Brushes.Black, rect1)
        End If
    
    End Sub
    '</snippet6>

    '<snippet7>
    Private Sub SubtractExample(ByVal e As PaintEventArgs) 
        Dim point1 As New PointF(120.5F, 120F)
        Dim size1 As New SizeF(120.5F, 30.5F)
        Dim point2 As PointF = PointF.Subtract(point1, size1)
        e.Graphics.DrawLine(Pens.Blue, point1, point2)
    
    End Sub
    '</snippet7>

    '<snippet8>
    Private Sub OpSubtractionExample(ByVal e As PaintEventArgs) 
        Dim point1 As New PointF(120.5F, 120F)
        Dim size1 As New SizeF(120.5F, 30.5F)
        Dim point2 As PointF = point1 - size1
        e.Graphics.DrawLine(Pens.Blue, point1, point2)
    
    End Sub
    '</snippet8>

   Private Sub ShearColors(ByVal e As PaintEventArgs) 
        '<snippet9>
        Dim image = New Bitmap("ColorBars.bmp")
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height
        
        Dim colorMatrixElements As Single()() = _
            {New Single() {1, 0, 0, 0, 0}, _
                New Single() {0, 1, 0, 0, 0}, _
                New Single() {0.5F, 0, 1, 0, 0}, _
                New Single() {0, 0, 0, 1, 0}, _
                New Single() {0, 0, 0, 0, 1}}
        
        Dim colorMatrix As New ColorMatrix(colorMatrixElements)
        
        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, _
            ColorAdjustType.Bitmap)
        
        e.Graphics.DrawImage(image, 10, 10, width, height)
        
        e.Graphics.DrawImage(image, New Rectangle(150, 10, width, height), 0, 0, _
            width, height, GraphicsUnit.Pixel, imageAttributes)
        '</snippet9>
    End Sub

 	'<snippetInstalledFonts> 
    	Private ifc As New InstalledFontCollection()
    	
	Private Sub EnumerateInstalledFonts(ByVal e As PaintEventArgs)
          Dim families As FontFamily() = ifc.Families
       	  Dim x As Single = 0.0F
       	  Dim y As Single = 0.0F
        	For i As Integer = 0 To ifc.Families.Length - 1
            	  If ifc.Families(i).IsStyleAvailable(FontStyle.Regular) Then
                	e.Graphics.DrawString(ifc.Families(i).Name, New Font(ifc.Families(i), 12),  _ 
			  Brushes.Black, x, y)
                	y += 20
                	If y Mod 700 = 0 Then
                          x += 140
                    	  y = 0
                        End If
            	  End If
        	Next
       End Sub
    '</snippetInstalledFonts>

    '<snippetConstructFontWithString>
    Private Sub ConstructFontWithString(ByVal e As PaintEventArgs)
        Dim font1 As New Font("Arial", 20)
        e.Graphics.DrawString("Arial Font", font1, Brushes.Red, New PointF(10, 10))
    End Sub
    '</snippetConstructFontWithString>

    Private Shared Function ResizeImage(ByVal image As System.Drawing.Image) As Bitmap 
       '<snippetSetResolution> 
       Dim bitmap As New Bitmap(100, 100) 
       bitmap.SetResolution(96F, 96F) 
       '</snippetSetResolution> 
    
       Using graphics__1 As Graphics = Graphics.FromImage(bitmap) 
          graphics__1.DrawImage(image, New Rectangle(0, 0, 100, 100), New Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel) 
       End Using 
    
       Return bitmap 
    End Function 
 '<snippetGetThumbnail>

    Public Function ThumbnailCallback() As Boolean 
      Return False 
    End Function 

    Public Sub Example_GetThumb(ByVal e As PaintEventArgs) 
        Dim myCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback) 
        Dim myBitmap As New Bitmap("Climber.jpg") 
        Dim myThumbnail As Image = myBitmap.GetThumbnailImage(40, 40, myCallback, IntPtr.Zero) 
        e.Graphics.DrawImage(myThumbnail, 150, 75) 
    End Sub 

'</snippetGetThumbnail>

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
        DrawCaps(e)
        'ConstructAnIconFromAType(e);
        ShowOutputChannels(e)

    End Sub 'Form1_Paint
End Class 'Form1 





