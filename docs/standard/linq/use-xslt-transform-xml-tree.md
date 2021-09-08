---
title: Use XSLT to transform an XML tree - LINQ to XML
description: Learn to use XSLT to transform an XML tree, using XmlReader to read and XmlWriter to write.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---
# Use XSLT to transform an XML tree (LINQ to XML)

You can use XSLT to transform an XML tree, using <xref:System.Xml.XmlReader> to read and <xref:System.Xml.XmlWriter> to write.

## Example: Use XSLT to transform an XML tree, using `XMLReader` to read and `XMLWriter` to write

This example creates an XML tree and uses XSLT to transform it. It makes use of an <xref:System.Xml.XmlReader> to read the original tree, and an <xref:System.Xml.XmlWriter> to write the transformed version.

It starts by creating:

- An XML tree.
- An <xref:System.Xml.XmlReader> of the XML tree.
- A new document to hold the XSLT output.
- An <xref:System.Xml.XmlWriter> to write the transformed tree to the new document.

It then invokes an XSLT transformation that uses the <xref:System.Xml.XmlReader> to read the original XML tree, and the <xref:System.Xml.XmlWriter> to write the transformed tree to the new document.

```csharp
string xslt = @"<?xml version='1.0'?>
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

var oldDocument = new XDocument(
    new XElement("Parent",
        new XElement("Child1", "Child1 data"),
        new XElement("Child2", "Child2 data")
    )
);

var newDocument = new XDocument();

using (var stringReader = new StringReader(xslt))
{
    using (XmlReader xsltReader = XmlReader.Create(stringReader))
    {
        var transformer = new XslCompiledTransform();
        transformer.Load(xsltReader);
        using (XmlReader oldDocumentReader = oldDocument.CreateReader())
        {
            using (XmlWriter newDocumentWriter = newDocument.CreateWriter())
            {
                transformer.Transform(oldDocumentReader, newDocumentWriter);
            }
        }
    }
}

string result = newDocument.ToString();
Console.WriteLine(result);
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

Dim xmlTree As XElement = _
    <Parent>
        <Child1>Child1 data</Child1>
        <Child2>Child2 data</Child2>
    </Parent>

Dim newTree As XDocument = New XDocument()

Using writer As XmlWriter = newTree.CreateWriter()
    ' Load the style sheet.
    Dim xslt As XslCompiledTransform = _
        New XslCompiledTransform()
    xslt.Load(xslMarkup.CreateReader())

    ' Execute the transform and output the results to a writer.
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

- <xref:System.Xml.Linq.XContainer.CreateWriter%2A?displayProperty=nameWithType>
- <xref:System.Xml.Linq.XNode.CreateReader%2A?displayProperty=nameWithType>
