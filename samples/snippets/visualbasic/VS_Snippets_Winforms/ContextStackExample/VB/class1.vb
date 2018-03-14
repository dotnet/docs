'<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization

Module ContextStackExample

    Sub Main()
        '<Snippet2>
        ' Create a ContextStack.
        Dim stack As New ContextStack
        '</Snippet2>

        '<Snippet3>
        ' Push ten items on to the stack and output the value of each.
        Dim number As Integer
        For number = 0 To 9
            Console.WriteLine(("Value pushed to stack: " + number.ToString()))
            stack.Push(number)
        Next number
        '</Snippet3>

        '<Snippet4>
        ' Pop each item off the stack.        
        Dim item As Object = stack.Pop()
        While item IsNot Nothing
            Console.WriteLine(("Value popped from stack: " + item.ToString()))
            item = stack.Pop()
        End While
        '</Snippet4>
    End Sub

End Module
'</Snippet1>