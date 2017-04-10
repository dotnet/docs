' Visual Basic .NET Document
Option Strict On
Option Infer On

Imports System.Numerics

Module Example
   Public Sub Main()
      FromDecimal()
      Console.WriteLine()
      FromBigInteger()
      
   End Sub
   
   Private Sub FromDecimal()
      ' <Snippet1>
      Dim numbers() As Decimal = { Decimal.MinValue, -18.35d, 0d, 1893.019d, 
                                   Decimal.MaxValue }
      For Each number In numbers
         Dim c1 As System.Numerics.Complex = CType(number, 
                                                   System.Numerics.Complex)
         Console.WriteLine("{0,30}  -->  {1}", number, c1)
      Next   
      ' The example displays the following output:
      '    -79228162514264337593543950335  -->  (-7.92281625142643E+28, 0)
      '                            -18.35  -->  (-18.3500003814697, 0)
      '                                 0  -->  (0, 0)
      '                          1893.019  -->  (1893.01904296875, 0)
      '     79228162514264337593543950335  -->  (7.92281625142643E+28, 0)
       ' </Snippet1>
   End Sub
   
   Private Sub FromBigInteger()
      ' <Snippet2>
      Dim numbers() As BigInteger = {
                       CType(Double.MaxValue, BigInteger) * 2, 
                       BigInteger.Parse("901345277852317852466891423"), 
                       BigInteger.One } 
      For Each number In numbers
        Dim c1 As System.Numerics.Complex = CType(number, 
                                          System.Numerics.Complex)
         Console.WriteLine(c1)
      Next        
      ' The example displays the following output:
      '       (Infinity, 0)
      '       (9.01345277852318E+26, 0)
      '       (1, 0)      
      ' </Snippet2>                            
   End Sub
End Module

