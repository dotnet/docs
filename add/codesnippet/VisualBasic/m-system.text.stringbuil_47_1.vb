      Dim str As String = "First;George Washington;1789;1797"
      Dim index As Integer = 0
      Dim sb As New System.Text.StringBuilder()
      Dim length As Integer = str.IndexOf(";"c, index)      
      sb.Append(str, index, length).Append(" President of the United States: ")
      index += length + 1
      length = str.IndexOf(";"c, index) - index
      sb.Append(str, index, length).Append(", from ")
      index += length + 1
      length = str.IndexOf(";"c, index) - index
      sb.Append(str, index, length).Append(" to ")
      index += length + 1
      sb.Append(str, index, str.Length - index)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '    First President of the United States: George Washington, from 1789 to 1797      