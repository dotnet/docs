
Imports System
Imports System.IO
Imports System.Windows
Imports System.Windows.Ink
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Input


'/ <summary>
'/ Interaction logic for Window2.xaml
'/ </summary>
Namespace CustomInkControlSample

    Partial Public Class Window2
        Inherits Window '

        Private s As Stroke
        Private inkFileName As String

        Public Sub New()

            InitializeComponent()

            Dim points As StylusPointCollection = New StylusPointCollection()
            Dim p1 As StylusPoint = New StylusPoint(20, 10)
            Dim p2 As StylusPoint = New StylusPoint(60, 80)
            Dim p3 As StylusPoint = New StylusPoint(300, 150)

            points.Add(p1)
            points.Add(p2)
            points.Add(p3)

            s = New Stroke(points)
            inkFileName = "strokes.isf"

        End Sub 'New


        ' To use Loaded event put Loaded="OnLoad" attribute in root element of .xaml file.
        Private Sub OnLoad(ByVal sender As Object, ByVal e As RoutedEventArgs)

        End Sub 'OnLoad

        '<Snippet21>
        ' Copy the strokes from one InkCanvas to another InkCanvas.
        Private Sub CopyStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Dim strokes As StrokeCollection = inkCanvas1.Strokes.Clone()
            inkCanvas2.Strokes.Clear()
            inkCanvas2.Strokes.Add(strokes)

        End Sub
        '</Snippet21>

        Private Sub SwitchMode_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            If inkCanvas1.EditingMode = InkCanvasEditingMode.Ink Then

                inkCanvas1.EditingMode = InkCanvasEditingMode.Select
                inkCanvas2.EditingMode = InkCanvasEditingMode.Select
                switchMode.Content = "Write"

            Else

                inkCanvas1.EditingMode = InkCanvasEditingMode.Ink
                inkCanvas2.EditingMode = InkCanvasEditingMode.Ink
                switchMode.Content = "Select"

            End If

        End Sub 'SwitchMode_Click


        ' Remove the selected strokes from the InkCanvas.
        Private Sub DeleteStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            DeleteStroke(s)
        End Sub 'DeleteStrokes_Click

        '<Snippet7>
        ' Replace the selected strokes with other strokes.
        Private Sub ReplaceStrokes(ByVal strokes As StrokeCollection)

            Dim selectedStrokes As StrokeCollection = inkCanvas1.GetSelectedStrokes()

            If Not (selectedStrokes Is Nothing) Then
                inkCanvas1.Strokes.Replace(selectedStrokes, strokes)
            End If

        End Sub
        '</Snippet7>

        '<Snippet8>
        ' Put the specified stroke at the beginning of the inkCanvas1.Strokes
        Private Sub InsertStroke(ByVal aStroke As Stroke)

            If inkCanvas1.Strokes.Contains(aStroke) Then
                Return
            End If

            If inkCanvas1.Strokes.Count > 0 Then
                inkCanvas1.Strokes.Insert(0, aStroke)
            Else
                inkCanvas1.Strokes.Add(aStroke)
            End If

        End Sub
        '</Snippet8>

        '<Snippet9>
        ' Move all the strokes on the InkCanvas to the right.
        Private Sub MoveStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Dim moveMatrix As New Matrix(1, 0, 0, 1, 20, 0)

            inkCanvas1.Strokes.Transform(moveMatrix, False)

        End Sub
        '</Snippet9>

        '<Snippet10>
        Private Sub SaveStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Dim fs As FileStream = Nothing

            Try
                fs = New FileStream(inkFileName, FileMode.Create)
                inkCanvas1.Strokes.Save(fs)
            Finally
                If Not fs Is Nothing Then
                    fs.Close()
                End If
            End Try

        End Sub

        '</Snippet10>
        '<Snippet11>
        Private Sub LoadStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Dim fs As FileStream = Nothing

            If Not File.Exists(inkFileName) Then
                MessageBox.Show("The file you requested does not exist." & _
                    " Save the StrokeCollection before loading it.")
                Return
            End If

            Try
                fs = New FileStream(inkFileName, _
                    FileMode.Open, FileAccess.Read)
                Dim strokes As StrokeCollection = New StrokeCollection(fs)
                inkCanvas1.Strokes = strokes
            Finally
                If Not fs Is Nothing Then
                    fs.Close()
                End If
            End Try


        End Sub 'LoadStrokes_Click 
        '</Snippet11>

        '<Snippet12>
        Private timestamp As New Guid("12345678-9012-3456-7890-123456789012")

        ' Add a timestamp to the StrokeCollection.
        Private Sub AddTimestamp_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            inkCanvas1.Strokes.AddPropertyData(timestamp, DateTime.Now)

        End Sub

        ' Get the timestamp of the StrokeCollection.
        Private Sub GetTimestamp_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            If inkCanvas1.Strokes.ContainsPropertyData(timestamp) Then

                Dim savedDate As Object = inkCanvas1.Strokes.GetPropertyData(timestamp)

                If TypeOf savedDate Is DateTime Then
                    MessageBox.Show("This StrokeCollection's timestamp is " & _
                        CType(savedDate, DateTime).ToString())
                End If
            Else
                MessageBox.Show("The StrokeCollection does not have a timestamp.")
            End If

        End Sub
        '</Snippet12>

        '<Snippet22>
        ' Remove the specified stroke from the InkCanvas.
        Private Sub RemoveStroke(ByVal aStroke As Stroke)

            Dim index As Integer = inkCanvas1.Strokes.IndexOf(aStroke)

            If index <> -1 Then
                inkCanvas1.Strokes.RemoveAt(index)
            End If

        End Sub
        '</Snippet22>

        '<Snippet23>
        ' Remove the specified stroke from the InkCanvas.
        Private Sub DeleteStroke(ByVal aStroke As Stroke)

            If inkCanvas1.Strokes.Contains(aStroke) Then
                inkCanvas1.Strokes.Remove(aStroke)
            End If

        End Sub
        '</Snippet23>

        Private Sub ReplaceStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            Dim collection As New StrokeCollection()
            collection.Add(s)

            ReplaceStrokes(collection)

        End Sub 'ReplaceStrokes_Click


        Private Sub InsertStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            InsertStroke(s)

        End Sub 'InsertStrokes_Click


        Private Sub AddStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        End Sub 'AddStrokes_Click


        Private Sub AddStrokes()

            '<Snippet25>
            Dim strokes(inkCanvas1.Strokes.Count) As Stroke
            inkCanvas1.Strokes.CopyTo(strokes, 0)
            '</Snippet25>

        End Sub 'AddStrokes

        Private Sub MoveFirstStroke_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            '<Snippet26>
            If inkCanvas1.Strokes.Count > 0 Then
                Dim firstStroke As Stroke = inkCanvas1.Strokes(0)
                firstStroke.DrawingAttributes.Color = Colors.Green
            End If
            '</Snippet26>

        End Sub 'MoveFirstStroke_Click

        '<Snippet27>
        Private Sub GetPropertyIds(ByVal strokes As StrokeCollection)

            Dim propertyIds As Guid() = strokes.GetPropertyDataIds()

        End Sub 'GetPropertyIds
        '</Snippet27>

        '<Snippet28>
        Private Sub RemovePropertyId()

            If inkCanvas1.Strokes.ContainsPropertyData(timestamp) Then
                inkCanvas1.Strokes.RemovePropertyData(timestamp)
            End If

        End Sub
        '</Snippet28>

        '<Snippet30>
        ' Change the color of the ink that is on the InkCanvas.
        Private Sub ChangeColors_Click(ByVal sender As Object, _
            ByVal e As RoutedEventArgs)

            Dim s As Stroke
            For Each s In inkCanvas1.Strokes
                s.DrawingAttributes.Color = Colors.DarkMagenta
            Next
        End Sub
        '</Snippet30>

        '<Snippet20>
        Public Sub GetBounds()
            Dim bounds As Rect = inkCanvas1.Strokes.GetBounds()

            Dim boundsShape As Rectangle = New Rectangle()
            boundsShape.Width = bounds.Width
            boundsShape.Height = bounds.Height
            boundsShape.Stroke = Brushes.Red

            InkCanvas.SetTop(boundsShape, bounds.Top)
            InkCanvas.SetLeft(boundsShape, bounds.Left)

            inkCanvas1.Children.Add(boundsShape)
        End Sub
        '</Snippet20>
    End Class 'Window2 
End Namespace