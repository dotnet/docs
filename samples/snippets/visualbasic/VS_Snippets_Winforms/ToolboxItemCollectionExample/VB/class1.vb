Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms

Module Module1

    Sub Main()
        '<Snippet1>
        ' Create a new ToolboxItemCollection using a ToolboxItem array.
        Dim collection As New ToolboxItemCollection(New ToolboxItem() _
         {New ToolboxItem(GetType(System.Windows.Forms.Label)), _
          New ToolboxItem(GetType(System.Windows.Forms.TextBox))})
        '</Snippet1>

        '<Snippet2>
        ' Creates a new ToolboxItemCollection using an existing ToolboxItemCollection.
        Dim coll As New ToolboxItemCollection(collection)
        '</Snippet2>

        '<Snippet3>
        ' Get the number of items in the collection.
        Dim collectionLength As Integer = collection.Count
        '</Snippet3>

        '<Snippet4>
        ' Get the ToolboxItem at each index.
        Dim item As ToolboxItem = Nothing
        Dim index As Integer
        For index = 0 To collection.Count - 1
            item = collection(index)
        Next index
        '</Snippet4>

        '<Snippet5>
        ' If the collection contains the specified ToolboxItem, 
        ' retrieve the collection index of the specified item.
        Dim indx As Integer = -1
        If collection.Contains(item) Then
            indx = collection.IndexOf(item)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copy the ToolboxItemCollection to the specified array.
        Dim items(collection.Count) As ToolboxItem
        collection.CopyTo(items, 0)
        '</Snippet6>
    End Sub
End Module