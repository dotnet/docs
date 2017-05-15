' <Snippet1>
Imports System.Threading
Imports System.Runtime.CompilerServices
Imports System.Runtime.ConstrainedExecution

' Demonstrate CERs using abrupt thread aborts. Demonstrate there
' is always a finally invocation for any CER that is entered.
Public Module Example
   Public Function Main() As Integer
      ' Run the test a few times--it is timing dependent. The argument 
      ' passed in is the stack depth to create.
      For i As Integer = 0 To 999
         If Not Test(i Mod 5)
            Console.WriteLine("Failed")
            Return 0
         End If
      Next
      Console.WriteLine("Succeeded")
      Return 100
   End Function

   ' Create a thread and tell it to create a stack of the required depth. 
   ' The first 3 levels will contain CERs, those after will not. Wait for 
   ' the thread to start up, but abort it immediately. The thread may be 
   ' in the process of setting the stack up at the point the abort occurs.
   ' Check a state variable after the thread exits to determine if there is 
   ' a consistent state following the abort. Each level of the stack with a
   ' CER maintains a consistency variable that is reset on entry to the try 
   ' and set in the corresponding finally block. None of these variables 
   ' should be in a reset state after aborting the thread.
   Function Test(d As Integer) As Boolean
      ' Create the context for the thread. This sets the stack depth for 
      ' the thread and gives the final consistency state after the abort.
      Dim wu As New WorkUnit(d)

      ' Create and start the thread.
      Dim t As New Thread(AddressOf wu.StackDepth1)
      t.Start()

      ' Wait until the thread is ready to begin.
      wu.wait.WaitOne()

      ' Abort immediately. This will occassionally interrupt the thread 
      ' as it is setting up the stack, which is good.
      t.Abort()

      ' Wait for the thread to exit.
      t.Join()

      ' Check the final state for consistency.
      Return wu.consistentLevel1
   End Function
End Module

' Context class for the thread worker.
Class WorkUnit
   Public wait As EventWaitHandle
   Public consistentLevel1 As Boolean
   Public consistentLevel2 As Boolean
   Public consistentLevel3 As Boolean
   Public depth As Integer

   Public Sub New(d As Integer)
      wait = New EventWaitHandle(False, EventResetMode.AutoReset)
      depth = d
   End Sub

   ' <Snippet2>
   Public Sub StackDepth1()
      ' Declare the root CER.
      RuntimeHelpers.PrepareConstrainedRegions()
      Try
         ' Cannot be interrupted until the event set below, so set up 
         ' for initial success. Level 1 consistency is achieved by 
         ' executing the finally the other two levels are assumed 
         ' consistent.
         consistentLevel1 = False
         consistentLevel2 = True
         consistentLevel3 = True

         ' Signal the parent thread. From this point on, the thread 
         ' can be aborted.
         wait.Set()

         ' Halt now if we want a one-level stack.
         If depth = 1 Then Thread.Sleep(-1)

         ' Else move to the next level.
         StackDepth2()
      Finally
         ' We should always get here. Compute consistency based on 
         ' all the levels.
         consistentLevel1 = consistentLevel2 And consistentLevel3
      End Try
   End Sub
   ' </Snippet2>

   ' <Snippet3>
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
   ' </Snippet3>

   <ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)>
   <MethodImpl(MethodImplOptions.NoInlining)>
   Sub StackDepth3()
      Try
         consistentLevel3 = False
         if depth = 3 Then Thread.Sleep(-1)
         StackDepth4()
      Finally
         consistentLevel3 = True
      End Try
   End Sub

   <MethodImpl(MethodImplOptions.NoInlining)>
   Sub StackDepth4()
      If depth = 4 Then Thread.Sleep(-1)
      StackDepth5()
   End Sub

   <MethodImpl(MethodImplOptions.NoInlining)>
   Sub StackDepth5()
        Thread.Sleep(-1)
   End Sub
End Class
' </Snippet1>
