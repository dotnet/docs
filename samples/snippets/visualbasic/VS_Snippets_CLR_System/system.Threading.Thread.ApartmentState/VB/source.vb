' <Snippet1>
Imports System.Threading

Public Class ApartmentTest

    <MTAThread> _
    Shared Sub Main()
    
        Dim newThread As Thread = New Thread(AddressOf ThreadMethod)
        newThread.SetApartmentState(ApartmentState.MTA)

        Console.WriteLine("ThreadState: {0}, ApartmentState: {1}", _
            newThread.ThreadState, newThread.GetApartmentState())

        newThread.Start()

        ' Wait for newThread to start and go to sleep.
        Thread.Sleep(300)
        Try
            ' This causes an exception since newThread is sleeping.
            newThread.SetApartmentState(ApartmentState.STA)
        Catch stateException As ThreadStateException
            Console.WriteLine(vbCrLf & "{0} caught:" & vbCrLf & _
                "Thread is not In the Unstarted or Running state.", _
                stateException.GetType().Name)
            Console.WriteLine("ThreadState: {0}, ApartmentState: " & _
                "{1}", newThread.ThreadState, newThread.GetApartmentState())
        End Try

    End Sub

    Shared Sub ThreadMethod()
        Thread.Sleep(1000)
    End Sub

End Class
' </Snippet1>