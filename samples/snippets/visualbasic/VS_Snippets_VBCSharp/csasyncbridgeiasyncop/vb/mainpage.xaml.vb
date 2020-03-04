
'<snippet10>
' Add an Imports statement for SyndicationClient.
Imports Windows.Web.Syndication


' The Blank Page item template is documented at http:'go.microsoft.com/fwlink/?LinkId=234238

Public NotInheritable Class MainPage
    Inherits Page

    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)

    End Sub


    ' The async modifier enables you to use await in the event handler.
    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)
        ResultsTextBox.Text = ""

        ' Disable the button until the operation is complete.
        StartButton.IsEnabled = False

        Dim client As Windows.Web.Syndication.SyndicationClient = New SyndicationClient()

        ' Force the SyndicationClient to download the information.
        client.BypassCacheOnRetrieve = True

        Dim uriList = CreateUriList()

        Try
            '<snippet7>
            Dim feedsQuery As IEnumerable(Of IAsyncOperationWithProgress(Of SyndicationFeed, 
                                                                            RetrievalProgress)) =
                                                            From uri In uriList
                                                            Select client.RetrieveFeedAsync(uri)
            '</snippet7>

            ' Run the query to start all the asynchronous processes.
            '<snippet8>
            Dim blogFeedOpsList As List(Of IAsyncOperationWithProgress(Of SyndicationFeed, 
                                                                       RetrievalProgress)) =
                                                           feedsQuery.ToList()
            '</snippet8>

            '<snippet9>
            Dim feed As SyndicationFeed
            For Each blogFeedOp In blogFeedOpsList
                ' The Await operator retrieves the final result (a SyndicationFeed instance)
                ' from each IAsyncOperation instance.
                feed = Await blogFeedOp
                DisplayResults(feed)
            Next
            '</snippet9>

        Catch ex As Exception
            ResultsTextBox.Text =
                "Page could not be loaded." & vbCrLf & "Exception: " & ex.ToString()
        End Try

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
'</snippet10>