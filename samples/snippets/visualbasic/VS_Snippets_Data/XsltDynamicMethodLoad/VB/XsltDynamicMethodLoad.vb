'<snippet1>
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports System.Xml.Xsl

Module Module1

    Sub Main()
        ' Load a stylesheet compiled using the XSLTC.EXE utility
        Dim compiledStylesheet As Type = [Assembly].Load("Transform").GetType("Transform")

        ' Extract private members from the compiled stylesheet
        Dim bindingFlags As BindingFlags = bindingFlags.NonPublic Or bindingFlags.Static
        Dim executeMethod As MethodInfo = compiledStylesheet.GetMethod("Execute", bindingFlags)
        Dim staticData As Object = compiledStylesheet.GetField("staticData", bindingFlags).GetValue(Nothing)
        Dim earlyBoundTypes As Object = compiledStylesheet.GetField("ebTypes", bindingFlags).GetValue(Nothing)

        ' Load into XslCompiledTransform
        Dim xslt As New XslCompiledTransform()
        xslt.Load(executeMethod, CType(staticData, Byte()), CType(earlyBoundTypes, Type()))

        ' Run the transformation
        xslt.Transform(XmlReader.Create(New StringReader("<Root><Price>9.50</Price></Root>")), CType(Nothing, XsltArgumentList), Console.Out)
    End Sub
End Module
'</snippet1>
