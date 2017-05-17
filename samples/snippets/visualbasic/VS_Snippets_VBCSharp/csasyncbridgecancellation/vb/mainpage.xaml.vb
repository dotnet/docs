
'<snippet1>
' Add an Imports statement for SyndicationClient.
Imports Windows.Web.Syndication
' Add an Imports statement for Tasks.
Imports System.Threading.Tasks
' Add an Imports statement for CancellationToken.
Imports System.Threading


'<snippet3>
Public NotInheritable Class MainPage
    Inherits Page

    ' ***Declare a System.Threading.CancellationTokenSource.
    Dim cts As CancellationTokenSource

    '</snippet3>
    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)
        ResultsTextBox.Text = ""
        ' Prevent unexpected reentrance.
        StartButton.IsEnabled = False

        ' ***Instantiate the CancellationTokenSource.
        '<snippet5>
        cts = New CancellationTokenSource()
        '</snippet5>

        '<snippet6>
        Try
            ' ***Send a token to carry the message if cancellation is requested.
            Await DownloadBlogsAsync(cts.Token)

            ' ***Check for cancellations.
        Catch op As OperationCanceledException
            ' In practice, this catch block often is empty. It is used to absorb
            ' the exception,
            ResultsTextBox.Text &= vbCrLf & "Cancellation exception bubbles up to the caller."

            ' Check for other exceptions.
        Catch ex As Exception
            ResultsTextBox.Text =
                "Page could not be loaded." & vbCrLf & "Exception: " & ex.ToString()
        End Try
        '</snippet6>

        ' ***Set the CancellationTokenSource to null when the work is complete.
        cts = Nothing

        ' In case you want to try again.
        StartButton.IsEnabled = True
    End Sub


    ' Provide a parameter for the CancellationToken.
    '<snippet2>
    Async Function DownloadBlogsAsync(ct As CancellationToken) As Task
        Dim client As Windows.Web.Syndication.SyndicationClient = New SyndicationClient()

        Dim uriList = CreateUriList()

        ' Force the SyndicationClient to download the information.
        client.BypassCacheOnRetrieve = True


        ' The following code avoids the use of implicit typing (var) so that you 
        ' can identify the types clearly.

        For Each uri In uriList
            ' ***These three lines are combined in the single statement that follows them.
            'Dim feedOp As IAsyncOperationWithProgress(Of SyndicationFeed, RetrievalProgress) =
            '    client.RetrieveFeedAsync(uri)
            'Dim feedTask As Task(Of SyndicationFeed) = feedOp.AsTask(ct)
            'Dim feed As SyndicationFeed = Await feedTask

            ' ***You can combine the previous three steps in one expression.
            '<snippet7>
            Dim feed As SyndicationFeed = Await client.RetrieveFeedAsync(uri).AsTask(ct)
            '</snippet7>

            DisplayResults(feed, ct)
        Next
    End Function
    '</snippet2>


    '<snippet4>
    ' ***Add an event handler for the Cancel button.
    Private Sub cancelButton_Click(sender As Object, e As RoutedEventArgs)
        If cts IsNot Nothing Then
            cts.Cancel()
            ResultsTextBox.Text &= vbCrLf & "Downloads canceled by the Cancel button."
        End If
    End Sub
    '</snippet4>


    Function CreateUriList() As List(Of Uri)
        ' Create a list of URIs.
        Dim uriList = New List(Of Uri) From
                {
                    New Uri("http://windowsteamblog.com/windows/b/developers/atom.aspx"),
                    New Uri("http://windowsteamblog.com/windows/b/extremewindows/atom.aspx"),
                    New Uri("http://windowsteamblog.com/windows/b/bloggingwindows/atom.aspx"),
                    New Uri("http://windowsteamblog.com/windows/b/business/atom.aspx"),
                    New Uri("http://windowsteamblog.com/windows/b/windowsexperience/atom.aspx"),
                    New Uri("http://windowsteamblog.com/windows/b/windowssecurity/atom.aspx"),
                    New Uri("http://windowsteamblog.com/windows/b/windowshomeserver/atom.aspx"),
                    New Uri("http://windowsteamblog.com/windows/b/springboard/atom.aspx")
                }
        Return uriList
    End Function


    ' You can pass the CancellationToken to this method if you think you might use a
    ' cancellable API here in the future.
    Sub DisplayResults(sf As SyndicationFeed, ct As CancellationToken)
        ' Title of the blog.
        ResultsTextBox.Text &= sf.Title.Text & vbCrLf

        ' Titles and dates for the first three blog posts.
        For i As Integer = 0 To If(sf.Items.Count >= 3, 2, sf.Items.Count)
            ResultsTextBox.Text &= vbTab & sf.Items.ElementAt(i).Title.Text & ", " &
                    sf.Items.ElementAt(i).PublishedDate.ToString() & vbCrLf
        Next

        ResultsTextBox.Text &= vbCrLf
    End Sub
End Class
'</snippet1>

' Sample Output:
' Developing for Windows
'     New blog for Windows 8 app developers, 5/1/2012 2:33:02 PM -07:00
'     Trigger-Start Services Recipe, 3/24/2011 2:23:01 PM -07:00
'     Windows Restart and Recovery Recipe, 3/21/2011 2:13:24 PM -07:00

' Extreme Windows Blog
'     Samsung Series 9 27" PLS Display: Amazing Picture, 8/20/2012 2:41:48 PM -07:00
'     NVIDIA GeForce GTX 660 Ti Graphics Card: Affordable Graphics Powerhouse, 8/16/2012 10:56:19 AM -07:00
'     HP Z820 Workstation: Rising To the Challenge, 8/14/2012 1:57:01 PM -07:00

' Blogging Windows
'     Windows Upgrade Offer Registration Now Available, 8/20/2012 1:01:00 PM -07:00
'     Windows 8 has reached the RTM milestone, 8/1/2012 9:00:00 AM -07:00
'     Windows 8 will be available on…, 7/18/2012 1:09:00 PM -07:00

' Windows for your Business
'     What Windows 8 RTM Means for Businesses, 8/1/2012 9:01:00 AM -07:00
'     Higher-Ed Learning with Windows 8, 7/26/2012 12:03:00 AM -07:00
'     Second Public Beta of App-V 5.0 Now Available with Office Integration, 7/24/2012 10:07:26 AM -07:00

' Downloads canceled.

