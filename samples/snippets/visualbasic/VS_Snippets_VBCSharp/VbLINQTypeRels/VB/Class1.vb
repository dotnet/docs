' ********************************************************************

Option Infer On
Imports System.Collections.Generic

Module Module1

    Sub Main()
        '<Snippet1>
        Dim city = "Seattle"
        '</Snippet1>

        '<Snippet2>
        Dim names = {"John", "Rick", "Maggie", "Mary"}
        Dim mNames = From name In names
                     Where name.IndexOf("M") = 0
                     Select name

        For Each nm In mNames
            Console.WriteLine(nm)
        Next
        '</Snippet2>

        '<Snippet3>
        Dim names2 = {"John", "Rick", "Maggie", "Mary"}
        Dim mNames2 As IEnumerable(Of String) =
            From name As String In names
            Where name.IndexOf("M") = 0
            Select name

        For Each nm As String In mNames
            Console.WriteLine(nm)
        Next
        '</Snippet3>

        '<Snippet4>
        Dim numbers1() As Integer = {1, 2, 4, 16, 32, 64}
        Dim numbers2() As Double = {5.0#, 10.0#, 15.0#}

        ' This code does not result in an error.
        Dim numberQuery1 = From n As Integer In numbers1 Where n > 5

        ' This code results in an error with Option Strict set to On. The type Double
        ' cannot be implicitly cast as type Integer.
        Dim numberQuery2 = From n As Integer In numbers2 Where n > 5

        ' This code casts the values in the data source to type Integer. The type of
        ' the range variable is Integer.
        Dim numberQuery3 = From n In numbers2.Cast(Of Integer)() Where n > 5

        ' This code returns the value of the range variable converted to Integer. The type of
        ' the range variable is Double.
        Dim numberQuery4 = From n In numbers2 Where n > 5 Select CInt(n)
        '</Snippet4>


        '' Method GetTable returns a table of Customer objects.
        'Dim customers = db.GetTable(Of Customer)()
        'Dim custNames = From cust In customers
        '                Where cust.City = "London"
        '                Select cust.Name

        'For Each custName In custNames
        '    Console.WriteLine(custName)
        'Next

        '' Method GetTable returns a table of Customer objects.
        'Dim customers As Table(Of Customer) = db.GetTable(Of Customer)()
        'Dim custNames As IEnumerable(Of String) =
        '    From cust As Customer In customers
        '    Where cust.City = "London"
        '    Select cust.Name

        'For Each custName As String In custNames
        '    Console.WriteLine(custName)
        'Next

        '' Method GetTable returns a table of Customer objects.
        'Dim customers = db.GetTable(Of Customer)()
        'Dim nameCityQuery = From cust In customers
        '                    Where cust.City = "London"
        '                    Select cust.Name, cust.City

        'For Each custInfo In nameCityQuery
        '    Console.WriteLine(custInfo.Name)
        'Next

    End Sub

End Module
