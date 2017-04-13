Module Module1

    Sub Main()
        '<Snippet1>
        ' Using GetType to obtain type information:
        Dim i As Integer = 42
        Dim type As System.Type = i.GetType()
        System.Console.WriteLine(type)
        '</Snippet1>


        '<Snippet2>
        ' Using Reflection to get information from an Assembly:
        Dim info As System.Reflection.Assembly = GetType(System.Int32).Assembly
        System.Console.WriteLine(info)
        '</Snippet2>
    End Sub

End Module
