
'<snippet4>
' Add an Imports statement for SyndicationClient.
Imports Windows.Web.Syndication

' Add an Imports statement for the Tasks.
Imports System.Threading.Tasks

' The Blank Page item template is documented at http:'go.microsoft.com/fwlink/?LinkId=234238

Public NotInheritable Class MainPage
    Inherits Page

    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
    End Sub


    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)

        ResultsTextBox.Text = ""

        ' Disable the button until the operation is complete.
        StartButton.IsEnabled = False

        Dim client As Windows.Web.Syndication.SyndicationClient = New SyndicationClient()

        ' Force the SyndicationClient to download the information.
        client.BypassCacheOnRetrieve = True

        Dim uriList = CreateUriList()

        ' The following code avoids the use of implicit typing so that you 
        ' can see the types clearly.

        '<snippet6>
        Try
            '<snippet1>
            Dim feedsQuery As IEnumerable(Of Task(Of SyndicationFeed)) =
                From uri In uriList
                Select client.RetrieveFeedAsync(uri).AsTask()
            ' AsTask changes the returns from RetrieveFeedAsync into tasks.

            ' Run the query to start all the asynchronous processes.
            Dim blogFeedTasksList As List(Of Task(Of SyndicationFeed)) = feedsQuery.ToList()
            '</snippet1>

            Dim feed As SyndicationFeed

            ' Repeat the following until there are no tasks left:
            '    - Grab the first one that finishes.
            '    - Retrieve the results from the task (what the return statement 
            '      in RetrieveFeedAsync returns).
            '    - Remove the task from the list.
            '    - Display the results.
            '<snippet3>
            While blogFeedTasksList.Count > 0
                '<snippet5>
                Dim nextTask As Task(Of SyndicationFeed) = Await Task.WhenAny(blogFeedTasksList)
                '</snippet5>
                '<snippet2>
                feed = Await nextTask
                blogFeedTasksList.Remove(nextTask)
                '</snippet2>
                DisplayResults(feed)
            End While
            '</snippet3>

        Catch ex As Exception
            ResultsTextBox.Text =
                "Page could not be loaded." & vbCrLf & "Exception: " & ex.ToString()
        End Try
        '</snippet6>

        ' Reenable the button in case you want to run the operation again.
        StartButton.IsEnabled = True
    End Sub


    Function CreateUriList() As List(Of Uri)

        ' Create a list of URIs.
        Dim uriList = New List(Of Uri) From
        {
                New Uri("http://windowsteamblog.com/windows/b/developers/atom.aspx"),
                New Uri("http://windowsteamblog.com/windows/b/extremewindows/atom.aspx"),
                New Uri("http://windowsteamblog.com/windows/b/bloggingwindows/atom.aspx"),
                New Uri("http://windowsteamblog.com/windows/b/springboard/atom.aspx")
        }
        Return uriList
    End Function


    Sub DisplayResults(sf As SyndicationFeed)

        ' Title of the blog.
        ResultsTextBox.Text &= sf.Title.Text & vbCrLf

        ' Titles and dates for blog posts.
        For Each item As SyndicationItem In sf.Items

            ResultsTextBox.Text &= vbTab & item.Title.Text & ", " &
                                item.PublishedDate.ToString() & vbCrLf
        Next

        ResultsTextBox.Text &= vbCrLf
    End Sub
End Class
'</snippet4>