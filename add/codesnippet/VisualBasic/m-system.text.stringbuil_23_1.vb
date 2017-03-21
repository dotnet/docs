      Dim str As String = "Characters in a string."
      Dim sb As New System.Text.StringBuilder()
      For Each ch In str
         sb.Append(" '").Append(ch).Append("' ")
      Next
      Console.WriteLine("Characters in the string:")
      Console.WriteLine("  {0}", sb)
      ' The example displays the following output:
      '    Characters in the string:
      '       'C'  'h'  'a'  'r'  'a'  'c'  't'  'e'  'r'  's'  ' '  'i'  'n'  ' '  'a'  ' '  's'  't' 'r'  'i'  'n'  'g'  '.'      