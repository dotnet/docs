
'<Snippet3>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Ink


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Partial Class Window1
    Inherits Window '

    Private authorGuid As New Guid("12345678-9012-3456-7890-123456789012")
    Private teachersDA As New DrawingAttributes()
    Private studentsDA As New DrawingAttributes()
    Private teacher As String = "teacher"
    Private student As String = "student"
    Private useStudentPen As Boolean = False


    Public Sub New()
        InitializeComponent()

        teachersDA.Color = Colors.Red
        teachersDA.Width = 5
        teachersDA.Height = 5
        teachersDA.AddPropertyData(authorGuid, teacher)

        studentsDA.Color = Colors.Blue
        studentsDA.Width = 5
        studentsDA.Height = 5
        studentsDA.AddPropertyData(authorGuid, student)

        inkCanvas1.DefaultDrawingAttributes = teachersDA

    End Sub 'New


    ' Switch between using the 'pen' DrawingAttributes and the 
    ' 'highlighter' DrawingAttributes.
    Private Sub switchAuthor_click(ByVal sender As [Object], ByVal e As RoutedEventArgs)
        useStudentPen = Not useStudentPen

        If useStudentPen Then
            switchAuthor.Content = "Use teacher's pen"
            inkCanvas1.DefaultDrawingAttributes = studentsDA
        Else
            switchAuthor.Content = "Use student's pen"
            inkCanvas1.DefaultDrawingAttributes = teachersDA
        End If

    End Sub 'switchAuthor_click


    ' Change the color of the ink that on the InkCanvas that used the pen.
    Private Sub changeColor_click(ByVal sender As [Object], ByVal e As RoutedEventArgs)
        Dim s As Stroke
        For Each s In inkCanvas1.Strokes
            If s.DrawingAttributes.ContainsPropertyData(authorGuid) Then
                Dim data As Object = s.DrawingAttributes.GetPropertyData(authorGuid)

                If TypeOf data Is String AndAlso CStr(data) = teacher Then
                    s.DrawingAttributes.Color = Colors.Black
                End If
                If TypeOf data Is String AndAlso CStr(data) = student Then
                    s.DrawingAttributes.Color = Colors.Green
                End If
            End If
        Next s

    End Sub 'changeColor_click
End Class 'Window1 
'</Snippet3>


Class CodeSnippet
    Private inkCanvas1 As InkCanvas
    '<Snippet1>
    Private timestamp As New Guid("12345678-9012-3456-7890-123456789012")
    
    
    ' Add a timestamp to the StrokeCollection.
    Private Sub AddTimestamp() 
        
        inkCanvas1.Strokes.AddPropertyData(timestamp, DateTime.Now)
    
    End Sub 'AddTimestamp
    
    
    ' Get the timestamp of the StrokeCollection.
    Private Sub GetTimestamp() 
        
        If inkCanvas1.Strokes.ContainsPropertyData(timestamp) Then
            Dim [date] As Object = inkCanvas1.Strokes.GetPropertyData(timestamp)
            
            If TypeOf [date] Is DateTime Then
                MessageBox.Show("This StrokeCollection's timestamp is " + CType([date], DateTime).ToString())
            End If
        Else
            MessageBox.Show("The StrokeCollection does not have a timestamp.")
        End If
    
    End Sub 'GetTimestamp
    '</Snippet1>
End Class 'CodeSnippet
