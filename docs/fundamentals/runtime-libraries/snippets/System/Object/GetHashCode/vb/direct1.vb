﻿' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Structure Number
   Private n As Integer

   Public Sub New(value As Integer)
      n = value
   End Sub

   Public ReadOnly Property Value As Integer
      Get
         Return n
      End Get
   End Property
   
   Public Overrides Function Equals(obj As Object) As Boolean
      If obj Is Nothing OrElse Not TypeOf obj Is Number Then
         Return False
      Else
         Return n = CType(obj, Number).n
      End If
   End Function      
   
   Public Overrides Function GetHashCode() As Integer
      Return n
   End Function
   
   Public Overrides Function ToString() As String
      Return n.ToString()
   End Function
End Structure

Module Example
   Public Sub Main()
      Dim rnd As New Random()
      For ctr As Integer = 0 To 9
         Dim randomN As Integer = rnd.Next(Int32.MinValue, Int32.MaxValue)
         Dim n As New Number(randomN)
         Console.WriteLine("n = {0,12}, hash code = {1,12}", n, n.GetHashCode())
      Next
   End Sub
End Module
' The example displays output like the following:
'       n =   -634398368, hash code =   -634398368
'       n =   2136747730, hash code =   2136747730
'       n =  -1973417279, hash code =  -1973417279
'       n =   1101478715, hash code =   1101478715
'       n =   2078057429, hash code =   2078057429
'       n =   -334489950, hash code =   -334489950
'       n =    -68958230, hash code =    -68958230
'       n =   -379951485, hash code =   -379951485
'       n =    -31553685, hash code =    -31553685
'       n =   2105429592, hash code =   2105429592
' </Snippet1>
