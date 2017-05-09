'<snippet4>
Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

Module TWTLConStringNameMod

    Const LISTENER_NAME As String = "myStringListener"

    ' args(0) is the specification of the trace log file.
    Sub Main(ByVal args() As String)

        ' Verify that a parameter was entered.
        If args.Length = 0 Then
            Console.WriteLine("Enter a trace file specification.")

        Else
            ' Create a TextWriterTraceListener object that takes a 
            ' file specification.
            Dim textListener As TextWriterTraceListener
            Try
                textListener = _
                    New TextWriterTraceListener(args(0), LISTENER_NAME)
                Trace.Listeners.Add(textListener)
            Catch ex As Exception
                Console.WriteLine( _
                    "Error creating TextWriterTraceListener for trace " & _
                    "file ""{0}"":" & vbCrLf & "{1}", args(0), ex.Message)
                Return
            End Try

            ' Write these messages only to this TextWriterTraceListener.
            textListener.WriteLine( _
                "This is trace listener named """ & textListener.Name & """")
            textListener.WriteLine("Trace written to a file: " & _
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
'</snippet4>
