        string testString = "<Test><InnerElement Val=\"1\" /><InnerElement Val=\"Data\"/><AnotherElement>11</AnotherElement></Test>";
        UnescapedXmlDiagnosticData unXData = new UnescapedXmlDiagnosticData(testString);
        ts.TraceData(TraceEventType.Error, 38, unXData);