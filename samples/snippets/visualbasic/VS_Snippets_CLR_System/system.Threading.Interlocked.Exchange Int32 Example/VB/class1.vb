'<snippet1>
Imports System
Imports System.Threading

Namespace InterlockedExchange_Example
    Class MyInterlockedExchangeExampleClass
        '0 for false, 1 for true.
        Private Shared usingResource As Integer = 0

        Private Const numThreadIterations As Integer = 5
        Private Const numThreads As Integer = 10

        <MTAThread> _
        Shared Sub Main()
            Dim myThread As Thread
            Dim rnd As New Random()

            Dim i As Integer
            For i = 0 To numThreads - 1
                myThread = New Thread(AddressOf MyThreadProc)
                myThread.Name = String.Format("Thread{0}", i + 1)

                'Wait a random amount of time before starting next thread.
                Thread.Sleep(rnd.Next(0, 1000))
                myThread.Start()
            Next i
        End Sub 'Main

        Private Shared Sub MyThreadProc()
            Dim i As Integer
            For i = 0 To numThreadIterations - 1
                UseResource()

                'Wait 1 second before next attempt.
                Thread.Sleep(1000)
            Next i
        End Sub 

        'A simple method that denies reentrancy.
        Shared Function UseResource() As Boolean
            '0 indicates that the method is not in use.
            If 0 = Interlocked.Exchange(usingResource, 1) Then
                Console.WriteLine("{0} acquired the lock", Thread.CurrentThread.Name)

                'Code to access a resource that is not thread safe would go here.
                'Simulate some work
                Thread.Sleep(500)

                Console.WriteLine("{0} exiting lock", Thread.CurrentThread.Name)

                'Release the lock
                Interlocked.Exchange(usingResource, 0)
                Return True
            Else
                Console.WriteLine("   {0} was denied the lock", Thread.CurrentThread.Name)
                Return False
            End If
        End Function 
    End Class 
End Namespace 
'</snippet1>