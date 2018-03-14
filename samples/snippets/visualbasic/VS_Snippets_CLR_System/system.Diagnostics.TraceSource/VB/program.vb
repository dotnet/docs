
'<Snippet1>
#Const TRACE = True
#Const ConfigFile = True
' The following configuration file can be used with this sample.
' When using a configuration file #define ConfigFile.
'<?xml version="1.0" encoding="utf-8"?>
'<configuration>
'  <system.diagnostics>
'    <sources>
'      <source name="TraceTest" switchName="TestSourceSwitch" switchType="Testing.MySourceSwitch, TraceSample" SecondTraceSourceAttribute="two">
'        <listeners>
'          <add name="console" />
'          <add name="file" />
'          <add name="fileBuilder" />
'        </listeners>
'      </source>
'    </sources>
'    <switches>
'      <add name="TestSourceSwitch" value="Error" customsourceSwitchattribute="5" />
'      <add name="TraceTest" value="Verbose" />
'      <add name="TraceSwitch" value="Warning" />
'      <add name="BoolSwitch" value="True" />
'    </switches>
'    <sharedListeners>
'      <add name="console" type="System.Diagnostics.ConsoleTraceListener, System, Version=1.2.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="false" />
'      <add name="file" type="System.Diagnostics.TextWriterTraceListener, System, Version=1.2.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="TextWriterOutput.log" traceOutputOptions="ProcessId, LogicalOperationStack, Timestamp, ThreadId, Callstack, DateTime" />
'      <add name="fileBuilder" type="System.Diagnostics.DelimitedListTraceListener, System, Version=1.2.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" initializeData="DelimitedListOutput.log" traceOutputOptions="ProcessId, LogicalOperationStack, Timestamp, ThreadId, DateTime" />
'    </sharedListeners>
'    <trace autoflush="true" indentsize="4">
'      <listeners>
'        <add name="console" />
'        <add name="file" />
'        <add name="fileBuilder" />
'          <add name="testlistener" type="Testing.TestListener, TraceSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" initializeData="5" />
'      </listeners>
'    </trace>
'  </system.diagnostics>
'</configuration>

#Const ConfigFile = True
Imports System.Collections
Imports System.Diagnostics
Imports System.Reflection
Imports System.IO
Imports System.Security.Permissions



Class TraceTest
    Private Const TEXTFILE As String = "TextWriterOutput.log"
    Private Const DELIMITEDFILE As String = "DelimitedListOutput.log"
    Private Const TESTLISTENERFILE As String = "C:\Temp\TestListener.txt"
    '<Snippet2>
    Public Shared traceSwitch As New TraceSwitch("TraceSwitch", "Verbose")
    Public Shared boolSwitch As New BooleanSwitch("BoolSwitch", "True")
    Public Shared sourceSwitch As New SourceSwitch("SourceSwitch", "Verbose")

    '</Snippet2>
    Shared Sub Main()

        Try
            ' Initialize trace switches.
            '<Snippet3>
#If (ConfigFile = False) Then
            Dim traceSwitch As New TraceSwitch("TraceSwitch", "Verbose")
#End If
            '</Snippet3>
            '<Snippet4>
            Console.WriteLine(traceSwitch.Level)
            '</Snippet4>
            '<Snippet5>
#If (ConfigFile = False) Then
            Dim boolSwitch As New BooleanSwitch("BoolSwitch", "True")
#End If
            '</Snippet5>
            '<Snippet6>
            Console.WriteLine(boolSwitch.Enabled)
            '</Snippet6>
            '<Snippet7>
#If (ConfigFile = False) Then
            Dim sourceSwitch As New SourceSwitch("SourceSwitch", "Verbose")
#End If
            '</Snippet7>
            '<Snippet8>
            Console.WriteLine(sourceSwitch.Level)
            '</Snippet8>
            ' Initialize trace source.
            '<Snippet9>
            Dim ts As New MyTraceSource("TraceTest")
            '</Snippet9>
            '<Snippet10>
            Console.WriteLine(ts.Switch.DisplayName)
            '</Snippet10>
            '<Snippet11>
            Console.WriteLine(ts.Switch.Level)
            '</Snippet11>
            '<Snippet12>
            Dim switches As SwitchAttribute() = SwitchAttribute.GetAll(GetType(TraceTest).Assembly)
            Dim i As Integer
            For i = 0 To switches.Length - 1
                Console.Write(switches(i).SwitchName)
                Console.Write(vbTab)
                Console.WriteLine(switches(i).SwitchType)
            Next i
            '</Snippet12>
            '<Snippet13>
            ' Display the SwitchLevelAttribute for the BooleanSwitch.
            Dim attribs As [Object]() = GetType(BooleanSwitch).GetCustomAttributes(GetType(SwitchLevelAttribute), False)
            If attribs.Length = 0 Then
                Console.WriteLine("Error, couldn't find SwitchLevelAttribute on BooleanSwitch.")
            Else
                Console.WriteLine(CType(attribs(0), SwitchLevelAttribute).SwitchLevelType.ToString())
            End If
            '</Snippet13>
#If (ConfigFile = True) Then
            '<Snippet14>
            ' Get the custom attributes for the TraceSource.
            Console.WriteLine(ts.Attributes.Count)
            Dim de As DictionaryEntry
            For Each de In ts.Attributes
                Console.WriteLine(de.Key + "  " + de.Value)
            Next de 
            '</Snippet14>
            '<Snippet15>
            ' Get the custom attributes for the trace source switch.

            For Each de In ts.Switch.Attributes
                Console.WriteLine(de.Key + "  " + de.Value)
            Next de 
            '</Snippet15>
#End If
            '<Snippet16>
            ts.Listeners("console").TraceOutputOptions = ts.Listeners("console").TraceOutputOptions Or TraceOptions.Callstack
            '</Snippet16>
            '<Snippet17>
            ts.TraceEvent(TraceEventType.Warning, 1)
            '</Snippet17>
            ts.Listeners("console").TraceOutputOptions = TraceOptions.DateTime
            '<Snippet18>
            ' Issue file not found message as a warning.
            ts.TraceEvent(TraceEventType.Warning, 1, "File Test not found")
            '</Snippet18>
            System.Threading.Thread.Sleep(1000)
            '<Snippet19>
            Console.WriteLine(ts.Listeners.Count)
            '</Snippet19>
            '<Snippet20>
            ts.Listeners.Add(New TestListener(TESTLISTENERFILE, "TestListener"))
            '</Snippet20>
            Console.WriteLine(ts.Listeners.Count)
            '<Snippet22>
            Dim traceListener As TraceListener
            For Each traceListener In ts.Listeners
                Console.Write(traceListener.Name + vbTab)
                ' The following output can be used to update the configuration file.
                Console.WriteLine(traceListener.GetType().AssemblyQualifiedName)
            Next traceListener
            '</Snippet22>
            '<Snippet23>
            ' Show correlation and output options.
            Trace.CorrelationManager.StartLogicalOperation("abc")
            '</Snippet23>
            '<Snippet24>
            ' Issue file not found message as a verbose event using a formatted string.
            ts.TraceEvent(TraceEventType.Verbose, 2, "File {0} not found.", "test")
            '</Snippet24>
            Trace.CorrelationManager.StartLogicalOperation("def")
            ' Issue file not found message as information.
            ts.TraceEvent(TraceEventType.Information, 3, "File {0} not found.", "test")
            '<Snippet25>
            Trace.CorrelationManager.StopLogicalOperation()
            '</Snippet25>
            '<Snippet26>
            ts.Listeners("console").TraceOutputOptions = ts.Listeners("console").TraceOutputOptions Or TraceOptions.LogicalOperationStack
            '</Snippet26>
            ' Issue file not found message as an error event.
            ts.TraceEvent(TraceEventType.Error, 4, "File {0} not found.", "test")
            Trace.CorrelationManager.StopLogicalOperation()
            ' Write simple message from trace.
            '<Snippet27>
            Trace.TraceWarning("Warning from Trace.")
            '</Snippet27>
            '<Snippet28>
            ' Test the filter on the ConsoleTraceListener.
            ts.Listeners("console").Filter = New SourceFilter("No match")
            ts.TraceData(TraceEventType.Information, 5, "SourceFilter should reject this message for the console trace listener.")
            ts.Listeners("console").Filter = New SourceFilter("TraceTest")
            ts.TraceData(TraceEventType.Information, 6, "SourceFilter should let this message through on the console trace listener.")
            '</Snippet28>
            ts.Listeners("console").Filter = Nothing
            ' Use the TraceData method. 
            '<Snippet30>
            ts.TraceData(TraceEventType.Warning, 9, New Object())
            '</Snippet30>
            '<Snippet31>
            ts.TraceData(TraceEventType.Warning, 10, New Object() {"Message 1", "Message 2"})
            '</Snippet31>
            ' Activity tests.
            '<Snippet32>
            ts.TraceEvent(TraceEventType.Start, 11, "Will not appear until the switch is changed.")
            ts.Switch.Level = SourceLevels.ActivityTracing Or SourceLevels.Critical
            ts.TraceEvent(TraceEventType.Suspend, 12, "Switch includes ActivityTracing, this should appear")
            ts.TraceEvent(TraceEventType.Critical, 13, "Switch includes Critical, this should appear")
            '</Snippet32>
            Trace.Flush()
            CType(Trace.Listeners("file"), TextWriterTraceListener).Close()
            CType(Trace.Listeners("fileBuilder"), TextWriterTraceListener).Close()

            System.Threading.Thread.Sleep(1000)


            ' Examine the contents of the log file.
            Console.WriteLine(vbLf + vbLf + vbLf)
            ' Use try/catch in case the file hasn't been defined.
            Try
                Console.WriteLine("Examining " + TEXTFILE)
                Dim logfile As New StreamReader(TEXTFILE)
                While Not logfile.EndOfStream
                    Console.WriteLine(logfile.ReadLine())
                End While
                logfile.Close()

                File.Delete(TEXTFILE)
            Catch e As Exception
                Console.WriteLine("Error tying to read the text log file. " + e.Message)
            End Try

            ' Display the contents of the log file builder.
            Console.WriteLine(vbLf + vbLf + vbLf)
            ' Use try/catch in case the file hasn't been defined.
            Try
                Console.WriteLine("Examining " + DELIMITEDFILE)
                Dim logfile As New StreamReader(DELIMITEDFILE)
                While Not logfile.EndOfStream
                    Console.WriteLine(logfile.ReadLine())
                End While
                logfile.Close()
                File.Delete(DELIMITEDFILE)
            Catch e As Exception
                Console.WriteLine("Error tying to read the delimited text file. " + e.Message)
            End Try

            Console.WriteLine("Press any key to exit.")
            Console.Read()
        Catch e As Exception
            ' Catch any unexpected exception.
            Console.WriteLine("Unexpected exception: " + e.ToString())
            Console.Read()
        End Try

    End Sub 'Main
End Class 'TraceTest

  '<Snippet33>
Public Class MyTraceSource
    Inherits TraceSource
    Private firstAttribute As String = ""
    Private secondAttribute As String = ""

    Public Sub New(ByVal n As String)
        MyBase.New(n)

    End Sub 'New 

    Public Property FirstTraceSourceAttribute() As String
        Get
            Dim de As DictionaryEntry
            For Each de In Me.Attributes
                If de.Key.ToString().ToLower() = "firsttracesourceattribute" Then
                    firstAttribute = de.Value.ToString()
                End If
            Next de
            Return firstAttribute
        End Get
        Set(ByVal value As String)
            firstAttribute = value
        End Set
    End Property

    Public Property SecondTraceSourceAttribute() As String
        Get
            Dim de As DictionaryEntry
            For Each de In Me.Attributes
                If de.Key.ToString().ToLower() = "secondtracesourceattribute" Then
                    secondAttribute = de.Value.ToString()
                End If
            Next de
            Return secondAttribute
        End Get
        Set(ByVal value As String)
            secondAttribute = Value
        End Set
    End Property

    Protected Overrides Function GetSupportedAttributes() As String()
        ' Allow the use of the attributes in the configuration file.
        Return New String() {"FirstTraceSourceAttribute", "SecondTraceSourceAttribute"}

    End Function 'GetSupportedAttributes
End Class 'MyTraceSource 
'</Snippet33>

'<Snippet34>
Public Class MySourceSwitch
    Inherits SourceSwitch
    Private sourceAttribute As Integer = 0

    Public Sub New(ByVal n As String)
        MyBase.New(n)

    End Sub 'New

    Public Property CustomSourceSwitchAttribute() As Integer
        Get
            Dim de As DictionaryEntry
            For Each de In Me.Attributes
                If de.Key.ToString().ToLower() = "customsourceswitchattribute" Then
                    sourceAttribute = Fix(de.Value)
                End If
            Next de
            Return sourceAttribute
        End Get
        Set(ByVal value As Integer)
            sourceAttribute = Fix(Value)
        End Set
    End Property

    Protected Overrides Function GetSupportedAttributes() As String()
        Return New String() {"customsourceSwitchattribute"}

    End Function 'GetSupportedAttributes
End Class 'MySourceSwitch
'</Snippet34>

' Very basic test listener derived from TextWriterTraceListener.
'<Snippet35>
<HostProtection(Synchronization:=True)> _
Public Class TestListener
    Inherits TextWriterTraceListener

    Public Sub New(ByVal fileName As String)
        MyBase.New(fileName)

    End Sub 'New

    Public Sub New(ByVal fileName As String, ByVal name As String)
        MyBase.New(fileName, name)

    End Sub 'New

    Public Overrides Sub Write(ByVal s As String)
        MyBase.Write(("TestListener " + s))

    End Sub 'Write

    Public Overrides Sub WriteLine(ByVal s As String)
        MyBase.WriteLine(("TestListener " + s))

    End Sub 'WriteLine

    Protected Overrides Function GetSupportedAttributes() As String()
        ' The following string array will allow the use of 
        ' the name "customListenerAttribute" in the configuration file.
        Return New String() {"customListenerAttribute"}

    End Function 'GetSupportedAttributes
End Class 'TestListener 
'</Snippet35>

'</Snippet1>