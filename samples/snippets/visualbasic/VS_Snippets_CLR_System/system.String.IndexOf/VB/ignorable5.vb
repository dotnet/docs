' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Module Example
   Public Sub Main()
      Dim softHyphen As String = ChrW(&h00AD)
      Dim s1 As String = "ani" + softHyphen + "mal"
      Dim s2 As String = "animal"
      
      Console.WriteLine("Culture-sensitive comparison:")
      ' Use culture-sensitive comparison to find the soft hyphen.
      Console.WriteLine(s1.IndexOf(softHyphen, StringComparison.CurrentCulture))
      Console.WriteLine(s2.IndexOf(softHyphen, StringComparison.CurrentCulture))
      
      ' Use culture-sensitive comparison to find the soft hyphen followed by "n".
      Console.WriteLine(s1.IndexOf(softHyphen + "n", StringComparison.CurrentCulture))
      Console.WriteLine(s2.IndexOf(softHyphen + "n", StringComparison.CurrentCulture))
      
      ' Use culture-sensitive comparison to find the soft hyphen followed by "m".
      Console.WriteLine(s1.IndexOf(softHyphen + "m", StringComparison.CurrentCulture))
      Console.WriteLine(s2.IndexOf(softHyphen + "m", StringComparison.CurrentCulture))
      
      Console.WriteLine("Ordinal comparison:")
      ' Use ordinal comparison to find the soft hyphen.
      Console.WriteLine(s1.IndexOf(softHyphen, StringComparison.Ordinal))
      Console.WriteLine(s2.IndexOf(softHyphen, StringComparison.Ordinal))
      
      ' Use ordinal comparison to find the soft hyphen followed by "n".
      Console.WriteLine(s1.IndexOf(softHyphen + "n", StringComparison.Ordinal))
      Console.WriteLine(s2.IndexOf(softHyphen + "n", StringComparison.Ordinal))
      
      ' Use ordinal comparison to find the soft hyphen followed by "m".
      Console.WriteLine(s1.IndexOf(softHyphen + "m", StringComparison.Ordinal))
      Console.WriteLine(s2.IndexOf(softHyphen + "m", StringComparison.Ordinal))
   End Sub
End Module
' The example displays the following output:
'       Culture-sensitive comparison:
'       0
'       0
'       1
'       1
'       4
'       3
'       Ordinal comparison:
'       3
'       -1
'       -1
'       -1
'       3
'       -1
' </Snippet6>

