    Public Sub SearchParameters()
        ' ...
        ' create OdbcParameterCollection parameterCollection
        ' ...
        If Not parameterCollection.Contains("Description") Then
            Console.WriteLine("ERROR: no such parameter in the collection")
        Else
            Console.WriteLine("Name: " & parameterCollection("Description").ToString() & _
                "Index: " & parameterCollection.IndexOf("Description").ToString())
        End If
    End Sub 