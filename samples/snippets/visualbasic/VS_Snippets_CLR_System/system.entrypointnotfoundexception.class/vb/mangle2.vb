' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Module Example
   Public Declare Function DoubleNum Lib ".\TestDll.dll" Alias "?Double@@YAHH@Z" _
                  (ByVal number As Integer) As Integer
   
   Public Sub Main()
      Console.WriteLine(DoubleNum(10))
   End Sub
End Module
' The example displays the following output:
'    20 
' </Snippet8>
