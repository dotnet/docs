'<Snippet1>
' The following configuration file can be used with this sample.
' When using a configuration file #define ConfigFile.
'<configuration>
'    <system.diagnostics>
'        <sources>
'            <source name="TraceTest" switchName="SourceSwitch" switchType="System.Diagnostics.SourceSwitch" >
'                <listeners>
'                    <add name="console" type="System.Diagnostics.ConsoleTraceListener" initializeData="false" />
'                    <remove name ="Default" />
'                </listeners>
'            </source>
'        </sources>
'        <switches>
'            <!-- You can set the level at which tracing is to occur -->
'            <add name="SourceSwitch" value="Warning" />
'            <!-- You can turn tracing off -->
'            <!--add name="SourceSwitch" value="Off" -->
'        </switches>
'        <trace autoflush="true" indentsize="4"></trace>
'    </system.diagnostics>
'</configuration>
#Const TRACE = True
'#Const ConfigFile = True

Imports System.Collections
Imports System.Diagnostics
Imports System.Reflection
Imports System.IO
Imports System.Security.Permissions



Class TraceTest
    '<Snippet9>
    ' Initialize the trace source.
    Private Shared ts As New TraceSource("TraceTest")
    '</Snippet9>
    '<Snippet2>
    <SwitchAttribute("SourceSwitch", GetType(SourceSwitch))> _
    Shared Sub Main()
        '</Snippet2>
        Try
            ' Initialize trace switches.
            '<Snippet7>
#If (ConfigFile = False) Then
            Dim sourceSwitch As New SourceSwitch("SourceSwitch", "Verbose")
            ts.Switch = sourceSwitch
            Dim idxConsole As New Integer()
            idxConsole = ts.Listeners.Add(New System.Diagnostics.ConsoleTraceListener())
            ts.Listeners(idxConsole).Name = "console"
#End If
            '</Snippet7>
            DisplayProperties(ts)
            '<Snippet16>
            ts.Listeners("console").TraceOutputOptions = ts.Listeners("console").TraceOutputOptions Or TraceOptions.Callstack
            '</Snippet16>
            '<Snippet17>
            ts.TraceEvent(TraceEventType.Warning, 1)
            '</Snippet17>
            ts.Listeners("console").TraceOutputOptions = TraceOptions.DateTime
            '<Snippet18>
            ' Issue file not found message as a warning.
            ts.TraceEvent(TraceEventType.Warning, 2, "File Test not found")
            '</Snippet18>
            '<Snippet24>
            ' Issue file not found message as a verbose event using a formatted string.
            ts.TraceEvent(TraceEventType.Verbose, 3, "File {0} not found.", "test")
            '</Snippet24>
            ' Issue file not found message as information.
            ts.TraceInformation("File {0} not found.", "test")
            '<Snippet26>
            ts.Listeners("console").TraceOutputOptions = ts.Listeners("console").TraceOutputOptions Or TraceOptions.LogicalOperationStack
            '</Snippet26>
            ' Issue file not found message as an error event.
            ts.TraceEvent(TraceEventType.Error, 4, "File {0} not found.", "test")
            '<Snippet28>
            ' Test the filter on the ConsoleTraceListener.
            ts.Listeners("console").Filter = New SourceFilter("No match")
            ts.TraceData(TraceEventType.Error, 5, "SourceFilter should reject this message for the console trace listener.")
            ts.Listeners("console").Filter = New SourceFilter("TraceTest")
            ts.TraceData(TraceEventType.Error, 6, "SourceFilter should let this message through on the console trace listener.")
            '</Snippet28>
            ts.Listeners("console").Filter = Nothing
            ' Use the TraceData method. 
            '<Snippet30>
            ts.TraceData(TraceEventType.Warning, 7, New Object())
            '</Snippet30>
            '<Snippet31>
            ts.TraceData(TraceEventType.Warning, 8, New Object() {"Message 1", "Message 2"})
            '</Snippet31>
            ' Activity tests.
            '<Snippet32>
            ts.TraceEvent(TraceEventType.Start, 9, "Will not appear until the switch is changed.")
            ts.Switch.Level = SourceLevels.ActivityTracing Or SourceLevels.Critical
            ts.TraceEvent(TraceEventType.Suspend, 10, "Switch includes ActivityTracing, this should appear")
            ts.TraceEvent(TraceEventType.Critical, 11, "Switch includes Critical, this should appear")
            '</Snippet32>
            '<Snippet33>
            ts.Flush()
            ts.Close()
            '</Snippet33>
            Console.WriteLine("Press any key to exit.")
            Console.Read()
        Catch e As Exception
            ' Catch any unexpected exception.
            Console.WriteLine("Unexpected exception: " + e.ToString())
            Console.Read()
        End Try

    End Sub 'Main

    Public Shared Sub DisplayProperties(ByVal ts As TraceSource)
        Console.WriteLine("TraceSource name = " + ts.Name)
        '<Snippet8>
        Console.WriteLine("TraceSource switch level = " + ts.Switch.Level.ToString())
        '</Snippet8>
        '<Snippet10>
        Console.WriteLine("TraceSource switch = " + ts.Switch.DisplayName.ToString())
        '</Snippet10>
        '<Snippet12>
        Dim switches As SwitchAttribute() = SwitchAttribute.GetAll(GetType(TraceTest).Assembly)
        Dim i As Integer
        For i = 0 To switches.Length - 1
            Console.WriteLine("Switch name = " + switches(i).SwitchName.ToString())
            Console.WriteLine("Switch type = " + switches(i).SwitchType.ToString())
        Next i
        '</Snippet12>

#If (ConfigFile) Then
        '<Snippet14>
        ' Get the custom attributes for the TraceSource.
        Console.WriteLine("Number of custom trace source attributes = " + ts.Attributes.Count)
        Dim de As DictionaryEntry
        For Each de In ts.Attributes
            Console.WriteLine("Custom trace source attribute = " + de.Key + "  " + de.Value)
        Next de
        '</Snippet14>
        '<Snippet15>
        ' Get the custom attributes for the trace source switch.
        For Each de In ts.Switch.Attributes
            Console.WriteLine("Custom switch attribute = " + de.Key + "  " + de.Value)
        Next de
        '</Snippet15>
#End If
        '<Snippet19>
        Console.WriteLine("Number of listeners = " + ts.Listeners.Count.ToString())
        '</Snippet19>
        '<Snippet21>
        Dim traceListener As TraceListener
        For Each traceListener In ts.Listeners
            Console.Write("TraceListener: " + traceListener.Name + vbTab)
            ' The following output can be used to update the configuration file.
            Console.WriteLine("AssemblyQualifiedName = " + traceListener.GetType().AssemblyQualifiedName)
        Next traceListener
        '</Snippet21>

    End Sub 'DisplayProperties
End Class 'TraceTest 

'</Snippet1>

