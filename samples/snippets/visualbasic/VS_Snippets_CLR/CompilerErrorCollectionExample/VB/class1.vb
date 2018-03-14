Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class Class1

    Public Sub New()
    End Sub

    ' CompilerErrorCollection
    Public Sub CompilerErrorCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CompilerErrorCollection.
        Dim collection As New CompilerErrorCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CompilerError to the collection.
        collection.Add(New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CompilerError objects to the collection.
        Dim errors As CompilerError() = {New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"), New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")}
        collection.AddRange(errors)

        ' Adds a collection of CompilerError objects to the collection.
        Dim errorsCollection As New CompilerErrorCollection()
        errorsCollection.Add(New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))
        errorsCollection.Add(New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))
        collection.AddRange(errorsCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CompilerError in the 
        ' collection, and retrieves its index if it is found.
        Dim testError As New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")
        Dim itemIndex As Integer = -1
        If collection.Contains(testError) Then
            itemIndex = collection.IndexOf(testError)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection, beginning at index 0, 
        ' to the specified CompilerError array.
        ' 'errors' is a CompilerError array.
        collection.CopyTo(errors, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CompilerError at index 0 of the collection.
        collection.Insert(0, New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CompilerError from the collection.
        Dim [error] As New CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text")
        collection.Remove([error])
        '</Snippet9>

        '<Snippet10>
        ' Removes the CompilerError at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class