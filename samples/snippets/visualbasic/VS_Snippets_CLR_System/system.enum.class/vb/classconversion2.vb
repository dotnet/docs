' Visual Basic .NET Document
Option Strict On
Option Infer On

Public Enum ArrivalStatus As Integer
   Unknown = -3
   Late = -1
   OnTime = 0
   Early = 1
End Enum

Module Example
   Public Sub Main()
      ' <Snippet8>
      Dim status As ArrivalStatus = ArrivalStatus.Early
      Dim number = Convert.ChangeType(status, [Enum].GetUnderlyingType(GetType(ArrivalStatus)))
      Console.WriteLine("Converted {0} to {1}", status, number)
      ' The example displays the following output:
      '       Converted Early to 1
      ' </Snippet8>
   End Sub
End Module

