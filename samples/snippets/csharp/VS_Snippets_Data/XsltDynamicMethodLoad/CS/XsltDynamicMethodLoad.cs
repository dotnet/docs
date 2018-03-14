//<snippet1>
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Xsl;

class Example
{
    static void Main()
    {
        // Load a stylesheet compiled using the XSLTC.EXE utility
        Type compiledStylesheet = Assembly.Load("Transform").GetType("Transform");

        // Extract private members from the compiled stylesheet
        BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static;
        MethodInfo executeMethod = compiledStylesheet.GetMethod("Execute", bindingFlags);
        object staticData = compiledStylesheet.GetField("staticData", bindingFlags).GetValue(null);
        object earlyBoundTypes = compiledStylesheet.GetField("ebTypes", bindingFlags).GetValue(null);

        // Load into XslCompiledTransform
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(executeMethod, (byte[])staticData, (Type[])earlyBoundTypes);

        // Run the transformation
        xslt.Transform(XmlReader.Create(new StringReader("<Root><Price>9.50</Price></Root>")), (XsltArgumentList)null, Console.Out);
    }
}
//</snippet1>

