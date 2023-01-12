' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Threading

Namespace Child
    Module Example
        Public Sub Main()
            Dim parent = Task.Factory.StartNew(Sub()
                                                   Console.WriteLine("Parent task beginning.")
                                                   For ctr As Integer = 0 To 9
                                                       Dim taskNo As Integer = ctr
                                                       Task.Factory.StartNew(Sub(x)
                                                                                 Thread.SpinWait(5000000)
                                                                                 Console.WriteLine("Attached child #{0} completed.",
                                                                                                 x)
                                                                             End Sub,
                                                       taskNo, TaskCreationOptions.AttachedToParent)
                                                   Next
                                               End Sub)
            parent.Wait()
            Console.WriteLine("Parent task completed.")
        End Sub
    End Module
    ' The example displays output like the following:
    '       Parent task beginning.
    '       Attached child #9 completed.
    '       Attached child #0 completed.
    '       Attached child #8 completed.
    '       Attached child #1 completed.
    '       Attached child #7 completed.
    '       Attached child #2 completed.
    '       Attached child #6 completed.
    '       Attached child #3 completed.
    '       Attached child #5 completed.
    '       Attached child #4 completed.
    '       Parent task completed.
End Namespace
' </Snippet8>
