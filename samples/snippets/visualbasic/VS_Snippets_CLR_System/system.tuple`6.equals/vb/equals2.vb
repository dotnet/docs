' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections

Public Class RateComparer(Of T1, T2, T3, T4, T5, T6) : Implements IEqualityComparer
   Private argument As Integer = 0

   Public Overloads Function Equals(x As Object, y As Object) As Boolean _
                   Implements IEqualityComparer.Equals
      argument += 1
      If argument = 1 Then
         Return True
      Else
         Dim fx, fy As Double
         If typeof x Is Double Or typeof x Is Single Then
            fx = CDbl(x)
            fy = CDbl(y)
            Return Math.Round(fx * 1000).Equals(Math.Round(fy * 1000))
         Else
            Return x.Equals(y)
         End If
      End If   
   End Function
   
   Public Overloads Function GetHashCode(obj As Object) As Integer _
                    Implements IEqualityComparer.GetHashCode
      If TypeOf(obj) Is Single Or TypeOf(obj) Is Double Then
         Return Math.Round(CDbl(obj) * 1000).GetHashCode()
      Else
         Return obj.GetHashCode()
      End If
   End Function                
End Class

Module Example
   Public Sub Main()
      Dim rate1 = Tuple.Create("New York", .014505, -.1042733, 
                               .0354833, .093644, .0290792)
      Dim rate2 = Tuple.Create("Unknown City", .014505, -.1042733, 
                               .0354833, .093644, .0290792)
      Dim rate3 = Tuple.Create("Unknown City", .014505, -.1042733, 
                               .0354833, .093644, .029079)
      Dim rate4 = Tuple.Create("San Francisco", -.0332858, -.0512803, 
                               .0662544, .0728964, .0491912)
      Dim eq As IStructuralEquatable = rate1
      ' Compare first tuple with remaining two tuples.
      Console.WriteLine("{0} = ", rate1.ToString())
      Console.WriteLine("   {0} : {1}", rate2, 
                        eq.Equals(rate2, New RateComparer(Of String, Double, Double, Double, Double, Double)()))
      Console.WriteLine("   {0} : {1}", rate3, 
                        eq.Equals(rate3, New RateComparer(Of String, Double, Double, Double, Double, Double)()))
      Console.WriteLine("   {0} : {1}", rate4, 
                        eq.Equals(rate4, New RateComparer(Of String, Double, Double, Double, Double, Double)()))
   End Sub
End Module
' The example displays the following output:
'    (New York, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.0290792) =
'       (Unknown City, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.0290792) : True
'       (Unknown City, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.029079) : True
'       (San Francisco, -0.0332858, -0.0512803, 0.0662544, 0.0728964, 0.0491912) : False
' </Snippet2>
