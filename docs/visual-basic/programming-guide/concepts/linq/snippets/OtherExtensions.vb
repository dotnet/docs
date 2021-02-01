Imports System.Runtime.CompilerServices

Module OtherExtensions
    ' <IntOverload>
    ' Integer overload
    <Extension()>
    Function Median(ByVal source As IEnumerable(Of Integer)) As Double
        Return Aggregate num In source Select CDbl(num) Into med = Median()
    End Function
    ' </IntOverload>

    ' <GenericOverload>
    ' Generic overload.
    <Extension()>
    Function Median(Of T)(ByVal source As IEnumerable(Of T),
                      ByVal selector As Func(Of T, Double)) As Double
        Return Aggregate num In source Select selector(num) Into med = Median()
    End Function
    ' </GenericOverload>

    ' <SequenceElement>
    ' Extension method for the IEnumerable(of T) interface.
    ' The method returns every other element of a sequence.
    <Extension()>
    Iterator Function AlternateElements(Of T)(
    ByVal source As IEnumerable(Of T)
    ) As IEnumerable(Of T)
        Dim i = 0
        For Each element In source
            If (i Mod 2 = 0) Then
                Yield element
            End If
            i = i + 1
        Next
    End Function
    ' </SequenceElement>

End Module
