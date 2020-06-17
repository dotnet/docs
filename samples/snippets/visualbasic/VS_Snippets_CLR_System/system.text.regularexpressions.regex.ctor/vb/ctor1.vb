' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Security
Imports System.Text.RegularExpressions
Imports System.Threading

Module Example
    Const MaxTimeoutInSeconds As Integer = 3

    Public Sub Main()
        Dim pattern As String = "(a+)+$"    ' DO NOT REUSE THIS PATTERN.
        Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1))
        Dim sw As Stopwatch = Nothing

        Dim inputs() As String = {"aa", "aaaa>",
                                   "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                                   "aaaaaaaaaaaaaaaaaaaaaa>",
                                   "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>"}

        For Each inputValue In inputs
            Console.WriteLine("Processing {0}", inputValue)
            Dim timedOut As Boolean = False
            Do
                Try
                    sw = Stopwatch.StartNew()
                    ' Display the result.
                    If rgx.IsMatch(inputValue) Then
                        sw.Stop()
                        Console.WriteLine("Valid: '{0}' ({1:ss\.fffffff} seconds)",
                                          inputValue, sw.Elapsed)
                    Else
                        sw.Stop()
                        Console.WriteLine("'{0}' is not a valid string. ({1:ss\.fffff} seconds)",
                                          inputValue, sw.Elapsed)
                    End If
                Catch e As RegexMatchTimeoutException
                    sw.Stop()
                    ' Display the elapsed time until the exception.
                    Console.WriteLine("Timeout with '{0}' after {1:ss\.fffff}",
                                      inputValue, sw.Elapsed)
                    Thread.Sleep(1500)       ' Pause for 1.5 seconds.

                    ' Increase the timeout interval and retry.
                    Dim timeout As TimeSpan = e.MatchTimeout.Add(TimeSpan.FromSeconds(1))
                    If timeout.TotalSeconds > MaxTimeoutInSeconds Then
                        Console.WriteLine("Maximum timeout interval of {0} seconds exceeded.",
                                          MaxTimeoutInSeconds)
                        timedOut = False
                    Else
                        Console.WriteLine("Changing the timeout interval to {0}",
                                          timeout)
                        rgx = New Regex(pattern, RegexOptions.IgnoreCase, timeout)
                        timedOut = True
                    End If
                End Try
            Loop While timedOut
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays output like the following:
'    Processing aa
'    Valid: 'aa' (00.0000779 seconds)
'    
'    Processing aaaa>
'    'aaaa>' is not a valid string. (00.00005 seconds)
'    
'    Processing aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
'    Valid: 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa' (00.0000043 seconds)
'    
'    Processing aaaaaaaaaaaaaaaaaaaaaa>
'    Timeout with 'aaaaaaaaaaaaaaaaaaaaaa>' after 01.00469
'    Changing the timeout interval to 00:00:02
'    Timeout with 'aaaaaaaaaaaaaaaaaaaaaa>' after 02.01202
'    Changing the timeout interval to 00:00:03
'    Timeout with 'aaaaaaaaaaaaaaaaaaaaaa>' after 03.01043
'    Maximum timeout interval of 3 seconds exceeded.
'    
'    Processing aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>
'    Timeout with 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>' after 03.01018
'    Maximum timeout interval of 3 seconds exceeded.
' </Snippet1>
