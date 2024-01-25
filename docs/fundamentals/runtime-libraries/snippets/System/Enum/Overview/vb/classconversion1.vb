﻿' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet7>
Public Enum ArrivalStatus As Integer
   Unknown = -3
   Late = -1
   OnTime = 0
   Early = 1
End Enum

Module Example
   Public Sub Main()
      Dim values() As Integer = { -3, -1, 0, 1, 5, Int32.MaxValue }
      For Each value In values
         Dim status As ArrivalStatus
         If [Enum].IsDefined(GetType(ArrivalStatus), value)
            status = CType(value, ArrivalStatus) 
         Else
            status = ArrivalStatus.Unknown
         End If
         Console.WriteLine("Converted {0:N0} to {1}", value, status)
      Next   
   End Sub
End Module
' The example displays the following output:
'       Converted -3 to Unknown
'       Converted -1 to Late
'       Converted 0 to OnTime
'       Converted 1 to Early
'       Converted 5 to Unknown
'       Converted 2,147,483,647 to Unknown
' </Snippet7>

