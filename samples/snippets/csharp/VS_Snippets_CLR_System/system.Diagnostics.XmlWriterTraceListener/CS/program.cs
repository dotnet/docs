//<Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;

class testClass
{
    static void Main()
    {
        File.Delete("NotEscaped.xml");
        TraceSource ts = new TraceSource("TestSource");
        ts.Listeners.Add(new XmlWriterTraceListener("NotEscaped.xml"));
        ts.Switch.Level = SourceLevels.All;
        string testString = "<Test><InnerElement Val=\"1\" /><InnerElement Val=\"Data\"/><AnotherElement>11</AnotherElement></Test>";
        XmlTextReader myXml = new XmlTextReader(new StringReader(testString));
        XPathDocument xDoc = new XPathDocument(myXml);
        XPathNavigator myNav = xDoc.CreateNavigator();
        ts.TraceData(TraceEventType.Error, 38, myNav);

        ts.Flush();
        ts.Close();

        File.Delete("Escaped.xml");
        TraceSource ts2 = new TraceSource("TestSource2");
        ts2.Listeners.Add(new XmlWriterTraceListener("Escaped.xml"));
        ts2.Switch.Level = SourceLevels.All;
        ts2.TraceData(TraceEventType.Error, 38, testString);

        ts2.Flush();
        ts2.Close();
    }
}
//</Snippet1>