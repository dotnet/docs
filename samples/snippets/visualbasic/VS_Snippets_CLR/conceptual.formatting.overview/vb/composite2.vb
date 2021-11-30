
Public Module Example3
    Public Sub Main3()
        ' <Snippet22>
        Dim startDate As New Date(2015, 8, 28, 6, 0, 0)
        Dim temps() As Decimal = {73.452, 68.98, 72.6, 69.24563,
                                   74.1, 72.156, 72.228}
        Console.WriteLine("{0,-20} {1,11}", "Date", "Temperature")
        Console.WriteLine()
        For ctr As Integer = 0 To temps.Length - 1
            Console.WriteLine("{0,-20:g} {1,11:N1}", startDate.AddDays(ctr), temps(ctr))
        Next
        ' The example displays the following output:
        '       Date                 Temperature
        '
        '       8/28/2015 6:00 AM           73.5
        '       8/29/2015 6:00 AM           69.0
        '       8/30/2015 6:00 AM           72.6
        '       8/31/2015 6:00 AM           69.2
        '       9/1/2015 6:00 AM            74.1
        '       9/2/2015 6:00 AM            72.2
        '       9/3/2015 6:00 AM            72.2
        ' </Snippet22>
    End Sub
End Module


