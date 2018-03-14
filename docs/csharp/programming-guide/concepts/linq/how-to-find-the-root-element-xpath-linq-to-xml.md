---
title: "How to: Find the Root Element (XPath-LINQ to XML) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 4fd824e0-4d39-429b-b092-f6a5c046ee6c
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Find the Root Element (XPath-LINQ to XML) (C#)
This topic shows how to get the root element with XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)].  
  
 The XPath expression is:  
  
 `/PurchaseOrders`  
  
## Example  
 This example finds the root element.  
  
 This example uses the following XML document: [Sample XML File: Multiple Purchase Orders (LINQ to XML)](../../../../csharp/programming-guide/concepts/linq/sample-xml-file-multiple-purchase-orders-linq-to-xml.md).  
  
```csharp  
XDocument po = XDocument.Load("PurchaseOrders.xml");  
  
// LINQ to XML query  
XElement el1 = po.Root;  
  
// XPath expression  
XElement el2 = po.XPathSelectElement("/PurchaseOrders");  
  
if (el1 == el2)  
    Console.WriteLine("Results are identical");  
else  
    Console.WriteLine("Results differ");  
Console.WriteLine(el1.Name);  
```  
  
 This example produces the following output:  
  
```  
Results are identical  
PurchaseOrders  
```  
  
## See Also  
 [LINQ to XML for XPath Users (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-for-xpath-users.md)
