' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
   Public Sub Main()
      Dim birthdate As Date = #7/28/1993#
      Dim dates() As Date = { #9/16/1993#, #7/28/1994#, #10/16/2000#, _
                              #7/27/2003#, #5/27/2007# }
      For Each dateValue As Date In dates
         Dim interval As TimeSpan = dateValue - birthdate
         ' Get the approximate number of years, without accounting for leap years.
         Dim years As Integer = CInt(interval.TotalDays) \ 365
         ' See if adding the number of years exceeds dateValue.
         Dim output As String
         If birthdate.AddYears(years) <= dateValue Then
            output = String.Format("You are now {0} years old.", years)
            Console.WriteLine(output)
         Else
            output = String.Format("You are now {0} years old.", years - 1)
            Console.WriteLine(output)   
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'       You are now 0 years old.
'       You are now 1 years old.
'       You are now 7 years old.
'       You are now 9 years old.
'       You are now 13 years old.
' </Snippet7>
