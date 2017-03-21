        Dim testString As String = "<Test><InnerElement Val=""1"" /><InnerElement Val=""Data""/><AnotherElement>11</AnotherElement></Test>"
        Dim unXData As New UnescapedXmlDiagnosticData(testString)
        ts.TraceData(TraceEventType.Error, 38, unXData)