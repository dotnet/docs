Imports System
Imports System.CodeDom

Public Class Class1

    Public Sub New()
    End Sub

    ' CodeParameterDeclarationExpressionCollection
    Public Sub CodeParameterDeclarationExpressionCollectionExample()
        '<Snippet1>
        '<Snippet2>
        ' Creates an empty CodeParameterDeclarationExpressionCollection.
        Dim collection As New CodeParameterDeclarationExpressionCollection()
        '</Snippet2>

        '<Snippet3>
        ' Adds a CodeParameterDeclarationExpression to the collection.
        collection.Add(New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument"))
        '</Snippet3>

        '<Snippet4>
        ' Adds an array of CodeParameterDeclarationExpression objects 
        ' to the collection.
        Dim parameters As CodeParameterDeclarationExpression() = {New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument"), New CodeParameterDeclarationExpression(GetType(Boolean), "testBoolArgument")}
        collection.AddRange(parameters)

        ' Adds a collection of CodeParameterDeclarationExpression 
        ' objects to the collection.
        Dim parametersCollection As New CodeParameterDeclarationExpressionCollection()
        parametersCollection.Add(New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument"))
        parametersCollection.Add(New CodeParameterDeclarationExpression(GetType(Boolean), "testBoolArgument"))
        collection.AddRange(parametersCollection)
        '</Snippet4>

        '<Snippet5>
        ' Tests for the presence of a CodeParameterDeclarationExpression 
        ' in the collection, and retrieves its index if it is found.
        Dim testParameter As New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument")
        Dim itemIndex As Integer = -1
        If collection.Contains(testParameter) Then
            itemIndex = collection.IndexOf(testParameter)
        End If
        '</Snippet5>

        '<Snippet6>
        ' Copies the contents of the collection beginning at index 0 to the specified CodeParameterDeclarationExpression array.
        ' 'parameters' is a CodeParameterDeclarationExpression array.
        collection.CopyTo(parameters, 0)
        '</Snippet6>

        '<Snippet7>
        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count
        '</Snippet7>

        '<Snippet8>
        ' Inserts a CodeParameterDeclarationExpression at index 0 
        ' of the collection.
        collection.Insert(0, New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument"))
        '</Snippet8>

        '<Snippet9>
        ' Removes the specified CodeParameterDeclarationExpression 
        ' from the collection.
        Dim parameter As New CodeParameterDeclarationExpression(GetType(Integer), "testIntArgument")
        collection.Remove(parameter)
        '</Snippet9>

        '<Snippet10>
        ' Removes the CodeParameterDeclarationExpression at index 0.
        collection.RemoveAt(0)
        '</Snippet10>
        '</Snippet1>
    End Sub
End Class