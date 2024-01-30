' Visual Basic .NET Document
Option Strict On

Imports System.Runtime.CompilerServices
Imports System.Threading

Module Example5
    Public Sub Main()
        ' <Snippet2>
        ' Define the lock object.
        Dim obj As New Object()

        ' Define the critical section.
        Monitor.Enter(obj)
        Try
            ' Code to execute one thread at a time.

            ' catch blocks go here.
        Finally
            Monitor.Exit(obj)
        End Try
        ' </Snippet2> 
    End Sub

    ' <Snippet3>
    <MethodImplAttribute(MethodImplOptions.Synchronized)>
    Sub MethodToLock()
        ' Method implementation.
    End Sub
    ' </Snippet3>
End Module

