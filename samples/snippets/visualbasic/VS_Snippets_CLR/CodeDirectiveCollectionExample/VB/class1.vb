
Imports System
Imports System.CodeDom



Public Class Class1
    
    Public Sub New() 
    
    End Sub 'New
    
    
    ' CodeDirectiveCollection
    Public Sub CodeDirectiveCollectionExample() 
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeDirectiveCollection.
        Dim collection As New CodeDirectiveCollection()
        '</Snippet2>
        '<Snippet3>
        ' Adds a CodeDirective to the collection.
        collection.Add(New CodeRegionDirective(CodeRegionMode.Start, "Region1"))
        '</Snippet3>
        '<Snippet4>
        ' Adds an array of CodeDirective objects to the collection.
        Dim directives As CodeDirective() = {New CodeRegionDirective(CodeRegionMode.Start, "Region1"), New CodeRegionDirective(CodeRegionMode.End, "Region1")}
        collection.AddRange(directives)

        ' Adds a collection of CodeDirective objects to the collection.
        Dim directivesCollection As New CodeDirectiveCollection()
        directivesCollection.Add(New CodeRegionDirective(CodeRegionMode.Start, "Region2"))
        directivesCollection.Add(New CodeRegionDirective(CodeRegionMode.End, "Region2"))
        collection.AddRange(directivesCollection)
        '</Snippet4>
        '<Snippet5>
        ' Tests for the presence of a CodeDirective in the 
        ' collection, and retrieves its index if it is found.
        Dim testDirective = New CodeRegionDirective(CodeRegionMode.Start, "Region1")
        Dim itemIndex As Integer = -1
        If collection.Contains(testDirective) Then
            itemIndex = collection.IndexOf(testDirective)
        End If
        '</Snippet5>
        '<Snippet6>
        ' Copies the contents of the collection beginning at index 0 to the specified CodeDirective array.
        ' 'directives' is a CodeDirective array.
        collection.CopyTo(directives, 0)
        '</Snippet6>
        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>
        '<Snippet8>
        ' Inserts a CodeDirective at index 0 of the collection.
        collection.Insert(0, New CodeRegionDirective(CodeRegionMode.Start, "Region1"))
        '</Snippet8>
        '<Snippet9>
        ' Removes the specified CodeDirective from the collection.
        Dim directive = New CodeRegionDirective(CodeRegionMode.Start, "Region1")
        collection.Remove(directive)
        '</Snippet9>
        '<Snippet10>
        ' Removes the CodeDirective at index 0.
        collection.RemoveAt(0)
    
    End Sub 'CodeDirectiveCollectionExample 
    '</Snippet10>           
End Class 'Class1 
'</Snippet1>