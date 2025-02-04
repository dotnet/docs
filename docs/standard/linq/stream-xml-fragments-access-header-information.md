---
title: How to stream XML fragments with access to header information - LINQ to XML
description: Learn how to implement and use a custom axis method that streams XML fragments from the file specified by a URI.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to stream XML fragments with access to header information (LINQ to XML)

Sometimes you have to read arbitrarily large XML files, and write your application so that the memory footprint of the application is predictable. If you attempt to populate an XML tree with a large XML file, your memory usage will be proportional to the size of the file—that is, excessive. Therefore, you should use a streaming technique instead.

One option is to write your application using <xref:System.Xml.XmlReader>. However, you might want to use LINQ to query the XML tree. If so, you can write your own custom axis method. For more information, see [How to write a LINQ to XML axis method](write-linq-xml-axis-method.md).

To write your own axis method, you write a small method that uses the <xref:System.Xml.XmlReader> to read nodes until it reaches one of the nodes in which you're interested. The method then calls <xref:System.Xml.Linq.XNode.ReadFrom%2A>, which reads from the <xref:System.Xml.XmlReader> and instantiates an XML fragment. It then yields each fragment through `yield return` to the method that's enumerating your custom axis method. You can then write LINQ queries on your custom axis method.

Streaming techniques are best applied in situations where you need to process the source document only once, and you can process the elements in document order. Certain standard query operators, such as <xref:System.Linq.Enumerable.OrderBy%2A>, iterate their source, collect all of the data, sort it, and then finally yield the first item in the sequence. If you use a query operator that materializes its source before yielding the first item, you won't retain a small memory footprint.

## Example: Implement and use a custom axis method that streams XML fragments from the file specified by a URI

Sometimes the problem gets just a little more interesting. In the following XML document, the consumer of your custom axis method also has to know the name of the customer that each item belongs to.

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

The approach that this example takes is to also watch for this header information, save the header information, and then build a small XML tree that contains both the header information and the detail that you're enumerating. The axis method then yields this new, small XML tree. The query then has access to the header information as well as the detail information.

This approach has a small memory footprint. As each detail XML fragment is yielded, no references are kept to the previous fragment, and it's available for garbage collection. This technique creates many short lived objects on the heap.

The following example shows how to implement and use a custom axis method that streams XML fragments from the file specified by the URI. This custom axis is written such that it expects a document that has `Customer`, `Name`, and `Item` elements, and that those elements will be arranged as in the above `Source.xml` document. It's a simplistic implementation. A more robust implementation would be prepared to parse an invalid document.

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
    XElement xmlTree = new XElement("Root",
        from el in StreamCustomerItem("Source.xml")
        where (int)el.Element("Key") >= 3 && (int)el.Element("Key") <= 7
        select new XElement("Item",
            new XElement("Customer", (string)el.Parent.Element("Name")),
            new XElement(el.Element("Key"))
        )
    );
    Console.WriteLine(xmlTree);
}
```

```vb
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
        Dim xmlTree = <Root>
                          <%=
                              From el In StreamCustomerItem("Source.xml")
                              Let itemKey = CInt(el.<Key>.Value)
                              Where itemKey >= 3 AndAlso itemKey <= 7
                              Select <Item>
                                         <Customer><%= el.Parent.<Name>.Value %></Customer>
                                         <%= el.<Key> %>
                                     </Item>
                          %>
                      </Root>

        Console.WriteLine(xmlTree)
    End Sub

End Module
```

 This code produces the following output:

```xml
<Root>
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
</Root>
```
