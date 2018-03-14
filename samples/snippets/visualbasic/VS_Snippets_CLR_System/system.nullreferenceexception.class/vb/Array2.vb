' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Module Example
   Public Sub Main()
      Dim values() As String = { "one", Nothing, "two" }
      For ctr As Integer = 0 To values.GetUpperBound(0)
         Console.Write("{0}{1}", 
                       If(values(ctr) IsNot Nothing, values(ctr).Trim(), ""), 
                       If(ctr = values.GetUpperBound(0), "", ", ")) 
      Next
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'       one, , two
' </Snippet9>
