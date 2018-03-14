Imports System
Imports System.CodeDom
Imports System.CodeDom.Compiler

Public Class Class1
   
   Public Sub New()
    End Sub

    ' CodeAttributeArgumentCollection
    Public Sub CodeAttributeArgumentCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeAttributeArgumentCollection.
        Dim collection As New CodeAttributeArgumentCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CodeAttributeArgument to the collection.
        collection.Add(New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True)))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CodeAttributeArgument objects to the collection.
        Dim arguments As CodeAttributeArgument() = {New CodeAttributeArgument(), New CodeAttributeArgument()}
        collection.AddRange(arguments)

        ' Adds a collection of CodeAttributeArgument objects to the collection.
        Dim argumentsCollection As New CodeAttributeArgumentCollection()
        argumentsCollection.Add(New CodeAttributeArgument("TestBooleanArgument", New CodePrimitiveExpression(True)))
        argumentsCollection.Add(New CodeAttributeArgument("TestIntArgument", New CodePrimitiveExpression(1)))
        collection.AddRange(argumentsCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CodeAttributeArgument in 
        ' the collection, and retrieves its index if it is found.
        Dim testArgument As New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True))
        Dim itemIndex As Integer = -1
        If collection.Contains(testArgument) Then
            itemIndex = collection.IndexOf(testArgument)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection beginning at index 0,
        ' to the specified CodeAttributeArgument array.
        ' 'arguments' is a CodeAttributeArgument array.
        collection.CopyTo(arguments, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CodeAttributeArgument at index 0 of the collection.
        collection.Insert(0, New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True)))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CodeAttributeArgument from the collection.
        Dim argument As New CodeAttributeArgument("Test Boolean Argument", New CodePrimitiveExpression(True))
        collection.Remove(argument)
        '</Snippet9>

        '<Snippet10>
        ' Removes the CodeAttributeArgument at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class