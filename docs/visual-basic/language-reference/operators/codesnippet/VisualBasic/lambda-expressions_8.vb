Module Module1
    Delegate Sub StoreCalculation(ByVal value As Double,
                                  ByVal calcType As String,
                                  ByVal result As Double)

    Sub Main()
        ' Create a DataTable to store the data.
        Dim valuesTable = New DataTable("Calculations")
        valuesTable.Columns.Add("Value", GetType(Double))
        valuesTable.Columns.Add("Calculation", GetType(String))
        valuesTable.Columns.Add("Result", GetType(Double))

        ' Define a lambda subroutine to write to the DataTable.
        Dim writeToValuesTable = Sub(value As Double, calcType As String, result As Double)
                                     Dim row = valuesTable.NewRow()
                                     row(0) = value
                                     row(1) = calcType
                                     row(2) = result
                                     valuesTable.Rows.Add(row)
                                 End Sub

        ' Define the source values.
        Dim s = {1, 2, 3, 4, 5, 6, 7, 8, 9}

        ' Perform the calculations.
        Array.ForEach(s, Sub(c) CalculateSquare(c, writeToValuesTable))
        Array.ForEach(s, Sub(c) CalculateSquareRoot(c, writeToValuesTable))

        ' Display the data.
        Console.WriteLine("Value" & vbTab & "Calculation" & vbTab & "Result")
        For Each row As DataRow In valuesTable.Rows
            Console.WriteLine(row(0).ToString() & vbTab &
                              row(1).ToString() & vbTab &
                              row(2).ToString())
        Next

    End Sub


    Sub CalculateSquare(ByVal number As Double, ByVal writeTo As StoreCalculation)
        writeTo(number, "Square     ", number ^ 2)
    End Sub

    Sub CalculateSquareRoot(ByVal number As Double, ByVal writeTo As StoreCalculation)
        writeTo(number, "Square Root", Math.Sqrt(number))
    End Sub
End Module