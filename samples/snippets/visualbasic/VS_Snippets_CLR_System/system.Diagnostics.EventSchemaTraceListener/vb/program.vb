'<Snippet1>
#Const NOCONFIGFILE = True
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Diagnostics

Class testClass

    <STAThreadAttribute()> _
    Shared Sub Main()
        File.Delete("TraceOutput.xml")
        Dim ts As New TraceSource("TestSource")
#If NOCONFIGFILE Then
        '<Snippet2>
        ts.Listeners.Add(New EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536, TraceLogRetentionOption.LimitedCircularFiles, 20480000, 2))
        '</Snippet2>
        '<Snippet3>
        ts.Listeners("eventListener").TraceOutputOptions = TraceOptions.DateTime Or TraceOptions.ProcessId Or TraceOptions.Timestamp
        '</Snippet3>
#End If
        ts.Switch.Level = SourceLevels.All
        '<Snippet11>
        Dim testString As String = "<Test><InnerElement Val=""1"" /><InnerElement Val=""Data""/><AnotherElement>11</AnotherElement></Test>"
        Dim unXData As New UnescapedXmlDiagnosticData(testString)
        ts.TraceData(TraceEventType.Error, 38, unXData)
        '</Snippet11>
        ts.TraceEvent(TraceEventType.Error, 38, testString)
        ts.Flush()
        ts.Close()
        DisplayProperties(ts)
        Process.Start("notepad.exe", "TraceOutput.xml")
        Console.WriteLine("Press the enter key to exit")
        Console.ReadLine()

    End Sub 'Main

    '<Snippet12>
    Private Shared Sub DisplayProperties(ByVal ts As TraceSource)
        '<Snippet4>
        Console.WriteLine("IsThreadSafe? " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).IsThreadSafe.ToString())
        '</Snippet4>
        '<Snippet5>
        Console.WriteLine("BufferSize =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).BufferSize.ToString())
        '</Snippet5>
        '<Snippet6>
        Console.WriteLine("MaximumFileSize =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).MaximumFileSize.ToString())
        '</Snippet6>
        '<Snippet7>
        Console.WriteLine("MaximumNumberOfFiles =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).MaximumNumberOfFiles.ToString())
        '</Snippet7>
        '<Snippet8>
        Console.WriteLine("Name =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).Name)
        '</Snippet8>
        '<Snippet9>
        Console.WriteLine("TraceLogRetentionOption =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).TraceLogRetentionOption.ToString())
        '</Snippet9>
        '<Snippet10>
        Console.WriteLine("TraceOutputOptions =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).TraceOutputOptions.ToString())
        '</Snippet10>
    End Sub
    '</Snippet12>
End Class 'testClass
'</Snippet1>