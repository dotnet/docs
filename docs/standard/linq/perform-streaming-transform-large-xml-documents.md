---
title: How to perform streaming transform of large XML documents - LINQ to XML
description: Learn how to perform streaming transform of large XML documents to achieve a small memory footprint.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to perform streaming transform of large XML documents (LINQ to XML)

Sometimes you have to transform large XML files, and write your application so that the memory footprint of the application is predictable. If you try to populate an XML tree with a very large XML file, your memory usage will be proportional to the size of the file (that is, excessive). Therefore, you should use a streaming technique instead.

Streaming techniques are best applied in situations where you need to process the source document only once, and you can process the elements in document order. Certain standard query operators, such as <xref:System.Linq.Enumerable.OrderBy%2A>, iterate their source, collect all of the data, sort it, and then finally yield the first item in the sequence. Note that if you use a query operator that materializes its source before yielding the first item, you won't retain a small memory footprint for your application.

Even if you use the technique described in [How to stream XML fragments with access to header information](stream-xml-fragments-access-header-information.md), if you try to assemble an XML tree that contains the transformed document, memory usage will be too great.

There are two main approaches. One approach is to use the deferred processing characteristics of <xref:System.Xml.Linq.XStreamingElement>. Another approach is to create an <xref:System.Xml.XmlWriter>, and use the capabilities of LINQ to XML to write elements to an <xref:System.Xml.XmlWriter>. This article demonstrates both approaches.

## Example: Use the deferred execution capabilities of `XStreamingElement` to stream the output

The following example builds on the example in [How to stream XML fragments with access to header information](stream-xml-fragments-access-header-information.md).

This example uses the deferred execution capabilities of <xref:System.Xml.Linq.XStreamingElement> to stream the output. This example can transform a very large document while maintaining a small memory footprint.

Note that the custom axis (`StreamCustomerItem`) is specifically written so that it expects a document that has `Customer`, `Name`, and `Item` elements, and that those elements will be arranged as in the following Source.xml document. A more robust implementation, however, would be prepared to parse an invalid document.

The following is the source document, Source.xml:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Root>
  <Customer>
    <Name>A. Datum Corporation</Name>
    <Item>
      <Key>0001</Key>
    </Item>
    <Item>
      <Key>0002</Key>
    </Item>
    <Item>
      <Key>0003</Key>
    </Item>
    <Item>
      <Key>0004</Key>
    </Item>
  </Customer>
  <Customer>
    <Name>Fabrikam, Inc.</Name>
    <Item>
      <Key>0005</Key>
    </Item>
    <Item>
      <Key>0006</Key>
    </Item>
    <Item>
      <Key>0007</Key>
    </Item>
    <Item>
      <Key>0008</Key>
    </Item>
  </Customer>
  <Customer>
    <Name>Southridge Video</Name>
    <Item>
      <Key>0009</Key>
    </Item>
    <Item>
      <Key>0010</Key>
    </Item>
  </Customer>
</Root>
```

```csharp
static IEnumerable<XElement> StreamCustomerItem(string uri)
{
    using XmlReader reader = XmlReader.Create(uri);

    reader.MoveToContent();

    // Parse the file, save header information when encountered, and yield the
    // Item XElement objects as they're created.

    // Loop through Customer elements
    do
    {
        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Customer")
        {
            // Move to Name element
            XElement? name = null;
            do
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Name")
                {
                    name = XNode.ReadFrom(reader) as XElement;
                    break;
                }
            }
            while (reader.Read());

            // Loop through Item elements
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Item")
                {
                    if (XNode.ReadFrom(reader) is XElement item && name != null)
                    {
                        XElement tempRoot = new XElement("Root",
                            new XElement(name),
                            item
                        );
                        yield return item;
                    }
                }
                else if (!reader.Read())
                    break;
            }
        }
    }
    while (reader.Read());
}

static void Main(string[] args)
{
    XStreamingElement root = new XStreamingElement("Root",
        from el in StreamCustomerItem("Source.xml")
        select new XElement("Item",
            new XElement("Customer", (string)el.Parent.Element("Name")),
            new XElement(el.Element("Key"))
        )
    );
    root.Save("Test.xml");
    Console.WriteLine(File.ReadAllText("Test.xml"));
}
```

```vb
Imports System.IO
Imports System.Xml

Module Module1

    Public Iterator Function StreamCustomerItem(uri As String) As IEnumerable(Of XElement)
        Using reader As XmlReader = XmlReader.Create(uri)
            reader.MoveToContent()

            ' Parse the file, save header information when encountered, And yield the
            ' Item XElement objects as they're created.

            ' Loop through Customer elements
            Do

                If reader.NodeType = XmlNodeType.Element And reader.Name = "Customer" Then

                    ' Move to Name element
                    Dim name As XElement = Nothing
                    Do
                        If reader.NodeType = XmlNodeType.Element And reader.Name = "Name" Then

                            name = TryCast(XNode.ReadFrom(reader), XElement)
                            Exit Do

                        End If

                    Loop While reader.Read()

                    ' Loop through Item elements
                    While reader.NodeType <> XmlNodeType.EndElement

                        If reader.NodeType = XmlNodeType.Element And reader.Name = "Item" Then

                            Dim item = TryCast(XNode.ReadFrom(reader), XElement)

                            If name IsNot Nothing AndAlso item IsNot Nothing Then

                                Dim tempRoot = <Root>
                                                   <Name><%= name.Value %></Name>
                                                   <%= item %>
                                               </Root>

                                Yield item

                            End If

                        ElseIf Not reader.Read() Then
                            Exit While
                        End If

                    End While

                End If

            Loop While reader.Read()

        End Using
    End Function

    Sub Main()
        Dim root = New XStreamingElement("Root",
            From el In StreamCustomerItem("Source.xml")
            Select <Item>
                       <Customer><%= el.Parent.<Name>.Value %></Customer>
                       <%= el.<Key> %>
                   </Item>
        )
        root.Save("Test.xml")
        Console.WriteLine(File.ReadAllText("Test.xml"))
    End Sub

End Module
```

This example produces the following output:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Root>
  <Item>
    <Customer>A. Datum Corporation</Customer>
    <Key>0001</Key>
  </Item>
  <Item>
    <Customer>A. Datum Corporation</Customer>
    <Key>0002</Key>
  </Item>
  <Item>
    <Customer>A. Datum Corporation</Customer>
    <Key>0003</Key>
  </Item>
  <Item>
    <Customer>A. Datum Corporation</Customer>
    <Key>0004</Key>
  </Item>
  <Item>
    <Customer>Fabrikam, Inc.</Customer>
    <Key>0005</Key>
  </Item>
  <Item>
    <Customer>Fabrikam, Inc.</Customer>
    <Key>0006</Key>
  </Item>
  <Item>
    <Customer>Fabrikam, Inc.</Customer>
    <Key>0007</Key>
  </Item>
  <Item>
    <Customer>Fabrikam, Inc.</Customer>
    <Key>0008</Key>
  </Item>
  <Item>
    <Customer>Southridge Video</Customer>
    <Key>0009</Key>
  </Item>
  <Item>
    <Customer>Southridge Video</Customer>
    <Key>0010</Key>
  </Item>
</Root>
```

## Example: Use LINQ to XML to write elements to an XmlWriter

The following example also builds on the example in [How to stream XML fragments with access to header information](stream-xml-fragments-access-header-information.md).

This example uses the capability of LINQ to XML to write elements to an <xref:System.Xml.XmlWriter>. This example can transform a very large document while maintaining a small memory footprint.

Note that the custom axis (`StreamCustomerItem`) is specifically written so that it expects a document that has `Customer`, `Name`, and `Item` elements, and that those elements will be arranged as in the following Source.xml document. A more robust implementation, however, would either validate the source document with an XSD, or would be prepared to parse an invalid document.

This example uses the same source document, Source.xml, as the previous example. It also produces exactly the same output.

Using <xref:System.Xml.Linq.XStreamingElement> for streaming the output XML is preferred to writing to an <xref:System.Xml.XmlWriter>.

```csharp
static IEnumerable<XElement> StreamCustomerItem(string uri)
{
    using XmlReader reader = XmlReader.Create(uri);

    reader.MoveToContent();

    // Parse the file, save header information when encountered, and yield the
    // Item XElement objects as they're created.

    // Loop through Customer elements
    do
    {
        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Customer")
        {
            // Move to Name element
            XElement? name = null;
            do
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Name")
                {
                    name = XNode.ReadFrom(reader) as XElement;
                    break;
                }
            }
            while (reader.Read());

            // Loop through Item elements
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Item")
                {
                    if (XNode.ReadFrom(reader) is XElement item && name != null)
                    {
                        XElement tempRoot = new XElement("Root",
                            new XElement(name),
                            item
                        );
                        yield return item;
                    }
                }
                else if (!reader.Read())
                    break;
            }
        }
    }
    while (reader.Read());
}

static void Main(string[] args)
{
    IEnumerable<XElement> srcTree =
        from el in StreamCustomerItem("Source.xml")
        select new XElement("Item",
            new XElement("Customer", (string)el.Parent.Element("Name")),
            new XElement(el.Element("Key"))
        );
    XmlWriterSettings xws = new XmlWriterSettings();
    xws.OmitXmlDeclaration = true;
    xws.Indent = true;
    using (XmlWriter xw = XmlWriter.Create("Output.xml", xws)) {
        xw.WriteStartElement("Root");
        foreach (XElement el in srcTree)
            el.WriteTo(xw);
        xw.WriteEndElement();
    }

    string str = File.ReadAllText("Output.xml");
    Console.WriteLine(str);
}
```

```vb
Imports System.IO
Imports System.Xml

Module Module1

    Public Iterator Function StreamCustomerItem(uri As String) As IEnumerable(Of XElement)
        Using reader As XmlReader = XmlReader.Create(uri)
            reader.MoveToContent()

            ' Parse the file, save header information when encountered, And yield the
            ' Item XElement objects as they're created.

            ' Loop through Customer elements
            Do

                If reader.NodeType = XmlNodeType.Element And reader.Name = "Customer" Then

                    ' Move to Name element
                    Dim name As XElement = Nothing
                    Do
                        If reader.NodeType = XmlNodeType.Element And reader.Name = "Name" Then

                            name = TryCast(XNode.ReadFrom(reader), XElement)
                            Exit Do

                        End If

                    Loop While reader.Read()

                    ' Loop through Item elements
                    While reader.NodeType <> XmlNodeType.EndElement

                        If reader.NodeType = XmlNodeType.Element And reader.Name = "Item" Then

                            Dim item = TryCast(XNode.ReadFrom(reader), XElement)

                            If name IsNot Nothing AndAlso item IsNot Nothing Then

                                Dim tempRoot = <Root>
                                                   <Name><%= name.Value %></Name>
                                                   <%= item %>
                                               </Root>

                                Yield item

                            End If

                        ElseIf Not reader.Read() Then
                            Exit While
                        End If

                    End While

                End If

            Loop While reader.Read()

        End Using
    End Function

    Sub Main()
        Dim srcTree =
            From el In StreamCustomerItem("Source.xml")
            Select <Item>
                       <Customer><%= el.Parent.<Name>.Value %></Customer>
                       <%= el.<Key> %>
                   </Item>

        Dim xws = New Xml.XmlWriterSettings()
        xws.OmitXmlDeclaration = True
        xws.Indent = True
        Using xw = Xml.XmlWriter.Create("Output.xml", xws)
            xw.WriteStartElement("Root")
            For Each el In srcTree
                el.WriteTo(xw)
            Next
            xw.WriteEndElement()
        End Using

        Dim s = File.ReadAllText("Output.xml")
        Console.WriteLine(s)
    End Sub

End Module
```

This example produces the following output:

```xml
<Root>
  <Item>
    <Customer>A. Datum Corporation</Customer>
    <Key>0001</Key>
  </Item>
  <Item>
    <Customer>A. Datum Corporation</Customer>
    <Key>0002</Key>
  </Item>
  <Item>
    <Customer>A. Datum Corporation</Customer>
    <Key>0003</Key>
  </Item>
  <Item>
    <Customer>A. Datum Corporation</Customer>
    <Key>0004</Key>
  </Item>
  <Item>
    <Customer>Fabrikam, Inc.</Customer>
    <Key>0005</Key>
  </Item>
  <Item>
    <Customer>Fabrikam, Inc.</Customer>
    <Key>0006</Key>
  </Item>
  <Item>
    <Customer>Fabrikam, Inc.</Customer>
    <Key>0007</Key>
  </Item>
  <Item>
    <Customer>Fabrikam, Inc.</Customer>
    <Key>0008</Key>
  </Item>
  <Item>
    <Customer>Southridge Video</Customer>
    <Key>0009</Key>
  </Item>
  <Item>
    <Customer>Southridge Video</Customer>
    <Key>0010</Key>
  </Item>
</Root>
```
