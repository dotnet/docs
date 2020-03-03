 ' <Snippet1>
Imports System.Collections

Public Class SamplesQueue

    Public Shared Sub Main()

        ' Creates and initializes a new Queue.
        Dim myQ As New Queue()
        myQ.Enqueue("Hello")
        myQ.Enqueue("World")
        myQ.Enqueue("!")

        ' Displays the properties and values of the Queue.
        Console.WriteLine("myQ")
        Console.WriteLine("    Count:    {0}", myQ.Count)
        Console.Write("    Values:")
        PrintValues(myQ)

    End Sub

    Public Shared Sub PrintValues(myCollection As IEnumerable)
        Dim obj As [Object]
        For Each obj In  myCollection
            Console.Write("    {0}", obj)
        Next obj
        Console.WriteLine()
    End Sub

End Class


' This code produces the following output.
' 
' myQ
'     Count:    3
'     Values:    Hello    World    !

' </Snippet1>