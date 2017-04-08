' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesStack    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Stack.
        Dim myStack As New Stack()
        myStack.Push("The")
        myStack.Push("quick")
        myStack.Push("brown")
        myStack.Push("fox")
        myStack.Push("jumped")
        
        ' Displays the count and values of the Stack.
        Console.WriteLine("Initially,")
        Console.WriteLine("   Count    : {0}", myStack.Count)
        Console.Write("   Values:")
        PrintValues(myStack)
        
        ' Clears the Stack.
        myStack.Clear()
        
        ' Displays the count and values of the Stack.
        Console.WriteLine("After Clear,")
        Console.WriteLine("   Count    : {0}", myStack.Count)
        Console.Write("   Values:")
        PrintValues(myStack)

    End Sub    

    Public Shared Sub PrintValues(myCollection As IEnumerable)
        Dim obj As [Object]
        For Each obj In  myCollection
            Console.Write("    {0}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class


' This code produces the following output.
' 
' Initially,
'    Count    : 5
'    Values:    jumped    fox    brown    quick    The
' After Clear,
'    Count    : 0
'    Values:

' </Snippet1>
