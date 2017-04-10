'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Diagnostics


Namespace CreateEventSource
  Class Program
    Sub Main()

        Try
            ' Create the source, if it does not already exist.
            If Not (EventLog.SourceExists("MySamplesSite")) Then
                EventLog.CreateEventSource("MySamplesSite", "Application")
                Console.WriteLine("Creating Event Source")
            End If

            ' Create an EventLog instance and assign its source.
            Dim myLog As New EventLog
            myLog.Source = "MySamplesSite"

            ' Write an informational entry to the event log.
            myLog.WriteEntry("Testing writing to event log.")

            Console.WriteLine("Message written to event log.")
        Catch e As Exception
            Console.WriteLine("Exception:")
            Console.WriteLine(e.ToString)
        End Try

    End Sub
  End Class
End Namespace
'</snippet1>