Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.Text = "Form1"
    End Sub

#End Region


    ' Snippet for: M:System.Drawing.Region.Complement(System.Drawing.Drawing2D.GraphicsPath)
    ' <snippet1>
    Public Sub Complement_Path_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' Create the second rectangle and draw it to the screen in red.
        Dim complementRect As New Rectangle(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, complementRect)

        ' Create a graphics path and add the second rectangle to it.
        Dim complementPath As New GraphicsPath
        complementPath.AddRectangle(complementRect)

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the complement of myRegion when combined with
        ' complementPath.
        myRegion.Complement(complementPath)

        ' Fill the complement area with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Region.Complement(System.Drawing.RectangleF)
    ' <snippet2>
    Public Sub Complement_RectF_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' Create the second rectangle and draw it to the screen in red.
        Dim complementRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, _
        Rectangle.Round(complementRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the complement of the region combined with the second
        ' rectangle.
        myRegion.Complement(complementRect)

        ' Fill the complement area with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Region.Complement(System.Drawing.Region)
    ' <snippet3>
    Public Sub Complement_Region_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' Create the second rectangle and draw it to the screen in red.
        Dim complementRect As New Rectangle(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, complementRect)

        ' create a region from the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Create a complement region.
        Dim complementRegion As New [Region](complementRect)

        ' Get the complement of myRegion when combined with
        ' complementRegion.
        myRegion.Complement(complementRegion)

        ' Fill the complement area with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Region.Exclude(System.Drawing.RectangleF)
    ' <snippet4>
    Public Sub Exclude_RectF_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' create the second rectangle and draw it to the screen in red.
        Dim complementRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, _
        Rectangle.Round(complementRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the nonexcluded area of myRegion when combined with
        ' complementRect.
        myRegion.Exclude(complementRect)

        ' Fill the nonexcluded area of myRegion with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Region.GetBounds(System.Drawing.Graphics)
    ' <snippet5>
    Public Sub GetBoundsExample(ByVal e As PaintEventArgs)

        ' Create a GraphicsPath and add an ellipse to it.
        Dim myPath As New GraphicsPath
        Dim ellipseRect As New Rectangle(20, 20, 100, 100)
        myPath.AddEllipse(ellipseRect)

        ' Fill the path with blue and draw it to the screen.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillPath(myBrush, myPath)

        ' Create a region using the GraphicsPath.
        Dim myRegion As New [Region](myPath)

        ' Get the bounding rectangle for myRegion and draw it to the
        ' screen in Red.
        Dim boundsRect As RectangleF = myRegion.GetBounds(e.Graphics)
        e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(boundsRect))
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Region.GetRegionData
    ' <snippet6>
    Public Sub GetRegionDataExample(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the RegionData for this region.
        Dim myRegionData As RegionData = myRegion.GetRegionData()
        Dim myRegionDataLength As Integer = myRegionData.Data.Length
        DisplayRegionData(e, myRegionDataLength, myRegionData)
    End Sub

    ' Helper Function for GetRegionData.
    Public Sub DisplayRegionData(ByVal e As PaintEventArgs, ByVal len As Integer, _
    ByVal dat As RegionData)

        ' Display the result.
        Dim i As Integer
        Dim x As Single = 20
        Dim y As Single = 140
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        e.Graphics.DrawString("myRegionData = ", myFont, myBrush, _
        New PointF(x, y))
        y = 160
        For i = 0 To len - 1
            If x > 300 Then
                y += 20
                x = 20
            End If
            e.Graphics.DrawString(dat.Data(i).ToString(), myFont, _
            myBrush, New PointF(x, y))
            x += 30
        Next i
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Region.Intersect(System.Drawing.RectangleF)
    ' <snippet7>
    Public Sub Intersect_RectF_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' create the second rectangle and draw it to the screen in red.
        Dim complementRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, _
        Rectangle.Round(complementRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the area of intersection for myRegion when combined with
        ' complementRect.
        myRegion.Intersect(complementRect)

        ' Fill the intersection area of myRegion with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Region.IsVisible(System.Drawing.RectangleF)
    ' <snippet8>
    Public Sub IsVisible_RectF_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in blue.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Blue, regionRect)

        ' create the second rectangle and draw it to the screen in red.
        Dim myRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(myRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Determine if myRect is contained in the region.
        Dim contained As Boolean = myRegion.IsVisible(myRect)

        ' Display the result.
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        e.Graphics.DrawString("contained = " & contained.ToString(), _
        myFont, myBrush, New PointF(20, 140))
    End Sub
    ' </snippet8>


    ' Snippet for: M:System.Drawing.Region.Transform(System.Drawing.Drawing2D.Matrix)
    ' <snippet9>
    Public Sub TransformExample(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in blue.
        Dim regionRect As New Rectangle(100, 50, 100, 100)
        e.Graphics.DrawRectangle(Pens.Blue, regionRect)

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Create a transform matrix and set it to have a 45 degree
        ' rotation.
        Dim transformMatrix As New Matrix
        transformMatrix.RotateAt(45, New PointF(100, 50))

        ' Apply the transform to the region.
        myRegion.Transform(transformMatrix)

        ' Fill the transformed region with red and draw it to the
        ' screen in red.
        Dim myBrush As New SolidBrush(Color.Red)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet9>


    ' Snippet for: M:System.Drawing.Region.Translate(System.Int32,System.Int32)
    ' <snippet10>
    Public Sub TranslateExample(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in blue.
        Dim regionRect As New Rectangle(100, 50, 100, 100)
        e.Graphics.DrawRectangle(Pens.Blue, regionRect)

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Apply the translation to the region.
        myRegion.Translate(150, 100)

        ' Fill the transformed region with red and draw it to the
        ' screen in red.
        Dim myBrush As New SolidBrush(Color.Red)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet10>


    ' Snippet for: M:System.Drawing.Region.Union(System.Drawing.RectangleF)
    ' <snippet11>
    Public Sub Union_RectF_Example(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' create the second rectangle and draw it to the screen in red.
        Dim unionRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(unionRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the area of union for myRegion when combined with
        ' complementRect.
        myRegion.Union(unionRect)

        ' Fill the intersection area of myRegion with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet11>


    ' Snippet for: M:System.Drawing.Region.Xor(System.Drawing.RectangleF)
    ' <snippet12>
    Public Sub XorExample(ByVal e As PaintEventArgs)

        ' Create the first rectangle and draw it to the screen in black.
        Dim regionRect As New Rectangle(20, 20, 100, 100)
        e.Graphics.DrawRectangle(Pens.Black, regionRect)

        ' create the second rectangle and draw it to the screen in red.
        Dim xorRect As New RectangleF(90, 30, 100, 100)
        e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(xorRect))

        ' Create a region using the first rectangle.
        Dim myRegion As New [Region](regionRect)

        ' Get the area of overlap for myRegion when combined with
        ' complementRect.
        myRegion.Xor(xorRect)

        ' Fill the intersection area of myRegion with blue.
        Dim myBrush As New SolidBrush(Color.Blue)
        e.Graphics.FillRegion(myBrush, myRegion)
    End Sub
    ' </snippet12>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
