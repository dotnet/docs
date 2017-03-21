Module Example
   Public Sub Main()
      Dim t1 = Tuple.Create(12.3, Double.NaN, 16.4)
      Dim t2 = Tuple.Create(12.3, Double.NaN, 16.4)
      
      ' Call default Equals method.
      Console.WriteLine(t1.Equals(t2))
      
      Dim equ As IStructuralEquatable = t1
      ' Call IStructuralEquatable.Equals using default comparer.
      Console.WriteLine(equ.Equals(t2, EqualityComparer(Of Object).Default))
      
      ' Call IStructuralEquatable.Equals using 
      ' StructuralComparisons.StructuralEqualityComparer.
      Console.WriteLine(equ.Equals(t2, 
                        StructuralComparisons.StructuralEqualityComparer))
      
      ' Call IStructuralEquatable.Equals using custom comparer.
      Console.WriteLine(equ.Equals(t2, New NanComparer))
   End Sub
End Module
' The example displays the following output:
'       True
'       True
'       True
'       False