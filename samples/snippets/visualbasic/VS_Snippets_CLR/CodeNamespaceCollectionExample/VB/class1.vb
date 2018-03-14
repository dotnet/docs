Imports System
Imports System.CodeDom

Public Class Class1

    Public Sub New()
    End Sub

    ' CodeNamespaceCollection
    Public Sub CodeNamespaceCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeNamespaceCollection.            
        Dim collection As New CodeNamespaceCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CodeNamespace to the collection.
        collection.Add(New CodeNamespace("TestNamespace"))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CodeNamespace objects to the collection.
        Dim namespaces As CodeNamespace() = {New CodeNamespace("TestNamespace1"), New CodeNamespace("TestNamespace2")}
        collection.AddRange(namespaces)

        ' Adds a collection of CodeNamespace objects to the collection.
        Dim namespacesCollection As New CodeNamespaceCollection()
        namespacesCollection.Add(New CodeNamespace("TestNamespace1"))
        namespacesCollection.Add(New CodeNamespace("TestNamespace2"))
        collection.AddRange(namespacesCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CodeNamespace in the collection,
        ' and retrieves its index if it is found.
        Dim testNamespace As New CodeNamespace("TestNamespace")
        Dim itemIndex As Integer = -1
        If collection.Contains(testNamespace) Then
            itemIndex = collection.IndexOf(testNamespace)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection beginning at index 0,
        ' to the specified CodeNamespace array.
        ' 'namespaces' is a CodeNamespace array.
        collection.CopyTo(namespaces, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CodeNamespace at index 0 of the collection.
        collection.Insert(0, New CodeNamespace("TestNamespace"))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CodeNamespace from the collection.
        Dim namespace_ As New CodeNamespace("TestNamespace")
        collection.Remove(namespace_)
        '</Snippet9>

        '<Snippet10>
        ' Removes the CodeNamespace at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class