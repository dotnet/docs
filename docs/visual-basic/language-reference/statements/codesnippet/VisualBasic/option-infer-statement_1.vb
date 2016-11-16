        ' Enable Option Infer before trying these examples.

        ' Variable num is an Integer.
        Dim num = 5

        ' Variable dbl is a Double.
        Dim dbl = 4.113

        ' Variable str is a String.
        Dim str = "abc"

        ' Variable pList is an array of Process objects.
        Dim pList = Process.GetProcesses()

        ' Variable i is an Integer.
        For i = 1 To 10
            Console.WriteLine(i)
        Next

        ' Variable item is a string.
        Dim lst As New List(Of String) From {"abc", "def", "ghi"}

        For Each item In lst
            Console.WriteLine(item)
        Next

        ' Variable namedCust is an instance of the Customer class.
        Dim namedCust = New Customer With {.Name = "Blue Yonder Airlines",
                                           .City = "Snoqualmie"}

        ' Variable product is an instance of an anonymous type.
        Dim product = New With {Key .Name = "paperclips", .Price = 1.29}

        ' If customers is a collection of Customer objects in the following 
        ' query, the inferred type of cust is Customer, and the inferred type
        ' of custs is IEnumerable(Of Customer).
        Dim custs = From cust In customers 
                    Where cust.City = "Seattle" 
                    Select cust.Name, cust.ID