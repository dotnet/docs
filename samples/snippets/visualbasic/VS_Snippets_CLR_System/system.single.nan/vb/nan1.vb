' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet1>
      Dim zero As Single = 0
      Console.WriteLine("{0} / {1} = {2}", zero, zero, zero/zero)
      ' The example displays the following output:
      '         0 / 0 = NaN      
      ' </Snippet1> 
      Console.WriteLine()
      
      ' <Snippet2>
      Dim nan1 As Single = Single.NaN
      
      Console.WriteLine("{0} + {1} = {2}", 3, nan1, 3 + nan1)
      Console.WriteLine("Abs({0}) = {1}", nan1, Math.Abs(nan1))
      ' The example displays the following output:
      '       3 + NaN = NaN
      '       Abs(NaN) = NaN
      ' </Snippet2> 
      Console.WriteLine()
      
      ' <Snippet3>
      Dim result As Single = Single.Nan
      Console.WriteLine("{0} = Single.Nan: {1}", 
                        result, result = Single.Nan)
      ' The example displays the following output:
      '         NaN = Single.NaN: False
      ' </Snippet3> 
   End Sub
End Module

