Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

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



    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.CopyData(System.Drawing.PointF[]@,System.Byte[]@,System.Int32,System.Int32)
    ' <snippet1>
    Public Sub CopyDataExample(ByVal e As PaintEventArgs)

        ' Create a graphics path.
        Dim myPath As New GraphicsPath

        ' Set up a points array.
        Dim myPoints As Point() = {New Point(20, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}

        ' Create a rectangle.
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add the points, rectangle, and an ellipse to the path.
        myPath.AddLines(myPoints)
        myPath.SetMarkers()
        myPath.AddRectangle(myRect)
        myPath.SetMarkers()
        myPath.AddEllipse(220, 220, 100, 100)

        ' Get the total number of points for the path, and arrays of the
        ' points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for listing the array of points on the left side
        ' of the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' List the set of points and types and types to the left side of
        ' the screen.
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() + ", " + _
            myPathPoints(i).Y.ToString() + ", " + _
            myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator for myPath and rewind it.
        Dim myPathIterator As New GraphicsPathIterator(myPath)
        myPathIterator.Rewind()

        ' Set up the arrays to receive the copied data.
        Dim points(myPathIterator.Count) As PointF
        Dim types(myPathIterator.Count) As Byte
        Dim myStartIndex As Integer
        Dim myEndIndex As Integer

        ' Increment the starting index to the second marker in the path.
        myPathIterator.NextMarker(myStartIndex, myEndIndex)
        myPathIterator.NextMarker(myStartIndex, myEndIndex)

        ' Copy all the points and types from the starting index to the
        ' ending index to the  points array and the types array
        ' respectively.
        Dim numPointsCopied As Integer = myPathIterator.CopyData(points, _
        types, myStartIndex, myEndIndex)

        ' List the copied points to the right side of the screen.
        j = 20
        Dim copiedStartIndex As Integer = 0
        For i = 0 To numPointsCopied - 1
            copiedStartIndex = myStartIndex + i
            e.Graphics.DrawString("Point: " + _
            copiedStartIndex.ToString() + ", Value: " + _
            points(i).ToString() + ", Type: " + types(i).ToString(), _
            myFont, myBrush, 200, j)
            j += 20
        Next i
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.Enumerate(System.Drawing.PointF[]@,System.Byte[]@)
    ' <snippet2>
    Public Sub EnumerateExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        Dim myPoints As Point() = {New Point(20, 20), _
            New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)
        myPath.AddLines(myPoints)
        myPath.AddRectangle(myRect)
        myPath.AddEllipse(220, 220, 100, 100)

        ' Get the total number of points for the path, and arrays of the
        ' points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for listing the array of points on the left side
        ' of the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' List the set of points and types and types to the left side of
        ' the screen.
        e.Graphics.DrawString("Original Data", myFont, myBrush, 20, j)
        j += 20
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() & ", " & _
            myPathPoints(i).Y.ToString() & ", " & _
            myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator for myPath.
        Dim myPathIterator As New GraphicsPathIterator(myPath)
        myPathIterator.Rewind()
        Dim points(myPathIterator.Count) As PointF
        Dim types(myPathIterator.Count) As Byte
        Dim numPoints As Integer = myPathIterator.Enumerate(points, types)

        ' Draw the set of copied points and types to the screen.
        j = 20
        e.Graphics.DrawString("Copied Data", myFont, myBrush, 200, j)
        j += 20
        For i = 0 To points.Length - 1
            e.Graphics.DrawString("Point: " & i & ", " & "Value: " & _
                points(i).ToString() & ", " & "Type: " & _
                types(i).ToString(), myFont, myBrush, 200, j)
            j += 20
        Next i
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.HasCurve
    ' <snippet3>
    Public Sub HasCurveExample(ByVal e As PaintEventArgs)
        Dim myPath As New GraphicsPath
        Dim myPoints As Point() = {New Point(20, 20), _
            New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)
        myPath.AddLines(myPoints)
        myPath.AddRectangle(myRect)
        myPath.AddEllipse(220, 220, 100, 100)

        ' Create a GraphicsPathIterator for myPath.
        Dim myPathIterator As New GraphicsPathIterator(myPath)
        Dim myHasCurve As Boolean = myPathIterator.HasCurve()
        MessageBox.Show(myHasCurve.ToString())
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextMarker(System.Drawing.Drawing2D.GraphicsPath)
    ' <snippet4>
    Public Sub NextMarkerExample2(ByVal e As PaintEventArgs)

        ' Create a graphics path.
        Dim myPath As New GraphicsPath

        ' Set up primitives to add to myPath.
        Dim myPoints As Point() = {New Point(20, 20), _
            New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add 3 lines, a rectangle, an ellipse, and 2 markers.
        myPath.AddLines(myPoints)
        myPath.SetMarkers()
        myPath.AddRectangle(myRect)
        myPath.SetMarkers()
        myPath.AddEllipse(220, 220, 100, 100)

        ' Get the total number of points for the path,
        ' and the arrays of the points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for drawing the array
        ' of points to the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the set of path points and types to the screen.
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() + _
                ", " + myPathPoints(i).Y.ToString() + ", " + _
                myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator.
        Dim myPathIterator As New GraphicsPathIterator(myPath)

        ' Rewind the iterator.
        myPathIterator.Rewind()

        ' Create a GraphicsPath section.
        Dim myPathSection As New GraphicsPath

        ' List the points contained in the first marker
        ' to the screen.
        Dim markerPoints As Integer
        markerPoints = myPathIterator.NextMarker(myPathSection)
        e.Graphics.DrawString("Marker: 1" + "  Num Points: " + _
            markerPoints.ToString(), myFont, myBrush, 200, 20)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextMarker(System.Int32@,System.Int32@)
    ' <snippet5>
    Public Sub NextMarkerExample(ByVal e As PaintEventArgs)

        ' Create the GraphicsPath.
        Dim myPath As New GraphicsPath
        Dim myPoints As Point() = {New Point(20, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add 3 lines, a rectangle, an ellipse, and 2 markers.
        myPath.AddLines(myPoints)
        myPath.SetMarkers()
        myPath.AddRectangle(myRect)
        myPath.SetMarkers()
        myPath.AddEllipse(220, 220, 100, 100)

        ' Get the total number of points for the path,
        ' and the arrays of the points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for drawing the array of points to the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the set of path points and types to the screen.
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() + ", " + _
                myPathPoints(i).Y.ToString() + ", " + _
                myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator.
        Dim myPathIterator As New GraphicsPathIterator(myPath)
        Dim myStartIndex As Integer
        Dim myEndIndex As Integer

        ' Rewind the Iterator.
        myPathIterator.Rewind()

        ' Draw the Markers and their start and end points to the screen.
        j = 20
        For i = 0 To 2
            myPathIterator.NextMarker(myStartIndex, myEndIndex)
            e.Graphics.DrawString("Marker " + i.ToString() + _
                ":  Start: " + myStartIndex.ToString() + "  End: " + _
                myEndIndex.ToString(), myFont, myBrush, 200, j)
            j += 20
        Next i

        ' Draw the total number of points to the screen.
        j += 20
        Dim myPathTotalPoints As Integer = myPathIterator.Count
        e.Graphics.DrawString("Total Points = " + _
            myPathTotalPoints.ToString(), myFont, myBrush, 200, j)
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextPathType(System.Byte@,System.Int32@,System.Int32@)
    ' <snippet6>
    Public Sub NextPathTypeExample(ByVal e As PaintEventArgs)

        ' Create the GraphicsPath.
        Dim myPath As New GraphicsPath
        Dim myPoints As Point() = {New Point(20, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add 3 lines, a rectangle, and an ellipse.
        myPath.AddLines(myPoints)
        myPath.AddRectangle(myRect)
        myPath.AddEllipse(220, 220, 100, 100)

        ' List all of the path points to the screen.
        ListPathPointsHelper(e, myPath, Nothing, 20, 1)

        ' Create a GraphicsPathIterator.
        Dim myPathIterator As New GraphicsPathIterator(myPath)

        ' Rewind the Iterator.
        myPathIterator.Rewind()

        ' Iterate the subpaths and types, and list the results
        ' to the screen.
        Dim j As Integer = 20
        Dim i As Integer
        Dim mySubPaths, subPathStartIndex, subPathEndIndex As Integer
        Dim IsClosed As [Boolean]
        Dim subPathPointType As Byte
        Dim pointTypeStartIndex, pointTypeEndIndex, _
        numPointsFound As Integer
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        j = 20
        For i = 0 To 2
            mySubPaths = myPathIterator.NextSubpath(subPathStartIndex, _
                subPathEndIndex, IsClosed)
            numPointsFound = myPathIterator.NextPathType(subPathPointType, _
                pointTypeStartIndex, pointTypeEndIndex)
            e.Graphics.DrawString("SubPath: " & i & "  Points Found: " & _
                numPointsFound.ToString() & "  Type of Points: " & _
            subPathPointType.ToString(), myFont, myBrush, 200, j)
            j += 20
        Next i

        ' List the total number of path points to the screen.
        ListPathPointsHelper(e, myPath, myPathIterator, 200, 2)
    End Sub

    ' This is a helper function used by NextPathTypeExample.
    Public Sub ListPathPointsHelper(ByVal e As PaintEventArgs, _
    ByVal myPath As GraphicsPath, ByVal myPathIterator As GraphicsPathIterator, _
    ByVal xOffset As Integer, ByVal listType As Integer)

        ' Get the total number of points for the path,
        ' and the arrays of the points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for drawing the points to the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)
        If listType = 1 Then
            ' List all the path points to the screen.

            ' Draw the set of path points and types to the screen.
            For i = 0 To myPathPointCount - 1
                e.Graphics.DrawString(myPathPoints(i).X.ToString() + ", " + _
                    myPathPoints(i).Y.ToString() + ", " + _
                myPathTypes(i).ToString(), myFont, myBrush, xOffset, j)
                j += 20
            Next i
        Else
            If listType = 2 Then
                ' Display the total number of path points.

                ' Draw the total number of points to the screen.
                Dim myPathTotalPoints As Integer = myPathIterator.Count
                e.Graphics.DrawString("Total Points = " + _
                    myPathTotalPoints.ToString(), myFont, myBrush, xOffset, _
                    100)
            Else
                e.Graphics.DrawString("Wrong or no list type argument.", _
                    myFont, myBrush, xOffset, 200)
            End If
        End If
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextSubpath(System.Drawing.Drawing2D.GraphicsPath,System.Boolean@)
    ' <snippet7>
    Public Sub NextSubpathExample2(ByVal e As PaintEventArgs)

        ' Create a graphics path.
        Dim myPath As New GraphicsPath

        ' Set up primitives to add to myPath.
        Dim myPoints As Point() = {New Point(20, 20), _
            New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add 3 lines, a rectangle, an ellipse, and 2 markers.
        myPath.AddLines(myPoints)
        myPath.SetMarkers()
        myPath.AddRectangle(myRect)
        myPath.SetMarkers()
        myPath.AddEllipse(220, 220, 100, 100)

        ' Get the total number of points for the path,

        ' and the arrays of the points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for drawing the array
        ' of points to the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the set of path points and types to the screen.
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() + _
                ", " + myPathPoints(i).Y.ToString() + ", " + _
                myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator for myPath.
        Dim myPathIterator As New GraphicsPathIterator(myPath)

        ' Rewind the iterator.
        myPathIterator.Rewind()

        ' Create the GraphicsPath section.
        Dim myPathSection As New GraphicsPath

        ' Draw the 3rd subpath and the number of points therein
        ' to the screen.
        Dim subpathPoints As Integer
        Dim IsClosed2 As Boolean

        ' Iterate to the third subpath.
        subpathPoints = myPathIterator.NextSubpath(myPathSection, _
            IsClosed2)
        subpathPoints = myPathIterator.NextSubpath(myPathSection, _
            IsClosed2)
        subpathPoints = myPathIterator.NextSubpath(myPathSection, _
            IsClosed2)

        ' Write the number of subpath points to the screen.
        e.Graphics.DrawString("Subpath: 3" + "   Num Points: " + _
        subpathPoints.ToString(), myFont, myBrush, 200, 20)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Drawing2D.GraphicsPathIterator.NextSubpath(System.Int32@,System.Int32@,System.Boolean@)
    ' <snippet8>
    Public Sub NextSubpathExample(ByVal e As PaintEventArgs)

        ' Create the GraphicsPath.
        Dim myPath As New GraphicsPath
        Dim myPoints As Point() = {New Point(20, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}
        Dim myRect As New Rectangle(120, 120, 100, 100)

        ' Add 3 lines, a rectangle, an ellipse, and 2 markers.
        myPath.AddLines(myPoints)
        myPath.AddRectangle(myRect)
        myPath.AddEllipse(220, 220, 100, 100)

        ' Get the total number of points for the path,
        ' and the arrays of the points and types.
        Dim myPathPointCount As Integer = myPath.PointCount
        Dim myPathPoints As PointF() = myPath.PathPoints
        Dim myPathTypes As Byte() = myPath.PathTypes

        ' Set up variables for drawing the array of points to the screen.
        Dim i As Integer
        Dim j As Single = 20
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the set of path points and types to the screen.
        For i = 0 To myPathPointCount - 1
            e.Graphics.DrawString(myPathPoints(i).X.ToString() + ", " + _
            myPathPoints(i).Y.ToString() + ", " + _
            myPathTypes(i).ToString(), myFont, myBrush, 20, j)
            j += 20
        Next i

        ' Create a GraphicsPathIterator.
        Dim myPathIterator As New GraphicsPathIterator(myPath)
        Dim myStartIndex As Integer
        Dim myEndIndex As Integer
        Dim myIsClosed As Boolean

        ' get the number of Subpaths.
        Dim numSubpaths As Integer = myPathIterator.NextSubpath(myPath, _
            myIsClosed)
        numSubpaths -= 1

        ' Rewind the Iterator.
        myPathIterator.Rewind()

        ' List the Subpaths to the screen.
        j = 20
        For i = 0 To numSubpaths - 1
            myPathIterator.NextSubpath(myStartIndex, myEndIndex, _
            myIsClosed)
            e.Graphics.DrawString("Subpath " + i.ToString() + _
                ":  Start: " + myStartIndex.ToString() + "  End: " + _
                myEndIndex.ToString() + "  IsClosed: " + _
                myIsClosed.ToString(), myFont, myBrush, 200, j)
            j += 20
        Next i

        ' Draw the total number of Subpaths to the screen.
        j += 20
        e.Graphics.DrawString("Number Subpaths = " + _
            numSubpaths.ToString(), myFont, myBrush, 200, j)
    End Sub
    ' </snippet8>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
