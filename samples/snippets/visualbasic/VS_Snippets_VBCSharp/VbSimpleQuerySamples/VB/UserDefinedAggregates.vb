'<Snippet18>
Imports System.Runtime.CompilerServices

Module UserDefinedAggregates

    ' Calculate the median value for a collection of type Double.
    <Extension()>
    Function Median(ByVal values As IEnumerable(Of Double)) As Double
        If values.Count = 0 Then
            Throw New InvalidOperationException("Cannot compute median for an empty set.")
        End If

        Dim sortedList = From number In values
                         Order By number

        Dim medianValue As Double

        Dim itemIndex = CInt(Int(sortedList.Count / 2))

        If sortedList.Count Mod 2 = 0 Then
            ' Even number of items in list.
            medianValue = ((sortedList(itemIndex) + sortedList(itemIndex - 1)) / 2)
        Else
            ' Odd number of items in list.
            medianValue = sortedList(itemIndex)
        End If

        Return medianValue
    End Function

    ' "Cast" the collection of generic items as type Double and call the 
    ' Median() method to calculate the median value.
    <Extension()>
    Function Median(Of T)(ByVal values As IEnumerable(Of T),
                          ByVal selector As Func(Of T, Double)) As Double
        Return (From element In values Select selector(element)).Median()
    End Function

End Module
'</Snippet18>

'<Snippet19>
Module Module1

    Sub Main()
        Dim numbers1 = {1, 2, 3, 4, 5}

        Dim query1 = Aggregate num In numbers1 Into Median(num)

        Console.WriteLine("Median = " & query1)

        Dim numbers2 = {1.9, 2, 8, 4, 5.7, 6, 7.2, 0}

        Dim query2 = Aggregate num In numbers2 Into Median()

        Console.WriteLine("Median = " & query2)
    End Sub

End Module
'</Snippet19>

