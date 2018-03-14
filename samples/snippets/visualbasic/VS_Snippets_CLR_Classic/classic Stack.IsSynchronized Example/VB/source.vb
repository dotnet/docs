' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesStack    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Stack.
        Dim myStack As New Stack()
        myStack.Push("The")
        myStack.Push("quick")
        myStack.Push("brown")
        myStack.Push("fox")
        
        ' Creates a synchronized wrapper around the Stack.
        Dim mySyncdStack As Stack = Stack.Synchronized(myStack)

        ' Displays the sychronization status of both Stacks.
        Dim msg As String
        If myStack.IsSynchronized Then
            msg = "synchronized"
        Else
            msg = "not synchronized"
        End If        
        Console.WriteLine("myStack is {0}.", msg)        
        If mySyncdStack.IsSynchronized Then
            msg = "synchronized"
        Else
            msg = "not synchronized"
        End If
        Console.WriteLine("mySyncdStack is {0}.", msg)
    End Sub
End Class

' This code produces the following output.
' 
' myStack is not synchronized.
' mySyncdStack is synchronized.
 
' </Snippet1>
