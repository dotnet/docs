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