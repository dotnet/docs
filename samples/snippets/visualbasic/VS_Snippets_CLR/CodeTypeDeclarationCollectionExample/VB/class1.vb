Imports System
Imports System.CodeDom

Public Class Class1

    Public Sub New()
    End Sub

    ' CodeTypeDeclarationCollection
    Public Sub CodeTypeDeclarationCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeTypeDeclarationCollection.
        Dim collection As New CodeTypeDeclarationCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CodeTypeDeclaration to the collection.
        collection.Add(New CodeTypeDeclaration("TestType"))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CodeTypeDeclaration objects to the 
        ' collection.
        Dim declarations As CodeTypeDeclaration() = {New CodeTypeDeclaration("TestType1"), New CodeTypeDeclaration("TestType2")}
        collection.AddRange(declarations)

        ' Adds a collection of CodeTypeDeclaration objects to the collection.
        Dim declarationsCollection As New CodeTypeDeclarationCollection()
        declarationsCollection.Add(New CodeTypeDeclaration("TestType1"))
        declarationsCollection.Add(New CodeTypeDeclaration("TestType2"))
        collection.AddRange(declarationsCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CodeTypeDeclaration in the 
        ' collection, and retrieves its index if it is found.
        Dim testDeclaration As New CodeTypeDeclaration("TestType")
        Dim itemIndex As Integer = -1
        If collection.Contains(testDeclaration) Then
            itemIndex = collection.IndexOf(testDeclaration)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection, beginning at index 0,
        ' to the specified CodeTypeDeclaration array.
        ' 'declarations' is a CodeTypeDeclaration array.
        collection.CopyTo(declarations, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CodeTypeDeclaration at index 0 of the collection.
        collection.Insert(0, New CodeTypeDeclaration("TestType"))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CodeTypeDeclaration from the collection.
        Dim declaration As New CodeTypeDeclaration("TestType")
        collection.Remove(declaration)
        '</Snippet9>

        '<Snippet10>
        ' Removes the CodeTypeDeclaration at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class