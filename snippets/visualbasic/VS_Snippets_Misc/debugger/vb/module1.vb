'<snippet1>
Imports System
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Diagnostics

Module S

  Sub Main()

    pcount = Environment.ProcessorCount
    Console.WriteLine("Proc count = " + pcount.ToString())
    ThreadPool.SetMinThreads(4, -1)
    ThreadPool.SetMaxThreads(4, -1)

    t1 = New Task(AddressOf A, 1)
    t2 = New Task(AddressOf A, 2)
    t3 = New Task(AddressOf A, 3)
    t4 = New Task(AddressOf A, 4)
    Console.WriteLine("Starting t1 " + t1.Id.ToString())
    t1.Start()
    Console.WriteLine("Starting t2 " + t2.Id.ToString())
    t2.Start()
    Console.WriteLine("Starting t3 " + t3.Id.ToString())
    t3.Start()
    Console.WriteLine("Starting t4 " + t4.Id.ToString())
    t4.Start()

    Console.ReadLine()
  End Sub
  Sub A(ByVal o As Object)
    B(o)
  End Sub
  Sub B(ByVal o As Object)
    C(o)
  End Sub
  Sub C(ByVal o As Object)

    Dim temp As Integer = o

    Interlocked.Increment(aa)
    While (aa < 4)
    End While

    If (temp = 1) Then
      ' BP1 - all tasks in C
      Debugger.Break()
      waitFor1 = False
    Else
      While (waitFor1)
      End While
    End If
    Select Case temp
      Case 1
        D(o)
      Case 2
        F(o)
      Case 3, 4
        I(o)
      Case Else
        Debug.Assert(False, "fool")
    End Select
  End Sub
  Sub D(ByVal o As Object)
    E(o)
  End Sub
  Sub E(ByVal o As Object)
    ' break here at the same time as H and K
    While (bb < 2)
    End While
    'BP2 - 1 in E, 2 in H, 3 in J, 4 in K
    Debugger.Break()
    Interlocked.Increment(bb)

    'after
    L(o)
  End Sub
  Sub F(ByVal o As Object)
    G(o)
  End Sub
  Sub G(ByVal o As Object)
    H(o)
  End Sub
  Sub H(ByVal o As Object)
    ' break here at the same time as E and K
    Interlocked.Increment(bb)
    Monitor.Enter(mylock)
    While (bb < 3)
    End While
    Monitor.Exit(mylock)

    'after
    L(o)
  End Sub
  Sub I(ByVal o As Object)
    J(o)
  End Sub
  Sub J(ByVal o As Object)

    Dim temp2 As Integer = o

    Select Case temp2
      Case 3
        t4.Wait()
      Case 4
        K(o)
      Case Else
        Debug.Assert(False, "fool2")
    End Select
  End Sub
  Sub K(ByVal o As Object)
    ' break here at the same time as E and H
    Interlocked.Increment(bb)
    Monitor.Enter(mylock)
    While (bb < 3)
    End While
    Monitor.Exit(mylock)

    'after
    L(o)
  End Sub
  Sub L(ByVal oo As Object)
    Dim temp3 As Integer = oo

    Select Case temp3
      Case 1
        M(oo)
      Case 2
        N(oo)
      Case 4
        O(oo)
      Case Else
        Debug.Assert(False, "fool3")
    End Select
  End Sub
  Sub M(ByVal o As Object)
    ' breaks here at the same time as N and Q
    Interlocked.Increment(cc)
    While (cc < 3)
    End While

    'BP3 - 1 in M, 2 in N, 3 still in J, 4 in O, 5 in Q
    Debugger.Break()
    Interlocked.Increment(cc)
    While (True)
      Thread.Sleep(500) '  for ever
    End While
  End Sub
  Sub N(ByVal o As Object)
    ' breaks here at the same time as M and Q
    Interlocked.Increment(cc)
    While (cc < 4)
    End While
    R(o)
  End Sub
  Sub O(ByVal o As Object)
    Dim t5 As Task = Task.Factory.StartNew(AddressOf P, TaskCreationOptions.AttachedToParent)
    t5.Wait()
    R(o)
  End Sub
  Sub P()
    Console.WriteLine("t5 runs " + Task.CurrentId.ToString())
    Q()
  End Sub
  Sub Q()
    ' breaks here at the same time as N and M
    Interlocked.Increment(cc)
    While (cc < 4)
    End While
    ' task 5 dies here freeing task 4 (its parent)
    Console.WriteLine("t5 dies " + Task.CurrentId.ToString())
    waitFor5 = False
  End Sub
  Sub R(ByVal o As Object)
    If (o = 2) Then
      ' wait for task5 to die
      While waitFor5
      End While

      '//spin up all procs
      Dim i As Integer
      For i = 0 To pcount - 4 - 1

        Dim t As Task = Task.Factory.StartNew(Sub()
                                                While True

                                                End While
                                              End Sub)
        Console.WriteLine("Started task " + t.Id.ToString())
      Next

      Task.Factory.StartNew(AddressOf T, i + 1 + 5, TaskCreationOptions.AttachedToParent) ' //scheduled
      Task.Factory.StartNew(AddressOf T, i + 2 + 5, TaskCreationOptions.AttachedToParent) ' //scheduled
      Task.Factory.StartNew(AddressOf T, i + 3 + 5, TaskCreationOptions.AttachedToParent) ' //scheduled
      Task.Factory.StartNew(AddressOf T, i + 4 + 5, TaskCreationOptions.AttachedToParent) ' //scheduled
      Task.Factory.StartNew(AddressOf T, (i + 5 + 5).ToString(), TaskCreationOptions.AttachedToParent) ' //scheduled

      '//BP4 - 1 in M, 2 in R, 3 in J, 4 in R, 5 died
      Debugger.Break()

    Else
      Debug.Assert(o = 4)
      t3.Wait()
    End If
  End Sub
  Sub T(ByVal o As Object)
    Console.WriteLine("Scheduled run " + Task.CurrentId.ToString())
  End Sub
  Private t1, t2, t3, t4 As Task
  Private aa As Integer = 0
  Private bb As Integer = 0
  Private cc As Integer = 0
  Private waitFor1 As Boolean = True
  Private waitFor5 As Boolean = True
  Private pcount As Integer
  Private mylock As New S2()
End Module

Public Class S2

End Class
'</snippet1>