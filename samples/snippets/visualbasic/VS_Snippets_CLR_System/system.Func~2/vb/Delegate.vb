' Visual Basic .NET Document
Option Strict On
' <Snippet1>
' Declare a delegate to represent string conversion method
Delegate Function ConvertMethod(ByVal inString As String) As String

Module DelegateExample
   Public Sub Main()
      ' Instantiate delegate to reference UppercaseString method
      Dim convertMeth As ConvertMethod = AddressOf UppercaseString
      Dim name As String = "Dakota"
      ' Use delegate instance to call UppercaseString method
      Console.WriteLine(convertMeth(name))
   End Sub

   Private Function UppercaseString(inputString As String) As String
      Return inputString.ToUpper()
   End Function
End Module
' </Snippet1>
