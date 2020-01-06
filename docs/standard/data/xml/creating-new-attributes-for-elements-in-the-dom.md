---
title: "Creating New Attributes for Elements in the DOM"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: dd6dc920-b011-418a-b3db-f1580a7d9251
---
# Creating New Attributes for Elements in the DOM

Creating new attributes is different than creating other node types, because attributes are not nodes, but are properties of an element node and are contained in an **XmlAttributeCollection** associated with the element. There are multiple ways to create an attribute and attach it to an element:

- Get the element node and use **SetAttribute** to add an attribute to the attribute collection of that element.

- Create an **XmlAttribute** node using the **CreateAttribute** method, get the element node, then use **SetAttributeNode** to add the node to the attribute collection of that element.

The following example shows how to add an attribute to an element using the **SetAttribute** method:

```vb
Imports System.IO
Imports System.Xml

Public Class Sample

    Public Shared Sub Main()

        Dim doc As New XmlDocument()
        doc.LoadXml("<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "</book>")
        Dim root As XmlElement = doc.DocumentElement

        ' Add a new attribute.
        root.SetAttribute("genre", "urn:samples", "novel")

        Console.WriteLine("Display the modified XML...")
        Console.WriteLine(doc.InnerXml)
    End Sub
End Class
```  
  
```csharp
using System;
using System.IO;
using System.Xml;

public class Sample
{
    public static void Main()
    {
        var doc = new XmlDocument();
        doc.LoadXml("<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>" +
                    "<title>Pride And Prejudice</title>" +
                    "</book>");
        XmlElement root = doc.DocumentElement;

        // Add a new attribute.
        root.SetAttribute("genre", "urn:samples", "novel");

        Console.WriteLine("Display the modified XML...");
        Console.WriteLine(doc.InnerXml);
    }
}
```

The following example shows a new attribute being created using the **CreateAttribute** method. It then shows the attribute added to the attribute collection of the **book** element using the **SetAttributeNode** method.

Given the following XML:
  
```xml
<book genre='novel' ISBN='1-861001-57-5'>
<title>Pride And Prejudice</title>
</book>
```

create a new attribute and give it a value:

```vb
Dim attr As XmlAttribute = doc.CreateAttribute("publisher")
attr.Value = "WorldWide Publishing"
```

```csharp
XmlAttribute attr = doc.CreateAttribute("publisher");
attr.Value = "WorldWide Publishing";
```

and attach it to the element:

```vb
doc.DocumentElement.SetAttributeNode(attr)
```

```csharp
doc.DocumentElement.SetAttributeNode(attr);
```

**Output**

```xml
<book genre="novel" ISBN="1-861001-57-5" publisher="WorldWide Publishing">
<title>Pride And Prejudice</title>
</book>
```

The full code sample can be found at <xref:System.Xml.XmlDocument.CreateAttribute%2A>.

You can also create an **XmlAttribute** node and use the **InsertBefore** or **InsertAfter** methods to place it in the appropriate position in the collection. If an attribute with the same name is already present in the attribute collection, the existing **XmlAttribute** node is removed from the collection and the new **XmlAttribute** node is inserted. This performs the same way as the **SetAttribute** method. These methods take, as a parameter, an existing node as a reference point to do the **InsertBefore** and **InsertAfter**. If you do not provide a reference node indicating where to insert the new node, the default for the **InsertAfter** method is to insert the new node at the beginning of the collection. The default position for the **InsertBefore**, if no reference node is provided, is at the end of the collection.

If you created an **XmlNamedNodeMap** of attributes, you can add an attribute by name using the <xref:System.Xml.XmlNamedNodeMap.SetNamedItem%2A> method. For more information, see [Node Collections in NamedNodeMaps and NodeLists](node-collections-in-namednodemaps-and-nodelists.md).

## Default attributes

If you create an element that is declared to have a default attribute, then a new default attribute with its default value is created by the XML Document Object Model (DOM) and attached to the element. The child nodes of the default attribute are also created at this time.

## Attribute child nodes

The value of an attribute node becomes its child nodes. There are only two types of valid child nodes: **XmlText** nodes and **XmlEntityReference** nodes. These are child nodes in the sense that methods such as **FirstChild** and **LastChild** process them as child nodes. This distinction of an attribute having child nodes is important when trying to remove attributes or attribute child nodes. For more information, see [Removing Attributes from an Element Node in the DOM](removing-attributes-from-an-element-node-in-the-dom.md).

## See also

- [XML Document Object Model (DOM)](xml-document-object-model-dom.md)
