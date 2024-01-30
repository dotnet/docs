' Visual Basic .NET Document
Option Strict On
Option Infer On

Public Enum ArrivalStatus8 As Integer
    Unknown = -3
    Late = -1
    OnTime = 0
    Early = 1
End Enum

Module Example8
    Public Sub Main()
        ' <Snippet9>
        Dim number As String = "-1"
        Dim name As String = "Early"
        Dim invalid As String = "32"

        Try
            Dim status1 As ArrivalStatus8 = CType([Enum].Parse(GetType(ArrivalStatus8), number), ArrivalStatus8)
            If Not [Enum].IsDefined(GetType(ArrivalStatus8), status1) Then status1 = ArrivalStatus8.Unknown
            Console.WriteLine("Converted '{0}' to {1}", number, status1)
        Catch e As FormatException
            Console.WriteLine("Unable to convert '{0}' to an ArrivalStatus8 value.",
                           number)
        End Try

        Dim status2 As ArrivalStatus8
        If [Enum].TryParse(Of ArrivalStatus8)(name, status2) Then
            If Not [Enum].IsDefined(GetType(ArrivalStatus8), status2) Then status2 = ArrivalStatus8.Unknown
            Console.WriteLine("Converted '{0}' to {1}", name, status2)
        Else
            Console.WriteLine("Unable to convert '{0}' to an ArrivalStatus8 value.",
                           number)
        End If
        ' The example displays the following output:
        '       Converted '-1' to Late
        '       Converted 'Early' to Early
        ' </Snippet9>      
    End Sub
End Module

