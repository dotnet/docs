      Dim value As Decimal = 1346.19d
      Dim sb As New System.Text.StringBuilder()
      sb.Append("*"c, 5).AppendFormat("{0:C2}", value).Append("*"c, 5)
      Console.WriteLine(sb)
      ' The example displays the following output:
      '       *****$1,346.19*****