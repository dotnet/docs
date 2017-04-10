
Imports System
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Collections

Namespace CustomInkControlSample

    ' This control allows the user to input and select ink.  When the
    ' user selects ink, the lasso remains visible until they erase, or clip
    ' the selected strokes, or clear the selection.  When the control is
    ' in selection mode, strokes that are selected turn red.

    Public Class StrokeCollectionDemo
        Inherits InkSelector
        Private dateTimeGuid As New Guid("12345678-9012-3456-7890-123456789012")
        Private presenter As InkPresenter


        Public Sub New()

            presenter = Me.InkPresenter
            AddHandler presenter.Strokes.PropertyDataChanged, _
                AddressOf Strokes_PropertyDataChanged

        End Sub 'New

        '<Snippet29>
        Private Sub Strokes_PropertyDataChanged(ByVal sender As Object, _
            ByVal e As PropertyDataChangedEventArgs)

            If (e.PropertyGuid = dateTimeGuid) And (TypeOf e.NewValue Is DateTime) Then
                MessageBox.Show("The timestamp for the strokes is " & _
                    (CType(e.NewValue, DateTime)).ToString())
            End If

        End Sub
        '</Snippet29>

        ' Assign the current time to the StrokeCollection and save it.
        Public Sub SaveStrokes()

            If presenter.Strokes.ContainsPropertyData(dateTimeGuid) Then
                presenter.Strokes.RemovePropertyData(dateTimeGuid)
            End If

            presenter.Strokes.AddPropertyData(dateTimeGuid, DateTime.Now)

            Dim fs As New FileStream("strokes.isf", FileMode.Create)
            presenter.Strokes.Save(fs)
            fs.Close()

        End Sub 'SaveStrokes


        ' Open "strokes.isf" and get the time the StrokeCollection was saved.
        Public Sub LoadStrokes()

            If Not File.Exists("strokes.isf") Then
                MessageBox.Show("""strokes.isf"" does not exist." & _
                 " Save the StrokeCollection before loading it.")
                Return
            End If

            Dim isf(9999) As [Byte]
            Dim fs As New FileStream("strokes.isf", FileMode.Open, FileAccess.Read)

            Dim strokes As New StrokeCollection(fs)
            fs.Close()
            presenter.Strokes = strokes

            ' Get the time the StrokeCollection was saved.
            If presenter.Strokes.ContainsPropertyData(dateTimeGuid) Then
                Dim [date] As Object = presenter.Strokes.GetPropertyData(dateTimeGuid)

                If TypeOf [date] Is DateTime Then
                    MessageBox.Show("This StrokeCollection was saved on " + CType([date], DateTime).ToString())
                Else
                    MessageBox.Show("The property data is not a DateTime object.")
                End If
            End If

        End Sub 'LoadStrokes

        ' This snippet illustrates the Clip and Erase methods.
        ' It assumes that there is a Stroke called lasso, and an Inkpresenter called presenter.
        '<Snippet2>
        ' Erase the selected strokes.
        Public Overloads Sub EraseStrokes(ByVal lasso As Stroke)

            If lasso Is Nothing Then
                Return
            End If

            Dim strokePoints() As Point = CType(lasso.StylusPoints, Point())

            presenter.Strokes.Erase(strokePoints)

        End Sub 'EraseStrokes

        '</Snippet2>

        '<Snippet13>
        ' Clip the selected strokes.
        Public Overloads Sub ClipStrokes(ByVal lasso As Stroke)

            If lasso Is Nothing Then
                Return
            End If

            Dim strokePoints() As Point = CType(lasso.StylusPoints, Point())
            presenter.Strokes.Clip(strokePoints)

        End Sub 'ClipStrokes

        '</Snippet13>
        '<Snippet14>
        ' Erase the ink that intersects the lasso.
        Public Overloads Sub ErasePath(ByVal lasso As Stroke)

            If lasso Is Nothing Then
                Return
            End If

            Dim eraserTip As New EllipseStylusShape(5, 5, 0)
            Dim strokePoints() As Point = CType(lasso.StylusPoints, Point())

            presenter.Strokes.Erase(strokePoints, eraserTip)

        End Sub

        '</Snippet14>


        Public Sub CopyStrokes()

            CopyStrokeCollection(presenter.Strokes)

        End Sub 'CopyStrokes


        '<Snippet5>
        Public Sub CopyStrokeCollection(ByVal strokes As StrokeCollection)

            Dim strokesInMemory As New MemoryStream()
            strokes.Save(strokesInMemory)
            Dim dataObj As New DataObject(StrokeCollection.InkSerializedFormat, _
                        strokesInMemory)

            Clipboard.SetDataObject(dataObj, True)

        End Sub

        '</Snippet5>
        ' Remove the lasso stroke.
        Public Sub ClearSelection()
            If Not (Lasso Is Nothing) Then
                presenter.Strokes.Remove(Lasso)
                Lasso = Nothing
            End If

        End Sub 'ClearSelection


        '<Snippet15>
        ' Change the color of all the strokes at the specified position.
        Public Sub SelectStrokes(ByVal position As Point)

            Dim selected As StrokeCollection = presenter.Strokes.HitTest(position, 5)

            Dim s As Stroke
            For Each s In selected
                s.DrawingAttributes.Color = Colors.Purple
            Next s

        End Sub 'SelectStrokes 
        '</Snippet15>


        Public ReadOnly Property Count() As Integer

            Get
                Return presenter.Strokes.Count
            End Get

        End Property


        Public Sub ExtractStrokes()

            MessageBox.Show("StrokeCollection.Extract has been removed.")

        End Sub 'ExtractStrokes
        'if (lasso == null)
        '{
        '    return;
        '}
        '//presenter.Strokes.Extract(lasso.GetRenderingPoints());
        'lasso = null;

        Private Function ConvertToPointArray(ByVal stylusPointsCollection As StylusPointCollection) As Point()

            Dim strokePoints As ArrayList = New ArrayList()

            Dim p As StylusPoint
            For Each p In stylusPointsCollection
                strokePoints.Add(CType(p, Point))
            Next

            Dim pointArray() As Point
            pointArray = strokePoints.ToArray(GetType(Point))
            Return pointArray

        End Function

        Public Sub EraseStrokesHelper()

            EraseStrokes(Lasso)
            Lasso = Nothing

        End Sub 'EraseStrokes


        Public Sub EraseStrokesWithRect()
            '<Snippet34>
            Dim rect As Rect = New Rect(100, 100, 200, 200)
            presenter.Strokes.Erase(rect)
            '</Snippet34>
        End Sub

        Public Sub ClipStrokesWithRect()
            '<Snippet35>
            Dim rect As Rect = New Rect(100, 100, 200, 200)
            presenter.Strokes.Clip(rect)
            '</Snippet35>
        End Sub

        Public Sub RemoveStrokesFromRect()
            '<Snippet36>
            Dim rect As Rect = New Rect(100, 100, 200, 200)
            Dim strokes As StrokeCollection = presenter.Strokes.HitTest(rect, 50)

            presenter.Strokes.Remove(strokes)
            '</Snippet36>
        End Sub

        '<Snippet37>
        Private Sub HitTestWithEraser(ByVal points() As Point)
            Dim eraser As RectangleStylusShape = New RectangleStylusShape(3, 3, 0)

            Dim strokes As StrokeCollection = presenter.Strokes.HitTest(points, eraser)

            Dim s As Stroke
            For Each s In strokes
                s.DrawingAttributes.Color = Colors.Purple
            Next
        End Sub
        '</Snippet37>

        ' Clip the selected strokes.
        Public Sub ClipStrokesHelper()

            ClipStrokes(Lasso)
            Lasso = Nothing

        End Sub 'ClipStrokes


        ' Erase the ink that intersects the lasso.
        Public Sub ErasePathHelper()

            ErasePath(Lasso)
            Lasso = Nothing

        End Sub 'ErasePath


        '<Snippet16>
        ' Remove the strokes within the lasso from the InkPresenter
        Public Sub RemoveStrokes(ByVal lasso As Point())

            If lasso Is Nothing Then
                Return
            End If

            Dim strokes As StrokeCollection = _
                presenter.Strokes.HitTest(lasso, 80)

            presenter.Strokes.Remove(strokes)

        End Sub 'RemoveStrokes

        '</Snippet16>
        Public Sub RemoveStrokesHelper()

            RemoveStrokes(ConvertToPointArray(Lasso.StylusPoints))
            Lasso = Nothing

        End Sub 'RemoveStrokes

    End Class 'StrokeCollectionDemo 

End Namespace