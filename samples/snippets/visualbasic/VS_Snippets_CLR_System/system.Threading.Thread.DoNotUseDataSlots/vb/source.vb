' <Snippet1>
Imports System
Imports System.Threading

Class Test

    <MTAThread> _
    Shared Sub Main()

        For i As Integer = 1 To 3
            Dim newThread As New Thread(AddressOf ThreadData.ThreadStaticDemo)
            newThread.Start()
        Next i

    End Sub

End Class

Class ThreadData

    <ThreadStaticAttribute> _
    Shared threadSpecificData As Integer

    Shared Sub ThreadStaticDemo()

        ' Store the managed thread id for each thread in the static
        ' variable.
        threadSpecificData = Thread.CurrentThread.ManagedThreadId
      
        ' Allow other threads time to execute the same code, to show
        ' that the static data is unique to each thread.
        Thread.Sleep( 1000 )

        ' Display the static data.
        Console.WriteLine( "Data for managed thread {0}: {1}", _
            Thread.CurrentThread.ManagedThreadId, threadSpecificData )

    End Sub

End Class

' This code example produces output similar to the following:
'
'Data for managed thread 4: 4
'Data for managed thread 5: 5
'Data for managed thread 3: 3
' </Snippet1>