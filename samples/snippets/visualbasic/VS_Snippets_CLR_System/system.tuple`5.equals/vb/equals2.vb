' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections

Public Class DoubleComparer(Of T1, T2, T3, T4, T5) : Implements IEqualityComparer
   Private difference As Double
   Private argument As Integer = 0
   
   Public Sub New(difference As Double)
      Me.difference = difference
   End Sub
   
   Public Overloads Function Equals(x As Object, y As Object) As Boolean _
                   Implements IEqualityComparer.Equals
      argument += 1
      
      ' Return true for Item1.
      If argument = 1 Then
         Return True
      Else
         Dim d1 As Double = CDbl(x)
         Dim d2 As Double = CDbl(y)
         If d1 - d2 < d1 * difference Then
            Return True
         Else            
            Return False
         End If
      End If
   End Function
   
   Public Overloads Function GetHashCode(obj As Object) As Integer _
                    Implements IEqualityComparer.GetHashCode
      If TypeOf obj Is T1 Then
         Return CType(obj, T1).GetHashCode()
      ElseIf TypeOf obj Is T2 Then
         Return CType(obj, T2).GetHashCode()
      ElseIf TypeOf obj Is T3 Then
         Return CType(Obj, T3).GetHashCode()
      ElseIf TypeOf obj Is T4 Then
         Return CType(Obj, T4).GetHashCode()
      Else	
         Return CType(obj, T5).GetHashCode()
      End If
   End Function                
End Class

Module Example
   Public Sub Main()
      Dim value1 = GetValues(1)
      Dim value2 = GetValues(2)
      Dim iValue1 As IStructuralEquatable = value1
      Console.WriteLine("{0} ={3}{1} :{3}{2}", value1, value2, _
                        iValue1.Equals(value2, _
                        New DoubleComparer(Of Integer, Double, Double, Double, Double)(.01)), _
                        vbCrLf)
   End Sub
   
   Private Function GetValues(ctr As Integer) As Tuple(Of Integer, Double, Double, Double, Double)
      ' Generate four random numbers between 0 and 1
      Dim rnd As New Random(CInt((DateTime.Now.Ticks >> 32) >> ctr))
      Return Tuple.Create(ctr, rnd.NextDouble(), rnd.NextDouble(), 
                          rnd.NextDouble(), rnd.NextDouble)
   End Function                                   
End Module
' The example displays output like the following:
'    (1, 0.910850029862882, 0.894596965934428, 0.319678635019659, 0.801647342649124) =
'    (2, 0.818546649915421, 0.355961162762698, 0.0438506622071614, 0.679904267042831) :
'    False
' </Snippet2>
