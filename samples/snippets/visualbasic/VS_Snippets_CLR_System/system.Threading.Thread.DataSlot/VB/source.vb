' <Snippet1>
Imports System
Imports System.Threading

Class Test

    <MTAThread> _
    Shared Sub Main()
        Dim newThreads(3) As Thread
        For i As Integer = 0 To newThreads.Length - 1
            newThreads(i) = New Thread(AddressOf Slot.SlotTest)
            newThreads(i).Start()
        Next i
    End Sub

End Class

Public Class Slot

    Shared randomGenerator As Random
    Shared localSlot As LocalDataStoreSlot

    Shared Sub New()
        randomGenerator = new Random()
        localSlot = Thread.AllocateDataSlot()
    End Sub

    Shared Sub SlotTest()

        ' Set different data in each thread's data slot.
        Thread.SetData(localSlot, randomGenerator.Next(1, 200))

        ' Write the data from each thread's data slot.
        Console.WriteLine("Data in thread_{0}'s data slot: {1,3}", _
            AppDomain.GetCurrentThreadId().ToString(), _
            Thread.GetData(localSlot).ToString())

        ' Allow other threads time to execute SetData to show
        ' that a thread's data slot is unique to the thread.
        Thread.Sleep(1000)

        ' Write the data from each thread's data slot.
        Console.WriteLine("Data in thread_{0}'s data slot: {1,3}", _
            AppDomain.GetCurrentThreadId().ToString(), _
            Thread.GetData(localSlot).ToString())
    End Sub

End Class
' </Snippet1>