' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim dat As Date = #12/31/2015#
      For ctr As Integer = 0 To 15
         Console.WriteLine(dat.AddMonths(ctr).ToString("d"))
      Next
   End Sub
End Module
' The example displays the following output:
'       12/31/2015
'       1/31/2016
'       2/29/2016
'       3/31/2016
'       4/30/2016
'       5/31/2016
'       6/30/2016
'       7/31/2016
'       8/31/2016
'       9/30/2016
'       10/31/2016
'       11/30/2016
'       12/31/2016
'       1/31/2017
'       2/28/2017
'       3/31/2017
' </Snippet1>
