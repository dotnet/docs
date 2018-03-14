' Visual Basic .NET Document
Option Strict On
' <Snippet2>
Module GenericFunc
   Public Sub Main()
      ' Instantiate delegate to reference UppercaseString method
      Dim convertMethod As Func(Of String, String) = AddressOf UppercaseString
      Dim name As String = "Dakota"
      ' Use delegate instance to call UppercaseString method
      Console.WriteLine(convertMethod(name))
   End Sub

   Private Function UppercaseString(inputString As String) As String
      Return inputString.ToUpper()
   End Function
End Module
' </Snippet2>
