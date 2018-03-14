' <Snippet1>
Public Module Example
   Public Sub Main()
      Dim original As String = "aaabbb"
      Console.WriteLine("The original string: '{0}'", original)
      Dim modified As String = original.Insert(3, " ")
      Console.WriteLine("The modified string: '{0}'", modified)
   End Sub
End Module
' The example displays the following output:
'     The original string: 'aaabbb'
'     The modified string: 'aaa bbb'
' </Snippet1>
