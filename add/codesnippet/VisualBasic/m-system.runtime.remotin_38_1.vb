      ' Creates an instance of a context-bound type SampleSynchronized.
      Dim sampSyncObj As New SampleSynchronized()
      
      ' Checks whether the object is a proxy, since it is context-bound.
      If RemotingServices.IsTransparentProxy(sampSyncObj) Then
         Console.WriteLine("sampSyncObj is a proxy.")
      Else
         Console.WriteLine("sampSyncObj is NOT a proxy.")
      End If 