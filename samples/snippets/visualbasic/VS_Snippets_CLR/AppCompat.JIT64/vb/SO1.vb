Imports System.Runtime.CompilerServices

Public Module Example
   Public Sub Main()
   End Sub

   ' <Snippet1>
   <MethodImpl(MethodImplOptions.NoOptimization)>
   Public Sub LargeMethodBody() 
   ' </Snippet1>
   End Sub
   
   ' <Snippet2>
   <MethodImpl(MethodImplOptions.AggressiveInlining)>
   Public Function ReturnSomeValue() As Integer
   ' </Snippet2>
      Return 10
   End Function

   ' <Snippet3>
   <MethodImpl(MethodImplOptions.NoOptimization)>
   Public Sub MethodWithExceptionHandler(flag As Boolean)
      If flag Then
         ' Execute code conditionally.
      End If
      Try   
         ' Throw here.
         
         If flag Then
            ' Code to execute conditionally. 
         End If
      Catch e As Exception     ' Turning off optimization prevents the compiler from
                               ' removing the if condition and executing the block
                               ' unconditionally. 
         If flag Then 
            ' Code to execute conditionally. 
         End If  
      End Try   
   End Sub
   ' </Snippet3>

   ' <Snippet4>
   <MethodImpl(MethodImplOptions.NoOptimization)>
   Public Function TestCondition(i As Integer) As Boolean
      '  Calls to methods that perform bit tests.
      Return Test1(i) AndAlso Test2(i) AndAlso Test3(i)
   End Function
   ' </Snippet4>

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
