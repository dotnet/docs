Imports System
Imports System.CodeDom

Public Class Class1

    Public Sub New()
    End Sub

    ' CodeTypeReferenceCollection
    Public Sub CodeTypeReferenceCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeTypeReferenceCollection.
        Dim collection As New CodeTypeReferenceCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CodeTypeReference to the collection.
        collection.Add(New CodeTypeReference(GetType(Boolean)))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CodeTypeReference objects to the collection.
        Dim references As CodeTypeReference() = {New CodeTypeReference(GetType(Boolean)), New CodeTypeReference(GetType(Boolean))}
        collection.AddRange(references)

        ' Adds a collection of CodeTypeReference objects to the collection.
        Dim referencesCollection As New CodeTypeReferenceCollection()
        referencesCollection.Add(New CodeTypeReference(GetType(Boolean)))
        referencesCollection.Add(New CodeTypeReference(GetType(Boolean)))
        collection.AddRange(referencesCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CodeTypeReference in the 
        ' collection, and retrieves its index if it is found.
        Dim testReference As New CodeTypeReference(GetType(Boolean))
        Dim itemIndex As Integer = -1
        If collection.Contains(testReference) Then
            itemIndex = collection.IndexOf(testReference)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection, beginning at index 0, 
        ' to the specified CodeTypeReference array.
        ' 'references' is a CodeTypeReference array.
        collection.CopyTo(references, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CodeTypeReference at index 0 of the collection.
        collection.Insert(0, New CodeTypeReference(GetType(Boolean)))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CodeTypeReference from the collection.
        Dim reference As New CodeTypeReference(GetType(Boolean))
        collection.Remove(reference)
        '</Snippet9>

        '<Snippet10>
        ' Removes the CodeTypeReference at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class