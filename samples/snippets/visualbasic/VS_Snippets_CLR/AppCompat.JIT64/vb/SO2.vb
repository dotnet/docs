Imports System.Runtime.CompilerServices

Public Module Example
   Public Sub Main()
   End Sub

   ' <Snippet5>
   <MethodImpl(MethodImplOptions.NoOptimization)>
   Public Function TestCondition(i As Integer) As Boolean
      '  Calls to methods that perform bit tests.
      Return Test1(i) AndAlso Test2(i) AndAlso Test3(i)
   End Function
   ' </Snippet5>

   Public Function Test1(i As Integer) As Boolean
      Return True
   End Function
   Public Function Test2(i As Integer) As Boolean
      Return True
   End Function
   Public Function Test3(i As Integer) As Boolean
      Return True
   End Function
End Module
