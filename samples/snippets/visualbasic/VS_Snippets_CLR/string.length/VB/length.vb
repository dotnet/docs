'<snippet1>
Class Sample
   Public Shared Sub Main()
      Dim str As String = "abcdefg"
      Console.WriteLine("1) The length of '{0}' is {1}", str, str.Length)
      Console.WriteLine("2) The length of '{0}' is {1}", "xyz", "xyz".Length)
      Dim length As Integer = str.Length
      Console.WriteLine("1) The length of '{0}' is {1}", str, length)
   End Sub 'Main
End Class 'Sample
'
'This example displays the following output:
'    1) The length of 'abcdefg' is 7
'    2) The length of 'xyz' is 3
'    3) The length of 'abcdefg' is 7
'</snippet1>