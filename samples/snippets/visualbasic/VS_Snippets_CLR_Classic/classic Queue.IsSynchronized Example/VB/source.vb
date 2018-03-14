' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesQueue    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Queue.
        Dim myQ As New Queue()
        myQ.Enqueue("The")
        myQ.Enqueue("quick")
        myQ.Enqueue("brown")
        myQ.Enqueue("fox")
        
        ' Creates a synchronized wrapper around the Queue.
        Dim mySyncdQ As Queue = Queue.Synchronized(myQ)
        
        ' Displays the sychronization status of both Queues.
        Dim msg As String
        If myQ.IsSynchronized Then
            msg = "synchronized"
        Else
            msg = "not synchronized"
        End If
        Console.WriteLine("myQ is {0}.", msg)
        If mySyncdQ.IsSynchronized Then
            msg = "synchronized"
        Else
            msg = "not synchronized"
        End If
        Console.WriteLine("mySyncdQ is {0}.", msg)
    End Sub
End Class

' This code produces the following output.
' 
' myQ is not synchronized.
' mySyncdQ is synchronized. 
' </Snippet1>
