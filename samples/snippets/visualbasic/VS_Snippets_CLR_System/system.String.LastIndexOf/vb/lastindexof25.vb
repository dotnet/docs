' <Snippet25>
Public Module Example
   Public Sub Main()
      Dim searchString As String = ChrW(&h00AD) + "m"
      Dim s1 As String = "ani" + ChrW(&h00AD) + "mal" 
      Dim s2 As String = "animal"
      Dim position As Integer

      position = s1.LastIndexOf("m"c)
      If position >= 0 Then
         Console.WriteLine(s1.LastIndexOf(searchString, position, StringComparison.CurrentCulture))
         Console.WriteLine(s1.LastIndexOf(searchString, position, StringComparison.Ordinal))
      End If
      
      position = s2.LastIndexOf("m"c)
      If position >= 0 Then
         Console.WriteLine(s2.LastIndexOf(searchString, position, StringComparison.CurrentCulture))
         Console.WriteLine(s2.LastIndexOf(searchString, position, StringComparison.Ordinal))
      End If
   End Sub
End Module
' The example displays the following output:
'       4
'       3
'       3
'       -1
' </Snippet25>
