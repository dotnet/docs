'<snippet1>
Imports System

Namespace WaitForPendingFinalizersExample
   Class MyWaitForPendingFinalizersClass
  
    ' You can increase this number to fill up more memory.
      Private Const numMfos As Integer = 1000
      ' You can increase this number to cause more
      ' post-finalization work to be done.
      Private Const maxIterations As Integer = 100
     
      Overloads Shared Sub Main()
         Dim mfo As MyFinalizeObject = Nothing
      
         ' Create and release a large number of objects
         ' that require finalization.
         Dim j As Integer
         For j = 0 To numMfos - 1
            mfo = New MyFinalizeObject()
         Next j
      
         'Release the last object created in the loop.
         mfo = Nothing
      
         'Force garbage collection.
         GC.Collect()
      
         ' Wait for all finalizers to complete before continuing.
         ' Without this call to GC.WaitForPendingFinalizers, 
         ' the worker loop below might execute at the same time 
         ' as the finalizers.
         ' With this call, the worker loop executes only after
         ' all finalizers have been called.
         GC.WaitForPendingFinalizers()
      
         ' Worker loop to perform post-finalization code.
         Dim i As Integer
         For i = 0 To maxIterations - 1
            Console.WriteLine("Doing some post-finalize work")
         Next i
      End Sub
   End Class


   Class MyFinalizeObject
      ' Make this number very large to cause the finalizer to
      ' do more work.
      Private maxIterations As Integer = 10000
      
      Protected Overrides Sub Finalize()
         Console.WriteLine("Finalizing a MyFinalizeObject")
      
         ' Do some work.
         Dim i As Integer
         For i = 0 To maxIterations - 1
            ' This method performs no operation on i, but prevents 
            ' the JIT compiler from optimizing away the code inside 
            ' the loop.
            GC.KeepAlive(i)
         Next i
         MyBase.Finalize()
      End Sub
   End Class
End Namespace
'</snippet1>