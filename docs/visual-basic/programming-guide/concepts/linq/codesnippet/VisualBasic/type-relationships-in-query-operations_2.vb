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