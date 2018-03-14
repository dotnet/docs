' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example
   Public Sub Main()
      Dim values() As Decimal = { 1345.6538d, 1921651.16d }
      
      For Each value In values
         Dim resultString As String = value.ToString()
         Console.WriteLine(resultString)
         Console.WriteLine()      
      Next   
   End Sub
End Module
' The example displays the following output:
'       1345.6538
'       
'       1921651.16
' </Snippet3>