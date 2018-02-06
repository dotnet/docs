---
title: "How to: Retrieve a Single Attribute (LINQ to XML) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 1b6b07b9-933f-47e9-874e-e790cab49dc5
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Retrieve a Single Attribute (LINQ to XML) (C#)
This topic explains how to retrieve a single attribute of an element, given the attribute name. This is useful for writing query expressions where you want to find an element that has a particular attribute.  
  
 The <xref:System.Xml.Linq.XElement.Attribute%2A> method of the <xref:System.Xml.Linq.XElement> class returns the <xref:System.Xml.Linq.XAttribute> with the specified name.  
  
## Example  
 The following example uses the <xref:System.Xml.Linq.XElement.Attribute%2A> method.  
  
```csharp  
XElement cust = new XElement("PhoneNumbers",  
    new XElement("Phone",  
        new XAttribute("type", "home"),  
        "555-555-5555"),  
    new XElement("Phone",  
        new XAttribute("type", "work"),  
        "555-555-6666")  
);  
IEnumerable<XElement> elList =  
    from el in cust.Descendants("Phone")  
    select el;  
foreach (XElement el in elList)  
    Console.WriteLine((string)el.Attribute("type"));  
```  
  
 This example finds all the descendants in the tree named `Phone`, and then finds the attribute named `type`.  
  
 This code produces the following output:  
  
```  
home  
work  
```  
  
## Example  
 If you want to retrieve the value of the attribute, you can cast it, just as you do for with <xref:System.Xml.Linq.XElement> objects. The following example demonstrates this.  
  
```csharp  
XElement cust = new XElement("PhoneNumbers",  
    new XElement("Phone",  
        new XAttribute("type", "home"),  
        "555-555-5555"),  
    new XElement("Phone",  
        new XAttribute("type", "work"),  
        "555-555-6666")  
);  
IEnumerable<XElement> elList =   
    from el in cust.Descendants("Phone")  
    select el;  
foreach (XElement el in elList)  
    Console.WriteLine((string)el.Attribute("type"));  
```  
  
 This code produces the following output:  
  
```  
home  
work  
```  
  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] provides explicit cast operators for the <xref:System.Xml.Linq.XAttribute> class to `string`, `bool`, `bool?`, `int`, `int?`, `uint`, `uint?`, `long`, `long?`, `ulong`, `ulong?`, `float`, `float?`, `double`, `double?`, `decimal`, `decimal?`, `DateTime`, `DateTime?`, `TimeSpan`, `TimeSpan?`, `GUID`, and `GUID?`.  
  
## Example  
 The following example shows the same code for an attribute that is in a namespace. For more information, see [Working with XML Namespaces (C#)](../../../../csharp/programming-guide/concepts/linq/working-with-xml-namespaces.md).  
  
```csharp  
XNamespace aw = "http://www.adventure-works.com";  
XElement cust = new XElement(aw + "PhoneNumbers",  
    new XElement(aw + "Phone",  
        new XAttribute(aw + "type", "home"),  
        "555-555-5555"),  
    new XElement(aw + "Phone",  
        new XAttribute(aw + "type", "work"),  
        "555-555-6666")  
);  
IEnumerable<XElement> elList =  
    from el in cust.Descendants(aw + "Phone")  
    select el;  
foreach (XElement el in elList)  
    Console.WriteLine((string)el.Attribute(aw + "type"));  
```  
  
 This code produces the following output:  
  
```  
home  
work  
```  
  
## See Also  
 [LINQ to XML Axes (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-axes.md)
