Imports System.Globalization

Public Enum DaysOfWeek As Long
   Monday = 1
   Tuesday = 2
End Enum

Module TestFormatting
   Public Sub Main()
      Dim acctNumber As Long, balance As Double 
      Dim wday As DaysOfWeek 
      Dim output As String

      acctNumber = 104254567890
      balance = 16.34
      wday = DaysOfWeek.Monday

      output = String.Format(New AcctNumberFormat(), "On {2}, the balance of account {0:H} was {1:C2}.", acctNumber, balance, wday)
      Console.WriteLine(output)

      wday = DaysOfWeek.Tuesday
      output = String.Format(New AcctNumberFormat(), "On {2}, the balance of account {0:I} was {1:C2}.", acctNumber, balance, wday)
      Console.WriteLine(output)
   End Sub
End Module
' The example displays the following output:
'    On Monday, the balance of account 10425-456-7890 was $16.34.
'    On Tuesday, the balance of account 104254567890 was $16.34.