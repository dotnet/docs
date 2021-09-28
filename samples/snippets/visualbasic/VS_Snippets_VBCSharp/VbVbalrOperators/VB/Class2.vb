'<Snippet54>
Option Strict Off
'</Snippet54>

Public Class Class2

  '<Snippet50>
  Dim var1 As String = "34"
  Dim var2 As Integer = 6
  Dim concatenatedNumber As Integer = var1 + var2
  '</Snippet50>

  '<Snippet51>
  ' The preceding statement generates a COMPILER ERROR. 
  '</Snippet51>

  '<Snippet52>
  ' The preceding statement returns 40 after the string in var1 is
  ' converted to a numeric value. This might be an unexpected result.
  ' We do not recommend use of Option Strict Off for these operations.
  '</Snippet52>

End Class
