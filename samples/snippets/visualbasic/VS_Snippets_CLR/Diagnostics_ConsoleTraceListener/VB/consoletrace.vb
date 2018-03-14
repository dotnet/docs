' Code sample for System.Diagnostics.ConsoleTraceListener

' <Snippet1>
' Define the TRACE constant, which enables trace output to the 
' Trace.Listeners collection. Typically, this constant is defined
' as a compilation argument.
#Const TRACE = True

Imports System
Imports System.Diagnostics

Public Class ConsoleTraceSample

    ' Define a simple method to write details about the current executing 
    ' environment to the trace listener collection.
    Public Shared Sub WriteEnvironmentInfoToTrace()

        Dim methodName As String = "WriteEnvironmentInfoToTrace"

        Trace.Indent()
        Trace.WriteLine(DateTime.Now.ToString() & " - Start of " & methodName)
        Trace.Indent()

        ' Write details on the executing environment to the trace output.
        Trace.WriteLine("Operating system: " & _
            System.Environment.OSVersion.ToString())
        Trace.WriteLine("Computer name: " & System.Environment.MachineName)
        Trace.WriteLine("User name: " & System.Environment.UserName)
        Trace.WriteLine("CLR version: " & System.Environment.Version.ToString)
        Trace.WriteLine("Command line: " & System.Environment.CommandLine)

        ' Enumerate the trace listener collection and 
        ' display details about each configured trace listener.
        Trace.WriteLine("Number of configured trace listeners = " & _
            Trace.Listeners.Count.ToString())

        Dim tl As TraceListener
        For Each tl In Trace.Listeners
            Trace.WriteLine("Trace listener name = " & tl.Name)
            Trace.WriteLine("               type = " & tl.GetType().ToString())
        Next tl

        Trace.Unindent()
        Trace.WriteLine(DateTime.Now.ToString() & " - End of " & methodName)
        Trace.Unindent()

    End Sub

    ' Define the main entry point of this class.
    ' The main method adds a console trace listener to the collection
    ' of configured trace listeners, then writes details on the current
    ' executing environment.
    Public Shared Sub Main(ByVal CmdArgs() As String)

        ' Write a trace message to all configured trace listeners.
        Trace.WriteLine(DateTime.Now.ToString() & " - Start of Main")

        ' <Snippet2>
        ' Define a trace listener to direct trace output from this method
        ' to the console.
        Dim consoleTracer As ConsoleTraceListener

        ' Check the command line arguments to determine which
        ' console stream should be used for trace output.
        If (CmdArgs.Length > 0) AndAlso _
           (CmdArgs(0).ToLower.Equals("/stderr")) Then
            ' Initialize the console trace listener to write
            ' trace output to the standard error stream.
            consoleTracer = New ConsoleTraceListener(True)
        Else
            ' Initialize the console trace listener to write
            ' trace output to the standard output stream.
            consoleTracer = New ConsoleTraceListener
        End If
        ' Set the name of the trace listener, which helps identify this 
        ' particular instance within the trace listener collection.
        consoleTracer.Name = "mainConsoleTracer"

        ' Write the initial trace message to the console trace listener.
        consoleTracer.WriteLine(DateTime.Now.ToString() & " [" & _
             consoleTracer.Name & "] - Starting output to trace listener.")

        ' Add the new console trace listener to 
        ' the collection of trace listeners.
        Trace.Listeners.Add(consoleTracer)
        ' </Snippet2>

        ' Call a local method, which writes information about the current 
        ' execution environment to the configured trace listeners.
        WriteEnvironmentInfoToTrace()

        ' Write the final trace message to the console trace listener.
        consoleTracer.WriteLine(DateTime.Now.ToString() & " [" & _
            consoleTracer.Name & "] - Ending output to trace listener.")

        ' Flush any pending trace messages, remove the 
        ' console trace listener from the collection,
        ' and close the console trace listener.
        Trace.Flush()
        Trace.Listeners.Remove(consoleTracer)
        consoleTracer.Close()

        ' Write a final trace message to all trace listeners.
        Trace.WriteLine(DateTime.Now.ToString() + " - End of Main")

        ' Close all other configured trace listeners.
        Trace.Close()

    End Sub

End Class
' </Snippet1>