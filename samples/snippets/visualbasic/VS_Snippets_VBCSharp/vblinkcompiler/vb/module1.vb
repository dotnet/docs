Option Strict On

Imports System.Collections.Generic
Imports Microsoft.Office.Interop.Excel

Module Module1

    Sub Main()
        '<Snippet1>
        ' The following code causes an error if ISampleInterface is an embedded interop type.
        Dim sample As ISampleInterface(Of SampleType)
        '</Snippet1>
    End Sub

End Module

Interface ISampleInterface(Of T)

End Interface

Public Class SampleType

End Class

'<Snippet5>
Module Client
    Public Sub Main()
        Dim util As New Utility()

        ' The following code causes an error.
        Dim rangeList1 As List(Of Range) = util.GetRange1()

        ' The following code is valid.
        Dim rangeList2 As List(Of Range) = CType(util.GetRange2(), List(Of Range))
    End Sub
End Module
'</Snippet5>
