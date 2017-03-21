    Private Sub BindingManagerBase_CurrentChanged(sender As Object, e As EventArgs)
        ' Print the new value of the current object.
        Console.Write("Current Changed: ")
        Console.WriteLine(CType(sender, BindingManagerBase).Current)
    End Sub 'BindingManagerBase_CurrentChanged
    
    
    Private Sub MoveNext()
        ' Increment the Position property value by one.
        myBindingManagerBase.Position += 1
    End Sub 'MoveNext
    
    
    Private Sub MovePrevious()
        ' Decrement the Position property value by one.
        myBindingManagerBase.Position -= 1
    End Sub 'MovePrevious
    
    
    Private Sub MoveFirst()
        ' Go to the first item in the list.
        myBindingManagerBase.Position = 0
    End Sub 'MoveFirst
    
    
    Private Sub MoveLast()
        ' Go to the last row in the list.
        myBindingManagerBase.Position = myBindingManagerBase.Count - 1
    End Sub 'MoveLast