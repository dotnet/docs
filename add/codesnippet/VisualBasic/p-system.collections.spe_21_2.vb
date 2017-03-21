    ' Displays the contents of the OrderedDictionary from its keys and values
    Public Shared Sub DisplayContents( _
        ByVal keyCollection As ICollection, _
        ByVal valueCollection As ICollection, ByVal dictionarySize As Integer)

        Dim myKeys(dictionarySize) As [String]
        Dim myValues(dictionarySize) As [String]
        keyCollection.CopyTo(myKeys, 0)
        valueCollection.CopyTo(myValues, 0)

        ' Displays the contents of the OrderedDictionary
        Console.WriteLine("   INDEX KEY                       VALUE")
        Dim i As Integer
        For i = 0 To dictionarySize - 1
            Console.WriteLine("   {0,-5} {1,-25} {2}", _
                 i, myKeys(i), myValues(i))
        Next i
        Console.WriteLine()
    End Sub