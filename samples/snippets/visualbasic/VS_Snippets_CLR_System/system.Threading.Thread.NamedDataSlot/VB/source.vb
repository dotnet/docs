' <Snippet1>
Imports System
Imports System.Threading

Class Test
    Public Shared Sub Main()
        Dim newThreads(3) As Thread
        Dim i As Integer
        For i = 0 To newThreads.Length - 1
            newThreads(i) = _
                New Thread(New ThreadStart(AddressOf Slot.SlotTest))
            newThreads(i).Start()
        Next i
        Thread.Sleep(2000)
        For i = 0 To newThreads.Length - 1
            newThreads(i).Join()
            Console.WriteLine("Thread_{0} finished.", _
                newThreads(i).ManagedThreadId)
        Next i
    End Sub
End Class

Class Slot
    Private Shared randomGenerator As New Random()

    Public Shared Sub SlotTest()
        ' Set random data in each thread's data slot.
        Dim slotData As Integer = randomGenerator.Next(1, 200)
        Dim threadId As Integer = Thread.CurrentThread.ManagedThreadId

        Thread.SetData(
            Thread.GetNamedDataSlot("Random"),
            slotData)

        ' Show what was saved in the thread's data slot.
        Console.WriteLine("Data stored in thread_{0}'s data slot: {1,3}",
            threadId, slotData)

        ' Allow other threads time to execute SetData to show
        ' that a thread's data slot is unique to itself.
        Thread.Sleep(1000)

        Dim newSlotData As Integer = _
            CType(Thread.GetData(Thread.GetNamedDataSlot("Random")), Integer)

        If newSlotData = slotData Then
            Console.WriteLine("Data in thread_{0}'s data slot is still: {1,3}",
                threadId, newSlotData)
        Else
            Console.WriteLine("Data in thread_{0}'s data slot changed to: {1,3}",
                threadId, newSlotData)
        End If
    End Sub
End Class
' </Snippet1>