Module Example
   Public Sub Main()
      Console.WriteLine(Utility.IsNumeric(12))
      Console.WriteLine(Utility.IsNumeric(True))
      Console.WriteLine(Utility.IsNumeric("c"c))
      Console.WriteLine(Utility.IsNumeric(#01/01/2012#))
      Console.WriteLine(Utility.IsInteger(12.2))
      Console.WriteLine(Utility.IsInteger(123456789))
      Console.WriteLine(Utility.IsFloat(True))
      Console.WriteLine(Utility.IsFloat(12.2))
      Console.WriteLine(Utility.IsFloat(12))
      Console.WriteLine("{0} {1} {2}", 12.1, Utility.Compare(12.1, 12), 12)
   End Sub
End Module
' The example displays the following output:
'       True
'       False
'       False
'       False
'       False
'       True
'       False
'       True
'       False
'       12.1 GreaterThan 12