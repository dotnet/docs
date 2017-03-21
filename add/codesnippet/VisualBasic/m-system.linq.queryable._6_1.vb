        Dim fruits() As String = {"apple", "banana", "mango", _
                              "orange", "passionfruit", "grape"}

        Dim count As Long = fruits.AsQueryable().LongCount()

        MsgBox(String.Format("There are {0} fruits in the collection.", count))

        ' This code produces the following output:

        ' There are 6 fruits in the collection.
