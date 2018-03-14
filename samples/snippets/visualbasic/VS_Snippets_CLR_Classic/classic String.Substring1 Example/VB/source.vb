' <Snippet1>
Public Class Sample
   Public Shared Sub Main()
      Dim myString As String = "abc"
      Dim test1 As Boolean = myString.Substring(2, 1).Equals("c") ' This is true.
      Console.WriteLine(test1)
      Dim test2 As Boolean = String.IsNullOrEmpty(myString.Substring(3, 0)) ' This is true.
      Console.WriteLine(test2)
      Try  
         Dim str3 As String = myString.Substring(3, 1) ' This throws ArgumentOutOfRangeException.
         Console.WriteLine(str3)
      Catch e As ArgumentOutOfRangeException
         Console.WriteLIne(e.Message)
      End Try   
   End Sub
End Class 
' The example displays the following output:
'       True
'       True
'       Index and length must refer to a location within the string.
'       Parameter name: length
' </Snippet1>
