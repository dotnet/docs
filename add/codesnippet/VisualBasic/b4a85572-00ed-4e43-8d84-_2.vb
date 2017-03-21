      If TypeOf arg Is IFormattable Then
         Return DirectCast(arg, IFormattable).ToString(fmt, CultureInfo.CurrentCulture)
      ElseIf arg IsNot Nothing Then
         Return arg.ToString()