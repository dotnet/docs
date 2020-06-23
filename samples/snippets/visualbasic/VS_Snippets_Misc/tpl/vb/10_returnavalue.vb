Option Strict On

' <snippet10>
Imports System.Threading.Tasks

Module Module1

    Sub Main()
        ReturnAValue()

        Console.WriteLine("Press any key to exit.")
        Console.ReadKey()

    End Sub

    Sub ReturnAValue()

        ' Return a value type with a lambda expression
        Dim task1 = Task(Of Integer).Factory.StartNew(Function() 1)
        Dim i As Integer = task1.Result

        ' Return a named reference type with a multi-line statement lambda.
        Dim task2 As Task(Of Test) = Task.Factory.StartNew(Function()
                                                               Dim s As String = ".NET"
                                                               Dim d As Integer = 4
                                                               Return New Test With {.Name = s, .Number = d}
                                                           End Function)

        Dim myTest As Test = task2.Result
        Console.WriteLine(myTest.Name & ": " & myTest.Number)

        ' Return an array produced by a PLINQ query.
        Dim task3 As Task(Of String()) = Task(Of String()).Factory.StartNew(Function()

                                                                                Dim path = "C:\Users\Public\Pictures\Sample Pictures\"
                                                                                Dim files = System.IO.Directory.GetFiles(path)

                                                                                Dim result = (From file In files.AsParallel()
                                                                                              Let info = New System.IO.FileInfo(file)
                                                                                              Where info.Extension = ".jpg"
                                                                                              Select file).ToArray()
                                                                                Return result
                                                                            End Function)

        For Each name As String In task3.Result
            Console.WriteLine(name)
        Next
    End Sub

    Class Test
        Public Name As String
        Public Number As Double
    End Class
End Module
'</snippet10>
