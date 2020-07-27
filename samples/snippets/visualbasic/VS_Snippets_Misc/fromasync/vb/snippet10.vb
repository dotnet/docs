' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Collections.Generic
Imports System.Net
Imports System.Threading
Imports System.Threading.Tasks

Public Class SimpleWebExample
    Dim tcs As New TaskCompletionSource(Of String())
    Dim token As CancellationToken
    Dim results As New List(Of String)
    Dim m_lock As New Object()
    Dim count As Integer
    Dim addresses() As String
    Dim nameToSearch As String

    Public Function GetWordCountsSimplified(ByVal urls() As String, ByVal str As String,
                                            ByVal token As CancellationToken) As Task(Of String())
        addresses = urls
        nameToSearch = str

        Dim webClients(urls.Length - 1) As WebClient

        ' If the user cancels the CancellationToken, then we can use the
        ' WebClient's ability to cancel its own async operations.
        token.Register(Sub()
                           For Each wc As WebClient In webClients
                               If wc IsNot Nothing Then
                                   wc.CancelAsync()
                               End If
                           Next
                       End Sub)

        For i As Integer = 0 To urls.Length - 1
            webClients(i) = New WebClient()

            ' Specify the callback for the DownloadStringCompleted
            ' event that will be raised by this WebClient instance.
            AddHandler webClients(i).DownloadStringCompleted, AddressOf WebEventHandler

            Dim address As New Uri(urls(i))
            ' Pass the address, and also use it for the userToken
            ' to identify the page when the delegate is invoked.
            webClients(i).DownloadStringAsync(address, address)
        Next

        ' Return the underlying Task. The client code
        ' waits on the Result property, and handles exceptions
        ' in the try-catch block there.
        Return tcs.Task
    End Function

    Public Sub WebEventHandler(ByVal sender As Object, ByVal args As DownloadStringCompletedEventArgs)

        If args.Cancelled = True Then
            tcs.TrySetCanceled()
            Return
        ElseIf args.Error IsNot Nothing Then
            tcs.TrySetException(args.Error)
            Return
        Else
            ' Split the string into an array of words,
            ' then count the number of elements that match
            ' the search term.
            Dim words() As String = args.Result.Split(" "c)

            Dim name As String = nameToSearch.ToUpper()
            Dim nameCount = (From word In words.AsParallel()
                             Where word.ToUpper().Contains(name)
                             Select word).Count()

            ' Associate the results with the url, and add new string to the array that
            ' the underlying Task object will return in its Result property.
            SyncLock (m_lock)
                results.Add(String.Format("{0} has {1} instances of {2}", args.UserState, nameCount, nameToSearch))
                count = count + 1
                If (count = addresses.Length) Then
                    tcs.TrySetResult(results.ToArray())
                End If
            End SyncLock
        End If
    End Sub
End Class
' </snippet10>

Public Module Example
    Public Sub Main
        Dim urls() As String = {"http:\\www.microsoft.com",
                                 "http:\\www.google.com",
                                 "http:\\www.amazon.com",
                                 "http:\\www.adobe.com"}
        Dim searchTerm As String = "investor"
        Dim ex As New SimpleWebExample()
        Dim t = ex.GetWordCountsSimplified(urls, searchTerm, Nothing)
        t.Wait()
        For Each value In t.Result
            Console.WriteLine(value)
        Next

        Console.ReadLine()
    End Sub
End Module
