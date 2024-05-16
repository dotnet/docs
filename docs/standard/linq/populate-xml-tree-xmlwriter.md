---
title: How to populate an XML tree with an XmlWriter - LINQ to XML
description: To populate an XML tree in C# and Visual Basic, create an XMLWriter using CreateWriter, then write to the XmlWriter.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to populate an XML tree with an XmlWriter (LINQ to XML)

One way to populate an XML tree is to use <xref:System.Xml.Linq.XContainer.CreateWriter%2A> to create an <xref:System.Xml.XmlWriter>, and then write to the <xref:System.Xml.XmlWriter>. The XML tree is populated with all nodes that are written to the <xref:System.Xml.XmlWriter>.

You'd typically use this method when you use LINQ to XML with another class that expects to write to an <xref:System.Xml.XmlWriter>, such as <xref:System.Xml.Xsl.XslCompiledTransform>.

## Example: Create an XmlWriter to accept the output of an XSLT transformation

You can use <xref:System.Xml.Linq.XContainer.CreateWriter%2A> to create an <xref:System.Xml.XmlWriter> to accept the output of an XSLT transformation. This is shown in the following example, which does the following:

- Creates an XML tree and an <xref:System.Xml.XmlReader> to read from it.
- Creates a new tree and an <xref:System.Xml.XmlWriter> to write to it.
- Invokes the XSLT transformation, providing it with the  <xref:System.Xml.XmlReader> and the <xref:System.Xml.XmlWriter>.

The transformation then populates the new tree.

```csharp
string xslMarkup = @"<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
    <xsl:template match='/Parent'>
        <Root>
            <C1>
            <xsl:value-of select='Child1'/>
            </C1>
            <C2>
            <xsl:value-of select='Child2'/>
            </C2>
        </Root>
    </xsl:template>
</xsl:stylesheet>";

XDocument xmlTree = new XDocument(
    new XElement("Parent",
        new XElement("Child1", "Child1 data"),
        new XElement("Child2", "Child2 data")
    )
);

XDocument newTree = new XDocument();
using (XmlWriter writer = newTree.CreateWriter())
{
    // Load the style sheet.
    XslCompiledTransform xslt = new XslCompiledTransform();
    xslt.Load(XmlReader.Create(new StringReader(xslMarkup)));

    // Execute the transformation and output the results to a writer.
    xslt.Transform(xmlTree.CreateReader(), writer);
}

Console.WriteLine(newTree);
```

```vb
Dim xslMarkup As XDocument = _
    <?xml version='1.0'?>
    <xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
        <xsl:template match='/Parent'>
            <Root>
                <C1>
                    <xsl:value-of select='Child1'/>
                </C1>
                <C2>
                    <xsl:value-of select='Child2'/>
                </C2>
            </Root>
        </xsl:template>
    </xsl:stylesheet>

Dim xmlTree As XDocument = _
    <?xml version='1.0'?>
    <Parent>
        <Child1>Child1 data</Child1>
        <Child2>Child2 data</Child2>
    </Parent>

Dim newTree As XDocument = New XDocument()
Using writer As XmlWriter = newTree.CreateWriter()
    ' Load the style sheet.
    Dim xslt As XslCompiledTransform = New XslCompiledTransform()
    xslt.Load(xslMarkup.CreateReader())

    ' Execute the transformation and output the results to a writer.
    xslt.Transform(xmlTree.CreateReader(), writer)
End Using

Console.WriteLine(newTree)
```

This example produces the following output:

```xml
<Root>
  <C1>Child1 data</C1>
  <C2>Child2 data</C2>
</Root>
```

## See also

- <xref:System.Xml.Linq.XContainer.CreateWriter%2A>
- <xref:System.Xml.XmlWriter>
- <xref:System.Xml.Xsl.XslCompiledTransform>
- [XML trees](functional-construction.md)
