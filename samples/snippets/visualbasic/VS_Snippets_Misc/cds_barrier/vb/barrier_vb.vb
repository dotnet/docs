'<snippet01>
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks


Class Program
    Shared words1() = New String() {"brown", "jumps", "the", "fox", "quick"}
    Shared words2() = New String() {"dog", "lazy", "the", "over"}
    Shared solution = "the quick brown fox jumps over the lazy dog."

    Shared success = False
    Shared barrier = New Barrier(2, Sub(b)
                                        Dim sb = New StringBuilder()
                                        For i As Integer = 0 To words1.Length - 1
                                            sb.Append(words1(i))
                                            sb.Append(" ")
                                        Next
                                        For i As Integer = 0 To words2.Length - 1

                                            sb.Append(words2(i))

                                            If (i < words2.Length - 1) Then
                                                sb.Append(" ")
                                            End If
                                        Next
                                        sb.Append(".")
                                        System.Diagnostics.Trace.WriteLine(sb.ToString())

                                        Console.CursorLeft = 0
                                        Console.Write("Current phase: {0}", barrier.CurrentPhaseNumber)
                                        If (String.CompareOrdinal(solution, sb.ToString()) = 0) Then
                                            success = True
                                            Console.WriteLine()
                                            Console.WriteLine("The solution was found in {0} attempts", barrier.CurrentPhaseNumber)
                                        End If
                                    End Sub)

    Shared Sub Main()
        Dim t1 = New Thread(Sub() Solve(words1))
        Dim t2 = New Thread(Sub() Solve(words2))
        t1.Start()
        t2.Start()

        ' Keep the console window open.
        Console.ReadLine()
    End Sub

    ' Use Knuth-Fisher-Yates shuffle to randomly reorder each array.
    ' For simplicity, we require that both wordArrays be solved in the same phase.
    ' Success of right or left side only is not stored and does not count.       
    Shared Sub Solve(ByVal wordArray As String())
        While success = False
            Dim rand = New Random()
            For i As Integer = 0 To wordArray.Length - 1
                Dim swapIndex As Integer = rand.Next(i + 1)
                Dim temp As String = wordArray(i)
                wordArray(i) = wordArray(swapIndex)
                wordArray(swapIndex) = temp
            Next

            ' We need to stop here to examine results
            ' of all thread activity. This is done in the post-phase
            ' delegate that is defined in the Barrier constructor.
            barrier.SignalAndWait()
        End While
    End Sub
End Class
'</snippet01>


Class BarrierDemo

    Friend success As Boolean
    Friend someCondition As Boolean
    Dim results() As Byte
    Dim myData()() As Byte
    Function ProcessData(ByVal d As Byte())
        Return New Byte()
    End Function
    '<snippet02>

    ' Create the Barrier object, and supply a post-phase delegate 
    ' to be invoked at the end of each phase.
    Dim barrier = New Barrier(2, Sub(bar)
                                     ' Examine results from all threads, determine 
                                     ' whether to continue, create inputs for next phase, etc. 
                                     If (someCondition) Then
                                         success = True
                                     End If
                                 End Sub)



    ' Define the work that each thread will perform. (Threads do not
    ' have to all execute the same method.)
    Sub CrunchNumbers(ByVal partitionNum As Integer)

        ' Up to System.Int64.MaxValue phases are supported. We assume
        ' in this code that the problem will be solved before that.
        While (success = False)

            ' Begin phase:
            ' Process data here on each thread, and optionally
            ' store results, for example:
            results(partitionNum) = ProcessData(myData(partitionNum))

            ' End phase:
            ' After all threads arrive,post-phase delegate
            ' is invoked, then threads are unblocked. Overloads
            ' accept a timeout value and/or CancellationToken.
            barrier.SignalAndWait()
        End While
    End Sub

    ' Perform n tasks to run in parallel. For simplicity
    ' all threads execute the same method in this example.
    Shared Sub Main()

        Dim app = New BarrierDemo()
        Dim t1 = New Thread(Sub() app.CrunchNumbers(0))
        Dim t2 = New Thread(Sub() app.CrunchNumbers(1))
        t1.Start()
        t2.Start()
    End Sub
    '</snippet02>
End Class
