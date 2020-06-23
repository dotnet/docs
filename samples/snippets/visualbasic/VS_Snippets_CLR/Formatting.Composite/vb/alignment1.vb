' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Module Example
    Public Sub Main()
        Dim names() As String = {"Adam", "Bridgette", "Carla", "Daniel",
                                  "Ebenezer", "Francine", "George"}
        Dim hours() As Decimal = {40, 6.667d, 40.39d, 82, 40.333d, 80,
                                   16.75d}

        Console.WriteLine("{0,-20} {1,5}", "Name", "Hours")
        Console.WriteLine()
        For ctr As Integer = 0 To names.Length - 1
            Console.WriteLine("{0,-20} {1,5:N1}", names(ctr), hours(ctr))
        Next
    End Sub
End Module
' The example displays the following output:
'       Name                 Hours
'
'       Adam                  40.0
'       Bridgette              6.7
'       Carla                 40.4
'       Daniel                82.0
'       Ebenezer              40.3
'       Francine              80.0
'       George                16.8
' </Snippet8>
