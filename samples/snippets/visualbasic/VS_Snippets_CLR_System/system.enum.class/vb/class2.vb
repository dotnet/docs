' Visual Basic .NET Document
Option Strict On

Public Enum ArrivalStatus As Integer
   Late = -1
   OnTime = 0
   Early = 1
End Enum

Public Module Example
   Public Sub Main()
      ' <Snippet3>
      Dim status1 As New ArrivalStatus()
      Console.WriteLine("Arrival Status: {0} ({0:D})", status1)
      ' The example displays the following output:
      '        Arrival Status: OnTime (0)
      ' </Snippet3>
      
      ' <Snippet4>
      Dim status2 As ArrivalStatus = CType(1, ArrivalStatus)
      Console.WriteLine("Arrival Status: {0} ({0:D})", status2)
      ' The example displays the following output:
      '       Arrival Status: Early (1)
      ' </Snippet4>
      
      ' <Snippet5>
      Dim value3 As Integer = 2
      Dim status3 As ArrivalStatus = CType(value3, ArrivalStatus)
      
      Dim value4 As Integer = CInt(status3)
      ' </Snippet5>

      ' <Snippet6>
      Dim number As Integer = -1
      Dim arrived As ArrivalStatus = CType(ArrivalStatus.ToObject(GetType(ArrivalStatus), number), ArrivalStatus)
      ' </Snippet6>
   End Sub
End Module
