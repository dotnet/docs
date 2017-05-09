' Visual Basic .NET Document
Option Strict Off
Option Infer On

' <Snippet2>
Imports System.Collections

Public Class Tuple1Comparer : Implements IEqualityComparer
   Public Overloads Function Equals(x As Object, y As Object) As Boolean _
                   Implements IEqualityComparer.Equals
      ' Check if x is a floating point type. If x is, then y is.
      If TypeOf x Is Double Or TypeOf x Is Single Then   
         ' Convert to Double values.
         Dim dblX As Double = CDbl(x)
         Dim dblY As Double = CDbl(y)
         If Double.IsNan(dblX) Or Double.IsInfinity(dblX) Or _
            Double.IsNan(dblY) Or Double.IsInfinity(dblY) Then
            Return dblX.Equals(dblY)   
         Else
            Return Math.Abs(dblX - dblY) <= dblY * .0001
         End If
      Else
         Return x.Equals(y)
      End If                    
   End Function
   
   Public Overloads Function GetHashCode(obj As Object) As Integer _
                   Implements IEqualityComparer.GetHashCode
      Return obj.GetHashCode()
   End Function
End Class

Module Example
   Public Sub Main()
      Dim doubleTuple1 = Tuple.Create(12.3455)

      Dim doubleTuple2 = Tuple.Create(16.8912)
      Dim doubleTuple3 = Tuple.Create(12.3449599)

      ' Compare first tuple with a Tuple(Of Double) with a different value.
      TestEquality(doubleTuple1, doubleTuple2)
      ' Compare first tuple with a Tuple(Of Double) with the same value.
      TestEquality(doubleTuple1, doubleTuple3)
   End Sub

   Private Sub TestEquality(tuple As Tuple(Of Double), obj As Object)
      Try
         Console.WriteLine("{0} = {1}: {2}", tuple.ToString(),
                                             obj.ToString,
                                             DirectCAst(tuple, IStructuralEquatable).Equals(obj, New Tuple1Comparer()))
      
      Catch e As ArgumentException
         If obj.GetType.IsGenericType Then 
            If obj.GetType().Name = "Tuple`1" Then 
               Console.WriteLine("Cannot compare a Tuple(Of {0}) with a Tuple(Of {1}).", 
                              tuple.Item1.GetType().Name, obj.Item1.GetType().Name)
            Else
               Console.WriteLine("Cannot compare a {0} with a {1}.", tuple.GetType().Name, 
                                                                     obj.GetType().Name)
            End If
         Else
            Console.WriteLine("Cannot compare a {0} with a {1}.", tuple.GetType().Name,
                                                                  obj.GetType().Name)
         End If
      End Try
   End Sub
End Module
' The example displays the following output:
'       (12.3455) = (16.8912): False
'       (12.3455) = (12.3449599): True
' </Snippet2>

