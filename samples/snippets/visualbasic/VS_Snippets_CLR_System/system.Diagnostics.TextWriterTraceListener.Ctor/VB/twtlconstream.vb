'<Snippet1>
Imports System
Imports System.Diagnostics
Imports System.IO
Imports Microsoft.VisualBasic

Module TWTLConStreamMod

    ' args(0) is the specification of the trace log file.
    Sub Main(ByVal args() As String)

        ' Verify that a parameter was entered.
        If args.Length = 0 Then
            Console.WriteLine("Enter a trace file specification.")

        Else
            ' Create a stream object.
            Dim traceStream As FileStream
            Try
                traceStream = New FileStream( _
                    args(0), FileMode.Append, FileAccess.Write)
            Catch ex As Exception
                Console.WriteLine( _
                    "Error creating FileStream for trace file ""{0}"":" & _
                    vbCrLf & "{1}", args(0), ex.Message)
                Return
            End Try

            ' Create a TextWriterTraceListener object that takes a stream.
            Dim textListener As TextWriterTraceListener
            textListener = New TextWriterTraceListener(traceStream)
            Trace.Listeners.Add(textListener)

            ' Write these messages only to this TextWriterTraceListener.
            textListener.WriteLine( _
                "This is trace listener named """ & textListener.Name & """")
            textListener.WriteLine( _
                "Trace written through a stream to: " & _
                vbCrLf & "    """ & args(0) & """")

            ' Write a message to all trace listeners.
            Trace.WriteLine(String.Format( _
                "This trace message written {0} to all listeners.", Now))

            ' Flush and close the output.
            Trace.Flush()
            textListener.Flush()
            textListener.Close()
        End If
    End Sub
End Module
'</Snippet1>
