Option Strict On
Option Infer On

' <Snippet1>
Module Example
    Sub Main()
        Dim from1980 As Tuple(Of Integer, Integer, Integer) =
            Tuple.Create(1203339, 1027974, 951270)
        Dim from1910 As New Tuple(Of Integer, Integer, Integer, Integer, Integer, Integer, Integer, _
            Tuple(Of Integer, Integer, Integer)) _
            (465766, 993078, 1568622, 1623452, 1849568, 1670144, 1511462, from1980)
        Dim population As New Tuple(Of String, Integer, Integer, Integer, Integer, Integer, Integer, _ 
            Tuple(Of Integer, Integer, Integer, Integer, Integer, Integer, Integer, Tuple(Of Integer, Integer, Integer))) _
            ("Detroit", 1860, 45619, 79577, 116340, 205876, 285704, from1910)

        Console.WriteLine(population.ToString())      
    End Sub
End Module
' The example displays the following output:
'   (Detroit, 1860, 45619, 79577, 116340, 205876, 285704, 465766, 993078, 
'    1568622, 1623452, 1849568, 1670144, 1511462, 1203339, 1027974, 951270)
' </Snippet1>
