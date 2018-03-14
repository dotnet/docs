' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Security
Imports System.Text.RegularExpressions
Imports System.Threading

Module Example
   Const MaxTimeoutInSeconds As Integer = 2
   
   Public Sub Main()
      Dim timeout As TimeSpan = New TimeSpan(0, 0, 1)
      
      Dim input As String = "aaaaaaaaaaaaaaaaaaaaaa>"
      If ValidateInput(input, timeout) Then
         ' Perform some operation with valid input string.
         Console.WriteLine("'{0}' is a valid string.", input) 
      End If
   End Sub 

   Private Function ValidateInput(input As String, 
                                  timeout As TimeSpan) As Boolean
      Dim pattern As String = "(a+)+$"      
      Try
         Return Regex.IsMatch(input, pattern, 
                              RegexOptions.IgnoreCase, timeout)
      Catch e As RegexMatchTimeoutException
         ' Increase the timeout interval and retry.
         timeout = timeout.Add(New TimeSpan(0, 0, 1))
         Console.WriteLine("Changing the timeout interval to {0}", 
                           timeout) 
         If timeout.TotalSeconds <= MaxTimeoutInSeconds Then
            ' Pause for a short interval.
            Thread.Sleep(250)
            Return ValidateInput(input, timeout)
         Else
            Console.WriteLine("Timeout interval of {0} exceeded.", 
                              timeout)
            ' Write to event log named RegexTimeouts
            Try
               If Not EventLog.SourceExists("RegexTimeouts") Then
                  EventLog.CreateEventSource("RegexTimeouts", "RegexTimeouts")
               End If   
               Dim log As New EventLog("RegexTimeouts")
               log.Source = "RegexTimeouts"
               Dim msg As String = String.Format("Timeout after {0} matching '{1}' with '{2}.",
                                                 e.MatchTimeout, e.Input, e.Pattern)
               log.WriteEntry(msg, EventLogEntryType.Error)
            ' Do nothing to handle the exceptions.
            Catch ex As SecurityException

            Catch ex As InvalidOperationException

            Catch ex As Win32Exception

            End Try   
            Return False
         End If   
      End Try
   End Function
End Module
' The example writes to the event log and also displays the following output:
'       Changing the timeout interval to 00:00:02
'       Changing the timeout interval to 00:00:03
'       Timeout interval of 00:00:03 exceeded.
' </Snippet1>
