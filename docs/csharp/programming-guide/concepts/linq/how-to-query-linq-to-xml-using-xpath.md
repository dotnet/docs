---
title: "How to: Query LINQ to XML Using XPath (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: ee5af263-4ab1-45e5-b792-33a3221b426d
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Query LINQ to XML Using XPath (C#)
This topic introduces the extension methods that enable you to query an XML tree by using XPath. For detailed information about using these extension methods, see <xref:System.Xml.XPath.Extensions?displayProperty=nameWithType>.  
  
 Unless you have a very specific reason for querying using XPath, such as extensive use of legacy code, using XPath with LINQ to XML is not recommended. XPath queries will not perform as well as [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] queries.  
  
## Example  
 The following example creates a small XML tree and uses <xref:System.Xml.XPath.Extensions.XPathSelectElements%2A> to select a set of elements.  
  
```csharp  
XElement root = new XElement("Root",  
    new XElement("Child1", 1),  
    new XElement("Child1", 2),  
    new XElement("Child1", 3),  
    new XElement("Child2", 4),  
    new XElement("Child2", 5),  
    new XElement("Child2", 6)  
);  
IEnumerable<XElement> list = root.XPathSelectElements("./Child2");  
foreach (XElement el in list)  
    Console.WriteLine(el);  
```  
  
 This example produces the following output:  
  
```xml  
<Child2>4</Child2>  
<Child2>5</Child2>  
<Child2>6</Child2>  
```  
  
## See Also  
 [Advanced Query Techniques (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/advanced-query-techniques-linq-to-xml.md)
