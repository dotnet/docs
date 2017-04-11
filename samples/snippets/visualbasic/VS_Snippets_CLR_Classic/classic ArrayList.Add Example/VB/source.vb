' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new ArrayList.
        Dim myAL As New ArrayList()
        myAL.Add("The")
        myAL.Add("quick")
        myAL.Add("brown")
        myAL.Add("fox")
        
        ' Creates and initializes a new Queue.
        Dim myQueue As New Queue()
        myQueue.Enqueue("jumped")
        myQueue.Enqueue("over")
        myQueue.Enqueue("the")
        myQueue.Enqueue("lazy")
        myQueue.Enqueue("dog")
        
        ' Displays the ArrayList and the Queue.
        Console.WriteLine("The ArrayList initially contains the following:")
        PrintValues(myAL, ControlChars.Tab)
        Console.WriteLine("The Queue initially contains the following:")
        PrintValues(myQueue, ControlChars.Tab)
        
        ' Copies the Queue elements to the end of the ArrayList.
        myAL.AddRange(myQueue)
        
        ' Displays the ArrayList.
        Console.WriteLine("The ArrayList now contains the following:")
        PrintValues(myAL, ControlChars.Tab)
    End Sub

    Public Shared Sub PrintValues(myList As IEnumerable, mySeparator As Char)
        Dim obj As [Object]
        For Each obj In  myList
          Console.Write( "{0}{1}", mySeparator, obj )
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class


' This code produces the following output.
' 
' The ArrayList initially contains the following:
'     The    quick    brown    fox
' The Queue initially contains the following:
'     jumped    over    the    lazy    dog
' The ArrayList now contains the following:
'     The    quick    brown    fox    jumped    over    the    lazy    dog 
' </Snippet1>
