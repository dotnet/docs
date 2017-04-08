Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class Class1

    Public Sub New()
    End Sub

    ' CodeCommentStatementCollection
    Public Sub CodeCommentStatementCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeCommentStatementCollection.
        Dim collection As New CodeCommentStatementCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CodeCommentStatement to the collection.
        collection.Add(New CodeCommentStatement("Test comment"))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CodeCommentStatement objects to the collection.
        Dim comments As CodeCommentStatement() = {New CodeCommentStatement("Test comment"), New CodeCommentStatement("Another test comment")}
        collection.AddRange(comments)

        ' Adds a collection of CodeCommentStatement objects to the 
        ' collection.
        Dim commentsCollection As New CodeCommentStatementCollection()
        commentsCollection.Add(New CodeCommentStatement("Test comment"))
        commentsCollection.Add(New CodeCommentStatement("Another test comment"))
        collection.AddRange(commentsCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CodeCommentStatement in the 
        ' collection, and retrieves its index if it is found.
        Dim testComment As New CodeCommentStatement("Test comment")
        Dim itemIndex As Integer = -1
        If collection.Contains(testComment) Then
            itemIndex = collection.IndexOf(testComment)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection beginning at index 0 to the specified CodeCommentStatement array.
        ' 'comments' is a CodeCommentStatement array.
        collection.CopyTo(comments, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CodeCommentStatement at index 0 of the collection.
        collection.Insert(0, New CodeCommentStatement("Test comment"))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CodeCommentStatement from the collection.
        Dim comment As New CodeCommentStatement("Test comment")
        collection.Remove(comment)
        '</Snippet9>

        '<Snippet10>
        ' Removes the CodeCommentStatement at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class