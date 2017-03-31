' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      ' Get an array of n random integers.
      Dim values() As Integer = GetArray(50, 0, 1000)
      Dim lBound As Integer = 300
      Dim uBound As Integer = 600
      Dim matchedItems() As Integer = Array.FindAll(values, 
                                            Function(x) x >= lBound And x <= uBound)  
      For ctr As Integer = 0 To matchedItems.Length - 1
         Console.Write("{0}  ", matchedItems(ctr))
         If (ctr + 1) Mod 12 = 0 Then Console.WriteLine()
      Next
   End Sub
   
   Private Function GetArray(n As Integer, lower As Integer, 
                             upper As Integer) As Integer()
      Dim rnd As New Random()
      Dim list As New List(Of Integer)
      For ctr As Integer = 1 To n
         list.Add(rnd.Next(lower, upper + 1))
      Next
      Return list.ToArray()
   End Function
End Module
' The example displays output similar to the following:
'       542  398  356  351  348  301  562  599  575  400  569  306
'       535  416  393  385
' </Snippet1>
