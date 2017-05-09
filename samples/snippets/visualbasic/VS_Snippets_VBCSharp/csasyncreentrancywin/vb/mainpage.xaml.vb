
'<snippet3>
' Add the following Imports statements.
Imports System.Threading.Tasks
Imports System.Threading
Imports System.Net.Http

Public NotInheritable Class MainPage
    Inherits Page

    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
    End Sub


    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)
        ' This line is commented out to make the results clearer in the output.
        'ResultsTextBox.Text = ""

        Try
            Await AccessTheWebAsync()

        Catch ex As Exception
            ResultsTextBox.Text &= vbCrLf & "Downloads failed."

        End Try
    End Sub


    Private Async Function AccessTheWebAsync() As Task

        ' Declare an HttpClient object.
        Dim client = New HttpClient()

        ' Make a list of web addresses.
        Dim urlList As List(Of String) = SetUpURLList()

        Dim total = 0
        Dim position = 0

        For Each url In urlList
            ' GetByteArrayAsync returns a task. At completion, the task
            ' produces a byte array.
            Dim urlContents As Byte() = Await client.GetByteArrayAsync(url)

            position += 1
            DisplayResults(url, urlContents, position)

            ' Update the total.
            total += urlContents.Length
        Next

        ' Display the total count for all of the websites.
        ResultsTextBox.Text &=
            String.Format(vbCrLf & vbCrLf & "TOTAL bytes returned:  " & total & vbCrLf)
    End Function


    Private Function SetUpURLList() As List(Of String)
        Dim urls = New List(Of String) From
        {
            "http://msdn.microsoft.com/en-us/library/hh191443.aspx",
            "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
            "http://msdn.microsoft.com/en-us/library/jj155761.aspx",
            "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
            "http://msdn.microsoft.com/en-us/library/hh524395.aspx",
            "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
            "http://msdn.microsoft.com",
            "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
        }
        Return urls
    End Function


    Private Sub DisplayResults(url As String, content As Byte(), pos As Integer)
        ' Display the length of each website. The string format is designed
        ' to be used with a monospaced font, such as Lucida Console or
        ' Global Monospace.

        ' Strip off the "http:'".
        Dim displayURL = url.Replace("http://", "")
        ' Display position in the URL list, the URL, and the number of bytes.
        ResultsTextBox.Text &= String.Format(vbCrLf & "{0}. {1,-58} {2,8}", pos, displayURL, content.Length)
    End Sub
End Class
'</snippet3>

' Output if you choose the Start button just once:

'1. msdn.microsoft.com/en-us/library/hh191443.aspx                86075
'2. msdn.microsoft.com/en-us/library/aa578028.aspx               205273
'3. msdn.microsoft.com/en-us/library/jj155761.aspx                29019
'4. msdn.microsoft.com/en-us/library/hh290140.aspx               117152
'5. msdn.microsoft.com/en-us/library/hh524395.aspx                68959
'6. msdn.microsoft.com/en-us/library/ms404677.aspx               197325
'7. msdn.microsoft.com                                            43133
'8. msdn.microsoft.com/en-us/library/ff730837.aspx               146159

'TOTAL bytes returned:  893095


' Sample output for multiple starts:

'1. msdn.microsoft.com/en-us/library/hh191443.aspx                83732
'2. msdn.microsoft.com/en-us/library/aa578028.aspx               205273
'3. msdn.microsoft.com/en-us/library/jj155761.aspx                29793
'1. msdn.microsoft.com/en-us/library/hh191443.aspx                83732
'4. msdn.microsoft.com/en-us/library/hh290140.aspx               117151
'2. msdn.microsoft.com/en-us/library/aa578028.aspx               205273
'5. msdn.microsoft.com/en-us/library/hh524395.aspx                68959
'3. msdn.microsoft.com/en-us/library/jj155761.aspx                29019
'6. msdn.microsoft.com/en-us/library/ms404677.aspx               197325
'7. msdn.microsoft.com                                            43133
'8. msdn.microsoft.com/en-us/library/ff730837.aspx               146159

'TOTAL bytes returned:  891525

'1. msdn.microsoft.com/en-us/library/hh191443.aspx                83732
'4. msdn.microsoft.com/en-us/library/hh290140.aspx               117152
'5. msdn.microsoft.com/en-us/library/hh524395.aspx                68959
'6. msdn.microsoft.com/en-us/library/ms404677.aspx               197325
'2. msdn.microsoft.com/en-us/library/aa578028.aspx               209598
'3. msdn.microsoft.com/en-us/library/jj155761.aspx                29019
'4. msdn.microsoft.com/en-us/library/hh290140.aspx               117152
'7. msdn.microsoft.com                                            43133
'5. msdn.microsoft.com/en-us/library/hh524395.aspx                68959
'6. msdn.microsoft.com/en-us/library/ms404677.aspx               197325
'7. msdn.microsoft.com                                            43133
'8. msdn.microsoft.com/en-us/library/ff730837.aspx               146159

'TOTAL bytes returned:  890752

'8. msdn.microsoft.com/en-us/library/ff730837.aspx               146159

'TOTAL bytes returned:  895077

