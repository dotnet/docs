' Visual Basic .NET Document
Option Strict On

Imports System.Threading
Imports System.Threading.Tasks

Class Example
    ' <Snippet13>
    Shared N As Integer = 3

    Shared m_throttle As New SemaphoreSlim(N, N)

    Shared Async Function DoOperation() As Task
        Await m_throttle.WaitAsync()
        ' Do work.
        m_throttle.Release()
    End Function
    ' </Snippet13>
End Class

