'<snippet1>
Class Example
   Public Shared Sub Main()
      Dim s1 As String = "The quick brown fox jumps over the lazy dog"
      Dim s2 As String = "fox"
      Dim b As Boolean = s1.Contains(s2)
      Console.WriteLine("'{0}' is in the string '{1}': {2}",
                        s2, s1, b)
      If b Then
          Dim index As Integer = s1.IndexOf(s2)
          If index >= 0 Then
             Console.WriteLine("'{0} begins at character position {1}",
                               s2, index + 1)
          End If
       End If
   End Sub
End Class
'
' This example displays the following output:
'    'fox' is in the string 'The quick brown fox jumps over the lazy dog': True
'    'fox begins at character position 17
'</snippet1>