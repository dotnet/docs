'<snippet01>
Imports System
Imports System.Collections.Generic

Class Program
    Shared Sub Main()
        Dim names As New List(Of String)
        names.Add("Bruce")
        names.Add("Alfred")
        names.Add("Tim")
        names.Add("Richard")

        ' Display the contents of the list using the Print method.
        names.ForEach(AddressOf Print)
    End Sub

    Shared Sub Print(ByVal s As String)
        Console.WriteLine(s)
    End Sub
End Class

' This code will produce output similar to the following:
' Bruce
' Alfred
' Tim
' Richard
'</snippet01>
