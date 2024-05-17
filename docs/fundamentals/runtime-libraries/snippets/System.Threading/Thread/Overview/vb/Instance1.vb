' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Threading

Module Example2
    Private lock As New Object()

    Public Sub Main()
        ThreadPool.QueueUserWorkItem(AddressOf ShowThreadInformation)
        Dim th1 As New Thread(AddressOf ShowThreadInformation)
        th1.Start()
        Dim th2 As New Thread(AddressOf ShowThreadInformation)
        th2.IsBackground = True
        th2.Start()
        Thread.Sleep(500)
        ShowThreadInformation(Nothing)
    End Sub

    Private Sub ShowThreadInformation(state As Object)
        SyncLock lock
            Dim th As Thread = Thread.CurrentThread
            Console.WriteLine("Managed thread #{0}: ", th.ManagedThreadId)
            Console.WriteLine("   Background thread: {0}", th.IsBackground)
            Console.WriteLine("   Thread pool thread: {0}", th.IsThreadPoolThread)
            Console.WriteLine("   Priority: {0}", th.Priority)
            Console.WriteLine("   Culture: {0}", th.CurrentCulture.Name)
            Console.WriteLine("   UI culture: {0}", th.CurrentUICulture.Name)
            Console.WriteLine()
        End SyncLock
    End Sub
End Module
' The example displays output like the following:
'       ' Managed thread #6:
'          Background thread: True
'          Thread pool thread: False
'          Priority: Normal
'          Culture: en-US
'          UI culture: en-US
'       
'       Managed thread #3:
'          Background thread: True
'          Thread pool thread: True
'          Priority: Normal
'          Culture: en-US
'          UI culture: en-US
'       
'       Managed thread #4:
'          Background thread: False
'          Thread pool thread: False
'          Priority: Normal
'          Culture: en-US
'          UI culture: en-US
'       
'       Managed thread #1:
'          Background thread: False
'          Thread pool thread: False
'          Priority: Normal
'          Culture: en-US
'          UI culture: en-US
' </Snippet4>

