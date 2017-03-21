            Dim myCollectionArray(myExceptionDictionary.Count -1 ) As Object
            myExceptionDictionary.Values.CopyTo(CType(myCollectionArray, Array), 0)
            Console.WriteLine(" Values are :")
            For Each myObj In  myCollectionArray
               Console.WriteLine(" " + myObj.ToString())
            Next myObj