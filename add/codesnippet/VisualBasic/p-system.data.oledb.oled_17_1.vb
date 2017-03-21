    Public Sub SearchParameters()
        ' ...
        ' create OleDbParameterCollection parameters
        ' ...
        If Not parameters.Contains("Description") Then
            Console.WriteLine("ERROR: no such parameter in the collection")
        Else
            Console.WriteLine("Name: " & parameters("Description").ToString() & _
                "Index: " & parameters.IndexOf("Description").ToString())
        End If
    End Sub 