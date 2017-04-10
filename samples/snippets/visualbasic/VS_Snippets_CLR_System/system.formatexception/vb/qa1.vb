' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim rnd As New Random()
      Dim numbers(3) As Integer
      Dim total As Integer = 0
      For ctr = 0 To 2
         Dim number As Integer = rnd.Next(1001)
         numbers(ctr) = number
         total += number
      Next
      numbers(3) = total
      Console.WriteLine("{0} + {1} + {2} = {3}", numbers)   
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: 
'    System.FormatException: 
'       Index (zero based) must be greater than or equal to zero and less than the size of the argument list.
'       at System.Text.StringBuilder.AppendFormat(IFormatProvider provider, String format, Object[] args)
'       at System.IO.TextWriter.WriteLine(String format, Object arg0)
'       at System.IO.TextWriter.SyncTextWriter.WriteLine(String format, Object arg0)
'       at Example.Main()
' </Snippet5>
