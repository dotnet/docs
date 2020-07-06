Option Strict On

' <Snippet1>
Public Class Constants
    Public Const Pi As Double = 3.1416
    Public ReadOnly BirthDate As Date

    Public Sub New(birthDate As Date)
        Me.BirthDate = birthDate
    End Sub
End Class

Public Module Example
    Public Sub Main()
        Dim con As New Constants(#8/18/1974#)
        Console.WriteLine(Constants.Pi.ToString())
        Console.WriteLine(con.BirthDate.ToString("d"))
    End Sub
End Module
' The example displays the following output if run on a system whose current
' culture is en-US:
'    3.1416
'    8/18/1974
' </Snippet1>
