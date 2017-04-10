 ' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic


Public Class SamplesQueue
    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Queue.
        Dim myQ As New Queue()
        myQ.Enqueue("The")
        myQ.Enqueue("quick")
        myQ.Enqueue("brown")
        myQ.Enqueue("fox")
        
        ' Displays the Queue.
        Console.Write("Queue values:")
        PrintValues(myQ)
        
        ' Removes an element from the Queue.
        Console.WriteLine("(Dequeue)    {0}", myQ.Dequeue())
        
        ' Displays the Queue.
        Console.Write("Queue values:")
        PrintValues(myQ)
        
        ' Removes another element from the Queue.
        Console.WriteLine("(Dequeue)    {0}", myQ.Dequeue())
        
        ' Displays the Queue.
        Console.Write("Queue values:")
        PrintValues(myQ)
        
        ' Views the first element in the Queue but does not remove it.
        Console.WriteLine("(Peek)       {0}", myQ.Peek())
        
        ' Displays the Queue.
        Console.Write("Queue values:")
        PrintValues(myQ)
    End Sub 'Main

    Public Shared Sub PrintValues(myCollection As IEnumerable)
        Dim obj As [Object]
        For Each obj In  myCollection
            Console.Write("    {0}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class 'SamplesQueue


' This code produces the following output.
' 
' Queue values:    The    quick    brown    fox
' (Dequeue)    The
' Queue values:    quick    brown    fox
' (Dequeue)    quick
' Queue values:    brown    fox
' (Peek)       brown
' Queue values:    brown    fox

' </Snippet1>