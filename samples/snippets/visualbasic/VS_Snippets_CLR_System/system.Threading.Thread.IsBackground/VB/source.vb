' <Snippet1>
Imports System.Threading

Public Module Example
    Public Sub Main()
        Dim shortTest As New BackgroundTest(10)
        Dim foregroundThread As New Thread(AddressOf shortTest.RunLoop)

        Dim longTest As New BackgroundTest(50)
        Dim backgroundThread As New Thread(AddressOf longTest.RunLoop)
        backgroundThread.IsBackground = True

        foregroundThread.Start()
        backgroundThread.Start()
    End Sub
End Module

Public Class BackgroundTest
    Dim maxIterations As Integer 

    Sub New(maximumIterations As Integer)
        maxIterations = maximumIterations
    End Sub

    Sub RunLoop()
        For i As Integer = 0 To maxIterations
            Console.WriteLine("{0} count: {1}", _
                    If(Thread.CurrentThread.IsBackground, 
                       "Background Thread", "Foreground Thread"), i)
            Thread.Sleep(250)
        Next 

        Console.WriteLine("{0} finished counting.", 
                          If(Thread.CurrentThread.IsBackground, 
                          "Background Thread", "Foreground Thread"))
    End Sub
End Class
' The example displays output like the following:
'    Foreground Thread count: 0
'    Background Thread count: 0
'    Background Thread count: 1
'    Foreground Thread count: 1
'    Foreground Thread count: 2
'    Background Thread count: 2
'    Foreground Thread count: 3
'    Background Thread count: 3
'    Background Thread count: 4
'    Foreground Thread count: 4
'    Foreground Thread count: 5
'    Background Thread count: 5
'    Foreground Thread count: 6
'    Background Thread count: 6
'    Background Thread count: 7
'    Foreground Thread count: 7
'    Background Thread count: 8
'    Foreground Thread count: 8
'    Foreground Thread count: 9
'    Background Thread count: 9
'    Background Thread count: 10
'    Foreground Thread count: 10
'    Background Thread count: 11
'    Foreground Thread finished counting.
' </Snippet1>