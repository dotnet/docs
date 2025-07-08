' Visual Basic .NET Document
Option Strict On

Module modMain

   Public Sub Main()
      DivideWithSingles()
      DivideWithDoubles()
      DivideWithoutRounding()
      DivideWithRounding()
   End Sub
      
   Private Sub DivideWithoutRounding()   
      Console.WriteLine("DivideWithoutRounding")
      ' <Snippet1>
      Dim dividend As Decimal = Decimal.One
      Dim divisor As Decimal = 3
      ' The following displays 0.9999999999999999999999999999 to the console
      Console.WriteLine(dividend/divisor * divisor)   
      ' </Snippet1>
   End Sub
   
   Private Sub DivideWithRounding()
      Console.WriteLine("DivideWithRounding")
      ' <Snippet2>
      Dim dividend As Decimal = Decimal.One
      Dim divisor As Decimal = 3
      ' The following displays 1.00 to the console
      Console.WriteLine(Math.Round(dividend/divisor * divisor, 2))   
      ' </Snippet2>
   End Sub
   
   Private Sub DivideWithSingles()
      Console.WriteLine("DivideWithSingles")
      Dim dividend As Single = 1
      Dim divisor As Single = 3
      Console.WriteLine(dividend/divisor * divisor)
   End Sub
   
   Private Sub DivideWithDoubles()
      Console.WriteLine("DivideWithDoubles")
      Dim dividend As Double = 1
      Dim divisor As Double = 3
      Console.WriteLine(dividend/divisor * divisor)
   End Sub
End Module

