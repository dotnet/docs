' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.IO
Imports System.Threading

Module Example5
    Public Sub Main()
        ' Initialize flag variables.
        Dim isRedirected, isBoth As Boolean
        Dim fileName As String = ""
        Dim sw As StreamWriter = Nothing

        ' Get any command line arguments.
        Dim args() As String = Environment.GetCommandLineArgs()
        ' Handle any arguments.
        If args.Length > 1 Then
            For ctr = 1 To args.Length - 1
                Dim arg As String = args(ctr)
                If arg.StartsWith("/") OrElse arg.StartsWith("-") Then
                    Select Case arg.Substring(1).ToLower()
                        Case "f"
                            isRedirected = True
                            If args.Length < ctr + 2 Then
                                ShowSyntax("The /f switch must be followed by a filename.")
                                Exit Sub
                            End If
                            fileName = args(ctr + 1)
                            ctr += 1
                        Case "b"
                            isBoth = True
                        Case Else
                            ShowSyntax(String.Format("The {0} switch is not supported",
                                              args(ctr)))
                            Exit Sub
                    End Select
                End If
            Next
        End If

        ' If isBoth is True, isRedirected must be True.
        If isBoth And Not isRedirected Then
            ShowSyntax("The /f switch must be used if /b is used.")
            Exit Sub
        End If

        ' Handle output.
        If isRedirected Then
            sw = New StreamWriter(fileName)
            If Not isBoth Then
                Console.SetOut(sw)
            End If
        End If
        Dim msg As String = String.Format("Application began at {0}", Date.Now)
        Console.WriteLine(msg)
        If isBoth Then sw.WriteLine(msg)
        Thread.Sleep(5000)
        msg = String.Format("Application ended normally at {0}", Date.Now)
        Console.WriteLine(msg)
        If isBoth Then sw.WriteLine(msg)
        If isRedirected Then sw.Close()
    End Sub

    Private Sub ShowSyntax(errMsg As String)
        Console.WriteLine(errMsg)
        Console.WriteLine()
        Console.WriteLine("Syntax: Example [[/f <filename> [/b]]")
        Console.WriteLine()
    End Sub
End Module
' </Snippet10>


Public Class Evaluation
    Public Sub SomeMethod()
        Dim booleanValue As Boolean

        ' <Snippet11>
        If booleanValue = True Then
            ' </Snippet11>
        End If

        ' <Snippet12>
        If booleanValue Then
            ' </Snippet12>
        End If
    End Sub
End Class
