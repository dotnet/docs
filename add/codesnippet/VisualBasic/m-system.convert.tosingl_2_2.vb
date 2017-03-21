Module Example
   Public Sub Main()
      Dim cold As New Temperature(-40)
      Dim freezing As New Temperature(0)
      Dim boiling As New Temperature(100)
      
      Console.WriteLine(Convert.ToInt32(cold, Nothing))
      Console.WriteLine(Convert.ToInt32(freezing, Nothing))
      Console.WriteLine(Convert.ToDouble(boiling, Nothing))
   End Sub
End Module
' The example displays the following output:
'       -40
'       0
'       100