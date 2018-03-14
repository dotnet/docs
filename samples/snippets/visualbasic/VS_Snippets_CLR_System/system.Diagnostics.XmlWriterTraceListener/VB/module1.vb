'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Imports System.Diagnostics



Class testClass
    
    Shared Sub Main() 
        File.Delete("NotEscaped.xml")
        Dim ts As New TraceSource("TestSource")
        ts.Listeners.Add(New XmlWriterTraceListener("NotEscaped.xml"))
        ts.Switch.Level = SourceLevels.All
        Dim testString As String = "<Test><InnerElement Val=""1"" /><InnerElement Val=""Data""/><AnotherElement>11</AnotherElement></Test>"
        Dim myXml As New XmlTextReader(New StringReader(testString))
        Dim xDoc As New XPathDocument(myXml)
        Dim myNav As XPathNavigator = xDoc.CreateNavigator()
        ts.TraceData(TraceEventType.Error, 38, myNav)

        ts.Flush()
        ts.Close()
        
        File.Delete("Escaped.xml")
        Dim ts2 As New TraceSource("TestSource2")
        ts2.Listeners.Add(New XmlWriterTraceListener("Escaped.xml"))
        ts2.Switch.Level = SourceLevels.All
        ts2.TraceData(TraceEventType.Error, 38, testString)
        
        ts2.Flush()
        ts2.Close()
    
    End Sub 'Main
End Class 'testClass
'</Snippet1>