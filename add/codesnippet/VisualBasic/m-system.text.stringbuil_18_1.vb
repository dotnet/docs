      Dim chars() As Char = { "a"c, "b"c, "c"c, "d"c, "e"c}
      Dim sb As New System.Text.StringBuilder()
      Dim startPosition As Integer = Array.IndexOf(chars, "a"c)
      Dim endPosition As Integer = Array.IndexOf(chars, "c"c)
      If startPosition >= 0 AndAlso endPosition >= 0 Then
         sb.Append("The array from positions ").Append(startPosition).
                   Append(" to ").Append(endPosition).Append(" contains ").
                   Append(chars, startPosition, endPosition + 1).Append(".")
         Console.WriteLine(sb)
      End If             
      ' The example displays the following output:
      '       The array from positions 0 to 2 contains abc.