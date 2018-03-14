' Visual Basic .NET Document
Option Strict On
' <Snippet2>
Module GenericFunc
   Public Sub Main()
      ' Instantiate delegate to reference ExtractWords method
      Dim extractMeth As Func(Of String, Integer, String()) = AddressOf ExtractWords
      Dim title As String = "The Scarlet Letter"
      ' Use delegate instance to call ExtractWords method and display result
      For Each word As String In extractMeth(title, 5)
         Console.WriteLine(word)
      Next   
   End Sub

   Private Function ExtractWords(phrase As String, limit As Integer) As String()
      Dim delimiters() As Char = {" "c}
      If limit > 0 Then
         Return phrase.Split(delimiters, limit)
      Else
         Return phrase.Split(delimiters)
      End If
   End Function
End Module
' </Snippet2>
