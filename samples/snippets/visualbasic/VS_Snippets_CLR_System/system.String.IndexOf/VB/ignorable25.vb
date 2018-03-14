' Visual Basic .NET Document
Option Strict On
' <Snippet25>
Module Example
   Public Sub Main()
      Dim searchString As String = Chrw(&h00AD) + "m"
      Dim s1 As String = "ani" + ChrW(&h00AD) + "mal"
      Dim s2 As String = "animal"

      Console.WriteLine(s1.IndexOf(searchString, 2, StringComparison.CurrentCulture))
      Console.WriteLine(s1.IndexOf(searchString, 2, StringComparison.Ordinal))
      Console.WriteLine(s2.IndexOf(searchString, 2, StringComparison.CurrentCulture))
      Console.WriteLine(s2.IndexOf(searchString, 2, StringComparison.Ordinal))
   End Sub
End Module
' The example displays the following output:
'       4
'       3
'       3
'       -1
' </Snippet25>
