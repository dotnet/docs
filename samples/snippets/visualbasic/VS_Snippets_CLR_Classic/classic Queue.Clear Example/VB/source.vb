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
        myQ.Enqueue("jumped")
        
        ' Displays the count and values of the Queue.
        Console.WriteLine("Initially,")
        Console.WriteLine("   Count    : {0}", myQ.Count)
        Console.Write("   Values:")
        PrintValues(myQ)
        
        ' Clears the Queue.
        myQ.Clear()
        
        ' Displays the count and values of the Queue.
        Console.WriteLine("After Clear,")
        Console.WriteLine("   Count    : {0}", myQ.Count)
        Console.Write("   Values:")
        PrintValues(myQ)
    End Sub
    
    Public Shared Sub PrintValues(myQ As Queue)
        Dim myObj As [Object]
        For Each myObj In  myQ
            Console.Write("    {0}", myObj)
        Next myObj
        Console.WriteLine()
    End Sub 'PrintValues

End Class 'SamplesQueue 


' This code produces the following output.
' 
' Initially,
'    Count    : 5
'    Values:    The    quick    brown    fox    jumped
' After Clear,
'    Count    : 0
'    Values:

' </Snippet1>