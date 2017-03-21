   <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)>
   <MethodImpl(MethodImplOptions.NoInlining)>
   Sub StackDepth2()
      Try
         consistentLevel2 = False
         If depth = 2 Then Thread.Sleep(-1)
         StackDepth3()
      Finally
         consistentLevel2 = True
      End Try
   End Sub