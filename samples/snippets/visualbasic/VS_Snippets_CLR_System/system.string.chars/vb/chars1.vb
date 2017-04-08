' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim str1 As String = "Test"
      For ctr As Integer = 0 to str1.Length - 1
         Console.Write("{0} ", str1(ctr))
      Next   
      ' The example displays the following output:
      '      T e s t         
      ' </Snippet1>   
   End Sub
End Module

