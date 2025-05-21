---
title: Overview - LINQ to XML
description: LINQ to XML provides an in-memory XML programming interface that' based on .NET capabilities, and comparable to an updated DOM API.
ms.date: 10/30/2018
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 716b94d3-0091-4de1-8e05-41bc069fa9dd
ms.topic: concept-article
---

# LINQ to XML overview

LINQ to XML provides an in-memory XML programming interface that leverages the .NET Language-Integrated Query (LINQ) Framework. LINQ to XML uses .NET capabilities and is comparable to an updated, redesigned Document Object Model (DOM) XML programming interface.

XML has been widely adopted as a way to format data in many contexts. For example, you can find XML on the Web, in configuration files, in Microsoft Office Word files, and in databases.

LINQ to XML is an up-to-date, redesigned approach to programming with XML. It provides the in-memory document modification capabilities of the Document Object Model (DOM), and supports LINQ query expressions. Although these query expressions are syntactically different from XPath, they provide similar functionality.

## LINQ to XML developers

LINQ to XML targets a variety of developers. For an average developer who just wants to get something done, LINQ to XML makes XML easier by providing a query experience that's similar to SQL. With just a bit of study, programmers can learn to write succinct and powerful queries in their programming language of choice.

Professional developers can use LINQ to XML to greatly increase their productivity. With LINQ to XML, they can write less code that's more expressive, more compact, and more powerful. They can use query expressions from multiple data domains at the same time.

## LINQ to XML is an XML programming interface

LINQ to XML is a LINQ-enabled, in-memory XML programming interface that enables you to work with XML from within the .NET programming languages.

LINQ to XML is like the Document Object Model (DOM) in that it brings the XML document into memory. You can query and modify the document, and after you modify it you can save it to a file or serialize it and send it over the Internet. However, LINQ to XML differs from DOM:

- It provides a new object model that's lighter weight and easier to work with.
- It takes advantage of language features in C# and Visual Basic.

The most important advantage of LINQ to XML is its integration with Language-Integrated Query (LINQ). This integration enables you to write queries on the in-memory XML document to retrieve collections of elements and attributes. The query capability of LINQ to XML is comparable in functionality (although not in syntax) to XPath and XQuery. The integration of LINQ in C# and Visual Basic provides stronger typing, compile-time checking, and improved debugger support.

Another advantage of LINQ to XML is the ability to use query results as parameters to <xref:System.Xml.Linq.XElement> and <xref:System.Xml.Linq.XAttribute> object constructors enables a powerful approach to creating XML trees. This approach, called *functional construction*, enables developers to easily transform XML trees from one shape to another.

For example, you might have a typical XML purchase order as described in [Sample XML file: Typical purchase order](sample-xml-file-typical-purchase-order.md). By using LINQ to XML, you could run the following query to obtain the part number attribute value for every item element in the purchase order:

```csharp
// Load the XML file from our project directory containing the purchase orders
var filename = "PurchaseOrder.xml";
var currentDirectory = Directory.GetCurrentDirectory();
var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

XElement purchaseOrder = XElement.Load(purchaseOrderFilepath);

IEnumerable<string> partNos =  from item in purchaseOrder.Descendants("Item")
                               select (string) item.Attribute("PartNumber");
```

```vb
' Load the XML file from our project directory containing the purchase orders
Dim filename = "PurchaseOrder.xml"
Dim currentDirectory = Directory.GetCurrentDirectory()
Dim purchaseOrderFilepath = Path.Combine(currentDirectory, filename)

Dim purchaseOrder As XElement = XElement.Load(purchaseOrderFilepath)

Dim partNos = _
    From item In purchaseOrder...<Item> _
    Select item.@PartNumber
```

In C# this can be rewritten in method syntax form:

```csharp
IEnumerable<string> partNos = purchaseOrder.Descendants("Item").Select(x => (string) x.Attribute("PartNumber"));
```

As another example, you might want a list, sorted by part number, of the items with a value greater than $100. To obtain this information, you could run the following query:

```csharp
// Load the XML file from our project directory containing the purchase orders
var filename = "PurchaseOrder.xml";
var currentDirectory = Directory.GetCurrentDirectory();
var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);

XElement purchaseOrder = XElement.Load(purchaseOrderFilepath);

IEnumerable<XElement> pricesByPartNos =  from item in purchaseOrder.Descendants("Item")
                                 where (int) item.Element("Quantity") * (decimal) item.Element("USPrice") > 100
                                 orderby (string)item.Element("PartNumber")
                                 select item;
```

```vb
' Load the XML file from our project directory containing the purchase orders
Dim filename = "PurchaseOrder.xml"
Dim currentDirectory = Directory.GetCurrentDirectory()
Dim purchaseOrderFilepath = Path.Combine(currentDirectory, filename)

Dim purchaseOrder As XElement = XElement.Load(purchaseOrderFilepath)

Dim partNos = _
From item In purchaseOrder...<Item> _
Where (item.<Quantity>.Value * _
       item.<USPrice>.Value) > 100 _
Order By item.<PartNumber>.Value _
Select item
```

Again, in C# this can be rewritten in method syntax form:

```csharp
IEnumerable<XElement> pricesByPartNos = purchaseOrder.Descendants("Item")
                                        .Where(item => (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100)
                                        .OrderBy(order => order.Element("PartNumber"));
```

In addition to these LINQ capabilities, LINQ to XML provides an improved XML programming interface. Using LINQ to XML, you can:

- Load XML from [files](load-xml-file.md) or [streams](stream-xml-fragments-xmlreader.md).
- Serialize XML to files or streams.
- Create XML from scratch by using functional construction.
- Query XML using XPath-like axes.
- Manipulate the in-memory XML tree by using methods such as <xref:System.Xml.Linq.XContainer.Add%2A>, <xref:System.Xml.Linq.XNode.Remove%2A>, <xref:System.Xml.Linq.XNode.ReplaceWith%2A>, and <xref:System.Xml.Linq.XElement.SetValue%2A>.
- Validate XML trees using XSD.
- Use a combination of these features to transform XML trees from one shape into another.

## Create XML trees

One of the most significant advantages of programming with LINQ to XML is that it's easy to create XML trees. For example, to create a small XML tree, you can write code as follows:

```csharp
XElement contacts =
new XElement("Contacts",
    new XElement("Contact",
        new XElement("Name", "Patrick Hines"),
        new XElement("Phone", "206-555-0144",
            new XAttribute("Type", "Home")),
        new XElement("phone", "425-555-0145",
            new XAttribute("Type", "Work")),
        new XElement("Address",
            new XElement("Street1", "123 Main St"),
            new XElement("City", "Mercer Island"),
            new XElement("State", "WA"),
            new XElement("Postal", "68042")
        )
    )
);
```

```vb
Dim contacts As XElement = _
    <Contacts>
        <Contact>
            <Name>Patrick Hines</Name>
            <Phone>206-555-0144</Phone>
            <Address>
                <Street1>123 Main St</Street1>
                <City>Mercer Island</City>
                <State>WA</State>
                <Postal>68042</Postal>
            </Address>
        </Contact>
    </Contacts>
```

> [!NOTE]
> The Visual Basic version of the example uses XML literals. You can also use <xref:System.Xml.Linq.XElement> in Visual Basic, as in the C# version.

For more information, see [XML trees](functional-construction.md).

## See also

- [Reference](reference.md)
- [LINQ to XML vs. DOM](linq-xml-vs-dom.md)
- [LINQ to XML vs. other XML technologies](linq-xml-vs-xml-technologies.md)
- <xref:System.Xml.Linq>
