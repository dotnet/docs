
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected myBindingManagerBase As BindingManagerBase
    
    ' <Snippet1>
    Private Sub BindingManagerBase_CurrentChanged(sender As Object, e As EventArgs)
        ' Print the new value of the current object.
        Console.Write("Current Changed: ")
        Console.WriteLine(CType(sender, BindingManagerBase).Current)
    End Sub
    
    
    Private Sub MoveNext()
        ' Increment the Position property value by one.
        myBindingManagerBase.Position += 1
    End Sub
    
    
    Private Sub MovePrevious()
        ' Decrement the Position property value by one.
        myBindingManagerBase.Position -= 1
    End Sub
    
    
    Private Sub MoveFirst()
        ' Go to the first item in the list.
        myBindingManagerBase.Position = 0
    End Sub
    
    
    Private Sub MoveLast()
        ' Go to the last row in the list.
        myBindingManagerBase.Position = myBindingManagerBase.Count - 1
    End Sub
    ' </Snippet1>
End Class
