---
title: "XAttribute Class Overview (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 5a630f24-f9ad-400e-831e-c14ebfc9e142
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# XAttribute Class Overview (C#)
Attributes are name/value pairs that are associated with an element. The <xref:System.Xml.Linq.XAttribute> class represents XML attributes.  
  
## Overview  
 Working with attributes in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] is similar to working with elements. Their constructors are similar. The methods that you use to retrieve collections of them are similar. A [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query expression for a collection of attributes looks very similar to a [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query expression for a collection of elements.  
  
 The order in which attributes were added to an element is preserved. That is, when you iterate through the attributes, you see them in the same order that they were added.  
  
## The XAttribute Constructor  
 The following constructor of the <xref:System.Xml.Linq.XAttribute> class is the one that you will most commonly use:  
  
|Constructor|Description|  
|-----------------|-----------------|  
|`XAttribute(XName name, object content)`|Creates an <xref:System.Xml.Linq.XAttribute> object. The `name` argument specifies the name of the attribute; `content` specifies the content of the attribute.|  
  
### Creating an Element with an Attribute  
 The following code shows the common task of creating an element that contains an attribute:  
  
```csharp  
XElement phone = new XElement("Phone",  
    new XAttribute("Type", "Home"),  
    "555-555-5555");  
Console.WriteLine(phone);  
```  
  
 This example produces the following output:  
  
```xml  
<Phone Type="Home">555-555-5555</Phone>  
```  
  
### Functional Construction of Attributes  
 You can construct <xref:System.Xml.Linq.XAttribute> objects in-line with the construction of <xref:System.Xml.Linq.XElement> objects, as follows:  
  
```csharp  
XElement c = new XElement("Customers",  
    new XElement("Customer",  
        new XElement("Name", "John Doe"),  
        new XElement("PhoneNumbers",  
            new XElement("Phone",  
                new XAttribute("type", "home"),  
                "555-555-5555"),  
            new XElement("Phone",  
                new XAttribute("type", "work"),  
                "666-666-6666")  
        )  
    )  
);  
Console.WriteLine(c);  
```  
  
 This example produces the following output:  
  
```xml  
<Customers>  
  <Customer>  
    <Name>John Doe</Name>  
    <PhoneNumbers>  
      <Phone type="home">555-555-5555</Phone>  
      <Phone type="work">666-666-6666</Phone>  
    </PhoneNumbers>  
  </Customer>  
</Customers>  
```  
  
### Attributes Are Not Nodes  
 There are some differences between attributes and elements. <xref:System.Xml.Linq.XAttribute> objects are not nodes in the XML tree. They are name/value pairs associated with an XML element. In contrast to the Document Object Model (DOM), this more closely reflects the structure of XML. Although <xref:System.Xml.Linq.XAttribute> objects are not actually nodes in the XML tree, working with <xref:System.Xml.Linq.XAttribute> objects is very similar to working with <xref:System.Xml.Linq.XElement> objects.  
  
 This distinction is primarily important only to developers who are writing code that works with XML trees at the node level. Many developers will not be concerned with this distinction.  
  
## See Also  
 [LINQ to XML Programming Overview (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-programming-overview.md)
