Module Client
    Public Sub Main()
        Dim util As New Utility()

        ' The following code causes an error.
        Dim rangeList1 As List(Of Range) = util.GetRange1()

        ' The following code is valid.
        Dim rangeList2 As List(Of Range) = CType(util.GetRange2(), List(Of Range))
    End Sub
End Module