Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler
Imports System.Collections

Public Class Class1

    Public Sub New()
    End Sub

    ' CodeAttributeDeclarationCollection
    Public Sub CodeAttributeDeclarationCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeAttributeDeclarationCollection.
        Dim collection As New CodeAttributeDeclarationCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CodeAttributeDeclaration to the collection.
        collection.Add(New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description"))))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CodeAttributeDeclaration objects to the collection.
        Dim declarations As CodeAttributeDeclaration() = {New CodeAttributeDeclaration(), New CodeAttributeDeclaration()}
        collection.AddRange(declarations)

        ' Adds a collection of CodeAttributeDeclaration objects to 
        ' the collection.
        Dim declarationsCollection As New CodeAttributeDeclarationCollection()
        declarationsCollection.Add(New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description"))))
        declarationsCollection.Add(New CodeAttributeDeclaration("BrowsableAttribute", New CodeAttributeArgument(New CodePrimitiveExpression(True))))
        collection.AddRange(declarationsCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CodeAttributeDeclaration in the 
        ' collection, and retrieves its index if it is found.
        Dim testdeclaration As New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description")))
        Dim itemIndex As Integer = -1
        If collection.Contains(testdeclaration) Then
            itemIndex = collection.IndexOf(testdeclaration)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection beginning at index 0 to the specified CodeAttributeDeclaration array.
        ' 'declarations' is a CodeAttributeDeclaration array.
        collection.CopyTo(declarations, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CodeAttributeDeclaration at index 0 of the collection.
        collection.Insert(0, New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description"))))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CodeAttributeDeclaration from the collection.
        Dim declaration As New CodeAttributeDeclaration("DescriptionAttribute", New CodeAttributeArgument(New CodePrimitiveExpression("Test Description")))
        collection.Remove(declaration)
        '</Snippet9>

        '<Snippet10>
        ' Removes the CodeAttributeDeclaration at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class