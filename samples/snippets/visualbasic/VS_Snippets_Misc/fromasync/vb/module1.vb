Imports System.Collections.Generic
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Namespace specialNamespaceForOneMethodSignature
    Class Task(Of TResult)
        Public TValue As TResult
    End Class
    Class Dummy(Of TResult)
        '<snippet01>
        Public Function FromAsync(Of TArg1, TArg2, TArg3)(
                        ByVal beginMethod As Func(Of TArg1, TArg2, TArg3, AsyncCallback, Object, IAsyncResult),
                        ByVal endMethod As Func(Of IAsyncResult, TResult),
                        ByVal dataBuffer As TArg1,
                        ByVal byteOffsetToStartAt As TArg2,
                        ByVal maxBytesToRead As TArg3,
                        ByVal stateInfo As Object)
            '</snippet01>
            Return New Task(Of TResult)
        End Function


    End Class
End Namespace

Module Module1

    Class AsyncResult
        Public Sub New()

        End Sub
        '<snippet07>
        Shared Function ReturnTaskFromAsyncResult() As Task(Of String)
            Dim ar As IAsyncResult = DoSomethingAsynchronously()
            Dim t As Task(Of String) = Task(Of String).Factory.FromAsync(ar, Function(res) CStr(res.AsyncState))
            Return t
        End Function
        '</snippet07>

        Private Shared Function DoSomethingAsynchronously() As IAsyncResult
            Throw New NotImplementedException
        End Function

    End Class
    '<snippet08>
    Class WebDataDownLoader

        Dim tcs As New TaskCompletionSource(Of String())
        Dim nameToSearch As String
        Dim token As CancellationToken
        Dim results As New List(Of String)
        Dim m_lock As Object
        Dim count As Integer
        Dim addresses() As String

        Shared Sub Main()

            Dim downloader As New WebDataDownLoader()
            downloader.addresses = {"http://www.msnbc.com", "http://www.yahoo.com", _
                                         "http://www.nytimes.com", "http://www.washingtonpost.com", _
                                         "http://www.latimes.com", "http://www.newsday.com"}
            Dim cts As New CancellationTokenSource()

            ' Create a UI thread from which to cancel the entire operation
            Task.Factory.StartNew(Sub()
                                      Console.WriteLine("Press c to cancel")
                                      If Console.ReadKey().KeyChar = "c"c Then
                                          cts.Cancel()
                                      End If
                                  End Sub)

            ' Using a neutral search term that is sure to get some hits on English web sites.
            ' Please substitute your favorite search term.
            downloader.nameToSearch = "the"
            Dim webTask As Task(Of String()) = downloader.GetWordCounts(downloader.addresses, downloader.nameToSearch, cts.Token)

            ' Do some other work here unless the method has already completed.
            If (webTask.IsCompleted = False) Then
                ' Simulate some work
                Thread.SpinWait(5000000)
            End If

            Dim results As String() = Nothing
            Try
                results = webTask.Result
            Catch ae As AggregateException
                For Each ex As Exception In ae.InnerExceptions
                    If (TypeOf (ex) Is OperationCanceledException) Then
                        Dim oce As OperationCanceledException = CType(ex, OperationCanceledException)
                        If oce.CancellationToken = cts.Token Then
                            Console.WriteLine("Operation canceled by user.")
                        End If
                    Else
                        Console.WriteLine(ex.Message)
                    End If

                Next
            Finally
                cts.Dispose()
            End Try

            If (Not results Is Nothing) Then
                For Each item As String In results
                    Console.WriteLine(item)
                Next
            End If

            Console.WriteLine("Press any key to exit")
            Console.ReadKey()
        End Sub

        Public Function GetWordCounts(ByVal urls() As String, ByVal str As String, ByVal token As CancellationToken) As Task(Of String())

            Dim webClients() As WebClient
            ReDim webClients(urls.Length)
            m_lock = New Object()

            ' If the user cancels the CancellationToken, then we can use the
            ' WebClient's ability to cancel its own async operations.
            token.Register(Sub()
                               For Each wc As WebClient In webClients
                                   If Not wc Is Nothing Then
                                       wc.CancelAsync()
                                   End If
                               Next
                           End Sub)


            For i As Integer = 0 To urls.Length - 1
                webClients(i) = New WebClient()

                ' Specify the callback for the DownloadStringCompleted
                ' event that will be raised by this WebClient instance.
                AddHandler webClients(i).DownloadStringCompleted, AddressOf WebEventHandler

                Dim address As Uri = Nothing
                Try
                    address = New Uri(urls(i))
                    ' Pass the address, and also use it for the userToken 
                    ' to identify the page when the delegate is invoked.
                    webClients(i).DownloadStringAsync(address, address)
                Catch ex As UriFormatException
                    tcs.TrySetException(ex)
                    Return tcs.Task
                End Try

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
            ElseIf Not args.Error Is Nothing Then
                tcs.TrySetException(args.Error)
                Return
            Else
                ' Split the string into an array of words,
                ' then count the number of elements that match
                ' the search term.
                Dim words() As String = args.Result.Split(" "c)
                Dim NAME As String = nameToSearch.ToUpper()
                Dim nameCount = (From word In words.AsParallel()
                                 Where word.ToUpper().Contains(NAME)
                                 Select word).Count()

                ' Associate the results with the url, and add new string to the array that 
                ' the underlying Task object will return in its Result property.
                results.Add(String.Format("{0} has {1} instances of {2}", args.UserState, nameCount, nameToSearch))
            End If

            SyncLock (m_lock)
                count = count + 1
                If (count = addresses.Length) Then
                    tcs.TrySetResult(results.ToArray())
                End If
            End SyncLock
        End Sub
        '</snippet08>
    End Class


    '<snippet09>
    Class Calculator
        Public Function BeginCalculate(ByVal decimalPlaces As Integer, ByVal ac As AsyncCallback, ByVal state As Object) As IAsyncResult
            Console.WriteLine("Calling BeginCalculate on thread {0}", Thread.CurrentThread.ManagedThreadId)
            Dim myTask = Task(Of String).Factory.StartNew(Function(obj) Compute(decimalPlaces), state)
            myTask.ContinueWith(Sub(antecedent) ac(myTask))

        End Function
        Private Function Compute(ByVal decimalPlaces As Integer)
            Console.WriteLine("Calling compute on thread {0}", Thread.CurrentThread.ManagedThreadId)

            ' Simulating some heavy work.
            Thread.SpinWait(500000000)

            ' Actual implementation left as exercise for the reader.
            ' Several examples are available on the Web.
            Return "3.14159265358979323846264338327950288"
        End Function

        Public Function EndCalculate(ByVal ar As IAsyncResult) As String
            Console.WriteLine("Calling EndCalculate on thread {0}", Thread.CurrentThread.ManagedThreadId)
            Return CType(ar, Task(Of String)).Result
        End Function
    End Class

    Class CalculatorClient
        Shared decimalPlaces As Integer
        Shared Sub Main()
            Dim calc As New Calculator
            Dim places As Integer = 35
            Dim callback As New AsyncCallback(AddressOf PrintResult)
            Dim ar As IAsyncResult = calc.BeginCalculate(places, callback, calc)

            ' Do some work on this thread while the calculator is busy.
            Console.WriteLine("Working...")
            Thread.SpinWait(500000)
            Console.ReadLine()
        End Sub

        Public Shared Sub PrintResult(ByVal result As IAsyncResult)
            Dim c As Calculator = CType(result.AsyncState, Calculator)
            Dim piString As String = c.EndCalculate(result)
            Console.WriteLine("Calling PrintResult on thread {0}; result = {1}",
                       Thread.CurrentThread.ManagedThreadId, piString)
        End Sub

    End Class
    '</snippet09>

    Class FileStreamDemo
        Shared Sub Main()
            Dim fsd As New FileStreamDemo()
            fsd.ShowCallingFromAsync()
        End Sub

        '<snippet03>
        Const MAX_FILE_SIZE As Integer = 14000000
        Shared Function GetFileStringAsync(ByVal path As String) As Task(Of String)
            Dim fi As New FileInfo(path)
            Dim data(fi.Length - 1) As Byte

            Dim fs As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, data.Length, True)

            ' Task(Of Integer) returns the number of bytes read
            Dim myTask As Task(Of Integer) = Task(Of Integer).Factory.FromAsync(
                AddressOf fs.BeginRead, AddressOf fs.EndRead, data, 0, data.Length, Nothing)

            ' It is possible to do other work here while waiting
            ' for the antecedent task to complete.
            ' ...

            ' Add the continuation, which returns a Task<string>. 
            Return myTask.ContinueWith(Function(antecedent)
                                           fs.Close()
                                           If (antecedent.Result < 100) Then
                                               Return "Data is too small to bother with."
                                           End If
                                           ' If we did not receive the entire file, the end of the
                                           ' data buffer will contain garbage.
                                           If (antecedent.Result < data.Length) Then
                                               Array.Resize(data, antecedent.Result)
                                           End If

                                           ' Will be returned in the Result property of the Task<string>
                                           ' at some future point after the asynchronous file I/O operation completes.
                                           Return New UTF8Encoding().GetString(data)
                                       End Function)

        End Function
        '</snippet03>

        Public Sub ShowCallingFromAsync()
            Dim path As String = "\\docbuild2\public\Main\Logs\DllDiffReport\DllDiffReport_BetweenInBuildAndInPublicShare.html"
            '<snippet04>
            Dim myTask As Task(Of String) = GetFileStringAsync(path)

            ' Do some other work
            ' ...

            Try
                Console.WriteLine(myTask.Result.Substring(0, 500))
            Catch ex As AggregateException
                Console.WriteLine(ex.InnerException.Message)
            End Try
            '</snippet04>

            Console.WriteLine("Press Enter to exit.")
            Console.ReadLine()
        End Sub

        '<snippet05>
        Public Function GetFileStringAsync2(ByVal path As String) As Task(Of String)
            Dim fi = New FileInfo(path)
            Dim data(fi.Length - 1) As Byte
            Dim state As New MyCustomState()

            Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, data.Length, True)
            ' We still pass null for the last parameter because
            ' the state variable is visible to the continuation delegate.
            Dim myTask As Task(Of Integer) = Task(Of Integer).Factory.FromAsync(
                    AddressOf fs.BeginRead, AddressOf fs.EndRead, data, 0, data.Length, Nothing)

            Return myTask.ContinueWith(Function(antecedent)
                                           fs.Close()
                                           ' Capture custom state data directly in the user delegate.
                                           ' No need to pass it through the FromAsync method.
                                           If (state.StateData.Contains("New York, New York")) Then
                                               Return "Start spreading the news!"
                                           End If

                                           ' If we did not receive the entire file, the end of the
                                           ' data buffer will contain garbage.
                                           If (antecedent.Result < data.Length) Then
                                               Array.Resize(data, antecedent.Result)
                                           End If
                                           '/ Will be returned in the Result property of the Task<string>
                                           '/ at some future point after the asynchronous file I/O operation completes.
                                           Return New UTF8Encoding().GetString(data)
                                       End Function)

        End Function
        '</snippet05>


        '<snippet06>
        Public Function GetMultiFileData(ByVal filesToRead As String()) As Task(Of String)
            Dim fs As FileStream
            Dim tasks(filesToRead.Length - 1) As Task(Of String)
            Dim fileData() As Byte = Nothing
            For i As Integer = 0 To filesToRead.Length
                fileData(&H1000) = New Byte()
                fs = New FileStream(filesToRead(i), FileMode.Open, FileAccess.Read, FileShare.Read, fileData.Length, True)

                ' By adding the continuation here, the 
                ' Result of each task will be a string.
                tasks(i) = Task(Of Integer).Factory.FromAsync(AddressOf fs.BeginRead,
                                                              AddressOf fs.EndRead,
                                                              fileData,
                                                              0,
                                                              fileData.Length,
                                                              Nothing).
                                                          ContinueWith(Function(antecedent)
                                                                           fs.Close()
                                                                           'If we did not receive the entire file, the end of the
                                                                           ' data buffer will contain garbage.
                                                                           If (antecedent.Result < fileData.Length) Then
                                                                               ReDim Preserve fileData(antecedent.Result)
                                                                           End If

                                                                           'Will be returned in the Result property of the Task<string>
                                                                           ' at some future point after the asynchronous file I/O operation completes.
                                                                           Return New UTF8Encoding().GetString(fileData)
                                                                       End Function)
            Next

            Return Task(Of String).Factory.ContinueWhenAll(tasks, Function(data)

                                                                      ' Propagate all exceptions and mark all faulted tasks as observed.
                                                                      Task.WaitAll(data)

                                                                      ' Combine the results from all tasks.
                                                                      Dim sb As New StringBuilder()
                                                                      For Each t As Task(Of String) In data
                                                                          sb.Append(t.Result)
                                                                      Next
                                                                      ' Final result to be returned eventually on the calling thread.
                                                                      Return sb.ToString()
                                                                  End Function)
        End Function
        '</snippet06>

        Class MyCustomState
            Public StateData As String
            Public Sub New()
                StateData = "Hello"
            End Sub
        End Class


    End Class


End Module
