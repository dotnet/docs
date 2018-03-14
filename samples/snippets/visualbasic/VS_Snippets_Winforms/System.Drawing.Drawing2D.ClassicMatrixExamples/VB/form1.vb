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


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.Multiply(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet1>
    Public Sub MultiplyExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Set up the matrices.
        Dim myMatrix1 As New Matrix(2.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0.0F)

        ' Scale.
        Dim myMatrix2 As New Matrix(0.0F, 1.0F, -1.0F, 0.0F, 0.0F, 0.0F)

        ' Rotate 90.
        Dim myMatrix3 As New Matrix(1.0F, 0.0F, 0.0F, 1.0F, 250.0F, 50.0F)

        ' Display the elements of the starting matrix.
        ListMatrixElementsHelper(e, myMatrix1, "Beginning Matrix", 6, 40)

        ' Multiply Matrix1 by Matrix 2.
        myMatrix1.Multiply(myMatrix2, MatrixOrder.Append)

        ' Display the result of the multiplication of Matrix1 and
        ' Matrix2.
        ListMatrixElementsHelper(e, myMatrix1, _
        "Matrix After 1st Multiplication", 6, 60)

        ' Multiply the result from the pervious multiplication by
        ' Matrix3.
        myMatrix1.Multiply(myMatrix3, MatrixOrder.Append)

        ' Display the result of the previous multiplication
        ' multiplied by Matrix3.
        ListMatrixElementsHelper1(e, myMatrix1, _
        "Matrix After 2nd Multiplication", 6, 80)

        ' Draw the rectangle prior to transformation.
        e.Graphics.DrawRectangle(myPen, 0, 0, 100, 100)
        e.Graphics.Transform = myMatrix1

        ' Draw the rectangle after transformation.
        e.Graphics.DrawRectangle(myPen2, 0, 0, 100, 100)
    End Sub

    ' A helper function to list the contents of a matrix.
    Public Sub ListMatrixElementsHelper1(ByVal e As PaintEventArgs, _
    ByVal matrix As Matrix, ByVal matrixName As String, ByVal numElements As Integer, _
    ByVal y As Integer)

        ' Set up variables for drawing the array

        ' of points to the screen.
        Dim i As Integer
        Dim x As Single = 20
        Dim j As Single = 200
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the matrix name to the screen.
        e.Graphics.DrawString(matrixName + ":  ", myFont, myBrush, x, y)

        ' Draw the set of path points and types to the screen.
        For i = 0 To numElements - 1
            e.Graphics.DrawString(matrix.Elements(i).ToString() + ", ", _
            myFont, myBrush, j, y)
            j += 30
        Next i
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.Reset
    ' <snippet2>
    Public Sub ResetExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)
        Dim myMatrix As New Matrix(5.0F, 0.0F, 0.0F, 3.0F, 0.0F, 0.0F)

        ListMatrixElementsHelper2(e, myMatrix, "Beginning Matrix", 6, 20)
        myMatrix.Reset()
        ListMatrixElementsHelper(e, myMatrix, "Matrix After Reset", 6, 40)

        ' Translate.
        myMatrix.Translate(50.0F, 40.0F)

        ListMatrixElementsHelper(e, myMatrix, "Matrix After Translation", _
            6, 60)
        e.Graphics.DrawRectangle(myPen, 0, 0, 100, 100)
        e.Graphics.Transform = myMatrix
        e.Graphics.DrawRectangle(myPen2, 0, 0, 100, 100)
    End Sub

    ' A helper function to list the contents of a matrix.
    Public Sub ListMatrixElementsHelper2(ByVal e As PaintEventArgs, _
    ByVal matrix As Matrix, ByVal matrixName As String, ByVal numElements As Integer, _
    ByVal y As Integer)

        ' Set up variables for drawing the array
        ' of points to the screen.
        Dim i As Integer
        Dim x As Single = 20
        Dim j As Single = 200
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the matrix name to the screen.
        e.Graphics.DrawString(matrixName + ":  ", myFont, myBrush, x, y)

        ' Draw the set of path points and types to the screen.
        For i = 0 To numElements - 1
            e.Graphics.DrawString(matrix.Elements(i).ToString() + ", ", _
            myFont, myBrush, j, y)
            j += 30
        Next i
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.Rotate(System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet3>
    Public Sub RotateExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Draw the rectangle to the screen before applying the transform.
        e.Graphics.DrawRectangle(myPen, 150, 50, 200, 100)

        ' Create a matrix and rotate it 45 degrees.
        Dim myMatrix As New Matrix
        myMatrix.Rotate(45, MatrixOrder.Append)

        ' Draw the rectangle to the screen again after applying the
        ' transform.
        e.Graphics.Transform = myMatrix
        e.Graphics.DrawRectangle(myPen2, 150, 50, 200, 100)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.RotateAt(System.Single,System.Drawing.PointF,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet4>
    Public Sub RotateAtExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)
        Dim rotatePoint As New PointF(150.0F, 50.0F)

        ' Draw the rectangle to the screen before applying the
        ' transform.
        e.Graphics.DrawRectangle(myPen, 150, 50, 200, 100)

        ' Create a matrix and rotate it 45 degrees.
        Dim myMatrix As New Matrix
        myMatrix.RotateAt(45, rotatePoint, MatrixOrder.Append)

        ' Draw the rectangle to the screen again after applying the
        ' transform.
        e.Graphics.Transform = myMatrix
        e.Graphics.DrawRectangle(myPen2, 150, 50, 200, 100)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.Scale(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet5>
    Public Sub ScaleExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Draw the rectangle to the screen before applying the
        ' transform.
        e.Graphics.DrawRectangle(myPen, 50, 50, 100, 100)

        ' Create a matrix and scale it.
        Dim myMatrix As New Matrix
        myMatrix.Scale(3, 2, MatrixOrder.Append)

        ' Draw the rectangle to the screen again after applying the
        ' transform.
        e.Graphics.Transform = myMatrix
        e.Graphics.DrawRectangle(myPen2, 50, 50, 100, 100)
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.Shear(System.Single,System.Single)
    ' <snippet6>
    Public Sub MatrixShearExample(ByVal e As PaintEventArgs)
        Dim myMatrix As New Matrix
        myMatrix.Shear(2, 0)
        e.Graphics.DrawRectangle(New Pen(Color.Green), 0, 0, 100, 50)
        e.Graphics.MultiplyTransform(myMatrix)
        e.Graphics.DrawRectangle(New Pen(Color.Red), 0, 0, 100, 50)
        e.Graphics.DrawEllipse(New Pen(Color.Blue), 0, 0, 100, 50)
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.TransformPoints(System.Drawing.Point[])
    ' <snippet7>
    Public Sub TransformPointsExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Create an array of points.
        Dim myArray As Point() = {New Point(20, 20), New Point(120, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}

        ' Draw the Points to the screen before applying the
        ' transform.
        e.Graphics.DrawLines(myPen, myArray)

        ' Create a matrix and scale it.
        Dim myMatrix As New Matrix
        myMatrix.Scale(3, 2, MatrixOrder.Append)
        myMatrix.TransformPoints(myArray)

        ' Draw the Points to the screen again after applying the
        ' transform.
        e.Graphics.DrawLines(myPen2, myArray)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.TransformVectors(System.Drawing.Point[])
    ' <snippet8>
    Public Sub TransformVectorsExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Create an array of points.
        Dim myArray As Point() = {New Point(20, 20), New Point(120, 20), _
        New Point(120, 120), New Point(20, 120), New Point(20, 20)}

        ' Draw the Points to the screen before applying the
        ' transform.
        e.Graphics.DrawLines(myPen, myArray)

        ' Create a matrix and scale it.
        Dim myMatrix As New Matrix
        myMatrix.Scale(3, 2, MatrixOrder.Append)
        myMatrix.Translate(100, 100, MatrixOrder.Append)
        ListMatrixElementsHelper(e, myMatrix, _
        "Scaled and Translated Matrix", 6, 20)
        myMatrix.TransformVectors(myArray)

        ' Draw the Points to the screen again after applying the
        ' transform.
        e.Graphics.DrawLines(myPen2, myArray)
    End Sub

    ' A helper function to list the contents of a matrix.
    Public Sub ListMatrixElementsHelper(ByVal e As PaintEventArgs, _
    ByVal matrix As Matrix, ByVal matrixName As String, ByVal numElements As Integer, _
    ByVal y As Integer)

        ' Set up variables for drawing the array
        ' of points to the screen.
        Dim i As Integer
        Dim x As Single = 20
        Dim j As Single = 200
        Dim myFont As New Font("Arial", 8)
        Dim myBrush As New SolidBrush(Color.Black)

        ' Draw the matrix name to the screen.
        e.Graphics.DrawString(matrixName + ":  ", myFont, myBrush, x, y)

        ' Draw the set of path points and types to the screen.
        For i = 0 To numElements - 1
            e.Graphics.DrawString(matrix.Elements(i).ToString() + ", ", _
            myFont, myBrush, j, y)
            j += 30
        Next i
    End Sub
    ' </snippet8>


    ' Snippet for: M:System.Drawing.Drawing2D.Matrix.Translate(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet9>
    Public Sub TranslateExample(ByVal e As PaintEventArgs)
        Dim myPen As New Pen(Color.Blue, 1)
        Dim myPen2 As New Pen(Color.Red, 1)

        ' Draw a rectangle to the screen before applying the
        ' transform.
        e.Graphics.DrawRectangle(myPen, 20, 20, 100, 50)

        ' Create a matrix and translate it.
        Dim myMatrix As New Matrix
        myMatrix.Translate(100, 100, MatrixOrder.Append)

        ' Draw the Points to the screen again after applying the
        ' transform.
        e.Graphics.Transform = myMatrix
        e.Graphics.DrawRectangle(myPen2, 20, 20, 100, 50)
    End Sub
    ' </snippet9>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
