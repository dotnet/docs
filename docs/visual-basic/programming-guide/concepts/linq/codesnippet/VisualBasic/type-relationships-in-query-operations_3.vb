        Dim names = {"John", "Rick", "Maggie", "Mary"}
        Dim mNames = From name In names
                     Where name.IndexOf("M") = 0
                     Select name

        For Each nm In mNames
            Console.WriteLine(nm)
        Next