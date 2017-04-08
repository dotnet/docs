' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Enum Relationship As Integer
    LessThan = -1
    Equals = 0
    GreaterThan = 1
End Enum

Module Example
   Public Sub Main()
      Dim value1 As Decimal = Decimal.MaxValue
      Dim value2 As Decimal = value1 - .01d
      Console.WriteLine("{0} {2} {1}", value1, value2, 
                        CType(Decimal.Compare(value1, value2), Relationship))   
   
      value2 = value1 / 12d - .1d
      value1 = value1 / 12d
      Console.WriteLine("{0} {2} {1}", value1, value2, 
                        CType(Decimal.Compare(value1, value2), Relationship))   
   
      value1 = value1 - .2d
      value2 = value2 + .1d
      Console.WriteLine("{0} {2} {1}", value1, value2, 
                        CType(Decimal.Compare(value1, value2), Relationship))   
   End Sub
End Module
' The example displays the following output:
'     79228162514264337593543950335 Equals 79228162514264337593543950335
'     6602346876188694799461995861.2 GreaterThan 6602346876188694799461995861.1
'     6602346876188694799461995861.0 LessThan 6602346876188694799461995861.2
' </Snippet1>
