'<snippet1>
Class Sample
   Public Shared Sub Main()
      Dim s1 As String = "abcd"
      Dim s2 As String = ""
      Dim s3 As String = Nothing
      
      Console.WriteLine("String s1 {0}.", Test(s1))
      Console.WriteLine("String s2 {0}.", Test(s2))
      Console.WriteLine("String s3 {0}.", Test(s3))
   End Sub
   
   Public Shared Function Test(s As String) As String
      If String.IsNullOrEmpty(s) Then
         Return "is null or empty"
      Else
         Return String.Format("(""{0}"") is neither null nor empty", s)
      End If
   End Function 
End Class  
' The example displays the following output:
'       String s1 ("abcd") is neither null nor empty.
'       String s2 is null or empty.
'       String s3 is null or empty.
' </snippet1>