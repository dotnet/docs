Module Example
   Public Sub Main()
      Dim cold As New Temperature(-40)
      Dim freezing As New Temperature(0)
      Dim boiling As New Temperature(100)
      
      Console.WriteLine(Convert.ToDecimal(cold, Nothing))
      Console.WriteLine(Convert.ToDecimal(freezing, Nothing))
      Console.WriteLine(Convert.ToDecimal(boiling, Nothing))
   End Sub
End Module
' The example displays the following output:
'       -40
'       0
'       100