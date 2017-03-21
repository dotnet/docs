            Dim myArray(myExceptionDictionary.Count -1 ) As Object
            myExceptionDictionary.Keys.CopyTo(CType(myArray, Array), 0)
            Console.WriteLine(" Keys are :")
            Dim myObj As Object
            For Each myObj In  myArray
               Console.WriteLine(" " + myObj.ToString())
            Next myObj