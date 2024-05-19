' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Enum ArrivalStatus1 As Integer
    Late = -1
    OnTime = 0
    Early = 1
End Enum
' </Snippet1>

' <Snippet2>
Public Module Example1
    Public Sub Main()
        Dim status As ArrivalStatus1 = ArrivalStatus1.OnTime
        Console.WriteLine("Arrival Status: {0} ({0:D})", status)
    End Sub
End Module
' The example displays the following output:
'        Arrival Status: OnTime (0)
' </Snippet2>
