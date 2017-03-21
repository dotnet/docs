Public Module Example
   Public Sub Main
      Dim s As String = "This is a string."
      Dim sub1 As String = "this"
      Console.WriteLine("Does '{0}' contain '{1}'?", s, sub1)
      Dim comp As StringComparison = StringComparison.Ordinal
      Console.WriteLine("   {0:G}: {1}", comp, s.Contains(sub1, comp))
      
      comp = StringComparison.OrdinalIgnoreCase
      Console.WriteLine("   {0:G}: {1}", comp, s.Contains(sub1, comp))
   End Sub
End Module
' The example displays the following output:
'       Does 'This is a string.' contain 'this'?
'          Ordinal: False
'          OrdinalIgnoreCase: True