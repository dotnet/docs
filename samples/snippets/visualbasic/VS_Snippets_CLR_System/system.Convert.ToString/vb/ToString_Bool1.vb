' Visual Basic .NET Document
Option Strict On

Module modMain
   Public Sub Main()
      ' <Snippet1> 
      Dim falseFlag As Boolean = False
      Dim trueFlag As Boolean = True
      
      Console.WriteLine(Convert.ToString(falseFlag))
      Console.WriteLine(Convert.ToString(falseFlag).Equals(Boolean.FalseString))
      Console.WriteLine(Convert.ToString(trueFlag))
      Console.WriteLine(Convert.ToString(trueFlag).Equals(Boolean.TrueString))
      ' The example displays the following output:
      '       False
      '       True
      '       True
      '       True      
      ' </Snippet1>
   End Sub
End Module

