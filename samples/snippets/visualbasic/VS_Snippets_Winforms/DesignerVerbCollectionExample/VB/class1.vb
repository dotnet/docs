Imports System
Imports System.ComponentModel.Design

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class Class1

    Public Sub New()
    End Sub

    ' DesignerVerbCollection
    Public Sub DesignerVerbCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty DesignerVerbCollection.
        Dim collection As New DesignerVerbCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a DesignerVerb to the collection.
        collection.Add(New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of DesignerVerb objects to the collection.
        Dim verbs As DesignerVerb() = {New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)), New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))}
        collection.AddRange(verbs)

        ' Adds a collection of DesignerVerb objects to the collection.
        Dim verbsCollection As New DesignerVerbCollection()
        verbsCollection.Add(New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))
        verbsCollection.Add(New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))
        collection.AddRange(verbsCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a DesignerVerb in the collection, 
        ' and retrieves its index if it is found.
        Dim testVerb As New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))
        Dim itemIndex As Integer = -1
        If collection.Contains(testVerb) Then
            itemIndex = collection.IndexOf(testVerb)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection, beginning at index 0, 
        ' to the specified DesignerVerb array.
        ' 'verbs' is a DesignerVerb array.
        collection.CopyTo(verbs, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a DesignerVerb at index 0 of the collection.
        collection.Insert(0, New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified DesignerVerb from the collection.
        Dim verb As New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))
        collection.Remove(verb)
        '</Snippet9>

        '<Snippet10>
        ' Removes the DesignerVerb at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub

    Private Sub ExampleEvent(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

End Class