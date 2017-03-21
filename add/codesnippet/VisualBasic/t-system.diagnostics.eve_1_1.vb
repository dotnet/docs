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
        ts.Listeners.Add(New EventSchemaTraceListener("TraceOutput.xml", "eventListener", 65536, TraceLogRetentionOption.LimitedCircularFiles, 20480000, 2))
        ts.Listeners("eventListener").TraceOutputOptions = TraceOptions.DateTime Or TraceOptions.ProcessId Or TraceOptions.Timestamp
#End If
        ts.Switch.Level = SourceLevels.All
        Dim testString As String = "<Test><InnerElement Val=""1"" /><InnerElement Val=""Data""/><AnotherElement>11</AnotherElement></Test>"
        Dim unXData As New UnescapedXmlDiagnosticData(testString)
        ts.TraceData(TraceEventType.Error, 38, unXData)
        ts.TraceEvent(TraceEventType.Error, 38, testString)
        ts.Flush()
        ts.Close()
        DisplayProperties(ts)
        Process.Start("notepad.exe", "TraceOutput.xml")
        Console.WriteLine("Press the enter key to exit")
        Console.ReadLine()

    End Sub 'Main

    Private Shared Sub DisplayProperties(ByVal ts As TraceSource)
        Console.WriteLine("IsThreadSafe? " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).IsThreadSafe.ToString())
        Console.WriteLine("BufferSize =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).BufferSize.ToString())
        Console.WriteLine("MaximumFileSize =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).MaximumFileSize.ToString())
        Console.WriteLine("MaximumNumberOfFiles =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).MaximumNumberOfFiles.ToString())
        Console.WriteLine("Name =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).Name)
        Console.WriteLine("TraceLogRetentionOption =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).TraceLogRetentionOption.ToString())
        Console.WriteLine("TraceOutputOptions =  " + CType(ts.Listeners("eventListener"), EventSchemaTraceListener).TraceOutputOptions.ToString())
    End Sub
End Class 'testClass