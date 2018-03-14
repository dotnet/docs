'<snippet01>
Imports System.Threading
Imports System.Threading.Tasks
Module BarrierSample

    ' Demonstrates:
    ' Barrier constructor with post-phase action
    ' Barrier.AddParticipants()
    ' Barrier.RemoveParticipant()
    ' Barrier.SignalAndWait(), incl. a BarrierPostPhaseException being thrown
    Sub Main()
        Dim count As Integer = 0

        ' Create a barrier with three participants
        ' Provide a post-phase action that will print out certain information
        ' And the third time through, it will throw an exception
        Dim barrier As New Barrier(3,
                                   Sub(b)
                                       Console.WriteLine("Post-Phase action: count={0}, phase={1}", count, b.CurrentPhaseNumber)
                                       If b.CurrentPhaseNumber = 2 Then
                                           Throw New Exception("D'oh!")
                                       End If
                                   End Sub)

        ' Nope -- changed my mind. Let's make it five participants.
        barrier.AddParticipants(2)

        ' Nope -- let's settle on four participants.
        barrier.RemoveParticipant()


        ' This is the logic run by all participants
        Dim action As Action =
            Sub()
                Interlocked.Increment(count)
                barrier.SignalAndWait()
                ' during the post-phase action, count should be 4 and phase should be 0

                Interlocked.Increment(count)
                barrier.SignalAndWait()
                ' during the post-phase action, count should be 8 and phase should be 1

                ' The third time, SignalAndWait() will throw an exception and all participants will see it
                Interlocked.Increment(count)
                Try
                    barrier.SignalAndWait()
                Catch bppe As BarrierPostPhaseException
                    Console.WriteLine("Caught BarrierPostPhaseException: {0}", bppe.Message)
                End Try

                ' The fourth time should be hunky-dory
                Interlocked.Increment(count)
                ' during the post-phase action, count should be 16 and phase should be 3
                barrier.SignalAndWait()

            End Sub

        ' Now launch 4 parallel actions to serve as 4 participants
        Parallel.Invoke(action, action, action, action)

        ' This (5 participants) would cause an exception:
        '   Parallel.Invoke(action, action, action, action, action)
        ' "System.InvalidOperationException: The number of threads using the barrier
        ' exceeded the total number of registered participants."

        ' It's good form to Dispose() a barrier when you're done with it.
        barrier.Dispose()
    End Sub
End Module
'</snippet01>
