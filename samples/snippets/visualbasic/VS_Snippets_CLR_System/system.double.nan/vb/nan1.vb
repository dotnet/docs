' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim zero As Double = 0
      Console.WriteLine("{0} / {1} = {2}", zero, zero, zero/zero)
      ' The example displays the following output:
      '         0 / 0 = NaN      
      ' </Snippet1> 
      Console.WriteLine()
      
      ' <Snippet2>
      Dim nan1 As Double = Double.NaN
      
      Console.WriteLine("{0} + {1} = {2}", 3, nan1, 3 + nan1)
      Console.WriteLine("Abs({0}) = {1}", nan1, Math.Abs(nan1))
      ' The example displays the following output:
      '       3 + NaN = NaN
      '       Abs(NaN) = NaN
      ' </Snippet2> 
      Console.WriteLine()
      
      ' <Snippet3>
      Dim result As Double = Double.Nan
      Console.WriteLine("{0} = Double.Nan: {1}", 
                        result, result = Double.Nan)
      ' The example displays the following output:
      '         NaN = Double.Nan: False
      ' </Snippet3> 
   End Sub
End Module

