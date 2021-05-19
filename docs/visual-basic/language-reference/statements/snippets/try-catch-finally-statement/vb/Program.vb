Option Strict On

Imports System

Module Program
    Sub Main(args As String())

        Console.WriteLine("=================    Try Catch statement Examples ======================")
        Dim examples As AsyncExceptionExamples = New AsyncExceptionExamples()
        Task.WaitAll(examples.DoSomethingAsync())
        Task.WaitAll(examples.DoMultipleAsync())

    End Sub
End Module
