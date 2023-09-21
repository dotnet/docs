Imports System

Module Program
    Sub Main(args As String())
        Bad()
        Good()
    End Sub

    Sub Bad()
        '<bad>
        Dim value As Integer = 6324
        Dim output As String = String.Format("{{{0:D}}}",
                                             value)
        Console.WriteLine(output)

        'The example displays the following output:
        '      {D}
        '</bad>
    End Sub

    Sub Good()
        '<good>
        Dim value As Integer = 6324
        Dim output As String = String.Format("{0}{1:D}{2}",
                                             "{", value, "}")
        Console.WriteLine(output)

        'The example displays the following output:
        '      {6324}
        '</good>
    End Sub

End Module
