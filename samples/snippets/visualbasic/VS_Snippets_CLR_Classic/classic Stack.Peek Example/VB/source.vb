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

        ' Displays the Stack.
        Console.Write("Stack values:")
        PrintValues(myStack, ControlChars.Tab)

        ' Removes an element from the Stack.
        Console.WriteLine("(Pop)" & ControlChars.Tab & ControlChars.Tab & _
           "{0}", myStack.Pop())

        ' Displays the Stack.
        Console.Write("Stack values:")
        PrintValues(myStack, ControlChars.Tab)

        ' Removes another element from the Stack.
        Console.WriteLine("(Pop)" & ControlChars.Tab & ControlChars.Tab & _
           "{0}", myStack.Pop())

        ' Displays the Stack.
        Console.Write("Stack values:")
        PrintValues(myStack, ControlChars.Tab)

        ' Views the first element in the Stack but does not remove it.
        Console.WriteLine("(Peek)" & ControlChars.Tab & ControlChars.Tab & _
           "{0}", myStack.Peek())

        ' Displays the Stack.
        Console.Write("Stack values:")
        PrintValues(myStack, ControlChars.Tab)

    End Sub

    Public Shared Sub PrintValues(myCollection As IEnumerable, mySeparator As Char)
        Dim obj As [Object]
        For Each obj In  myCollection
            Console.Write("{0}{1}", mySeparator, obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class 'SamplesStack


' This code produces the following output.
' 
' Stack values:    fox    brown    quick    The
' (Pop)        fox
' Stack values:    brown    quick    The
' (Pop)        brown
' Stack values:    quick    The
' (Peek)        quick
' Stack values:    quick    The

' </Snippet1>