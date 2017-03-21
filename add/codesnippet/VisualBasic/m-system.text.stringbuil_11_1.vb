      Dim bytes() As Byte = { 16, 132, 27, 253 }
      Dim sb As New System.Text.StringBuilder()
      For Each value In bytes
         sb.Append(value).Append(" ")         
      Next
      Console.WriteLine("The byte array: {0}", sb.ToString())
      ' The example displays the following output:
      '         The byte array: 16 132 27 253      