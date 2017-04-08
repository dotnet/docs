'<snippet1>
Imports System
Imports System.Threading

Namespace AutoResetEvent_Examples
    Class MyMainClass
        'Initially not signaled.
        Private Const numIterations As Integer = 100
        Private Shared myResetEvent As New AutoResetEvent(False)
        Private Shared number As Integer

        <MTAThread> _
        Shared Sub Main()
            'Create and start the reader thread.
            Dim myReaderThread As New Thread(AddressOf MyReadThreadProc)
            myReaderThread.Name = "ReaderThread"
            myReaderThread.Start()

            Dim i As Integer
            For i = 1 To numIterations
                Console.WriteLine("Writer thread writing value: {0}", i)
                number = i

                'Signal that a value has been written.
                myResetEvent.Set()

                'Give the Reader thread an opportunity to act.
                Thread.Sleep(1)
            Next i

            'Terminate the reader thread.
            myReaderThread.Abort()
        End Sub 'Main

        Shared Sub MyReadThreadProc()
            While True
                'The value will not be read until the writer has written
                ' at least once since the last read.
                myResetEvent.WaitOne()
                Console.WriteLine("{0} reading value: {1}", Thread.CurrentThread.Name, number)
            End While
        End Sub 'MyReadThreadProc
    End Class 'MyMainClass
End Namespace 'AutoResetEvent_Examples
'</snippet1>