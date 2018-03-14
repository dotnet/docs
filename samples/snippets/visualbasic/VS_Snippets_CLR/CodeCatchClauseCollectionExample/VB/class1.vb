Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class Class1

    Public Sub New()
    End Sub

    ' CodeCatchClauseCollection
    Public Sub CodeCatchClauseCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeCatchClauseCollection.
        Dim collection As New CodeCatchClauseCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CodeCatchClause to the collection.
        collection.Add(New CodeCatchClause("e"))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CodeCatchClause objects to the collection.
        Dim clauses As CodeCatchClause() = {New CodeCatchClause(), New CodeCatchClause()}
        collection.AddRange(clauses)

        ' Adds a collection of CodeCatchClause objects to the collection.
        Dim clausesCollection As New CodeCatchClauseCollection()
        clausesCollection.Add(New CodeCatchClause("e", New CodeTypeReference(GetType(System.ArgumentOutOfRangeException))))
        clausesCollection.Add(New CodeCatchClause("e"))
        collection.AddRange(clausesCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CodeCatchClause in the 
        ' collection, and retrieves its index if it is found.
        Dim testClause As New CodeCatchClause("e")
        Dim itemIndex As Integer = -1
        If collection.Contains(testClause) Then
            itemIndex = collection.IndexOf(testClause)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection beginning at index 0 to the specified CodeCatchClause array.
        ' 'clauses' is a CodeCatchClause array.
        collection.CopyTo(clauses, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CodeCatchClause at index 0 of the collection.
        collection.Insert(0, New CodeCatchClause("e"))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CodeCatchClause from the collection.
        Dim clause As New CodeCatchClause("e")
        collection.Remove(clause)
        '</Snippet9>

        '<Snippet10>
        ' Removes the CodeCatchClause at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class