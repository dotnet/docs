' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
    Public Sub Main()
        Dim cultureNames() As String = {"en-US", "en-GB", "fr-FR",
                                         "ne-NP", "es-BO", "ig-NG"}
        For Each cultureName In cultureNames
            Dim region As New RegionInfo(cultureName)
            Console.WriteLine("{0} {1} the metric system.", region.EnglishName,
                              If(region.IsMetric, "uses", "does not use"))
        Next
    End Sub
End Module
' The example displays the following output:
'       United States does not use the metric system.
'       United Kingdom uses the metric system.
'       France uses the metric system.
'       Nepal uses the metric system.
'       Bolivia uses the metric system.
'       Nigeria uses the metric system.
' </Snippet1>

