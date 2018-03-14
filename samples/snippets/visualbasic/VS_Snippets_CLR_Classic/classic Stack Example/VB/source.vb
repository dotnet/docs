' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesStack    
    
    Public Shared Sub Main()
    
        ' Creates and initializes a new Stack.
        Dim myStack As New Stack()
        myStack.Push("Hello")
        myStack.Push("World")
        myStack.Push("!")
        
        ' Displays the properties and values of the Stack.
        Console.WriteLine("myStack")
        Console.WriteLine(ControlChars.Tab & "Count:    {0}", myStack.Count)
        Console.Write(ControlChars.Tab & "Values:")
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
' myStack
'     Count:     3
'     Values:    !    World    Hello
' </Snippet1>
