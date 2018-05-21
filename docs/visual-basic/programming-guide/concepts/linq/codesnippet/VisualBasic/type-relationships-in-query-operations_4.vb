        Dim names2 = {"John", "Rick", "Maggie", "Mary"}
        Dim mNames2 As IEnumerable(Of String) =
            From name As String In names
            Where name.IndexOf("M") = 0
            Select name

        For Each nm As String In mNames
            Console.WriteLine(nm)
        Next