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
    ' Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Drawing.Rectangle)
    ' <snippet111>
    Private Sub FillRectangleRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create rectangle.
        Dim rect As New Rectangle(0, 0, 200, 200)

        ' Fill rectangle to screen.
        e.Graphics.FillRectangle(blueBrush, rect)
    End Sub
    ' </snippet111>


    ' Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Drawing.RectangleF)
    ' <snippet112>
    Private Sub FillRectangleRectangleF(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create rectangle.
        Dim rect As New RectangleF(0.0F, 0.0F, 200.0F, 200.0F)

        ' Fill rectangle to screen.
        e.Graphics.FillRectangle(blueBrush, rect)
    End Sub
    ' </snippet112>


    ' Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet113>
    Private Sub FillRectangleInt(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create location and size of rectangle.
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim width As Integer = 200
        Dim height As Integer = 200

        ' Fill rectangle to screen.
        e.Graphics.FillRectangle(blueBrush, x, y, width, height)
    End Sub
    ' </snippet113>


    ' Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Single,System.Single,System.Single,System.Single)
    ' <snippet114>
    Private Sub FillRectangleFloat(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create location and size of rectangle.
        Dim x As Single = 0.0F
        Dim y As Single = 0.0F
        Dim width As Single = 200.0F
        Dim height As Single = 200.0F

        ' Fill rectangle to screen.
        e.Graphics.FillRectangle(blueBrush, x, y, width, height)
    End Sub
    ' </snippet114>


    ' Snippet for: M:System.Drawing.Graphics.FillRectangles(System.Drawing.Brush,System.Drawing.Rectangle[])
    ' <snippet115>
    Private Sub FillRectanglesRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create array of rectangles.
        Dim rects As Rectangle() = {New Rectangle(0, 0, 100, 200), _
        New Rectangle(100, 200, 250, 50), _
        New Rectangle(300, 0, 50, 100)}

        ' Fill rectangles to screen.
        e.Graphics.FillRectangles(blueBrush, rects)
    End Sub
    ' </snippet115>


    ' Snippet for: M:System.Drawing.Graphics.FillRectangles(System.Drawing.Brush,System.Drawing.RectangleF[])
    ' <snippet116>
    Private Sub FillRectanglesRectangleF(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create array of rectangles.
        Dim rects As RectangleF() = {New RectangleF(0.0F, 0.0F, 100.0F, 200.0F), _
        New RectangleF(100.0F, 200.0F, 250.0F, 50.0F), _
        New RectangleF(300.0F, 0.0F, 50.0F, 100.0F)}

        ' Fill rectangles to screen.
        e.Graphics.FillRectangles(blueBrush, rects)
    End Sub
    ' </snippet116>


    ' Snippet for: M:System.Drawing.Graphics.FillRegion(System.Drawing.Brush,System.Drawing.Region)
    ' <snippet117>
    Private Sub FillRegionRectangle(ByVal e As PaintEventArgs)

        ' Create solid brush.
        Dim blueBrush As New SolidBrush(Color.Blue)

        ' Create rectangle for region.
        Dim fillRect As New Rectangle(100, 100, 200, 200)

        ' Create region for fill.
        Dim fillRegion As New [Region](fillRect)

        ' Fill region to screen.
        e.Graphics.FillRegion(blueBrush, fillRegion)
    End Sub
    ' </snippet117>


    ' Snippet for: M:System.Drawing.Graphics.FromHdc(System.IntPtr)
    ' <snippet118>
    <System.Security.Permissions.SecurityPermission( _
    System.Security.Permissions.SecurityAction.LinkDemand, Flags := _
    System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Private Sub FromHdcHdc(ByVal e As PaintEventArgs)

        ' Get handle to device context.
        Dim hdc As IntPtr = e.Graphics.GetHdc()

        ' Create new graphics object using handle to device context.
        Dim newGraphics As Graphics = Graphics.FromHdc(hdc)

        ' Draw rectangle to screen.
        newGraphics.DrawRectangle(New Pen(Color.Red, 3), 0, 0, 200, 100)

        ' Release handle to device context and dispose of the Graphics 	' object
        e.Graphics.ReleaseHdc(hdc)
        newGraphics.Dispose()
    End Sub
    ' </snippet118>


    ' Snippet for: M:System.Drawing.Graphics.FromHwnd(System.IntPtr)
    ' <snippet119>
    Private Sub FromHwndHwnd(ByVal e As PaintEventArgs)

        ' Get handle to form.
        Dim hwnd As IntPtr = Me.Handle


        ' Create new graphics object using handle to window.
        Dim newGraphics As Graphics = Graphics.FromHwnd(hwnd)

        ' Draw rectangle to screen.
        newGraphics.DrawRectangle(New Pen(Color.Red, 3), 0, 0, 200, 100)

        ' Dispose of new graphics.
        newGraphics.Dispose()
    End Sub
    ' </snippet119>


    ' Snippet for: M:System.Drawing.Graphics.FromImage(System.Drawing.Image)
    ' <snippet120>
    Private Sub FromImageImage2(ByVal e As PaintEventArgs)

        ' Create image.
        Dim imageFile As Image = Image.FromFile("SampImag.jpg")

        ' Create graphics object for alteration.
        Dim newGraphics As Graphics = Graphics.FromImage(imageFile)

        ' Alter image.
        newGraphics.FillRectangle(New SolidBrush(Color.Black), _
        100, 50, 100, 100)

        ' Draw image to screen.
        e.Graphics.DrawImage(imageFile, New PointF(0.0F, 0.0F))

        ' Dispose of graphics object.
        newGraphics.Dispose()
    End Sub
    ' </snippet120>


    ' Snippet for: M:System.Drawing.Graphics.GetHalftonePalette
    ' <snippet121>
    <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
    Private Shared Function SelectPalette(ByVal hdc As IntPtr, _
    ByVal htPalette As IntPtr, ByVal bForceBackground As Boolean) As IntPtr
    End Function

    <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
    Private Shared Function RealizePalette(ByVal hdc As IntPtr) As Integer
    End Function

    <System.Security.Permissions.SecurityPermission( _
    System.Security.Permissions.SecurityAction.LinkDemand, Flags:= _
    System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Private Sub GetHalftonePaletteVoid(ByVal e As PaintEventArgs)

        ' Create and draw image.
        Dim imageFile As Image = Image.FromFile("SampImag.jpg")
        e.Graphics.DrawImage(imageFile, New Point(0, 0))

        ' Get handle to device context.
        Dim hdc As IntPtr = e.Graphics.GetHdc()

        ' Get handle to halftone palette.
        Dim htPalette As IntPtr = Graphics.GetHalftonePalette()

        ' Select and realize new palette.
        SelectPalette(hdc, htPalette, True)
        RealizePalette(hdc)

        ' Create new graphics object.
        Dim newGraphics As Graphics = Graphics.FromHdc(hdc)

        ' Draw image with new palette.
        newGraphics.DrawImage(imageFile, 300, 0)

        ' Release handle to device context.
        e.Graphics.ReleaseHdc(hdc)
    End Sub
    ' </snippet121>


    ' Snippet for: M:System.Drawing.Graphics.GetHdc
    ' <snippet122>
    Public Class GDI
        <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
        Friend Shared Function Rectangle(ByVal hdc As IntPtr, _
        ByVal ulCornerX As Integer, ByVal ulCornerY As Integer, ByVal lrCornerX As Integer, _
        ByVal lrCornerY As Integer) As Boolean
        End Function
    End Class

    <System.Security.Permissions.SecurityPermission( _
    System.Security.Permissions.SecurityAction.LinkDemand, Flags:= _
    System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Private Sub GetHdcForGDI1(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim redPen As New Pen(Color.Red, 1)

        ' Draw rectangle with GDI+.
        e.Graphics.DrawRectangle(redPen, 10, 10, 100, 50)

        ' Get handle to device context.
        Dim hdc As IntPtr = e.Graphics.GetHdc()

        ' Draw rectangle with GDI using default pen.
        GDI.Rectangle(hdc, 10, 70, 110, 120)

        ' Release handle to device context.
        e.Graphics.ReleaseHdc(hdc)
    End Sub
    ' </snippet122>


    ' Snippet for: M:System.Drawing.Graphics.GetNearestColor(System.Drawing.Color)
    ' <snippet123>
    Private Sub GetNearestColorColor(ByVal e As PaintEventArgs)

        ' Create solid brush with arbitrary color.
        Dim arbColor As Color = Color.FromArgb(255, 165, 63, 136)
        Dim arbBrush As New SolidBrush(arbColor)

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(arbBrush, 0, 0, 200, 100)

        ' Get nearest color.
        Dim realColor As Color = e.Graphics.GetNearestColor(arbColor)
        Dim realBrush As New SolidBrush(realColor)

        ' Fill ellipse on screen.
        e.Graphics.FillEllipse(realBrush, 0, 100, 200, 100)
    End Sub
    ' </snippet123>


    ' Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.Rectangle)
    ' <snippet124>
    Private Sub IntersectClipRectangle(ByVal e As PaintEventArgs)

        ' Set clipping region.
        Dim clipRect As New Rectangle(0, 0, 200, 200)
        e.Graphics.SetClip(clipRect)

        ' Update clipping region to intersection of

        ' existing region with specified rectangle.
        Dim intersectRect As New Rectangle(100, 100, 200, 200)
        e.Graphics.IntersectClip(intersectRect)

        ' Fill rectangle to demonstrate effective clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        500, 500)

        ' Reset clipping region to infinite.
        e.Graphics.ResetClip()

        ' Draw clipRect and intersectRect to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Black), clipRect)
        e.Graphics.DrawRectangle(New Pen(Color.Red), intersectRect)
    End Sub
    ' </snippet124>


    ' Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.RectangleF)
    ' <snippet125>
    Private Sub IntersectClipRectangleF1(ByVal e As PaintEventArgs)

        ' Set clipping region.
        Dim clipRect As New Rectangle(0, 0, 200, 200)
        e.Graphics.SetClip(clipRect)

        ' Update clipping region to intersection of

        ' existing region with specified rectangle.
        Dim intersectRectF As New RectangleF(100.0F, 100.0F, 200.0F, 200.0F)
        e.Graphics.IntersectClip(intersectRectF)

        ' Fill rectangle to demonstrate effective clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        500, 500)

        ' Reset clipping region to infinite.
        e.Graphics.ResetClip()

        ' Draw clipRect and intersectRect to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Black), clipRect)
        e.Graphics.DrawRectangle(New Pen(Color.Red), _
        Rectangle.Round(intersectRectF))
    End Sub
    ' </snippet125>


    ' Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.Region)
    ' <snippet126>
    Private Sub IntersectClipRegion(ByVal e As PaintEventArgs)

        ' Set clipping region.
        Dim clipRect As New Rectangle(0, 0, 200, 200)
        Dim clipRegion As New [Region](clipRect)
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Update clipping region to intersection of

        ' existing region with specified rectangle.
        Dim intersectRect As New Rectangle(100, 100, 200, 200)
        Dim intersectRegion As New [Region](intersectRect)
        e.Graphics.IntersectClip(intersectRegion)

        ' Fill rectangle to demonstrate effective clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        500, 500)

        ' Reset clipping region to infinite.
        e.Graphics.ResetClip()

        ' Draw clipRect and intersectRect to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Black), clipRect)
        e.Graphics.DrawRectangle(New Pen(Color.Red), intersectRect)
    End Sub
    ' </snippet126>


    ' Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.Point)
    ' <snippet127>
    Private Sub IsVisiblePoint(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of points.
        Dim x1 As Integer = 100
        Dim y1 As Integer = 100
        Dim x2 As Integer = 200
        Dim y2 As Integer = 200
        Dim point1 As New Point(x1, y1)
        Dim point2 As New Point(x2, y2)

        ' If point is visible, fill ellipse that represents it.
        If e.Graphics.IsVisible(point1) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Red), x1, y1, _
            10, 10)
        End If
        If e.Graphics.IsVisible(point2) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Blue), x2, y2, _
            10, 10)
        End If
    End Sub
    ' </snippet127>


    ' Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.PointF)
    ' <snippet128>
    Private Sub IsVisiblePointF(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of points.
        Dim x1 As Single = 100.0F
        Dim y1 As Single = 100.0F
        Dim x2 As Single = 200.0F
        Dim y2 As Single = 200.0F
        Dim point1 As New PointF(x1, y1)
        Dim point2 As New PointF(x2, y2)

        ' If point is visible, fill ellipse that represents it.
        If e.Graphics.IsVisible(point1) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Red), x1, y1, _
            10.0F, 10.0F)
        End If
        If e.Graphics.IsVisible(point2) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Blue), x2, y2, _
            10.0F, 10.0F)
        End If
    End Sub
    ' </snippet128>


    ' Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.Rectangle)
    ' <snippet129>
    Private Sub IsVisibleRectangle(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of rectangles.
        Dim rect1 As New Rectangle(100, 100, 20, 20)
        Dim rect2 As New Rectangle(200, 200, 20, 20)

        ' If rectangle is visible, fill it.
        If e.Graphics.IsVisible(rect1) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Red), rect1)
        End If
        If e.Graphics.IsVisible(rect2) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Blue), rect2)
        End If
    End Sub
    ' </snippet129>


    ' Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.RectangleF)
    ' <snippet130>
    Private Sub IsVisibleRectangleF(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of rectangles.
        Dim rect1 As New RectangleF(100.0F, 100.0F, 20.0F, 20.0F)
        Dim rect2 As New RectangleF(200.0F, 200.0F, 20.0F, 20.0F)

        ' If rectangle is visible, fill it.
        If e.Graphics.IsVisible(rect1) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Red), rect1)
        End If
        If e.Graphics.IsVisible(rect2) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Blue), rect2)
        End If
    End Sub
    ' </snippet130>


    ' Snippet for: M:System.Drawing.Graphics.IsVisible(System.Int32,System.Int32)
    ' <snippet131>
    Private Sub IsVisibleInt(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of points.
        Dim x1 As Integer = 100
        Dim y1 As Integer = 100
        Dim x2 As Integer = 200
        Dim y2 As Integer = 200

        ' If point is visible, fill ellipse that represents it.
        If e.Graphics.IsVisible(x1, y1) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Red), x1, y1, _
            10, 10)
        End If
        If e.Graphics.IsVisible(x2, y2) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Blue), x2, y2, _
            10, 10)
        End If
    End Sub
    ' </snippet131>


    ' Snippet for: M:System.Drawing.Graphics.IsVisible(System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet132>
    Private Sub IsVisible4Int(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of rectangles.
        Dim x1 As Integer = 100
        Dim y1 As Integer = 100
        Dim width1 As Integer = 20
        Dim height1 As Integer = 20
        Dim x2 As Integer = 200
        Dim y2 As Integer = 200
        Dim width2 As Integer = 20
        Dim height2 As Integer = 20

        ' If rectangle is visible, fill it.
        If e.Graphics.IsVisible(x1, y1, width1, height1) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Red), x1, y1, _
            width1, height1)
        End If
        If e.Graphics.IsVisible(x2, y2, width2, height2) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Blue), x2, y2, _
            width2, height2)
        End If
    End Sub
    ' </snippet132>


    ' Snippet for: M:System.Drawing.Graphics.IsVisible(System.Single,System.Single)
    ' <snippet133>
    Private Sub IsVisibleFloat(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of points.
        Dim x1 As Single = 100.0F
        Dim y1 As Single = 100.0F
        Dim x2 As Single = 200.0F
        Dim y2 As Single = 200.0F

        ' If point is visible, fill ellipse that represents it.
        If e.Graphics.IsVisible(x1, y1) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Red), x1, y1, _
            10.0F, 10.0F)
        End If
        If e.Graphics.IsVisible(x2, y2) Then
            e.Graphics.FillEllipse(New SolidBrush(Color.Blue), x2, y2, _
            10.0F, 10.0F)
        End If
    End Sub
    ' </snippet133>


    ' Snippet for: M:System.Drawing.Graphics.IsVisible(System.Single,System.Single,System.Single,System.Single)
    ' <snippet134>
    Private Sub IsVisible4Float(ByVal e As PaintEventArgs)

        ' Set clip region.
        Dim clipRegion As New [Region](New Rectangle(50, 50, 100, 100))
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Set up coordinates of rectangles.
        Dim x1 As Single = 100.0F
        Dim y1 As Single = 100.0F
        Dim width1 As Single = 20.0F
        Dim height1 As Single = 20.0F
        Dim x2 As Single = 200.0F
        Dim y2 As Single = 200.0F
        Dim width2 As Single = 20.0F
        Dim height2 As Single = 20.0F

        ' If rectangle is visible, fill it.
        If e.Graphics.IsVisible(x1, y1, width1, height1) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Red), x1, y1, _
            width1, height1)
        End If
        If e.Graphics.IsVisible(x2, y2, width2, height2) Then
            e.Graphics.FillRectangle(New SolidBrush(Color.Blue), x2, y2, _
            width2, height2)
        End If
    End Sub
    ' </snippet134>


    ' Snippet for: M:System.Drawing.Graphics.MeasureCharacterRanges(System.String,System.Drawing.Font,System.Drawing.RectangleF,System.Drawing.StringFormat)
    ' <snippet135>
    Private Sub MeasureCharacterRangesRegions(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "First and Second ranges"
        Dim stringFont As New Font("Times New Roman", 16.0F)

        ' Set character ranges to "First" and "Second".
        Dim characterRanges As CharacterRange() = _
        {New CharacterRange(0, 5), New CharacterRange(10, 6)}

        ' Create rectangle for layout.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim width As Single = 35.0F
        Dim height As Single = 200.0F
        Dim layoutRect As New RectangleF(x, y, width, height)

        ' Set string format.
        Dim stringFormat As New StringFormat
        stringFormat.FormatFlags = StringFormatFlags.DirectionVertical
        stringFormat.SetMeasurableCharacterRanges(characterRanges)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        x, y, stringFormat)

        ' Measure two ranges in string.
        Dim stringRegions() As [Region] = e.Graphics.MeasureCharacterRanges(measureString, _
	stringFont, layoutRect, stringFormat)

        ' Draw rectangle for first measured range.
        Dim measureRect1 As RectangleF = _
        stringRegions(0).GetBounds(e.Graphics)
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), _
        Rectangle.Round(measureRect1))

        ' Draw rectangle for second measured range.
        Dim measureRect2 As RectangleF = _
        stringRegions(1).GetBounds(e.Graphics)
        e.Graphics.DrawRectangle(New Pen(Color.Blue, 1), _
        Rectangle.Round(measureRect2))
    End Sub
    ' </snippet135>


    ' Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font)
    ' <snippet136>
    Private Sub MeasureStringMin(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Measure string.
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        New PointF(0, 0))
    End Sub
    ' </snippet136>


    ' Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.PointF,System.Drawing.StringFormat)
    ' <snippet137>
    Private Sub MeasureStringPointFFormat(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Set point for upper-left corner of string.
        Dim x As Single = 50.0F
        Dim y As Single = 50.0F
        Dim ulCorner As New PointF(x, y)

        ' Set string format.
        Dim newStringFormat As New StringFormat
        newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Measure string.
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont, _
        ulCorner, newStringFormat)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), x, y, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        ulCorner, newStringFormat)
    End Sub
    ' </snippet137>


    ' Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF)
    ' <snippet138>
    Private Sub MeasureStringSizeF(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Set maximum layout size.
        Dim layoutSize As New SizeF(200.0F, 50.0F)

        ' Measure string.
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont, _
        layoutSize)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        New PointF(0, 0))
    End Sub
    ' </snippet138>


    ' Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF,System.Drawing.StringFormat)
    ' <snippet139>
    Private Sub MeasureStringSizeFFormat(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Set maximum layout size.
        Dim layoutSize As New SizeF(100.0F, 200.0F)

        ' Set string format.
        Dim newStringFormat As New StringFormat
        newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Measure string.
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont, _
        layoutSize, newStringFormat)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        New PointF(0, 0), newStringFormat)
    End Sub
    ' </snippet139>


    ' Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF,System.Drawing.StringFormat,System.Int32@,System.Int32@)
    ' <snippet140>
    Private Sub MeasureStringSizeFFormatInts(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Set maximum layout size.
        Dim layoutSize As New SizeF(100.0F, 200.0F)

        ' Set string format.
        Dim newStringFormat As New StringFormat
        newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Measure string.
        Dim charactersFitted As Integer
        Dim linesFilled As Integer
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont, _
        layoutSize, newStringFormat, charactersFitted, linesFilled)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        New PointF(0, 0), newStringFormat)

        ' Draw output parameters to screen.
        Dim outString As String = "chars " & charactersFitted & _
        ", lines " & linesFilled
        e.Graphics.DrawString(outString, stringFont, Brushes.Black, _
        New PointF(100, 0))
    End Sub
    ' </snippet140>


    ' Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Int32)
    ' <snippet141>
    Private Sub MeasureStringWidth(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Set maximum width of string.
        Dim stringWidth As Integer = 200

        ' Measure string.
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, _
        stringFont, stringWidth)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        New PointF(0, 0))
    End Sub
    ' </snippet141>


    ' Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Int32,System.Drawing.StringFormat)
    ' <snippet142>
    Private Sub MeasureStringWidthFormat(ByVal e As PaintEventArgs)

        ' Set up string.
        Dim measureString As String = "Measure String"
        Dim stringFont As New Font("Arial", 16)

        ' Set maximum width of string.
        Dim stringWidth As Integer = 100

        ' Set string format.
        Dim newStringFormat As New StringFormat
        newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical

        ' Measure string.
        Dim stringSize As New SizeF
        stringSize = e.Graphics.MeasureString(measureString, stringFont, _
        stringWidth, newStringFormat)

        ' Draw rectangle representing size of string.
        e.Graphics.DrawRectangle(New Pen(Color.Red, 1), 0.0F, 0.0F, _
        stringSize.Width, stringSize.Height)

        ' Draw string to screen.
        e.Graphics.DrawString(measureString, stringFont, Brushes.Black, _
        New PointF(0, 0), newStringFormat)
    End Sub
    ' </snippet142>


    ' Snippet for: M:System.Drawing.Graphics.MultiplyTransform(System.Drawing.Drawing2D.Matrix)
    ' <snippet143>
    Private Sub MultiplyTransformMatrix(ByVal e As PaintEventArgs)

        ' Create transform matrix.
        Dim transformMatrix As New Matrix

        ' Translate matrix, prepending translation vector.
        transformMatrix.Translate(200.0F, 100.0F)

        ' Rotate transformation matrix of graphics object,

        ' prepending rotation matrix.
        e.Graphics.RotateTransform(30.0F)

        ' Multiply (prepend to) transformation matrix of

        ' graphics object to translate graphics transformation.
        e.Graphics.MultiplyTransform(transformMatrix)

        ' Draw rotated, translated ellipse.
        e.Graphics.DrawEllipse(New Pen(Color.Blue, 3), -80, -40, 160, 80)
    End Sub
    ' </snippet143>


    ' Snippet for: M:System.Drawing.Graphics.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet144>
    Private Sub MultiplyTransformMatrixOrder(ByVal e As PaintEventArgs)

        ' Create transform matrix.
        Dim transformMatrix As New Matrix

        ' Translate matrix, prepending translation vector.
        transformMatrix.Translate(200.0F, 100.0F)

        ' Rotate transformation matrix of graphics object,

        ' prepending rotation matrix.
        e.Graphics.RotateTransform(30.0F)

        ' Multiply (append to) transformation matrix of

        ' graphics object to translate graphics transformation.
        e.Graphics.MultiplyTransform(transformMatrix, MatrixOrder.Append)

        ' Draw rotated, translated ellipse.
        e.Graphics.DrawEllipse(New Pen(Color.Blue, 3), -80, -40, 160, 80)
    End Sub
    ' </snippet144>


    ' Snippet for: M:System.Drawing.Graphics.ReleaseHdc(System.IntPtr)
    ' <snippet145>
    <System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
    Private Shared Function Rectangle2(ByVal hdc As IntPtr, _
    ByVal ulCornerX As Integer, ByVal ulCornerY As Integer, ByVal lrCornerX As Integer, _
    ByVal lrCornerY As Integer) As Boolean
    End Function

    <System.Security.Permissions.SecurityPermission( _
    System.Security.Permissions.SecurityAction.LinkDemand, Flags:= _
    System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Private Sub GetHdcForGDI2(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim redPen As New Pen(Color.Red, 1)

        ' Draw rectangle with GDI+.
        e.Graphics.DrawRectangle(redPen, 10, 10, 100, 50)

        ' Get handle to device context.
        Dim hdc As IntPtr = e.Graphics.GetHdc()

        ' Draw rectangle with GDI using default pen.
        Rectangle2(hdc, 10, 70, 110, 120)

        ' Release handle to device context.
        e.Graphics.ReleaseHdc(hdc)
    End Sub
    ' </snippet145>


    ' Snippet for: M:System.Drawing.Graphics.ResetClip
    ' <snippet146>
    Private Sub IntersectClipRectangleF2(ByVal e As PaintEventArgs)

        ' Set clipping region.
        Dim clipRect As New Rectangle(0, 0, 200, 200)
        e.Graphics.SetClip(clipRect)

        ' Update clipping region to intersection of

        ' existing region with specified rectangle.
        Dim intersectRectF As New RectangleF(100.0F, 100.0F, 200.0F, 200.0F)
        e.Graphics.IntersectClip(intersectRectF)

        ' Fill rectangle to demonstrate effective clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        500, 500)

        ' Reset clipping region to infinite.
        e.Graphics.ResetClip()

        ' Draw clipRect and intersectRect to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Black), clipRect)
        e.Graphics.DrawRectangle(New Pen(Color.Red), _
        Rectangle.Round(intersectRectF))
    End Sub
    ' </snippet146>


    ' Snippet for: M:System.Drawing.Graphics.ResetTransform
    ' <snippet147>
    Private Sub SaveRestore1(ByVal e As PaintEventArgs)

        ' Translate transformation matrix.
        e.Graphics.TranslateTransform(100, 0)

        ' Save translated graphics state.
        Dim transState As GraphicsState = e.Graphics.Save()

        ' Reset transformation matrix to identity and fill rectangle.
        e.Graphics.ResetTransform()
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, 100, 100)

        ' Restore graphics state to translated state and fill second

        ' rectangle.
        e.Graphics.Restore(transState)
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        100, 100)
    End Sub
    ' </snippet147>


    ' Snippet for: M:System.Drawing.Graphics.Restore(System.Drawing.Drawing2D.GraphicsState)
    ' <snippet148>
    Private Sub SaveRestore2(ByVal e As PaintEventArgs)

        ' Translate transformation matrix.
        e.Graphics.TranslateTransform(100, 0)

        ' Save translated graphics state.
        Dim transState As GraphicsState = e.Graphics.Save()

        ' Reset transformation matrix to identity and fill rectangle.
        e.Graphics.ResetTransform()
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, 100, 100)

        ' Restore graphics state to translated state and fill second

        ' rectangle.
        e.Graphics.Restore(transState)
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        100, 100)
    End Sub
    ' </snippet148>


    ' Snippet for: M:System.Drawing.Graphics.RotateTransform(System.Single)
    ' <snippet149>
    Private Sub RotateTransformAngle(ByVal e As PaintEventArgs)

        ' Set world transform of graphics object to translate.
        e.Graphics.TranslateTransform(100.0F, 0.0F)

        ' Then to rotate, prepending rotation matrix.
        e.Graphics.RotateTransform(30.0F)

        ' Draw rotated, translated ellipse to screen.
        e.Graphics.DrawEllipse(New Pen(Color.Blue, 3), 0, 0, 200, 80)
    End Sub
    ' </snippet149>


    ' Snippet for: M:System.Drawing.Graphics.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet150>
    Private Sub RotateTransformAngleMatrixOrder(ByVal e As PaintEventArgs)

        ' Set world transform of graphics object to translate.
        e.Graphics.TranslateTransform(100.0F, 0.0F)

        ' Then to rotate, appending rotation matrix.
        e.Graphics.RotateTransform(30.0F, MatrixOrder.Append)

        ' Draw translated, rotated ellipse to screen.
        e.Graphics.DrawEllipse(New Pen(Color.Blue, 3), 0, 0, 200, 80)
    End Sub
    ' </snippet150>


    ' Snippet for: M:System.Drawing.Graphics.Save
    ' <snippet151>
    Private Sub SaveRestore3(ByVal e As PaintEventArgs)

        ' Translate transformation matrix.
        e.Graphics.TranslateTransform(100, 0)

        ' Save translated graphics state.
        Dim transState As GraphicsState = e.Graphics.Save()

        ' Reset transformation matrix to identity and fill rectangle.
        e.Graphics.ResetTransform()
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, 100, 100)

        ' Restore graphics state to translated state and fill second

        ' rectangle.
        e.Graphics.Restore(transState)
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        100, 100)
    End Sub
    ' </snippet151>


    ' Snippet for: M:System.Drawing.Graphics.ScaleTransform(System.Single,System.Single)
    ' <snippet152>
    Private Sub ScaleTransformFloat(ByVal e As PaintEventArgs)

        ' Set world transform of graphics object to rotate.
        e.Graphics.RotateTransform(30.0F)

        ' Then to scale, prepending to world transform.
        e.Graphics.ScaleTransform(3.0F, 1.0F)

        ' Draw scaled, rotated rectangle to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Blue, 3), 50, 0, 100, 40)
    End Sub
    ' </snippet152>


    ' Snippet for: M:System.Drawing.Graphics.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet153>
    Private Sub ScaleTransformFloatMatrixOrder(ByVal e As PaintEventArgs)

        ' Set world transform of graphics object to rotate.
        e.Graphics.RotateTransform(30.0F)

        ' Then to scale, appending to world transform.
        e.Graphics.ScaleTransform(3.0F, 1.0F, MatrixOrder.Append)

        ' Draw rotated, scaled rectangle to screen.
        e.Graphics.DrawRectangle(New Pen(Color.Blue, 3), 50, 0, 100, 40)
    End Sub
    ' </snippet153>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Drawing2D.GraphicsPath)
    ' <snippet154>
    Private Sub SetClipPath(ByVal e As PaintEventArgs)

        ' Create graphics path.
        Dim clipPath As New GraphicsPath
        clipPath.AddEllipse(0, 0, 200, 100)

        ' Set clipping region to path.
        e.Graphics.SetClip(clipPath)

        ' Fill rectangle to demonstrate clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet154>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Drawing2D.GraphicsPath,System.Drawing.Drawing2D.CombineMode)
    ' <snippet155>
    Private Sub SetClipPathCombine(ByVal e As PaintEventArgs)

        ' Create graphics path.
        Dim clipPath As New GraphicsPath
        clipPath.AddEllipse(0, 0, 200, 100)

        ' Set clipping region to path.
        e.Graphics.SetClip(clipPath, CombineMode.Replace)

        ' Fill rectangle to demonstrate clipping region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet155>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Graphics)
    ' <snippet156>
    Private Sub SetClipGraphics(ByVal e As PaintEventArgs)

        ' Create temporary graphics object and set its clipping region.
        Dim newGraphics As Graphics = Me.CreateGraphics()
        newGraphics.SetClip(New Rectangle(0, 0, 100, 100))

        ' Update clipping region of graphics to clipping region of new

        ' graphics.
        e.Graphics.SetClip(newGraphics)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)

        ' Release new graphics.
        newGraphics.Dispose()
    End Sub
    ' </snippet156>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Graphics,System.Drawing.Drawing2D.CombineMode)
    ' <snippet157>
    Private Sub SetClipGraphicsCombine(ByVal e As PaintEventArgs)

        ' Create temporary graphics object and set its clipping region.
        Dim newGraphics As Graphics = Me.CreateGraphics()
        newGraphics.SetClip(New Rectangle(0, 0, 100, 100))

        ' Update clipping region of graphics to clipping region of new

        ' graphics.
        e.Graphics.SetClip(newGraphics, CombineMode.Replace)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)

        ' Release new graphics.
        newGraphics.Dispose()
    End Sub
    ' </snippet157>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Rectangle)
    ' <snippet158>
    Private Sub SetClipRectangle(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New Rectangle(0, 0, 100, 100)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet158>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Rectangle,System.Drawing.Drawing2D.CombineMode)
    ' <snippet159>
    Private Sub SetClipRectangleCombine(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New Rectangle(0, 0, 100, 100)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect, CombineMode.Replace)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet159>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.RectangleF)
    ' <snippet160>
    Private Sub SetClipRectangleF(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New RectangleF(0.0F, 0.0F, 100.0F, 100.0F)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet160>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.RectangleF,System.Drawing.Drawing2D.CombineMode)
    ' <snippet161>
    Private Sub SetClipRectangleFCombine(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New RectangleF(0.0F, 0.0F, 100.0F, 100.0F)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect, CombineMode.Replace)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet161>


    ' Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Region,System.Drawing.Drawing2D.CombineMode)
    ' <snippet162>
    Private Sub SetClipRegionCombine(ByVal e As PaintEventArgs)

        ' Create region for clipping.
        Dim clipRegion As New [Region](New Rectangle(0, 0, 100, 100))

        ' Set clipping region of graphics to region.
        e.Graphics.SetClip(clipRegion, CombineMode.Replace)

        ' Fill rectangle to demonstrate clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet162>


    ' Snippet for: M:System.Drawing.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Point[])
    ' <snippet163>
    Private Sub TransformPointsPoint(ByVal e As PaintEventArgs)

        ' Create array of two points.
        Dim points As Point() = {New Point(0, 0), New Point(100, 50)}

        ' Draw line connecting two untransformed points.
        e.Graphics.DrawLine(New Pen(Color.Blue, 3), points(0), points(1))

        ' Set world transformation of Graphics object to translate.
        e.Graphics.TranslateTransform(40, 30)

        ' Transform points in array from world to page coordinates.
        e.Graphics.TransformPoints(CoordinateSpace.Page, _
        CoordinateSpace.World, points)

        ' Reset world transformation.
        e.Graphics.ResetTransform()

        ' Draw line that connects transformed points.
        e.Graphics.DrawLine(New Pen(Color.Red, 3), points(0), points(1))
    End Sub
    ' </snippet163>


    ' Snippet for: M:System.Drawing.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.PointF[])
    ' <snippet164>
    Private Sub TransformPointsPointF(ByVal e As PaintEventArgs)

        ' Create array of two points.
        Dim points As PointF() = {New PointF(0.0F, 0.0F), New PointF(100.0F, _
        50.0F)}

        ' Draw line connecting two untransformed points.
        e.Graphics.DrawLine(New Pen(Color.Blue, 3), points(0), points(1))

        ' Set world transformation of Graphics object to translate.
        e.Graphics.TranslateTransform(40.0F, 30.0F)

        ' Transform points in array from world to page coordinates.
        e.Graphics.TransformPoints(CoordinateSpace.Page, _
        CoordinateSpace.World, points)

        ' Reset world transformation.
        e.Graphics.ResetTransform()

        ' Draw line that connects transformed points.
        e.Graphics.DrawLine(New Pen(Color.Red, 3), points(0), points(1))
    End Sub
    ' </snippet164>


    ' Snippet for: M:System.Drawing.Graphics.TranslateClip(System.Int32,System.Int32)
    ' <snippet165>
    Private Sub TranslateClipInt(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New Rectangle(0, 0, 100, 100)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect)

        ' Translate clipping region.
        Dim dx As Integer = 50
        Dim dy As Integer = 50
        e.Graphics.TranslateClip(dx, dy)

        ' Fill rectangle to demonstrate translated clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet165>


    ' Snippet for: M:System.Drawing.Graphics.TranslateClip(System.Single,System.Single)
    ' <snippet166>
    Private Sub TranslateClipFloat(ByVal e As PaintEventArgs)

        ' Create rectangle for clipping region.
        Dim clipRect As New RectangleF(0.0F, 0.0F, 100.0F, 100.0F)

        ' Set clipping region of graphics to rectangle.
        e.Graphics.SetClip(clipRect)

        ' Translate clipping region.
        Dim dx As Single = 50.0F
        Dim dy As Single = 50.0F
        e.Graphics.TranslateClip(dx, dy)

        ' Fill rectangle to demonstrate translated clip region.
        e.Graphics.FillRectangle(New SolidBrush(Color.Black), 0, 0, _
        500, 300)
    End Sub
    ' </snippet166>


    ' Snippet for: M:System.Drawing.Graphics.TranslateTransform(System.Single,System.Single)
    ' <snippet167>
    Private Sub TranslateTransformAngle(ByVal e As PaintEventArgs)

        ' Set world transform of graphics object to rotate.
        e.Graphics.RotateTransform(30.0F)

        ' Then to translate, prepending to world transform.
        e.Graphics.TranslateTransform(100.0F, 0.0F)

        ' Draw translated, rotated ellipse to screen.
        e.Graphics.DrawEllipse(New Pen(Color.Blue, 3), 0, 0, 200, 80)
    End Sub
    ' </snippet167>


    ' Snippet for: M:System.Drawing.Graphics.TranslateTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet168>
    Private Sub TranslateTransformAngleMatrixOrder(ByVal e As PaintEventArgs)

        ' Set world transform of graphics object to rotate.
        e.Graphics.RotateTransform(30.0F)

        ' Then to translate, appending to world transform.
        e.Graphics.TranslateTransform(100.0F, 0.0F, MatrixOrder.Append)

        ' Draw rotated, translated ellipse to screen.
        e.Graphics.DrawEllipse(New Pen(Color.Blue, 3), 0, 0, 200, 80)
    End Sub
    ' </snippet168>


    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
