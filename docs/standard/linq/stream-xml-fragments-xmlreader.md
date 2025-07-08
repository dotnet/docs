---
title: How to stream XML fragments from an XmlReader - LINQ to XML
description: You can stream XML fragments from an XmlReader using a custom axis method in C# and Visual Basic. This is an approach that can work when loading the whole XML tree into memory is infeasible.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to stream XML fragments from an XmlReader (LINQ to XML)

When you have to process large XML files, it might not be feasible to load the whole XML tree into memory. This article shows how to stream fragments using an <xref:System.Xml.XmlReader> in C# and Visual Basic.

One of the most effective ways to use an <xref:System.Xml.XmlReader> to read <xref:System.Xml.Linq.XElement> objects is to write your own custom axis method. An axis method typically returns a collection such as <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement>, as shown in the example in this article. In the custom axis method, after you create the XML fragment by calling the <xref:System.Xml.Linq.XNode.ReadFrom%2A> method, return the collection using `yield return`. This provides deferred execution semantics to your custom axis method.

When you create an XML tree from an <xref:System.Xml.XmlReader> object, the <xref:System.Xml.XmlReader> must be positioned on an element. The <xref:System.Xml.Linq.XNode.ReadFrom%2A> method doesn't return until it has read the close tag of the element.

If you want to create a partial tree, you can instantiate an <xref:System.Xml.XmlReader>, position the reader on the node that you want to convert to an <xref:System.Xml.Linq.XElement> tree, and then create the <xref:System.Xml.Linq.XElement> object.

The article [How to stream XML fragments with access to header information](stream-xml-fragments-access-header-information.md) contains information on streaming a more complex document.

The article [How to perform streaming transform of large XML documents](perform-streaming-transform-large-xml-documents.md) contains an example of using LINQ to XML to transform extremely large XML documents while maintaining a small memory footprint.

## Example: Create a custom axis method

This example creates a custom axis method. You can query it by using a LINQ query. The custom axis method `StreamRootChildDoc` can read a document that has a repeating `Child` element.

```csharp
using System.Xml;
using System.Xml.Linq;

static IEnumerable<XElement> StreamRootChildDoc(StringReader stringReader)
{
    using XmlReader reader = XmlReader.Create(stringReader);

    reader.MoveToContent();

    // Parse the file and display each of the nodes.
    while (true)
    {
        // If the current node is an element and named "Child"
        if (reader.NodeType == XmlNodeType.Element && reader.Name == "Child")
        {
            // Get the current node and advance the reader to the next
            if (XNode.ReadFrom(reader) is XElement el)
                yield return el;

        }
        else if (!reader.Read())
            break;
    }
}

string markup = """
                <Root>
                  <Child Key="01">
                    <GrandChild>aaa</GrandChild>
                  </Child>
                  <Child Key="02">
                    <GrandChild>bbb</GrandChild>
                  </Child>
                  <Child Key="03">
                    <GrandChild>ccc</GrandChild>
                  </Child>
                </Root>
                """;

IEnumerable<string> grandChildData =
    from el in StreamRootChildDoc(new StringReader(markup))
    where (int)el.Attribute("Key") > 1
    select (string)el.Element("GrandChild");

foreach (string str in grandChildData)
    Console.WriteLine(str);
```

```vb
Imports System.Xml

Module Module1

    Public Iterator Function StreamRootChildDoc(stringReader As IO.StringReader) As IEnumerable(Of XElement)
        Using reader As XmlReader = XmlReader.Create(stringReader)
            reader.MoveToContent()

            ' Parse the file and display each of the nodes.
            While True

                ' If the current node is an element and named "Child"
                If reader.NodeType = XmlNodeType.Element And reader.Name = "Child" Then

                    ' Get the current node and advance the reader to the next
                    Dim el As XElement = TryCast(XNode.ReadFrom(reader), XElement)

                    If (el IsNot Nothing) Then
                        Yield el
                    End If

                ElseIf Not reader.Read() Then
                    Exit While
                End If

            End While
        End Using
    End Function

    Sub Main()

        Dim markup = "<Root>
                       <Child Key=""01"">
                         <GrandChild>aaa</GrandChild>
                       </Child>
                       <Child Key=""02"">
                         <GrandChild>bbb</GrandChild>
                       </Child>
                       <Child Key=""03"">
                         <GrandChild>ccc</GrandChild>
                       </Child>
                     </Root>"

        Dim grandChildData =
             From el In StreamRootChildDoc(New IO.StringReader(markup))
             Where CInt(el.@Key) > 1
             Select el.<GrandChild>.Value

        For Each s In grandChildData
            Console.WriteLine(s)
        Next

    End Sub
End Module
```

This example produces the following output:

```output
bbb
ccc
```

The technique used in this example maintains a small memory footprint even for millions of `Child` elements.

## See also

- [Parse XML](parse-string.md)
