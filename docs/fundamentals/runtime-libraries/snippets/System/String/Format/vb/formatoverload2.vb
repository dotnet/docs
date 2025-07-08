' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet9>
Module Example3
    Public Sub Main()
        ' Create array of 5-tuples with population data for three U.S. cities, 1940-1950.
        Dim cities() =
          {Tuple.Create("Los Angeles", #1/1/1940#, 1504277, #1/1/1950#, 1970358),
            Tuple.Create("New York", #1/1/1940#, 7454995, #1/1/1950#, 7891957),
            Tuple.Create("Chicago", #1/1/1940#, 3396808, #1/1/1950#, 3620962),
            Tuple.Create("Detroit", #1/1/1940#, 1623452, #1/1/1950#, 1849568)}

        ' Display header
        Dim header As String = String.Format("{0,-12}{1,8}{2,12}{1,8}{2,12}{3,14}",
                                           "City", "Year", "Population", "Change (%)")
        Console.WriteLine(header)
        Console.WriteLine()
        For Each city In cities
            Dim output = String.Format("{0,-12}{1,8:yyyy}{2,12:N0}{3,8:yyyy}{4,12:N0}{5,14:P1}",
                                city.Item1, city.Item2, city.Item3, city.Item4, city.Item5,
                                (city.Item5 - city.Item3) / city.Item3)
            Console.WriteLine(output)
        Next
    End Sub
End Module
' The example displays the following output:
'    City            Year  Population    Year  Population    Change (%)
'    
'    Los Angeles     1940   1,504,277    1950   1,970,358        31.0 %
'    New York        1940   7,454,995    1950   7,891,957         5.9 %
'    Chicago         1940   3,396,808    1950   3,620,962         6.6 %
'    Detroit         1940   1,623,452    1950   1,849,568        13.9 %
' </Snippet9>
