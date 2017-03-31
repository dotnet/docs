Option Strict On
Option Explicit On 


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
        PopulateListBoxWithFonts()
        PopulateListBoxWithGraphicsResolution()
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
    Friend WithEvents listBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.listBox1 = New System.Windows.Forms.ListBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'listBox1
        '
        Me.listBox1.Location = New System.Drawing.Point(88, 112)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(120, 95)
        Me.listBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(120, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.listBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' The following code example shows all the font families in the
    ' Families property of the FontFamily class. This example is 
    ' designed to be used with a Windows form. To run this example, 
    ' add a ListBox named listBox1 to a form and call the 
    ' PopulateListBoxWithFonts method from the form's constructor.
    '<snippet1>
    Private Sub PopulateListBoxWithFonts()
        listBox1.Width = 200
        listBox1.Location = New Point(40, 120)
        Dim oneFontFamily As FontFamily
        For Each oneFontFamily In FontFamily.Families
            listBox1.Items.Add(oneFontFamily.Name)
        Next
    End Sub
    '</snippet1>

    ' The following method shows the use of the DpiX and DpiY
    ' properties. This example is designed for use with a Windows Form. 
    ' To run this example, paste it into a form that contains a ListBox named 
    ' listBox1 and call this method from the form's constructor or Load event.
    '<snippet4>
    Private Sub PopulateListBoxWithGraphicsResolution()
        Dim boxGraphics As Graphics = listBox1.CreateGraphics()
        Dim formGraphics As Graphics = Me.CreateGraphics()

        listBox1.Items.Add("ListBox horizontal resolution: " _
            & boxGraphics.DpiX)
        listBox1.Items.Add("ListBox vertical resolution: " _
            & boxGraphics.DpiY)

        boxGraphics.Dispose()
    End Sub
    '</snippet4>

    ' The following code example shows how to set a keyboard shortcut
    ' when drawing a string with the Graphics object. It also 
    ' demonstrates how to use the SystemBrush.FromSystemColor method. To  
    ' run this example, paste the code into a form, handle the form's 
    ' Paint event and call the following method, passing e as 
    ' PaintEventArgs.
    '<snippet2>
    Private Sub ShowHotKey(ByVal e As PaintEventArgs)

        ' Declare the string with keyboard shortcut.
        Dim text As String = "&Click Here"

        ' Declare a new StringFormat.
        Dim format As New StringFormat

        ' Set the HotkeyPrefix property.
        format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show

        ' Draw the string.
        Dim theBrush As Brush = _
            SystemBrushes.FromSystemColor(SystemColors.Highlight)
        e.Graphics.DrawString(text, Me.Font, theBrush, 30, 40, format)
    End Sub
    '</snippet2>

    ' The following code example adds a shadow to a ListBox using the
    ' following members:
    '   Size.opImplicit
    '   SizeF.opAddition
    '   Point.opImplicit
    '   PointF.opAddition
    '   SolidBrush 

    ' This example is designed to be used with a Windows Form. 
    ' To run this example, paste this code into a form and call the
    ' AddShadow method when handling the form's Paint event. Make
    ' sure the form contains a ListBox named listBox1.

    '<snippet3>
    Private Sub AddShadow(ByVal e As PaintEventArgs)

        ' Create two SizeF objects.
        Dim shadowSize As SizeF = Size.op_Implicit(listBox1.Size)
        Dim addSize As New SizeF(10.5F, 20.8F)

        ' Add them together and save the result in shadowSize.
        shadowSize = SizeF.op_Addition(shadowSize, addSize)

        ' Get the location of the ListBox and convert it to a PointF.
        Dim shadowLocation As PointF = Point.op_Implicit(listBox1.Location)

        ' Add a Size to the Point to get a new location.
        shadowLocation = PointF.op_Addition(shadowLocation, New Size(5, 5))

        ' Create a rectangleF. 
        Dim rectFToFill As New RectangleF(shadowLocation, shadowSize)

        ' Create a custom brush using a semi-transparent color, and 
        ' then fill in the rectangle.
        Dim customColor As Color = Color.FromArgb(50, Color.Gray)
        Dim shadowBrush As SolidBrush = New SolidBrush(customColor)
        e.Graphics.FillRectangles(shadowBrush, _
            New RectangleF() {rectFToFill})

        ' Dispose of the brush.
        shadowBrush.Dispose()
    End Sub
    '</snippet3>

    ' The following code example demonstrates using a Matrix
    ' and the GraphicsPath.Transform method to rotate a string.
    ' This example is designed to be used with Windows Forms.
    ' Create a form and paste the following code into it.  Call the
    ' DrawVerticalStringFromBottomUp method in the form's Paint 
    ' event-handling method, passing e as PaintEventArgs.
    '<snippet5>
    Public Sub DrawVerticalStringFromBottomUp(ByVal e As PaintEventArgs)

        ' Create the string to draw on the form.
        Dim text As String = "Can you read this?"

        ' Create a GraphicsPath.
        Dim path As New System.Drawing.Drawing2D.GraphicsPath

        ' Add the string to the path; declare the font, font style, size, and
        ' vertical format for the string.
        path.AddString(text, Me.Font.FontFamily, 1, 15, New PointF(0.0F, 0.0F), _
            New StringFormat(StringFormatFlags.DirectionVertical))

        ' Declare a matrix that will be used to rotate the text.
        Dim rotateMatrix As New System.Drawing.Drawing2D.Matrix

        ' Set the rotation angle and starting point for the text.
        rotateMatrix.RotateAt(180.0F, New PointF(10.0F, 100.0F))

        ' Transform the text with the matrix.
        path.Transform(rotateMatrix)

        ' Set the SmoothingMode to high quality for best readability.
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

        ' Fill in the path to draw the string.
        e.Graphics.FillPath(Brushes.Red, path)

        ' Dispose of the path.
        path.Dispose()

    End Sub
    '</snippet5>


    ' The following code example demonstrates how to use the KnownColor enum
    ' to print out the name and colors of all its values. This example is 
    ' designed to be used with Windows Forms. Create a form and paste
    ' the following code into it.  Call the DisplayKnownColors method in the
    ' form's Paint event-handling method, passing e as PaintEventArgs.
    '<snippet6>
    Private Sub DisplayKnownColors(ByVal e As PaintEventArgs)
        Me.Size = New Size(650, 550)
        Dim i As Integer

        ' Get all the values from the KnownColor enumeration.
        Dim colorsArray As System.Array = _
            [Enum].GetValues(GetType(KnownColor))
        Dim allColors(colorsArray.length) As KnownColor

        Array.Copy(colorsArray, allColors, colorsArray.Length)

        ' Loop through printing out the value's name in the colors 
        ' they represent.
        Dim y As Single
        Dim x As Single = 10.0F

        For i = 0 To allColors.Length - 1

            ' If x is a multiple of 30, start a new column.
            If (i > 0 And i Mod 30 = 0) Then
                x += 105.0F
                y = 15.0F
            Else
                ' Otherwise increment y by 15.
                y += 15.0F
            End If

            ' Create a custom brush from the color and use it to draw
            ' the brush's name.
            Dim aBrush As New SolidBrush(Color.FromName( _
                allColors(i).ToString()))
            e.Graphics.DrawString(allColors(i).ToString(), _
                Me.Font, aBrush, x, y)

            ' Dispose of the custom brush.
            aBrush.Dispose()
        Next

    End Sub
    '</snippet6>

    ' The following code example demonstrates how to use the MakeEmpty
    ' method. This example is designed to be used with Windows Forms.
    ' Create a form and paste the following code into it.  Call the 
    ' FillEmptyRegion method in the form's Paint event-handling method,
    ' passing e as PaintEventArgs.
    '<snippet7>
    Private Sub FillEmptyRegion(ByVal e As PaintEventArgs)

        ' Create a region from a rectangle.
        Dim originalRectangle As New Rectangle(40, 40, 40, 50)
        Dim smallRegion As New Region(originalRectangle)

        ' Call MakeEmpty.
        smallRegion.MakeEmpty()

        ' Fill the region in red and draw the original rectangle
        ' in black. Note there is nothing filled in.
        e.Graphics.FillRegion(Brushes.Red, smallRegion)
        e.Graphics.DrawRectangle(Pens.Black, originalRectangle)

    End Sub
    '</snippet7>

    ' The following code example demonstrates how to use the MakeInfinite
    ' method. This example is designed to be used with Windows Forms. 
    ' Create a form and paste the following code into it.  Call the
    ' FillInfiniteRegion method in the form's Paint event-handling method, 
    ' passing e as PaintEventArgs.
    '<snippet8>
    Private Sub FillInfiniteRegion(ByVal e As PaintEventArgs)
        ' Create a region from a rectangle.
        Dim originalRectangle As New Rectangle(40, 40, 40, 50)
        Dim smallRegion As New Region(originalRectangle)

        ' Call MakeInfinite.
        smallRegion.MakeInfinite()

        ' Fill the region in red and draw the original rectangle
        ' in black. Note that the entire form is filled in.
        e.Graphics.FillRegion(Brushes.Red, smallRegion)
        e.Graphics.DrawRectangle(Pens.Black, originalRectangle)

    End Sub
    '</snippet8>

    ' The following code example demonstrates how to use the ToBitmap
    ' method. This example is designed to be used with Windows Forms. 
    ' Create a form and paste the following code into it.  Call the 
    ' IconToBitmap method in the form's Paint event-handling method, 
    ' passing e as PaintEventArgs.
    '<snippet9>
    Private Sub IconToBitmap(ByVal e As PaintEventArgs)

        ' Construct an Icon.
        Dim icon1 As New Icon(SystemIcons.Exclamation, 40, 40)

        ' Call ToBitmap to convert it.
        Dim bmp As Bitmap = icon1.ToBitmap()

        ' Draw the bitmap.
        e.Graphics.DrawImage(bmp, New Point(30, 30))
    End Sub
    '</snippet9>

   

    ' The following code example demonstrates using the TranslateTransform
    ' method. This example is designed to be used with Windows forms.  
    ' Create a form and paste the following code into it.  Call the 
    ' TranslateAndTransform method in the form's Paint event-handling 
    ' method, passing e asPaintEventArgs.
    '<snippet10>
    Private Sub TranslateAndTransform(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath.
        Dim myPath As New Drawing2D.GraphicsPath

        ' Create a rectangle.
        Dim layoutRectangle As RectangleF = _
             New RectangleF(20.0F, 20.0F, 40.0F, 50.0F)

        ' Add the rectangle to the path.
        myPath.AddRectangle(layoutRectangle)

        ' Add a string to the path.
        myPath.AddString("Path", Me.Font.FontFamily, 2, 10.0F, layoutRectangle, _
            New StringFormat(StringFormatFlags.NoWrap))

        ' Draw the path.
        e.Graphics.DrawPath(Pens.Black, myPath)

        ' Call TranslateTransform and draw the path again.
        e.Graphics.TranslateTransform(10.0F, 10.0F)
        e.Graphics.DrawPath(Pens.Red, myPath)

    End Sub
    '</snippet10>


    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'FillEmptyRegion(e)
        'SetAndFillClip(e)
        'FillInfiniteRegion(e)
        'ShowHotKey(e)
        'AddShadow(e)
        'IconToBitmap(e)
        'DisplayKnownColors(e)
        'DrawVerticalStringFromBottomUp(e)
        TranslateAndTransform(e)



    End Sub

    ' The following code example demonstrates setting the Font property of 
    ' a button to a new, bold-style Font. This example is designed to be
    ' used with Windows forms. Create a form containing a button named 
    ' Button1 andand paste the following code into it. Associate the 
    ' following method with the button's Click event.
    '<snippet11>
     Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        If Not Button1.Font.Style = FontStyle.Bold Then
            Button1.Font = New Font(FontFamily.GenericSansSerif, _
                12.0F, FontStyle.Bold)
        End If
    End Sub
    '</snippet11>

' The following code example demonstrates how to construct a Region
    ' using the RegionData class. This example is designed to be used with Windows
    ' Forms. To run this example paste it into a form and handle the form's Paint event
    ' by calling the DemonstrateRegionData method, passing e as PaintEventArgs.
    ' <snippet12>
    Private Sub DemonstrateRegionData(ByVal e As PaintEventArgs)

        'Create a simple region.
        Dim region1 As New Region(New Rectangle(10, 10, 100, 100))

        ' Extract the region data.
        Dim region1Data As System.Drawing.Drawing2D.RegionData = _
            region1.GetRegionData

        ' Create a new region using the region data.
        Dim region2 As New Region(region1Data)

        ' Dispose of the first region.
        region1.Dispose()

        ' Call ExcludeClip passing in the second region.
        e.Graphics.ExcludeClip(region2)

        ' Fill in the client rectangle.
        e.Graphics.FillRectangle(Brushes.Red, Me.ClientRectangle)

        region2.Dispose()

    End Sub
    ' </snippet12>

' The following code example demonstrates how use the Data from
    ' one region to set the Data for another region. This example is designed 
    ' to be used with Windows Forms. To run this example paste
    ' it into a form and handle the form's Paint event
    ' by calling the DemonstrateRegionData2 method, passing e as PaintEventArgs.
    ' <snippet13>
    Private Sub DemonstrateRegionData2(ByVal e As PaintEventArgs)

        'Create a simple region.
        Dim region1 As New Region(New Rectangle(10, 10, 100, 100))

        ' Extract the region data.
        Dim region1Data As System.Drawing.Drawing2D.RegionData = region1.GetRegionData
        Dim data1() As Byte
        data1 = region1Data.Data

        ' Create a second region.
        Dim region2 As New Region

        ' Get the region data for the second region.
        Dim region2Data As System.Drawing.Drawing2D.RegionData = region2.GetRegionData()

        ' Set the Data property for the second region to the Data from the first region.
        region2Data.Data = data1

        ' Construct a third region using the modified RegionData of the second region.
        Dim region3 As New Region(region2Data)

        ' Dispose of the first and second regions.
        region1.Dispose()
        region2.Dispose()

        ' Call ExcludeClip passing in the third region.
        e.Graphics.ExcludeClip(region3)

        ' Fill in the client rectangle.
        e.Graphics.FillRectangle(Brushes.Red, Me.ClientRectangle)

        region3.Dispose()

    End Sub
    ' </snippet13>
    '<snippetConstructor>
    Private Sub BitmapConstructorEx(ByVal e As PaintEventArgs)

        ' Create a bitmap.
        Dim bmp As New Bitmap("c:\fakePhoto.jpg")

        ' Retrieve the bitmap data from the the bitmap.
        Dim bmpData As System.Drawing.Imaging.BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), _
            ImageLockMode.ReadOnly, bmp.PixelFormat)

        'Create a new bitmap.
        Dim newBitmap As New Bitmap(200, 200, bmpData.Stride, bmp.PixelFormat, bmpData.Scan0)

        bmp.UnlockBits(bmpData)

        ' Draw the new bitmap.
        e.Graphics.DrawImage(newBitmap, 10, 10)

    End Sub
    '</snippetConstructor>

End Class


