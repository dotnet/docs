' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Public Enum Comparison As Integer
   LessThan = -1
   Equal = 0
   GreaterThan = 1
End Enum

Module ValueComparison
   Public Sub Main()
      Dim mainValue As Integer = 16325
      Dim zeroValue As Integer = 0
      Dim negativeValue As Integer = -1934
      Dim positiveValue As Integer = 903624
      Dim sameValue As Integer = 16325
      
      Console.WriteLine("Comparing {0} and {1}: {2} ({3}).", _ 
                        mainValue, zeroValue, _
                        mainValue.CompareTo(zeroValue), _
                        CType(mainValue.CompareTo(zeroValue), Comparison))
                        
      Console.WriteLine("Comparing {0} and {1}: {2} ({3}).", _ 
                        mainValue, sameValue, _
                        mainValue.CompareTo(sameValue), _
                        CType(mainValue.CompareTo(sameValue), Comparison))
                        
      Console.WriteLine("Comparing {0} and {1}: {2} ({3}).", _ 
                        mainValue, negativeValue, _
                        mainValue.CompareTo(negativeValue), _
                        CType(mainValue.CompareTo(negativeValue), Comparison))
                        
      Console.WriteLine("Comparing {0} and {1}: {2} ({3}).", _ 
                        mainValue, positiveValue, _
                        mainValue.CompareTo(positiveValue), _
                        CType(mainValue.CompareTo(positiveValue), Comparison))
   End Sub
End Module
' The example displays the following output:
'       Comparing 16325 and 0: 1 (GreaterThan).
'       Comparing 16325 and 16325: 0 (Equal).
'       Comparing 16325 and -1934: 1 (GreaterThan).
'       Comparing 16325 and 903624: -1 (LessThan).
' </Snippet1>
