' Visual Basic .NET Document
Option Strict On

' Imports System.Collections
' Imports System.Linq

' <Snippet8>
<Assembly: CLSCompliant(True)>

Public Class Numbers
   Public Shared Function GetTenPrimes() As Array
      Dim arr As Array = Array.CreateInstance(GetType(Int32), {10}, {1})
      arr.SetValue(1, 1)
      arr.SetValue(2, 2)
      arr.SetValue(3, 3)
      arr.SetValue(5, 4)
      arr.SetValue(7, 5)
      arr.SetValue(11, 6)
      arr.SetValue(13, 7)
      arr.SetValue(17, 8)
      arr.SetValue(19, 9)
      arr.SetValue(23, 10)
      
      Return arr
   End Function
End Class
' </Snippet8>

Module Example
   Public Sub Main()
      For Each number In Numbers.GetTenPrimes()
         Console.WriteLine(number)
      Next   
   End Sub
End Module

