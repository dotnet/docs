' <Snippet17>
Imports System.Globalization

Public Module Example
   Public Sub Main()
      Dim ci As CompareInfo = CultureInfo.CurrentCulture.CompareInfo

      Dim searchString As String = ChrW(&h00AD) + "m"
      Dim s1 As String = "ani" + ChrW(&h00AD) + "mal" 
      Dim s2 As String = "animal"
      Dim position As Integer

      position = ci.LastIndexOf(s1, "m"c)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s1, searchString, position, 3, CompareOptions.None))
         Console.WriteLine(ci.LastIndexOf(s1, searchString, position, 3, CompareOptions.Ordinal))
      End If
      
      position = ci.LastIndexOf(s2, "m"c)
      If position >= 0 Then
         Console.WriteLine(ci.LastIndexOf(s2, searchString, position, 3, CompareOptions.None))
         Console.WriteLine(ci.LastIndexOf(s2, searchString, position, 3, CompareOptions.Ordinal))
      End If
   End Sub
End Module
' The example displays the following output:
'       4
'       3
'       3
'       -1
' </Snippet17>